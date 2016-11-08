"use strict";
angular.module("tecnipart.utils")
    .directive("visorImagen", visorImagen);
visorImagen.$inject = ["$mdDialog"];

function visorImagen($mdDialog) {
    return {
        restrict: "A",
        //templateUrl: "",
        link: function ($scope, $element, attrs, ctrl) {
            $element.unbind("click");
            $element.bind("click", function (ev) {
                $mdDialog.show(
                    $mdDialog.alert({
                        templateUrl: "Partials/VisorImagen",
                        locals: {
                            src: attrs.src
                        },
                        controller: "visorImagenController",
                        controllerAs: "vm",
                        bindToController: true
                    })
                    .parent(angular.element(document.querySelector('.maincontent')))
                    .clickOutsideToClose(true)
                    .targetEvent(ev)
                );
            });
        }
    }
}