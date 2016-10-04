(function () {
    "use strict";
    angular.module("tecnipart")
        .service("sistemasDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Sistemas";
        var restService = restAngular.service("Sistemas");

        service.sistemasListar = [];
        service.sistemas = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeSistemas = removeSistemas;
        service.query = query;
        service.getSistemasModel = getSistemasModel;
        return service;

        function get(id) {
            logger.info("[sistemasDataServices] informacion", id);
            return service.sistemasListar.get(id).then(function (data) {
                logger.info("[sistemasDataServices] informacion recibida desde el servidor ", data);

                service.sistemas = data;
            }, function (reason) {
                logger.error("[sistemasDataServices] error obteniendo el modelo de las sistemas", reason);
            });
        }

        function save(sistemas) {
            logger.info("[sistemasDataServices] Guardando", sistemas);
            return appService.post("api/Sistemas", sistemas, "POST")
                .then(function (data) {
                    service.sistemas = data;
                    service.sistemasListar.push(data);
                    logger.success("[sistemasDataServices] Guardo exitosamente", data);
                        return service.sistemas;
                    },
                function (reason) {
                    logger.error("Error intentanto guardar estadosistemas", reason);
                    return reason;
                });
        }

        function put(sistemas) {
            logger.info("[sistemasDataServices] Guardando", sistemas);
            return sistemas.put();
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[sistemasDataServices] datos obtenidos ", data);
                    service.sistemasListar = data;
                    return data;
                });
        }

        function removeSistemas(sistemas) {
            logger.info("[sistemasDataServices] Eliminando -> ", sistemas);

            return appService.fetch("API/Sistemas/" + sistemas.IdSistemas, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo sistemas obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[sistemasDataServices] error obteniendo el modelo sistemas", reason);
                });

        }

        function getSistemasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Sistemas/GetSistemasModel", { id: param })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo sistemas obtenido -> ", response);
                        service.sistemas = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[sistemasDataServices] error obteniendo el modelo de las sistemas", reason);
                });
        }
    }
})();