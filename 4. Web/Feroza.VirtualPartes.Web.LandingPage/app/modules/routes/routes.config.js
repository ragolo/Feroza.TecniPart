/**=========================================================
 * Module: config.js
 * App routes and resources configuration
 =========================================================*/


//(function () {
'use strict';

angular
    .module('app.routes')
    .config(routesConfig);

routesConfig.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider', 'RouteHelpersProvider'];
function routesConfig($stateProvider, $locationProvider, $urlRouterProvider, helper) {

    // Set the following to true to enable the HTML5 Mode
    // You may have to set <base> tag in index and a routing configuration in your server
    $locationProvider.html5Mode(false);

    // defaults to dashboard
    $urlRouterProvider.otherwise("Pais/IndexView");

    // 
    // Application Routes
    // -----------------------------------   


    $stateProvider
      .state("tecnipartWeb",
      {
          //url: '/',
          abstract: true,
          resolve: helper.resolveFor("modernizr", "icons"),
          views: {
              'content': {
                  template:
                      '<div data-ui-view="" autoscroll="false" ng-class="app.viewAnimation" class="content-wrapper"></div>',
                  controller: [
                      "$rootScope", function ($rootScope) {
                          // Uncomment this if you are using horizontal layout
                          // $rootScope.app.layout.horizontal = true;

                          // Due to load times on local server sometimes the offsidebar is displayed before go offscreen
                          // so it's hidden by default and after 1sec we show it offscreen
                          // [If removed, also the hide class must be removed from .offsidebar]
                          setTimeout(function () {
                              angular.element(".offsidebar").removeClass("hide");
                          },
                              2000);

                      }
                  ]
              }
          }
      })
          .state('app.acceso', {
              url: '/acceso',
              templateUrl: '/Acceso/Index',
              resolve: helper.resolveFor('modernizr', 'icons'),
              controller: ['$rootScope', function ($rootScope) {
                  $rootScope.app.layout.isBoxed = false;
              }]
          })
          .state("app.login", {
              title: "Login",
              views: {
                  "main": {
                      url: "/Acceso/Login",
                      controller: "loginController",
                      controllerAs: "vm",
                      templateUrl: helper.basepath("Acceso/Login")

                  }
              }
          })
      .state("app.busquedaview",
      {
          url: "/BusquedaView",
          title: "Busqueda",
          templateUrl: helper.basepath("BusquedaView/Index")
      })
      .state("app.administracionPais",
      {
          url: "/Pais/IndexView",
          title: "Pais",
          templateUrl: helper.basepath("Pais/IndexView"),
          resolve: helper.resolveFor("smart-table")
      })
          .state("app.administracionSistemas",
      {
          url: "/Sistemas/IndexView",
          title: "Sistemas",
          templateUrl: helper.basepath("Sistemas/IndexView"),
          resolve: helper.resolveFor("smart-table")
      })
     .state("app.administracionFabricantes",
      {
          url: "/Fabricantes/IndexView",
          title: "Fabricantes",
          templateUrl: helper.basepath("Fabricantes/IndexView"),
          resolve: helper.resolveFor("smart-table")
      })
    .state("app.administracionMarcas",
      {
          url: "/Marcas/IndexView",
          title: "Marcas",
          templateUrl: helper.basepath("Marcas/IndexView"),
          resolve: helper.resolveFor("smart-table")
      })
    .state("app.administracionVehiculos",
      {
          url: "/Vehiculos/IndexView",
          title: "Vehiculos",
          templateUrl: helper.basepath("Vehiculos/IndexView"),
          resolve: helper.resolveFor("smart-table")
      })
     .state("app.administracionSubSistemas",
      {
          url: "/SubSistemas/IndexView",
          title: "Sub Sistemas",
          templateUrl: helper.basepath("SubSistemas/IndexView"),
          resolve: helper.resolveFor("smart-table")
      })
    .state("app.administracionCatalogos",
      {
          url: "/Catalogos/IndexView",
          title: "Catalogos",
          templateUrl: helper.basepath("Catalogos/IndexView"),
          resolve: helper.resolveFor("smart-table")
      });

    // 
    // CUSTOM RESOLVES
    //   Add your own resolves properties
    //   following this object extend
    //   method
    // ----------------------------------- 
    // .state('app.someroute', {
    //   url: '/some_url',
    //   templateUrl: 'path_to_template.html',
    //   controller: 'someController',
    //   resolve: angular.extend(
    //     helper.resolveFor(), {
    //     // YOUR RESOLVES GO HERE
    //     }
    //   )
    // })
    ;

} // routesConfig

//})();

