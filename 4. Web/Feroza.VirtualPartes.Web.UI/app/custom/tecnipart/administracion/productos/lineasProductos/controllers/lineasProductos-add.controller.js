(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("lineasProductosAddController", lineasProductosAddController);
    lineasProductosAddController.$inject = ["lineasProductosDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function lineasProductosAddController(lineasProductosDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [lineasProductosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", lineasProductosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.lineasProductos.IdPaises = "";
            vm.lineasProductos.IdLineasProductos = 0;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.lineasProductos.ImagenLineasProductosBase64 = result;
                          });
        };

        function save() {
            if (typeof ($scope.file) !== "undefined") {
                lineasProductosDataServices.saveWithImage(vm.lineasProductos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            lineasProductosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    });
            } else {
                lineasProductosDataServices.save(vm.lineasProductos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            lineasProductosDataServices.query();
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