(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("sistemasAddController", sistemasAddController);
    sistemasAddController.$inject = ["sistemasDataServices", "logger", "modalWindowFactory"];

    function sistemasAddController(sistemasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [sistemasAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", sistemasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[sistemasAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            sistemasDataServices.save(vm.sistemas).then(function (data) {
                modalWindowFactory.hide();
            }, function (reason) {
                logger.error(reason);
            });
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();