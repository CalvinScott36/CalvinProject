var newUserModel = {
    UserName: '',
    Password: '',
    Firstname: '',
    Surname: '',
    successMessage: '',
    errorMessage: '',
    showError: false,
    showSuccess: false,
    Email: '',
    PhoneCountry: '',
    PhoneNumber: '',
    PhoneCountry: '',
    PhoneCountrySelections: ['18', '12', '13', '27'],
    JobDescriptions: ['Not Applicable','Accountant', 'Developer', 'Beautician', 'Other'],
    JobDescription: '',
    ConfirmPassword: '',
}

var vm = new Vue({
    el: "#register",
    data: newUserModel,
    methods: {
        registerUser: function() {
            AxiosPost(this.registerUrl, this.$data, this.successRegister, this.falureRegister);
        },
        successRegister: function (data) {
            debugger;
            if (data.success != true) {
                this.errorMessage = data.errorMessage;
                showError = true;
                $('#dangerToast').toast('show');
            }
        },
        falureRegister: function (data) {
            this.errorMessage = "An Error has occured";
            showError = true;
            $('#dangerToast').toast('show');
        },
        // check parameter methods
        checkFirstName: function () {
            if (!this.Firstname) {
                return true;
            } else {
                return false;
            }
        },
        checkSurname: function () {
            if (!this.Surname) {
                return true;
            } else {
                return false;
            }
        },
        checkEmail: function () {
            const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return !(re.test(String(this.Email).toLowerCase()));
        },
        checkPhoneNumber: function () {
            const re = /^\d{10}$/;
            return !(re.test(String(this.PhoneNumber).toLowerCase()));
        },
        checkJobDescriptions: function () {
            return (!this.JobDescription)
        },
        checkPassword: function () {
            return (!this.Password || this.Password.length < 5)
        },
        checkConfirmationPassword: function () {
            return !(this.ConfirmPassword) || !(this.Password == this.ConfirmPassword)
        }
    }
});