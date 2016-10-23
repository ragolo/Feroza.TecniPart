(function () {
    'use strict';

    angular
        .module('blocks.logger')
        .factory('logger', logger);

    logger.$inject = ["$log", "toastr", "$mdDialog"];

    function logger($log, toastr, $mdDialog) {
        var service = {
            showToasts: false,

            error: error,
            info: info,
            success: success,
            warning: warning,

            // straight to console; bypass toastr
            log: $log.log
        };

        return service;
        /////////////////////

        function error(message, error, title, mostarAlert) {
            if (mostarAlert === true) {
                var alert = $mdDialog.alert({
                     title: "Error",
                     textContent: error,
                     ok: "Aceptar"
                 });

                 $mdDialog
                 .show(alert)
                 .finally(function () {
                     alert = undefined;
                 });
            } else {
                toastr.error(error, title);
            }
            $log.error('Error: ' + message, error);
        }

        function info(message, data, title) {
            if (service.showToasts) {
                toastr.info(message, title);
            }

            $log.info('Info: ' + message, data);
        }

        function success(message, data, title) {
            toastr.success(message, title);
            $log.info('Success: ' + message, data);
        }

        function warning(message, data, title) {
            toastr.warning(message, title);
            $log.warn('Warning: ' + message, data);
        }
    }
}());
