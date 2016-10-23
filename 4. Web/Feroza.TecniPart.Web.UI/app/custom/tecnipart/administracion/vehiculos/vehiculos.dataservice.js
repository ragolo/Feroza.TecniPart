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
                    logger.error("[vehiculosDataServices] error obteniendo el modelo de las vehiculos", reason, "", true);
                });
        }

        function save(vehiculos) {
            logger.info("[vehiculosDataServices] Guardando", vehiculos);
            return appService.post("api/Vehiculos", vehiculos)
                .then(function (data) {
                    service.vehiculos = data;
                    service.vehiculosListar.push(data);
                    logger.success("[vehiculosDataServices] Guardo exitosamente", data);
                    return service.vehiculos;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadovehiculos", reason);
                });
        }

        function saveWithImage(vehiculos, images) {
            vehiculos.ImagenVehiculosBase64 = null;
            vehiculos.ImagenVehiculos = null;
            logger.info("[vehiculosDataServices] imagen enviada al servidor", images);
            logger.info("[vehiculosDataServices] entidad que se envuelve en el encabezado", vehiculos);
            return appService.postImage("/Api/VehiculosImage", vehiculos, images)
                .then(function (data) {
                    service.vehiculos = data;
                    service.vehiculosListar.push(data);
                    logger.success("[vehiculosDataServices] Guardo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadovehiculos", reason);
                });
        }

        function putWithImage(vehiculos, images) {
            vehiculos.ImagenVehiculosBase64 = null;
            return appService.putImage("/Api/VehiculosImage", vehiculos, images)
                .then(function (data) {
                    service.vehiculos = data;
                    service.vehiculosListar.push(data);
                    logger.success("[vehiculosDataServices] Actualizo exitosamente", data);
                    return data;
                },
                function (reason) {
                    logger.error("Error intentanto guardar estadovehiculos", reason);
                });
        }

        function put(vehiculos) {
            console.log("sdadasdasdasdasdasdsadadasdas");
            console.log(vehiculos);
            vehiculos.ImagenVehiculosBase64 = null;

            logger.info("[vehiculosDataServices] Guardando", vehiculos);
            return appService.put("api/Vehiculos", vehiculos)
               .then(function (data) {
                   service.vehiculos = data;
                   service.vehiculosListar.push(data);
                   logger.success("[vehiculosDataServices] Guardo exitosamente", data);
                   return data;
               },
               function (reason) {
                   logger.error("Error intentanto guardar estadovehiculos", reason);
               });
        }

        function query() {
            return appService.fetch("api/Vehiculos", null, "GET")
                    .then(function (response) {
                        logger.info("[vehiculosDataServices] datos obtenidos ", response);
                        service.vehiculosListar = response;
                        return response;
                    },
                        function (mensajeError) {
                            logger.error("Error intentanto actualizar el vehiculos", mensajeError, "", true);
                        });
        }

        function removeVehiculos(vehiculos) {
            logger.info("[vehiculosDataServices] Eliminando -> ", vehiculos);

            return appService.fetch("API/Vehiculos/", vehiculos, "DELETE")
                .then(function (response) {
                    logger.info("Modelo vehiculos obtenido -> ", response);
                    logger.success("[vehiculosDataServices] Se removio exitosamente", response);
                    service.vehiculosListar = service.vehiculosListar.filter(function (vehiculosFilter) {
                        return vehiculosFilter.IdVehiculos !== vehiculos.IdVehiculos;
                    });
                    return service.vehiculosListar;
                }, function (reason) {
                    logger.error("[vehiculosDataServices] error obteniendo el modelo vehiculos", reason);
                });

        }

        function getVehiculosModel(id) {
            logger.info("Obteniendo el modelo para -> ", id);
            var param = typeof (id) === "undefined" ? null : id;
            return appService.fetch("Vehiculos/GetVehiculosModel", { id: param })
                .then(function (response) {
                    logger.info("Modelo vehiculos obtenido -> ", response);
                    service.vehiculos = response;
                    return response;
                }, function (mensajeError) {
                    logger.error("[vehiculosDataServices] error obteniendo el modelo de las vehiculos", mensajeError);
                });
        }
    }
})();