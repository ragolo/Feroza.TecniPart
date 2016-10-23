"use strict";
angular.module("tecnipart")
    .directive("referenciasAddComponent", referenciasAddComponent);

function referenciasAddComponent() {
    var directive = {
        restrict: "E",
        controller: "referenciasAddController",
        controllerAs: "vm",
        templateUrl: "/Referencias/ReferenciasComponent",
        scope: {
            referencias: "="
        },
        bindToController: true
};
    return directive;
}