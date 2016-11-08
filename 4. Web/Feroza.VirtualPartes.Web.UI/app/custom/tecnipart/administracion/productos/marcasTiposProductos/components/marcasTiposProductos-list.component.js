(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("marcasTiposProductosListComponent", marcasTiposProductosListComponent);
	function marcasTiposProductosListComponent() {

		var directive = {
			restrict: "E",
			controller: "marcasTiposProductosController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/MarcasTiposProductos/MarcasTiposProductosListComponent",
            scope: {
                marcasTiposProductos: "="
            }
		};
		return directive;
	}
})();