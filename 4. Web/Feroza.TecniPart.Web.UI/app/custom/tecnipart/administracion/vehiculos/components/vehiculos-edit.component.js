"use strict";
angular.module("tecnipart")
    .directive("vehiculosEditComponent", vehiculosEditComponent);

function vehiculosEditComponent() {
    var directive = {
        restrict: "E",
        controller: "vehiculosEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Vehiculos/VehiculosComponent",
        scope: {
            vehiculos: "="
        }
};
    return directive;
}