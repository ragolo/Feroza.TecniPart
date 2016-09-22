(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("fabricantesController", fabricantesController);
    fabricantesController.$inject = ["$scope", "fabricantesDataServices", "logger", "modalWindowFactory", "$mdDialog", "fabricantesStateProvider"];

    function fabricantesController($scope, fabricantesDataServices, logger, modalWindowFactory, $mdDialog, fabricantesStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            fabricantesDataServices.query().then(function (data) {
                vm.fabricantes = fabricantesDataServices;
            });
        }

        function add() {
            fabricantesStateProvider.goToFabricantesComponentAdd().then(function () {
                //init();
            });
        }

        function edit(fabricantes) {
            logger.info("Levantara la vista y comenzara a editar", fabricantes);
            fabricantesStateProvider.goToFabricantesComponentEdit(fabricantes.IdFabricantes);
        }

        function del(fabricantes) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + fabricantes.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", fabricantes);
                fabricantesDataServices.removeFabricantes(fabricantes)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();