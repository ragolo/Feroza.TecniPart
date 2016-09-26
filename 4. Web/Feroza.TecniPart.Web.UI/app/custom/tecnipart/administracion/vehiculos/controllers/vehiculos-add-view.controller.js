(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("vehiculosAddViewController", vehiculosAddViewController);
    vehiculosAddViewController.$inject = ["vehiculosDataServices", "logger"];

    function vehiculosAddViewController(vehiculosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            vehiculosDataServices.getVehiculosModel().then(function (resposeData) {
                vm.vehiculos = resposeData;
                vm.vehiculos.IdMarca = "";
                vm.vehiculos.IdFabricantes = "";

            });
        }
    }
})();