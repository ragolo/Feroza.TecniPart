(function () {
    "use strict";

    angular
        .module("layout.sidebar")
        .controller("userBlockController", userBlockController);

    userBlockController.$inject = ["$scope"];

    function userBlockController($scope) {

        activate();

        ////////////////

        function activate() {

            $scope.userBlockVisible = true;

            var detach = $scope.$on("toggleUserBlock", function (/*event, args*/) {

                $scope.userBlockVisible = !$scope.userBlockVisible;

            });

            $scope.$on("$destroy", detach);
        }
    }
})();