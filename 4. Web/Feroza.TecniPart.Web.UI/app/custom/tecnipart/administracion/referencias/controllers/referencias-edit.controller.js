(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("referenciasEditController", referenciasEditController);
    referenciasEditController.$inject = ["referenciasDataServices", "logger", "modalWindowFactory"];

    function referenciasEditController(referenciasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [referenciasEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", referenciasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {

        }

        function save() {
            logger.info("[referenciasEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            referenciasDataServices.put(vm.referencias).then(function (data) {
                if (typeof (data) !== "undefined") {
                    referenciasDataServices.query().then(function (data) { });
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