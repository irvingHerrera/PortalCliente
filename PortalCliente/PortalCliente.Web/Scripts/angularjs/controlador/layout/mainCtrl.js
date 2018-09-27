(function () {
    'use strict';

    angular
        .module('app')
        .controller('mainCtrl', main);

    main.$inject = ['$scope', '$layoutService'];

    function main($scope, $layoutService) {
        var vm = $scope;

        vm.notificacion = [];
        vm.obtenerDatosUsuarios = function () {

            vm.datosUsuario = [];

            $layoutService.obtenerDatosUsuario({ usuario: "paco" }).then(function (data) {
                vm.datosUsuario = data;
            }, function (error) {
                console.log("error en obtenerDatosUsuario", error);
            });
        }

        vm.init = function () {
            var rolUsuario = window.aplicacionDatoUsuario.Rol;
            var usuario = window.aplicacionDatoUsuario.IdUsuario;

            $layoutService.obtenerNotificacion({ idUsuario: usuario, idRol: rolUsuario }).then(function (data) {
                if (data.data.resultado) {
                    vm.notificacion = data.data.dato;
                } else {

                }
            }, function (error) {
                console.log("error", error);
            });
        }

        vm.obtenerNotificacion = function () {

            vm.notificacion = [];
        };

        vm.notificacionSeleccionada = function (objNotificacion) {
            $scope.$broadcast("notificacionSeleccionada", objNotificacion);
            var url = '/' + objNotificacion.Controlador + '/' + objNotificacion.Vista;
            if (objNotificacion.Tab != null)
                objNotificacion.CargarDato = true;
            if (objNotificacion.Controlador && objNotificacion.Vista)
                angular.post(url, objNotificacion);
        };

        $scope.$on("select_busqueda_precliente", function (evet, data) {
            $scope.$broadcast("seleccion_busqueda", data)
        });
    }

})();