(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("vehiculosAddController", vehiculosAddController);
    vehiculosAddController.$inject = ["vehiculosDataServices", "logger", "modalWindowFactory"];

    function vehiculosAddController(vehiculosDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [vehiculosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", vehiculosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[vehiculosAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            vehiculosDataServices.save(vm.vehiculos).then(function (data) {
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