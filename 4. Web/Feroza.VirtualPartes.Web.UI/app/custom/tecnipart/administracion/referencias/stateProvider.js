"use strict";
angular.module("tecnipart")
    .service("referenciasStateProvider", referenciasStateProvider);

referenciasStateProvider.$inject = ["$state", "$timeout", "logger", "referenciasDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function referenciasStateProvider($state, $timeoute, logger, referenciasDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToReferenciasComponentAdd = goToReferenciasComponentAdd;
    stateProvider.goToReferenciasComponentEdit = goToReferenciasComponentEdit;

    return stateProvider;

    function goToReferenciasComponentAdd() {
        logger.info("Comienza la consulta del referencias model -> ", null);
        return getReferenciasModel("referenciasAddController", null);
    }

    function goToReferenciasComponentEdit(id) {
        logger.info("Comienza la consulta de la referencias model -> ", id);
        return getReferenciasModel("referenciasEditController", id);
    }

    function getReferenciasModel(controlador, parametro) {
        return referenciasDataServices.getReferenciasModel(parametro)
            .then(function (resultado) {
                showDialog(null, resultado, controlador);
            });
    }

    function showDialog($event, referencias, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "Referencias/ReferenciasComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { referencias: referencias },
            bindToController: true
        });
    }
}