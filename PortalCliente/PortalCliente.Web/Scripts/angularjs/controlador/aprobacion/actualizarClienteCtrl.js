(function () {
    'use strict';

    angular
        .module('app')
        .controller('actualizarClienteCtrl', actualizar);

    actualizar.$inject = ['$scope', '$aprovacionService', '$catalogoService',
        '$actualizaClienteService', '$TabuladorProcedimientoOperacionService',
        '$capturaClienteService', '$registroClienteService', '$q'];

    function actualizar($scope, $aprovacionService, $catalogoService,
        $actualizaClienteService, $TabuladorProcedimientoOperacionService,
        $capturaClienteService, $registroClienteService, $q) {
        var vm = $scope;
        vm.modelo = {};
        vm.modelo.TabuladorDinamico = [];
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        vm.botones = false;

        var idPrecliente = 0;
        var idUsrPrecliente = 0;
        var filasContactosTab = 0;
        var filasTarifasTab = 0;
        var filasEmpresaTab = 0;
        var numero_tabs = 1;

        function objTab() {
            return {
                Empresa: []
                , empresaGrid: {}
            };
        }

        vm.init = function () {

            $catalogoService.obtenerEstados({ IdPais: "N3" }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoEstado = data.data.dato;
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })

            $catalogoService.obtenerAduanas().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoAduanas = data.data.data;
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })

            $catalogoService.obtenerClavePedimento().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoClavePedimento = data.data.data;
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })

            $catalogoService.obtenerConceptoAutoFacturacion().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoConceptoAutoFacturacion = data.data.data;
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })

            $catalogoService.obtenerEquipoOperativo().then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoEquipoOperativo = data.data.data;
                } else {
                    console.log("Ocurrió un problema al obtener el catalogo Equipo Operativo");
                }

            }, function (error) {
                console.log("Ocurrió un problema al obtener el catalogo Equipo Operativo", error);
            });

            vm.agregarTabDinamico();

        };

        vm.agregarTabDinamico = function () {
            var tab = objTab();
            vm.modelo.TabuladorDinamico.push(tab);
            tab = {};
        }

        $scope.$on("seleccion_busqueda", function (evet, data) {
            console.log("seleccion_busqueda", data);
            if (data.Estatus == 16) {
                $("#paso1").removeClass("active");
                $("#paso3").addClass("active");

                idPrecliente = data.IdPrecliente;
                idUsrPrecliente = data.IdUsuario;
                vm.buscarDatosTabuladores(data.IdPrecliente);

                vm.arrayProcedimiento = [];
                resolverPromesas(data);
            }
        })

        var id_ciudad_aux = "";
        vm.buscarDatosTabuladores = function (id) {
            $actualizaClienteService.BuscarDatosTabuladores({ id_precliente: id, temporal: true }).then(function (data) {
                if (data.data.resultado) {
                    vm.modelo = data.data.data[0];
                    vm.modelo.IdPrecliente = id;

                    vm.buscarDatosTabuladoresContactos(id);
                    vm.buscarDatosTabuladoresTarifas(id);
                    vm.buscarDatosTabuladoresTabs(id);


                    if (vm.modelo.TipoCliente === 1) { cambiarEtiqueta('Pedimento') }
                    else if (vm.modelo.TipoCliente === 2) { cambiarEtiqueta('Factura'); }
                    else if (vm.modelo.TipoCliente === 3) { $(".nombre-alta, .cliente-pedimento").slideUp('fast'); }
                    id_ciudad_aux = vm.modelo.id_ciudad;
                    vm.seleccionarEstado(vm.modelo.id_estado);

                    angular.forEach(vm.catalogoEquipoOperativo, function (elemento, index) {
                        if (elemento.IdEquipo == vm.modelo.EquipoOperativo) {
                            vm.modelo.EquipoOperativo = elemento;
                        }
                    });
                } else {
                }
            }, function (error) {
                console.log("Error en BuscarDatosTabuladores", error);
            });
        }

        vm.buscarDatosTabuladoresContactos = function (id) {
            $actualizaClienteService.BuscarDatosTabuladoresContactos({ id_precliente: id, temporal: true }).then(function (data) {
                if (data.data.resultado) {
                    var tabContactos = data.data.data;
                    //console.log("tabContactos", tabContactos);
                    vm.modelo.InformacionContacto = [];
                    vm.contactoTab = {};
                    angular.forEach(tabContactos, function (elemento, index) {
                        vm.contactoTab.Contacto = elemento.contacto;
                        vm.contactoTab.Nombre = elemento.nombre;
                        vm.contactoTab.Puesto = elemento.puesto;
                        vm.contactoTab.Telefono = elemento.telefono;
                        vm.contactoTab.Email = elemento.email;
                        vm.modelo.InformacionContacto.push(vm.contactoTab);
                        vm.contactoTab = {};
                        filasContactosTab++;
                    });
                } else {
                }
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresContactos", error);
            });
        }

        vm.buscarDatosTabuladoresTarifas = function (id) {
            $actualizaClienteService.BuscarDatosTabuladoresTarifas({ id_precliente: id, temporal: true }).then(function (data) {
                if (data.data.resultado) {
                    var tabTarifas = data.data.data;
                    console.log("vm.modelo.TarifaServicio", tabTarifas);
                    vm.modelo.TarifaServicio = [];
                    vm.tarifa = {};
                    angular.forEach(tabTarifas, function (elemento, index) {
                        vm.tarifa.Servicio = elemento.servicio;
                        vm.tarifa.Tarifa = elemento.tarifa;
                        vm.tarifa.Notas = elemento.notas;
                        vm.modelo.TarifaServicio.push(vm.tarifa);
                        vm.tarifa = {};
                        filasTarifasTab++;
                    });

                    console.log("vm.modelo.TarifaServicio", vm.modelo.TarifaServicio);

                } else {
                }
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresTarifas", error);
            });
        }

        vm.buscarDatosTabuladoresTabs = function (id) {
            numero_tabs = 0;
            $actualizaClienteService.BuscarDatosTabuladoresTabs({ id_precliente: id, temporal: true }).then(function (data) {
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
                                    filasEmpresaTab++;
                                }
                            });
                            vm.modelo.TabuladorDinamico.push(vm.tabularDinamico);
                            vm.tabularDinamico = {};
                            numero_tabs++;

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

        function obtenerPromesas(datoBusqueda) {

            vm.camposFinanciamiento = false;
            var id_precliente = datoBusqueda.IdPrecliente;

            var promesaformapago = $TabuladorProcedimientoOperacionService.GetFormaPagos();
            var promesaicoterms = $TabuladorProcedimientoOperacionService.GetExIncoterms();
            var promesaValoracions = $TabuladorProcedimientoOperacionService.GetExMetodoValoracions();
            var promesaRegimens = $TabuladorProcedimientoOperacionService.GetRegimens();
            var prinesaaplicacionespreferencia = $TabuladorProcedimientoOperacionService.GetApliacacionPreferencia();

            var promesaCuenta = $capturaClienteService.obtenerListaCuentaBanco({ 'idPrecliente': datoBusqueda.IdPrecliente });
            var promesaDireccion = $capturaClienteService.obtenerDireccionCliente({ 'idPrecliente': datoBusqueda.IdPrecliente });
            var promesaNumeroTab = $capturaClienteService.obtenerNumeroTabulador({ 'idUsuario': datoBusqueda.IdUsuario, 'idPrecliente': datoBusqueda.IdPrecliente });
            var promesaTabuladorTabs = $capturaClienteService.ObtieneTabsPrecliente(datoBusqueda.IdPrecliente);
            var promesatabitems = $actualizaClienteService.GetTabuladorTab(datoBusqueda.IdPrecliente);
            var promesaDatoCliente = $registroClienteService.ObtieneDatosCliente(datoBusqueda.IdUsuario);
            var promesaDatosTituloSecciones = $registroClienteService.ObtieneDatosTituloSecciones({ 'idPrecliente': datoBusqueda.IdPrecliente });
            var promesaDatosFinanciamiento = $registroClienteService.ObtieneDatosFinanciamiento({ 'idPrecliente': datoBusqueda.IdPrecliente });
            //VRF


            return $q.all({
                promesaCuenta,
                promesaDireccion,
                promesaNumeroTab,
                promesaTabuladorTabs,
                promesatabitems,
                promesaformapago,
                promesaicoterms,
                promesaValoracions,
                promesaRegimens,
                prinesaaplicacionespreferencia,
                promesaDatoCliente,
                promesaDatosTituloSecciones,
                promesaDatosFinanciamiento
            })
        }

        function resolverPromesas(datoBusqueda) {
            obtenerPromesas(datoBusqueda).then(function (promesas) {
                //console.log("promesas.promesaDatoCliente.data", promesas.promesaDatoCliente);

                if (promesas.promesaCuenta.data.resultado) {
                    vm.listaCuenta = promesas.promesaCuenta.data.data;
                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaDireccion.data.resultado) {
                    vm.dirrecionCliente = promesas.promesaDireccion.data.data;
                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaNumeroTab.data.resultado) {
                    vm.numeroTabs = promesas.promesaNumeroTab.data.data;

                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaDatosTituloSecciones.data.resultado) {
                    vm.Secciones = [];
                    var temp2 = promesas.promesaDatosTituloSecciones.data.data;
                    for (var i = 0; i < temp2.length; i++) {
                        vm.Secciones.push(temp2[i]);
                    }
                } else {
                    console.log("Error", promesas.promesaDatosTituloSecciones.data);
                }

                if (promesas.promesaDatosFinanciamiento.data.resultado) {
                    vm.Monto = promesas.promesaDatosFinanciamiento.data.data.monto;
                    vm.Parausoen = promesas.promesaDatosFinanciamiento.data.data.para_uso_en;
                    vm.PuntoReorden = promesas.promesaDatosFinanciamiento.data.data.punto_reorden;
                    vm.Recuperacion = promesas.promesaDatosFinanciamiento.data.data.recuperacion;
                    vm.Plazo = promesas.promesaDatosFinanciamiento.data.data.plazo;
                    vm.Condiciones = promesas.promesaDatosFinanciamiento.data.data.condiciones;
                    if (promesas.promesaDatosFinanciamiento.data.data.con_financiamiento === "False") {
                        vm.camposFinanciamiento = true;
                    }

                } else {
                    console.log("Error", promesas.promesaDatosFinanciamiento.data);
                }

                if (promesas.promesaTabuladorTabs.data.resultado) {

                    //console.log("promesas.promesaTabuladorTabs.data.resultado");
                    // console.log(promesas.promesaTabuladorTabs.data.resultado);
                    var temp = promesas.promesaTabuladorTabs.data.resultado;
                    vm.idtabs = [];
                    vm.indices = [];

                    for (var i = 0; i < temp.length; i++) {

                        vm.idtabs.push(temp[i].split("|")[0]);
                        vm.indices.push(temp[i].split("|")[1])

                    }


                } else {
                    console.log("Error", promesas.promesaTabuladorTabs.data.mensaje);
                }

                if (promesas.promesaformapago.data.respuesta) {
                    vm.FormaPagosCat = promesas.promesaformapago.data.items;
                    //console.log("vm.FormaPagosCat", vm.FormaPagosCat);
                }

                if (promesas.promesaicoterms.data.respuesta) {
                    vm.IncotermsCat = promesas.promesaicoterms.data.items;
                }

                if (promesas.promesaValoracions.data.respuesta) {
                    vm.MetodoValoracionsCat = promesas.promesaValoracions.data.items;
                }

                if (promesas.promesaRegimens.data.respuesta) {
                    vm.RegimensCat = promesas.promesaRegimens.data.items;
                }

                if (promesas.prinesaaplicacionespreferencia.data.respuesta) {
                    vm.AplicacionPreferenciaCat = promesas.prinesaaplicacionespreferencia.data.items;

                }

                if (promesas.promesatabitems.data.respuesta) {
                    // console.log(promesas.promesatabitems.data);
                    vm.itemstaboper = promesas.promesatabitems.data.items;
                    //console.log("promesas.promesatabitems", promesas.promesatabitems);
                }

                if (promesas.promesaDatoCliente.data) {
                    //console.log("promesas.promesaDatoCliente.data.Contacto", promesas.promesaDatoCliente.data.Contacto);
                    vm.contactoCliente = promesas.promesaDatoCliente.data.Contacto;
                    vm.VucemCliente = promesas.promesaDatoCliente.data.VucemCliente;

                    if (vm.VucemCliente == true)
                        vm.TipoCliente = "cliente";
                    else
                        vm.TipoCliente = "agente aduanal";
                }

                if (promesas.promesaNumeroTab.data.resultado &&
                    promesas.promesaCuenta.data.resultado &&
                    promesas.promesaDireccion.data.resultado &&
                    promesas.promesaTabuladorTabs.data.resultado &&
                    promesas.promesatabitems.data.respuesta &&
                    promesas.promesaformapago.data.respuesta &&
                    promesas.promesaicoterms.data.respuesta &&
                    promesas.promesaValoracions.data.respuesta &&
                    promesas.promesaRegimens.data.respuesta &&
                    promesas.prinesaaplicacionespreferencia.data.respuesta &&
                    promesas.promesaDatoCliente.data) {
                    crearArrayProcedimiento();
                    vm.botones = true;
                }
            })
        }

        function modalError(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensaje-aviso').innerHTML = mensaje;
        }

        function validarCampoContactoEI(ContactosEI) {
            if (ContactosEI) {
                if (!ContactosEI.nombre || !ContactosEI.correo || !ContactosEI.telefono || !ContactosEI.puesto_departamento) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        //***Grid contacto EI**//
        vm.agregarContactoEI = function (ContactosEI, indice) {
            if (validarCampoContactoEI(ContactosEI)) {
                vm.arrayProcedimiento[indice - 1].ContactosEI.push(ContactosEI);
                vm.arrayProcedimiento[indice - 1].ContactoEI = {};

            } else {
                //modalError("Se deben llenar todos los campos de la fila.");
                $('.popupoverlay').fadeIn('fast');
                $('#popupNo').fadeIn('fast');
                document.getElementById('mensajeNo').innerHTML = "Se deben llenar todos los campos de la fila.";
            }
        };

        vm.actualizarFilaContactoEI = function (index, indice) {
            //console.log("actualizarFilaContactoEI" + index);
            saveFilasPO(index, indice);
            window.saveFilas(index)
        };

        vm.editarFilaContactoEI = function (index, indice) {
            //console.log("editarFilaContactoEI" + index);
            EditFilasPO(index, indice);
            window.editFilas(index)
        };

        vm.eliminarFilaContactoEI = function (index, indice) {
            //console.log("eliminarFilaContacto" + index);
            vm.arrayProcedimiento[indice - 1].ContactosEI.splice(index, 1);
        }
        //***Grid contacto EI**//

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

        function crearArrayProcedimiento() {
            for (var index = 0; index < vm.numeroTabs; index++) {
                var procedimiento = {};
                procedimiento.Cuentas = vm.listaCuenta;
                procedimiento.Precliente = {};
                procedimiento.Precliente.NombreComercial = vm.dirrecionCliente.NombreComercial;
                procedimiento.Precliente.Direccion = vm.dirrecionCliente.Direccion;
                procedimiento.Precliente.ContactoCliente = vm.contactoCliente;
                procedimiento.claseSucces = '';
                procedimiento.Id_Tabulador = vm.idtabs[index];
                procedimiento.Indice = vm.indices[index];
                procedimiento.ContactoEI = {};
                procedimiento.Secciones = vm.Secciones[index];

                procedimiento.Monto = vm.Monto;
                procedimiento.Parausoen = vm.Parausoen;
                procedimiento.PuntoReorden = vm.PuntoReorden;
                procedimiento.Recuperacion = vm.Recuperacion;
                procedimiento.Plazo = vm.Plazo;
                procedimiento.Condiciones = vm.Condiciones;

                var NvoTab = true;
                for (var i = 0; i < vm.itemstaboper.length; i++) {
                    var _item = vm.itemstaboper[i];
                    if (_item.Id_Tabulador == procedimiento.Id_Tabulador) {
                        $.extend(procedimiento, _item);
                        NvoTab = false;
                        procedimiento.Vinculacion = procedimiento.Vinculacion == true ? 1 : 2;
                        procedimiento.AplicacionTLCAN = procedimiento.AplicacionTLCAN == true ? 1 : 2;
                        procedimiento.Incrementables = procedimiento.Incrementables == true ? 1 : 2;
                        procedimiento.EnvioProformaAutorizacion = procedimiento.EnvioProformaAutorizacion == true ? 1 : 2;
                        procedimiento.GrupoGeneralEEI = procedimiento.GrupoGeneralEEI == true ? 1 : 2;
                        procedimiento.claseSucces = "bg-green";
                    }
                }

                if (NvoTab) {
                    procedimiento.Id_TipodePedimento = 0;
                    procedimiento.Id_Regimen = 0;
                    procedimiento.Id_ManejodePedimento = 0;
                    procedimiento.Id_Incoterm = 0;
                    procedimiento.Id_MetodoValoracion = 0;
                    procedimiento.Id_FormaPago = 0;
                    procedimiento.Vinculacion = 0;
                    procedimiento.Id_AplicacionPreferencias = 0;
                    procedimiento.AplicacionTLCAN = 0;
                    procedimiento.Incrementables = 0;
                    procedimiento.EnvioProformaAutorizacion = 0;
                    procedimiento.GrupoGeneralEEI = 0;
                    procedimiento.ContactosEI = [];
                }


                procedimiento.FormaPagosCat = creaarraycatalogo(['Seleccione']).concat(vm.FormaPagosCat);
                procedimiento.TipoPedimentoCat = creaarraycatalogo(['Seleeccione', 'Importacion', 'Exportacion']);
                procedimiento.RegimensCat = creaarraycatalogo(['Seleccione']).concat(vm.RegimensCat);
                procedimiento.ManejoPedimientoCat = creaarraycatalogo(['Seleccione', 'Normal', 'Consolidado', 'Remesa']);
                procedimiento.IncotermsCat = creaarraycatalogo(['Seleccione']).concat(vm.IncotermsCat);
                procedimiento.MetodoValoracionsCat = creaarraycatalogo(['Seleccione']).concat(vm.MetodoValoracionsCat);
                procedimiento.FormaPagosCat = creaarraycatalogo(['Seleccione']).concat(vm.FormaPagosCat);
                procedimiento.VinculacionCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
                procedimiento.AplicacionPreferenciaCat = creaarraycatalogo(['Seleccione']).concat(vm.AplicacionPreferenciaCat);
                procedimiento.AlicacionTLCANCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
                procedimiento.IncrementablesCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
                procedimiento.EnvioProformaAutorizacionCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
                procedimiento.GrupoGeneralEEICat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);

                procedimiento.Id_abuladorProcedimientoOperacion = null;
                vm.arrayProcedimiento.push(procedimiento);
                //console.log(procedimiento.Id_FormaPago)

            }

            //console.log("arrayprocedimiento");
            //console.log(vm.arrayProcedimiento);
        }

        vm.obtenerCiudadNueva = function (estado) {
            $catalogoService.obtenerCiudades({ IdEstado: estado }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoCiudad = data.data.dato;
                    vm.seleccionarCiudad();
                    //osa
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }

        vm.seleccionarCiudad = function () {
            angular.forEach(vm.catalogoCiudad, function (ciudades, index) {
                if (ciudades.id == id_ciudad_aux) {
                    vm.modelo.Ciudad = vm.catalogoCiudad[index];
                }
            });
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

        vm.revalidacionActCliente = function () {
            vm.modalConfirmarAC = {};
            vm.modalConfirmarAC.Observacion = '';
            vm.modalConfirmarAC.habilitar = false;
            $('#popup-confirmAC').fadeIn('fast');
            $('#popupoverlay').fadeIn('fast');
            $('#popup-confirmAC .texttarea').fadeIn('fast');
            $('#popup-confirmAC .texttarea').removeAttr("disabled");
            $('#popup-confirmAC button').removeAttr("disabled");
            $('#popup-confirmAC #obs').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
            vm.modalConfirmarAC = {};
            vm.modalConfirmarAC.isRevalidacion = true;
            //console.log("revalidacionProcedimiento");
        }

        vm.aprobarActCliente = function () {
            vm.modalConfirmarAC = {};
            vm.modalConfirmarAC.isRevalidacion = false;
            vm.modalConfirmarAC.habilitar = false;
            vm.modalConfirmarAC.Observacion = '';
            $('#popup-confirmAC button').removeAttr("disabled");
            $('#popup-confirmAC').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
        }

        vm.aceptarRevalidacionAC = function () {
            //console.log("revalidacion act cliente");

            if (vm.modalConfirmarAC.Observacion) {

                $aprovacionService.revalidacionAC({ idUsuario: usuario, idPrecliente: idPrecliente, observacion: vm.modalConfirmarAC.Observacion }).then(function (data) {
                    if (data.data.resultado) {
                        //vm.cerrarModalAC();
                        //vm.modalOKAprobacion("Se realizó la revalidación satisfactoriamente.");
                        window.location.reload(true);
                    } else {
                        console.log("Error en la revalidacion act cte", data.data.mensaje);
                        modalError(data.data.mensaje);
                    }
                }, function (error) {
                    console.log("Error en la revalidacion act cte", error);
                    modalError("Error en la revalidacion");
                });
            }
            else {
                vm.modalConfirmarAC.claseError = 'has-error';
                return;
            }
        }

        vm.aceptarAprobacionAC = function () {
            $aprovacionService.aprobacionAC({ idUsuario: usuario, idPrecliente: idPrecliente, observacion: vm.modalConfirmarAC.Observacion })
                .then(function (data) {
                    if (data.data.resultado) {
                        //vm.cerrarModalAC();
                        //vm.modalOKAprobacion("Se realizó la revalidación satisfactoriamente.");
                        window.location.reload(true);
                    } else {
                        console.log("Error en la aprovacion", data.data.mensaje);
                        modalError(data.data.mensaje);
                    }
                }, function (error) {
                    modalError("Error en la aprovacion");
                    console.log("Error en la aprovacion", error);
                });
        }

        vm.cerrarModalAC = function () {
            console.log("cerrarModal");
            $('.popupoverlay').fadeOut('fast');
            $('#popup-confirmAC').fadeOut('fast');
        }
    }
})();
