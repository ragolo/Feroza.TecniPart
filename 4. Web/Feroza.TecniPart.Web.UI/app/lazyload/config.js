(function () {
    "use strict";

    angular
        .module("app.lazyload")
        .config(lazyloadConfig);

    lazyloadConfig.$inject = ["$ocLazyLoadProvider", "APP_REQUIRES"];
    function lazyloadConfig($ocLazyLoadProvider, appRequires) {

        // Lazy Load modules configuration
        $ocLazyLoadProvider.config({
            debug: false,
            events: true,
            modules: appRequires.modules
        });

    }
})();