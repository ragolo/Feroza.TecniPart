(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("productosController", productosController);
    productosController.$inject = ["$scope", "productosDataServices", "logger", "modalWindowFactory", "$mdDialog", "productosStateProvider"];

    function productosController($scope, productosDataServices, logger, modalWindowFactory, $mdDialog, productosStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            productosDataServices.query().then(function (data) {
                vm.productos = productosDataServices;
            });
        }

        function add() {
            productosStateProvider.goToProductosComponentAdd().then(function () {
                //init();
            });
        }

        function edit(productos) {
            logger.info("Levantara la vista y comenzara a editar", productos);
            productosStateProvider.goToProductosComponentEdit(productos.IdProductos);
        }

        function del(productos) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + productos.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", productos);
                productosDataServices.removeProductos(productos)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();