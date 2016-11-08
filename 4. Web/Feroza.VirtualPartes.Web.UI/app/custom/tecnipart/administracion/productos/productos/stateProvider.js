"use strict";
angular.module("tecnipart")
    .service("productosStateProvider", productosStateProvider);

productosStateProvider.$inject = ["$state", "$timeout", "logger", "productosDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function productosStateProvider($state, $timeoute, logger, productosDataServices, modalWindowFactory, $timeout, $mdDialog) {
    var stateProvider = {};

    stateProvider.goToProductosComponentAdd = goToProductosComponentAdd;
    stateProvider.goToProductosComponentEdit = goToProductosComponentEdit;

    return stateProvider;

    function goToProductosComponentAdd() {
        logger.info("Comienza la consulta del productos model -> ", null);
        return productosDataServices.getProductosModel(null)
            .then(function (resultado) {
                showDialog(null, resultado, "productosAddController");
            });
    }

    function goToProductosComponentEdit(id) {
        logger.info("Comienza la consulta del estado productos model -> ", id);
        return productosDataServices.getProductosModel(id)
            .then(function (resultado) {
                showDialog(null, resultado, "productosEditController");
            });
    }

    function showDialog($event, productos, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "/Productos/ProductosComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { productos: productos },
            bindToController: true
        });
    }
}