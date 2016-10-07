"use strict";
angular.module("tecnipart")
    .directive("catalogosEditComponent", catalogosEditComponent);

function catalogosEditComponent() {
    var directive = {
        restrict: "E",
        controller: "catalogosEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Catalogos/CatalogosComponent",
        scope: {
            catalogos: "="
        }
};
    return directive;
}