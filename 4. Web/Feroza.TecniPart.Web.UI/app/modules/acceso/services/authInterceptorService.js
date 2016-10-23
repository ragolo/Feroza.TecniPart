"use strict";
angular
      .module("app.acceso").factory("authInterceptorService", ['$q', '$location', 'localStorageService', "$injector", function ($q, $location, localStorageService, $injector) {

          var authInterceptorServiceFactory = {};

          var request = function (config) {

              config.headers = config.headers || {};

              var authData = localStorageService.get("authorizationData");
              if (authData) {
                  config.headers.Authorization = "Bearer " + authData.token;
              }

              return config;
          }

          var responseError = function (rejection) {

              if (rejection.status === 401) {
                  console.log(rejection.status);
                  var $state = $injector.get("$state");
                  window.location.href = "www.google.com";
                  window.location.replace("http://www.google.com");
                  //$state.transitionTo("app.busquedaview");
              }
              return $q.reject(rejection);
          }

          authInterceptorServiceFactory.request = request;
          authInterceptorServiceFactory.responseError = responseError;

    return authInterceptorServiceFactory;
}]);