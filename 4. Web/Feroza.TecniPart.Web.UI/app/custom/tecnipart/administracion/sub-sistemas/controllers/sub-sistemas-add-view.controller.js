(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("subSistemasAddViewController", subSistemasAddViewController);
    subSistemasAddViewController.$inject = ["subSistemasDataServices", "logger"];

    function subSistemasAddViewController(subSistemasDataServices, logger) {
        var vm = this;
        init();
        function init() {
            subSistemasDataServices.getSistemasModel().then(function (resposeData) {
                vm.subSistemas = resposeData;
                vm.subSistemas.IdSistemas = "";
                vm.subSistemas.IdDane = "";
            });
        }
    }
})();