"use strict";
angular.module("tecnipart")
    .controller("controlEditorController", controlEditorController);
controlEditorController.$inject = ["$scope"];
function controlEditorController($scope) {
    var vm = this;
    vm.item = $scope.item;
}