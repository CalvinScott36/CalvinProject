var newUserModel = {
    UserName: '',
    Password: '',
    Firstname: '',
    Surname: '',
    successMessage: '',
    errorMessage: '',
    showError: false,
    showSuccess: true,
    Email: '',
    PhoneCountry: '',
    PhoneNumber: '',
    PhoneCountry: '',
    PhoneCountrySelections: ['18', '12', '13', '27'],
    JobDescriptions: ['Accountant', 'Developer', 'Beautician'],
    JobDescription: '',
    ConfirmPassword: '',
}

var vm = new Vue({
    el: "#register",
    data: newUserModel,
    methods: {
        checkFirstName: function () {
            if (!this.Firstname) {
                return true;
            } else {
                return false;
            }
        }
    }
});