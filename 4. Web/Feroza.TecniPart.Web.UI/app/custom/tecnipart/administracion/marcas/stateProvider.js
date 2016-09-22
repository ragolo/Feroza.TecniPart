"use strict";
angular.module("tecnipart")
    .service("marcasStateProvider", marcasStateProvider);

marcasStateProvider.$inject = ["$state", "$timeout", "logger", "marcasDataServices", "modalWindowFactory", "$timeout"];

function marcasStateProvider($state, $timeoute, logger, marcasDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToMarcasComponentAdd = goToMarcasComponentAdd;
    stateProvider.goToMarcasComponentEdit = goToMarcasComponentEdit;

    return stateProvider;

    function goToMarcasComponentAdd() {
        return $state.transitionTo("state-marcas-MarcasAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("marcasAddController");
                                         });
                                     });
    }

    function goToMarcasComponentEdit(id) {
        logger.info("Comienza la consulta del estado marcas model -> ", id);
        return marcasDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-marcas-MarcasEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("MarcasEditView");
                        });
                    });
            });
    }
}