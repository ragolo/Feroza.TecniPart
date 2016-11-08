(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("marcasTiposProductosAddController", marcasTiposProductosAddController);
    marcasTiposProductosAddController.$inject = ["marcasTiposProductosDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function marcasTiposProductosAddController(marcasTiposProductosDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [marcasTiposProductosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", marcasTiposProductosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.marcasTiposProductos.IdPaises = "";
            vm.marcasTiposProductos.IdMarcasTiposProductos = 0;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.marcasTiposProductos.ImagenMarcasTiposProductosBase64 = result;
                          });
        };

        function save() {
            if (typeof ($scope.file) !== "undefined") {
                marcasTiposProductosDataServices.saveWithImage(vm.marcasTiposProductos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            marcasTiposProductosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    });
            } else {
                marcasTiposProductosDataServices.save(vm.marcasTiposProductos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            marcasTiposProductosDataServices.query();
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