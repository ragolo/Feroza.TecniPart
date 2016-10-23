(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("referenciasAddViewController", referenciasAddViewController);
    referenciasAddViewController.$inject = ["referenciasDataServices", "logger"];

    function referenciasAddViewController(referenciasDataServices, logger) {
        var vm = this;
        init();
        function init() {
            referenciasDataServices.getReferenciasModel().then(function (responseData) {
                vm.referencias = responseData;
                vm.referencias.IdSistemas = "";
                vm.referencias.IdSubSistemas = "";
            });
        }
    }
})();