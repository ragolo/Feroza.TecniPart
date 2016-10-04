"use strict";
angular.module("tecnipart")
    .service("sistemasStateProvider", sistemasStateProvider);

sistemasStateProvider.$inject = ["$state", "$timeout", "logger", "sistemasDataServices", "modalWindowFactory", "$timeout"];

function sistemasStateProvider($state, $timeoute, logger, sistemasDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToSistemasComponentAdd = goToSistemasComponentAdd;
    stateProvider.goToSistemasComponentEdit = goToSistemasComponentEdit;

    return stateProvider;

    function goToSistemasComponentAdd() {
        return $state.transitionTo("state-sistemas-SistemasAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("sistemasAddController");
                                         });
                                     });
    }

    function goToSistemasComponentEdit(id) {
        logger.info("Comienza la consulta del estado sistemas model -> ", id);
        return sistemasDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-sistemas-SistemasEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("SistemasEditView");
                        });
                    });
            });
    }
}