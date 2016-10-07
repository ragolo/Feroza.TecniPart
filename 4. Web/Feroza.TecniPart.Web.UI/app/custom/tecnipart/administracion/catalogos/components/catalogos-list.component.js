(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("catalogosListComponent", catalogosListComponent);
	function catalogosListComponent() {

		var directive = {
			restrict: "E",
			controller: "catalogosController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Catalogos/CatalogosListComponent",
            scope: {
                catalogos: "="
            }
		};
		return directive;
	}
})();