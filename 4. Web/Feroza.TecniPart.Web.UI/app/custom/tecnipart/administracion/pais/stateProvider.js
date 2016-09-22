"use strict";
angular.module("tecnipart")
    .service("paisStateProvider", paisStateProvider);

paisStateProvider.$inject = ["$state", "$timeout", "logger", "paisDataServices", "modalWindowFactory", "$timeout"];

function paisStateProvider($state, $timeoute, logger, paisDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToPaisComponentAdd = goToPaisComponentAdd;
    stateProvider.goToPaisComponentEdit = goToPaisComponentEdit;

    return stateProvider;

    function goToPaisComponentAdd() {
        return $state.transitionTo("state-pais-PaisAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("paisAddController");
                                         });
                                     });
    }

    function goToPaisComponentEdit(id) {
        logger.info("Comienza la consulta del estado pais model -> ", id);
        return paisDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-pais-PaisEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("PaisEditView");
                        });
                    });
            });
    }
}