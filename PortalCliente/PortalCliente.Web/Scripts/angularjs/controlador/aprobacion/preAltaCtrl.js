(function () {
    'use strict';

    angular
        .module('app')
        .controller('capturaClienteCtrl', capturaCliente);

    capturaCliente.$inject = ['$scope', '$registroClienteService', '$capturaClienteService', '$aprovacionService', '$catalogoService', '$tabuladoresService', '$q'];

    function capturaCliente($scope, $registroClienteService, $capturaClienteService, $aprovacionService, $catalogoService, $tabuladoresService, $q) {
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

        vm.modelo = {};

        vm.catalogoPais = [];
        vm.catalogoEstado = [];
        vm.catalogoCiudad = [];
        vm.catalogoEstadoTab = [];
        vm.catalogoCiudadTab = [];

        var id_precliente = 0;
        vm.catalogoEquipoOperativo = [];

        function obtenerPromesas2(usuarioBusqueda) {
            var promesaCapturaCliente = $capturaClienteService.obtenerInfoCliente({ id_usuario: usuarioBusqueda.IdUsuario });
            var promesaContactoCliente = $capturaClienteService.obtenerContactosCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaCuenta = $capturaClienteService.obtenerPECACliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaUsuarioAduabook = $capturaClienteService.obtenerUsrsAduabookCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaPais = $catalogoService.obtenerPais();
            id_precliente = usuarioBusqueda.IdPrecliente;



            return $q.all({
                promesaCapturaCliente,
                promesaContactoCliente,
                promesaCuenta,
                promesaUsuarioAduabook,
                promesaPais
            });

        }

        var id_ciudad_aux = "";
        var id_estado_aux = "";
        vm.buscarDatosTabuladores = function (idPrecliente) {
            $tabuladoresService.BuscarDatosTabuladores({ id_precliente: idPrecliente }).then(function (data) {
                if (data.data.resultado) {
                    vm.modelo = data.data.data[0];
                    console.log("data", data.data);
                    vm.modelo.IdPrecliente = id_precliente;



                    if (vm.modelo.TipoCliente === 1) { cambiarEtiqueta('Pedimento'); }
                    else if (vm.modelo.TipoCliente === 2) { cambiarEtiqueta('Factura'); }
                    else if (vm.modelo.TipoCliente === 3) { $(".nombre-alta, .cliente-pedimento").slideUp('fast'); }

                    if (vm.modelo.SitioFTP === false) {
                        $("#ftpdatos").slideUp('fast');
                    }
                    else {
                        $("#ftpdatos").slideDown('fast');
                    }

                    id_ciudad_aux = vm.modelo.id_ciudad;
                    id_estado_aux = vm.modelo.id_estado;

                    angular.forEach(vm.catalogoEquipoOperativo, function (elemento, index) {
                        if (elemento.IdEquipo == vm.modelo.EquipoOperativo) {
                            vm.modelo.EquipoOperativo = elemento;
                        }
                    });

                    angular.forEach(vm.catalogoEstadoTab, function (elemento, index) {
                        if (vm.modelo.id_estado == elemento.id) {
                            vm.modelo.EstadoTab = elemento;
                        }
                    })

                    ciudadTabulador(vm.modelo.id_estado);
                    //vm.modelo.EjecutivoVenta = window.aplicacionDatoUsuario.Nombre;
                    console.log("data", vm.modelo);
                } else {
                }
            }, function (error) {
                console.log("Error en BuscarDatosTabuladores", error);
            });
        }

        vm.buscarDatosTabuladoresContactos = function (idPrecliente) {
            $tabuladoresService.BuscarDatosTabuladoresContactos({ id_precliente: idPrecliente }).then(function (data) {
                if (data.data.resultado) {
                    var tabContactos = data.data.data;
                    vm.modelo.InformacionContacto = [];
                    vm.contacto = {};
                    angular.forEach(tabContactos, function (elemento, index) {
                        vm.contacto.Contacto = elemento.contacto;
                        vm.contacto.Nombre = elemento.nombre;
                        vm.contacto.Puesto = elemento.puesto;
                        vm.contacto.Telefono = elemento.telefono;
                        vm.contacto.Email = elemento.email;
                        vm.modelo.InformacionContacto.push(vm.contacto);
                        vm.contacto = {};
                    });
                } else {
                }
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresContactos", error);
            });
        }

        vm.buscarDatosTabuladoresTarifas = function (idPrecliente) {
            $tabuladoresService.BuscarDatosTabuladoresTarifas({ id_precliente: idPrecliente }).then(function (data) {
                if (data.data.resultado) {
                    var tabTarifas = data.data.data;
                    vm.modelo.TarifaServicio = [];
                    vm.tarifa = {};
                    angular.forEach(tabTarifas, function (elemento, index) {
                        vm.tarifa.Servicio = elemento.servicio;
                        vm.tarifa.Tarifa = elemento.tarifa;
                        vm.tarifa.Notas = elemento.notas;
                        vm.modelo.TarifaServicio.push(vm.tarifa);
                        vm.tarifa = {};
                    });
                } else {
                }
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresTarifas", error);
            });
        }

        vm.buscarDatosTabuladoresTabs = function (idPrecliente) {

            $tabuladoresService.BuscarDatosTabuladoresTabs({ id_precliente: idPrecliente }).then(function (data) {
                if (data.data.resultado) {
                    var tabTabs = data.data.data.tabs;
                    var empresaServicio = data.data.data.empresas;

                    var promesasConceptoFacturacion = obtenerConceptoFacturacionPorEmpresa(empresaServicio);

                    $q.all(promesasConceptoFacturacion).then(function (result) {
                        for (var i = 0; i < empresaServicio.length; i++) {
                            empresaServicio[i].catalogoConceptoFacturacion = result[i].data.data;
                        }



                        vm.modelo.TabuladorDinamico = [];
                        vm.tabularDinamico = {};
                        angular.forEach(tabTabs, function (elemento, index) {

                            vm.tabularDinamico.TipoOperacion = elemento.TipoOperacion;
                            vm.tabularDinamico.id_aduana = elemento.id_aduana;
                            vm.seleccionarAduana(vm.tabularDinamico.id_aduana);
                            vm.tabularDinamico.id_clavepedimento = elemento.ClavePedimento;
                            vm.seleccionarClavePedimento(vm.tabularDinamico.id_clavepedimento);
                            vm.tabularDinamico.Moneda = elemento.Moneda;
                            vm.tabularDinamico.Facturacion = elemento.Facturacion;
                            vm.tabularDinamico.DiasLibres = elemento.DiasLibres;
                            vm.tabularDinamico.Empresa = [];

                            angular.forEach(empresaServicio, function (objServicio, index) {

                                if (parseInt(objServicio.id_tabulador_tab) === elemento.id_tabulador_tab) {
                                    angular.forEach(objServicio.catalogoConceptoFacturacion, function (cat, index) {
                                        if (cat.id == objServicio.concepto_facturacion) {
                                            objServicio.concepto_facturacion = cat;
                                        }
                                    });

                                    var empresaTemp = {};

                                    empresaTemp.catalogoConceptoFacturacion = objServicio.catalogoConceptoFacturacion;
                                    empresaTemp.Empresa = objServicio.empresa;
                                    empresaTemp.ConceptoFacturacion = objServicio.concepto_facturacion;
                                    empresaTemp.ConceptoAutoFacturacion = buscarConceptoAutoFacturacion(objServicio.concepto_auto_facturacion);
                                    empresaTemp.TarifaVenta = objServicio.tarifa_venta;
                                    empresaTemp.TarifaVentaMoneda = objServicio.tarifa_venta_tipo_moneda;
                                    empresaTemp.TarifaCompra = objServicio.tarifa_compra;
                                    empresaTemp.TarifaCompraMoneda = objServicio.tarifa_compra_tipo_moneda;

                                    vm.tabularDinamico.Empresa.push(empresaTemp);
                                }
                            });
                            vm.modelo.TabuladorDinamico.push(vm.tabularDinamico);
                            vm.tabularDinamico = {};

                        });


                    });


                } else {
                }
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresTabs", error);
            });
        }

        function obtenerConceptoFacturacionPorEmpresa(empresas) {
            var promesas = [];
            angular.forEach(empresas, function (empresa, index) {

                promesas.push($catalogoService.obtenerConceptoFacturacion({ empresa: empresa.empresa }));
            });

            return promesas;


        }

        function buscarConceptoAutoFacturacion(id) {
            var coneptoEncontrado = {};
            angular.forEach(vm.catalogoConceptoAutoFacturacion, function (concepto, index) {
                if (concepto.id === id) {
                    coneptoEncontrado = concepto;
                    return coneptoEncontrado;
                }
            });

            return coneptoEncontrado;
        }

        function ciudadTabulador(idEstado) {
            $catalogoService.obtenerCiudades({ idEstado: idEstado }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoCiudadTab = data.data.dato;

                    angular.forEach(vm.catalogoCiudadTab, function (elemento, index) {
                        if (vm.modelo.id_ciudad == elemento.id) {
                            vm.modelo.CiudadTab = elemento;
                        }
                    })

                } else {
                    console.log("Error", data.data.mensaje);
                }
            })
        }

        vm.seleccionarEstado = function (id_estado) {
            angular.forEach(vm.catalogoEstado, function (estados, index) {
                if (estados.id == id_estado) {
                    vm.modelo.Estado = vm.catalogoEstado[index];
                    vm.obtenerCiudadNueva(vm.modelo.Estado.id);

                }
            });
        }
        vm.seleccionarAduana = function (id_aduana) {
            angular.forEach(vm.catalogoAduanas, function (aduanas, index) {
                
                if (aduanas.id == id_aduana) {
                    vm.tabularDinamico.Aduana = vm.catalogoAduanas[index];
                }
            });
        }
        vm.seleccionarClavePedimento = function (id_clavepedimento) {
            angular.forEach(vm.catalogoClavePedimento, function (claves, index) {
                if (claves.id == id_clavepedimento) {
                    vm.tabularDinamico.ClavePedimento = vm.catalogoClavePedimento[index];
                }
            });
        }

        var pais_aux = "";
        function resolverPromesa(promesaGeneral) {

            promesaGeneral.then(function (promesas) {
                //console.log("promesas.promesaCapturaCliente", promesas.promesaCapturaCliente);
                //console.log("promesas.promesaContactoCliente", promesas.promesaContactoCliente);
                //console.log("promesas.promesaCuenta", promesas.promesaCuenta);
                //console.log("promesas.promesaUsuarioAduabook", promesas.promesaUsuarioAduabook);
                // console.log("promesas.promesaCuestionario", promesas.promesaCuestionario);
                //console.log("promesas.promesaDocumento", promesas.promesaDocumento);

                if (promesas.promesaCapturaCliente.data.resultado) {

                    //$('#paso2').prop('disabled', false); // Se habilita la pestaña de "Tabuladores" en caso de existir datos en "Registro Cliente".

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
                    pais_aux = infoCliente.id_pais;
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
                    vm.model.DatoAdicional.MotivoCartaEncomienda = infoCliente.motivo_sin_carta_encomienda_respaldo;

                    if (promesas.promesaPais.data.resultado) {
                        vm.catalogoPais = promesas.promesaPais.data.dato;
                        angular.forEach(vm.catalogoPais, function (pais, index) {
                            if (pais_aux == pais.id) {
                                vm.model.DatosCliente.Pais = vm.catalogoPais[index];
                                vm.obtenerEstado(vm.model.DatosCliente.Pais);
                            }
                        });
                    } else {
                        console.log("Error", promesas.promesaPais.data.mensaje);
                    }

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

            },
                function (error) {
                    console.log("Error", error);
                });

        }

        function cargarRegistroCliente(usuarioBusqueda) {
            var promesaGeneral = obtenerPromesas2(usuarioBusqueda);
            resolverPromesa(promesaGeneral);
        }

        //*****evento buscador***
        $scope.$on("seleccion_busqueda", function (evet, data) {
            cargarRegistroCliente(data);

            vm.buscarDatosTabuladores(data.IdPrecliente);
            vm.buscarDatosTabuladoresContactos(data.IdPrecliente);
            vm.buscarDatosTabuladoresTarifas(data.IdPrecliente);
            vm.buscarDatosTabuladoresTabs(data.IdPrecliente);

            idPrecliente = data.IdPrecliente;
            vm.inputDisable = true;


        });

        vm.init = function () {
            $catalogoService.obtenerEquipoOperativo().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoEquipoOperativo = data.data.data;
                } else {
                    console.log("Ocurrió un problema al obtener el catalogo Equipo Operativo");
                }

            }, function (error) {
                console.log("Ocurrió un problema al obtener el catalogo Equipo Operativo", error);
            });

            $catalogoService.obtenerEstados({ IdPais: "N3" }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoEstadoTab = data.data.dato;
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })


            $catalogoService.obtenerAduanas().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoAduanas = data.data.data;
                    // console.log("aduanas", vm.catalogoAduanas);
                    //cargaestados();
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })

            $catalogoService.obtenerClavePedimento().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoClavePedimento = data.data.data;
                    //console.log("claves_pedimentos", vm.catalogoClavePedimento);
                    //cargaestados();
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })

            $catalogoService.obtenerConceptoAutoFacturacion().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoConceptoAutoFacturacion = data.data.data;
                    //console.log("catalogoConceptoAutoFacturacion", vm.catalogoConceptoAutoFacturacion);
                    //cargaestados();
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })

        }


        //para la edicion eliminar posteriormente 
        vm.test = function () {
            vm.inputDisable = !vm.inputDisable;
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

                    // console.log("estado vacio", vm.Estado);
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


        function modalError(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensaje-aviso').innerHTML = mensaje;
        }

        function modalExito() {
            $('.popupoverlay').fadeIn('fast');
            $('#popup').fadeIn('fast');

            $('#popup .icon i').addClass('far fa-check-circle');
            document.getElementById('mensaje').innerHTML = "Cliente cambiado a estatus Revalidacion Pre - Alta exitosamente";
            // console.log("Modal exito!");
        }

        function modalExito2() {
            $('.popupoverlay').fadeIn('fast');
            $('#popup').fadeIn('fast');

            $('#popup .icon i').addClass('far fa-check-circle');
            document.getElementById('mensaje').innerHTML = "Cliente cambiado a estatus Aprobado sin procedimiento PreAlta exitosamente";
            // console.log("Modal exito!");
        }

        vm.fnAprobadoSinProcedimientoPreAlta = function () {
            console.log("fnAprobadoSinProcedimientoPreAlta");

            if (vm.model.DatosCliente.IdPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            $aprovacionService.AprobadoSinProcedimientoPreAlta({ idUsuario: usuario, idPrecliente: idPrecliente, estatus: 5, observacion: vm.observaciones })
                .then(function (data) {
                    console.log("regresa aprobado sin procedimiento");
                    console.log(data);
                    /*
                    $('.popupoverlay').fadeIn('fast');
                    $('#popup').fadeIn('fast');
                    $('#popup .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensaje').innerHTML = "Cliente cambiado a estatus: Aprobado sin Procedimiento - exitosamente";
                    */
                    $('.popupoverlay').fadeIn('fast');
                    $('#popupAprobadoSI').fadeIn('fast');
                    $('#popupAprobadoSI .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensajeAprobadoSI').innerHTML = "Cliente cambiado a estatus: Aprobado sin Procedimiento - exitosamente";
                }, function (error) {
                    console.log("Error", data.data.mensaje + ' ' + error);
                })
        }

        vm.fnNoAprobado = function () {
            console.log("fnNoAprobado");

            if (vm.model.DatosCliente.IdPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            $aprovacionService.NoAprobado({ idUsuario: usuario, idPrecliente: idPrecliente, estatus: 6, observacion: vm.observaciones })
                .then(function (data) {
                    console.log("regresa no aprobado");
                    console.log(data);
                    $('.popupoverlay').fadeIn('fast');
                    $('#popupNoAprobadoRefresh').fadeIn('fast');
                    $('#popupNoAprobadoRefresh .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensajeNoAprobadoRefresh').innerHTML = "Cliente cambiado a estatus: No Aprobado - exitosamente";
                }, function (error) {
                    console.log("Error", data.data.mensaje + ' ' + error);
                })
        }
        vm.fnRevalidacion = function () {
            console.log("fnRevalidacion");

            if (idPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            $aprovacionService.PreAltaRevalidacion({ idUsuario: usuario, idPrecliente: idPrecliente, estatus: 4, observacion: vm.observacionesRev })
                .then(function (data) {
                    console.log("regresa no fnRevalidacion" + window.aplicacionDatoUsuario.IdUsuario + window.aplicacionDatoUsuario.IdPrecliente + vm.observacionesRev);
                    console.log(data);
                    console.log(data.data.resultado);
                    if (data.data.resultado == true) {
                        //modalExito();

                        $('.popupoverlay').fadeIn('fast');
                        $('#popupRevalidacion').fadeIn('fast');

                        $('#popupRevalidacion .icon i').addClass('far fa-check-circle');
                        document.getElementById('mensajeRevalidacion').innerHTML = "Cliente cambiado a estatus Revalidacion Pre - Alta exitosamente";

                    } else {
                        modalError(data.data.mensaje)
                    }
                }, function (error) {
                    console.log("Error", data.data.mensaje + ' ' + error);

                })
        }

        vm.recargar = function () {
            window.location.reload(true);
        };



        vm.fnConfirmaRevalidacion = function () {

            if (idPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            $('.popupoverlay').fadeIn('fast');
            $('#popup-Revalidacion').fadeIn('fast');

        }

        vm.fnConfirmarAprobar = function () {

            if (idPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            $('.popupoverlay').fadeIn('fast');
            $('#popup-AprobarSi').fadeIn('fast');
        }

        vm.fnConfirmarNoAprobar = function () {

            if (idPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            $('.popupoverlay').fadeIn('fast');
            $('#popup-AprobarNo').fadeIn('fast');

        }

    }
})();