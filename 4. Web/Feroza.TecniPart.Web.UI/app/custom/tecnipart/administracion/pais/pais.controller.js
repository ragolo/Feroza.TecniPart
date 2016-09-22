(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisController", paisController);
    paisController.$inject = ["$scope", "paisDataServices", "logger", "modalWindowFactory", "$mdDialog", "paisStateProvider"];

    function paisController($scope, paisDataServices, logger, modalWindowFactory, $mdDialog, paisStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            paisDataServices.query().then(function (data) {
                vm.pais = paisDataServices;
            });
        }

        function add() {
            paisStateProvider.goToPaisComponentAdd().then(function () {
                //init();
            });
        }

        function edit(pais) {
            logger.info("Levantara la vista y comenzara a editar", pais);
            paisStateProvider.goToPaisComponentEdit(pais.IdPais);
        }

        function del(pais) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + pais.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", pais);
                paisDataServices.removePais(pais)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();