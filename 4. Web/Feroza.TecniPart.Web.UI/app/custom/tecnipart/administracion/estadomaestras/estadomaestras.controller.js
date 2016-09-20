(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadomaestrasController", estadomaestrasController);
    estadomaestrasController.$inject = ["$scope", "estadomaestasDataServices", "logger", "modalWindowFactory", "$mdDialog", "estadomaestrasStateProvider"];

    function estadomaestrasController($scope, estadomaestasDataServices, logger, modalWindowFactory, $mdDialog, estadomaestrasStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            estadomaestasDataServices.query().then(function (data) {
                vm.estadomaestras = estadomaestasDataServices.estadoMaestrasListar;
            });
        }

        function add() {
            estadomaestrasStateProvider.goToEstadoMaestrasComponentAdd();
        }

        function edit(estadomaestras) {
            logger.info("Levantara la vista y comenzara a editar", estadomaestras);
            estadomaestrasStateProvider.goToEstadoMaestrasComponentEdit(estadomaestras.IdEstadoMaestras);
        }

        function del(estadomaestras) {
            // Appending dialog to document.body to cover sidenav in docs app
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + estadomaestras.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {

                logger.info("Eliminara el registro", estadomaestras);
                estadomaestasDataServices.removeEstadoMaestras(estadomaestras.IdEstadoMaestras);
            }, function () {
                $scope.status = 'You decided to keep your debt.';
            });
        }
    }
})();