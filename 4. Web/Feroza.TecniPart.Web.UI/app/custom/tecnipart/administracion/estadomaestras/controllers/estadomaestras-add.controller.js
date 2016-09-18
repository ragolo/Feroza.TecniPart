(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("estadomaestrasAddController", estadomaestrasAddController);
    estadomaestrasAddController.$inject = ["estadomaestasDataServices", "logger", "modalWindowFactory"];

    function estadomaestrasAddController(estadomaestasDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [estadomaestrasAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", estadomaestasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();
  
        function init() {
        }

        function save() {
            logger.info("[estadomaestrasAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            estadomaestasDataServices.save(vm.estadomaestras).then(function () {
                modalWindowFactory.hide();
            }, function(reason) {
                
            });
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();