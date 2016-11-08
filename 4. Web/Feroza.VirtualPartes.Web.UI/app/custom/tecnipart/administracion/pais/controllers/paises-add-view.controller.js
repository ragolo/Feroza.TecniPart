(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisesAddViewController", paisesAddViewController);
    paisesAddViewController.$inject = ["paisesDataServices", "logger"];

    function paisesAddViewController(paisesDataServices, logger) {
        var vm = this;
        init();
        function init() {
            paisesDataServices.getPaisModel().then(function (responseData) {
                vm.paises = responseData;
                vm.paises.IdPaises = 0;
            });
        }
    }
})();