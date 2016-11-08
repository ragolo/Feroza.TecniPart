(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("sistemasEditController", sistemasEditController);
    sistemasEditController.$inject = ["sistemasDataServices", "logger", "modalWindowFactory", "fileReader", "$scope"];

    function sistemasEditController(sistemasDataServices, logger, modalWindowFactory, fileReader, $scope) {
        var vm = this;

        logger.info("Cargando por primera vez [sistemasEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", sistemasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            logger.info("[sistemasEditController] inicializa controlador", vm);
            vm.sistemas.ImagenSistemasBase64 = "data:image/jpeg;base64," + vm.sistemas.ImagenFabricante;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.sistemas.ImagenSistemasBase64 = result;
                          });
        };

        function save() {
            logger.info("[sistemasEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                sistemasDataServices.putWithImage(vm.sistemas, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            sistemasDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            }
            else {
                sistemasDataServices.put(vm.sistemas)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            sistemasDataServices.query();
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