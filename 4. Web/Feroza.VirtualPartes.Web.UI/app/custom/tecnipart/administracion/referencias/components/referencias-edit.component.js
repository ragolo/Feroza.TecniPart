"use strict";
angular.module("tecnipart")
    .directive("referenciasEditComponent", referenciasEditComponent);

function referenciasEditComponent() {
    var directive = {
        restrict: "E",
        controller: "referenciasEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Referencias/ReferenciasComponent",
        scope: {
            referencias: "="
        }
};
    return directive;
}