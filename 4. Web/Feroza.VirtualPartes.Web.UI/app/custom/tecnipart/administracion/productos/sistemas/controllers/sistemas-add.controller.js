(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("sistemasAddController", sistemasAddController);
    sistemasAddController.$inject = ["sistemasDataServices", "logger", "modalWindowFactory", "$scope", "fileReader"];

    function sistemasAddController(sistemasDataServices, logger, modalWindowFactory, $scope, fileReader) {
        var vm = this;

        logger.info("Cargando por primera vez [sistemasAddController] ->", vm);
        logger.info("Mostrando datos del dataservice", sistemasDataServices);
        vm.save = save;
        vm.cancel = cancel;
        init();

        function init() {
            vm.sistemas.IdPaises = "";
            vm.sistemas.IdSistemas = 0;
        }

        $scope.getFile = function () {
            $scope.progress = 0;
            fileReader.readAsDataUrl($scope.file, $scope)
                          .then(function (result) {
                              vm.sistemas.ImagenSistemasBase64 = result;
                          });
        };

        function save() {
            if (typeof ($scope.file) !== "undefined") {
                sistemasDataServices.saveWithImage(vm.sistemas, $scope.file)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            sistemasDataServices.query();
                            modalWindowFactory.hide();
                        }
                    });
            } else {
                sistemasDataServices.save(vm.sistemas)
                    .then(function (data) {
                        if (typeof (data) !== "undefined") {
                            sistemasDataServices.query();
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