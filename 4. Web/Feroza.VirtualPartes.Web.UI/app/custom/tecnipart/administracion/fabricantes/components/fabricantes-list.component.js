(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("fabricantesListComponent", fabricantesListComponent);
	function fabricantesListComponent() {

		var directive = {
			restrict: "E",
			controller: "fabricantesController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Fabricantes/FabricantesListComponent",
            scope: {
                fabricantes: "="
            }
		};
		return directive;
	}
})();