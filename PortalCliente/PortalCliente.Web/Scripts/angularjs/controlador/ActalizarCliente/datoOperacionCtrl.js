(function () {
    'use strict';

    angular
        .module('app')
        .controller('datoOperacionCtrl', datoOperacion);

    datoOperacion.$inject = ['$scope', '$tabuladoresService', '$catalogoService',
        '$TabuladorProcedimientoOperacionService', '$registroClienteService',
        '$capturaClienteService', '$aprovacionService', '$actualizaClienteService', '$q'];

    function datoOperacion($scope, $tabuladoresService, $catalogoService,
        $TabuladorProcedimientoOperacionService, $registroClienteService,
        $capturaClienteService, $aprovacionService, $actualizaClienteService, $q) {
        var vm = $scope;
        vm.modelo = {};
        vm.modelo.TabuladorDinamico = [];
        vm.modelo.InformacionContacto = [];

        vm.tabularDinamico = {};
        vm.contacto = {};
        vm.tarifa = {};

        vm.catalogoEquipoOperativo = [];

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

        vm.agregarTabDinamico = function () {
            var tab = objTab();
            vm.modelo.TabuladorDinamico.push(tab);
            tab = {};
        }

        vm.eliminarTabulador = function (index) {
            vm.modelo.TabuladorDinamico.splice(index, 1);
            numero_tabs -= 1;
        }

        var id_ciudad_aux = "";
        vm.buscarDatosTabuladores = function (id) {
            $tabuladoresService.BuscarDatosTabuladores({ id_precliente: idPrecliente }).then(function (data) {
                if (data.data.resultado) {
                    vm.modelo = data.data.data[0];
                    vm.modelo.IdPrecliente = id;


                    vm.buscarDatosTabuladoresContactos();
                    vm.buscarDatosTabuladoresTarifas();
                    vm.buscarDatosTabuladoresTabs();


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
                    //vm.modelo.EjecutivoVenta = window.aplicacionDatoUsuario.Nombre;

                } 
            }, function (error) {
                console.log("Error en BuscarDatosTabuladores", error);
            });
        }

        vm.buscarDatosTabuladoresContactos = function () {
            vm.modelo.InformacionContacto = [];
            console.log("vm.modelo.InformacionContacto", vm.modelo.InformacionContacto);
            $tabuladoresService.BuscarDatosTabuladoresContactos({ id_precliente: idPrecliente }).then(function (data) {
                console.log("contacto", data.data);
                if (data.data.resultado) {
                    var tabContactos = data.data.data;
                    //console.log("tabContactos", tabContactos);
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
                    console.log("vm.modelo.InformacionContacto", vm.modelo.InformacionContacto);
                } 
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresContactos", error);
                });

            console.log("vm.modelo.InformacionContacto", vm.modelo.InformacionContacto);
        }

        vm.buscarDatosTabuladoresTarifas = function () {
            vm.modelo.TarifaServicio = [];
            $tabuladoresService.BuscarDatosTabuladoresTarifas({ id_precliente: idPrecliente }).then(function (data) {
                console.log("tarifa", data.data);
                if (data.data.resultado) {
                    var tabTarifas = data.data.data;
                    
                    vm.tarifa = {};
                    angular.forEach(tabTarifas, function (elemento, index) {
                        vm.tarifa.Servicio = elemento.servicio;
                        vm.tarifa.Tarifa = elemento.tarifa;
                        vm.tarifa.Notas = elemento.notas;
                        vm.modelo.TarifaServicio.push(vm.tarifa);
                        vm.tarifa = {};
                        filasTarifasTab++;
                    });
                }
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresTarifas", error);
            });
        }


        function obtenerConceptoFacturacionPorEmpresa(empresas) {
            var promesas = [];
            angular.forEach(empresas, function (empresa, index) {

                promesas.push($catalogoService.obtenerConceptoFacturacion({ empresa: empresa.empresa }));
            });

            return promesas;


        }

        vm.buscarDatosTabuladoresTabs = function () {
            numero_tabs = 0;
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

                            vm.tabularDinamico.IdTab = elemento.id_tabulador_tab;
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


                } 
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresTabs", error);
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
        vm.buscarDatosTabuladoresEmpresa = function (id_tabulador_tab) {
            $tabuladoresService.BuscarDatosTabuladoresEmpresa({ id_tabulador_tab: id_tabulador_tab }).then(function (data) {
                if (data.data.resultado) {
                    //var empresa_aux = data.data.data[0];
                    //vm.tabularDinamico.empresaGrid = data.data.data;
                    var objServicio = data.data.data;

                    var empresaTemp = {};
                    empresaTemp.Empresa = objServicio.empresa;
                    empresaTemp.ConceptoFacturacion = objServicio.concepto_facturacion;
                    empresaTemp.ConceptoAutoFacturacion = objServicio.concepto_auto_facturacion;
                    empresaTemp.TarifaVenta = objServicio.tarifa_venta;
                    empresaTemp.TarifaVentaMoneda = objServicio.tarifa_venta_tipo_moneda;
                    empresaTemp.TarifaCompra = objServicio.tarifa_compra;
                    empresaTemp.TarifaCompraMoneda = objServicio.tarifa_compra_tipo_moneda;
                    vm.tabularDinamico.Empresa.push(empresaTemp);



                } else {
                }
            }, function (error) {
                console.log("Error en BuscarDatosTabuladoresEmpresa", error);
            });
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

        //***Grid contacto ***
        vm.agregarContacto = function (contacto) {
            console.log("vm.modelo.InformacionContacto", vm.modelo.InformacionContacto);
            if (validarCampoContacto(contacto)) {
                
                filasContactosTab++;
                contacto.UsuarioCreacion = 'Test';
                vm.modelo.InformacionContacto.push(contacto);
                vm.contacto = {};
                $('#req-table1').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        }

        vm.eliminarFilaContacto = function (index) {
            vm.modelo.InformacionContacto.splice(index, 1);
        }

        vm.editarFilaContacto = function (index) {
            window.editFilas(index)
        }

        vm.actualizarFilaContacto = function (index) {
            window.saveFilas(index)
        }
        //***Grid contacto ***

        //***Grid Tarifa servicio ***

        vm.agregarTarifaServicio = function (tarifa) {
            if (validarCampoTarifa(tarifa)) {
                filasTarifasTab++;
                tarifa.UsuarioCreacion = 'Test';
                vm.modelo.TarifaServicio.push(tarifa);
                vm.tarifa = {};
                $('#req-table1').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        }

        vm.eliminarFilaTarifaServicio = function (index) {
            vm.modelo.TarifaServicio.splice(index, 1);
        }

        vm.editarFilaTarifaServicio = function (index) {
            window.editFilas(index)
        }

        vm.actualizarFilaTarifaServicio = function (index) {
            window.saveFilas(index)
        }
        //***Grid Tarifa servicio ***

        //***Grid Tab empresa dinamico ***

        vm.agregarEmpresa = function (tabEmpresa) {
            //console.log("tabEmpresa.empresaGrid", tabEmpresa.empresaGrid);
            if (validarCampoEmpresa(tabEmpresa.empresaGrid)) {
                filasEmpresaTab++;
                tabEmpresa.empresaGrid.UsuarioCreacion = 'Test';
                tabEmpresa.empresaGrid.catalogoConceptoFacturacion = angular.copy(vm.catalogoConceptoFacturacion);

                //
                angular.forEach(tabEmpresa.empresaGrid.catalogoConceptoFacturacion, function (elemento, index) {
                    if (elemento.Id === tabEmpresa.empresaGrid.ConceptoFacturacion.Id) {
                        tabEmpresa.empresaGrid.ConceptoFacturacion = elemento;
                        return;
                    }
                });

                tabEmpresa.Empresa.push(tabEmpresa.empresaGrid);
                $('#req-table1').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }

            tabEmpresa.empresaGrid = {};
            vm.catalogoConceptoFacturacion = {};
        }

        vm.eliminarFilaEmpresa = function (tabEmpresa, index) {
            tabEmpresa.Empresa.splice(index, 1);
        }

        vm.editarFilaEmpresa = function (index) {
            window.editFilas(index)
        }

        vm.actualizarFilaEmpresa = function (index) {
            window.saveFilas(index)
        }

        //***Grid Tab empresa dinamico ***

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

        vm.obtenerConceptoFacturacion = function (empresa) {
            $catalogoService.obtenerConceptoFacturacion({ empresa: empresa }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoConceptoFacturacion = data.data.data;
                    //console.log("conceptoFacturacion", vm.catalogoConceptoFacturacion);
                    //cargaciudad();
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }

        vm.obtenerConceptoFacturacionEdicion = function (tab) {
            $catalogoService.obtenerConceptoFacturacion({ empresa: tab.Empresa }).then(function (data) {
                if (data.data.resultado) {
                    tab.catalogoConceptoFacturacion = data.data.data;
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }


        //***Grid Tarifa servicio ***

        function validarCampoContacto(contacto) {
            if (contacto) {
                if (!contacto.Contacto || !contacto.Nombre || !contacto.Puesto || !contacto.Telefono || !contacto.Email) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        function validarCampoTarifa(tarifa) {
            if (tarifa) {
                if (!tarifa.Servicio || !tarifa.Tarifa || !tarifa.Notas) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        function validarCampoEmpresa(empresa) {
            if (empresa) {
                if (empresa.Empresa || empresa.ConceptoFacturacion || empresa.ConceptoAutoFacturacion
                    || empresa.TarifaVenta || empresa.TarifaVentaMoneda || empresa.TarifaCompra
                    || empresa.TarifaCompraMoneda) {
                    return true;
                }
                else {
                    return false;
                }
            } else {
                return false;
            }
        }

        function modalError(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popupFinOperacion').fadeIn('fast');
            $('#popupFinOperacion .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensajeFinOperacion').innerHTML = mensaje;
        };

        //evento 
        $scope.$on("seleccion_busqueda", function (evet, data) {
            idPrecliente = data.IdPrecliente;
            idUsrPrecliente = data.IdUsuario;
            vm.modelo.IdPrecliente = data.IdPrecliente;
            vm.buscarDatosTabuladores(data.IdPrecliente);
           

            //para procedimiento
            vm.arrayProcedimiento = [];
            resolverPromesas(data);
            //console.log("seleccion_busqueda");
        });

        /***para procedimiento***/

        vm.dirrecionCliente = {};
        vm.arrayProcedimiento = [];
        vm.contactoCliente = [];
        vm.numeroTabs;
        vm.ContactosEI = {};

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
            var promesatabitems = $TabuladorProcedimientoOperacionService.GetTabuladorTab(datoBusqueda.IdPrecliente);
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
                    vm.Secciones = [];
                    var temp2 = promesas.promesaDatosTituloSecciones.data.data;
                    for (var i = 0; i < temp2.length; i++) {
                        vm.Secciones.push(temp2[i]);
                    }
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

            })
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
                procedimiento.Secciones = vm.Secciones[index];
                //console.log(procedimiento.Id_FormaPago)

            }

            //console.log("arrayprocedimiento");
            //console.log(vm.arrayProcedimiento);
        }

        function creaarraycatalogo(items) {
            var array = [];

            for (var i = 0; i < items.length; i++) {
                var item = {};
                item.Id = i;
                item.Descripcion = items[i];
                item.Clave = "";
                array.push(item);
            }
            return array;
        }

        function validacionProcedimiento() {
            var correcto = true;

            angular.forEach(vm.arrayProcedimiento, function (Procedimiento, index) {

                $(".reqpo" + Procedimiento.Indice).css({ 'border-color': '' });
                $(".ddlreqpo" + Procedimiento.Indice).css({ 'border': '0px solid black' });


                $(".reqpo" + Procedimiento.Indice).each(function () {
                    if ($(this).val().trim().length == 0) {
                        $(this).css({ 'border-color': 'red' });

                        correcto = false;
                        console.log("$(this)", $(this));
                    }
                });

                $(".ddlreqpo" + Procedimiento.Indice).each(function () {
                    if ($(this).val() == 0) {
                        $(this).css({ 'border': '1px solid red' });
                        correcto = false;
                        console.log("$(this)", $(this));
                    }
                });
            });

            console.log("correcto", correcto);

            return correcto;
        }

        function validacionTabulador() {
            var error = 0;

            resetearCamposTabuladores(numero_tabs);

            if (idPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            // Iniciales
            if (document.getElementById('in1').value == '') {
                $('#in1').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in2').value == '') {
                $('#in2').css({ 'border-color': 'red' });
                error++;
            }
            // Tipo de Cliente
            if (!(document.getElementById('ped').checked) && !(document.getElementById('fact').checked) && !(document.getElementById('ped-fact').checked)) {
                $('#l1').css({ 'color': 'red' });
                $('#l2').css({ 'color': 'red' });
                $('#l3').css({ 'color': 'red' });
                error++;
            }
            if (document.getElementById('in3').value == '') {
                $('#in3').css({ 'border-color': 'red' });
                error++;
            }
            if ((document.getElementById('ped').checked) || (document.getElementById('fact').checked)) {
                if (document.getElementById('in4').value == '') {
                    $('#in4').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in5').value == '') {
                    $('#in5').css({ 'border-color': 'red' });
                    error++;
                }
            }

            // Instrucciones de Facturación
            if (!(document.getElementById('factchecksi1').checked) && !(document.getElementById('factcheckno1').checked)) {
                $('#l4').css({ 'color': 'red' });
                error++;
                console.log("check1");
            }
            if (vm.modelo.SitioFTP) {
                if (document.getElementById('in6Tab').value == '') {
                    $('#in6Tab').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in7Tab').value == '') {
                    $('#in7Tab').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in8Tab').value == '') {
                    $('#in8Tab').css({ 'border-color': 'red' });
                    error++;
                }
            }
            if (!(document.getElementById('entregasi').checked) && !(document.getElementById('entregano').checked)) {
                $('#l5').css({ 'color': 'red' });
                error++;
                console.log("check2");
            }
            if (vm.modelo.EntregaFisica) {
                if (document.getElementById('inT9').value == '') {
                    $('#inT9').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('inT10').value == '') {
                    $('#inT10').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('inT11').value == '') {
                    $('#inT11').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('inT12').value == '') {
                    $('#inT12').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in13').value == '') {
                    $('#in13').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in14').value == '') {
                    $('#in14').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in15').value == '') {
                    $('#in15').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in16').value == '') {
                    $('#in16').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in17').value == '') {
                    $('#in17').css({ 'border-color': 'red' });
                    error++;
                }
            }

            // Tabuladores General

            if (document.getElementById("cteped1").checked === true || document.getElementById("ctefact1").checked === true) {
                if (document.getElementById('in21').value == '') {
                    $('#in21').css({ 'border-color': 'red' });
                    error++;
                }
            }

            if (document.getElementById("cteped2").checked === true || document.getElementById("ctefact2").checked === true) {
                if (document.getElementById('in20').value == '') {
                    $('#in20').css({ 'border-color': 'red' });
                    error++;
                }
            }

            if (document.getElementById("cteped3").checked === true || document.getElementById("ctefact3").checked === true) {
                if (document.getElementById('in19').value == '') {
                    $('#in19').css({ 'border-color': 'red' });
                    error++;
                }
            }

            if (document.getElementById("cteped4").checked === true || document.getElementById("ctefact4").checked === true) {
                if (document.getElementById('in18').value == '') {
                    $('#in18').css({ 'border-color': 'red' });
                    error++;
                }
            }

            if (document.getElementById('in23').value == '') {
                $('#in23').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in24').value == '') {
                $('#in24').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in25').value == '') {
                $('#in25').css({ 'border-color': 'red' });
                error++;
            }

            // Información de Cobranza
            if (document.getElementById('in26').value == '') {
                $('#in26').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in27').value == '') {
                $('#in27').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in28').value == '') {
                $('#in28').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in29').value == '') {
                $('#in29').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById("factchecksi5").checked === false && document.getElementById("factcheckno5").checked === false) {
                $('#l10').css({ 'color': 'red' });
                error++;
            }
            if (filasContactosTab === 0) {
                $('#contacto-tab').css({ 'border-color': 'red' });
                $('#nombre-tab').css({ 'border-color': 'red' });
                $('#puesto-tab').css({ 'border-color': 'red' });
                $('#telefono-tab').css({ 'border-color': 'red' });
                $('#email-tab').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById("factchecksi6").checked === false && document.getElementById("factcheckno6").checked === false) {
                $('#l11').css({ 'color': 'red' });
                error++;
            }
            if (document.getElementById("factchecksi6").checked === true) {
                if (document.getElementById('monto').value == '') {
                    $('#monto').css({ 'border-color': 'red' });
                    error++;
                }
            }
            if (document.getElementById("factchecksi7").checked === false && document.getElementById("factcheckno7").checked === false) {
                $('#l12').css({ 'color': 'red' });
                error++;
            }
            if (document.getElementById("factchecksi7").checked === true) {
                if (document.getElementById('in30').value == '') {
                    $('#in30').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in31').value == '') {
                    $('#in31').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in32').value == '') {
                    $('#in32').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in33').value == '') {
                    $('#in33').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in34').value == '') {
                    $('#in34').css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('in35').value == '') {
                    $('#in35').css({ 'border-color': 'red' });
                    error++;
                }
            }

            // Tarifa de ventas de posibles servicios
            if (filasTarifasTab === 0) {
                $('#in36').css({ 'border-color': 'red' });
                $('#in37').css({ 'border-color': 'red' });
                $('#in38').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in39').value == '') {
                $('#in39').css({ 'border-color': 'red' });
                error++;
            }

            // Pie de N tabuladores
            if (document.getElementById('in40').value == '') {
                $('#in40').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in41').value == '') {
                $('#in41').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in42').value == '') {
                $('#in42').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in43').value == '') {
                $('#in43').css({ 'border-color': 'red' });
                error++;
            }

            //campos nuevos banco

            // N tabuladores
            for (var i = 1; i <= numero_tabs; i++) {
                if (document.getElementById('TipoOperacionTab' + i).value == '') {
                    $('#TipoOperacionTab' + i).css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('AduanaTab' + i).value == '') {
                    $('#AduanaTab' + i).css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('ClavePedimentoTab' + i).value == '') {
                    $('#ClavePedimentoTab' + i).css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('MonedaTab' + i).value == '') {
                    $('#MonedaTab' + i).css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('FacturacionTab' + i).value == '') {
                    $('#FacturacionTab' + i).css({ 'border-color': 'red' });
                    error++;
                }
                if (document.getElementById('DiasLibresTab' + i).value == '') {
                    $('#DiasLibresTab' + i).css({ 'border-color': 'red' });
                    error++;
                }
                if (filasEmpresaTab === 0) {
                    $('#EmpresaTab' + i).css({ 'border-color': 'red' });
                    $('#ConceptoFacturacionTab' + i).css({ 'border-color': 'red' });
                    $('#ConceptoAutoFacturacionTab' + i).css({ 'border-color': 'red' });
                    $('#TarifaVentaTab' + i).css({ 'border-color': 'red' });
                    $('#TarifaVentaTipoMonedaTab' + i).css({ 'border-color': 'red' });
                    $('#TarifaCompraTab' + i).css({ 'border-color': 'red' });
                    $('#TarifaCompraTipoMonedaTab' + i).css({ 'border-color': 'red' });
                    error++;
                }
            }

            //validar datos tabulador banco e id
            if (vm.modelo.ImpuestoPeca) {
                if (!vm.modelo.Banco) {
                    $('#in44').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.modelo.BancoId) {
                    $('#in45').css({ 'border-color': 'red' });
                    error++;
                }
            }

            return error > 0 ? false : true;
        }

        function resetearCamposTabuladores(num) {
            $('#in1').css({ 'border-color': '#cccccc' });
            $('#in2').css({ 'border-color': '#cccccc' });
            $('#l1').css({ 'color': '#616161' });
            $('#l2').css({ 'color': '#616161' });
            $('#l3').css({ 'color': '#616161' });
            $('#in3').css({ 'border-color': '#cccccc' });
            $('#in4').css({ 'border-color': '#cccccc' });
            $('#in5').css({ 'border-color': '#cccccc' });
            $('#l4').css({ 'color': '#616161' });
            $('#in6Tab').css({ 'border-color': '#cccccc' });
            $('#in7Tab').css({ 'border-color': '#cccccc' });
            $('#in8Tab').css({ 'border-color': '#cccccc' });
            $('#l5').css({ 'color': '#616161' });
            $('#inT9').css({ 'border-color': '#cccccc' });
            $('#inT10').css({ 'border-color': '#cccccc' });
            $('#inT11').css({ 'border-color': '#cccccc' });
            $('#inT12').css({ 'border-color': '#cccccc' });
            $('#in13').css({ 'border-color': '#cccccc' });
            $('#in14').css({ 'border-color': '#cccccc' });
            $('#in15').css({ 'border-color': '#cccccc' });
            $('#in16').css({ 'border-color': '#cccccc' });
            $('#in17').css({ 'border-color': '#cccccc' });
            $('#l6').css({ 'color': '#616161' });
            $('#l7').css({ 'color': '#616161' });
            $('#l8').css({ 'color': '#616161' });
            $('#l9').css({ 'color': '#616161' });
            $('#in18').css({ 'border-color': '#cccccc' });
            $('#in19').css({ 'border-color': '#cccccc' });
            $('#in20').css({ 'border-color': '#cccccc' });
            $('#in21').css({ 'border-color': '#cccccc' });
            $('#in22').css({ 'border-color': '#cccccc' });
            $('#in23').css({ 'border-color': '#cccccc' });
            $('#in24').css({ 'border-color': '#cccccc' });
            $('#in25').css({ 'border-color': '#cccccc' });
            $('#in26').css({ 'border-color': '#cccccc' });
            $('#in27').css({ 'border-color': '#cccccc' });
            $('#in28').css({ 'border-color': '#cccccc' });
            $('#in29').css({ 'border-color': '#cccccc' });
            $('#l10').css({ 'color': '#616161' });
            $('#contacto-tab').css({ 'border-color': '#cccccc' });
            $('#nombre-tab').css({ 'border-color': '#cccccc' });
            $('#puesto-tab').css({ 'border-color': '#cccccc' });
            $('#telefono-tab').css({ 'border-color': '#cccccc' });
            $('#email-tab').css({ 'border-color': '#cccccc' });
            $('#l11').css({ 'color': '#616161' });
            $('#monto').css({ 'border-color': '#cccccc' });
            $('#l12').css({ 'color': '#616161' });
            $('#in30').css({ 'border-color': '#cccccc' });
            $('#in31').css({ 'border-color': '#cccccc' });
            $('#in32').css({ 'border-color': '#cccccc' });
            $('#in33').css({ 'border-color': '#cccccc' });
            $('#in34').css({ 'border-color': '#cccccc' });
            $('#in35').css({ 'border-color': '#cccccc' });
            $('#in36').css({ 'border-color': '#cccccc' });
            $('#in37').css({ 'border-color': '#cccccc' });
            $('#in38').css({ 'border-color': '#cccccc' });
            $('#in39').css({ 'border-color': '#cccccc' });
            $('#in40').css({ 'border-color': '#cccccc' });
            $('#in41').css({ 'border-color': '#cccccc' });
            $('#in42').css({ 'border-color': '#cccccc' });
            $('#in43').css({ 'border-color': '#cccccc' });
            for (var i = 1; i <= num; i++) {
                $('#TipoOperacionTab' + i).css({ 'border-color': '#cccccc' });
                $('#AduanaTab' + i).css({ 'border-color': '#cccccc' });
                $('#ClavePedimentoTab' + i).css({ 'border-color': '#cccccc' });
                $('#MonedaTab' + i).css({ 'border-color': '#cccccc' });
                $('#FacturacionTab' + i).css({ 'border-color': '#cccccc' });
                $('#DiasLibresTab' + i).css({ 'border-color': '#cccccc' });
                $('#EmpresaTab' + i).css({ 'border-color': '#cccccc' });
                $('#ConceptoFacturacionTab' + i).css({ 'border-color': '#cccccc' });
                $('#ConceptoAutoFacturacionTab' + i).css({ 'border-color': '#cccccc' });
                $('#TarifaVentaTab' + i).css({ 'border-color': '#cccccc' });
                $('#TarifaVentaTipoMonedaTab' + i).css({ 'border-color': '#cccccc' });
                $('#TarifaCompraTab' + i).css({ 'border-color': '#cccccc' });
                $('#TarifaCompraTipoMonedaTab' + i).css({ 'border-color': '#cccccc' });
            }
        }

        vm.recargarPagina = function () {
            if (guardadoExito)
                window.location.reload();
        }
        var guardadoExito = false;

        vm.guardarDatoOperacion = function () {
            var isTabuladorValido = validacionTabulador();
            var isProcedimientoValido = validacionProcedimiento();

            //console.log("isTabuladorValido", isTabuladorValido);
            //console.log("isProcedimientoValido", isProcedimientoValido);
                return;
            if (isTabuladorValido && isProcedimientoValido) {
                vm.modelo.IdPrecliente = idPrecliente;
                vm.modelo.IdUsuario = idUsrPrecliente;
                vm.modelo.IdCiudad = vm.modelo.id_ciudad;
                vm.modelo.IdEstado = vm.modelo.id_estado;

               // console.log("modelo en guardar dato op", vm.modelo);

                angular.forEach(vm.arrayProcedimiento, function (Procedimiento, index) {

                    Procedimiento.Vinculacion = Procedimiento.Vinculacion == 1 ? true : false;
                    Procedimiento.AplicacionTLCAN = Procedimiento.AplicacionTLCAN == 1 ? true : false;
                    Procedimiento.Incrementables = Procedimiento.Incrementables == 1 ? true : false;
                    Procedimiento.EnvioProformaAutorizacion = Procedimiento.EnvioProformaAutorizacion == 1 ? true : false;
                    Procedimiento.GrupoGeneralEEI = Procedimiento.GrupoGeneralEEI == 1 ? true : false;

                });
               // console.log("listado de tabuladores!", vm.arrayProcedimiento);

                $actualizaClienteService.GuardarDatoOperacion({ modelo: vm.modelo, _ExTabuladorProcedimientoOperacion: vm.arrayProcedimiento }).then(function (data) {
                    if (data.data.resultado) {
                        modalError("Se guardaron los datos correctamente.");
                        guardadoExito = true;
                    } else {
                        modalError("Error al guardar los datos, reintentar.");
                    }
                }, function (error) {
                    console.log("Error en guardarTabulador", error);
                    modalError("Error al guardar los datos, reintentar.");
                });
            } else {
                modalError("Es necesario capturar todos los datos obligatorios");
            }


        }

    }
})();