(function() {
    "use strict";
    angular
        .module("tecnipartWeb")
            .config(config);
    config.$inject = ["$httpProvider"];

    function config($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    }
})();

