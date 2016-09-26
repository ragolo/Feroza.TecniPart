"use strict";
angular.module("tecnipart")
    .service("vehiculosStateProvider", vehiculosStateProvider);

vehiculosStateProvider.$inject = ["$state", "$timeout", "logger", "vehiculosDataServices", "modalWindowFactory", "$timeout"];

function vehiculosStateProvider($state, $timeoute, logger, vehiculosDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToVehiculosComponentAdd = goToVehiculosComponentAdd;
    stateProvider.goToVehiculosComponentEdit = goToVehiculosComponentEdit;

    return stateProvider;

    function goToVehiculosComponentAdd() {
        return $state.transitionTo("state-vehiculos-VehiculosAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("vehiculosAddController");
                                         });
                                     });
    }

    function goToVehiculosComponentEdit(id) {
        logger.info("Comienza la consulta del estado vehiculos model -> ", id);
        return vehiculosDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-vehiculos-VehiculosEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("VehiculosEditView");
                        });
                    });
            });
    }
}