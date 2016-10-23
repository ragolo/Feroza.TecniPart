"use strict";
angular.module("tecnipart")
    .service("sistemasStateProvider", sistemasStateProvider);

sistemasStateProvider.$inject = ["$state", "$timeout", "logger", "sistemasDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function sistemasStateProvider($state, $timeoute, logger, sistemasDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToSistemasComponentAdd = goToSistemasComponentAdd;
    stateProvider.goToSistemasComponentEdit = goToSistemasComponentEdit;

    return stateProvider;

    function goToSistemasComponentAdd() {
        return getSistemasModel("sistemasAddController", null);

    }

    function goToSistemasComponentEdit(id) {
        logger.info("Comienza la consulta del sistemas model -> ", id);
        return getSistemasModel("sistemasEditController", id);
    }

    function getSistemasModel(controlador, parametro) {
        return sistemasDataServices.getSistemasModel(parametro)
            .then(function (resultado) {
                showDialog(null, resultado, controlador);
            });
    }

    function showDialog($event, sistemas, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "Sistemas/SistemasComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { sistemas: sistemas },
            bindToController: true
        });
    }
}