(function () {
    'use strict';

    angular
        .module('app')
        .service('$consultaService', consulta);

    consulta.$inject = ['$http'];

    function consulta($http) {
        var baseUrl = "/Consulta/";

        this.obtenerPreclientePendiente = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerListaPreclientePendiente",
            });
        }
        this.ObtenerUsrsNoAprobado = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerUsrsNoAprobado",
            });

            //usuario
        }
        this.AprobacionPrealta = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "AprobacionPrealta",
            });

            //usuario
        }
        this.ObtenerInfoTabulador = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerInfoTabulador",
            });

            //usuario
        }
        this.ObtenerAprobacionDePreAltaCliente = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerAprobacionDePreAltaCliente",
            });
        }
        this.ObtenerAprobacionDeAltaCliente = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerAprobacionDeAltaCliente",
            });
        }

       

    }

})();