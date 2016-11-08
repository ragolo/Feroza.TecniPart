(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("subSistemasEditViewController", subSistemasEditViewController);
    subSistemasEditViewController.$inject = ["subSistemasDataServices", "logger"];

    function subSistemasEditViewController(subSistemasDataServices, logger) {
        var vm = this;
        init();
        function init() {

            vm.subSistemas = subSistemasDataServices.subSistemas;

        }
    }
})();