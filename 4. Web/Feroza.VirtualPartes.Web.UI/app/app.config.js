(function() {
    'use strict';

    angular
        .module('angle')
            .config(config);
    config.$inject = ["$httpProvider"];

    function config($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    }
})();

