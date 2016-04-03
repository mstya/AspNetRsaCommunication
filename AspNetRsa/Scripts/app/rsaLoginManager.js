﻿var RsaLoginManager = (function() {
    function RsaLoginManager(publicKey) {
        this.rsaManager = new RsaManager(publicKey);
    }

    RsaLoginManager.prototype.submitForm = function($userFields, $hiddenFields) {

        var login = $userFields.$login.val();
        var password = $userFields.$password.val();

        var encrypedLogin = this.rsaManager.encrypt(login);
        var encrypedPassword = this.rsaManager.encrypt(password);

        $hiddenFields.$login.val(encrypedLogin);
        $hiddenFields.$password.val(encrypedPassword);

        localStorage.setItem('login', login);
        $hiddenFields.$login.closest("form").submit();
    };

    RsaLoginManager.prototype.getLogin = function() {
        return localStorage.getItem("login");
    }

    return RsaLoginManager;
})();