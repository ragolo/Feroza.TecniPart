(function () {
    "use strict";
    angular.module("tecnipart")
        .service("lineasProductosDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "LineasProductos";
        var restService = restAngular.service("LineasProductos");

        service.lineasProductosListar = [];
        service.lineasProductos = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeLineasProductos = removeLineasProductos;
        service.query = query;
        service.getLineasProductosModel = getLineasProductosModel;

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[lineasProductosDataServices] informacion", id);
            return appService.fetch(entityName + "/GetLineasProductosModel", { id: id })
                .then(function (data) {
                    logger.info("[lineasProductosDataServices] informacion recibida desde el servidor ", data);
                    service.lineasProductos = data.result;
                }, function (reason) {
                    logger.error("[lineasProductosDataServices] error obteniendo el modelo de las lineasProductos", reason);
                });
        }

        function save(lineasProductos) {
            logger.info("[lineasProductosDataServices] Guardando", lineasProductos);
            return appService.post("api/LineasProductos", lineasProductos)
                .then(function (data) {
                    service.lineasProductos = data;
                    service.lineasProductosListar.push(data);
                    logger.success("[lineasProductosDataServices] Guardo exitosamente", data);
                    return service.lineasProductos;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadolineasProductos", reason);
                });
        }

        function saveWithImage(lineasProductos, images) {
            lineasProductos.ImagenLineasProductosBase64 = null;
            lineasProductos.ImagenFabricante = null;
            logger.info("[lineasProductosDataServices] imagen enviada al servidor", images);
            logger.info("[lineasProductosDataServices] entidad que se envuelve en el encabezado", lineasProductos);
            return appService.postImage("/Api/LineasProductosImage", lineasProductos, images)
                .then(function (data) {
                    service.lineasProductos = data;
                    service.lineasProductosListar.push(data);
                    logger.success("[lineasProductosDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadolineasProductos", reason);
                });
        }

        function putWithImage(lineasProductos, images) {
            lineasProductos.ImagenLineasProductosBase64 = null;
            return appService.putImage("/Api/LineasProductosImage", lineasProductos, images)
                .then(function (data) {
                    service.lineasProductos = data;
                    service.lineasProductosListar.push(data);
                    logger.success("[lineasProductosDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadolineasProductos", reason);
                });
        }

        function put(lineasProductos) {
            lineasProductos.ImagenLineasProductosBase64 = null;
            logger.info("[lineasProductosDataServices] Guardando", lineasProductos);
            return appService.put("api/LineasProductos", lineasProductos)
               .then(function (data) {
                   service.lineasProductos = data;
                   service.lineasProductosListar.push(data);
                   logger.success("[lineasProductosDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadolineasProductos", reason);
               });
        }

        function query() {
            return appService.fetch("api/LineasProductos", null, "GET")
                    .then(function (response) {
                        logger.info("[lineasProductosDataServices] datos obtenidos ", response);
                        service.lineasProductosListar = response;
                        return response;
                    },
                        function (mensajeError) {
                            logger.error("Error intentanto actualizar el lineasProductos", mensajeError, "", true);
                        });
        }

        function removeLineasProductos(lineasProductos) {
            logger.info("[lineasProductosDataServices] Eliminando -> ", lineasProductos);

            return appService.fetch("API/LineasProductos/", lineasProductos, "DELETE")
                .then(function (response) {
                    logger.info("Modelo lineasProductos obtenido -> ", response);
                    logger.success("[lineasProductosDataServices] Se removio exitosamente", response);
                    service.lineasProductosListar = service.lineasProductosListar.filter(function (lineasProductosFilter) {
                        return lineasProductosFilter.IdLineasProductos !== lineasProductos.IdLineasProductos;
                    });
                    return service.lineasProductosListar;
                }, function (reason) {
                    logger.error("[lineasProductosDataServices] error obteniendo el modelo lineasProductos", reason);
                });

        }

        function getLineasProductosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("LineasProductos/GetLineasProductosModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo lineasProductos obtenido -> ", response);
                    service.lineasProductos = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[lineasProductosDataServices] error obteniendo el modelo de las lineasProductos", mensajeError);
                });
        }
    }
})();