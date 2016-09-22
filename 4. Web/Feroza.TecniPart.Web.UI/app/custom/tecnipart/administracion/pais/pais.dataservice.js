(function () {
    "use strict";
    angular.module("tecnipart")
        .service("paisDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Pais";
        var restService = restAngular.service("Pais");

        service.paisListar = [];
        service.pais = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removePais = removePais;
        service.query = query;
        service.getPaisModel = getPaisModel;
        return service;

        function get(id) {
            logger.info("[paisDataServices] informacion", id);
            return service.paisListar.get(id).then(function (data) {
                logger.info("[paisDataServices] informacion recibida desde el servidor ", data);

                service.pais = data;
            }, function (reason) {
                logger.error("[paisDataServices] error obteniendo el modelo de las pais", reason);
            });
        }

        function save(pais) {
            logger.info("[paisDataServices] Guardando", pais);
            return appService.post("api/Pais", pais, "POST")
                .then(function (data) {
                    service.pais = data;
                    service.paisListar.push(data);
                    logger.success("[paisDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadopais", reason);
                });
        }

        function put(pais) {
            logger.info("[paisDataServices] Guardando", pais);
            return pais.put();
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[paisDataServices] datos obtenidos ", data);
                    service.paisListar = data;
                    return data;
                });
        }

        function removePais(pais) {
            logger.info("[paisDataServices] Eliminando -> ", pais);

            return appService.fetch("API/Pais/" + pais.IdPais, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo pais obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[paisDataServices] error obteniendo el modelo pais", reason);
                });

        }

        function getPaisModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Pais/GetPaisModel", { id: param })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo pais obtenido -> ", response);
                        service.pais = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[paisDataServices] error obteniendo el modelo de las pais", reason);
                });
        }
    }
})();