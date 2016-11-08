(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasTiposProductosEditViewController", marcasTiposProductosEditViewController);
    marcasTiposProductosEditViewController.$inject = ["marcasTiposProductosDataServices", "logger"];

    function marcasTiposProductosEditViewController(marcasTiposProductosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            vm.marcasTiposProductos = marcasTiposProductosDataServices.marcasTiposProductos;
        }
    }
})();