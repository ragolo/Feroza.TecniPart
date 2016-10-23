"use strict";
angular.module("tecnipart")
    .service("vehiculosStateProvider", vehiculosStateProvider);

vehiculosStateProvider.$inject = ["$state", "$timeout", "logger", "vehiculosDataServices", "modalWindowFactory", "$timeout", "$mdDialog"];

function vehiculosStateProvider($state,
    $timeoute,
    logger,
    vehiculosDataServices,
    modalWindowFactory,
    $timeout,
    $mdDialog) {
    var stateProvider = {};

    stateProvider.goToVehiculosComponentAdd = goToVehiculosComponentAdd;
    stateProvider.goToVehiculosComponentEdit = goToVehiculosComponentEdit;

    return stateProvider;

    function goToVehiculosComponentAdd() {
        return getVehiculosModel("vehiculosAddController", null);
    }

    function goToVehiculosComponentEdit(id) {
        logger.info("Comienza la consulta del estado vehiculos model -> ", id);
        return getVehiculosModel("vehiculosEditController", id);

    }

    function getVehiculosModel(controlador, parametro) {
        return vehiculosDataServices.getVehiculosModel(parametro)
            .then(function(resultado) {
                showDialog(null, resultado, controlador);
            });
    }

    function showDialog($event, vehiculos, controllerName) {
        var parentEl = angular.element(document.body);
        $mdDialog.show({
            parent: parentEl,
            targetEvent: $event,
            templateUrl: "Vehiculos/VehiculosComponent",
            controller: controllerName,
            controllerAs: "vm",
            locals: { vehiculos: vehiculos },
            bindToController: true
        });
    }
}