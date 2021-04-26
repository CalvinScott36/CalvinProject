var userModel = {
    UserName: '',
    Password: '',
    successMessage: [],
    errorMessage: [],
    showError: false,
    showSuccess: false
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
                this.errorMessage = [];
                this.errorMessage.push(data.errorMessage);
                this.showError = true;
                $('#dangerToast').toast('show');
            } else {
                window.location = data.urlLocation;
            }
        },
        falureLogin: function (data) {
            this.errorMessage = [];
            this.errorMessage.push("An Error has occured");
            this.showError = true;
            $('#dangerToast').toast('show');
        },
        register: function () {
            AxiosGet(registerUrl, null, null, null);
        }
    }
});