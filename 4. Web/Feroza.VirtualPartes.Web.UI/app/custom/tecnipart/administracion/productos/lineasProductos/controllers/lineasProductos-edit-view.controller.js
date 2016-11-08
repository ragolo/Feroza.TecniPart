(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("lineasProductosEditViewController", lineasProductosEditViewController);
    lineasProductosEditViewController.$inject = ["lineasProductosDataServices", "logger"];

    function lineasProductosEditViewController(lineasProductosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            vm.lineasProductos = lineasProductosDataServices.lineasProductos;
        }
    }
})();