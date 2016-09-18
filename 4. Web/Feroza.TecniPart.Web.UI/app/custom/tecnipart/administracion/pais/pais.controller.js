(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisController", paisController);
    paisController.$inject = ["$scope", "paisDataServices", "logger", "modalWindowFactory", "$modal", "paisStateProvider"];

    function paisController($scope, paisDataServices, logger, modalWindowFactory, $modal, paisStateProvider) {
        var vm = this;
        init();

        vm.add = add;
        vm.edit = edit;

        function init() {
            paisDataServices.query().then(function (data) {
                vm.paises = paisDataServices.paisListar;
            });
        }

        function add() {
            paisStateProvider.goToPaisComponentAdd();
        }

        function edit(pais) {
            logger.info("Levantara la vista y comenzara a editar", pais);
            paisStateProvider.goToPaisComponentEdit(pais.IdPais);
        }

        function del(pais) {
            
        }
    }
})();