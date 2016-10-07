"use sctric";
angular.module("tecnipart.utils")
    .controller("visorImagenController", visorImagenController);
visorImagenController.$inject = ["$mdDialog"];
function visorImagenController($mdDialog) {
    var vm = this;
    vm.cerrar = cerrar;

    function cerrar() {
        $mdDialog.hide();
    }
}