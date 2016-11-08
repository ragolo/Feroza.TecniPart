(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("referenciasListComponent", referenciasListComponent);
	function referenciasListComponent() {

		var directive = {
			restrict: "E",
			controller: "referenciasController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Referencias/ReferenciasListComponent",
            scope: {
                referencias: "="
            }
		};
		return directive;
	}
})();