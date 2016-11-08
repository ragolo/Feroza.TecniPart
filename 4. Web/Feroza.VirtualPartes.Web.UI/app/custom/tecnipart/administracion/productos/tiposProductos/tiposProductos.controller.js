(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("tiposProductosController", tiposProductosController);
    tiposProductosController.$inject = ["$scope", "tiposProductosDataServices", "logger", "modalWindowFactory", "$mdDialog", "tiposProductosStateProvider"];

    function tiposProductosController($scope, tiposProductosDataServices, logger, modalWindowFactory, $mdDialog, tiposProductosStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            tiposProductosDataServices.query()
                .then(function (data) {
                    vm.tiposProductos = tiposProductosDataServices;
                });
        }

        function add() {
            tiposProductosStateProvider.goToTiposProductosComponentAdd()
                .then(function () {
                    //init();
                });
        }

        function edit(tiposProductos) {
            logger.info("Levantara la vista y comenzara a editar", tiposProductos);
            tiposProductosStateProvider.goToTiposProductosComponentEdit(tiposProductos.IdTiposProductos);
        }

        function del(tiposProductos) {
            var confirm = $mdDialog.confirm()
                .title("Eliminar: " + tiposProductos.Descripcion)
                .textContent("Esta seguro que desea eliminar este registro?")
                .ariaLabel("Esta seguro que desea eliminar este registro?")
                .ok("Aceptar")
                .cancel("Cancelar");

            $mdDialog.show(confirm)
                .then(function () {
                    logger.info("Eliminara el registro", tiposProductos);
                    tiposProductosDataServices.removeTiposProductos(tiposProductos)
                        .then(function () {
                            //init();
                        });
                });
        }
    }
})();