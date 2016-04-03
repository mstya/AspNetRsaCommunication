$(function () {
    debugger;
    var registerManager = new RsaRegisterManager(pukey);
    var encryptedEmail = $("#fakeEmail").val();

    if (encryptedEmail !== "") {
        var login = LocalStorage.getValue("login");
        $("#fakeEmail").val(login);
    }

    $("#Register").click(function () {

        registerManager.submitForm({
            $login: $("#fakeEmail"),
            $password: $("#fakePassword"),
            $confirmPassword: $("#fakeConfirmPassword")
        }, {
            $login: $("#Email"),
            $password: $("#Password"),
            $confirmPassword: $("#ConfirmPassword")
        });

    });
});