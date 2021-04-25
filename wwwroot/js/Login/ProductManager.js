var ProductDataModel = {
    productModel = {
        Name: "",
        Price: "",
        Description: "",
        Image: "",
    },
    products:[]
}
var vm = new Vue({
    el: '#Products',
    data: ProductDataModel,
    methods: {
        login: function () {
            AxiosPost(loginUrl, { UserName: this.$data.UserName, Password: this.$data.Password }, this.successLogin, this.falureLogin);
        },
        async getProducts() {
            debugger;
            await AxiosGet(getProductsUrl, null, this.successLogin, this.falureProduct);
        },
        successProduct: function (data) {
            debugger;
            if (data.success != true) {
                this.errorMessage = [];
                this.errorMessage.push(data.errorMessage);
                this.showError = true;
                $('#dangerToast').toast('show');
            } else {
                window.location = data.urlLocation;
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