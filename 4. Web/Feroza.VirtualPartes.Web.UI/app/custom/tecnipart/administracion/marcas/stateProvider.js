"use strict";
angular.module("tecnipart")
    .service("marcasStateProvider", marcasStateProvider);

marcasStateProvider.$inject = ["$state", "$timeout", "logger", "marcasDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function marcasStateProvider($state, $timeoute, logger, marcasDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToMarcasComponentAdd = goToMarcasComponentAdd;
    stateProvider.goToMarcasComponentEdit = goToMarcasComponentEdit;

    return stateProvider;

    function goToMarcasComponentAdd() {
        logger.info("Comienza la consulta del marcas model -> ", null);
        return marcasDataServices.getMarcasModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "marcasAddController");
            });
    }

    function goToMarcasComponentEdit(id) {
        logger.info("Comienza la consulta del estado marcas model -> ", id);
        return marcasDataServices.getMarcasModel(id)
             .then(function (resultado) {
                 showDialog(null, resultado, "marcasEditController");
             });
    }

    function showDialog($event, marcas, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/marcas/MarcasComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { marcas: marcas },
            bindToController: true
        });
    }
}