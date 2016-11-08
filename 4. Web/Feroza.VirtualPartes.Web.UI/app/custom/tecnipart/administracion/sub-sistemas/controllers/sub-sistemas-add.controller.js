(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("subSistemasAddController", subSistemasAddController);
    subSistemasAddController.$inject = ["subSistemasDataServices", "logger", "modalWindowFactory"];

    function subSistemasAddController(subSistemasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [subSistemasAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", subSistemasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.subSistemas.IdSistemas = "";
        }

        function save() {
            logger.info("[subSistemasAddController] Se esta guardando el sub sistemas, vm -> ", vm);
            subSistemasDataServices.save(vm.subSistemas).then(function (data) {
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