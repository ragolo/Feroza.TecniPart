(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("tiposProductosAddController", tiposProductosAddController);
    tiposProductosAddController.$inject = ["tiposProductosDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function tiposProductosAddController(tiposProductosDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [tiposProductosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", tiposProductosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.tiposProductos.IdPaises = "";
            vm.tiposProductos.IdTiposProductos = 0;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.tiposProductos.ImagenTiposProductosBase64 = result;
                          });
        };

        function save() {
            if (typeof ($scope.file) !== "undefined") {
                tiposProductosDataServices.saveWithImage(vm.tiposProductos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            tiposProductosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    });
            } else {
                tiposProductosDataServices.save(vm.tiposProductos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            tiposProductosDataServices.query();
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