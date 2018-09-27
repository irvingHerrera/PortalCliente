(function () {
    'use strict';

    angular
        .module('app')
        .service('$impresionService', impresion);

    impresion.$inject = ['$http'];

    function impresion($http) {
        var baseUrl = "/Impresion/";

        this.obtenerExpediente = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ObtenerExpediente",
            });
        }

        this.reporteSolicitudCliente = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ReporteSolicitudCliente",
            });
        }

        this.reporteProcedimientoOperacion = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ReporteProcedimientoOperacion",
            });
        }

    }

})();