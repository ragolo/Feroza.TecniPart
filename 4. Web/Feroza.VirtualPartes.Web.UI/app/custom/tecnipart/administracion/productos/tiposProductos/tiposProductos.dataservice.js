(function () {
    "use strict";
    angular.module("tecnipart")
        .service("tiposProductosDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "TiposProductos";
        var restService = restAngular.service("TiposProductos");

        service.tiposProductosListar = [];
        service.tiposProductos = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeTiposProductos = removeTiposProductos;
        service.query = query;
        service.getTiposProductosModel = getTiposProductosModel;

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[tiposProductosDataServices] informacion", id);
            return appService.fetch(entityName + "/GetTiposProductosModel", { id: id })
                .then(function (data) {
                    logger.info("[tiposProductosDataServices] informacion recibida desde el servidor ", data);
                    service.tiposProductos = data.result;
                }, function (reason) {
                    logger.error("[tiposProductosDataServices] error obteniendo el modelo de las tiposProductos", reason);
                });
        }

        function save(tiposProductos) {
            logger.info("[tiposProductosDataServices] Guardando", tiposProductos);
            return appService.post("api/TiposProductos", tiposProductos)
                .then(function (data) {
                    service.tiposProductos = data;
                    service.tiposProductosListar.push(data);
                    logger.success("[tiposProductosDataServices] Guardo exitosamente", data);
                    return service.tiposProductos;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadotiposProductos", reason);
                });
        }

        function saveWithImage(tiposProductos, images) {
            tiposProductos.ImagenTiposProductosBase64 = null;
            tiposProductos.ImagenFabricante = null;
            logger.info("[tiposProductosDataServices] imagen enviada al servidor", images);
            logger.info("[tiposProductosDataServices] entidad que se envuelve en el encabezado", tiposProductos);
            return appService.postImage("/Api/TiposProductosImage", tiposProductos, images)
                .then(function (data) {
                    service.tiposProductos = data;
                    service.tiposProductosListar.push(data);
                    logger.success("[tiposProductosDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadotiposProductos", reason);
                });
        }

        function putWithImage(tiposProductos, images) {
            tiposProductos.ImagenTiposProductosBase64 = null;
            return appService.putImage("/Api/TiposProductosImage", tiposProductos, images)
                .then(function (data) {
                    service.tiposProductos = data;
                    service.tiposProductosListar.push(data);
                    logger.success("[tiposProductosDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadotiposProductos", reason);
                });
        }

        function put(tiposProductos) {
            tiposProductos.ImagenTiposProductosBase64 = null;
            logger.info("[tiposProductosDataServices] Guardando", tiposProductos);
            return appService.put("api/TiposProductos", tiposProductos)
               .then(function (data) {
                   service.tiposProductos = data;
                   service.tiposProductosListar.push(data);
                   logger.success("[tiposProductosDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadotiposProductos", reason);
               });
        }

        function query() {
            return appService.fetch("api/TiposProductos", null, "GET")
                    .then(function (response) {
                        logger.info("[tiposProductosDataServices] datos obtenidos ", response);
                        service.tiposProductosListar = response;
                        return response;
                    },
                        function (mensajeError) {
                            logger.error("Error intentanto actualizar el tiposProductos", mensajeError, "", true);
                        });
        }

        function removeTiposProductos(tiposProductos) {
            logger.info("[tiposProductosDataServices] Eliminando -> ", tiposProductos);

            return appService.fetch("API/TiposProductos/", tiposProductos, "DELETE")
                .then(function (response) {
                    logger.info("Modelo tiposProductos obtenido -> ", response);
                    logger.success("[tiposProductosDataServices] Se removio exitosamente", response);
                    service.tiposProductosListar = service.tiposProductosListar.filter(function (tiposProductosFilter) {
                        return tiposProductosFilter.IdTiposProductos !== tiposProductos.IdTiposProductos;
                    });
                    return service.tiposProductosListar;
                }, function (reason) {
                    logger.error("[tiposProductosDataServices] error obteniendo el modelo tiposProductos", reason);
                });

        }

        function getTiposProductosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("TiposProductos/GetTiposProductosModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo tiposProductos obtenido -> ", response);
                    service.tiposProductos = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[tiposProductosDataServices] error obteniendo el modelo de las tiposProductos", mensajeError);
                });
        }
    }
})();