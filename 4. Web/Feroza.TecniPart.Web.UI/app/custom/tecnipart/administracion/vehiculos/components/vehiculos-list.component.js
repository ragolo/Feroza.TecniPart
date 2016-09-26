(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("vehiculosListComponent", vehiculosListComponent);
	function vehiculosListComponent() {

		var directive = {
			restrict: "E",
			controller: "vehiculosController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Vehiculos/VehiculosListComponent",
            scope: {
                vehiculos: "="
            }
		};
		return directive;
	}
})();