$(function () {
    var loginManager = new RsaLoginManager(pukey);
    var encryptedEmail = $("#fakeEmail").val();

    if (encryptedEmail !== "") {
        var login = LocalStorage.getValue("login");
        $("#fakeEmail").val(login);
    }

    $("#LogIn").click(function() {

        loginManager.submitForm({
            $login: $("#fakeEmail"),
            $password: $("#fakePassword")
        }, {
            $login: $("#Email"),
            $password: $("#Password")
        });

    });
});