(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasController", marcasController);
    marcasController.$inject = ["$scope", "marcasDataServices", "logger", "modalWindowFactory", "$mdDialog", "marcasStateProvider"];

    function marcasController($scope, marcasDataServices, logger, modalWindowFactory, $mdDialog, marcasStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            marcasDataServices.query().then(function (data) {
                vm.marcas = marcasDataServices;
            });
        }

        function add() {
            marcasStateProvider.goToMarcasComponentAdd().then(function () {
                //init();
            });
        }

        function edit(marcas) {
            logger.info("Levantara la vista y comenzara a editar", marcas);
            marcasStateProvider.goToMarcasComponentEdit(marcas.IdMarcas);
        }

        function del(marcas) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + marcas.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", marcas);
                marcasDataServices.removeMarcas(marcas)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();