(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("sistemasController", sistemasController);
    sistemasController.$inject = ["$scope", "sistemasDataServices", "logger", "modalWindowFactory", "$mdDialog", "sistemasStateProvider"];

    function sistemasController($scope, sistemasDataServices, logger, modalWindowFactory, $mdDialog, sistemasStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            sistemasDataServices.query().then(function (data) {
                vm.sistemas = sistemasDataServices;
            });
        }

        function add() {
            sistemasStateProvider.goToSistemasComponentAdd().then(function () {
                //init();
            });
        }

        function edit(sistemas) {
            logger.info("Levantara la vista y comenzara a editar", sistemas);
            sistemasStateProvider.goToSistemasComponentEdit(sistemas.IdSistemas);
        }

        function del(sistemas) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + sistemas.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", sistemas);
                sistemasDataServices.removeSistemas(sistemas)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();