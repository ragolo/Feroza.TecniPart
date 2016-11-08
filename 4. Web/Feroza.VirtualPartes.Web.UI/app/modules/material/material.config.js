
(function() {
    'use strict';
    // Used only for the BottomSheetExample
    angular
        .module('app.material')
        .config(materialConfig)
        ;
    materialConfig.$inject = ['$mdIconProvider'];
    function materialConfig($mdIconProvider){
      $mdIconProvider
        .icon('share-arrow', 'Content/img/icons/share-arrow.svg', 24)
        .icon('upload', 'Content/img/icons/upload.svg', 24)
        .icon('copy', 'Content/img/icons/copy.svg', 24)
        .icon('print', 'Content/img/icons/print.svg', 24)
        .icon('hangout', 'Content/img/icons/hangout.svg', 24)
        .icon('mail', 'Content/img/icons/mail.svg', 24)
        .icon('message', 'Content/img/icons/message.svg', 24)
        .icon('copy2', 'Content/img/icons/copy2.svg', 24)
        .icon('facebook', 'Content/img/icons/facebook.svg', 24)
        .icon('twitter', 'Content/img/icons/twitter.svg', 24);
    }
})();
