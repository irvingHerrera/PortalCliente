(function () {
    'use strict';

    angular
        .module('app')
        .service('$sistemasOperativosService', sistemasOperativos);

    sistemasOperativos.$inject = ['$http'];

    function sistemasOperativos($http) {

        var baseUrl = "/AltaCliente/";

        this.ObtenerSistemasOperativos = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerSistemasOperativos",
            });
        }

        this.GuardarSistemasOperativos = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardarSistemasOperativos",
            });
        }

        this.GuardarGP = function (modelo) {
            return $http({
                method: "post",
                //header: "Company: ELI",
                headers: {
                    "Company": "ELI"
                },
                data: modelo,
                //data: { "CUSTNMBR": "NUMERO PRUEBA", "CUSTNAME": "NOMBRE PRUEBA"},
                url: "http://207.248.45.4/VerticalApi/api/Clientes/GuardarCliente",
            });
        }

    }

})();