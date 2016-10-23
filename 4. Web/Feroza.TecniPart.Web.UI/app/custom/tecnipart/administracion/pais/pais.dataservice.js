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
            return appService.fetch("api/Pais", id, "GET").then(function (response) {
                logger.info("[paisDataServices] informacion recibida desde el servidor ", response);
                service.pais = response;
            }, function (mensajeError) {
                logger.error("[paisDataServices] error obteniendo el modelo de las pais", mensajeError, "", true);
            });
        }

        function save(pais) {
            logger.info("[paisDataServices] Guardando", pais);
            return appService.post("api/Pais", pais)
                .then(function (response) {
                    service.pais = response;
                    service.paisListar.push(response);
                    logger.success("[paisDataServices] Guardo exitosamente", response);
                        return service.pais;
                    },
                function (mensajeError) {
                    logger.error("Error intentanto actualizar el pais", mensajeError);
                });
        }

        function put(pais) {
            logger.info("[paisDataServices] Guardando", pais);
            return appService.put("api/Pais", pais)
                            .then(function (data) {
                                service.pais = data;
                                service.paisListar.push(data);
                                logger.success("[paisDataServices] Guardo exitosamente", data);
                                return service.pais;
                            },
                            function (mensajeError) {
                                logger.error("Error intentanto actualizar el pais", mensajeError);
                            });
        }

        function query() {
            return appService.fetch("api/Pais", null, "GET")
                .then(function (response) {
                    logger.info("[paisDataServices] datos obtenidos ", response);
                    service.paisListar = response;
                    return response;
                },
                    function(mensajeError) {
                        logger.error("Error intentanto actualizar el pais", mensajeError);
                        return mensajeError;
                    });
        }

        function removePais(pais) {
            logger.info("[paisDataServices] Eliminando -> ", pais);

            return appService.delete("API/Pais/", pais)
                .then(function (response) {
                    logger.info("Modelo pais obtenido -> ", response);
                    logger.success("[paisDataServices] Se removio exitosamente", response);
                    service.paisListar = service.paisListar.filter(function (paisFilter) {
                        return paisFilter.IdPais !== pais.IdPais;
                    });
                    return service.paisListar;
                }, function (mensajeError) {
                    logger.error("[paisDataServices] error obteniendo el modelo pais", mensajeError);
                });

        }

        function getPaisModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Pais/GetPaisModel", { id: param })
                .then(function (response) {
                        logger.info("Modelo pais obtenido -> ", response);
                        service.pais = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[paisDataServices] error obteniendo el modelo de las pais", mensajeError);
                });
        }
    }
})();