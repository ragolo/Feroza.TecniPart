"use strict";
angular.module("tecnipart")
    .service("marcasTiposProductosStateProvider", marcasTiposProductosStateProvider);

marcasTiposProductosStateProvider.$inject = ["$state", "$timeout", "logger", "marcasTiposProductosDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function marcasTiposProductosStateProvider($state, $timeoute, logger, marcasTiposProductosDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToMarcasTiposProductosComponentAdd = goToMarcasTiposProductosComponentAdd;
    stateProvider.goToMarcasTiposProductosComponentEdit = goToMarcasTiposProductosComponentEdit;

    return stateProvider;

    function goToMarcasTiposProductosComponentAdd() {
        logger.info("Comienza la consulta del marcasTiposProductos model -> ", null);
        return marcasTiposProductosDataServices.getMarcasTiposProductosModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "marcasTiposProductosAddController");
            });
    }

    function goToMarcasTiposProductosComponentEdit(id) {
        logger.info("Comienza la consulta del estado marcasTiposProductos model -> ", id);
        return marcasTiposProductosDataServices.getMarcasTiposProductosModel(id)
            .then(function (resultado) {
                showDialog(null, resultado, "marcasTiposProductosEditController");
            });
    }

    function showDialog($event, marcasTiposProductos, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/MarcasTiposProductos/MarcasTiposProductosComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { marcasTiposProductos: marcasTiposProductos },
            bindToController: true
        });
    }
}