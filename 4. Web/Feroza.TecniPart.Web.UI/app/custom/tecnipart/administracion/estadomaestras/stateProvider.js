"use strict";
angular.module("tecnipart")
    .service("estadomaestrasStateProvider", estadomaestrasStateProvider);

estadomaestrasStateProvider.$inject = ["$state", "$timeout", "logger", "estadomaestasDataServices", "modalWindowFactory", "$timeout"];

function estadomaestrasStateProvider($state, $timeoute, logger, estadomaestasDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToEstadoMaestrasComponentAdd = goToEstadoMaestrasComponentAdd;
    stateProvider.goToEstadoMaestrasComponentEdit = goToEstadoMaestrasComponentEdit;

    return stateProvider;

    function goToEstadoMaestrasComponentAdd() {
        return $state.transitionTo("state-estadomaestras-EstadoMaestrasAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("estadomaestrasAddController");
                                         });
                                     });
    }

    function goToEstadoMaestrasComponentEdit(id) {
        logger.info("Comienza la consulta del estado maestra model -> ", id);
        return estadomaestasDataServices.getEstadoMaestrasModel(id)
            .then(function () {
                return $state.transitionTo("state-estadomaestras-EstadoMaestrasEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("EstadoMaestrasEditView");
                        });
                    });
            });
    }
}