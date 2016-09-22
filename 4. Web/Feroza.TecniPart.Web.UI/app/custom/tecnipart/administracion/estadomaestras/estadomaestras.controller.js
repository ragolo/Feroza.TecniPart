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
                vm.estadomaestras = estadomaestasDataServices;
            });
        }

        function add() {
            estadomaestrasStateProvider.goToEstadoMaestrasComponentAdd().then(function() {
                //init();
            });
        }

        function edit(estadomaestras) {
            logger.info("Levantara la vista y comenzara a editar", estadomaestras);
            estadomaestrasStateProvider.goToEstadoMaestrasComponentEdit(estadomaestras.IdEstadoMaestras);
        }

        function del(estadomaestras) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + estadomaestras.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", estadomaestras);
                estadomaestasDataServices.removeEstadoMaestras(estadomaestras)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();