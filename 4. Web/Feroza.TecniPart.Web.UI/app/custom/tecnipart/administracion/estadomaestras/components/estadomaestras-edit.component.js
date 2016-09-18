"use strict";
angular.module("tecnipart")
    .directive("estadomaestrasEditComponent", estadomaestrasEditComponent);

function estadomaestrasEditComponent() {
    var directive = {
        restrict: "E",
        controller: "estadomaestrasEditController",
        controllerAs: "vm",
        templateUrl: "/EstadoMaestras/EstadoMaestrasComponent",
        scope: {
            estadomaestras: "="
        },
        bindToController: true
};
    return directive;
}