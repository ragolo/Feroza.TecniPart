(function() {
    'use strict';
    // Used only for the BottomSheetExample
    angular
        .module('app.material')
        .run(materialRun)
        ;
    materialRun.$inject = ['$http', '$templateCache'];
    function materialRun($http, $templateCache){
      var urls = [
        'Content/img/icons/share-arrow.svg',
        'Content/img/icons/upload.svg',
        'Content/img/icons/copy.svg',
        'Content/img/icons/print.svg',
        'Content/img/icons/hangout.svg',
        'Content/img/icons/mail.svg',
        'Content/img/icons/message.svg',
        'Content/img/icons/copy2.svg',
        'Content/img/icons/facebook.svg',
        'Content/img/icons/twitter.svg'
      ];

      angular.forEach(urls, function(url) {
        $http.get(url, {cache: $templateCache});
      });

    }

})();
