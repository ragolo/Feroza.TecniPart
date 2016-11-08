(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("paisesListComponent", paisesListComponent);
	function paisesListComponent() {

		var directive = {
			restrict: "E",
			controller: "paisesController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Paises/PaisesListComponent",
            scope: {
                paises: "="
            }
		};
		return directive;
	}
})();