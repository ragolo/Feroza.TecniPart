(function () {
    "use strict";
    angular.module("tecnipart")
        .service("marcasTiposProductosDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "MarcasTiposProductos";
        var restService = restAngular.service("MarcasTiposProductos");

        service.marcasTiposProductosListar = [];
        service.marcasTiposProductos = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeMarcasTiposProductos = removeMarcasTiposProductos;
        service.query = query;
        service.getMarcasTiposProductosModel = getMarcasTiposProductosModel;

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[marcasTiposProductosDataServices] informacion", id);
            return appService.fetch(entityName + "/GetMarcasTiposProductosModel", { id: id })
                .then(function (data) {
                    logger.info("[marcasTiposProductosDataServices] informacion recibida desde el servidor ", data);
                    service.marcasTiposProductos = data.result;
                }, function (reason) {
                    logger.error("[marcasTiposProductosDataServices] error obteniendo el modelo de las marcasTiposProductos", reason);
                });
        }

        function save(marcasTiposProductos) {
            logger.info("[marcasTiposProductosDataServices] Guardando", marcasTiposProductos);
            return appService.post("api/MarcasTiposProductos", marcasTiposProductos)
                .then(function (data) {
                    service.marcasTiposProductos = data;
                    service.marcasTiposProductosListar.push(data);
                    logger.success("[marcasTiposProductosDataServices] Guardo exitosamente", data);
                    return service.marcasTiposProductos;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadomarcasTiposProductos", reason);
                });
        }

        function saveWithImage(marcasTiposProductos, images) {
            marcasTiposProductos.ImagenMarcasTiposProductosBase64 = null;
            marcasTiposProductos.ImagenFabricante = null;
            logger.info("[marcasTiposProductosDataServices] imagen enviada al servidor", images);
            logger.info("[marcasTiposProductosDataServices] entidad que se envuelve en el encabezado", marcasTiposProductos);
            return appService.postImage("/Api/MarcasTiposProductosImage", marcasTiposProductos, images)
                .then(function (data) {
                    service.marcasTiposProductos = data;
                    service.marcasTiposProductosListar.push(data);
                    logger.success("[marcasTiposProductosDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadomarcasTiposProductos", reason);
                });
        }

        function putWithImage(marcasTiposProductos, images) {
            marcasTiposProductos.ImagenMarcasTiposProductosBase64 = null;
            return appService.putImage("/Api/MarcasTiposProductosImage", marcasTiposProductos, images)
                .then(function (data) {
                    service.marcasTiposProductos = data;
                    service.marcasTiposProductosListar.push(data);
                    logger.success("[marcasTiposProductosDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadomarcasTiposProductos", reason);
                });
        }

        function put(marcasTiposProductos) {
            marcasTiposProductos.ImagenMarcasTiposProductosBase64 = null;
            logger.info("[marcasTiposProductosDataServices] Guardando", marcasTiposProductos);
            return appService.put("api/MarcasTiposProductos", marcasTiposProductos)
               .then(function (data) {
                   service.marcasTiposProductos = data;
                   service.marcasTiposProductosListar.push(data);
                   logger.success("[marcasTiposProductosDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadomarcasTiposProductos", reason);
               });
        }

        function query() {
            return appService.fetch("api/MarcasTiposProductos", null, "GET")
                    .then(function (response) {
                        logger.info("[marcasTiposProductosDataServices] datos obtenidos ", response);
                        service.marcasTiposProductosListar = response;
                        return response;
                    },
                        function (mensajeError) {
                            logger.error("Error intentanto actualizar el marcasTiposProductos", mensajeError, "", true);
                        });
        }

        function removeMarcasTiposProductos(marcasTiposProductos) {
            logger.info("[marcasTiposProductosDataServices] Eliminando -> ", marcasTiposProductos);

            return appService.fetch("API/MarcasTiposProductos/", marcasTiposProductos, "DELETE")
                .then(function (response) {
                    logger.info("Modelo marcasTiposProductos obtenido -> ", response);
                    logger.success("[marcasTiposProductosDataServices] Se removio exitosamente", response);
                    service.marcasTiposProductosListar = service.marcasTiposProductosListar.filter(function (marcasTiposProductosFilter) {
                        return marcasTiposProductosFilter.IdMarcasTiposProductos !== marcasTiposProductos.IdMarcasTiposProductos;
                    });
                    return service.marcasTiposProductosListar;
                }, function (reason) {
                    logger.error("[marcasTiposProductosDataServices] error obteniendo el modelo marcasTiposProductos", reason);
                });

        }

        function getMarcasTiposProductosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("MarcasTiposProductos/GetMarcasTiposProductosModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo marcasTiposProductos obtenido -> ", response);
                    service.marcasTiposProductos = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[marcasTiposProductosDataServices] error obteniendo el modelo de las marcasTiposProductos", mensajeError);
                });
        }
    }
})();