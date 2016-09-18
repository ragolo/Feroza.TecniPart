(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("estadomaestrasListComponent", estadomaestrasListComponent);
	function estadomaestrasListComponent() {

		var directive = {
			restrict: "E",
			controller: "estadomaestrasController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/EstadoMaestras/EstadoMaestrasListComponent",
            scope: {
                estadomaestras: "="
            }
		};
		return directive;
	}
})();