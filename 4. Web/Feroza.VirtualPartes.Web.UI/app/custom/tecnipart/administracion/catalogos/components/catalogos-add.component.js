"use strict";
angular.module("tecnipart")
    .directive("catalogosAddComponent", catalogosAddComponent);

function catalogosAddComponent() {
    var directive = {
        restrict: "E",
        controller: "catalogosAddController",
        controllerAs: "vm",
        templateUrl: "/Catalogos/CatalogosComponent",
        scope: {
            catalogos: "="
        },
        bindToController: true
};
    return directive;
}