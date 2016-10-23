(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("vehiculosEditController", vehiculosEditController);
    vehiculosEditController.$inject = ["vehiculosDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function vehiculosEditController(vehiculosDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [vehiculosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", vehiculosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.vehiculos.ImagenVehiculoBase64 = "data:image/jpeg;base64," + vm.vehiculos.ImagenVehiculo;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.vehiculos.ImagenVehiculoBase64 = result;
                          });
        };

        function save() {
            logger.info("[vehiculosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);

            if (typeof ($scope.file) !== "undefined") {
                vehiculosDataServices.putWithImage(vm.vehiculos, $scope.file)
                    .then(function (data) {
                            if (typeof (data) !== "undefined") {
                                vehiculosDataServices.query();
                                modalWindowFactory.hide();
                            }
                        },
                        function (reason) {
                            logger.error(reason);
                        });
            } else {
                vehiculosDataServices.put(vm.vehiculos)
                    .then(function (data) {
                            if (typeof (data) !== "undefined") {
                                vehiculosDataServices.query();
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