// Repository
angular.module("tecnipart")
    .service("ajaxServiceFactory", ajaxServiceFactory);
ajaxServiceFactory.$inject = ["$resource"];
function ajaxServiceFactory($resource) {
    "use strict";

    this.getService = getService;

    //// PUBLIC METHODS - Implementation

    function getService(endPoint) {
        if (endPoint === "") {
            throw "Invalid end point";
        }

        // create resource to make AJAX calls
        return $resource(endPoint + '/:id',
        {
            id: "@Id" // default URL params, '@' Indicates that the value should be obtained from a data property 
        },
        {
            'update': { method: 'PUT' } // add update to actions (is not defined by default)
        });
    }
}