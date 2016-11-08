'use strict';

angular.module("app.core")
  .config(function ($provide) {
      $provide.decorator('$exceptionHandler', ['$log', '$delegate',
        function ($log, $delegate) {
            return function (exception, cause) {
                $log.debug('Default exception handler.');
                alert(cause);
                $delegate(exception, cause);
            };
        }
      ]);
  });