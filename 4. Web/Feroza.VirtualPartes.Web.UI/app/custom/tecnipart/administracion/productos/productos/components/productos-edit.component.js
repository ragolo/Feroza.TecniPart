"use strict";
angular.module("tecnipart")
    .directive("productosEditComponent", productosEditComponent);

function productosEditComponent() {
    var directive = {
        restrict: "E",
        controller: "productosEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Productos/ProductosComponent",
        scope: {
            productos: "="
        }
};
    return directive;
}