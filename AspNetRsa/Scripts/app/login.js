$(function () {
    var loginManager = new RsaLoginManager(pukey);
    var encryptedEmail = $("#fakeEmail").val();

    if (encryptedEmail !== "") {
        var login = loginManager.getLogin();
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