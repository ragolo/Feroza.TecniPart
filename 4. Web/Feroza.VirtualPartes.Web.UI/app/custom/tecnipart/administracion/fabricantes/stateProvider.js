"use strict";
angular.module("tecnipart")
    .service("fabricantesStateProvider", fabricantesStateProvider);

fabricantesStateProvider.$inject = ["$state", "$timeout", "logger", "fabricantesDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function fabricantesStateProvider($state, $timeoute, logger, fabricantesDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToFabricantesComponentAdd = goToFabricantesComponentAdd;
    stateProvider.goToFabricantesComponentEdit = goToFabricantesComponentEdit;

    return stateProvider;

    function goToFabricantesComponentAdd() {
        logger.info("Comienza la consulta del fabricantes model -> ", null);
        return fabricantesDataServices.getFabricantesModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "fabricantesAddController");
            });
    }

    function goToFabricantesComponentEdit(id) {
        logger.info("Comienza la consulta del estado fabricantes model -> ", id);
        return fabricantesDataServices.getFabricantesModel(id)
            .then(function (resultado) {
                showDialog(null, resultado, "fabricantesEditController");
            });
    }

    function showDialog($event, fabricantes, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/Fabricantes/FabricantesComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { fabricantes: fabricantes },
            bindToController: true
        });
    }
}