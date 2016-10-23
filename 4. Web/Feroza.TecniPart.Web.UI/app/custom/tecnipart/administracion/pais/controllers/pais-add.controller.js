(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisAddController", paisAddController);
    paisAddController.$inject = ["paisDataServices", "logger", "modalWindowFactory"];

    function paisAddController(paisDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [paisAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", paisDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.pais.IdPais = "";
            vm.pais.IdDane = "";
        }

        function save() {
            logger.info("[paisAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            paisDataServices.save(vm.pais).then(function (data) {
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