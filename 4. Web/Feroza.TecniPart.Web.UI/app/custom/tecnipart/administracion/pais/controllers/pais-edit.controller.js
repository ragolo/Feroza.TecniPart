(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisEditController", paisEditController);
    paisEditController.$inject = ["paisDataServices", "logger", "modalWindowFactory"];

    function paisEditController(paisDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [paisEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", paisDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();
  
        function init() {
        }

        function save() {
            logger.info("[paisEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            paisDataServices.put(vm.pais).then(function () {
                paisDataServices.query();
                modalWindowFactory.hide();
            }, function(reason) {
                
            });
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();