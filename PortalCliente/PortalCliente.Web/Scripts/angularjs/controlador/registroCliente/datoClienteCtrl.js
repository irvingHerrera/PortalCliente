(function () {
    'use strict';

    angular
        .module('app')
        .controller('datoClienteCtrl', datoCliente);

    datoCliente.$inject = ['$scope', '$registroClienteService', '$catalogoService', '$document'];

    function datoCliente($scope, $registroClienteService, $catalogoService, $document) {
        var vm = $scope;
        

        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        var prec = idPrecliente;
        vm.modelo = {};
        vm.modeloBanco = [];
        vm.modeloContacto = [];
        vm.banco = {};
        vm.contacto = {};
        vm.cuestionario = {};
        var filasContactos = 0;
        var filasBancos = 0;

        var tempestado;
        var tempciudad;
        var temppais;

        vm.catalogoPais = {};
        vm.catalogoEstado = {};
        vm.catalogoCiudad = {};
        //00000

        vm.clickDocumento = function () {
            console.log("clickDocumento", window.numeroDocumento);
            if (window.numeroDocumento != 0)
                if (window.numeroDocumento < 10) {
                    //modalExitoDocumento();
                } else {

                }
        }

        function obtenerIdPrecliente() {
            var cero = '00000';
            cero = cero.substring(0, (cero.length - 1) - (idPrecliente.length - 1));
            cero += idPrecliente;
            return cero;
        }

        vm.modelo.IdPrecliente = idPrecliente;
        vm.modelo.IdPreclienteVisual = "PRE_" + obtenerIdPrecliente();


        vm.init = function () {
            vm.modelo.IdPrecliente = idPrecliente;

            $catalogoService.obtenerPais().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoPais = data.data.dato;
                    //console.log("pais", vm.catalogoPais);
                    //cargarPaises();
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })


        };

        vm.obtenerEstado = function (pais) {
            $catalogoService.obtenerEstados({ idPais: pais }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoEstado = data.data.dato;
                    cargaestados();
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }

        vm.obtenerCiudad = function (estado) {
            $catalogoService.obtenerCiudades({ idEstado: estado }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoCiudad = data.data.dato;
                    cargaciudad();
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }
        

        vm.Paises = [];
        vm.Estados = [];
        vm.Ciudades = [];

        vm.Pais = '';
        vm.Estado = '';
        vm.Ciudad = '';

        //Campos faltantes de carta 
        vm.Calle = '';
        vm.Colonia = '';
        vm.CP = '';
        vm.Estado = '';
        vm.Municipio = '';
        vm.Estado = '';
        vm.NoInt = '';
        vm.NoExt = '';
        vm.Escritura = '';
        vm.Notario = '';
        vm.Notaria = '';
        vm.CdNotariado = '';
        vm.EdoNotariado = '';
        vm.Membrete = '(Imprimir en membrete de la empresa importadora o exportadora. Borrar el presente texto antes de enviar o imprimir)';
        vm.PeriodoInicio = '';
        vm.PeriodoFin = '';


        vm.FechaActual = new Date();

        vm.Patentes = [];

        vm.Patente = '-- Seleccione un patente --||';
        vm.NombrePatente = "";
        vm.DireccionPatente = "";

        vm.guardarDatos = function () {
            vm.modelo.Contacto = vm.modeloContacto;
            vm.modelo.Cuenta = vm.modeloBanco;
            vm.modelo.UsuarioModificacion = 'Test';

            // Valida que se ingresen valores en todos los campos
            var faltantes = 0;

            for (var i = 2; i <= 20; i++) {
                if (document.getElementById('in' + i).value == '') {
                    $('#in' + i).addClass('falta');
                    $('#cont-paso1').scrollTop(0);
                    $('#req' + i).fadeIn('fast');
                    faltantes++
                } else {
                    $('#in' + i).removeClass('falta');
                }
            };

            if ((faltantes > 0)) {
                $('.popupoverlay').fadeIn('fast');
                $('#popupFin').fadeIn('fast');
                $('#popupFin .icon .far').addClass('fa-check-circle');
                document.getElementById('mensajeFin').innerHTML = "Se deben llenar todos los campos.";
                $('#cont-paso1').scrollTop(0);

                return;

                /*
                $('.popupoverlay').fadeIn('fast');
                $('#popupFin').fadeIn('fast');
                $('#popupFin .icon .far').addClass('fa-check-circle');
                document.getElementById('mensajeFin').innerHTML = "Favor de capturar motivo por el cual no envía la encomienda de respaldo.";
                $('#cont-paso4').scrollTop(0);
                $('#motivo1').addClass('falta');

                $('.popupoverlay').fadeIn('fast');
                $('#popup').fadeIn('fast');

                $('#popup .icon i').addClass('far fa-check-circle');
                document.getElementById('mensaje').innerHTML = "Se guardó correctamente la información.";
                */
            };

            // Valida al menos haberse agregado un contacto
            if (filasContactos == 0) {
                //$('.popupoverlay').fadeIn('fast');
                //$('#popup-error').fadeIn('fast');

                //$('#popup-error .icon i').addClass('fas fa-exclamation-circle');
                //document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
                $('#req-table1').fadeIn('fast');
                return;
            }

            // Valida al menos haberse agregado un banco
            if (filasBancos == 0) {
                //$('.popupoverlay').fadeIn('fast');
                //$('#popup-error').fadeIn('fast');

                //$('#popup-error .icon i').addClass('fas fa-exclamation-circle');
                //document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
                $('#req-table2').fadeIn('fast');
                return;
            }

            //$('#req-table1').fadeOut('fast');

            $registroClienteService.guardaDatoCliente(vm.modelo).then(function (data) {
                if (data.data.resultado)
                    modalExito();
                else
                    modalError(data.data.mensaje);
            }, function (error) {
                console.log("error", error);
            })
        };

        vm.GuardarCuestionario = function () {

            var faltantes = 0;
            for (var i = 1; i <= 20; i++) {
                if ($('#ans' + i + 'checksi').prop('checked')) {
                    if ((i == 1) || (i == 2) || (i == 9)) {
                        if (document.getElementById('select' + i).value == '') {
                            $('#select' + i).css({ 'border-color': 'red' });
                            $('#req' + i).fadeIn('fast');
                            faltantes++
                        } else {
                            $('#select' + i).css({ 'border-color': '#ccc' });
                            $('#req' + i).fadeOut('fast');
                        }
                    }
                    if (document.getElementById('name' + i).value == '') {
                        $('#name' + i).css({ 'border-color': 'red' });
                        $('#checksi' + i).css({ 'border-color': '#62a8ea' })
                        $('#checkno' + i).css({ 'border-color': '#62a8ea' })
                        faltantes++
                    } else {
                        $('#checksi' + i).css({ 'border-color': '#62a8ea' })
                        $('#checkno' + i).css({ 'border-color': '#62a8ea' })
                        $('#name' + i).css({ 'border-color': '#ccc' });
                    }
                } else if ($('#ans' + i + 'checkno').prop('checked')) {
                    $('#checksi' + i).css({ 'border-color': '#62a8ea' })
                    $('#checkno' + i).css({ 'border-color': '#62a8ea' })
                } else {
                    $('#checksi' + i).css({ 'border-color': 'red' })
                    $('#checkno' + i).css({ 'border-color': 'red' })
                    $('#cont-paso2').scrollTop(0);
                    faltantes++
                }
            };

            if (faltantes > 0) {
                /*
                $('.popupoverlay').fadeIn('fast');
                $('#popup-error').fadeIn('fast');

                $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
                document.getElementById('mensaje-aviso').innerHTML = "Debes responder todas las preguntas";
                $('#cont-paso3').scrollTop(0);
                return;
                */

                $('.popupoverlay').fadeIn('fast');
                $('#popupFin').fadeIn('fast');
                $('#popupFin .icon .far').addClass('fa-check-circle');
                document.getElementById('mensajeFin').innerHTML = "Debes responder todas las preguntas.";
                $('#cont-paso3').scrollTop(0);
                return;
            }

            // Guardamos información del cuestionario

            vm.cuestionario.id_precliente = window.aplicacionDatoUsuario.IdPrecliente;
            vm.cuestionario.id_usuario = window.aplicacionDatoUsuario.IdUsuario;;

            /*
            vm.cuestionario.id_precliente = 1;
            vm.cuestionario.id_usuario = 2;
            vm.cuestionario.respuesta01 = "1";
            vm.cuestionario.respuesta02 = "0";
            vm.cuestionario.respuesta03 = "0";
            vm.cuestionario.respuesta04 = "1";
            vm.cuestionario.respuesta05 = "1";
            vm.cuestionario.respuesta06 = "0";
            vm.cuestionario.respuesta07 = "0";
            vm.cuestionario.respuesta08 = "1";
            vm.cuestionario.respuesta09 = "1";
            vm.cuestionario.respuesta10 = "0";
            vm.cuestionario.respuesta11 = "0";
            vm.cuestionario.respuesta12 = "1";
            vm.cuestionario.respuesta13 = "1";
            vm.cuestionario.respuesta14 = "0";
            vm.cuestionario.respuesta15 = "0";
            vm.cuestionario.respuesta16 = "1";
            vm.cuestionario.respuesta17 = "1";
            vm.cuestionario.respuesta18 = "0";
            vm.cuestionario.respuesta19 = "0";
            vm.cuestionario.respuesta20 = "1";
            vm.cuestionario.observacion01 = "o1";
            vm.cuestionario.observacion02 = "o2";
            vm.cuestionario.observacion03 = "o3";
            vm.cuestionario.observacion04 = "o4";
            vm.cuestionario.observacion05 = "o5";
            vm.cuestionario.observacion06 = "o6";
            vm.cuestionario.observacion07 = "o7";
            vm.cuestionario.observacion08 = "o8";
            vm.cuestionario.observacion09 = "o9";
            vm.cuestionario.observacion10 = "o10";
            vm.cuestionario.observacion11 = "o11";
            vm.cuestionario.observacion12 = "o12";
            vm.cuestionario.observacion13 = "o13";
            vm.cuestionario.observacion14 = "o14";
            vm.cuestionario.observacion15 = "o15";
            vm.cuestionario.observacion16 = "o16";
            vm.cuestionario.observacion17 = "o17";
            vm.cuestionario.observacion18 = "o18";
            vm.cuestionario.observacion19 = "o19";
            vm.cuestionario.observacion20 = "o20";
            vm.cuestionario.certificacion1 = "c1";
            vm.cuestionario.certificacion2 = "c2";
            vm.cuestionario.numero_puertos = "np";
            */


            $registroClienteService.guardaCuestionario(vm.cuestionario).then(function (data) {
                var resultado = data.data.resultado;
                if (data.data.resultado) {
                    /*
                    $('.popupoverlay').fadeIn('fast');
                    $('#popup').fadeIn('fast');

                    $('#popup .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensaje').innerHTML = "Se guardó correctamente la información.";
                    $('#cont-paso3').scrollTop(0);

                    // Activamos tabs y establecemos estilos
                    $('.menu-sections .btn-operaciones').removeClass('active');
                    $('#paso3').addClass('visited');
                    $('#icon-t1-3').removeClass('fas fa-lock');
                    $('#icon-t1-3').addClass('far fa-check-circle');

                    $('#paso4').addClass('active');
                    $('#paso4').prop('disabled', false);

                    $('#cont-paso1').fadeOut('fast');
                    $('#cont-paso2').fadeOut('fast');
                    $('#cont-paso3').fadeOut('fast');
                    $('#cont-paso4').fadeIn('fast');
                    */
                    $('.popupoverlay').fadeIn('fast');
                    $('#popupCuestionesSeguridad').fadeIn('fast');
                    $('#popupCuestionesSeguridad .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensajeCuestionesSeguridad').innerHTML = "Se guardó correctamente la información.";
                }
                else {
                    modalError(data.data.mensaje);
                }
            }, function (error) {
                console.log("error", error);
            })
        };

        vm.agregarBanco = function (banco) {
            if (validarCampoBanco(banco)) {
                banco.UsuarioCreacion = 'Test';
                vm.modeloBanco.push(banco);
                vm.banco = {};
                filasBancos++;
                $('#req-table2').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        }

        vm.eliminarFilaBanco = function (index) {
            vm.modeloBanco.splice(index, 1);
            filasBancos--;
        }

        vm.editarFilaBanco = function (index) {
            window.editFilas(index)
        }

        vm.actualizarFilaBanco = function (index) {
            window.saveFilas(index)
        }

        vm.agregarContacto = function (contacto) {
            if (validarCampoContacto(contacto)) {
                contacto.UsuarioCreacion = 'Test';
                vm.modeloContacto.push(contacto);
                vm.contacto = {};
                filasContactos++;
                $('#req-table1').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        }

        vm.eliminarFilaContacto = function (index) {
            vm.modeloContacto.splice(index, 1);
            filasContactos--;
        }

        vm.editarFilaContacto = function (index) {
            window.editFilas(index)
        }

        vm.actualizarFilaContacto = function (index) {
            window.saveFilas(index)
        }

        /*
        $registroClienteService.ObtenerPaises().then(function (data) {
            vm.Paises = data.data;
            vm.actualizarEstados();
            vm.actualizarCiudades();
        }, function (error) {
            console.log("error", error);
        })
        */

        /*
        vm.actualizarEstados = function () {
            $registroClienteService.ObtenerEstados({ id_pais: vm.Pais }).then(function (data) {
                vm.Estados = data.data;
            }, function (error) {
                console.log("error", error);
            })
        }
        */

        /*
        vm.actualizarCiudades = function () {
            $registroClienteService.ObtenerCiudades({ id_estado: vm.Estado }).then(function (data) {
                vm.Ciudades = data.data;
            }, function (error) {
                console.log("error", error);
            })
        }
        */

        $registroClienteService.ObtenerPatentes().then(function (data) {
            vm.Patentes = data.data;

        }, function (error) {
            console.log("error", error);
        })



        $registroClienteService.ObtieneDatosCliente(usuario).then(function (data) {
            var v = data.data;
            console.log("data.data", data.data);
            if (v.Banderilla) // aun no se completa 
            {
                $('#paso2').prop('disabled', true);
                $('#paso3').prop('disabled', true);
                $('#paso4').prop('disabled', true);

                //$(".btn-operaciones").prop("disabled", false);

                //index
                vm.modelo.IdPrecliente = v.IdPreCliente;

                vm.modelo.RepresentanteLegal = v.RepresentanteLegal;
                if (v.RepresentanteLegal != "") {
                    $('#paso2').prop('disabled', false);
                    $('.menu-sections .btn-operaciones').removeClass('active');
                    $('#paso1').addClass('visited');
                    $('#icon-t1-1').removeClass('fa-list-alt');
                    $('#icon-t1-1').addClass('fa-check-circle');
                }
                else {
                    return;
                }

                //Datos cliente
                vm.modelo.NombreFiscal = v.NombreFiscal;
                vm.modelo.RFC = v.RFC;
                vm.modelo.NombreComercial = v.NombreComercial;
                vm.modelo.Calle = v.Calle;

                vm.modelo.NoExt = v.NoExt;
                vm.modelo.NoInt = v.NoInt;
                vm.modelo.Colonia = v.Colonia;
                vm.modelo.CP = parseInt(v.CP);
                vm.modelo.Telefono = v.Telefono;

                

                var _pais = {};
                _pais.Id = v.IdPais;
                temppais = _pais.Id;
                var _estado = {};
                _estado.Id = v.IdEstado;
                tempestado = _estado.Id;
                tempciudad = v.IdCiudad;
                cargarPaises();
                //cargaestados();
                //vm.obtenerCiudad(_estado);

                for (var i = 0; i < v.Contacto.length; i++) {
                    vm.agregarContacto(v.Contacto[i]);
                }

                for (var i = 0; i < v.Cuenta.length; i++) {
                    vm.agregarBanco(v.Cuenta[i]);
                }

                //datos adicionales 
                vm.modelo.Giro = v.Giro;
                if (v.Giro != "") {
                    $('#paso3').prop('disabled', false);
                    $('.menu-sections .btn-operaciones').removeClass('active');
                    $('#paso2').addClass('visited');
                    $('#icon-t1-2').removeClass('fas fa-list-ul');
                    $('#icon-t1-2').addClass('far fa-check-circle');
                }
                vm.modelo.TiempoEstablecido = v.TiempoEstablecido;
                vm.modelo.NumeroEmpleado = v.NumeroEmpleado;
                vm.modelo.VentaAnual = v.VentaAnual;
                vm.modelo.PaginaWeb = v.PaginaWeb;
                vm.modelo.PatentesOperacion = v.PatentesOperacion;
                //vm.modelo.PatentesOperacion = parseInt(v.PatentesOperacion);
                vm.modelo.FrecuentaEmbarques = v.FrecuentaEmbarques;
                vm.modelo.CorreosArriboEmbarque = v.CorreosArriboEmbarque;

                if (v.VucemCliente == true) {
                    $('#factchecksi8').prop('checked', true);
                }
                if (v.VucemGrupoei == true) {
                    $('#factcheckno8').prop('checked', true);
                }

                vm.modelo.Banco = v.Banco;
                vm.modelo.NumeroCuenta = v.NumeroCuenta;
                vm.modelo.ClabeInterbancaria = v.ClabeInterbancaria;
                vm.modelo.Moneda = v.Moneda;
                vm.modelo.SucursalBanco = v.SucursalBanco;
                vm.modelo.CiudadBanco = v.CiudadBanco;

                var strfila = "";
                for (var i = 0; i < v.Usuarios.length; i++) {
                    var r = v.Usuarios[i];
                    strfila = '';
                    strfila = '<tr class="table-rows" id="fila' + i + '"><td><input type="text" class="form-control" value="' + r.nombre + '" disabled=""></td> <td><input type="text" class="form-control" value="' + r.puesto_departamento + '" disabled=""></td><td><input type="text" class="form-control" value="' + r.telefono + '" disabled=""></td><td><input type="text" class="form-control" value="' + r.correo + '" disabled=""></td><td><input type="text" class="form-control" value="' + r.admon + '" disabled=""></td><td><input type="text" class="form-control" value="' + r.oper + '" disabled=""></td><td><i id="save' + i + '" class="fas fa-save btn-save boxtool" onclick="saveFilas(' + i + ')"><div class="tooltip">Guardar</div></i><i id="edit' + i + '" class="fas fa-pencil-alt boxtool" onclick="editFilas(' + i + ')"><div class="tooltip">Editar</div></i><i class="fas fa-trash-alt boxtool" onclick="removeFilas(' + i + ')"><div class="tooltip">Borrar</div></i></td></tr>';
                    $('#numbers3').append(strfila);
                }

                //cuestionarioa de seguridad
                if (v.Cuestionario.respuesta01 == null) {
                    v.Cuestionario.respuesta01 = v.Cuestionario.respuesta01;
                }
                else {
                    v.Cuestionario.respuesta01 = strToBool(v.Cuestionario.respuesta01);
                }

                if (v.Cuestionario.respuesta01 == true || v.Cuestionario.respuesta01 == false) {
                    $('#paso4').prop('disabled', false);
                    $('.menu-sections .btn-operaciones').removeClass('active');
                    $('#paso3').addClass('visited');
                    $('#icon-t1-3').removeClass('fas fa-lock');
                    $('#icon-t1-3').addClass('far fa-check-circle');
                }
                if (v.Cuestionario.respuesta02 == null) {
                    v.Cuestionario.respuesta02 = v.Cuestionario.respuesta02;
                }
                else {
                    v.Cuestionario.respuesta02 = strToBool(v.Cuestionario.respuesta02);
                }
                if (v.Cuestionario.respuesta03 == null) {
                    v.Cuestionario.respuesta03 = v.Cuestionario.respuesta03;
                }
                else {
                    v.Cuestionario.respuesta03 = strToBool(v.Cuestionario.respuesta03);
                }
                if (v.Cuestionario.respuesta04 == null) {
                    v.Cuestionario.respuesta04 = v.Cuestionario.respuesta04;
                }
                else {
                    v.Cuestionario.respuesta04 = strToBool(v.Cuestionario.respuesta04);
                }
                if (v.Cuestionario.respuesta05 == null) {
                    v.Cuestionario.respuesta05 = v.Cuestionario.respuesta05;
                }
                else {
                    v.Cuestionario.respuesta05 = strToBool(v.Cuestionario.respuesta05);
                }
                if (v.Cuestionario.respuesta06 == null) {
                    v.Cuestionario.respuesta06 = v.Cuestionario.respuesta06;
                }
                else {
                    v.Cuestionario.respuesta06 = strToBool(v.Cuestionario.respuesta06);
                }
                if (v.Cuestionario.respuesta07 == null) {
                    v.Cuestionario.respuesta07 = v.Cuestionario.respuesta07;
                }
                else {
                    v.Cuestionario.respuesta07 = strToBool(v.Cuestionario.respuesta07);
                }
                if (v.Cuestionario.respuesta08 == null) {
                    v.Cuestionario.respuesta08 = v.Cuestionario.respuesta08;
                }
                else {
                    v.Cuestionario.respuesta08 = strToBool(v.Cuestionario.respuesta08);
                }
                if (v.Cuestionario.respuesta09 == null) {
                    v.Cuestionario.respuesta09 = v.Cuestionario.respuesta09;
                }
                else {
                    v.Cuestionario.respuesta09 = strToBool(v.Cuestionario.respuesta09);
                }
                if (v.Cuestionario.respuesta10 == null) {
                    v.Cuestionario.respuesta10 = v.Cuestionario.respuesta10;
                }
                else {
                    v.Cuestionario.respuesta10 = strToBool(v.Cuestionario.respuesta10);
                }
                if (v.Cuestionario.respuesta11 == null) {
                    v.Cuestionario.respuesta11 = v.Cuestionario.respuesta11;
                }
                else {
                    v.Cuestionario.respuesta11 = strToBool(v.Cuestionario.respuesta11);
                }
                if (v.Cuestionario.respuesta12 == null) {
                    v.Cuestionario.respuesta12 = v.Cuestionario.respuesta12;
                }
                else {
                    v.Cuestionario.respuesta12 = strToBool(v.Cuestionario.respuesta12);
                }
                if (v.Cuestionario.respuesta13 == null) {
                    v.Cuestionario.respuesta13 = v.Cuestionario.respuesta13;
                }
                else {
                    v.Cuestionario.respuesta13 = strToBool(v.Cuestionario.respuesta13);
                }
                if (v.Cuestionario.respuesta14 == null) {
                    v.Cuestionario.respuesta14 = v.Cuestionario.respuesta14;
                }
                else {
                    v.Cuestionario.respuesta14 = strToBool(v.Cuestionario.respuesta14);
                }
                if (v.Cuestionario.respuesta15 == null) {
                    v.Cuestionario.respuesta15 = v.Cuestionario.respuesta15;
                }
                else {
                    v.Cuestionario.respuesta15 = strToBool(v.Cuestionario.respuesta15);
                }
                if (v.Cuestionario.respuesta16 == null) {
                    v.Cuestionario.respuesta16 = v.Cuestionario.respuesta16;
                }
                else {
                    v.Cuestionario.respuesta16 = strToBool(v.Cuestionario.respuesta16);
                }
                if (v.Cuestionario.respuesta17 == null) {
                    v.Cuestionario.respuesta17 = v.Cuestionario.respuesta17;
                }
                else {
                    v.Cuestionario.respuesta17 = strToBool(v.Cuestionario.respuesta17);
                }
                if (v.Cuestionario.respuesta18 == null) {
                    v.Cuestionario.respuesta18 = v.Cuestionario.respuesta18;
                }
                else {
                    v.Cuestionario.respuesta18 = strToBool(v.Cuestionario.respuesta18);
                }
                if (v.Cuestionario.respuesta19 == null) {
                    v.Cuestionario.respuesta19 = v.Cuestionario.respuesta19;
                }
                else {
                    v.Cuestionario.respuesta19 = strToBool(v.Cuestionario.respuesta19);
                }
                if (v.Cuestionario.respuesta20 == null) {
                    v.Cuestionario.respuesta20 = v.Cuestionario.respuesta20;
                }
                else {
                    v.Cuestionario.respuesta20 = strToBool(v.Cuestionario.respuesta20);
                }

                vm.cuestionario = v.Cuestionario;

                if (v.Cuestionario.respuesta01) {
                    $('.selec-a1').css({ 'visibility': 'visible', 'opacity': '1' });
                    vm.cuestionario.certificacion1 = v.Certificacion;

                }

                if (v.Cuestionario.respuesta02) {
                    $('.selec-a2').css({ 'visibility': 'visible', 'opacity': '1' });
                    vm.cuestionario.certificacion2 = v.Certificacion2;
                }

                if (v.Cuestionario.respuesta09) {

                    $('.selec-a9').css({ 'visibility': 'visible', 'opacity': '1' });
                    vm.cuestionario.numero_puertos = parseInt(v.NumeroPuertos);
                }


                //documentos
                window.numeroDocumento = v.Documentos.length;
                for (var i = 0; i < v.Documentos.length; i++) {
                    var d = v.Documentos[i];

                    reemplazaicono(d.id_documento, d.ruta_local);
                }



                // selecciona combos paises; 
                /*
                angular.forEach(vm.catalogoPais, function (pais, index) {
                    if (pais.Id === _pais.Id) {
                        vm.modelo.Pais = vm.catalogoPais[index];
                    }
                });
				*/

                //cargaestados();
                //cargaciudad();

                vm.obtenerDatosCartaEnc();
            }
        }, function (error) {
            console.log("error get datos cliente", error);
        })

        function cargarPaises() {

            if (typeof vm.catalogoPais.length !== "undefined") {
                angular.forEach(vm.catalogoPais, function (pais, index) {
                    if (pais.id === temppais) {
                        vm.modelo.Pais = vm.catalogoPais[index];
                        vm.obtenerEstado(temppais);
                    }
                });
            }
            else {
                setTimeout(cargarPaises, 250);
            }
        }

        vm.obtenerDatosCartaEnc = function () {
            $registroClienteService.obtenerDatosCartaenc({ id_usuario: usuario }).then(function (data) {
                if (data.data.resultado) {
                    //console.log("datos carta enc", data.data.data);
                    var datosCarta = data.data.data[0];

                    vm.Calle = vm.modelo.Calle;//datosCarta.domicilio_fiscal_calle;
                    vm.Colonia = vm.modelo.Colonia;//datosCarta.domicilio_fiscal_colonia;
                    vm.CP = vm.modelo.CP;//datosCarta.domicilio_fiscal_cp;
                    //vm.Estado = $("#in12 option:selected").text();//datosCarta.domicilio_fiscal_estado;
                    //vm.Municipio = $("#in10 option:selected").text();//datosCarta.domicilio_fiscal_municipio;
                    //vm.Ciudad = $("#in10 option:selected").text();//datosCarta.domicilio_fiscal_ciudad;
                    vm.NoInt = vm.modelo.NoInt;//datosCarta.domicilio_fiscal_no_int;
                    vm.NoExt = vm.modelo.NoExt;//datosCarta.domicilio_fiscal_no_ext;
                    vm.Escritura = datosCarta.numero_escritura;
                    vm.Notario = datosCarta.nombre_notario;
                    vm.Notaria = datosCarta.numero_notaria;
                    vm.CdNotariado = datosCarta.ciudad_notariado;
                    vm.EdoNotariado = datosCarta.estado_notariado;
                    if (datosCarta.membrete_empresa != "" && datosCarta.membrete_empresa != null) {
                        vm.Membrete = datosCarta.membrete_empresa;
                    }
                    vm.PeriodoInicio = datosCarta.periodo_compredido_inicio;
                    vm.PeriodoFin = datosCarta.periodo_compredido_fin;

                    if (datosCarta.patente_carta_encomienda != null && datosCarta.patente_carta_encomienda != ""
                        && datosCarta.patente_carta_encomienda != "-- S||DIRECCION EJEMPLO") {
                        vm.Patente = datosCarta.patente_carta_encomienda;
                        //console.log("patente", datosCarta.patente_carta_encomienda);
                        vm.NombrePatente = datosCarta.patente_carta_encomienda.split('|')[1];
                        vm.DireccionPatente = datosCarta.patente_carta_encomienda.split('|')[2];
                    }
                }
                else {
                    console.log("error al obtener datos de carta encomienda", data.data.mensaje);
                }
            }, function (error) {
                console.log("error", error);
            })
        }
        vm.obtenerNombrePatente = function () {
            vm.NombrePatente = vm.Patente.split('|')[1];
            vm.DireccionPatente = vm.Patente.split('|')[2];
        }

        vm.guardarCamposCartaEnc = function () {

            //console.log(vm.Calle);

            $(".error").remove();

            var guardar = true;

            //posicionar scroll de modal en primer elemento requerido
            var requeridos = $('input[type=text]').filter('[required]:visible');//$("#exampleModal :input:required"); //not([readonly='readonly'])

            var scrollPos = false;

            requeridos.each(function () {
                $(this).css("border-color", "");
                if ($(this).val().trim() == "") {
                    if (!scrollPos) {
                        scrollPos = true;

                        var b = $('#bodyCartaEnc');
                        var row = $(this);

                        b.scrollTop(row.offset().top - (b.height() / 2));
                        $(this).focus();
                    }
                    $(this).css({ 'border-color': '#f92626' });//.parent().append('<label class="error" style="color:red;font-size:8px">*</label>');
                    guardar = false;
                }
            });

            //$('select[name=selectPatente]').each(function () {
            //    $(this).css("border-color", "");
            //    if ($(this).find(":selected").index() == 0) {
            //        $(this).css({ 'border-color': '#f92626' });//.parent().append('<label class="error" style="color:red;font-size:8px">*</label>');
            //        guardar = false;
            //    }

            //    if (!scrollPos) {
            //        scrollPos = true;

            //        var b = $('#bodyCartaEnc');
            //        var row = $(this);

            //        b.scrollTop(row.offset().top - (b.height() / 2));
            //        $(this).focus();

            //    }
            //});

            var usuario = window.aplicacionDatoUsuario.IdUsuario;
            var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

            if (guardar) {
                $registroClienteService.guardarCamposCartaEnc({
                    id_usuario: usuario,
                    domicilio_fiscal_calle: vm.Calle,
                    domicilio_fiscal_colonia: vm.Colonia,
                    domicilio_fiscal_cp: vm.CP,
                    domicilio_fiscal_ciudad: vm.Ciudad,
                    domicilio_fiscal_municipio: vm.Municipio,
                    domicilio_fiscal_estado: vm.Estado,
                    domicilio_fiscal_no_ext: vm.NoExt,
                    domicilio_fiscal_no_int: vm.NoInt,
                    numero_escritura: vm.Escritura,
                    nombre_notario: vm.Notario,
                    numero_notaria: vm.Notaria,
                    ciudad_notariado: vm.CdNotariado,
                    estado_notariado: vm.EdoNotariado,
                    membrete_empresa: vm.Membrete,
                    periodo_compredido_inicio: vm.PeriodoInicio,
                    periodo_compredido_fin: vm.PeriodoFin,
                    patente_carta_encomienda: vm.Patente.split('|')[0]
                }).then(function (data) {

                    //console.log(data);
                    if (data.data.resultado == null) {
                        //console.log(data);
                        modalError(data.data.mensaje);
                    } else {
                        //$("#exampleModal").modal("hide");
                        modalOk("Información de carta encomienda actualizada!");
                    }
                }, function (error) {
                    console.log("error", error);
                })
            }
        }

        vm.generarCartaEnc = function () {

            var usuario = window.aplicacionDatoUsuario.IdUsuario;
            var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;


            var guardar = true;

            //posicionar scroll de modal en primer elemento requerido
            var requeridos = $('input[type=text]').filter('[required]:visible');//$("#exampleModal :input[type=text]:not([readonly='readonly'])");

            var scrollPos = false;

            requeridos.each(function () {
                $(this).css("border-color", "");
                if ($(this).val().trim() == "") {
                    if (!scrollPos) {
                        scrollPos = true;

                        var b = $('#bodyCartaEnc');
                        var row = $(this);

                        b.scrollTop(row.offset().top - (b.height() / 2));
                        $(this).focus();
                    }
                    $(this).css({ 'border-color': '#f92626' });//.parent().append('<label class="error" style="color:red;font-size:8px">*</label>');
                    guardar = false;
                }
            });
            /*
            $('select[name=selectPatente]').each(function () {
                $(this).css("border-color", "");
                if ($(this).find(":selected").index() == 0) {
                    $(this).css({ 'border-color': '#f92626' });//.parent().append('<label class="error" style="color:red;font-size:8px">*</label>');
                    guardar = false;
                }

                if (!scrollPos) {
                    scrollPos = true;

                    var b = $('#bodyCartaEnc');
                    var row = $(this);

                    b.scrollTop(row.offset().top - (b.height() / 2));
                    $(this).focus();

                }
            });
            */
            if (guardar) {
                $registroClienteService.generarCartaEnc(
                    {
                        IdPrecliente: idPrecliente,
                        IdUsuario: usuario,
                        NombreNotarioPublico: vm.Notario,
                        PeriodoCompredidoInicio: vm.PeriodoInicio,
                        PeriodoCompredidoFin: vm.PeriodoFin,
                        CiudadNotariado: vm.CdNotariado,
                        EstadoNotariado: vm.EdoNotariado,
                        MembreteEmpresa: vm.Membrete,
                        NumeroEscritura: vm.Escritura,
                        NumeroNotaria: vm.Notaria,
                        NombreAgenteAduanal: vm.NombrePatente,
                        Patente: vm.Patente.split('|')[0],
                        DirreccionPatente: vm.DireccionPatente

                    }).then(function (data) {
                        var response = data.data;
                        if (response.resultado) {
                            window.location.href = UrlDescargaDoc + "?name=" + response.documento;
                        } else {
                            modalError(response.mensaje);
                        }
                    }, function (error) {
                        console.log("error", error);
                    })
            }
        }
        //---js----//

        function validarCampoBanco(banco) {
            if (banco) {
                if (!banco.Banco || !banco.NumeroCuenta || !banco.PatentesAutorizadas || !banco.Aduana) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        function validarCampoContacto(contacto) {
            if (contacto) {
                if (!contacto.Area || !contacto.Nombre || !contacto.Correo || !contacto.Telefono || !contacto.PuestoDepartamento) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        function modalError(mensaje) {
            /*
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');
            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensaje-aviso').innerHTML = mensaje;
			*/

            $('.popupoverlay').fadeIn('fast');
            $('#popupFin').fadeIn('fast');
            $('#popupFin .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensajeFin').innerHTML = mensaje;
        };

        function modalExito() {
            $('.popupoverlay').fadeIn('fast');
            $('#popupDatosCliente').fadeIn('fast');
            $('#popupDatosCliente .icon i').addClass('far fa-check-circle');
            document.getElementById('mensajeDatosCliente').innerHTML = "Se guardó correctamente la información.";
        }

        function modalExitoDocumento() {
            $('.popupoverlay').fadeIn('fast');
            $('#popupok').fadeIn('fast');
            $('#popupok .icon i').addClass('far fa-check-circle');
            document.getElementById('mensajeok').innerHTML = "Favor de cargar todos los documentos";
        }

        function modalOk() {
            $('.popupoverlay').fadeIn('fast');
            $('#popupok').fadeIn('fast');

            $('#popupok .icon i').addClass('far fa-check-circle');
            document.getElementById('mensajeok').innerHTML = "Se guardó correctamente la información.";
        }

        function cargaciudad() {
            if (typeof vm.catalogoCiudad.length !== "undefined") {
                angular.forEach(vm.catalogoCiudad, function (ciudad, index) {
                    if (ciudad.id == tempciudad) {
                        vm.modelo.Ciudad = vm.catalogoCiudad[index];
                    }
                });
            }
            else {

                setTimeout(cargaciudad, 250);
            }
        }

        function cargaestados() {
            if (typeof vm.catalogoEstado.length !== "undefined") {
                angular.forEach(vm.catalogoEstado, function (estado, index) {
                    if (estado.id == tempestado) {
                        vm.modelo.Estado = vm.catalogoEstado[index];
                        vm.obtenerCiudad(tempestado);
                    }
                });
            }
            else {
                setTimeout(cargaestados, 250);
            }
        }

        $('#exampleModal').on('shown.bs.modal', function () {

            $(".modal-body :input:enabled:visible:first").focus().select();

            $("#inlineFormInput2").empty();
            $("#inlineFormInput3").empty();
            $("#inlineFormInput19").empty();
            $("#inlineFormInput16").empty();
            $("#inlineFormInput18").empty();

            $("#inlineFormInput11").empty();
            $("#inlineFormInput12").empty();
            $("#inlineFormInput13").empty();
            $("#inlineFormInput14").empty();

            vm.Estado = "";
            vm.Municipio = "";
            vm.Ciudad = "";
            vm.Calle = "";
            vm.NoExt = "";
            vm.NoInt = "";
            vm.Colonia = "";

            if ($("#in12").prop('selectedIndex') > 0) {//estado
                vm.Estado = $("#in12 option:selected").text();//datosCarta.domicilio_fiscal_estado;
                $("#inlineFormInput3").val($("#in12 option:selected").text());
                $("#inlineFormInput19").val(vm.Estado);

            }

            if ($("#in10").prop('selectedIndex') > 0) {//ciudad
                vm.Municipio = $("#in10 option:selected").text();//datosCarta.domicilio_fiscal_municipio;
                vm.Ciudad = $("#in10 option:selected").text();//datosCarta.domicilio_fiscal_ciudad;
                $("#inlineFormInput2").val($("#in10 option:selected").text());
                $("#inlineFormInput16").val(vm.Municipio);
                $("#inlineFormInput18").val(vm.Ciudad);
            }

            vm.Calle = $("#in6").val();
            $("#inlineFormInput11").val($("#in6").val());
            vm.NoExt = $("#in7").val();
            $("#inlineFormInput12").val($("#in7").val());
            vm.NoInt = $("#in8").val();
            $("#inlineFormInput13").val($("#in8").val());
            vm.Colonia = $("#in9").val();
            $("#inlineFormInput14").val($("#in9").val());
            vm.CP = $("#in11").val();
            $("#inlineFormInput17").val($("#in11").val());
        });

        $('#exampleModal').on('hide.bs.modal', function () {

            var requeridos = $("#exampleModal :input[type=text]:not([readonly='readonly'])");

            requeridos.each(function () {
                $(this).css("border-color", "");
            });

            $('select[name=selectPatente]').each(function () {
                $(this).css("border-color", "");
            });
        });

    }

})();

function strToBool(val) {
    if (val == "true") return true;
    else return false;
}

