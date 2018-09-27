(function () {
    'use strict';

    angular
        .module('app')
        .controller('sistemasOperativosCtrl', sistemasOperativos);

    sistemasOperativos.$inject = ['$scope', '$sistemasOperativosService', '$catalogoService'];

    function sistemasOperativos($scope, $sistemasOperativosService, $catalogoService) {

        var vm = $scope;
        vm.modelo = {};
        vm.modeloGP = {};

        vm.modelo.ID_precliente = 0;
        vm.modelo.ADUASIS = false;
        vm.modelo.GP = false;
        vm.modelo.Equipo = "";
        vm.modelo.Correos = "";
        vm.catalogoEquipoOperativo = [];

        vm.init = function () {
            console.log("sistemasOperativos: init");

            $catalogoService.obtenerEquipoOperativo().then(function (data) {
                console.log("data", data);

                if (data.data.resultado) {
                    vm.catalogoEquipoOperativo = data.data.data;
                } else {
                    console.log("Ocurrió un problema al obtener el catalogo Equipo Operativo");
                }

            }, function (error) {
                console.log("Ocurrió un problema al obtener el catalogo Equipo Operativo", error);
            });
        }

        $scope.$on("seleccion_busqueda", function (evet, data) {
            console.log("seleccion_busqueda controlador sistemas operativos", data);
            vm.modelo.ID_precliente = data.IdPrecliente;
        });

        vm.guardarSistemasOperativos = function () {
            console.log("en guardarSistemasOperativos");
            console.log("modelo", vm.modelo);

            if (vm.modelo.ID_precliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            resetearCampos();

            var error = 0;

            if (vm.modelo.ADUASIS === false && vm.modelo.GP === false) {
                $('#ADUASIS_SO').css({ 'color': 'red' });
                $('#GP_SO').css({ 'color': 'red' });
                error++;
            }

            if (vm.modelo.Equipo === "") {
                $('#Equipo_SO').css({ 'border-color': 'red' });
                error++;
            }

            var emails = $('#lista-emails').text();
            emails = emails.trim();
            if (emails === '') {
                $('#Correos_SO').css({ 'color': 'red' });
                error++;
            }
            else {
                vm.modelo.Correos = emails;
            }

            if (error > 0) {
                modalError("Faltan datos a ingresar.");
                return;
            }
            console.log("guardando en guardarSistemasOperativos");

            var insercionOK = false;
            $sistemasOperativosService.GuardarSistemasOperativos(vm.modelo).then(function (data) {
                if (data.data.resultado) {
                    vm.modeloGP = data.data.data[0];
                    if (vm.modelo.GP === true) {
                        $sistemasOperativosService.GuardarGP(vm.modeloGP).then(function (data) {
                            if (data.data.success) {
                                modalConfirmacion("Se guardaron los datos correctamente.");
                            }
                        }, function (error) {
                            console.log("Error en GP", error);
                            modalError("Error al guardar los datos, reintentar.");
                            insercionOK = false;
                        });
                    }
                    else {
                        modalConfirmacion("Se guardaron los datos correctamente.");
                    }
                    //modalConfirmacion("Se guardaron los datos correctamente.");
                }
            }, function (error) {
                console.log("Error en GuardarSistemasOperativos", error);
                modalError("Error al guardar los datos, reintentar.");
            });

            /*
            vm.modeloGP.ADRSCODE = "PRINCIPAL";
            vm.modeloGP.CUSTNMBR = "NUMERO8"; // ID NUEVO CLIENTE
            vm.modeloGP.CUSTNAME = "NOMBRE71"; // NOMBRE CLIENTE
            vm.modeloGP.CUSTCLAS = "PEDIMENTO"; // TIPO CLIENTE
            vm.modeloGP.ZIPCODE = "CODIGOPOSTAL7"; // CODIGO POSTAL
            vm.modeloGP.PHNUMBR1 = "1234567"; // TELEFONO
            vm.modeloGP.ADDRESS1 = "MIGUEL DE CERVANTES SAAVEDRA 301TORRE NORTE PISO 5"; // DIRECCION
            vm.modeloGP.ADDRESS3 = ""; // DIRECCION
            vm.modeloGP.CITY = "CUAUHTEMOC"; // CIUDAD
            vm.modeloGP.STATE = "NOMBRE PRUEBA6"; // ESTADO
            vm.modeloGP.COUNTRY = "MEXICO"; // PAIS DESCRIPCION
            

            $sistemasOperativosService.GuardarGP(vm.modeloGP).then(function (data) {
                if (data.data.resultado) {
                    modalConfirmacion("Se guardaron los datos correctamente en GP.");
                }
            }, function (error) {
                console.log("Error en GP", error);
                modalError("Error al guardar los datos, reintentar.");
            });
            */


        }

        function modalError(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');
            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensaje-aviso').innerHTML = mensaje;
        }

        function modalConfirmacion(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popupSO').fadeIn('fast');
            $('#popupSO .icon i').addClass('far fa-check-circle');
            window.document.getElementById('mensajeSO').innerHTML = mensaje;
        }

        function resetearCampos() {
            $('#ADUASIS_SO').css({ 'color': '#616161' });
            $('#GP_SO').css({ 'color': '#616161' });
            $('#Equipo_SO').css({ 'border-color': '#cccccc' });
            $('#Correos_SO').css({ 'color': '#616161' });
        }

    }

})();