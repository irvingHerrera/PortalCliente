(function () {
    'use strict';

    angular
        .module('app')
        .service('$layoutService', layout);

    layout.$inject = ['$http'];

    function layout($http) {
        var baseUrl = "/Notificacion/";

        this.validarTerminoCondicion = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ValidarTerminoCondicion",
            });
        }

        this.aceptarTerminoCondicion = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "AceptarTerminoCondicion",
            });
        }

        this.obtenerNotificacion = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerNotificacion",
            });
        };

        this.obtenerDatosUsuario = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerDatosUsuario",
            });
        };

        //this.obtenerListaPrecliente = function () {
        //    return $http({
        //        method: "post",
        //        url: baseUrl + "ObtenerListaPrecliente",
        //    });
        //};

    }

})();