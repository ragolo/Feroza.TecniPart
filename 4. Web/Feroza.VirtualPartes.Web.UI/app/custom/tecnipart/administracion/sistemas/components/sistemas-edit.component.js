﻿"use strict";
angular.module("tecnipart")
    .directive("qsistemasEditComponent", sistemasEditComponent);

function sistemasEditComponent() {
    var directive = {
        restrict: "E",
        controller: "sistemasEditController",
        controllerAs: "vm",
        bindToController: true,
        templateUrl: "/Sistemas/SistemasComponent",
        scope: {
            sistemas: "="
        }
};
    return directive;
}