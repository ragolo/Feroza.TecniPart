"use strict";
angular.module("tecnipart")
    .directive("marcasEditComponent", marcasEditComponent);

function marcasEditComponent() {
    var directive = {
        restrict: "E",
        controller: "marcasEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Marcas/MarcasComponent",
        scope: {
            marcas: "="
        }
};
    return directive;
}