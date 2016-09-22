(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("fabricantesEditController", fabricantesEditController);
    fabricantesEditController.$inject = ["fabricantesDataServices", "logger", "modalWindowFactory"];

    function fabricantesEditController(fabricantesDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [fabricantesEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", fabricantesDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[fabricantesEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            fabricantesDataServices.put(vm.fabricantes).then(function () {
                fabricantesDataServices.query().then(function (data) {
                    vm.fabricantes = vm.fabricantes.get();
                });
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