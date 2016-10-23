(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("referenciasController", referenciasController);
    referenciasController.$inject = ["$scope", "referenciasDataServices", "logger", "modalWindowFactory", "$mdDialog", "referenciasStateProvider"];

    function referenciasController($scope, referenciasDataServices, logger, modalWindowFactory, $mdDialog, referenciasStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            referenciasDataServices.query()
                .then(function(data) {
                    vm.referencias = referenciasDataServices;
                });
        }

        function add() {
            referenciasStateProvider.goToReferenciasComponentAdd()
                .then(function() {
                    //init();
                });
        }

        function edit(referencias) {
            logger.info("Levantara la vista y comenzara a editar", referencias);
            referenciasStateProvider.goToReferenciasComponentEdit(referencias.CodigoOem);
        }

        function del(referencias) {
            var confirm = $mdDialog.confirm()
                .title("Eliminar: " + referencias.Descripcion)
                .textContent("Esta seguro que desea eliminar este registro?")
                .ariaLabel("Esta seguro que desea eliminar este registro?")
                .ok("Aceptar")
                .cancel("Cancelar");

            $mdDialog.show(confirm)
                .then(function() {
                    logger.info("Eliminara el registro", referencias);
                    referenciasDataServices.removeReferencias(referencias)
                        .then(function() {
                            //init();
                        });
                });
        }
    }
})();