(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadomaestrasEditController", estadomaestrasEditController);
    estadomaestrasEditController.$inject = ["estadomaestasDataServices", "logger", "modalWindowFactory"];

    function estadomaestrasEditController(estadomaestasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [estadomaestrasEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", estadomaestasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[estadomaestrasEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            estadomaestasDataServices.put(vm.estadomaestras).then(function () {
                estadomaestasDataServices.query().then(function (data) {
                    vm.estadomaestras = vm.estadomaestras.get();
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