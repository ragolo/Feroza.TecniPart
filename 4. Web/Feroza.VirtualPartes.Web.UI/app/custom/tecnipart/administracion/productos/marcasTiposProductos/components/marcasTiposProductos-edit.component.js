"use strict";
angular.module("tecnipart")
    .directive("marcasTiposProductosEditComponent", marcasTiposProductosEditComponent);

function marcasTiposProductosEditComponent() {
    var directive = {
        restrict: "E",
        controller: "marcasTiposProductosEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/MarcasTiposProductos/MarcasTiposProductosComponent",
        scope: {
            marcasTiposProductos: "="
        }
};
    return directive;
}