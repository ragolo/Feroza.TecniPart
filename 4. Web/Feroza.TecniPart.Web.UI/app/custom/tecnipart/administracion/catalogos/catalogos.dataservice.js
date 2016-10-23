(function () {
    "use strict";
    angular.module("tecnipart")
        .service("catalogosDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Catalogos";
        var restService = restAngular.service("Catalogos");

        service.catalogosListar = [];
        service.catalogos = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeCatalogos = removeCatalogos;
        service.query = query;
        service.getCatalogosModel = getCatalogosModel;

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[catalogosDataServices] informacion", id);
            return appService.fetch(entityName + "/GetCatalogosModel", { id: id })
                .then(function (data) {
                    logger.info("[catalogosDataServices] informacion recibida desde el servidor ", data);
                    service.catalogos = data.result;
                }, function (reason) {
                    logger.error("[catalogosDataServices] error obteniendo el modelo de las catalogos", reason);
                });
        }

        function save(catalogos) {
            logger.info("[catalogosDataServices] Guardando", catalogos);
            return appService.post("api/Catalogos", catalogos)
                .then(function (data) {
                    service.catalogos = data;
                    service.catalogosListar.push(data);
                    logger.success("[catalogosDataServices] Guardo exitosamente", data);
                    return service.catalogos;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadocatalogos", reason);
                });
        }

        function saveWithImage(catalogos, images) {
            catalogos.ImagenFabricanteBase64 = null;
            catalogos.ImagenFabricante = null;
            logger.info("[catalogosDataServices] imagen enviada al servidor", images);
            logger.info("[catalogosDataServices] entidad que se envuelve en el encabezado", catalogos);
            return appService.postImage("/Api/CatalogosImage", catalogos, images)
                .then(function (data) {
                    service.catalogos = data;
                    service.catalogosListar.push(data);
                    logger.success("[catalogosDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadocatalogos", reason);
                });
        }

        function putWithImage(catalogos, images) {
            catalogos.ImagenFabricanteBase64 = null;
            return appService.putImage("/Api/CatalogosImage", catalogos, images)
                .then(function (data) {
                    service.catalogos = data;
                    service.catalogosListar.push(data);
                    logger.success("[catalogosDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadocatalogos", reason);
                });
        }

        function put(catalogos) {
            catalogos.ImagenFabricanteBase64 = null;
            logger.info("[catalogosDataServices] Guardando", catalogos);
            return appService.put("api/Catalogos", catalogos)
               .then(function (data) {
                   service.catalogos = data;
                   service.catalogosListar.push(data);
                   logger.success("[catalogosDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadocatalogos", reason);
               });
        }

        function query() {
            return appService.fetch("api/Catalogos", null, "GET")
                    .then(function (response) {
                        logger.info("[catalogosDataServices] datos obtenidos ", response);
                        service.catalogosListar = response;
                        return response;
                    },
                        function (mensajeError) {
                            logger.error("Error intentanto actualizar el catalogos", mensajeError, "", true);
                        });
        }

        function removeCatalogos(catalogos) {
            logger.info("[catalogosDataServices] Eliminando -> ", catalogos);

            return appService.fetch("API/Catalogos/", catalogos, "DELETE")
                .then(function (response) {
                    logger.info("Modelo catalogos obtenido -> ", response);
                    logger.success("[catalogosDataServices] Se removio exitosamente", response);
                    service.catalogosListar = service.catalogosListar.filter(function (catalogosFilter) {
                        return catalogosFilter.IdCatalogos !== catalogos.IdCatalogos;
                    });
                    return service.catalogosListar;
                }, function (reason) {
                    logger.error("[catalogosDataServices] error obteniendo el modelo catalogos", reason);
                });

        }

        function getCatalogosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Catalogos/GetCatalogosModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo catalogos obtenido -> ", response);
                    service.catalogos = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[catalogosDataServices] error obteniendo el modelo de las catalogos", mensajeError);
                });
        }
    }
})();