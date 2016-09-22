(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("fabricantesEditViewController", fabricantesEditViewController);
    fabricantesEditViewController.$inject = ["fabricantesDataServices", "logger"];

    function fabricantesEditViewController(fabricantesDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.fabricantes = fabricantesDataServices.fabricantes;

        }
    }
})();