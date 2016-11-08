(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasAddViewController", marcasAddViewController);
    marcasAddViewController.$inject = ["marcasDataServices", "logger"];

    function marcasAddViewController(marcasDataServices, logger) {
        var vm = this;
        init();
        function init() {
            marcasDataServices.getMarcasModel().then(function (resposeData) {
                vm.marcas = resposeData;
            });
        }
    }
})();