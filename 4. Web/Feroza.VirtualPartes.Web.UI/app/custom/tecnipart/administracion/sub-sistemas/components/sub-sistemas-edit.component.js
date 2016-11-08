"use strict";
angular.module("tecnipart")
    .directive("subSistemasEditComponent", subSistemasEditComponent);

function subSistemasEditComponent() {
    var directive = {
        restrict: "E",
        controller: "subSistemasEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/SubSistemas/SubSistemasComponent",
        scope: {
            subSistemas: "="
        }
};
    return directive;
}