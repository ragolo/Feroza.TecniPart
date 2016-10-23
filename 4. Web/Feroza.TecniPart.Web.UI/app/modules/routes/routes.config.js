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
      .state("app",
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
      })
     .state("app.administracionReferencias",
      {
          url: "/Referencias/IndexView",
          title: "Referencias",
          templateUrl: helper.basepath("Referencias/IndexView"),
          resolve: helper.resolveFor("smart-table")
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

    $stateProvider.state("state-vehiculos-VehiculosEditView",
    {
        url: "/Vehiculos/VehiculosEditView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Vehiculos/VehiculosEditView"),
                controller: "vehiculosEditViewController",
                controllerAs: "vm"
            }
        }
    });


    $stateProvider.state("state-vehiculos-VehiculosAddView",
    {
        url: "/Vehiculos/VehiculosAddView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Vehiculos/VehiculosAddView"),
                controller: "vehiculosAddViewController",
                controllerAs: "vm"
            }
        }
    });

    $stateProvider.state("state-sistemas-SistemasAddView",
{
    url: "/Sistemas/SistemasAddView",
    abstract: false,
    views: {
        modalCore: {
            templateUrl: helper.basepath("Sistemas/SistemasAddView"),
            controller: "sistemasAddViewController",
            controllerAs: "vm"
        }
    }
});

    $stateProvider.state("state-sistemas-SistemasEditView",
    {
        url: "/Sistemas/SistemasEditView",
        abstract: false,
        views: {
            modalCore: {
                templateUrl: helper.basepath("Sistemas/SistemasEditView"),
                controller: "sistemasEditViewController",
                controllerAs: "vm"
            }
        }
    });

    $stateProvider.state("state-sub-sistemas-SubSistemasEditView",
  {
      url: "/SubSistemas/SubSistemasEditView",
      abstract: false,
      views: {
          modalCore: {
              templateUrl: helper.basepath("SubSistemas/SubSistemasEditView"),
              controller: "subSistemasEditViewController",
              controllerAs: "vm"
          }
      }
  });

    $stateProvider.state("state-sub-sistemas-SubSistemasAddView",
  {
      url: "/SubSistemas/SubSistemasAddView",
      abstract: false,
      views: {
          modalCore: {
              templateUrl: helper.basepath("SubSistemas/SubSistemasAddView"),
              controller: "subSistemasAddViewController",
              controllerAs: "vm"
          }
      }
  });

    $stateProvider.state("state-catalogos-CatalogosAddView",
{
    url: "/Catalogos/CatalogosAddView",
    abstract: false,
    views: {
        modalCore: {
            templateUrl: helper.basepath("Catalogos/CatalogosAddView"),
            controller: "catalogosAddViewController",
            controllerAs: "vm"
        }
    }
});

    $stateProvider.state("state-catalogos-CatalogosEditView",
{
    url: "/Catalogos/CatalogosEditView",
    abstract: false,
    views: {
        modalCore: {
            templateUrl: helper.basepath("Catalogos/CatalogosEditView"),
            controller: "catalogosEditViewController",
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

