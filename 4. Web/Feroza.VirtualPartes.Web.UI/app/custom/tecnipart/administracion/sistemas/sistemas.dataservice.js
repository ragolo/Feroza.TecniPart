(function () {
    "use strict";
    angular.module("tecnipart")
        .service("qsistemasDataServices", dataservice);
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
            return appService.fetch("api/Sistemas", id, "GET").then(function (response) {
                logger.info("[sistemasDataServices] informacion recibida desde el servidor ", response);
                service.sistemas = response;
            }, function (mensajeError) {
                logger.error("[sistemasDataServices] error obteniendo el modelo de las sistemas", mensajeError, "", true);
            });
        }

        function save(sistemas) {
            logger.info("[sistemasDataServices] Guardando", sistemas);
            return appService.post("api/Sistemas", sistemas)
                .then(function (response) {
                    service.sistemas = response;
                    service.sistemasListar.push(response);
                    logger.success("[sistemasDataServices] Guardo exitosamente", response);
                    return service.sistemas;
                },
                function (mensajeError) {
                    logger.error("Error intentanto actualizar el sistemas", mensajeError);
                });
        }

        function put(sistemas) {
            logger.info("[sistemasDataServices] Guardando", sistemas);
            return appService.put("api/Sistemas", sistemas)
                            .then(function (data) {
                                service.sistemas = data;
                                service.sistemasListar.push(data);
                                logger.success("[sistemasDataServices] Guardo exitosamente", data);
                                return service.sistemas;
                            },
                            function (mensajeError) {
                                logger.error("Error intentanto actualizar el sistemas", mensajeError);
                            });
        }

        function query() {
            return appService.fetch("api/Sistemas", null, "GET")
                .then(function (response) {
                    logger.info("[sistemasDataServices] datos obtenidos ", response);
                    service.sistemasListar = response;
                    return response;
                },
                    function (mensajeError) {
                        logger.error("Error intentanto actualizar el sistemas", mensajeError, "", true);
                        return mensajeError;
                    });
        }

        function removeSistemas(sistemas) {
            logger.info("[sistemasDataServices] Eliminando -> ", sistemas);

            return appService.delete("API/Sistemas/", sistemas)
                .then(function (response) {
                    logger.info("Modelo sistemas obtenido -> ", response);
                    logger.success("[sistemasDataServices] Se removio exitosamente", response);
                    service.sistemasListar = service.sistemasListar.filter(function (sistemasFilter) {
                        return sistemasFilter.IdSistemas !== sistemas.IdSistemas;
                    });
                    return service.sistemasListar;
                }, function (mensajeError) {
                    logger.error("[sistemasDataServices] error obteniendo el modelo sistemas", mensajeError);
                });

        }

        function getSistemasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Sistemas/GetSistemasModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo sistemas obtenido -> ", response);
                    service.sistemas = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[sistemasDataServices] error obteniendo el modelo de las sistemas", mensajeError);
                });
        }
    }
})();