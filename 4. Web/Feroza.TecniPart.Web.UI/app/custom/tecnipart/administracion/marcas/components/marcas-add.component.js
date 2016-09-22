"use strict";
angular.module("tecnipart")
    .directive("marcasAddComponent", marcasAddComponent);

function marcasAddComponent() {
    var directive = {
        restrict: "E",
        controller: "marcasAddController",
        controllerAs: "vm",
        templateUrl: "/Marcas/MarcasComponent",
        scope: {
            marcas: "="
        },
        bindToController: true
};
    return directive;
}