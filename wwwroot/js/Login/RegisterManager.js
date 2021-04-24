var newUserModel = {
    UserName: '',
    Password: '',
    Firstname: '',
    Surname: '',
    successMessage: [],
    errorMessage: [],
    showError: false,
    showSuccess: false,
    Email: '',
    PhoneCountry: '',
    PhoneNumber: '',
    PhoneCountry: '',
    PhoneCountrySelections: ['18', '12', '13', '27'],
    JobDescriptions: ['Not Applicable', 'Accountant', 'Developer', 'Beautician', 'Other'],
    JobDescription: '',
    ConfirmPassword: '',
}

var vm = new Vue({
    el: "#register",
    data: newUserModel,
    methods: {
        registerUser: function () {
            var self = this;
            debugger;
            this.checkForErrors()
            if (self.errorMessage.length > 0) {
                self.showError = true;
                $('#dangerToast').toast('show');
            } else {
                self.showError = false;
                AxiosPost(registerUrl, this.$data, this.successRegister, this.falureRegister);
            }
        },
        successRegister: function (data) {
            debugger;
            if (data.success != true) {
                this.errorMessage = []
                this.errorMessage.push(data.errorMesssage);
                self.showError = true;
                $('#dangerToast').toast('show');
            } else {
                this.successMessage.push("Successfully registered");
                $('#successToast').toast('show');
            }
        },
        falureRegister: function (data) {
            this.errorMessage = [];
            this.errorMessage.push("An Error has occured");
            showError = true;
            $('#dangerToast').toast('show');
        },
        checkForErrors: function () {
            var self = this;
            self.errorMessage = [];
            if (self.checkFirstName()) {
                self.errorMessage.push("Please fill in your first name");
            }
            if (self.checkSurname()) {
                self.errorMessage.push("Please fill in your Surname");
            }
            if (self.checkEmail()) {
                self.errorMessage.push("Invalid email");
            }
            if (self.checkPhoneNumber()) {
                self.errorMessage.push("Invalid phone number");
            }
            if (self.checkPassword()) {
                self.errorMessage.push("Invalid password");
            }
            if (self.checkConfirmationPassword()) {
                self.errorMessage.push("passwords dont match");
            }
            if (self.checkUserName()) {
                self.errorMessage.push("please fill in your username");
            }
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
            return !(this.Password == this.ConfirmPassword)
        },
        checkUserName: function () {
            return (!this.UserName)
        }
    }
});