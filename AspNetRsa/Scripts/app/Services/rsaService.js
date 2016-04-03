var RsaManager = (function () {
    function RsaManager(key) {
        this.doOaepPadding = false;
        this.bitHelper = new ByteHelper();
        this.publicKey = key;
    }

    RsaManager.prototype.encrypt = function (dataToEncrypt) {
        var rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
        rsa.FromXmlString(this.publicKey);

        var decryptedBytes = System.Text.Encoding.UTF8.GetBytes(dataToEncrypt);
        var encryptedBytes = rsa.Encrypt(decryptedBytes, this.doOaepPadding);

        return this.bitHelper.toCommaString(encryptedBytes);
    };

    return RsaManager;
}());