"use strict";
angular.module("tecnipart")
    .service("tiposProductosStateProvider", tiposProductosStateProvider);

tiposProductosStateProvider.$inject = ["$state", "$timeout", "logger", "tiposProductosDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function tiposProductosStateProvider($state, $timeoute, logger, tiposProductosDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToTiposProductosComponentAdd = goToTiposProductosComponentAdd;
    stateProvider.goToTiposProductosComponentEdit = goToTiposProductosComponentEdit;

    return stateProvider;

    function goToTiposProductosComponentAdd() {
        logger.info("Comienza la consulta del tiposProductos model -> ", null);
        return tiposProductosDataServices.getTiposProductosModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "tiposProductosAddController");
            });
    }

    function goToTiposProductosComponentEdit(id) {
        logger.info("Comienza la consulta del estado tiposProductos model -> ", id);
        return tiposProductosDataServices.getTiposProductosModel(id)
            .then(function (resultado) {
                showDialog(null, resultado, "tiposProductosEditController");
            });
    }

    function showDialog($event, tiposProductos, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/TiposProductos/TiposProductosComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { tiposProductos: tiposProductos },
            bindToController: true
        });
    }
}