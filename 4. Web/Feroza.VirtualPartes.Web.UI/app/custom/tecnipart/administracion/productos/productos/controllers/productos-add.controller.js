(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("productosAddController", productosAddController);
    productosAddController.$inject = ["productosDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function productosAddController(productosDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [productosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", productosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.productos.IdPaises = "";
            vm.productos.IdProductos = 0;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.productos.ImagenProductosBase64 = result;
                          });
        };

        function save() {
            if (typeof ($scope.file) !== "undefined") {
                productosDataServices.saveWithImage(vm.productos, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            productosDataServices.query();
                            modalWindowFactory.hide();
                        }
                    });
            } else {
                productosDataServices.save(vm.productos)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            productosDataServices.query();
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