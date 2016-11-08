(function () {
    "use strict";
    angular.module("tecnipart")
        .service("sistemasDataServices", dataservice);
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

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[sistemasDataServices] informacion", id);
            return appService.fetch(entityName + "/GetSistemasModel", { id: id })
                .then(function (data) {
                    logger.info("[sistemasDataServices] informacion recibida desde el servidor ", data);
                    service.sistemas = data.result;
                }, function (reason) {
                    logger.error("[sistemasDataServices] error obteniendo el modelo de las sistemas", reason);
                });
        }

        function save(sistemas) {
            logger.info("[sistemasDataServices] Guardando", sistemas);
            return appService.post("api/Sistemas", sistemas)
                .then(function (data) {
                    service.sistemas = data;
                    service.sistemasListar.push(data);
                    logger.success("[sistemasDataServices] Guardo exitosamente", data);
                    return service.sistemas;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadosistemas", reason);
                });
        }

        function saveWithImage(sistemas, images) {
            sistemas.ImagenSistemasBase64 = null;
            sistemas.ImagenFabricante = null;
            logger.info("[sistemasDataServices] imagen enviada al servidor", images);
            logger.info("[sistemasDataServices] entidad que se envuelve en el encabezado", sistemas);
            return appService.postImage("/Api/SistemasImage", sistemas, images)
                .then(function (data) {
                    service.sistemas = data;
                    service.sistemasListar.push(data);
                    logger.success("[sistemasDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadosistemas", reason);
                });
        }

        function putWithImage(sistemas, images) {
            sistemas.ImagenSistemasBase64 = null;
            return appService.putImage("/Api/SistemasImage", sistemas, images)
                .then(function (data) {
                    service.sistemas = data;
                    service.sistemasListar.push(data);
                    logger.success("[sistemasDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadosistemas", reason);
                });
        }

        function put(sistemas) {
            sistemas.ImagenSistemasBase64 = null;
            logger.info("[sistemasDataServices] Guardando", sistemas);
            return appService.put("api/Sistemas", sistemas)
               .then(function (data) {
                   service.sistemas = data;
                   service.sistemasListar.push(data);
                   logger.success("[sistemasDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadosistemas", reason);
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
                        });
        }

        function removeSistemas(sistemas) {
            logger.info("[sistemasDataServices] Eliminando -> ", sistemas);

            return appService.fetch("API/Sistemas/", sistemas, "DELETE")
                .then(function (response) {
                    logger.info("Modelo sistemas obtenido -> ", response);
                    logger.success("[sistemasDataServices] Se removio exitosamente", response);
                    service.sistemasListar = service.sistemasListar.filter(function (sistemasFilter) {
                        return sistemasFilter.IdSistemas !== sistemas.IdSistemas;
                    });
                    return service.sistemasListar;
                }, function (reason) {
                    logger.error("[sistemasDataServices] error obteniendo el modelo sistemas", reason);
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