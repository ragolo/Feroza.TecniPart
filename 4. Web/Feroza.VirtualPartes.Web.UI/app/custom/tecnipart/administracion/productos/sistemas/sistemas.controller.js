(function() {
    "use strict";
    angular.module("tecnipart")
        .controller("sistemasController", sistemasController);
    sistemasController.$inject = [
        "$scope", "sistemasDataServices", "logger", "modalWindowFactory", "$mdDialog", "sistemasStateProvider"
    ];

    function sistemasController($scope,
        sistemasDataServices,
        logger,
        modalWindowFactory,
        $mdDialog,
        sistemasStateProvider) {
        var vm = this;
        init();
        vm.add = add;
        vm.edit = edit;
        vm.del = del;

        function init() {
            sistemasDataServices.query()
                .then(function(data) {
                    vm.sistemas = sistemasDataServices;
                });
            treee();
        }

        function add() {
            sistemasStateProvider.goToSistemasComponentAdd()
                .then(function() {
                    //init();
                });
        }

        function edit(sistemas) {
            logger.info("Levantara la vista y comenzara a editar", sistemas);
            sistemasStateProvider.goToSistemasComponentEdit(sistemas.IdSistemas);
        }

        function del(sistemas) {
            treee();
            var confirm = $mdDialog.confirm()
                .title("Eliminar: " + sistemas.Nombre)
                .textContent("Esta seguro que desea eliminar este registro?")
                .ariaLabel("Esta seguro que desea eliminar este registro?")
                .ok("Aceptar")
                .cancel("Cancelar");

            $mdDialog.show(confirm)
                .then(function() {
                    logger.info("Eliminara el registro", sistemas);
                    sistemasDataServices.removeSistemas(sistemas)
                        .then(function() {
                            //init();
                        });
                });
        }

        function treee() {
            $scope.remove = function (scope) {
                scope.remove();
            };

            $scope.toggle = function (scope) {
                scope.toggle();
            };

            $scope.moveLastToTheBeginning = function () {
                var a = $scope.data.pop();
                $scope.data.splice(0, 0, a);
            };

            $scope.newSubItem = function (scope) {
                var nodeData = scope.$modelValue;
                nodeData.nodes.push({
                    id: nodeData.id * 10 + nodeData.nodes.length,
                    title: nodeData.title + '.' + (nodeData.nodes.length + 1),
                    nodes: []
                });
            };

            $scope.collapseAll = function () {
                $scope.$broadcast('angular-ui-tree:collapse-all');
            };

            $scope.expandAll = function () {
                $scope.$broadcast('angular-ui-tree:expand-all');
            };

            $scope.data = [{
                'id': 1,
                'title': 'node1',
                'nodes': [
                  {
                      'id': 11,
                      'title': 'node1.1',
                      'nodes': [
                        {
                            'id': 111,
                            'title': 'node1.1.1',
                            'nodes': []
                        }
                      ]
                  },
                  {
                      'id': 12,
                      'title': 'node1.2',
                      'nodes': []
                  }
                ]
            }, {
                'id': 2,
                'title': 'node2',
                'nodrop': true, // An arbitrary property to check in custom template for nodrop-enabled
                'nodes': [
                  {
                      'id': 21,
                      'title': 'node2.1',
                      'nodes': []
                  },
                  {
                      'id': 22,
                      'title': 'node2.2',
                      'nodes': []
                  }
                ]
            }, {
                'id': 3,
                'title': 'node3',
                'nodes': [
                  {
                      'id': 31,
                      'title': 'node3.1',
                      'nodes': []
                  }
                ]
            }];
            //$scope.data = vm.sistemas;
        }
    }
})();