(function() {
    'use strict';

    angular
        .module('app.core')
        .config(coreConfig)
    ;

    coreConfig.$inject = ['$controllerProvider', '$compileProvider', '$filterProvider', '$provide', '$animateProvider', "toastrConfig"];
    function coreConfig($controllerProvider, $compileProvider, $filterProvider, $provide, $animateProvider, toastrConfig) {

      var core = angular.module('app.core');
      // registering components after bootstrap
      core.controller = $controllerProvider.register;
      core.directive  = $compileProvider.directive;
      core.filter     = $filterProvider.register;
      core.factory    = $provide.factory;
      core.service    = $provide.service;
      core.constant   = $provide.constant;
      core.value      = $provide.value;

      // Disables animation on items with class .ng-no-animation
      $animateProvider.classNameFilter(/^((?!(ng-no-animation)).)*$/);

      angular.extend(toastrConfig, {
          autoDismiss: false,
          extendedTimeOut: 1000,
          containerId: 'toast-container',
          closeButton: true,
          progressBar: true,
          maxOpened: 5,
          newestOnTop: true,
          positionClass: 'toast-bottom-right',
          preventDuplicates: true,
          preventOpenDuplicates: true,
          target: 'body'
      });
      // Improve performance disabling debugging features
      // $compileProvider.debugInfoEnabled(false);

    }

})();