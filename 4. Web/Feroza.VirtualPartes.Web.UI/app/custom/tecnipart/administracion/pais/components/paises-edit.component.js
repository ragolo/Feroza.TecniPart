"use strict";
angular.module("tecnipart")
    .directive("paisesEditComponent", paisesEditComponent);

function paisesEditComponent() {
    var directive = {
        restrict: "E",
        controller: "paisesEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Paises/PaisesComponent",
        scope: {
            paises: "="
        }
};
    return directive;
}