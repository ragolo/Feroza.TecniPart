(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisesEditViewController", paisesEditViewController);
    paisesEditViewController.$inject = ["paisesDataServices", "logger"];

    function paisesEditViewController(paisesDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.paises = paisesDataServices.paises;

        }
    }
})();