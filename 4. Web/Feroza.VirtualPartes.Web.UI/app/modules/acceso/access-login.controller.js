'use strict';
angular
    .module('app.acceso')
    .controller('loginController', loginController);
loginController.$inject = ['$scope', '$location', 'authService', "$injector"];

function loginController($scope, $location, authService, $injector) {
    var vm = this;
    vm.loginData = {
        NombreUsuario: "",
        Password: ""
    };

    vm.message = "";

    vm.loginn = loginn;

    function loginn() {
        console.log(vm.loginData);
        authService.login(vm.loginData)
            .then(function (response) {
                console.log("registro exitoso");
                var $state = $injector.get("$state");
                $state.transitionTo("app.busquedaview");
            },
                function (err) {
                    vm.message = err.error_description;
                });
    }
}