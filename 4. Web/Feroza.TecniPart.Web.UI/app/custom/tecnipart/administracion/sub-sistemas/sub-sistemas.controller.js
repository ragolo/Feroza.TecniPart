(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("subSistemasController", subSistemasController);
    subSistemasController.$inject = ["$scope", "subSistemasDataServices", "logger", "modalWindowFactory", "$mdDialog", "subSistemasStateProvider", "$mdSidenav"];

    function subSistemasController($scope, subSistemasDataServices, logger, modalWindowFactory, $mdDialog, subSistemasStateProvider, $mdSidenav) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;
        function init() {
            subSistemasDataServices.query().then(function (data) {
                vm.subSistemas = subSistemasDataServices;
            });
        }

        function add() {
            subSistemasStateProvider.goToSubSistemasComponentAdd().then(function () {
                //init();
            });
        }

        function edit(subSistemas) {
            logger.info("Levantara la vista y comenzara a editar", subSistemas);
            subSistemasStateProvider.goToSubSistemasComponentEdit(subSistemas.IdSubSistemas);
        }

        function del(subSistemas) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + subSistemas.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", subSistemas);
                subSistemasDataServices.removeSubSistemas(subSistemas)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();