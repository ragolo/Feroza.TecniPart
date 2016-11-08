(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("lineasProductosListComponent", lineasProductosListComponent);
	function lineasProductosListComponent() {

		var directive = {
			restrict: "E",
			controller: "lineasProductosController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/LineasProductos/LineasProductosListComponent",
            scope: {
                lineasProductos: "="
            }
		};
		return directive;
	}
})();