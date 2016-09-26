(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("vehiculosController", vehiculosController);
    vehiculosController.$inject = ["$scope", "vehiculosDataServices", "logger", "modalWindowFactory", "$mdDialog", "vehiculosStateProvider"];

    function vehiculosController($scope, vehiculosDataServices, logger, modalWindowFactory, $mdDialog, vehiculosStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            vehiculosDataServices.query().then(function (data) {
                vm.vehiculos = vehiculosDataServices;
            });
        }

        function add() {
            vehiculosStateProvider.goToVehiculosComponentAdd().then(function () {
                //init();
            });
        }

        function edit(vehiculos) {
            logger.info("Levantara la vista y comenzara a editar", vehiculos);
            vehiculosStateProvider.goToVehiculosComponentEdit(vehiculos.IdVehiculos);
        }

        function del(vehiculos) {
            var confirm = $mdDialog.confirm()
                  .title("Eliminar: " + vehiculos.Descripcion)
                  .textContent("Esta seguro que desea eliminar este registro?")
                  .ariaLabel("Esta seguro que desea eliminar este registro?")
                  .ok("Aceptar")
                  .cancel("Cancelar");

            $mdDialog.show(confirm).then(function () {
                logger.info("Eliminara el registro", vehiculos);
                vehiculosDataServices.removeVehiculos(vehiculos)
                .then(function () {
                    //init();
                });
            });
        }
    }
})();