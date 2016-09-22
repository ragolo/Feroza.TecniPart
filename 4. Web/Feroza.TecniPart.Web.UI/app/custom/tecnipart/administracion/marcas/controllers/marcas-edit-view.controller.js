(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasEditViewController", marcasEditViewController);
    marcasEditViewController.$inject = ["marcasDataServices", "logger"];

    function marcasEditViewController(marcasDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.marcas = marcasDataServices.marcas;

        }
    }
})();