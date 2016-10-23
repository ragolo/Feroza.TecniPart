(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("subSistemasEditController", subSistemasEditController);
    subSistemasEditController.$inject = ["subSistemasDataServices", "logger", "modalWindowFactory"];

    function subSistemasEditController(subSistemasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [subSistemasEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", subSistemasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[subSistemasEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            subSistemasDataServices.put(vm.subSistemas).then(function (data) {
                if (typeof (data) !== "undefined") {
                    subSistemasDataServices.query();
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