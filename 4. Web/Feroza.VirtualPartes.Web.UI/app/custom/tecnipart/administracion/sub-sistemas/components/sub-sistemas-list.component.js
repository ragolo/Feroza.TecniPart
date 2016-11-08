(function () {
	"use strict";
	angular.module("tecnipart")
        .directive("subSistemasListComponent", subSistemasListComponent);
	function subSistemasListComponent() {

		var directive = {
			restrict: "E",
			controller: "subSistemasController",
			controllerAs : "vm",
            bindToController: true,
            templateUrl: "/SubSistemas/SubSistemasListComponent",
            scope: {
                subSistemas: "="
            }
		};
		return directive;
	}
})();