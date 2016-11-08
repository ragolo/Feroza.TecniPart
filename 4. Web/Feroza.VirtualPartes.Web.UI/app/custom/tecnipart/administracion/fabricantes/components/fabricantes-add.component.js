"use strict";
angular.module("tecnipart")
    .directive("fabricantesAddComponent", fabricantesAddComponent);

function fabricantesAddComponent() {
    var directive = {
        restrict: "E",
        controller: "fabricantesAddController",
        controllerAs: "vm",
        templateUrl: "/Fabricantes/FabricantesComponent",
        scope: {
            fabricantes: "="
        },
        bindToController: true
};
    return directive;
}