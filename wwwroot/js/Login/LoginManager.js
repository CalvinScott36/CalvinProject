var userModel = {
    UserName: '',
    Password: '',
    successMessage: '',
    errorMessage: '',
    showError: false,
    showSuccess:true
}

var vm = new Vue({
    el: '#login',
    data: userModel,
    methods: {
        login: function () {
            AxiosPost(loginUrl, { UserName: this.$data.UserName, Password: this.$data.Password }, this.successLogin, this.falureLogin);
        },
        successLogin: function (data) {
            debugger;
            if (data.success != true) {
                this.errorMessage = data.errorMessage;
                showError = true;
                $('#dangerToast').toast('show');
            }
        },
        falureLogin: function (data) {
            this.errorMessage = "An Error has occured";
            showError = true;
            $('#dangerToast').toast('show');
        },
        register: function () {
            AxiosGet(registerUrl, null, null, null);
        }
    }
});