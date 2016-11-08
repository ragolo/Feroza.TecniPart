"use strict";
angular.module("tecnipart")
    .directive("lineasProductosAddComponent", lineasProductosAddComponent);

function lineasProductosAddComponent() {
    var directive = {
        restrict: "E",
        controller: "lineasProductosAddController",
        controllerAs: "vm",
        templateUrl: "/LineasProductos/LineasProductosComponent",
        scope: {
            lineasProductos: "="
        },
        bindToController: true
};
    return directive;
}