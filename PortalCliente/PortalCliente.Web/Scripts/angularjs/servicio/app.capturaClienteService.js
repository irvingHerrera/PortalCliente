(function () {
    'use strict';

    angular
        .module('app')
        .service('$capturaClienteService', capturaCliente);

    capturaCliente.$inject = ['$http', '$httpParamSerializerJQLike'];

    function capturaCliente($http, $httpParamSerializerJQLike) {
        var baseUrl = "/CapturaCliente/";

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

        this.obtenerCuestionarioCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ObtenerCuestionarioCliente",
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

        this.obtenerDocumentosCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "obtenerDocumentosCliente",
            });
        }

        this.GuardarRevisionDocumentosCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardarRevisionDocumentosCliente",
            });
        }

        this.guardarEdicion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "GuardarEdicion",
            });
        }

        this.guardarEdicionAlta = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/AltaCliente/" + "GuardarEdicion",
            });
        }

        this.guardarArchivo = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/DocumentosCliente/GuardaDocumento",
                headers: {
                    'Content-Type': undefined // Note the appropriate header
                }
            });
        }

        this.RevisarAprobaronPeAltaCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "RevisarAprobaronPeAltaCliente",
            });
        }

        this.TerminarProcedimientoOperacion = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "TerminarProcedimientoOperacion",
            });
        }
        this.ValidaNumeroDocumentosRevisados = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ValidaNumeroDocumentosRevisados",
            });
        }

        this.ObtieneTabsPrecliente = function (idprecliente)
        {
            return $http({
                method: "get",
                url: baseUrl + "ObtieneTabsPrecliente?idPrecliente=" + idprecliente
            });
        }

        this.obtenerListaAprobador = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: "/Aprobacion/ObtenerListaAprobador",
            });
        }

        this.activarCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "ActivarCliente",
            });
        }

        this.inactivarCliente = function (modelo) {
            return $http({
                method: "post",
                data: modelo,
                url: baseUrl + "InactivarCliente",
            });
        }

    }


})();