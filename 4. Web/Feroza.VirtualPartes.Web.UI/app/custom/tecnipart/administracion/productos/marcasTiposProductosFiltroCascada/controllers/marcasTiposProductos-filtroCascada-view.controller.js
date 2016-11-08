(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasTiposProductosAddViewController", marcasTiposProductosAddViewController);
    marcasTiposProductosAddViewController.$inject = ["marcasTiposProductosDataServices", "logger"];

    function marcasTiposProductosAddViewController(marcasTiposProductosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            marcasTiposProductosDataServices.getMarcasTiposProductosModel().then(function (resposeData) {
                resposeData.IdPaises = "";
                vm.marcasTiposProductos = resposeData;
            });
        }
    }
})();