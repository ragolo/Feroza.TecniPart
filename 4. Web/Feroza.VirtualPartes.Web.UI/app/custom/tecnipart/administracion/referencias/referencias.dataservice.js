(function () {
    "use strict";
    angular.module("tecnipart")
        .service("referenciasDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Referencias";
        var restService = restAngular.service("Referencias");

        service.referenciasListar = [];
        service.referencias = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeReferencias = removeReferencias;
        service.query = query;
        service.getReferenciasModel = getReferenciasModel;
        return service;

        function get(id) {
            logger.info("[referenciasDataServices] informacion", id);
            return appService.fetch("api/Referencias", id, "GET").then(function (response) {
                logger.info("[referenciasDataServices] informacion recibida desde el servidor ", response);
                service.referencias = response;
            }, function (mensajeError) {
                logger.error("[referenciasDataServices] error obteniendo el modelo de las referencias", mensajeError, "", true);
            });
        }

        function save(referencias) {
            logger.info("[referenciasDataServices] Guardando", referencias);
            return appService.post("api/Referencias", referencias)
                .then(function (response) {
                    service.referencias = response;
                    service.referenciasListar.push(response);
                    logger.success("[referenciasDataServices] Guardo exitosamente", response);
                        return service.referencias;
                    },
                function (mensajeError) {
                    logger.error("Error intentanto actualizar el referencias", mensajeError);
                });
        }

        function put(referencias) {
            logger.info("[referenciasDataServices] Guardando", referencias);
            return appService.put("api/Referencias", referencias)
                            .then(function (data) {
                                service.referencias = data;
                                service.referenciasListar.push(data);
                                logger.success("[referenciasDataServices] Guardo exitosamente", data);
                                return service.referencias;
                            },
                            function (mensajeError) {
                                logger.error("Error intentanto actualizar el referencias", mensajeError);
                            });
        }

        function query() {
            return appService.fetch("api/Referencias", null, "GET")
                .then(function (response) {
                    logger.info("[referenciasDataServices] datos obtenidos ", response);
                    service.referenciasListar = response;
                    return response;
                },
                    function(mensajeError) {
                        logger.error("Error intentanto actualizar el referencias", mensajeError);
                        return mensajeError;
                    });
        }

        function removeReferencias(referencias) {
            logger.info("[referenciasDataServices] Eliminando -> ", referencias);

            return appService.delete("API/Referencias/", referencias)
                .then(function (response) {
                    logger.info("Modelo referencias obtenido -> ", response);
                    logger.success("[referenciasDataServices] Se removio exitosamente", response);
                    service.referenciasListar = service.referenciasListar.filter(function (referenciasFilter) {
                        return referenciasFilter.IdReferencias !== referencias.IdReferencias;
                    });
                    return service.referenciasListar;
                }, function (mensajeError) {
                    logger.error("[referenciasDataServices] error obteniendo el modelo referencias", mensajeError);
                });

        }

        function getReferenciasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Referencias/GetReferenciasModel", { id: param })
                .then(function (response) {
                        logger.info("Modelo referencias obtenido -> ", response);
                        service.referencias = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[referenciasDataServices] error obteniendo el modelo de las referencias", mensajeError);
                });
        }
    }
})();