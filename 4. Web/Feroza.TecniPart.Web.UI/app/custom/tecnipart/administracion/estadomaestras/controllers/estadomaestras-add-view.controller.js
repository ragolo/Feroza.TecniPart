(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadomaestrasAddViewController", estadomaestrasAddViewController);
    estadomaestrasAddViewController.$inject = ["estadomaestasDataServices", "logger"];

    function estadomaestrasAddViewController(estadomaestasDataServices, logger) {
        var vm = this;
        init();
        function init() {
            estadomaestasDataServices.getEstadoMaestrasModel()
                .then(function (data) {
                    vm.estadomaestras = data;
                });
        }
    }
})();