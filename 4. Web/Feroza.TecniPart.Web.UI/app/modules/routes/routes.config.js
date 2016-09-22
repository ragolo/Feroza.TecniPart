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
    $urlRouterProvider.otherwise("/BusquedaView");

    // 
    // Application Routes
    // -----------------------------------   


    $stateProvider
      .state("app",
      {
          //url: '/',
          abstract: true,
          resolve: helper.resolveFor("modernizr", "icons", "toaster"),
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
                              3000);

                      }
                  ]
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
      .state("app.administracionEstadomaestras",
      {
          url: "/EstadoMaestras/IndexView",
          title: "Estado Maestras",
          templateUrl: helper.basepath("EstadoMaestras/IndexView"),
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
    .state("app.administracionProductos",
      {
          url: "/Productos/IndexView",
          title: "Productos",
          templateUrl: helper.basepath("Productos/IndexView"),
          resolve: helper.resolveFor("smart-table")
      })
    ;

    $stateProvider.state("state-estadomaestras-EstadoMaestrasAddView",
    {
        url: "/EstadoMaestras/EstadoMaestrasAddView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("EstadoMaestras/EstadoMaestrasAddView"),
                controller: "estadomaestrasAddViewController",
                controllerAs: "vm"
            }
        }
    });

    $stateProvider.state("state-estadomaestras-EstadoMaestrasEditView",
    {
        url: "/EstadoMaestras/EstadoMaestrasEditView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("EstadoMaestras/EstadoMaestrasEditView"),
                controller: "estadomaestrasEditViewController",
                controllerAs: "vm"
            }
        }
    });

    $stateProvider.state("state-pais-PaisAddView",
   {
       url: "/Pais/PaisAddView",
       abstract: false,
       views: {
           modalCore: {
               templateUrl: helper.basepath("Pais/PaisAddView"),
               controller: "paisAddViewController",
               controllerAs: "vm"
           }
       }
   });

    $stateProvider.state("state-pais-PaisEditView",
    {
        url: "/Pais/PaisEditView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Pais/PaisEditView"),
                controller: "paisEditViewController",
                controllerAs: "vm"
            }
        }
    });

    $stateProvider.state("state-fabricantes-FabricantesAddView",
 {
     url: "/Fabricantes/FabricantesFabricantesAddView",
     abstract: false,
     views: {
         modalCore: {
             templateUrl: helper.basepath("Fabricantes/FabricantesAddView"),
             controller: "fabricantesAddViewController",
             controllerAs: "vm"
         }
     }
 });

    $stateProvider.state("state-fabricantes-FabricantesEditView",
    {
        url: "/Fabricantes/FabricantesEditView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Fabricantes/FabricantesEditView"),
                controller: "fabricantesEditViewController",
                controllerAs: "vm"
            }
        }
    });

    $stateProvider.state("state-marcas-MarcasAddView",
{
    url: "/Marcas/MarcasAddView",
    abstract: false,
    views: {
        modalCore: {
            templateUrl: helper.basepath("Marcas/MarcasAddView"),
            controller: "marcasAddViewController",
            controllerAs: "vm"
        }
    }
});

    $stateProvider.state("state-marcas-MarcasEditView",
    {
        url: "/Marcas/MarcasEditView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Marcas/MarcasEditView"),
                controller: "marcasEditViewController",
                controllerAs: "vm"
            }
        }
    });

    $stateProvider.state("state-productos-ProductosEditView",
    {
        url: "/Productos/ProductosEditView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Productos/ProductosEditView"),
                controller: "productosEditViewController",
                controllerAs: "vm"
            }
        }
    });


    $stateProvider.state("state-productos-ProductosAddView",
    {
        url: "/Productos/ProductosAddView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Productos/ProductosAddView"),
                controller: "productosAddViewController",
                controllerAs: "vm"
            }
        }
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

