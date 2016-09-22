(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisAddController", paisAddController);
    paisAddController.$inject = ["paisDataServices", "logger", "modalWindowFactory"];

    function paisAddController(paisDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [paisAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", paisDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[paisAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            paisDataServices.save(vm.pais).then(function (data) {
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