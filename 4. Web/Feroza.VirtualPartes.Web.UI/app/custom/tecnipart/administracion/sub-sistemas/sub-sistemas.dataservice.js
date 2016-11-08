(function () {
    "use strict";
    angular.module("tecnipart")
        .service("subSistemasDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "SubSubSistemas";
        var restService = restAngular.service("SubSubSistemas");

        service.subSubSistemasListar = [];
        service.subSubSistemas = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeSubSistemas = removeSubSistemas;
        service.query = query;
        service.getSubSistemasModel = getSubSistemasModel;
        return service;

        function get(id) {
            logger.info("[subSistemasDataServices] informacion", id);
            return appService.fetch("api/SubSistemas", id, "GET").then(function (response) {
                logger.info("[subSistemasDataServices] informacion recibida desde el servidor ", response);
                service.subSistemas = response;
            }, function (mensajeError) {
                logger.error("[subSistemasDataServices] error obteniendo el modelo de las subSistemas", mensajeError, "", true);
            });
        }

        function save(subSistemas) {
            logger.info("[subSistemasDataServices] Guardando", subSistemas);
            return appService.post("api/SubSistemas", subSistemas)
                .then(function (response) {
                    service.subSistemas = response;
                    service.subSistemasListar.push(response);
                    logger.success("[subSistemasDataServices] Guardo exitosamente", response);
                    return service.subSistemas;
                },
                function (mensajeError) {
                    logger.error("Error intentanto actualizar el subSistemas", mensajeError);
                });
        }

        function put(subSistemas) {
            logger.info("[subSistemasDataServices] Guardando", subSistemas);
            return appService.put("api/SubSistemas", subSistemas)
                            .then(function (data) {
                                service.subSistemas = data;
                                service.subSistemasListar.push(data);
                                logger.success("[subSistemasDataServices] Guardo exitosamente", data);
                                return service.subSistemas;
                            },
                            function (mensajeError) {
                                logger.error("Error intentanto actualizar el subSistemas", mensajeError);
                            });
        }

        function query() {
            return appService.fetch("api/SubSistemas", null, "GET")
                .then(function (response) {
                    logger.info("[subSistemasDataServices] datos obtenidos ", response);
                    service.subSistemasListar = response;
                    return response;
                },
                    function (mensajeError) {
                        logger.error("Error intentanto actualizar el subSistemas", mensajeError, "", true);
                        return mensajeError;
                    });
        }

        function removeSubSistemas(subSistemas) {
            logger.info("[subSistemasDataServices] Eliminando -> ", subSistemas);

            return appService.delete("API/SubSistemas/", subSistemas)
                .then(function (response) {
                    logger.info("Modelo subSistemas obtenido -> ", response);
                    logger.success("[subSistemasDataServices] Se removio exitosamente", response);
                    service.subSistemasListar = service.subSistemasListar.filter(function (subSistemasFilter) {
                        return subSistemasFilter.IdSubSistemas !== subSistemas.IdSubSistemas;
                    });
                    return service.subSistemasListar;
                }, function (mensajeError) {
                    logger.error("[subSistemasDataServices] error obteniendo el modelo subSistemas", mensajeError);
                });

        }

        function getSubSistemasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("SubSistemas/GetSubSistemasModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo subSistemas obtenido -> ", response);
                    service.subSistemas = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[subSistemasDataServices] error obteniendo el modelo de las subSistemas", mensajeError);
                });
        }
    }
})();