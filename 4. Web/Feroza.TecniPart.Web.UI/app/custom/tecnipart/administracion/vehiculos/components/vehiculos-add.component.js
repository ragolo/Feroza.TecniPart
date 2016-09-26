"use strict";
angular.module("tecnipart")
    .directive("vehiculosAddComponent", vehiculosAddComponent);

function vehiculosAddComponent() {
    var directive = {
        restrict: "E",
        controller: "vehiculosAddController",
        controllerAs: "vm",
        templateUrl: "/Vehiculos/VehiculosComponent",
        scope: {
            vehiculos: "="
        },
        bindToController: true
};
    return directive;
}