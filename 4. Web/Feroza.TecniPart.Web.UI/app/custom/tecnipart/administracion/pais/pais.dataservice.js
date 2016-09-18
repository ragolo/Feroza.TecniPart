(function () {
    "use strict";
    angular.module("tecnipart")
        .service("paisDataServices", dataservice);
    dataservice.$inject = ["appService", "logger"];

    function dataservice(appService, logger) {
        var service = {};
        service.paisListar = [];
        service.pais = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.remove = remove;
        service.query = query;
        service.getPaisModel = getPaisModel;
        return service;

        function get(id) {
            return appService.get("api/Pais", id)
                .then(function (data) {
                    service.pais = data;
                }, function (reason) {
                    logger.error("[paisDataServices] error al intentar obtener estado maestra por " + id, reason);
                });
        }

        function save(estadoMaestra) {
            logger.info("[paisDataServices] Guardando", estadoMaestra);
            return appService.post("api/Pais", estadoMaestra)
                .then(function (data) {
                    service.pais = data;
                    service.paisListar.push(data);
                    logger.success("[paisDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar pais", reason);
                });
        }

        function put(estadoMaestra) {
            logger.info("[paisDataServices] Guardando", estadoMaestra);
            return appService.put("api/Pais", estadoMaestra)
                .then(function (data) {
                    service.pais = data;
                    service.paisListar.push(data);
                    logger.success("[paisDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar pais", reason);
                });
        }

        function query() {
            return appService.get("api/Pais", "")
                .then(function (data) {
                    logger.info("[paisDataServices] datos obtenidos ", data);
                    service.paisListar = [];
                    service.paisListar = data;
                });
        }

        function remove(id) {
            return appService.delete("api/Pais", id)
                .then(function (data) {
                    service.pais = data;
                });
        }

        function getPaisModel(id) {
            logger.info("[paisDataServices] Obteniendo el modelo para -> ", id);
            return appService.fetch("Pais/GetPaisModel", { id: id })
                .then(function (response) {
                    if (response.success) {
                        logger.info("[paisDataServices] Modelo Pais obtenido -> ", response);
                        service.pais = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[paisDataServices] error obteniendo el modelo Pais", reason);
                });
        }
    }
})();