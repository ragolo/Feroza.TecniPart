"use strict";
angular.module("tecnipart")
    .service("catalogosStateProvider", catalogosStateProvider);

catalogosStateProvider.$inject = ["$state", "$timeout", "logger", "catalogosDataServices", "modalWindowFactory", "$timeout"];

function catalogosStateProvider($state, $timeoute, logger, catalogosDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToCatalogosComponentAdd = goToCatalogosComponentAdd;
    stateProvider.goToCatalogosComponentEdit = goToCatalogosComponentEdit;

    return stateProvider;

    function goToCatalogosComponentAdd() {
        return $state.transitionTo("state-catalogos-CatalogosAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("catalogosAddController");
                                         });
                                     });
    }

    function goToCatalogosComponentEdit(id) {
        logger.info("Comienza la consulta del estado catalogos model -> ", id);
        return catalogosDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-catalogos-CatalogosEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("CatalogosEditView");
                        });
                    });
            });
    }
}