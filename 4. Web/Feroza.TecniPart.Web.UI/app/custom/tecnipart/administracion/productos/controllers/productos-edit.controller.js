(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("productosEditController", productosEditController);
    productosEditController.$inject = ["productosDataServices", "logger", "modalWindowFactory"];

    function productosEditController(productosDataServices, logger, modalWindowFactory) {
        var vm = this;

        logger.info("Cargando por primera vez [productosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", productosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        function save() {
            logger.info("[productosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            productosDataServices.put(vm.productos).then(function () {
                productosDataServices.query().then(function (data) {
                    vm.productos = vm.productos.get();
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