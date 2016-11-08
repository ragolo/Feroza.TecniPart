(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("tiposProductosListComponent", tiposProductosListComponent);
	function tiposProductosListComponent() {

		var directive = {
			restrict: "E",
			controller: "tiposProductosController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/TiposProductos/TiposProductosListComponent",
            scope: {
                tiposProductos: "="
            }
		};
		return directive;
	}
})();