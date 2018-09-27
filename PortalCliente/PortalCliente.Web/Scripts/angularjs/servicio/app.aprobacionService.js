(function () {
    'use strict';

    angular
        .module('app')
        .service('$aprovacionService', aprovacion);

    aprovacion.$inject = ['$http'];
    function aprovacion($http) {
        var baseUrl = "/Aprobacion/";

        this.revalidacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "Revalidacion",
            });
        }

        this.aprobacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "Aprobacion",
            });
        }

        this.obtenerListaCuentaBanco = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerCuentaPECA",
            });
        }

        this.obtenerDireccionCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerDirecionCliente",
            });
        }

        this.obtenerNumeroTabulador = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerNumeroTabulador",
            });
        }

        this.obtenerListaAprobador = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerListaAprobador",
            });
		}

		this.AprobadoSinProcedimientoPreAlta = function (modelo) {
			return $http({
				method: "post",
				data: modelo,
				url: baseUrl + "AprobadoSinProcedimientoPreAlta",
			});
		}

		this.NoAprobado = function (modelo) {
			return $http({
				method: "post",
				data: modelo,
				url: baseUrl + "NoAprobado",
			});
        }
        this.PreAltaRevalidacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "PreAltaRevalidacion",
            });
        }

        this.obtenerInfoCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerInfoCliente",
            });
        }

        this.obtenerContactosCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerContactosCliente",
            });
        }

        this.obtenerPECACliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerPECACliente",
            });
        }

        this.obtenerUsrsAduabookCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerUsrsAduabookCliente",
            });
        }

        this.revalidacionAC = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "RevalidacionActCliente",
            });
        }

        this.aprobacionAC = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "AprobacionActCliente",
            });
        }

        this.ObtenerInfActCte = function(modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerInfActCliente",
            });
        }

    }
})();