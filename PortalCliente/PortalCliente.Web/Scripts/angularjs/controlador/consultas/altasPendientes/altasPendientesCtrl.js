(function () {
    'use strict';

    angular
        .module('app')
        .controller('altaPendienteCtrl', altaPendiente);

    altaPendiente.$inject = ['$scope', '$consultaService'];

    function altaPendiente($scope, $consultaService) {
        var vm = $scope;

        vm.preclientesPendientes = [];
        vm.busqueda = {};

        vm.init = function () {
            $consultaService.obtenerPreclientePendiente().then(function (resultado) {

                if (resultado.data.resultado) {
                    vm.preclientesPendientes = resultado.data.data;

                    setTimeout(function () { $("#table-precliente-pendiente").tablesorter(); }, 100);

                    

                } else {
                    console.log(resultado.data.mensaje);
                }

            }, function (error) {
                console.log("Error al obtener la lista de preclientes pendientes", error);
                })
        }
    }

})();