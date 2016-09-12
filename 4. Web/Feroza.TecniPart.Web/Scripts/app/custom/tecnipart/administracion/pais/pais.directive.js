(function () {
    "use strict";
    angular.module("tecnipart")
        .directive("paisesComponent", paisesComponent);
    function paisesComponent() {

        var directive = {
            restrict: "EAC",
            controller: "paisesController",
            controllerAs: "vm",
            bindToController: true,
            templateUrl: "/Pais/Listar",
            scope: {
                paises: "="
            }
        };
        return directive;
    }
})();