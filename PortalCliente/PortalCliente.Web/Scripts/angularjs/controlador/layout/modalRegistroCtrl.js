(function () {
    'use strict';

    angular
        .module('app')
        .controller('modalRegistroCtrl', modalRegistro);

    modalRegistro.$inject = ['$scope', '$layoutService'];

    function modalRegistro($scope, $layoutService) {
        var vm = $scope;

        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        $scope.$on("notificacionSeleccionada", function (data, evt) {
            console.log("Notificacion", data);
            console.log("Notificacion", evt);
        });

        vm.inicializar = function () {

            if (rolUsuario == 2) {
                $layoutService.validarTerminoCondicion({ idUsuario: usuario }).then(function (data) {
                    if (!data.data.resultado) {
                        $('#modalRegistroCliente').modal({ backdrop: 'static', keyboard: false })
                        $('#modalRegistroCliente').modal('show');
                    }
                }, function (error) {
                    console.log("Ocurrió un error al consultar terminso y condiciones", error);
                });
            }
        };

        vm.aceptarContrato = function () {
            //guardar aceptacion de terminos y condiciones, cambiar el estatus del precliente 
            //en registro

            $layoutService.aceptarTerminoCondicion({ idPreCliente: idPrecliente }).then(function (data) {
                if (data)
                    $('#modalRegistroCliente').modal('hide');
                $('#paso2').prop('disabled', true);
                $('#paso3').prop('disabled', true);
                $('#paso4').prop('disabled', true);
            }, function () {
                console.log("Ocurrió un error al aceptar términos y condiciones", error);
            })


            $('#modalRegistroCliente').modal('hide');
            $scope.obtenerDatosUsuarios();
            $scope.obtenerNotificacion();
        };

        vm.cancelarContrato = function () {
            window.location.href = "/Login/Index";
        };

    }

})();