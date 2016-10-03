(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("fabricantesAddController", fabricantesAddController);
    fabricantesAddController.$inject = ["fabricantesDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function fabricantesAddController(fabricantesDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [fabricantesAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", fabricantesDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.fabricantes.ImagenFabricanteBase64 = result;
                          });
        };

        function save() {
            if (typeof ($scope.file) !== "undefined") {
                fabricantesDataServices.saveWithImage(vm.fabricantes, $scope.file)
                    .then(function () {
                        fabricantesDataServices.query();
                        modalWindowFactory.hide();
                    });
            } else {
                fabricantesDataServices.save(vm.fabricantes)
                    .then(function () {
                        fabricantesDataServices.query();
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