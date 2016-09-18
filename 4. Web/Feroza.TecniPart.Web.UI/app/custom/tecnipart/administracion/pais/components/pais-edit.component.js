"use strict";
angular.module("tecnipart")
    .directive("paisEditComponent", paisEditComponent);

function paisEditComponent() {
    var directive = {
        restrict: "E",
        controller: "paisEditController",
        controllerAs: "vm",
        templateUrl: "/Pais/PaisComponent",
        scope: {
            paises: "="
        },
        bindToController: true
};
    return directive;
}