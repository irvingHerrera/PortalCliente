(function () {
	'use strict';

	angular
		.module('app')
		.service('$TabuladorProcedimientoOperacionService', TabuladorProcedimientoOperacion);

	TabuladorProcedimientoOperacion.$inject = ['$http'];

    function TabuladorProcedimientoOperacion($http) {
        var baseUrl = "/TabuladorProcedimientoOperacion/";

        this.GuardaTabuladorProcedimiento = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardaTabuladorProcedimiento",
            });
        }

        this.GetTabuladorTab = function (idtab) {
            return $http({
                method: "get",
                url: baseUrl + "GetTabuladorTab?idprecliente=" + idtab,
            });
        }

        this.puedeActualizarProcedimiento = function (idprecliente)
        {
            return $http({
                method: "get",
                url: baseUrl + "PuedeActualizarProcedimientoOperacion?idprecliente=" + idprecliente,
            });
        }

		//CATALOGOS

		this.GetApliacacionPreferencia = function (modelo) {
			return $http({
				method: "get",
				url: baseUrl + "GetApliacacionPreferencia",
			});
		}

		this.GetExIncoterms = function (modelo) {
			return $http({
				method: "get",
				url: baseUrl + "GetExIncoterms",
			});
		}

		this.GetExMetodoValoracions = function (modelo) {
			return $http({
				method: "get",
				url: baseUrl + "GetExMetodoValoracions",
			});
		}

		this.GetFormaPagos = function (modelo) {
			return $http({
				method: "get",
				url: baseUrl + "GetFormaPagos",
			});
		}

		this.GetRegimens = function (modelo) {
			return $http({
				method: "get",
				url: baseUrl + "GetRegimens",
			});
        }

        this.GuardarTerminarProcedimientoOperacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/CapturaCliente/GuardarTerminarProcedimientoOperacion",
            });
        }

	}


})();