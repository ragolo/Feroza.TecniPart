(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("vehiculosEditController", vehiculosEditController);
    vehiculosEditController.$inject = ["vehiculosDataServices", "logger", "modalWindowFactory"];

    function vehiculosEditController(vehiculosDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [vehiculosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", vehiculosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[vehiculosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            vehiculosDataServices.put(vm.vehiculos).then(function () {
                vehiculosDataServices.query();
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