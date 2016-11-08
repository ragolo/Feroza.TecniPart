"use strict";
angular.module("tecnipart")
    .directive("qsistemasAddComponent", sistemasAddComponent);

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