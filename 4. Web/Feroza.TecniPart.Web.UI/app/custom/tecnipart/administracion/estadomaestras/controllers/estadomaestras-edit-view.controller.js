(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadomaestrasEditViewController", estadomaestrasEditViewController);
    estadomaestrasEditViewController.$inject = ["estadomaestasDataServices", "logger"];

    function estadomaestrasEditViewController(estadomaestasDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.estadomaestras = estadomaestasDataServices.estadoMaestras;

        }
    }
})();