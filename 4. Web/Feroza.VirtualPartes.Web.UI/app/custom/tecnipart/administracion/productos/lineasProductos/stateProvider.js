"use strict";
angular.module("tecnipart")
    .service("lineasProductosStateProvider", lineasProductosStateProvider);

lineasProductosStateProvider.$inject = ["$state", "$timeout", "logger", "lineasProductosDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function lineasProductosStateProvider($state, $timeoute, logger, lineasProductosDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToLineasProductosComponentAdd = goToLineasProductosComponentAdd;
    stateProvider.goToLineasProductosComponentEdit = goToLineasProductosComponentEdit;

    return stateProvider;

    function goToLineasProductosComponentAdd() {
        logger.info("Comienza la consulta del lineasProductos model -> ", null);
        return lineasProductosDataServices.getLineasProductosModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "lineasProductosAddController");
            });
    }

    function goToLineasProductosComponentEdit(id) {
        logger.info("Comienza la consulta del estado lineasProductos model -> ", id);
        return lineasProductosDataServices.getLineasProductosModel(id)
            .then(function (resultado) {
                showDialog(null, resultado, "lineasProductosEditController");
            });
    }

    function showDialog($event, lineasProductos, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/LineasProductos/LineasProductosComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { lineasProductos: lineasProductos },
            bindToController: true
        });
    }
}