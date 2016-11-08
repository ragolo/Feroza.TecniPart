(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("referenciasEditViewController", referenciasEditViewController);
    referenciasEditViewController.$inject = ["referenciasDataServices", "logger"];

    function referenciasEditViewController(referenciasDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.referencias = referenciasDataServices.referencias;

        }
    }
})();