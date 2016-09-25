(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisAddViewController", paisAddViewController);
    paisAddViewController.$inject = ["paisDataServices", "logger"];

    function paisAddViewController(paisDataServices, logger) {
        var vm = this;
        init();
        function init() {
            paisDataServices.getPaisModel().then(function (resposeData) {
                vm.pais = resposeData;
                vm.pais.IdPais = "";
                vm.pais.IdDane = "";
            });
        }
    }
})();