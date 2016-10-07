(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("catalogosAddViewController", catalogosAddViewController);
    catalogosAddViewController.$inject = ["catalogosDataServices", "logger"];

    function catalogosAddViewController(catalogosDataServices, logger) {
        var vm = this;
        init();
        function init() {
            catalogosDataServices.getCatalogosModel().then(function (resposeData) {
                vm.catalogos = resposeData;
                vm.catalogos.IdSistemas = "";
                vm.catalogos.IdSubSistemas = "";
                vm.catalogos.IdVehiculos = "";
            });
        }
    }
})();