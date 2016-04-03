var LocalStorage = (function() {
    function LocalStorage() {}

    LocalStorage.setValue = function(key, value) {
        localStorage.setItem(key, value);
    };

    LocalStorage.getValue = function(key) {
        return localStorage.getItem(key);
    };

    return LocalStorage;
})();