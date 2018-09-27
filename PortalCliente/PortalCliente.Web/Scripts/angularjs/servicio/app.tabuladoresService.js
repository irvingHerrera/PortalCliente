(function () {
    'use strict';

    angular
        .module('app')
        .service('$tabuladoresService', tabuladores);

    tabuladores.$inject = ['$http'];

    function tabuladores($http) {

        var baseUrl = "/RegistroCliente/";

        this.GuardarTabuladores = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/CapturaCliente/GuardarTabuladores",
            });
        }

        this.BuscarDatosTabuladores = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/CapturaCliente/BuscarDatosTabuladores",
            });
        }

        this.BuscarDatosTabuladoresContactos = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/CapturaCliente/BuscarDatosTabuladoresContactos",
            });
        }

        this.BuscarDatosTabuladoresTarifas = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/CapturaCliente/BuscarDatosTabuladoresTarifas",
            });
        }

        this.BuscarDatosTabuladoresTabs = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/CapturaCliente/BuscarDatosTabuladoresTabs",
            });
        }

        this.BuscarDatosTabuladoresEmpresa = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/CapturaCliente/BuscarDatosTabuladoresEmpresa",
            });
        }
    }

})();