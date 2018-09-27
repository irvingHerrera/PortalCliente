(function () {
    'use strict';

    angular
        .module('app')
        .controller('busquedaPreclienteCtrl', busquedaPrecliente);

    busquedaPrecliente.$inject = ['$scope'];

    function busquedaPrecliente($scope) {
        var vm = $scope;

        vm.listaPrecliente = {};
        vm.selectPrecliente = {};

        vm.init = function (listaPrecliente) {
            vm.listaPrecliente = listaPrecliente;
        }

        $scope.$watch("selectPrecliente.selected", function (valorNuevo, valorAnterior) {

            if (valorNuevo !== valorAnterior) {
                $scope.$emit('select_busqueda_precliente', valorNuevo);
            }
        });

    }

})();