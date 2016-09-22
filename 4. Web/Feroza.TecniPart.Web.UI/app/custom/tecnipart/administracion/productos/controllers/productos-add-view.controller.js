(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("productosAddViewController", productosAddViewController);
    productosAddViewController.$inject = ["productosDataServices", "logger"];

    function productosAddViewController(productosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            productosDataServices.getProductosModel().then(function (resposeData) {
                vm.productos = resposeData;
            });
        }
    }
})();