(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("productosEditController", productosEditController);
    productosEditController.$inject = ["productosDataServices", "logger", "modalWindowFactory", "fileReader", "$scope"];

    function productosEditController(productosDataServices, logger, modalWindowFactory, fileReader, $scope) {
        var vm = this;

        logger.info("Cargando por primera vez [productosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", productosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            logger.info("[productosEditController] inicializa controlador", vm);
            vm.productos.ImagenProductosBase64 = "data:image/jpeg;base64," + vm.productos.ImagenFabricante;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.productos.ImagenProductosBase64 = result;
                          });
        };

        function save() {
            logger.info("[productosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                productosDataServices.putWithImage(vm.productos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            productosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            }
            else {
                productosDataServices.put(vm.productos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            productosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            }
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();