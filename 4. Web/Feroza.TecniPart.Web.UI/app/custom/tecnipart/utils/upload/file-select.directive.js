"use strict";
angular.module("tecnipart.utils")
    .directive("fileSelect", fileSelect);

function fileSelect() {
    return {
        link: function ($scope, $el) {
            $el.bind("change",
                function (e) {
                    $scope.file = (e.srcElement || e.target).files[0];
                    $scope.getFile();
                });
        }
    }
}