(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadoMaestrasController", estadoMaestrasController);
    estadoMaestrasController.$inject = ["estadoMaestrasDataService"];

    function estadoMaestrasController(estadoMaestrasDataService) {
        var vm = this;
        vm.estadoMaestra = { Descripcion: "", IdEstadoMaestras: 0 };
        init();

        vm.saveEstadoMaestras = saveEstadoMaestras;

        function init() {
            estadoMaestrasDataService.query().then(function (data) {
                vm.estadomaestras = estadoMaestrasDataService.EstadoMaestras;
            });
        }
        
        function saveEstadoMaestras() {
            console.log(vm.estadoMaestra);
            estadoMaestrasDataService.save(vm.estadoMaestra).then(function () {
                init();
            });
        }

    }
})();