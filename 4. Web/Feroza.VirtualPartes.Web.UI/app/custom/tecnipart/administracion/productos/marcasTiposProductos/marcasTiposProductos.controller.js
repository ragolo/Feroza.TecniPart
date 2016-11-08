(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasTiposProductosController", marcasTiposProductosController);
    marcasTiposProductosController.$inject = ["$scope", "marcasTiposProductosDataServices", "logger", "modalWindowFactory", "$mdDialog", "marcasTiposProductosStateProvider"];

    function marcasTiposProductosController($scope, marcasTiposProductosDataServices, logger, modalWindowFactory, $mdDialog, marcasTiposProductosStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            marcasTiposProductosDataServices.query()
                .then(function (data) {
                    vm.marcasTiposProductos = marcasTiposProductosDataServices;
                });
        }

        function add() {
            marcasTiposProductosStateProvider.goToMarcasTiposProductosComponentAdd()
                .then(function () {
                    //init();
                });
        }

        function edit(marcasTiposProductos) {
            logger.info("Levantara la vista y comenzara a editar", marcasTiposProductos);
            marcasTiposProductosStateProvider.goToMarcasTiposProductosComponentEdit(marcasTiposProductos.IdMarcasTiposProductos);
        }

        function del(marcasTiposProductos) {
            var confirm = $mdDialog.confirm()
                .title("Eliminar: " + marcasTiposProductos.Descripcion)
                .textContent("Esta seguro que desea eliminar este registro?")
                .ariaLabel("Esta seguro que desea eliminar este registro?")
                .ok("Aceptar")
                .cancel("Cancelar");

            $mdDialog.show(confirm)
                .then(function () {
                    logger.info("Eliminara el registro", marcasTiposProductos);
                    marcasTiposProductosDataServices.removeMarcasTiposProductos(marcasTiposProductos)
                        .then(function () {
                            //init();
                        });
                });
        }
    }
})();