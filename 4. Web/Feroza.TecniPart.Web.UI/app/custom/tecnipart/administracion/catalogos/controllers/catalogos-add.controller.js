(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("catalogosAddController", catalogosAddController);
    catalogosAddController.$inject = ["catalogosDataServices", "logger", "modalWindowFactory", "$scope", "fileReader", "$timeout"];

    function catalogosAddController(catalogosDataServices, logger, modalWindowFactory, $scope, fileReader, $timeout) {
        var vm = this;

        logger.info("Cargando por primera vez [catalogosAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", catalogosDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();
        watch();

        function init() {
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
                        if ( typeof (vm.catalogos) !== "undefined" && typeof (vm.catalogos.IdSubSistemas) !== "undefined") {
                            vm.catalogos.IdSubSistemas = "";
                        }
                    });
            });
        }

        function save() {
            if (typeof ($scope.file) !== "undefined") {
                catalogosDataServices.saveWithImage(vm.catalogos, $scope.file)
                    .then(function () {
                        catalogosDataServices.query();
                        modalWindowFactory.hide();
                    });
            } else {
                catalogosDataServices.save(vm.catalogos)
                    .then(function () {
                        catalogosDataServices.query();
                        modalWindowFactory.hide();
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