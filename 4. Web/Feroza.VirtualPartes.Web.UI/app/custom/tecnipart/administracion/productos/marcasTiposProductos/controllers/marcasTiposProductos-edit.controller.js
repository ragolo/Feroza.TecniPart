(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasTiposProductosEditController", marcasTiposProductosEditController);
    marcasTiposProductosEditController.$inject = ["marcasTiposProductosDataServices", "logger", "modalWindowFactory", "fileReader", "$scope"];

    function marcasTiposProductosEditController(marcasTiposProductosDataServices, logger, modalWindowFactory, fileReader, $scope) {
        var vm = this;

        logger.info("Cargando por primera vez [marcasTiposProductosEditController] ->", vm);
        logger.info("Mostrando datos del dataservice", marcasTiposProductosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            logger.info("[marcasTiposProductosEditController] inicializa controlador", vm);
            vm.marcasTiposProductos.ImagenMarcasTiposProductosBase64 = "data:image/jpeg;base64," + vm.marcasTiposProductos.ImagenFabricante;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.marcasTiposProductos.ImagenMarcasTiposProductosBase64 = result;
                          });
        };

        function save() {
            logger.info("[marcasTiposProductosEditController] Se esta guardando el estado de la maestra, vm -> ", vm);
            if (typeof ($scope.file) !== "undefined") {
                marcasTiposProductosDataServices.putWithImage(vm.marcasTiposProductos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            marcasTiposProductosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    },
                        function (reason) {
                            logger.error(reason);
                        });
            }
            else {
                marcasTiposProductosDataServices.put(vm.marcasTiposProductos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            marcasTiposProductosDataServices.query();
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