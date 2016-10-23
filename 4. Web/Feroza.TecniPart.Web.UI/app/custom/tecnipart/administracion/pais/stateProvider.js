"use strict";
angular.module("tecnipart")
    .service("paisStateProvider", paisStateProvider);

paisStateProvider.$inject = ["$state", "$timeout", "logger", "paisDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function paisStateProvider($state, $timeoute, logger, paisDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToPaisComponentAdd = goToPaisComponentAdd;
    stateProvider.goToPaisComponentEdit = goToPaisComponentEdit;

    return stateProvider;

    function goToPaisComponentAdd() {
        logger.info("Comienza la consulta del pais model -> ", null);
        return paisDataServices.getPaisModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "paisAddController");
            });
    }

    function goToPaisComponentEdit(id) {
        logger.info("Comienza la consulta del estado pais model -> ", id);
        return paisDataServices.getPaisModel(id)
            .then(function (resultado) {
                showDialog(null, resultado, "paisEditController");
            });
    }

    function showDialog($event, pais, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/Pais/PaisComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { pais: pais },
            bindToController: true
        });
    }
}