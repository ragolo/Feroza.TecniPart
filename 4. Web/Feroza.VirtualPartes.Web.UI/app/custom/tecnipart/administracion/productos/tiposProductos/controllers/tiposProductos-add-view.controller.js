(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("tiposProductosAddViewController", tiposProductosAddViewController);
    tiposProductosAddViewController.$inject = ["tiposProductosDataServices", "logger"];

    function tiposProductosAddViewController(tiposProductosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            tiposProductosDataServices.getTiposProductosModel().then(function (resposeData) {
                resposeData.IdPaises = "";
                vm.tiposProductos = resposeData;
            });
        }
    }
})();