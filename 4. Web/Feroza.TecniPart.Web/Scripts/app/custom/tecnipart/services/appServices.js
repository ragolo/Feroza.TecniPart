(function () {
    "use strict";
    angular.module("tecnipart")
        .factory("appService", appService);
    appService.$inject = ["$http", "$window", "$q"];

    function appService($http, $window, $q) {
        var service = {};
        service.fetch = fetch;
        service.get = get;
        service.post = post;
        service.delete = del;
        service.put = put;
        return service;

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
                    defered.resolve(err);
                })
                .then(function () {
                });
            return promise;
        }

        function del(url, requestData) {

            var defered = $q.defer();
            var promise = defered.promise;
            $http({
                url: url,
                method: "DELETE",
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

        function put(url, requestData) {

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