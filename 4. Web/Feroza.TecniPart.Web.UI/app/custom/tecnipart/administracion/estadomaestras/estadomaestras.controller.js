(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadomaestrasController", estadomaestrasController);
    estadomaestrasController.$inject = ["$scope", "estadomaestasDataServices", "logger", "modalWindowFactory", "$modal", "estadomaestrasStateProvider"];

    function estadomaestrasController($scope, estadomaestasDataServices, logger, modalWindowFactory, $modal, estadomaestrasStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;

        function init() {
            estadomaestasDataServices.query().then(function (data) {
                vm.estadomaestras = estadomaestasDataServices.estadoMaestrasListar;
            });
        }

        function add() {
            estadomaestrasStateProvider.goToEstadoMaestrasComponentAdd();
        }

        function edit(estadomaestras) {
            logger.info("Levantara la vista y comenzara a editar", estadomaestras);
            estadomaestrasStateProvider.goToEstadoMaestrasComponentEdit(estadomaestras.IdEstadoMaestras);
        }

        function del(estadomaestras) {
            
        }
    }
})();