var id_precliente_code = 0;

(function () {
    'use strict';

    angular
        .module('app')
        .controller('capturaClienteCtrl', capturaCliente);

    capturaCliente.$inject = ['$scope', '$registroClienteService', '$capturaClienteService', '$catalogoService', '$q'];

    function capturaCliente($scope, $registroClienteService, $capturaClienteService, $catalogoService, $q) {
        var tempestado;
        var tempciudad;

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

        vm.catalogoPais = [];
        vm.catalogoEstado = [];
        vm.catalogoCiudad = [];
        vm.Documentos = [];

        function obtenerPromesas(usuarioBusqueda) {
            var promesaCapturaCliente = $capturaClienteService.obtenerInfoCliente({ id_usuario: usuarioBusqueda.IdUsuario });
            var promesaContactoCliente = $capturaClienteService.obtenerContactosCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaCuenta = $capturaClienteService.obtenerPECACliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaUsuarioAduabook = $capturaClienteService.obtenerUsrsAduabookCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaCuestionario = $capturaClienteService.obtenerCuestionarioCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaDocumento = $capturaClienteService.obtenerDocumentosCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
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
                //console.log("promesas.promesaCapturaCliente", promesas.promesaCapturaCliente);
                //console.log("promesas.promesaContactoCliente", promesas.promesaContactoCliente);
                //console.log("promesas.promesaCuenta", promesas.promesaCuenta);
                //console.log("promesas.promesaUsuarioAduabook", promesas.promesaUsuarioAduabook);
                console.log("promesas.promesaCuestionario", promesas.promesaCuestionario);
               //console.log("promesas.promesaDocumento", promesas.promesaDocumento);

                if (promesas.promesaCapturaCliente.data.resultado) {

                   // $('#paso2').prop('disabled', false); // Se habilita la pestaña de "Tabuladores" en caso de existir datos en "Registro Cliente".

                    var infoCliente = promesas.promesaCapturaCliente.data.data[0];
                    vm.model.DatosCliente.IdPrecliente = infoCliente.id_precliente;
                    id_precliente_code = infoCliente.id_precliente;
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
                    vm.model.DatosCliente.NumeroCuenta = infoCliente.numero_cuenta;
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

                    if (infoCliente.con_carta_encomienda_respaldo) {
                        vm.model.DatoAdicional.ConCartaEncomiendaActualizar = false;
                    }
                    else {
                        vm.model.DatoAdicional.ConCartaEncomiendaActualizar = true;
                    }

                    vm.model.DatoAdicional.MotivoCartaEncomienda = infoCliente.motivo_sin_carta_encomienda_respaldo;

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
                    console.log("Documentos", vm.Documentos);
                    if (vm.Documentos.length == 9) {
                        vm.Documentos.splice(1, 0, { "ruta_local": "-1" });
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
                        if (pais.id == vm.model.DatosCliente.IdPais) {
                            vm.model.DatosCliente.Pais = vm.catalogoPais[index];
                            vm.obtenerEstado(vm.model.DatosCliente.Pais);
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

        function cargarRegistroCliente(usuarioBusqueda) {
            var promesaGeneral = obtenerPromesas(usuarioBusqueda);
            resolverPromesa(promesaGeneral);
        }

        //*****evento buscador***
        $scope.$on("seleccion_busqueda", function (evet, data) {
            cargarRegistroCliente(data);
            vm.mostrarBoton = true;
            vm.inputDisable = false;

        });

        vm.init = function () {

        }


        //para la edicion eliminar posteriormente 
        vm.test = function () {
            vm.inputDisable = !vm.inputDisable;
        }

        //***Grid contacto**//
        vm.agregarContacto = function (contacto) {
            if (validarCampoContacto(contacto)) {
                vm.model.DatosCliente.Contacto.push(contacto);
                vm.contacto = {};
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        };

        vm.actualizarFilaContacto = function (index) {
            //realizar logica
            window.saveFilas(index)
        };

        vm.editarFilaContacto = function (index) {
            //realizar logica
            window.editFilas(index)
        };

        vm.eliminarFilaContacto = function (index) {
            //realizar logica
            vm.model.DatosCliente.Contacto.splice(index, 1);
        }
        //***Grid contacto**//



        //***Grid banco**//
        vm.agregarBanco = function (bancoPeca) {
            if (validarCampoBanco(bancoPeca)) {
                vm.model.DatosCliente.Cuenta.push(bancoPeca);
                vm.bancoPeca = {};
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        };

        vm.actualizarFilaBanco = function (index) {
            //realizar logica
            window.saveFilas(index)
        };

        vm.editarFilaBanco = function (index) {
            //realizar logica
            window.editFilas(index)
        };

        vm.eliminarFilaBanco = function (index) {
            //realizar logica
            vm.model.DatosCliente.Cuenta.splice(index, 1);
        }

        //***Grid banco**//

        //***Grid informacion adicional**//
        vm.agregarInformacion = function (informacion) {
            if (validarInformacion(informacion)) {
                vm.model.UsuarioAudabook.push(informacion);
                vm.informacion = {};
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        };

        vm.actualizarFilaInformacion = function (index) {
            //realizar logica
            window.saveFilas(index)
        };

        vm.editarFilaInformacion = function (index) {
            //realizar logica
            window.editFilas(index)
        };

        vm.eliminarFilaInformacion = function (index) {
            //realizar logica
            vm.model.UsuarioAudabook.splice(index, 1);
        }

        vm.GuardarRevisionDocumentosCliente = function () {
            $capturaClienteService.GuardarRevisionDocumentosCliente({ id_precliente: idPrecliente, id_usuario: usuario }).then(function (data) {
                console.log("guarda docto entra!" + idPrecliente + usuario);
                if (data.data.resultado) {
                    //console.log("guarda docto!");
                    //console.log(data.data.data);
                    vm.Resultado = data.data.data[0];
                    console.log(vm.Resultado);
                    if (vm.Resultado.Resultado == 1) {
                        modalExito("Información validada exitosamente");
                        $('#paso2').prop('disabled', false); // Se habilita la pestaña de "Tabuladores" en caso de existir datos en "Registro Cliente".
                    }
                } else {

                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }

        vm.obtenerEstado = function (pais) {
            $catalogoService.obtenerEstados({ idPais: pais.id }).then(function (data) {
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
            if (estado == null) {
                vm.catalogoCiudad = [];
                vm.Ciudad = null;
            } else {
                $catalogoService.obtenerCiudades({ idEstado: estado.id }).then(function (data) {
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
        }

        function cargaciudad() {
            if (typeof vm.catalogoCiudad.length !== "undefined") {
                angular.forEach(vm.catalogoCiudad, function (ciudad, index) {
                    if (ciudad.id == vm.model.DatosCliente.IdCiudad) {
                        vm.model.DatosCliente.Ciudad = vm.catalogoCiudad[index];
                    }
                });
            }
            else {

                setTimeout(cargaciudad, 250);
            }
        }

        function cargaestados() {
            //debugger;
            if (typeof vm.catalogoEstado.length !== "undefined") {
                angular.forEach(vm.catalogoEstado, function (estado, index) {

                    console.log("estado vacio", vm.Estado);
                    if (estado.id == vm.model.DatosCliente.IdEstado) {
                        vm.model.DatosCliente.Estado = vm.catalogoEstado[index];
                    }

                });
                vm.obtenerCiudad(vm.model.DatosCliente.Estado);
            }
            else {
                setTimeout(cargaestados, 250);
            }
        }

        function llenaIframeSrc() {
            var iframe = document.getElementById("frame");
            var iframe2 = document.getElementById("frame2");
            var iframe3 = document.getElementById("frame3");
            var iframe4 = document.getElementById("frame4");
            var iframe5 = document.getElementById("frame5");
            var iframe6 = document.getElementById("frame6");
            var iframe7 = document.getElementById("frame7");
            var iframe8 = document.getElementById("frame8");
            var iframe9 = document.getElementById("frame9");
            var iframe10 = document.getElementById("frame10");
            iframe.setAttribute("src", vm.Documentos[0].ruta_local + "#zoom=90");
            if (vm.Documentos[1].ruta_local != -1) {
                iframe2.setAttribute("src", vm.Documentos[1].ruta_local + "#zoom=90");
            }
            iframe3.setAttribute("src", vm.Documentos[2].ruta_local + "#zoom=90");
            iframe4.setAttribute("src", vm.Documentos[3].ruta_local + "#zoom=90");
            iframe5.setAttribute("src", vm.Documentos[4].ruta_local + "#zoom=90");
            iframe6.setAttribute("src", vm.Documentos[5].ruta_local + "#zoom=90");
            iframe7.setAttribute("src", vm.Documentos[6].ruta_local + "#zoom=90");
            iframe8.setAttribute("src", vm.Documentos[7].ruta_local + "#zoom=90");
            iframe9.setAttribute("src", vm.Documentos[8].ruta_local + "#zoom=90");
            iframe10.setAttribute("src", vm.Documentos[9].ruta_local + "#zoom=90");
        }

        vm.guardarEdicion = function () {

            $capturaClienteService.guardarEdicionAlta(vm.model).then(function (data) {

                if (data.data.resultado) {
                    $("#paso2").addClass("btn-operaciones active");
                    $("#paso1").removeClass("btn-operaciones active").addClass("btn-operaciones");
                    $('#paso2').prop('disabled', false);

                    var paso = '#cont-paso' + 2;
                    $('.cont-datos').fadeOut('fast');
                    $(paso).fadeIn('fast');
                    modalPaso1("Información validada exitosamente.");
                }
                else {
                    modalError(data.data.mensaje);
                }

            }, function (error) {
                modalError(data.data.mensaje);
            })
        }

        vm.habilitarCampos = function () {
            vm.inputDisable = false;
        }

        vm.modalGuardar = function () {
            var valido = true;

            valido = validarInput();

            if (!validarCuestionario()) {
                valido = false;
            }

            if (vm.model.DatosCliente.Contacto.length === 0) {
                $('#req-table1').fadeIn('fast');
                valido = false;
            }

            if (vm.model.DatosCliente.Cuenta.length === 0) {
                $('#req-table2').fadeIn('fast');
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
                return;
            }

            $('.popupoverlay').fadeIn('fast');
            $('#popup-confirma-alta').fadeIn('fast');

            $('#popup-confirma-alta .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-confirma-alta').innerHTML = "¿Confirma que la información capturada por el cliente coincide con la documentación proporcionada?";
        }

        //*****Subir archivos**********
        function validarTipoArchivo(idTipoDocumento, extension) {
            var tipoPdf = 'pdf';
            var tipoImagen = ['jpg', 'png', 'gif'];

            if (idTipoDocumento !== 10) {
                console.log("10000");
                if (extension === tipoPdf)
                    return true;
                else
                    return false;
            } else {
                var resultado = false;
                angular.forEach(tipoImagen, function (tipo, index) {
                    console.log(tipo);
                    console.log(extension);
                    if (tipo === extension) {
                        resultado = true;
                        return;
                    }
                });

                return resultado;
            }

        }

        vm.modalDocumento = function (documento, frame) {
            vm.documentoSeleccionado = documento;
            vm.frame = frame || null;
            $('#cargar').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
        }

        vm.subirArchivo = function () {
            desactivarDocumentos(vm.documentoSeleccionado.id_documento, vm.documentoSeleccionado.id_precliente);
            for (var i in $scope.theFile) {
                var extension = $scope.theFile[i].name.substr($scope.theFile[i].name.length - 3, 3).toLowerCase();
                if (!validarTipoArchivo(vm.documentoSeleccionado.id_documento, extension)) {
                    setTimeout(function () { modalError("El tipo de archivo no es admitido."); }, 100);
                } else {
                    angular.element($scope.elemento[i]).val('');

                    var formdata = new FormData();
                    formdata.append("UploadedDocument", $scope.theFile[i]);
                    formdata.append("id", vm.documentoSeleccionado.id_precliente);
                    formdata.append("tipo", vm.documentoSeleccionado.id_documento);

                    $capturaClienteService.guardarArchivo(formdata).then(function (resultado) {
                        if (resultado.data) {
                            vm.documentoSeleccionado.NombreAchivo = $scope.theFile[i].name;
                            if (vm.frame != null) {
                                vm.activarSubir = false;
                                var frame = document.getElementById(vm.frame);
                                console.log("frame", frame);
                                frame.removeAttribute("src");
                                frame.setAttribute("src", resultado.data + "#zoom=90");
                            }
                            modalExitoConfirmacion("El documento fue actualizado correctamente");
                        }
                        else {
                            modalError(resultado.data.Error);
                        }
                    }, function (error) {
                        modalError("Ocurrió un problema al actualizar el documento");
                    });
                }
            }
        }

        $scope.setFile = function (element) {
            vm.activarSubir = true;
            $scope.$apply(function ($scope) {
                $scope.theFile = element.files;
                //$scope.theFile = element.files[0];
                $scope.elemento = element;
            });
        }

        //********validaciones*************
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

        //****modales*****
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
        }

        function modalExitoConfirmacion(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popupFin').fadeIn('fast');

            $('#popupFin .icon i').addClass('far fa-check-circle');
            document.getElementById('mensajeFin').innerHTML = mensaje;
        }

    }
})();

$('.visualizaDocumentos1').click(function () {
    buscarDocumentosClientes(1);
});

$('.visualizaDocumentos2').click(function () {
    buscarDocumentosClientes(2);
});

$('.visualizaDocumentos3').click(function () {
    buscarDocumentosClientes(3);
});

$('.visualizaDocumentos4').click(function () {
    buscarDocumentosClientes(4);
});

$('.visualizaDocumentos5').click(function () {
    buscarDocumentosClientes(5);
});

$('.visualizaDocumentos6').click(function () {
    buscarDocumentosClientes(6);
});

$('.visualizaDocumentos7').click(function () {
    buscarDocumentosClientes(7);
});

$('.visualizaDocumentos8').click(function () {
    buscarDocumentosClientes(8);
});

$('.visualizaDocumentos9').click(function () {
    buscarDocumentosClientes(9);
});

$('.visualizaDocumentos10').click(function () {
    buscarDocumentosClientes(10);
});

function buscarDocumentosClientes(ID_Documento) {
    /*
    1  Carta Encomienda
    2  Carta Encomienda Respaldo
    3  Constancia de situación del cliente
    4  Comprobante de domicilio de la empresa no mayor a 2 meses
    5  Acta constitutiva de la empresa
    6  Poder Notarial del representante y/o apoderado legal
    7  Identificación oficial con foto y firma
    8  RFC del representante lega
    9  Encargo Conferido a favor de cada uno de los agentes aduanales
    10 Fotografías recientes del establecimiento
    11 Expediente
    */

    $('#tablaVisualizaDocumentos tbody tr').remove();

    var id_precliente = id_precliente_code;

    $.ajax({
        url: "../DocumentosCliente/BuscarTodosDocumentos?id_precliente=" + id_precliente + "&tipo_documento=" + ID_Documento,
        contentType: 'application/json',
        async: false,
        datatype: 'json',
        success: function (data) {
            console.log(data);
            for (i = 0; i < data.documentos.length; i++) {
                var FilaDatos = "";
                FilaDatos = FilaDatos + '<tr>';
                FilaDatos = FilaDatos + '<td>' + data.documentos[i] + '</td>';
                FilaDatos = FilaDatos + '<td><button type="button" class="btn btn-primary" data-url="' + data.documentos[i + 1] + '" onclick="verDocumento(this)">Ver documento</button></td>';
                FilaDatos = FilaDatos + '</tr>';
                $('#tablaVisualizaDocumentos').append(FilaDatos);
                i++;
            }
        },
        error: function (data) {
            console.log(data);
        }
    });

    $('#popupVisualizaDocumentos').fadeIn('fast');
    $('.popupoverlay').fadeIn('fast');
}

function verDocumento(e) {
    var url = e.attributes[2].value;
    var iframe = document.getElementById("frameDocumentos");
    iframe.setAttribute("src", url + "#zoom=90");
    $('#popupVisualizaDocumentos').fadeOut('fast');
    $('#verdocumentos').fadeIn('fast');
    $('#popupoverlay').fadeIn('fast');
}

function desactivarDocumentos(tipo_documento, id_precliente) {
    $.ajax({
        url: "../DocumentosCliente/DesactivarDocumentos?id_precliente=" + id_precliente + "&tipo_documento=" + tipo_documento,
        contentType: 'application/json',
        async: false,
        datatype: 'json',
        success: function (data) {
            console.log(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
}