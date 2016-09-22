"use strict";
angular.module("tecnipart")
    .directive("paisAddComponent", paisAddComponent);

function paisAddComponent() {
    var directive = {
        restrict: "E",
        controller: "paisAddController",
        controllerAs: "vm",
        templateUrl: "/Pais/PaisComponent",
        scope: {
            pais: "="
        },
        bindToController: true
};
    return directive;
}