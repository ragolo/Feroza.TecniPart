(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("lineasProductosEditController", lineasProductosEditController);
    lineasProductosEditController.$inject = ["lineasProductosDataServices", "logger", "modalWindowFactory", "fileReader", "$scope"];

    function lineasProductosEditController(lineasProductosDataServices, logger, modalWindowFactory, fileReader, $scope) {
        var vm = this;

        logger.info("Cargando por primera vez [lineasProductosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", lineasProductosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            logger.info("[lineasProductosEditController] inicializa controlador", vm);
            vm.lineasProductos.ImagenLineasProductosBase64 = "data:image/jpeg;base64," + vm.lineasProductos.ImagenFabricante;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.lineasProductos.ImagenLineasProductosBase64 = result;
                          });
        };

        function save() {
            logger.info("[lineasProductosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                lineasProductosDataServices.putWithImage(vm.lineasProductos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            lineasProductosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            }
            else {
                lineasProductosDataServices.put(vm.lineasProductos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            lineasProductosDataServices.query();
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