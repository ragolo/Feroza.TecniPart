(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("tiposProductosEditViewController", tiposProductosEditViewController);
    tiposProductosEditViewController.$inject = ["tiposProductosDataServices", "logger"];

    function tiposProductosEditViewController(tiposProductosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            vm.tiposProductos = tiposProductosDataServices.tiposProductos;
        }
    }
})();