(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("qsistemasEditController", sistemasEditController);
    sistemasEditController.$inject = ["sistemasDataServices", "logger", "modalWindowFactory"];

    function sistemasEditController(sistemasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [sistemasEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", sistemasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[sistemasEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            sistemasDataServices.put(vm.sistemas).then(function (data) {
                if (typeof (data) !== "undefined") {
                    sistemasDataServices.query();
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