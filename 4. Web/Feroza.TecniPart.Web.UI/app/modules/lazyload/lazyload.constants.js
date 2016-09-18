(function () {
    'use strict';

    angular
        .module('app.lazyload')
        .constant('APP_REQUIRES', {
            // jQuery based and standalone scripts
            scripts: {
                'modernizr': ['Scripts/Vendor/modernizr/modernizr.custom.js'],
                'icons': ['Scripts/Vendor/fontawesome/css/font-awesome.min.css',
                                       'Scripts/Vendor/simple-line-icons/css/simple-line-icons.css'],
                'weather-icons': ['Scripts/Vendor/weather-icons/css/weather-icons.min.css',
                                       'Scripts/Vendor/weather-icons/css/weather-icons-wind.min.css'],
                'loadGoogleMapsJS': ['Scripts/Vendor/load-google-maps/load-google-maps.js']
            },
            // Angular based script (use the right module name)
            modules: [
                  { name: "smart-table", files: ["Scripts/Vendor/angular-smart-table/smart-table.min.js"] },
                  { name: 'toaster', files: ['Scripts/Vendor/angularjs-toaster/toaster.js', 'Scripts/Vendor/angularjs-toaster/toaster.css'] }
            ]
        })
    ;

})();
