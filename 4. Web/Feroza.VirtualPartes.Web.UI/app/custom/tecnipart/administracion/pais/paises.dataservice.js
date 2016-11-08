(function () {
    "use strict";
    angular.module("tecnipart")
        .service("paisesDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Pais";
        var restService = restAngular.service("Pais");

        service.paisesListar = [];
        service.paises = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removePais = removePais;
        service.query = query;
        service.getPaisModel = getPaisModel;
        return service;

        function get(id) {
            logger.info("[paisesDataServices] informacion", id);
            return appService.fetch("api/Paises", id, "GET").then(function (response) {
                logger.info("[paisesDataServices] informacion recibida desde el servidor ", response);
                service.paises = response;
            }, function (mensajeError) {
                logger.error("[paisesDataServices] error obteniendo el modelo de las paises", mensajeError, "", true);
            });
        }

        function save(paises) {
            logger.info("[paisesDataServices] Guardando", paises);
            return appService.post("api/Paises", paises)
                .then(function (response) {
                    service.paises = response;
                    service.paisesListar.push(response);
                    logger.success("[paisesDataServices] Guardo exitosamente", response);
                        return service.paises;
                    },
                function (mensajeError) {
                    logger.error("Error intentanto actualizar el paises", mensajeError);
                });
        }

        function put(paises) {
            logger.info("[paisesDataServices] Guardando", paises);
            return appService.put("api/Paises", paises)
                            .then(function (data) {
                                service.paises = data;
                                service.paisesListar.push(data);
                                logger.success("[paisesDataServices] Guardo exitosamente", data);
                                return service.paises;
                            },
                            function (mensajeError) {
                                logger.error("Error intentanto actualizar el paises", mensajeError);
                            });
        }

        function query() {
            return appService.fetch("api/Paises", null, "GET")
                .then(function (response) {
                    logger.info("[paisesDataServices] datos obtenidos ", response);
                    service.paisesListar = response;
                    return response;
                },
                    function(mensajeError) {
                        logger.error("Error intentanto actualizar el paises", mensajeError);
                        return mensajeError;
                    });
        }

        function removePais(paises) {
            logger.info("[paisesDataServices] Eliminando -> ", paises);

            return appService.delete("API/Paises/", paises)
                .then(function (response) {
                    logger.info("Modelo paises obtenido -> ", response);
                    logger.success("[paisesDataServices] Se removio exitosamente", response);
                    service.paisesListar = service.paisesListar.filter(function (paisesFilter) {
                        return paisesFilter.IdPaises !== paises.IdPaises;
                    });
                    return service.paisesListar;
                }, function (mensajeError) {
                    logger.error("[paisesDataServices] error obteniendo el modelo paises", mensajeError);
                });

        }

        function getPaisModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Paises/GetPaisesModel", { id: param })
                .then(function (response) {
                        logger.info("Modelo paises obtenido -> ", response);
                        service.paises = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[paisesDataServices] error obteniendo el modelo de las paises", mensajeError);
                });
        }
    }
})();