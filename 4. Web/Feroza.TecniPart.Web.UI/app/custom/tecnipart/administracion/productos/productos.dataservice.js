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
        return service;

        function get(id) {
            logger.info("[productosDataServices] informacion", id);
            return service.productosListar.get(id).then(function (data) {
                logger.info("[productosDataServices] informacion recibida desde el servidor ", data);

                service.productos = data;
            }, function (reason) {
                logger.error("[productosDataServices] error obteniendo el modelo de las productos", reason);
            });
        }

        function save(productos) {
            logger.info("[productosDataServices] Guardando", productos);
            return appService.post("api/Productos", productos, "POST")
                .then(function (data) {
                    service.productos = data;
                    service.productosListar.push(data);
                    logger.success("[productosDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadoproductos", reason);
                });
        }

        function put(productos) {
            logger.info("[productosDataServices] Guardando", productos);
            return productos.put();
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[productosDataServices] datos obtenidos ", data);
                    service.productosListar = data;
                    return data;
                });
        }

        function removeProductos(productos) {
            logger.info("[productosDataServices] Eliminando -> ", productos);

            return appService.fetch("API/Productos/" + productos.IdProductos, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo productos obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[productosDataServices] error obteniendo el modelo productos", reason);
                });

        }

        function getProductosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Productos/GetProductosModel", { id: param })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo productos obtenido -> ", response);
                        service.productos = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[productosDataServices] error obteniendo el modelo de las productos", reason);
                });
        }
    }
})();