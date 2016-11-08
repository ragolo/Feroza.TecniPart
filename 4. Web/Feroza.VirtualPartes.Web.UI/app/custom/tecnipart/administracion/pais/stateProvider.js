"use strict";
angular.module("tecnipart")
    .service("paisesStateProvider", paisesStateProvider);

paisesStateProvider.$inject = ["$state", "$timeout", "logger", "paisesDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function paisesStateProvider($state, $timeoute, logger, paisesDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToPaisComponentAdd = goToPaisComponentAdd;
    stateProvider.goToPaisComponentEdit = goToPaisComponentEdit;

    return stateProvider;

    function goToPaisComponentAdd() {
        logger.info("Comienza la consulta del paises model -> ", null);
        return paisesDataServices.getPaisModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "paisesAddController");
            });
    }

    function goToPaisComponentEdit(id) {
        logger.info("Comienza la consulta del estado paises model -> ", id);
        return paisesDataServices.getPaisModel(id)
            .then(function (resultado) {
                showDialog(null, resultado, "paisesEditController");
            });
    }

    function showDialog($event, paises, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/Paises/PaisesComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { paises: paises },
            bindToController: true
        });
    }
}