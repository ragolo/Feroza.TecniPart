(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("paisListComponent", paisListComponent);
	function paisListComponent() {

		var directive = {
			restrict: "E",
			controller: "paisController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Pais/PaisListComponent",
            scope: {
                paises: "="
            }
		};
		return directive;
	}
})();