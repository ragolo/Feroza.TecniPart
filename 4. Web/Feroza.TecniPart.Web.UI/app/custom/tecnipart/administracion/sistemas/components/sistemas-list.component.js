(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("sistemasListComponent", sistemasListComponent);
	function sistemasListComponent() {

		var directive = {
			restrict: "E",
			controller: "sistemasController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/Sistemas/SistemasListComponent",
            scope: {
                sistemas: "="
            }
		};
		return directive;
	}
})();