var AddProductModel = {
    productModel: {
        name: "",
        price: "",
        description: "",
        image: "",
    },
    successMessage: [],
    errorMessage: [],
    showError: false,
    showSuccess: false
}

var vm = new Vue({
    el: '#EditProduct',
    data: AddProductModel,
    created: function () {
        var self = this;
        Object.assign(self.$data.productModel, model);
    },
    methods: {
        saveNewProduct: function () {
            this.checkForErrors();
            if (this.errorMessage && this.errorMessage.length > 0) {
                $('#dangerToast').toast('show');
            } else {
                AxiosPost(productSaveUrl, this.$data.productModel, this.successAddProduct, this.falureAddProduct)
            }
        },
        getImageDetials: function (img) {
            debugger;
            var self = this;
            var file = img[0];
            var reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = function () {
                self.productModel.Image = reader.result;
            };
            reader.onerror = function (error) {
                falureAddProduct(error);
            };
        },
        successAddProduct: function (data) {
            debugger;
            if (data.success != true) {
                this.errorMessage = [];
                this.errorMessage.push(data.errorMessage);
                this.showError = true;
                $('#dangerToast').toast('show');
            } else {
                var self = this;
                self.successMessage.push("The product was successfully added");
                $('#successToast').toast('show');
                Object.assign(this.$data, {});
                Object.assign(this.$data, AddProductModel);
            }
        },
        falureAddProduct: function (data) {
            this.errorMessage = [];
            this.errorMessage.push("An Error has occured: " + data + "");
            this.showError = true;
            $('#dangerToast').toast('show');
        },

        //validation checking   
        checkProductName: function () {
            return (!this.productModel.Name || this.productModel.Name.length < 5)
        },
        checkProductPrice: function () {
            debugger;
            return (!this.productModel.Price || isNaN(this.productModel.Price))
        },
        checkProductDescription: function () {
            return (!this.productModel.Description || this.productModel.Description.length < 5)
        },

        checkForErrors: function () {
            var self = this;
            self.errorMessage = [];
            if (self.checkProductName()) {
                self.errorMessage.push("Please provide a product name");
            }
            if (self.checkProductPrice()) {
                self.errorMessage.push("Please enter a valid product price");
            }
            if (self.checkProductDescription()) {
                self.errorMessage.push("Please provide a valid product description");
            }
        }
    }
});