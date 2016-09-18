"use strict";
angular.module("tecnipart")
    .directive("estadomaestrasAddComponent", estadomaestrasAddComponent);

function estadomaestrasAddComponent() {
    var directive = {
        restrict: "E",
        controller: "estadomaestrasAddController",
        controllerAs: "vm",
        templateUrl: "/EstadoMaestras/EstadoMaestrasComponent",
        scope: {
            estadomaestras: "="
        },
        bindToController: true
};
    return directive;
}