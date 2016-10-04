"use strict";
angular.module("tecnipart")
    .directive("sistemasAddComponent", sistemasAddComponent);

function sistemasAddComponent() {
    var directive = {
        restrict: "E",
        controller: "sistemasAddController",
        controllerAs: "vm",
        templateUrl: "/Sistemas/SistemasComponent",
        scope: {
            sistemas: "="
        },
        bindToController: true
};
    return directive;
}