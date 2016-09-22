(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("fabricantesAddController", fabricantesAddController);
    fabricantesAddController.$inject = ["fabricantesDataServices", "logger", "modalWindowFactory"];

    function fabricantesAddController(fabricantesDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [fabricantesAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", fabricantesDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[fabricantesAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            fabricantesDataServices.save(vm.fabricantes).then(function (data) {
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