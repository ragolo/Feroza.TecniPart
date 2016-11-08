(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("referenciasAddController", referenciasAddController);
    referenciasAddController.$inject = ["referenciasDataServices", "logger", "modalWindowFactory"];

    function referenciasAddController(referenciasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [referenciasAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", referenciasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.referencias.Cantidad = "";
        }

        function save() {
            logger.info("[referenciasAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            referenciasDataServices.save(vm.referencias).then(function (data) {
                if (typeof (data) !== "undefined") {
                    modalWindowFactory.hide();
                    referenciasDataServices.query();
                }
            });
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();