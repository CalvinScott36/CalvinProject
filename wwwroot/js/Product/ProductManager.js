var ProductDataModel = {
    products: [],
    errorMessage: "",
    successMessage:"",

}
var vm = new Vue({
    el: '#Products',
    data: ProductDataModel,
    methods: {
        login: function () {
            AxiosPost(loginUrl, { UserName: this.$data.UserName, Password: this.$data.Password }, this.successLogin, this.falureLogin);
        },
        editProduct: function (product) {
            AxiosPost(gotToEditProductsUrl, product, this.successProduct, this.falureProduct);
        },
        getProducts() {
            debugger;
            AxiosGet(getProductsUrl, null, this.successProduct, this.falureProduct);
        },
        successProduct: function (data) {
            debugger;
            if (data.success && data.success != true) {
                this.errorMessage = [];
                this.errorMessage.push(data.errorMessage);
                this.showError = true;
                $('#dangerToast').toast('show');
            } else if (typeof data == 'string') {
                window.location = data;
            } else {
                this.products.push(...data.products);
            }
        },
        falureProduct: function (data) {
            this.errorMessage = [];
            this.errorMessage.push("An Error has occured");
            this.showError = true;
            $('#dangerToast').toast('show');
        }

    },
    created() {
        this.getProducts();
    }
});