(function () {
    'use strict';

    angular
        .module('app')
        .service('$actualizaClienteService', actualizaCliente);

    actualizaCliente.$inject = ['$http'];

    function actualizaCliente($http) {
        var baseUrl = "/ActualizarCliente/";

        this.GuardarDatoOperacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardarDatoOperacion",
            });
        }

        this.BuscarDatosTabuladores = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "BuscarDatosTabuladores",
            });
        }

        this.BuscarDatosTabuladoresContactos = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "BuscarDatosTabuladoresContactos",
            });
        }

        this.BuscarDatosTabuladoresTarifas = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "BuscarDatosTabuladoresTarifas",
            });
        }

        this.BuscarDatosTabuladoresTabs = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "BuscarDatosTabuladoresTabs",
            });
        }

        this.BuscarDatosTabuladoresEmpresa = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "BuscarDatosTabuladoresEmpresa",
            });
        }

        this.GetTabuladorTab = function (idtab) {
            return $http({
                method: "get",
                url: baseUrl + "GetTabuladorTab?idprecliente=" + idtab,
            });
        }
    }

    

})();