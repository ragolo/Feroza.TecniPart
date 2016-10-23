(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("vehiculosAddController", vehiculosAddController);
    vehiculosAddController.$inject = ["vehiculosDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function vehiculosAddController(vehiculosDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [vehiculosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", vehiculosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.vehiculos.IdMarca = "";
            vm.vehiculos.IdFabricantes = "";
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.vehiculos.ImagenVehiculoBase64 = result;
                          });
        };

        function save() {
            logger.info("[vehiculosAddController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                vehiculosDataServices.saveWithImage(vm.vehiculos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            vehiculosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    });
            } else {
                vehiculosDataServices.save(vm.vehiculos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            vehiculosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    }, function (reason) {
                        return reason;
                    });
            }
        }

        function cancel() {
            modalWindowFactory.cancel();
        }
    }
})();