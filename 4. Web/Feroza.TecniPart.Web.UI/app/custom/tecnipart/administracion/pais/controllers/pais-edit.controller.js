﻿(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisEditController", paisEditController);
    paisEditController.$inject = ["paisDataServices", "logger", "modalWindowFactory"];

    function paisEditController(paisDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [paisEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", paisDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {

        }

        function save() {
            logger.info("[paisEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            paisDataServices.put(vm.pais).then(function (data) {
                if (typeof (data) !== "undefined") {
                    paisDataServices.query().then(function (data) { });
                    modalWindowFactory.hide();
                }
            }, function (reason) {
                logger.error(reason);
            });
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();