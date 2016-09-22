(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("fabricantesAddViewController", fabricantesAddViewController);
    fabricantesAddViewController.$inject = ["fabricantesDataServices", "logger"];

    function fabricantesAddViewController(fabricantesDataServices, logger) {
        var vm = this;
        init();
        function init() {
            fabricantesDataServices.getFabricantesModel().then(function (resposeData) {
                vm.fabricantes = resposeData;
            });
        }
    }
})();