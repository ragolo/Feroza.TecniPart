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
            vm.referencias.IdReferencias = "";
            vm.referencias.IdSistemas = "";
            vm.referencias.IdSubSistemas = "";
        }

        function save() {
            logger.info("[referenciasAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            referenciasDataServices.save(vm.referencias).then(function (data) {
                if (typeof (data) !== "undefined") {
                    modalWindowFactory.hide();
                }
            });
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();