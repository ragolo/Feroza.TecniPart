﻿(function () {
    "use strict";
    angular.module("tecnipart")
        .service("fabricantesDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Fabricantes";
        var restService = restAngular.service("Fabricantes");

        service.fabricantesListar = [];
        service.fabricantes = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeFabricantes = removeFabricantes;
        service.query = query;
        service.getFabricantesModel = getFabricantesModel;
        return service;

        function get(id) {
            logger.info("[fabricantesDataServices] informacion", id);
            return service.fabricantesListar.get(id).then(function (data) {
                logger.info("[fabricantesDataServices] informacion recibida desde el servidor ", data);

                service.fabricantes = data;
            }, function (reason) {
                logger.error("[fabricantesDataServices] error obteniendo el modelo de las fabricantes", reason);
            });
        }

        function save(fabricantes) {
            logger.info("[fabricantesDataServices] Guardando", fabricantes);
            return appService.post("api/Fabricantes", fabricantes, "POST")
                .then(function (data) {
                    service.fabricantes = data;
                    service.fabricantesListar.push(data);
                    logger.success("[fabricantesDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadofabricantes", reason);
                });
        }

        function put(fabricantes) {
            logger.info("[fabricantesDataServices] Guardando", fabricantes);
            return fabricantes.put();
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[fabricantesDataServices] datos obtenidos ", data);
                    service.fabricantesListar = data;
                    return data;
                });
        }

        function removeFabricantes(fabricantes) {
            logger.info("[fabricantesDataServices] Eliminando -> ", fabricantes);

            return appService.fetch("API/Fabricantes/" + fabricantes.IdFabricantes, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo fabricantes obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[fabricantesDataServices] error obteniendo el modelo fabricantes", reason);
                });

        }

        function getFabricantesModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Fabricantes/GetFabricantesModel", { id: param })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo fabricantes obtenido -> ", response);
                        service.fabricantes = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[fabricantesDataServices] error obteniendo el modelo de las fabricantes", reason);
                });
        }
    }
})();