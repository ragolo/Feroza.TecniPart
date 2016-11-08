"use strict";
angular.module("tecnipart")
    .service("subSistemasStateProvider", subSistemasStateProvider);

subSistemasStateProvider.$inject = ["$state", "$timeout", "logger", "subSistemasDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function subSistemasStateProvider($state, $timeoute, logger, subSistemasDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToSubSistemasComponentAdd = goToSubSistemasComponentAdd;
    stateProvider.goToSubSistemasComponentEdit = goToSubSistemasComponentEdit;

    return stateProvider;

    function goToSubSistemasComponentAdd() {
        return getSubSistemasModel("subSistemasAddController", null);
    }

    function goToSubSistemasComponentEdit(id) {
        logger.info("Comienza la consulta del estado subSistemas model -> ", id);
        return getSubSistemasModel("subSistemasEditController", id);
    }

    function getSubSistemasModel(controlador, parametro) {
        return subSistemasDataServices.getSubSistemasModel(parametro)
            .then(function (resultado) {
                showDialog(null, resultado, controlador);
            });
    }

    function showDialog($event, subSistemas, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "SubSistemas/SubSistemasComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { subSistemas: subSistemas },
            bindToController: true
        });
    }
}