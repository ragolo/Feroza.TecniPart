(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("sistemasEditViewController", sistemasEditViewController);
    sistemasEditViewController.$inject = ["sistemasDataServices", "logger"];

    function sistemasEditViewController(sistemasDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.sistemas = sistemasDataServices.sistemas;

        }
    }
})();