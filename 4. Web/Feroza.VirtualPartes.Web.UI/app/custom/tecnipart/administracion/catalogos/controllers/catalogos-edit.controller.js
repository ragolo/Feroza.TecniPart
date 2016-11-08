(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("catalogosEditController", catalogosEditController);
    catalogosEditController.$inject = ["catalogosDataServices", "logger", "modalWindowFactory", "fileReader", "$scope", "$timeout"];

    function catalogosEditController(catalogosDataServices, logger, modalWindowFactory, fileReader, $scope, $timeout) {
        var vm = this;

        logger.info("Cargando por primera vez [catalogosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", catalogosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();
        watch();

        function init() {
            logger.info("[catalogosEditController] inicializa controlador", vm);
            vm.catalogos.ImagenCatalogoBase64 = "data:image/jpeg;base64," + vm.catalogos.ImagenCatalogo;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.catalogos.ImagenCatalogoBase64 = result;
                          });
        };

        function watch() {
            $timeout(function () {
                $scope.$watch("vm.catalogos.IdSistemas",
                    function (newValue, oldValue) {
                        if (typeof (vm.catalogos) !== "undefined" && typeof (vm.catalogos.IdSubSistemas) !== "undefined" && typeof (newValue) === "undefined") {
                            vm.catalogos.IdSubSistemas = "";
                        }
                    });
            });
        }

        function save() {
            logger.info("[catalogosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                catalogosDataServices.putWithImage(vm.catalogos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            catalogosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            } else {
                catalogosDataServices.put(vm.catalogos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            catalogosDataServices.query();
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