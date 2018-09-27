(function () {
    'use strict';

    angular
        .module('app')
        .service('$registroClienteService', registroCliente);

    registroCliente.$inject = ['$http'];

    function registroCliente($http) {
        var baseUrl = "/RegistroCliente/";

        this.guardaDatoCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardarDatoCliente",
            });
        }

        this.guardaCuestionario = function (modelo) {
            debugger;
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardarCuestionario",
            });
        }

        this.ObtenerPaises = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerPaises",
            });
        }

        this.ObtenerEstados = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerEstados",
            });
        }

        this.ObtenerCiudades = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerCiudades",
            });
        }

        this.guardarCamposCartaEnc = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardarDatosCartaEnc",
            });
        }

        this.ObtenerPatentes = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerPatentes",
            });
		}

		this.ObtieneDatosCliente = function (parametro) {
			return $http({
				method: "GET",
				url: baseUrl + "ObtieneDatosCliente?idusuario=" + parametro,
			});
        }

        this.generarCartaEnc = function (modelo) {
            return $http({
                method: "POST",
                data: modelo,
                url: baseUrl + "GenerarCartaEnc",
            });
        }

        this.obtenerDatosCartaenc = function (modelo) {
            return $http({
                method: "POST",
                data: modelo,
                url: baseUrl + "ObtenerDatosCartaEnc",
            });
        }

        this.ObtieneDatosClientePost = function (modelo) {
            return $http({
                method: "POST",
                data: modelo,
                url: baseUrl + "ObtieneDatosClientePost",
            });
        }

        this.ObtieneDatosTituloSecciones = function (modelo) {
            return $http({
                method: "POST",
                data: modelo,
                url: baseUrl + "ObtieneDatosTituloSecciones",
            });
        }

        this.ObtieneDatosFinanciamiento = function (modelo) {
            return $http({
                method: "POST",
                data: modelo,
                url: baseUrl + "ObtieneDatosFinanciamiento",
            });
        }
    }


})();