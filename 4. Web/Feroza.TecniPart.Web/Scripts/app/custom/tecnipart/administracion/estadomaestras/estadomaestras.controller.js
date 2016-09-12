(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadoMaestrasController", estadoMaestrasController);
    estadoMaestrasController.$inject = ["estadoMaestrasDataService"];

    function estadoMaestrasController(estadoMaestrasDataService) {
        var vm = this;

        init();

        vm.saveEstadoMaestras = saveEstadoMaestras;

        function init() {
            estadoMaestrasDataService.query().then(function (data) {
                vm.estadomaestras = estadoMaestrasDataService.EstadoMaestras;
            });
        }
        
        function saveEstadoMaestras() {
            estadoMaestrasDataService.save(vm.estadomaestras).then(function() {
                init();
            });
        }

    }
})();