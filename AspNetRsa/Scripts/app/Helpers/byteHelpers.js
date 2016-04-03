var ByteHelper = (function() {
    function ByteHelper() {
        
    }

    ByteHelper.prototype.toCommaString = function (bytes) {
        return bytes.join(",");
    };

    return ByteHelper;
})();