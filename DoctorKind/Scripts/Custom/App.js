function ViewModel() {
    var self = this;

    var tokenKey = 'accessToken';
    var RefTokenKey = 'refreshToken';
    self.result = ko.observable();
    self.user = ko.observable();

    self.registerEmail = ko.observable();
    self.registerPassword = ko.observable();
    self.registerPassword2 = ko.observable();

    self.loginEmail = ko.observable();
    self.loginPassword = ko.observable();
    self.token = ko.observable();
    self.refreshToken = ko.observable();
    function showError(jqXHR) {
        self.result(jqXHR.status + ': ' + jqXHR.statusText);
    }

    self.callApi = function () {

        self.result('');

        var token = sessionStorage.getItem(tokenKey);

        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'GET',
            url: '/api/values',
            headers: headers
        }).done(function (data) {
            self.result(data);
        }).fail(showError);
    }

    self.callToken = function () {
        self.result('');
        // alert(self.loginEmail());  
        // alert(self.loginPassword());  
        var loginData = {
            grant_type: 'password',
            username: self.loginEmail(),
            password: self.loginPassword()
        };

        $.ajax({
            type: 'POST',
            url: '/Token',
            data: loginData
        }).done(function (data) {
            self.user(data.userName);
            // Cache the access token in session storage.  
            sessionStorage.setItem(tokenKey, data.access_token);
            var tkn = sessionStorage.getItem(tokenKey);
            $("#tknKey").val(tkn);
        }).fail(showError);
    }

}

var app = new ViewModel();
ko.applyBindings(app);