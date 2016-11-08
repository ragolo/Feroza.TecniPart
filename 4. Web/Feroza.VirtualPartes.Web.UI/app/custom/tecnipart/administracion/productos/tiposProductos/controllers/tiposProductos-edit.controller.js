(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("tiposProductosEditController", tiposProductosEditController);
    tiposProductosEditController.$inject = ["tiposProductosDataServices", "logger", "modalWindowFactory", "fileReader", "$scope"];

    function tiposProductosEditController(tiposProductosDataServices, logger, modalWindowFactory, fileReader, $scope) {
        var vm = this;

        logger.info("Cargando por primera vez [tiposProductosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", tiposProductosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            logger.info("[tiposProductosEditController] inicializa controlador", vm);
            vm.tiposProductos.ImagenTiposProductosBase64 = "data:image/jpeg;base64," + vm.tiposProductos.ImagenFabricante;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.tiposProductos.ImagenTiposProductosBase64 = result;
                          });
        };

        function save() {
            logger.info("[tiposProductosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                tiposProductosDataServices.putWithImage(vm.tiposProductos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            tiposProductosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            }
            else {
                tiposProductosDataServices.put(vm.tiposProductos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            tiposProductosDataServices.query();
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