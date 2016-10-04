(function () {
    "use strict";
    angular.module("tecnipart")
        .service("vehiculosDataServices", dataservice);
    dataservice.$inject = ["appService", "logger", "Restangular"];

    function dataservice(appService, logger, restAngular) {
        var service = {};
        var entityName = "Vehiculos";
        var restService = restAngular.service("Vehiculos");

        service.vehiculosListar = [];
        service.vehiculos = {};

        service.get = get;
        service.save = save;
        service.put = put;
        service.removeVehiculos = removeVehiculos;
        service.query = query;
        service.getVehiculosModel = getVehiculosModel;

        service.saveWithImage = saveWithImage;
        service.putWithImage = putWithImage;

        return service;

        function get(id) {
            logger.info("[vehiculosDataServices] informacion", id);
            return appService.fetch(entityName + "/GetVehiculosModel", { id: id })
                .then(function (data) {
                    logger.info("[vehiculosDataServices] informacion recibida desde el servidor ", data);
                    service.vehiculos = data.result;
                }, function (reason) {
                    logger.error("[vehiculosDataServices] error obteniendo el modelo de las vehiculos", reason);
                });
        }

        function save(vehiculos) {
            logger.info("[vehiculosDataServices] Guardando", vehiculos);
            return appService.post("api/Vehiculos", vehiculos, "POST")
                .then(function (data) {
                    service.vehiculos = data;
                    service.vehiculosListar.push(data);
                    logger.success("[vehiculosDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar vehiculos", reason);
                });
        }

        function saveWithImage(vehiculos, images) {
            vehiculos.ImagenVehiculoBase64 = null;
            vehiculos.ImagenVehiculo = null;
            logger.info("[vehiculosDataServices] imagen enviada al servidor", images);
            logger.info("[vehiculosDataServices] entidad que se envuelve en el encabezado", vehiculos);
            return appService.postImage("/Api/VehiculosImage", vehiculos, images)
                .then(function (data) {
                    service.vehiculos = data;
                    service.vehiculosListar.push(data);
                    logger.success("[vehiculosDataServices] Guardo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadovehiculos", reason);
                });
        }

        function putWithImage(vehiculos, images) {
            vehiculos.ImagenVehiculoBase64 = null;
            return appService.putImage("/Api/VehiculosImage", vehiculos, images)
                .then(function (data) {
                    service.vehiculos = data;
                    service.vehiculosListar.push(data);
                    logger.success("[vehiculosDataServices] Actualizo exitosamente", data);
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadovehiculos", reason);
                });
        }

        function put(vehiculos) {
            logger.info("[vehiculosDataServices] Guardando", vehiculos);
            return appService.put("api/Vehiculos", vehiculos)
               .then(function (data) {
                   service.vehiculos = data;
                   service.vehiculosListar.push(data);
                   logger.success("[vehiculosDataServices] Guardo exitosamente", data);
               },
               function (reason) {
                   logger.error("Error intentanto guardar vehiculos", reason);
               });
        }

        function query() {
            return restAngular.all(entityName).getList()
                .then(function (data) {
                    logger.info("[vehiculosDataServices] datos obtenidos ", data);
                    $(data).each(function (idx, vehiculo) {
                        vehiculo.ImagenVehiculoBase64 = typeof (vehiculo.ImagenVehiculoBase64) === "string" ? vehiculo.ImagenVehiculoBase64 : "data:image/jpeg;base64," + vehiculo.ImagenVehiculo;
                    });
                    service.vehiculosListar = data;
                    return data;
                });
        }

        function removeVehiculos(vehiculos) {
            logger.info("[vehiculosDataServices] Eliminando -> ", vehiculos);

            return appService.fetch("API/Vehiculos/" + vehiculos.IdVehiculos, "", "DELETE")
                .then(function (response) {
                    logger.info("Modelo vehiculos obtenido -> ", response);
                    //TODO: hay que cambiar la clave primaria de las tablas y la gestion es mas sencillas
                    query();
                }, function (reason) {
                    logger.error("[vehiculosDataServices] error obteniendo el modelo vehiculos", reason);
                });

        }

        function getVehiculosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Vehiculos/GetVehiculosModel", { id: param })
                .then(function (response) {
                    if (response.success) {
                        logger.info("Modelo vehiculos obtenido -> ", response);
                        service.vehiculos = response.result;
                    } else {
                        logger.error(response.error);
                    }
                    return response.result;
                }, function (reason) {
                    logger.error("[vehiculosDataServices] error obteniendo el modelo de las vehiculos", reason);
                });
        }
    }
})();