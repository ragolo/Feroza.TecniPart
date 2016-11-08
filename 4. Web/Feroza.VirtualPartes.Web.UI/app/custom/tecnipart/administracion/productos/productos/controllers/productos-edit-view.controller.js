(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("productosEditViewController", productosEditViewController);
    productosEditViewController.$inject = ["productosDataServices", "logger"];

    function productosEditViewController(productosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            vm.productos = productosDataServices.productos;
        }
    }
})();