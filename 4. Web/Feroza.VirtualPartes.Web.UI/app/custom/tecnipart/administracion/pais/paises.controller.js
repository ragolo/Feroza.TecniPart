(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisesController", paisesController);
    paisesController.$inject = ["$scope", "paisesDataServices", "logger", "modalWindowFactory", "$mdDialog", "paisesStateProvider"];

    function paisesController($scope, paisesDataServices, logger, modalWindowFactory, $mdDialog, paisesStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            paisesDataServices.query()
                .then(function(data) {
                    vm.paises = paisesDataServices;
                });
        }

        function add() {
            paisesStateProvider.goToPaisComponentAdd()
                .then(function() {
                    //init();
                });
        }

        function edit(paises) {
            logger.info("Levantara la vista y comenzara a editar", paises);
            paisesStateProvider.goToPaisComponentEdit(paises.IdPaises);
        }

        function del(paises) {
            var confirm = $mdDialog.confirm()
                .title("Eliminar: " + paises.Nombre)
                .textContent("Esta seguro que desea eliminar este registro?")
                .ariaLabel("Esta seguro que desea eliminar este registro?")
                .ok("Aceptar")
                .cancel("Cancelar");

            $mdDialog.show(confirm)
                .then(function() {
                    logger.info("Eliminara el registro", paises);
                    paisesDataServices.removePais(paises)
                        .then(function() {
                            //init();
                        });
                });
        }
    }
})();