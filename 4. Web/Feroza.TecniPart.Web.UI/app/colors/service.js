/**=========================================================
 * Module: colors.js
 * Services to retrieve global colors
 =========================================================*/

(function () {
    "use strict";

    angular
        .module("app.colors")
        .service("Colors", colors);

    colors.$inject = ["APP_COLORS"];
    function colors(appColors) {
        this.byName = byName;

        ////////////////

        function byName(name) {
            return (appColors[name] || "#fff");
        }
    }

})();