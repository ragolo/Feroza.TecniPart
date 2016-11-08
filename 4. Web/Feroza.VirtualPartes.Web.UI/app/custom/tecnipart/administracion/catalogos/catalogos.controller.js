(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("catalogosController", catalogosController);
    catalogosController.$inject = ["$scope", "catalogosDataServices", "logger", "modalWindowFactory", "$mdDialog", "catalogosStateProvider"];

    function catalogosController($scope, catalogosDataServices, logger, modalWindowFactory, $mdDialog, catalogosStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            catalogosDataServices.query().then(function (data) {
                vm.catalogos = catalogosDataServices;
                logger.info("este es el modelo para ver BASE64 ->", vm.catalogos);
            });
        }

        function add() {
            catalogosStateProvider.goToCatalogosComponentAdd().then(function () {
                //init();
            });
        }

        function edit(catalogos) {
            logger.info("Levantara la vista y comenzara a editar", catalogos);
            catalogosStateProvider.goToCatalogosComponentEdit(catalogos.IdCatalogos);
        }

        function del(catalogos) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + catalogos.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", catalogos);
                catalogosDataServices.removeCatalogos(catalogos)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();