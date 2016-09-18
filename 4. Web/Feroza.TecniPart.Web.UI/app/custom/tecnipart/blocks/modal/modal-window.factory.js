(function () {

    "use strict";
    // ReSharper disable once PossiblyUnassignedProperty
    angular.module("tecnipart")
        // ReSharper disable once PossiblyUnassignedProperty
        .factory("modalWindowFactory", modalWindowFactory);
    modalWindowFactory.$inject = ["$modal", "$mdDialog", "logger"];
    function modalWindowFactory($modal, $mdDialog, logger) {

        return {
            show: function (controller, event) {
                logger.info("[modalWindowFactory] Iniciando el evento para levantar el modal", controller);
                $mdDialog.show({
                    //scope: $scope,
                    templateUrl: 'Partials/ModalService',
                    parent: angular.element(document.body),
                    clickOutsideToClose: false,
                    focusOnOpen: true,
                    targetEvent: event,
                    fullscreen: false // Only for -xs, -sm breakpoints.
                })
                .then(function (answer) {
                    //$scope.status = 'You said the information was "' + answer + '".';
                }, function () {
                    //$scope.status = 'You cancelled the dialog.';
                });
            },
            cancel: function () {
                $mdDialog.cancel();
            },
            hide: function () {
                $mdDialog.hide();
            }
        };
    };
})();