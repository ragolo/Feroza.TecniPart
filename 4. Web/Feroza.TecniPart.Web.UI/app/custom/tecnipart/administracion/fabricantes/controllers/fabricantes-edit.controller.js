(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("fabricantesEditController", fabricantesEditController);
    fabricantesEditController.$inject = ["fabricantesDataServices", "logger", "modalWindowFactory", "fileReader", "$scope"];

    function fabricantesEditController(fabricantesDataServices, logger, modalWindowFactory, fileReader, $scope) {
        var vm = this;

        logger.info("Cargando por primera vez [fabricantesEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", fabricantesDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            logger.info("[fabricantesEditController] inicializa controlador", vm);
            vm.fabricantes.ImagenFabricanteBase64 = "data:image/jpeg;base64," + vm.fabricantes.ImagenFabricante;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.fabricantes.ImagenFabricanteBase64 = result;
                          });
        };

        function save() {
            logger.info("[fabricantesEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                fabricantesDataServices.putWithImage(vm.fabricantes, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            fabricantesDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            }
            else {
                fabricantesDataServices.put(vm.fabricantes)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            fabricantesDataServices.query();
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