(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("productosListComponent", productosListComponent);
	function productosListComponent() {

		var directive = {
			restrict: "E",
			controller: "productosController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Productos/ProductosListComponent",
            scope: {
                productos: "="
            }
		};
		return directive;
	}
})();