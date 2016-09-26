(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("vehiculosEditViewController", vehiculosEditViewController);
    vehiculosEditViewController.$inject = ["vehiculosDataServices", "logger"];

    function vehiculosEditViewController(vehiculosDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.vehiculos = vehiculosDataServices.vehiculos;

        }
    }
})();