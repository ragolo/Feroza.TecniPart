(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasAddController", marcasAddController);
    marcasAddController.$inject = ["marcasDataServices", "logger", "modalWindowFactory"];

    function marcasAddController(marcasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [marcasAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", marcasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[marcasAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            marcasDataServices.save(vm.marcas).then(function (data) {
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