(function () {
    "use strict";
    angular.module("tecnipart")
        .service("subSistemasDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "SubSistemas";
        var restService = restAngular.service("SubSistemas");

        service.subSistemasListar = [];
        service.subSistemas = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeSubSistemas = removeSubSistemas;
        service.query = query;
        service.getSistemasModel = getSistemasModel;
        return service;

        function get(id) {
            logger.info("[subSistemasDataServices] informacion", id);
            return appService.fetch(entityName + "/GetSubSistemasModel", { id: id })
               .then(function (data) {
                   logger.info("[subSistemasDataServices] informacion recibida desde el servidor ", data);
                   service.subSistemas = data.result;
               }, function (reason) {
                   logger.error("[subSistemasDataServices] error obteniendo el modelo de las subSistemas", reason);
               });
        }

        function save(subSistemas) {
            logger.info("[subSistemasDataServices] Guardando", subSistemas);
            return appService.post("api/SubSistemas", subSistemas, "POST")
                .then(function (data) {
                    service.subSistemas = data;
                    service.subSistemasListar.push(data);
                    logger.success("[subSistemasDataServices] Guardo exitosamente", data);
                        return service.subSistemas;
                    },
                function (reason) {
                    logger.error("Error intentanto guardar estadosubSistemas", reason);
                    return reason;
                });
        }

        function put(subSistemas) {
            logger.info("[subSistemasDataServices] Guardando", subSistemas);
            return appService.put("api/SubSistemas", subSistemas)
               .then(function (data) {
                   service.subSistemas = data;
                   service.subSistemasListar.push(data);
                   logger.success("[subSistemasDataServices] Guardo exitosamente", data);
               },
               function (reason) {
                   logger.error("Error intentanto guardar subSistemas", reason);
               });
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[subSistemasDataServices] datos obtenidos ", data);
                    service.subSistemasListar = data;
                    return data;
                });
        }

        function removeSubSistemas(subSistemas) {
            logger.info("[subSistemasDataServices] Eliminando -> ", subSistemas);

            return appService.fetch("api/SubSistemas/" + subSistemas.IdSubSistemas, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo subSistemas obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[subSistemasDataServices] error obteniendo el modelo subSistemas", reason);
                });

        }

        function getSistemasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("SubSistemas/GetSubSistemasModel", { id: param })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo subSistemas obtenido -> ", response);
                        service.subSistemas = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[subSistemasDataServices] error obteniendo el modelo de las subSistemas", reason);
                });
        }
    }
})();