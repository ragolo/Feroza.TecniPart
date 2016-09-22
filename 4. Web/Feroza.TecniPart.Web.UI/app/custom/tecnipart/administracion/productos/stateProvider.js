"use strict";
angular.module("tecnipart")
    .service("productosStateProvider", productosStateProvider);

productosStateProvider.$inject = ["$state", "$timeout", "logger", "productosDataServices", "modalWindowFactory", "$timeout"];

function productosStateProvider($state, $timeoute, logger, productosDataServices, modalWindowFactory, $timeout) {
    var stateProvider = {};

    stateProvider.goToProductosComponentAdd = goToProductosComponentAdd;
    stateProvider.goToProductosComponentEdit = goToProductosComponentEdit;

    return stateProvider;

    function goToProductosComponentAdd() {
        return $state.transitionTo("state-productos-ProductosAddView",
                                     {},
                                     {
                                         reload: true,
                                         inherit: false,
                                         notify: false
                                     })
                                     .then(function () {
                                         $timeout(function () {
                                             modalWindowFactory.show("productosAddController");
                                         });
                                     });
    }

    function goToProductosComponentEdit(id) {
        logger.info("Comienza la consulta del estado productos model -> ", id);
        return productosDataServices.get(id)
            .then(function () {
                return $state.transitionTo("state-productos-ProductosEditView",
                        {},
                        {
                            reload: true,
                            inherit: false,
                            notify: false
                        })
                    .then(function () {
                        $timeout(function () {
                            modalWindowFactory.show("ProductosEditView");
                        });
                    });
            });
    }
}