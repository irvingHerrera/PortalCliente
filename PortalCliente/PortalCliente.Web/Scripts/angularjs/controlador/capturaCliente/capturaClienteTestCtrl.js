(function () {
    'use strict';

    angular
        .module('app')
        .controller('capturaClienteTestCtrl', capturaCliente);

    capturaCliente.$inject = ['$scope', '$capturaClienteService', '$catalogoService', '$document', '$q'];

    function capturaCliente($scope, $capturaClienteService, $catalogoService, $document, $q) {
        var vm = $scope;
        vm.inputDisable = true;
        vm.id_usuario = window.aplicacionDatoUsuario.IdUsuario;
        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        vm.model = {};
        vm.model.DatosCliente = {};
        vm.model.DatoAdicional = {};
        vm.model.UsuarioAudabook = [];
        vm.model.Cuestionario = {};

        function obtenerPromesas() {
            var promesaCapturaCliente = $capturaClienteService.obtenerInfoCliente({ id_usuario: vm.id_usuario });
            var promesaContactoCliente = $capturaClienteService.obtenerContactosCliente({ id_precliente: 2 });
            var promesaCuenta = $capturaClienteService.obtenerPECACliente({ id_precliente: 2 });
            var promesaUsuarioAduabook = $capturaClienteService.obtenerUsrsAduabookCliente({ id_precliente: 2 });
            var promesaCuestionario = $capturaClienteService.obtenerCuestionarioCliente({ id_precliente: 2 });
            var promesaDocumento = $capturaClienteService.obtenerDocumentosCliente({ id_precliente: 2 });
            var promesaPais = $catalogoService.obtenerPais();

            return $q.all({
                promesaCapturaCliente,
                promesaContactoCliente,
                promesaCuenta,
                promesaUsuarioAduabook,
                promesaCuestionario,
                promesaDocumento,
                promesaPais
            });

        }

        function resolverPromesa(promesaGeneral) {

            promesaGeneral.then(function (promesas) {
                console.log("promesas.promesaCapturaCliente", promesas.promesaCapturaCliente);
                //console.log("promesas.promesaContactoCliente", promesas.promesaContactoCliente);
                //console.log("promesas.promesaCuenta", promesas.promesaCuenta);
                console.log("promesas.promesaUsuarioAduabook", promesas.promesaUsuarioAduabook);
                //console.log("promesas.promesaCuestionario", promesas.promesaCuestionario);
                //console.log("promesas.promesaDocumento", promesas.promesaDocumento);

                if (promesas.promesaCapturaCliente.data.resultado) {
                    var infoCliente = promesas.promesaCapturaCliente.data.data[0];
                    vm.model.DatosCliente.IdPrecliente = infoCliente.id_precliente;
                    vm.model.DatosCliente.IdUsuario = infoCliente.id_usuario;
                    vm.model.DatosCliente.RepresentanteLegal = infoCliente.representante_legal;
                    vm.model.DatosCliente.NombreFiscal = infoCliente.nombre_fiscal;
                    vm.model.DatosCliente.Calle = infoCliente.calle;
                    vm.model.DatosCliente.NoExt = infoCliente.no_ext;
                    vm.model.DatosCliente.NoInt = infoCliente.no_int;
                    vm.model.DatosCliente.RFC = infoCliente.rfc;
                    vm.model.DatosCliente.NombreComercial = infoCliente.nombre_comercial;
                    vm.model.DatosCliente.Colonia = infoCliente.colonia;
                    vm.model.DatosCliente.CP = infoCliente.cp;
                    vm.model.DatosCliente.IdPais = infoCliente.id_pais;
                    vm.model.DatosCliente.IdEstado = infoCliente.id_estado;
                    vm.model.DatosCliente.IdCiudad = infoCliente.id_ciudad;
                    /*vm.model.DatosCliente.Pais = infoCliente.pais;
                    vm.model.DatosCliente.Ciudad = infoCliente.ciudad;
                    vm.model.DatosCliente.Estado = infoCliente.estado;*/
                    vm.model.DatosCliente.Telefono = infoCliente.telefono;

                    vm.model.DatosCliente.Banco = infoCliente.banco;
                    vm.model.DatosCliente.NumeroCuenta = infoCliente.numero_cuenta,
                        vm.model.DatosCliente.ClabeInterbancaria = infoCliente.clabe_interbancaria;
                    vm.model.DatosCliente.Moneda = infoCliente.moneda;
                    vm.model.DatosCliente.SucursalBanco = infoCliente.sucursal_banco;
                    vm.model.DatosCliente.CiudadBanco = infoCliente.ciudad_banco;

                    vm.model.DatoAdicional.Giro = infoCliente.giro;
                    vm.model.DatoAdicional.TiempoEstablecido = infoCliente.tiempo_establecido;
                    vm.model.DatoAdicional.NumeroEmpleados = infoCliente.numero_empleados;
                    vm.model.DatoAdicional.VentasAnuales = infoCliente.ventas_anuales;
                    vm.model.DatoAdicional.PaginaWeb = infoCliente.pagina_web;
                    vm.model.DatoAdicional.PatemtesOperacion = infoCliente.patentes_operacion;
                    vm.model.DatoAdicional.Frecuencia = infoCliente.frecuencia_embarques;
                    vm.model.DatoAdicional.CorreoArribo = infoCliente.correos_arribo_embarque;
                    vm.model.DatoAdicional.VucemC = infoCliente.vucem_cliente;
                    vm.model.DatoAdicional.VucemG = infoCliente.vucem_grupoei;
                    vm.model.DatoAdicional.ConCartaEncomienda = infoCliente.con_carta_encomienda_respaldo;
                    vm.model.DatoAdicional.MotivoCartaEncomienda = infoCliente.motivo_sin_carta_encomienda_respaldo;

                    console.log(" vm.model.DatoAdicional", vm.model.DatoAdicional);

                } else {
                    console.log("Error", promesas.promesaCapturaCliente.data.mensaje);
                }

                if (promesas.promesaContactoCliente.data.resultado) {
                    var contactos = promesas.promesaContactoCliente.data.data
                    vm.model.DatosCliente.Contacto = [];

                    angular.forEach(contactos, function (elemento, index) {
                        vm.model.DatosCliente.Contacto.push({
                            IdPrecliente: vm.model.DatosCliente.IdPrecliente,
                            Nombre: elemento.nombre,
                            Correo: elemento.correo,
                            Telefono: elemento.telefono,
                            Area: elemento.area,
                            PuestoDepartamento: elemento.puesto_departamento
                        });
                    });



                    console.log("vm.model.DatosCliente.Contacto", vm.model.DatosCliente);

                } else {
                    console.log("Error", promesas.promesaContactoCliente.data.mensaje);
                }

                if (promesas.promesaCuenta.data.resultado) {

                    var cuentas = promesas.promesaCuenta.data.data;

                    vm.model.DatosCliente.Cuenta = [];

                    angular.forEach(cuentas, function (elemento, index) {
                        vm.model.DatosCliente.Cuenta.push({
                            IdPrecliente: vm.model.DatosCliente.IdPrecliente,
                            Banco: elemento.banco,
                            NumeroCuenta: elemento.numero_cuenta,
                            Identificador: elemento.identificador,
                            PatentesAutorizadas: elemento.patentes_autorizadas,
                            Aduana: elemento.aduana
                        });
                    })
                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaUsuarioAduabook.data.resultado) {
                    var usuario = promesas.promesaUsuarioAduabook.data.data;
                    console.log("usuario", usuario);
                    angular.forEach(usuario, function (elemento, index) {
                        vm.model.UsuarioAudabook.push({
                            Admon: elemento.admon,
                            Correo: elemento.correo,
                            Nombre: elemento.nombre,
                            Oper: elemento.oper,
                            PuestoDepartamento: elemento.puesto_departamento,
                            Telefono: elemento.telefono
                        });
                    });

                } else {
                    console.log("Error", promesas.promesaUsuarioAduabook.data.mensaje);
                }

                if (promesas.promesaCuestionario.data.resultado) {

                    vm.model.Cuestionario.id_precliente = vm.model.DatosCliente.IdPrecliente;
                    vm.model.Cuestionario.id_usuario = vm.model.DatosCliente.IdPrecliente;
                    vm.model.Cuestionario.respuesta01 = promesas.promesaCuestionario.data.data[0].respuesta;
                    vm.model.Cuestionario.respuesta02 = promesas.promesaCuestionario.data.data[1].respuesta;
                    vm.model.Cuestionario.respuesta03 = promesas.promesaCuestionario.data.data[2].respuesta;
                    vm.model.Cuestionario.respuesta04 = promesas.promesaCuestionario.data.data[3].respuesta;
                    vm.model.Cuestionario.respuesta05 = promesas.promesaCuestionario.data.data[4].respuesta;
                    vm.model.Cuestionario.respuesta06 = promesas.promesaCuestionario.data.data[5].respuesta;
                    vm.model.Cuestionario.respuesta07 = promesas.promesaCuestionario.data.data[6].respuesta;
                    vm.model.Cuestionario.respuesta08 = promesas.promesaCuestionario.data.data[7].respuesta;
                    vm.model.Cuestionario.respuesta09 = promesas.promesaCuestionario.data.data[8].respuesta;
                    vm.model.Cuestionario.respuesta10 = promesas.promesaCuestionario.data.data[9].respuesta;
                    vm.model.Cuestionario.respuesta11 = promesas.promesaCuestionario.data.data[10].respuesta;
                    vm.model.Cuestionario.respuesta12 = promesas.promesaCuestionario.data.data[11].respuesta;
                    vm.model.Cuestionario.respuesta13 = promesas.promesaCuestionario.data.data[12].respuesta;
                    vm.model.Cuestionario.respuesta14 = promesas.promesaCuestionario.data.data[13].respuesta;
                    vm.model.Cuestionario.respuesta15 = promesas.promesaCuestionario.data.data[14].respuesta;
                    vm.model.Cuestionario.respuesta16 = promesas.promesaCuestionario.data.data[15].respuesta;
                    vm.model.Cuestionario.respuesta17 = promesas.promesaCuestionario.data.data[16].respuesta;
                    vm.model.Cuestionario.respuesta18 = promesas.promesaCuestionario.data.data[17].respuesta;
                    vm.model.Cuestionario.respuesta19 = promesas.promesaCuestionario.data.data[18].respuesta;
                    vm.model.Cuestionario.respuesta20 = promesas.promesaCuestionario.data.data[19].respuesta;

                    vm.model.Cuestionario.observacion01 = promesas.promesaCuestionario.data.data[0].observacion;
                    vm.model.Cuestionario.observacion02 = promesas.promesaCuestionario.data.data[1].observacion;
                    vm.model.Cuestionario.observacion03 = promesas.promesaCuestionario.data.data[2].observacion;
                    vm.model.Cuestionario.observacion04 = promesas.promesaCuestionario.data.data[3].observacion;
                    vm.model.Cuestionario.observacion05 = promesas.promesaCuestionario.data.data[4].observacion;
                    vm.model.Cuestionario.observacion06 = promesas.promesaCuestionario.data.data[5].observacion;
                    vm.model.Cuestionario.observacion07 = promesas.promesaCuestionario.data.data[6].observacion;
                    vm.model.Cuestionario.observacion08 = promesas.promesaCuestionario.data.data[7].observacion;
                    vm.model.Cuestionario.observacion09 = promesas.promesaCuestionario.data.data[8].observacion;
                    vm.model.Cuestionario.observacion10 = promesas.promesaCuestionario.data.data[9].observacion;
                    vm.model.Cuestionario.observacion11 = promesas.promesaCuestionario.data.data[10].observacion;
                    vm.model.Cuestionario.observacion12 = promesas.promesaCuestionario.data.data[11].observacion;
                    vm.model.Cuestionario.observacion13 = promesas.promesaCuestionario.data.data[12].observacion;
                    vm.model.Cuestionario.observacion14 = promesas.promesaCuestionario.data.data[13].observacion;
                    vm.model.Cuestionario.observacion15 = promesas.promesaCuestionario.data.data[14].observacion;
                    vm.model.Cuestionario.observacion16 = promesas.promesaCuestionario.data.data[15].observacion;
                    vm.model.Cuestionario.observacion17 = promesas.promesaCuestionario.data.data[16].observacion;
                    vm.model.Cuestionario.observacion18 = promesas.promesaCuestionario.data.data[17].observacion;
                    vm.model.Cuestionario.observacion19 = promesas.promesaCuestionario.data.data[18].observacion;
                    vm.model.Cuestionario.observacion20 = promesas.promesaCuestionario.data.data[19].observacion;
                    vm.model.Cuestionario.certificacion1 = promesas.promesaCapturaCliente.data.data[0].certificacion1;
                    vm.model.Cuestionario.certificacion2 = promesas.promesaCapturaCliente.data.data[0].certificacion2;
                    vm.model.Cuestionario.numero_puertos = parseInt(promesas.promesaCapturaCliente.data.data[0].numero_puertos);

                } else {
                    console.log("Error", promesas.promesaCuestionario.data.mensaje);
                }

                if (promesas.promesaDocumento.data.resultado) {
                    var documento = promesas.promesaDocumento.data.data;

                    vm.Documentos = promesas.promesaDocumento.data.data;
                    if (vm.Documentos.length == 9) {
                        vm.Documentos.splice(1, 0, { "ruta_local": "-1" });
                        //console.log(vm.Documentos);
                    }
                    llenaIframeSrc();

                    vm.Documento = {};

                    angular.forEach(documento, function (elemento, index) {

                        var nombreArchivo = elemento.ruta_local.substring(elemento.ruta_local.lastIndexOf("\\") + 1, elemento.ruta_local.length);

                        switch (elemento.id_documento) {
                            case 1://Carta Encomienda
                                vm.Documento.CartaEncomienda = elemento;
                                vm.Documento.CartaEncomienda.NombreAchivo = nombreArchivo;
                                break;
                            case 2://Carta Encomienda Respaldo
                                vm.Documento.CartaEncomiendaRespaldo = elemento;
                                vm.Documento.CartaEncomiendaRespaldo.NombreAchivo = nombreArchivo;
                                break;
                            case 3://Constancia de situación del cliente
                                vm.Documento.ConstanciaCliente = elemento;
                                vm.Documento.ConstanciaCliente.NombreAchivo = nombreArchivo;
                                break;
                            case 4://Comprobante de domicilio de la empresa no mayor a 2 meses
                                vm.Documento.ComprobanteDomicilio = elemento;
                                vm.Documento.ComprobanteDomicilio.NombreAchivo = nombreArchivo;
                                break;
                            case 5://Acta constitutiva de la empresa
                                vm.Documento.ActaContitutiva = elemento;
                                vm.Documento.ActaContitutiva.NombreAchivo = nombreArchivo;
                                break;
                            case 6://Poder Notarial del representante y/o apoderado legal
                                vm.Documento.PoderNotarial = elemento;
                                vm.Documento.PoderNotarial.NombreAchivo = nombreArchivo;
                                break;
                            case 7://Identificación oficial con foto y firma
                                vm.Documento.Identificacion = elemento;
                                vm.Documento.Identificacion.NombreAchivo = nombreArchivo;
                                break;
                            case 8://RFC del representante lega
                                vm.Documento.RFC = elemento;
                                vm.Documento.RFC.NombreAchivo = nombreArchivo;
                                break;
                            case 9://Encargo Conferido a favor de cada uno de los agentes aduanales
                                vm.Documento.Encargado = elemento;
                                vm.Documento.Encargado.NombreAchivo = nombreArchivo;
                                break;
                            case 10://Fotografías recientes del establecimiento
                                vm.Documento.Fotografia = elemento;
                                vm.Documento.Fotografia.NombreAchivo = nombreArchivo;
                                break;
                            default:
                        }
                    });

                } else {
                    console.log("Error", promesas.promesaDocumento.data.mensaje);
                }

                if (promesas.promesaPais.data.resultado) {
                    vm.catalogoPais = promesas.promesaPais.data.dato;
                    angular.forEach(vm.catalogoPais, function (pais, index) {
                        if (pais.Descripcion == vm.model.DatosCliente.Pais) {
                            vm.Pais = vm.catalogoPais[index];
                            vm.obtenerEstado(vm.Pais);
                        }
                    });
                } else {
                    console.log("Error", promesas.promesaPais.data.mensaje);
                }
            },
                function (error) {
                    console.log("Error", error);
                });

        }

        function cargarRegistroCliente() {
            var promesaGeneral = obtenerPromesas();
            resolverPromesa(promesaGeneral);
        }

        vm.init = function () {
            cargarRegistroCliente();
        }


        //para la edicion 
        vm.test = function () {
            console.log("test");
            vm.inputDisable = !vm.inputDisable;
        }

        //***Grid contacto**//
        vm.agregarContacto = function (contacto) {
            if (validarCampoContacto(contacto)) {
                console.log("agregar contacto", contacto);
                vm.model.DatosCliente.Contacto.push(contacto);
                vm.contacto = {};
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        };

        vm.actualizarFilaContacto = function (index) {
            //realizar logica
            console.log("actualizarFilaContacto", index);
            window.saveFilas(index)
        };

        vm.editarFilaContacto = function (index) {
            //realizar logica
            console.log("editarFilaContacto", index);
            window.editFilas(index)
        };

        vm.eliminarFilaContacto = function (index) {
            //realizar logica
            console.log("eliminarFilaContacto", index);
            vm.model.DatosCliente.Contacto.splice(index, 1);
        }
        //***Grid contacto**//



        //***Grid banco**//
        vm.agregarBanco = function (bancoPeca) {
            if (validarCampoBanco(bancoPeca)) {
                console.log("agregar banco", bancoPeca);
                vm.model.DatosCliente.Cuenta.push(bancoPeca);
                vm.bancoPeca = {};
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        };

        vm.actualizarFilaBanco = function (index) {
            //realizar logica
            console.log("actualizarFilaBanco", index);
            window.saveFilas(index)
        };

        vm.editarFilaBanco = function (index) {
            //realizar logica
            console.log("editarFilaBanco", index);
            window.editFilas(index)
        };

        vm.eliminarFilaBanco = function (index) {
            //realizar logica
            console.log("eliminarFilaBanco", index);
            vm.model.DatosCliente.Cuenta.splice(index, 1);
        }

        //***Grid banco**//

        //***Grid informacion adicional**//
        vm.agregarInformacion = function (informacion) {
            if (validarInformacion(informacion)) {
                console.log("agregarInformacion", informacion);
                vm.model.UsuarioAudabook.push(informacion);
                vm.informacion = {};
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        };

        vm.actualizarFilaInformacion = function (index) {
            //realizar logica
            console.log("actualizarFilaInformacion", index);
            window.saveFilas(index)
        };

        vm.editarFilaInformacion = function (index) {
            //realizar logica
            console.log("editarFilaInformacion", index);
            window.editFilas(index)
        };

        vm.eliminarFilaInformacion = function (index) {
            //realizar logica
            console.log("eliminarFilaInformacion", index);
            vm.model.UsuarioAudabook.splice(index, 1);
        }

        //***Grid informacion adicional**//

        vm.GuardarRevisionDocumentosCliente = function () {
            $capturaClienteService.GuardarRevisionDocumentosCliente({ id_precliente: idPrecliente, id_usuario: usuario }).then(function (data) {
                console.log("guarda docto entra!" + vm.id_precliente + vm.id_usuario);
                if (data.data.resultado) {
                    //console.log("guarda docto!");
                    //console.log(data.data.data);
                    vm.Resultado = data.data.data[0];
                    console.log(vm.Resultado);
                    if (vm.Resultado.Resultado == 1) {
                        modalExito("Información validada exitosamente");

                    }
                } else {

                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }

        function modalError(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensaje-aviso').innerHTML = mensaje;
        }

        function modalExito(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup').fadeIn('fast');

            $('#popup .icon i').addClass('far fa-check-circle');
            document.getElementById('mensaje').innerHTML = mensaje;
            // console.log("Modal exito!");
        }

        function modalExitoConfirmacion(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popupFin').fadeIn('fast');

            $('#popupFin .icon i').addClass('far fa-check-circle');
            document.getElementById('mensajeFin').innerHTML = mensaje;
        }

        $scope.$on("seleccion_busqueda", function (evet, data) {
            console.log("controlador captura cliente", event);
            console.log("controlador captura cliente", data);
        });

        vm.guardarEdicion = function () {
            var valido = true;

            valido = validarInput();

            if (!validarCuestionario()) {
                valido = false;
            }

            if (vm.model.DatosCliente.Contacto.length === 0) {
                $('#req-table1').fadeIn('fast');
                console.log("model.DatosCliente.Contacto");
                valido = false;
            }

            if (vm.model.DatosCliente.Cuenta.length === 0) {
                $('#req-table2').fadeIn('fast');
                console.log("model.DatosCliente.Cuenta");
                valido = false;
            }

            if (vm.model.UsuarioAudabook.length === 0) {
                $('#req-table3').fadeIn('fast');
                console.log("model.UsuarioAudabook.Contacto");
                valido = false;
            }

            if (!valido) {

                $('.popupoverlay').fadeIn('fast');
                $('#popup-error').fadeIn('fast');

                $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
                document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
                $('#cont-paso1').scrollTop(0);
            }

            $capturaClienteService.guardarEdicion(vm.model).then(function (data) {

                if (data.data.resultado) {
                    //actualizar estatus
                    modalExitoConfirmacion("Se guarda la información correctamente, se envía para su aprobación")
                }
                else {
                    modalError(data.data.mensaje);
                }

            }, function (error) {
                modalError(data.data.mensaje);
            })
        }

        vm.modalDocumento = function (documento) {
            vm.documentoSeleccionado = documento;
            $('#cargar').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
        }

        vm.subirArchivo = function () {
            console.log(" vm.documentoSeleccionado", vm.documentoSeleccionado);
            angular.element($scope.elemento).val('');
            var formdata = new FormData();
            formdata.append("UploadedDocument", $scope.theFile);
            formdata.append("id", vm.documentoSeleccionado.id_precliente);
            formdata.append("tipo", vm.documentoSeleccionado.id_documento);

            $capturaClienteService.guardarArchivo(formdata).then(function (resultado) {
                console.log("resultado", resultado);
                if (resultado.data == 'OK') {
                    vm.documentoSeleccionado.NombreAchivo = $scope.theFile.name;
                    modalExitoConfirmacion("El documento fue actualizado correctamente");
                }
                else {
                    modalError("Ocurrió un problema al actualizar el documento");
                }
            }, function (error) {
                modalError("Ocurrió un problema al actualizar el documento");
            });
        }

        $scope.setFile = function (element) {
            vm.activarSubir = true;
            $scope.$apply(function ($scope) {
                $scope.theFile = element.files[0];
                $scope.elemento = element;
                console.log("$scope.theFile", $scope.theFile);
            });


        }

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

        function validarInformacion(informacion) {
            if (informacion) {
                if (!informacion.Nombre || !informacion.PuestoDepartamento || !informacion.Telefono || !informacion.Correo || !informacion.Admon || !informacion.Oper) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        function validarInput() {
            var resultado = true;
            for (var i = 1; i <= 27; i++) {

                if ($('#inp' + i).val() == '') {
                    $('#inp' + i).addClass('falta');
                    console.log("$('#in' + i).val() == '')", $('#inp' + i).val());
                    console.log("$('#in' + i).val() == '')", i);
                    resultado = false;
                } else {
                    $('#inp' + i).removeClass('falta');
                }
            };

            return resultado;
        }

        function validarCuestionario() {

            var resultado = true;

            $.each($('.textarea-valid'), function (index, element) {
                console.log("validarCuestionario", element);
                if ($(element).val() == '') {
                    $(element).addClass('falta');
                    resultado = false;
                } else {
                    $(element).removeClass('falta');
                }
            })

            $.each($('.select-valid'), function (index, element) {
                if ($(element).val() == '') {
                    $(element).addClass('falta');
                    $('.select-valid-mensaje').show();
                    resultado = false;
                } else {
                    $(element).removeClass('falta');
                    $('.select-valid-mensaje').hide();
                }
            })

            return resultado;
        }
    }
})();