(function () {
    "use strict";
    angular.module("tecnipart")
        .service("fabricantesDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular", "fileReader"];

    function dataservice(appService, logger, restAngular, fileReader) {
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
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadofabricantes", reason);
               });
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[fabricantesDataServices] datos obtenidos ", data);
                    $(data).each(function (idx, fabricante) {
                        fabricante.ImagenFabricanteBase64 = typeof (fabricante.ImagenFabricanteBase64) === "string" ? fabricante.ImagenFabricanteBase64 : "data:image/jpeg;base64," + fabricante.ImagenFabricante;
                    });
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
            var param = typeof (id) === "undefined" ? { id: "" } : { id: id };
            console.log(param);
            return appService.fetch("Fabricantes/GetFabricantesModel", param)
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