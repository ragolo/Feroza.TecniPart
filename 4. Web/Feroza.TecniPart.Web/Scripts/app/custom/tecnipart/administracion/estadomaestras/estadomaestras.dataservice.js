(function () {
    "use strict";
    angular.module("tecnipart")
        .service("estadoMaestrasDataService", dataservice);
    dataservice.$inject = ["appService"];

    function dataservice(appService) {
        var service = {};
        service.EstadoMaestras = [];

        service.get = get;
        service.save = save;
        service.remove = remove;
        service.query = query;
        return service;

        function get(id) {
            return appService.get("api/EstadoMaestras",id)
                .then(function (data) {
                    service.EstadoMaestras = data;
                });
        }

        function save(estadoMaestra) {
            return appService.post("api/EstadoMaestras", estadoMaestra)
                .then(function (data) {
                    service.EstadoMaestras = data;
                });
        }

        function query() {
            return appService.get("api/EstadoMaestras", "")
                .then(function (data) {
                    service.EstadoMaestras = data;
                });
        }

        function remove(id) {
            return appService.delete("api/EstadoMaestras", id)
                .then(function (data) {
                    service.EstadoMaestras = data;
                });
        }
    }
})();