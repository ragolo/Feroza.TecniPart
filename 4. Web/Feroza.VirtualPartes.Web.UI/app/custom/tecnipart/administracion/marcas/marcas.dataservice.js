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
            return appService.fetch(entityName + "/GetMarcasModel", { id: id })
                .then(function (data) {
                    logger.info("[marcasDataServices] informacion recibida desde el servidor ", data);
                    service.marcas = data.result;
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
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadomarcas", reason);
                });
        }

        function put(marcas) {
            marcas.ImagenFabricanteBase64 = null;
            logger.info("[marcasDataServices] Guardando", marcas);
            return appService.put("api/Marcas", marcas)
               .then(function (data) {
                   service.marcas = data;
                   service.marcasListar.push(data);
                   logger.success("[marcasDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadomarcas", reason);
               });
        }

        function query() {
            return appService.fetch("api/Marcas", null, "GET")
                   .then(function (response) {
                       logger.info("[marcasDataServices] datos obtenidos ", response);
                       service.marcasListar = response;
                       return response;
                   },
                       function (mensajeError) {
                           logger.error("Error intentanto actualizar el marcas", mensajeError, "", true);
                       });
        }

        function removeMarcas(marcas) {
            logger.info("[marcasDataServices] Eliminando -> ", marcas);

            return appService.fetch("API/Marcas/", marcas, "DELETE")
                .then(function (response) {
                    logger.info("Modelo marcas obtenido -> ", response);
                    service.marcasListar = service.marcasListar.filter(function (marcasFilter) {
                        return marcasFilter.IdMarcas !== marcas.IdMarcas;
                    });
                    return service.marcasListar;
                }, function (reason) {
                    logger.error("[marcasDataServices] error obteniendo el modelo marcas", reason);
                });

        }

        function getMarcasModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Marcas/GetMarcasModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo marcas obtenido -> ", response);
                    service.marcas = response;
                    return response;
                }, function (reason) {
                    logger.error("[marcasDataServices] error obteniendo el modelo de las marcas", reason);
                });
        }
    }
})();