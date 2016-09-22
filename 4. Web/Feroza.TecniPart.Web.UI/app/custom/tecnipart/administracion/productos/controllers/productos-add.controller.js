(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("productosAddController", productosAddController);
    productosAddController.$inject = ["productosDataServices", "logger", "modalWindowFactory"];

    function productosAddController(productosDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [productosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", productosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[productosAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            productosDataServices.save(vm.productos).then(function (data) {
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