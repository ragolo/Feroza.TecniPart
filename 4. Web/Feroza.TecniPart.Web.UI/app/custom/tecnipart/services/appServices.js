(function () {
    "use strict";
    angular.module("tecnipart")
        .factory("appService", appService);
    appService.$inject = ["$http", "$window", "$q", "logger"];

    function appService($http, $window, $q, logger) {
        var service = {};
        service.get = get;
        service.post = post;
        service.delete = del;
        service.put = put;
        service.fetch = fetch;

        return service;

        function fetch(url, requestData, method) {
            var defered = $q.defer();
            var promise = defered.promise;
            var httpMethod = method;

            if (typeof (httpMethod) === "undefined") {
                httpMethod = "POST";
            }

            $http({
                url: url,
                method: httpMethod,
                headers: { 'Content-Type': "application/json" },
                data: requestData
            })
                .success(function (response) {
                    defered.resolve(response);
                }
                )
                .error(function (err, codeStatus, r) {
                    defered.resolve(err);
                })
                .then(function () {
                });
            return promise;
        }

        function get(url, requestData) {

            var defered = $q.defer();
            var promise = defered.promise;
            $http({
                url: url,
                method: "GET",
                headers: { 'Content-Type': "application/json" },
                data: requestData
            })
                .success(function (response) {
                    defered.resolve(response);
                }
                )
                .error(function (err, codeStatus, r) {
                    defered.resolve(err);
                })
                .then(function () {
                });
            return promise;
        }

        function post(url, requestData) {
            logger.info("[appService] post entidad", requestData);

            var defered = $q.defer();
            var promise = defered.promise;
            $http({
                url: url,
                method: "POST",
                contentType: "application/json;chartset=utf-8",
                data: requestData
            })
                .success(function (response) {
                    defered.resolve(response);
                }
                )
                .error(function (err, codeStatus, r) {
                    defered.reject(err);
                })
                .then(function () {
                });
            return promise;
        }

        function del(url, requestData) {

            var defered = $q.defer();
            var promise = defered.promise;
            $http({
                url: url + requestData,
                method: "DELETE",
                headers: { 'Content-Type': "application/json" },
                //data: requestData
            })
                .success(function (response) {
                    defered.resolve(response);
                }
                )
                .error(function (err, codeStatus, r) {
                    defered.resolve(err);
                })
                .then(function () {
                });
            return promise;
        }

        function put(url, requestData) {
            logger.info("[appService] put entidad", requestData);
            var defered = $q.defer();
            var promise = defered.promise;
            $http({
                url: url,
                method: "PUT",
                headers: { 'Content-Type': "application/json" },
                data: requestData
            })
                .success(function (response) {
                    defered.resolve(response);
                }
                )
                .error(function (err, codeStatus, r) {
                    defered.resolve(err);
                })
                .then(function () {
                });
            return promise;
        }
    };
})();