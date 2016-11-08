"use strict";
angular.module("tecnipart")
    .directive("marcasTiposProductosAddComponent", marcasTiposProductosAddComponent);

function marcasTiposProductosAddComponent() {
    var directive = {
        restrict: "E",
        controller: "marcasTiposProductosAddController",
        controllerAs: "vm",
        templateUrl: "/MarcasTiposProductos/MarcasTiposProductosComponent",
        scope: {
            marcasTiposProductos: "="
        },
        bindToController: true
};
    return directive;
}