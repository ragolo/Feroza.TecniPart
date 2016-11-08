"use strict";
angular.module("tecnipart")
    .directive("marcasTiposProductosFiltroCascadaComponent", marcasTiposProductosFiltroCascadaComponent);

function marcasTiposProductosFiltroCascadaComponent() {
    var directive = {
        restrict: "E",
        controller: "marcasTiposProductosFiltroCascadaController",
        controllerAs: "vm",
        templateUrl: "/MarcasTiposProductos/MarcasTiposProductosFiltroCascadaComponent",
        scope: {
            marcasTiposProductos: "="
        },
        bindToController: true
};
    return directive;
}