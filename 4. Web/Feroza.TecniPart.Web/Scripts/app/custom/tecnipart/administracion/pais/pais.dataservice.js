(function () {
    "use strict";
    angular.module("tecnipart")
        .service("paisesDataService", dataservice);
    dataservice.$inject = ["appService"];

    function dataservice(appService) {
        var service = {};
        service.Paises = [];

        service.getPaises = getPaises;
        return service;

        function getPaises() {
            return appService.get("api/Pais","")
                .then(function (data) {
                    service.Paises = data;
                });
        }
    }
})();