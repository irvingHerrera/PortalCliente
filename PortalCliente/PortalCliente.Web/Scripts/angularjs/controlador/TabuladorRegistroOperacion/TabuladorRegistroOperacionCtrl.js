(function () {
	'use strict';

	angular
		.module('app')
		.controller('TabuladorRegistroOperacionCtrl', TabuladorRegistroOperacio);
	TabuladorRegistroOperacio.$inject = ['$scope', '$TabuladorProcedimientoOperacionService', '$document'];


	function TabuladorRegistroOperacio($scope,$TabuladorProcedimientoOperacionService, $document)
	{
		var vm = $scope;

		vm.GuardaTabuladorRegistroOperacion = function ()
		{
			$TabuladorProcedimientoOperacionService.GuardaTabuladorProcedimiento(vm.modelo).then(function (data) {
				console.log("correcto tabulador procedimiento operacion");

			}, function (error) {
				console.log("Error", error);
			})
        }

        vm.GetApliacacionPreferencia = function ()
        {
            $TabuladorProcedimientoOperacionService.GetApliacacionPreferencia().then(function (data) {
                vm.AplicacionPreferenciaCat = data;
            }, function (error) {
                console.log(error);
            });
        }

        vm.GetExIncoterms = function ()
        {
            $TabuladorProcedimientoOperacionService.GetExIncoterms().then(function (data) {
                vm.IncotermsCat = data;
            }, function (error) {
                console.log(error);
            });
        }

        vm.GetExMetodoValoracions = function () {
            $TabuladorProcedimientoOperacionService.GetExMetodoValoracions().then(function (data) {
                vm.MetodoValoracionsCat = data;
            }, function (error) {
                console.log(error);
            });
        }

        vm.GetFormaPagos = function () {
            $TabuladorProcedimientoOperacionService.GetFormaPagos().then(function (data) {
                vm.FormaPagosCat = data;
            }, function (error) {
                console.log(error);
            });
        }

        vm.GetRegimens = function () {
            $TabuladorProcedimientoOperacionService.GetRegimens().then(function (data) {
                vm.RegimensCat = data;
            }, function (error) {
                console.log(error);
            });
        }








	}


    

})();