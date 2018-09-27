(function () {
    'use strict';

    angular
        .module('app')
        .controller('aprobadorCtrl', aprobador);

    aprobador.$inject = ['$scope', '$aprovacionService'];

    function aprobador($scope, $aprovacionService) {
        var vm = $scope;
        //vm.listaAprobador = {};
        vm.inhabilitaPreAlta = true;
        vm.inhabilitaProcedimientoOperacion = true;
        vm.inhabilitaActCliente = true;

        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;
        // Lider             3
        // Gerente comercial 5
        // Aprobador         6
        if (rolUsuario == 5 || rolUsuario == 6) {
            //Ver prealta
            $('#cont-paso1').fadeIn('fast');
            $('#cont-paso2').fadeOut('fast');
            $('#cont-paso3').fadeOut('fast');
        }
        if (rolUsuario == 3) {
            //Ver procedimiento de operación
            $('#cont-paso1').fadeOut('fast');
            $('#cont-paso2').fadeIn('fast');
            $('#cont-paso3').fadeOut('fast')
        }

        //codigo duro
        /*
        vm.obtenerListaAprobador = function (precliente) {
            $aprovacionService.obtenerListaAprobador({ idPrecliente: precliente.IdPrecliente })
                .then(function (data) {
                    vm.listaAprobador = data.data.data;
                    if (vm.listaAprobador.length > 0) {
                        vm.classTopAprobador = 'top-aprobador';
                        //vm.classTopAprobador = data.data.data;

                    }
                    else {
                        vm.classTopAprobador = '';
                    }
                }, function (error) {
                    console.log("Error", data.data.mensaje + ' ' + error);
                })
        }
        */
        //vm.inhabilitaActCliente = true;

        
        function habilitarProcDeOpe() {
            //document.getElementById("paso4").disabled = false;
        }
        function desHabilitarProcDeOpe() {
            //document.getElementById("paso4").disabled = true;
        }
        //evento 
        $scope.$on("seleccion_busqueda", function (evet, data) {
            console.log("seleccion_busqueda controlador aprobador", data);

            // Lider             3
            // Gerente comercial 5
            // Aprobador         6

            $("#cont-paso2").css("display", "");
            $("#paso1").addClass("btn-operaciones active");
            $("#paso2").removeClass("btn-operaciones active").addClass("btn-operaciones");

            if (data.Estatus === 3 && (rolUsuario == 6 || rolUsuario == 5)) {
                //Ver prealta
                $('#cont-paso1').fadeIn('fast');
                $('#cont-paso2').fadeOut('fast');
                $('#cont-paso3').fadeOut('fast');
                vm.inhabilitaPreAlta = false;
                vm.inhabilitaProcedimientoOperacion = true;
                vm.inhabilitaActCliente = true;
            }

            if ((data.Estatus === 10 || data.Estatus === 11) && (rolUsuario == 3 || rolUsuario == 5)) {
                //Ver procedimiento de operación
                $('#cont-paso1').fadeOut('fast');
                $('#cont-paso2').fadeIn('fast');
                $('#cont-paso3').fadeOut('fast');
                vm.inhabilitaPreAlta = true;
                vm.inhabilitaProcedimientoOperacion = false;
                vm.inhabilitaActCliente = true;
                
                $("#paso1").removeClass("btn-operaciones active").addClass("btn-operaciones");
                $("#paso2").addClass("btn-operaciones active");
            }
            else {
                $('#cont-paso2').fadeOut('fast');
            }

            if (data.Estatus === 16 && rolUsuario == 6) {
                //Ver actualización cliente
                $('#cont-paso1').fadeOut('fast');
                $('#cont-paso2').fadeOut('fast');
                $('#cont-paso3').fadeIn('fast');
                vm.inhabilitaPreAlta = true;
                vm.inhabilitaProcedimientoOperacion = true;
                vm.inhabilitaActCliente = false;
            }

            if (data.Estatus === 3 && rolUsuario == 3) {
                $("#paso1").removeClass("btn-operaciones active").addClass("btn-operaciones");
                $("#cont-paso2").css("display", "none")
                $("#paso2").addClass("btn-operaciones active");
            }

            /*
            vm.classTopAprobador = '';
            vm.listaAprobador = [];
            if (data.Estatus === 4)
                vm.obtenerListaAprobador(data);
            else
                vm.listaAprobador = [];
            */

            //data.Estatus = 9;
            /*
            vm.inhabilitaActCliente = true;
            if (data.Estatus == 8 || data.Estatus == 9) {
                console.log("habilitar");
                vm.inhabilitaActCliente = false;
            }
            if (data.Estatus == 5 || data.Estatus == 8) {
                habilitarProcDeOpe();
            } else {
               desHabilitarProcDeOpe();
            }
            */

        });

    }

})();