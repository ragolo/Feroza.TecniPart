"use strict";
angular.module("tecnipart")
    .directive("paisesAddComponent", paisesAddComponent);

function paisesAddComponent() {
    var directive = {
        restrict: "E",
        controller: "paisesAddController",
        controllerAs: "vm",
        templateUrl: "/Paises/PaisesComponent",
        scope: {
            paises: "="
        },
        bindToController: true
};
    return directive;
}