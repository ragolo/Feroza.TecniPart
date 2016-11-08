(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisesAddController", paisesAddController);
    paisesAddController.$inject = ["paisesDataServices", "logger", "modalWindowFactory"];

    function paisesAddController(paisesDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [paisesAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", paisesDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.paises.IdPaises = 0;
            vm.paises.Activo = true;
        }

        function save() {
            logger.info("[paisesAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            paisesDataServices.save(vm.paises).then(function (data) {
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