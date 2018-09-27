(function () {
	'use strict';

	angular
        .module('app')
        .service('$catalogoService', catalogo);

	catalogo.$inject = ['$http'];

	function catalogo($http) {
		var baseUrl = "/Catalogo/";

		this.obtenerPais = function (parametro) {
			return $http({
				method: "post",
				data: parametro,
				url: baseUrl + "ObtenerPais",
			});
		}

		this.obtenerEstados = function (parametro) {
			return $http({
				method: "post",
				data: parametro,
				url: baseUrl + "ObtenerEstados",
			});
		}

		this.obtenerCiudades = function (parametro) {
			return $http({
				method: "post",
				data: parametro,
				url: baseUrl + "ObtenerCiudades",
			});
        };

        this.obtenerAduanas = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerAduanas",
            });
        }

        this.obtenerClavePedimento = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerClavePedimento",
            });
        }

        this.obtenerConceptoFacturacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerConceptoFacturacion",
            });
        }

        this.obtenerConceptoAutoFacturacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerConceptoAutoFacturacion",
            });
        }

        this.obtenerEquipoOperativo = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerEquipoOperativo",
            });
        }
	}

})();