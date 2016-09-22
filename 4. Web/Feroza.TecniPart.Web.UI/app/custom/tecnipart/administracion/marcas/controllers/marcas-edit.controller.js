(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasEditController", marcasEditController);
    marcasEditController.$inject = ["marcasDataServices", "logger", "modalWindowFactory"];

    function marcasEditController(marcasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [marcasEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", marcasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[marcasEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            marcasDataServices.put(vm.marcas).then(function () {
                marcasDataServices.query().then(function (data) {
                    vm.marcas = vm.marcas.get();
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