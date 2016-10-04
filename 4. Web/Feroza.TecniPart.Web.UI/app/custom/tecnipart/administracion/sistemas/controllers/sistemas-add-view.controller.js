﻿(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("sistemasAddViewController", sistemasAddViewController);
    sistemasAddViewController.$inject = ["sistemasDataServices", "logger"];

    function sistemasAddViewController(sistemasDataServices, logger) {
        var vm = this;
        init();
        function init() {
            sistemasDataServices.getSistemasModel().then(function (resposeData) {
                vm.sistemas = resposeData;
                vm.sistemas.IdSistemas = "";
                vm.sistemas.IdDane = "";
            });
        }
    }
})();