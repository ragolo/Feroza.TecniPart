(function () {
    "use strict";
    angular.module("tecnipart")
        .controller("paisesController", paisesController);
    paisesController.$inject = ["paisesDataService"];

    function paisesController(paisesDataService) {
        var vm = this;
        vm.gridOptions = {
            columnDefs: [
                            { name: "IdPais", enableCellEdit: false, width: '10%', displayName: "", cellTemplate: 'Scripts/app/custom/tecnipart/partials/edit-button.html' },
                            { name: "Descripcion"}
            ],
            enableFiltering: true,
            enableHorizontalScrollbar: "uiGridConstants.scrollbars.NEVER",
            enableGridMenu: true
        };

        init();

        function init() {
            paisesDataService.getPaises().then(function (data) {
                vm.pasies = paisesDataService.Paises;
                vm.gridOptions.data = paisesDataService.Paises;
            });
        }
    }
})();