(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("lineasProductosAddViewController", lineasProductosAddViewController);
    lineasProductosAddViewController.$inject = ["lineasProductosDataServices", "logger"];

    function lineasProductosAddViewController(lineasProductosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            lineasProductosDataServices.getLineasProductosModel().then(function (resposeData) {
                resposeData.IdPaises = "";
                vm.lineasProductos = resposeData;
            });
        }
    }
})();