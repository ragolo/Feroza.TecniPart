(function () {
    'use strict';

    angular
        .module('app.acceso')
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });
})();