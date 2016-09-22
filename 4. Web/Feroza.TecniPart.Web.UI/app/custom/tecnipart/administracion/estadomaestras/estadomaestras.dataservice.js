(function () {
    "use strict";
    angular.module("tecnipart")
        .service("estadomaestasDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "EstadoMaestras";
        var restService = restAngular.service("EstadoMaestras");

        service.estadoMaestrasListar = [];
        service.estadoMaestras = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeEstadoMaestras = removeEstadoMaestras;
        service.query = query;
        service.getEstadoMaestrasModel = getEstadoMaestrasModel;
        return service;

        function get(id) {
            return service.estadoMaestrasListar.get(id).then(function (data) {
                service.estadoMaestras = data;
            }, function (reason) {
                logger.error("[estadomaestasDataServices] error obteniendo el modelo de las maestras", reason);
            });
        }

        function save(estadoMaestra) {
            logger.info("[estadomaestasDataServices] Guardando", estadoMaestra);
            return appService.post("api/EstadoMaestras", estadoMaestra, "POST")
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
            return estadoMaestra.put();
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[estadomaestasDataServices] datos obtenidos ", data);
                    service.estadoMaestrasListar = data;
                    return data;
                });
        }

        function removeEstadoMaestras(estadoMaestras) {
            logger.info("[estadomaestasDataServices] Eliminando -> ", estadoMaestras);

            return appService.fetch("API/EstadoMaestras/" + estadoMaestras.IdEstadoMaestras, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo estado maestras obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[estadomaestasDataServices] error obteniendo el modelo de las maestras", reason);
                });

        }

        function getEstadoMaestrasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("EstadoMaestras/GetEstadoMaestrasModel", { id: param })
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