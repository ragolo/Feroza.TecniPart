"use strict";
angular.module("tecnipart")
    .directive("lineasProductosEditComponent", lineasProductosEditComponent);

function lineasProductosEditComponent() {
    var directive = {
        restrict: "E",
        controller: "lineasProductosEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/LineasProductos/LineasProductosComponent",
        scope: {
            lineasProductos: "="
        }
};
    return directive;
}