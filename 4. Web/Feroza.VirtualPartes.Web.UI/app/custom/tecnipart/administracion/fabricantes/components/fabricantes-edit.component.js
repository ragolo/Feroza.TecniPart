"use strict";
angular.module("tecnipart")
    .directive("fabricantesEditComponent", fabricantesEditComponent);

function fabricantesEditComponent() {
    var directive = {
        restrict: "E",
        controller: "fabricantesEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Fabricantes/FabricantesComponent",
        scope: {
            fabricantes: "="
        }
};
    return directive;
}