(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisEditViewController", paisEditViewController);
    paisEditViewController.$inject = ["paisDataServices", "logger"];

    function paisEditViewController(paisDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.pais = paisDataServices.pais;

        }
    }
})();