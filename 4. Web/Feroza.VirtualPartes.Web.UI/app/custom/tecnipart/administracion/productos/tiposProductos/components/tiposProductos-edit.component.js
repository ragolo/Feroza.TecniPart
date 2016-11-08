"use strict";
angular.module("tecnipart")
    .directive("tiposProductosEditComponent", tiposProductosEditComponent);

function tiposProductosEditComponent() {
    var directive = {
        restrict: "E",
        controller: "tiposProductosEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/TiposProductos/TiposProductosComponent",
        scope: {
            tiposProductos: "="
        }
};
    return directive;
}