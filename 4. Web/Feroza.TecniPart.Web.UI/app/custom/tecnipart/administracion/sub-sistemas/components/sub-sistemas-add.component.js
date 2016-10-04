"use strict";
angular.module("tecnipart")
    .directive("subSistemasAddComponent", subSistemasAddComponent);

function subSistemasAddComponent() {
    var directive = {
        restrict: "E",
        controller: "subSistemasAddController",
        controllerAs: "vm",
        templateUrl: "/SubSistemas/SubSistemasComponent",
        scope: {
            subSistemas: "="
        },
        bindToController: true
};
    return directive;
}