"use strict";
angular.module("tecnipart")
    .directive("tiposProductosAddComponent", tiposProductosAddComponent);

function tiposProductosAddComponent() {
    var directive = {
        restrict: "E",
        controller: "tiposProductosAddController",
        controllerAs: "vm",
        templateUrl: "/TiposProductos/TiposProductosComponent",
        scope: {
            tiposProductos: "="
        },
        bindToController: true
};
    return directive;
}