"use strict";
angular.module("tecnipart")
    .service("fabricantesStateProvider", fabricantesStateProvider);

fabricantesStateProvider.$inject = ["$state", "$timeout", "logger", "fabricantesDataServices", "modalWindowFactory", "$timeout"];

function fabricantesStateProvider($state, $timeoute, logger, fabricantesDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToFabricantesComponentAdd = goToFabricantesComponentAdd;
    stateProvider.goToFabricantesComponentEdit = goToFabricantesComponentEdit;

    return stateProvider;

    function goToFabricantesComponentAdd() {
        return $state.transitionTo("state-fabricantes-FabricantesAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("fabricantesAddController");
                                         });
                                     });
    }

    function goToFabricantesComponentEdit(id) {
        logger.info("Comienza la consulta del estado fabricantes model -> ", id);
        return fabricantesDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-fabricantes-FabricantesEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("FabricantesEditView");
                        });
                    });
            });
    }
}