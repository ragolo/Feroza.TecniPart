(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisesEditController", paisesEditController);
    paisesEditController.$inject = ["paisesDataServices", "logger", "modalWindowFactory"];

    function paisesEditController(paisesDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [paisesEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", paisesDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {

        }

        function save() {
            logger.info("[paisesEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            paisesDataServices.put(vm.paises).then(function (data) {
                if (typeof (data) !== "undefined") {
                    paisesDataServices.query().then(function (data) { });
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