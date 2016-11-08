"use strict";
angular.module("tecnipart")
    .service("catalogosStateProvider", catalogosStateProvider);

catalogosStateProvider.$inject = ["$state", "$timeout", "logger", "catalogosDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function catalogosStateProvider($state, $timeoute, logger, catalogosDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToCatalogosComponentAdd = goToCatalogosComponentAdd;
    stateProvider.goToCatalogosComponentEdit = goToCatalogosComponentEdit;

    return stateProvider;

    function goToCatalogosComponentAdd() {
        return getCatalogosModel("catalogosAddController", null);

    }

    function goToCatalogosComponentEdit(id) {
        logger.info("Comienza la consulta del catalogos model -> ", id);
        return getCatalogosModel("catalogosEditController", id);
    }

    function getCatalogosModel(controlador, parametro) {
        return catalogosDataServices.getCatalogosModel(parametro)
            .then(function (resultado) {
                showDialog(null, resultado, controlador);
            });
    }

    function showDialog($event, catalogos, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "Catalogos/CatalogosComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { catalogos: catalogos },
            bindToController: true
        });
    }
}