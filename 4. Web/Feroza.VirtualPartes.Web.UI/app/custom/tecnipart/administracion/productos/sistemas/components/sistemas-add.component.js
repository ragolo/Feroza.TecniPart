"use strict";
angular.module("tecnipart")
    .directive("productosAddComponent", productosAddComponent);

function productosAddComponent() {
    var directive = {
        restrict: "E",
        controller: "productosAddController",
        controllerAs: "vm",
        templateUrl: "/Productos/ProductosComponent",
        scope: {
            sistemas: "="
        },
        bindToController: true
};
    return directive;
}