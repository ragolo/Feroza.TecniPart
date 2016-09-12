(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("estadoMaestrasComponent", estadoMaestrasCompoenent);
	function estadoMaestrasCompoenent() {

		var directive = {
			restrict: "EAC",
			controller: "estadoMaestrasController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/EstadoMaestras/Listar",
            scope: {
                estadomaestras: "="
            }
		};
		return directive;
	}
})();