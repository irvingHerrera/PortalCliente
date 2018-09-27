(function () {
    'use strict';

    angular
        .module('app')
        .controller('impresionCtrl', impresion);

    impresion.$inject = ['$scope', '$impresionService', '$q'];

    function impresion($scope, $impresionService, $q) {
        var vm = $scope;

        vm.mostrarVisor = false;
        vm.documentoVisual = {};
        vm.expediente = {};
        vm.solicitud = {};
        vm.procedimiento = {};

        vm.showExpediente = true;
        vm.showSolicitud = true;
        vm.showProcedimiento = true;

        $scope.$on("seleccion_busqueda", function (evet, data) {
            console.log(data);
            obtenerDocumentacion(data);
            vm.showExpedienteError = false;
            vm.showSolicitudError = false;
            vm.showProcedimientoError = false;

            vm.showExpediente = true;
            vm.showSolicitud = true;
            vm.showProcedimiento = true;
        });

        vm.verSolicitud = function () {
            vm.mostrarVisor = true;
            vm.documentoVisual = vm.solicitud;
        };

        vm.verProcedimiento = function () {
            vm.mostrarVisor = true;
            vm.documentoVisual = vm.procedimiento;
        };

        vm.verExpediente = function () {
            vm.mostrarVisor = true;
            vm.documentoVisual = vm.expediente;
        };

        vm.cerrarVisor = function () {
            vm.mostrarVisor = false;
            
        }

        function obtenerPromesas(informacionBusqueda) {
            var promesaSolicitud = $impresionService.reporteSolicitudCliente({ idPrecliente: informacionBusqueda.IdPrecliente, IdUsuario: informacionBusqueda.IdUsuario });
            var promesaProcedimiento = $impresionService.reporteProcedimientoOperacion({ idPrecliente: informacionBusqueda.IdPrecliente, IdUsuario: informacionBusqueda.IdUsuario });
            var promesaExpediente = $impresionService.obtenerExpediente({ idPrecliente: informacionBusqueda.IdPrecliente, IdUsuario: informacionBusqueda.IdUsuario });

            return $q.all({
                promesaSolicitud,
                promesaProcedimiento,
                promesaExpediente
            });
        }

        function obtenerDocumentacion(informacionBusqueda) {
            obtenerPromesas(informacionBusqueda).then(function (promesas) {
                console.log("promesaSolicitud", promesas.promesaSolicitud.data);
                if (promesas.promesaSolicitud.data.resultado) {
                    vm.solicitud = promesas.promesaSolicitud.data.data;
                    if (vm.solicitud.ExisteDocumento)
                        vm.showSolicitud = false;
                    else {
                        vm.showSolicitudError = true;
                    }
                } else {
                    console.log(promesas.promesaSolicitud.data.mensaje);
                    vm.showSolicitudError = true;
                }

                if (promesas.promesaProcedimiento.data.resultado) {
                    vm.procedimiento = promesas.promesaProcedimiento.data.data;
                    if (vm.procedimiento.ExisteDocumento)
                        vm.showProcedimiento = false;
                    else {
                        vm.showProcedimientoError = true;
                    }
                } else {
                    console.log(promesas.promesaProcedimiento.data.mensaje);
                    vm.showProcedimientoError = true;
                }

                console.log("promesaExpediente", promesas.promesaExpediente.data);
                if (promesas.promesaExpediente.data.resultado) {
                    vm.expediente = promesas.promesaExpediente.data.data;
                    if (vm.expediente.ExisteDocumento)
                        vm.showExpediente = false;
                    else {
                        vm.showExpedienteError = true;
                    }
                } else {
                    console.log(promesas.promesaExpediente.data.mensaje);
                    vm.showExpedienteError = true;
                }
            }, function (error) {
                console.log("Ocurrió un problema al obtener la documentación", error);
            });
        }
    }

})();