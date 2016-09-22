(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("marcasListComponent", marcasListComponent);
	function marcasListComponent() {

		var directive = {
			restrict: "E",
			controller: "marcasController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Marcas/MarcasListComponent",
            scope: {
                marcas: "="
            }
		};
		return directive;
	}
})();