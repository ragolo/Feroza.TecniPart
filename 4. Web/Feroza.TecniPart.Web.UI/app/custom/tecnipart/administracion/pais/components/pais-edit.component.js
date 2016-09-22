"use strict";
angular.module("tecnipart")
    .directive("paisEditComponent", paisEditComponent);

function paisEditComponent() {
    var directive = {
        restrict: "E",
        controller: "paisEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Pais/PaisComponent",
        scope: {
            pais: "="
        }
};
    return directive;
}