(function () {
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

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[fabricantesDataServices] informacion", id);
            return appService.fetch(entityName + "/GetFabricantesModel", { id: id })
                .then(function (data) {
                    logger.info("[fabricantesDataServices] informacion recibida desde el servidor ", data);
                    service.fabricantes = data.result;
                }, function (reason) {
                    logger.error("[fabricantesDataServices] error obteniendo el modelo de las fabricantes", reason);
                });
        }

        function save(fabricantes) {
            logger.info("[fabricantesDataServices] Guardando", fabricantes);
            return appService.post("api/Fabricantes", fabricantes)
                .then(function (data) {
                    service.fabricantes = data;
                    service.fabricantesListar.push(data);
                    logger.success("[fabricantesDataServices] Guardo exitosamente", data);
                    return service.fabricantes;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadofabricantes", reason);
                });
        }

        function saveWithImage(fabricantes, images) {
            fabricantes.ImagenFabricanteBase64 = null;
            fabricantes.ImagenFabricante = null;
            logger.info("[fabricantesDataServices] imagen enviada al servidor", images);
            logger.info("[fabricantesDataServices] entidad que se envuelve en el encabezado", fabricantes);
            return appService.postImage("/Api/FabricantesImage", fabricantes, images)
                .then(function (data) {
                    service.fabricantes = data;
                    service.fabricantesListar.push(data);
                    logger.success("[fabricantesDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadofabricantes", reason);
                });
        }

        function putWithImage(fabricantes, images) {
            fabricantes.ImagenFabricanteBase64 = null;
            return appService.putImage("/Api/FabricantesImage", fabricantes, images)
                .then(function (data) {
                    service.fabricantes = data;
                    service.fabricantesListar.push(data);
                    logger.success("[fabricantesDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadofabricantes", reason);
                });
        }

        function put(fabricantes) {
            fabricantes.ImagenFabricanteBase64 = null;
            logger.info("[fabricantesDataServices] Guardando", fabricantes);
            return appService.put("api/Fabricantes", fabricantes)
               .then(function (data) {
                   service.fabricantes = data;
                   service.fabricantesListar.push(data);
                   logger.success("[fabricantesDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadofabricantes", reason);
               });
        }

        function query() {
            return appService.fetch("api/Fabricantes", null, "GET")
                    .then(function (response) {
                        logger.info("[fabricantesDataServices] datos obtenidos ", response);
                        service.fabricantesListar = response;
                        return response;
                    },
                        function (mensajeError) {
                            logger.error("Error intentanto actualizar el fabricantes", mensajeError, "", true);
                        });
        }

        function removeFabricantes(fabricantes) {
            logger.info("[fabricantesDataServices] Eliminando -> ", fabricantes);

            return appService.fetch("API/Fabricantes/", fabricantes, "DELETE")
                .then(function (response) {
                    logger.info("Modelo fabricantes obtenido -> ", response);
                    logger.success("[fabricantesDataServices] Se removio exitosamente", response);
                    service.fabricantesListar = service.fabricantesListar.filter(function (fabricantesFilter) {
                        return fabricantesFilter.IdFabricantes !== fabricantes.IdFabricantes;
                    });
                    return service.fabricantesListar;
                }, function (reason) {
                    logger.error("[fabricantesDataServices] error obteniendo el modelo fabricantes", reason);
                });

        }

        function getFabricantesModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Fabricantes/GetFabricantesModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo fabricantes obtenido -> ", response);
                    service.fabricantes = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[fabricantesDataServices] error obteniendo el modelo de las fabricantes", mensajeError);
                });
        }
    }
})();