(function () {
    "use strict";
    angular.module("tecnipart")
    .controller('RightCtrl', function ($scope, $timeout, $mdSidenav, $log) {
        $scope.close = function () {
            // Component lookup should always be available since we are not using `ng-if`
            $mdSidenav('right').close()
              .then(function () {
                  $log.debug("close RIGHT is done");
              });
        };
    })
        .controller("sistemdasController", sistemasController);
    sistemasController.$inject = ["$scope", "sistemasDataServices", "logger", "modalWindowFactory", "$mdDialog", "sistemasStateProvider", "$mdSidenav"];

    function sistemasController($scope, sistemasDataServices, logger, modalWindowFactory, $mdDialog, sistemasStateProvider, $mdSidenav) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;
        vm.toggleRight = buildToggler('right');

        function buildToggler(navID) {
            return function () {
                // Component lookup should always be available since we are not using `ng-if`
                $mdSidenav(navID)
                  .toggle()
                  .then(function () {
                      logger.info("toggle " + navID + " is done");
                  });
            }
        }

        function init() {
            sistemasDataServices.query().then(function (data) {
                vm.sistemas = sistemasDataServices;
            });
        }

        function add() {
            sistemasStateProvider.goToSistemasComponentAdd().then(function () {
                //init();
            });
        }

        function edit(sistemas) {
            logger.info("Levantara la vista y comenzara a editar", sistemas);
            sistemasStateProvider.goToSistemasComponentEdit(sistemas.IdSistemas);
        }

        function del(sistemas) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + sistemas.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", sistemas);
                sistemasDataServices.removeSistemas(sistemas)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();