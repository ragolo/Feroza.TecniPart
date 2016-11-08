(function () {
    "use strict";
    angular.module("tecnipart")
        .service("productosDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Productos";
        var restService = restAngular.service("Productos");

        service.productosListar = [];
        service.productos = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeProductos = removeProductos;
        service.query = query;
        service.getProductosModel = getProductosModel;

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[productosDataServices] informacion", id);
            return appService.fetch(entityName + "/GetProductosModel", { id: id })
                .then(function (data) {
                    logger.info("[productosDataServices] informacion recibida desde el servidor ", data);
                    service.productos = data.result;
                }, function (reason) {
                    logger.error("[productosDataServices] error obteniendo el modelo de las productos", reason);
                });
        }

        function save(productos) {
            logger.info("[productosDataServices] Guardando", productos);
            return appService.post("api/Productos", productos)
                .then(function (data) {
                    service.productos = data;
                    service.productosListar.push(data);
                    logger.success("[productosDataServices] Guardo exitosamente", data);
                    return service.productos;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadoproductos", reason);
                });
        }

        function saveWithImage(productos, images) {
            productos.ImagenProductosBase64 = null;
            productos.ImagenFabricante = null;
            logger.info("[productosDataServices] imagen enviada al servidor", images);
            logger.info("[productosDataServices] entidad que se envuelve en el encabezado", productos);
            return appService.postImage("/Api/ProductosImage", productos, images)
                .then(function (data) {
                    service.productos = data;
                    service.productosListar.push(data);
                    logger.success("[productosDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadoproductos", reason);
                });
        }

        function putWithImage(productos, images) {
            productos.ImagenProductosBase64 = null;
            return appService.putImage("/Api/ProductosImage", productos, images)
                .then(function (data) {
                    service.productos = data;
                    service.productosListar.push(data);
                    logger.success("[productosDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadoproductos", reason);
                });
        }

        function put(productos) {
            productos.ImagenProductosBase64 = null;
            logger.info("[productosDataServices] Guardando", productos);
            return appService.put("api/Productos", productos)
               .then(function (data) {
                   service.productos = data;
                   service.productosListar.push(data);
                   logger.success("[productosDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadoproductos", reason);
               });
        }

        function query() {
            return appService.fetch("api/Productos", null, "GET")
                    .then(function (response) {
                        logger.info("[productosDataServices] datos obtenidos ", response);
                        service.productosListar = response;
                        return response;
                    },
                        function (mensajeError) {
                            logger.error("Error intentanto actualizar el productos", mensajeError, "", true);
                        });
        }

        function removeProductos(productos) {
            logger.info("[productosDataServices] Eliminando -> ", productos);

            return appService.fetch("API/Productos/", productos, "DELETE")
                .then(function (response) {
                    logger.info("Modelo productos obtenido -> ", response);
                    logger.success("[productosDataServices] Se removio exitosamente", response);
                    service.productosListar = service.productosListar.filter(function (productosFilter) {
                        return productosFilter.IdProductos !== productos.IdProductos;
                    });
                    return service.productosListar;
                }, function (reason) {
                    logger.error("[productosDataServices] error obteniendo el modelo productos", reason);
                });

        }

        function getProductosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Productos/GetProductosModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo productos obtenido -> ", response);
                    service.productos = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[productosDataServices] error obteniendo el modelo de las productos", mensajeError);
                });
        }
    }
})();