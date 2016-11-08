(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("lineasProductosController", lineasProductosController);
    lineasProductosController.$inject = ["$scope", "lineasProductosDataServices", "logger", "modalWindowFactory", "$mdDialog", "lineasProductosStateProvider"];

    function lineasProductosController($scope, lineasProductosDataServices, logger, modalWindowFactory, $mdDialog, lineasProductosStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            lineasProductosDataServices.query()
                .then(function (data) {
                    vm.lineasProductos = lineasProductosDataServices;
                });
        }

        function add() {
            lineasProductosStateProvider.goToLineasProductosComponentAdd()
                .then(function () {
                    //init();
                });
        }

        function edit(lineasProductos) {
            logger.info("Levantara la vista y comenzara a editar", lineasProductos);
            lineasProductosStateProvider.goToLineasProductosComponentEdit(lineasProductos.IdLineasProductos);
        }

        function del(lineasProductos) {
            var confirm = $mdDialog.confirm()
                .title("Eliminar: " + lineasProductos.Descripcion)
                .textContent("Esta seguro que desea eliminar este registro?")
                .ariaLabel("Esta seguro que desea eliminar este registro?")
                .ok("Aceptar")
                .cancel("Cancelar");

            $mdDialog.show(confirm)
                .then(function () {
                    logger.info("Eliminara el registro", lineasProductos);
                    lineasProductosDataServices.removeLineasProductos(lineasProductos)
                        .then(function () {
                            //init();
                        });
                });
        }
    }
})();