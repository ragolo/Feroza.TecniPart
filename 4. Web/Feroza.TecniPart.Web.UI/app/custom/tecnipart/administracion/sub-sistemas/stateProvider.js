"use strict";
angular.module("tecnipart")
    .service("subSistemasStateProvider", subSistemasStateProvider);

subSistemasStateProvider.$inject = ["$state", "$timeout", "logger", "subSistemasDataServices", "modalWindowFactory", "$timeout"];

function subSistemasStateProvider($state, $timeoute, logger, subSistemasDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToSubSistemasComponentAdd = goToSubSistemasComponentAdd;
    stateProvider.goToSubSistemasComponentEdit = goToSubSistemasComponentEdit;

    return stateProvider;

    function goToSubSistemasComponentAdd() {
        return $state.transitionTo("state-sub-sistemas-SubSistemasAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("subSistemasAddController");
                                         });
                                     });
    }

    function goToSubSistemasComponentEdit(id) {
        logger.info("Comienza la consulta del estado subSistemas model -> ", id);
        return subSistemasDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-sub-sistemas-SubSistemasEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("SubSistemasEditView");
                        });
                    });
            });
    }
}