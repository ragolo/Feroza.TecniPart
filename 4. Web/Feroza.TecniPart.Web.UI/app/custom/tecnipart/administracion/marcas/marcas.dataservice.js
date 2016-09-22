(function () {
    "use strict";
    angular.module("tecnipart")
        .service("marcasDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Marcas";
        var restService = restAngular.service("Marcas");

        service.marcasListar = [];
        service.marcas = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeMarcas = removeMarcas;
        service.query = query;
        service.getMarcasModel = getMarcasModel;
        return service;

        function get(id) {
            logger.info("[marcasDataServices] informacion", id);
            return service.marcasListar.get(id).then(function (data) {
                logger.info("[marcasDataServices] informacion recibida desde el servidor ", data);

                service.marcas = data;
            }, function (reason) {
                logger.error("[marcasDataServices] error obteniendo el modelo de las marcas", reason);
            });
        }

        function save(marcas) {
            logger.info("[marcasDataServices] Guardando", marcas);
            return appService.post("api/Marcas", marcas, "POST")
                .then(function (data) {
                    service.marcas = data;
                    service.marcasListar.push(data);
                    logger.success("[marcasDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadomarcas", reason);
                });
        }

        function put(marcas) {
            logger.info("[marcasDataServices] Guardando", marcas);
            return marcas.put();
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[marcasDataServices] datos obtenidos ", data);
                    service.marcasListar = data;
                    return data;
                });
        }

        function removeMarcas(marcas) {
            logger.info("[marcasDataServices] Eliminando -> ", marcas);

            return appService.fetch("API/Marcas/" + marcas.IdMarcas, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo marcas obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[marcasDataServices] error obteniendo el modelo marcas", reason);
                });

        }

        function getMarcasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Marcas/GetMarcasModel", { id: param })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo marcas obtenido -> ", response);
                        service.marcas = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[marcasDataServices] error obteniendo el modelo de las marcas", reason);
                });
        }
    }
})();