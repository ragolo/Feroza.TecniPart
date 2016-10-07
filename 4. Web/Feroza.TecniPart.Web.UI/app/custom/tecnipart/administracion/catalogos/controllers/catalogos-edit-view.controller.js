(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("catalogosEditViewController", catalogosEditViewController);
    catalogosEditViewController.$inject = ["catalogosDataServices", "logger"];

    function catalogosEditViewController(catalogosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            vm.catalogos = catalogosDataServices.catalogos;
        }
    }
})();