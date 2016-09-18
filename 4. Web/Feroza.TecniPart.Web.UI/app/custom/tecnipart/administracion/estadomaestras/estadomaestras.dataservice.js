(function () {
    "use strict";
    angular.module("tecnipart")
        .service("estadomaestasDataServices", dataservice);
    dataservice.$inject = ["appService", "logger"];

    function dataservice(appService, logger) {
        var service = {};
        service.estadoMaestrasListar = [];
        service.estadoMaestras = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.remove = remove;
        service.query = query;
        service.getEstadoMaestrasModel = getEstadoMaestrasModel;
        return service;

        function get(id) {
            return appService.get("api/EstadoMaestras", id)
                .then(function (data) {
                    service.estadoMaestras = data;
                }, function (reason) {
                    logger.error("[estadomaestasDataServices] error al intentar obtener estado maestra por " + id, reason);
                });
        }

        function save(estadoMaestra) {
            logger.info("[estadomaestasDataServices] Guardando", estadoMaestra);
            return appService.post("api/EstadoMaestras", estadoMaestra)
                .then(function (data) {
                    service.estadoMaestras = data;
                    service.estadoMaestrasListar.push(data);
                    logger.success("[estadomaestasDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadomaestras", reason);
                });
        }

        function put(estadoMaestra) {
            logger.info("[estadomaestasDataServices] Guardando", estadoMaestra);
            return appService.put("api/EstadoMaestras", estadoMaestra)
                .then(function (data) {
                    service.estadoMaestras = data;
                    service.estadoMaestrasListar.push(data);
                    logger.success("[estadomaestasDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadomaestras", reason);
                });
        }

        function query() {
            return appService.get("api/EstadoMaestras", "")
                .then(function (data) {
                    logger.info("[estadomaestasDataServices] datos obtenidos ", data);
                    service.estadoMaestrasListar = [];
                    service.estadoMaestrasListar = data;
                });
        }

        function remove(id) {
            return appService.delete("api/EstadoMaestras", id)
                .then(function (data) {
                    service.estadoMaestras = data;
                });
        }

        function getEstadoMaestrasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            return appService.fetch("EstadoMaestras/GetEstadoMaestrasModel", { id: id })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo estado maestras obtenido -> ", response);
                        service.estadoMaestras = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[estadomaestasDataServices] error obteniendo el modelo de las maestras", reason);
                });
        }
    }
})();