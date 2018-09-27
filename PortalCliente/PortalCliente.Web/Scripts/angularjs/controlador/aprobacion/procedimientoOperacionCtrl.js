(function () {
    'use strict';

    angular
        .module('app')
        .controller('procedimientoOperacionCtrl', procedimientoOperacion);

    procedimientoOperacion.$inject = ['$scope', '$aprovacionService', '$TabuladorProcedimientoOperacionService', '$registroClienteService', '$q', '$tabuladoresService', '$catalogoService', '$capturaClienteService'];

    function procedimientoOperacion($scope, $aprovacionService, $TabuladorProcedimientoOperacionService, $registroClienteService, $q, $tabuladoresService, $catalogoService, $capturaClienteService) {
        var vm = $scope;
        vm.inputDisable = true;
        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        var id_usrSelected = "";
        var id_cteSelected = "";

        vm.listaCuenta = [];
        vm.dirrecionCliente = {};
        vm.arrayProcedimiento = [];
        vm.numeroTabs;
        vm.datoProcedimiento = {};
        vm.contactoCliente = [];
        vm.Secciones = [];

        vm.modelo = {};
        vm.modelo.TipoCliente = 1;
        vm.modelo.IdPrecliente = 1;
        vm.modelo.IdUsuario = window.aplicacionDatoUsuario.IdUsuario;
        vm.modelo.SitioFTP = true;
        vm.modelo.SuspenderCliente = true;
        vm.modelo.EntregaFisica = true;
        vm.modelo.Fondo = true;
        vm.modelo.Financiamiento = true;
        vm.modelo.InformacionContacto = [];
        vm.modelo.TarifaServicio = [];
        vm.modelo.TabuladorDinamico = [];

        vm.tabularDinamico = {};
        vm.contacto = {};
        vm.tarifa = {};


        vm.ContactosEI = [];
        vm.UsrsAduabook = [];
        vm.VucemCliente;
        vm.TipoCliente;

        vm.idtabs = [];

        function obtenerPromesas3(datoBusqueda) {
            var promesaCuenta = $aprovacionService.obtenerListaCuentaBanco({ 'idPrecliente': datoBusqueda.IdPrecliente });
            var promesaDireccion = $aprovacionService.obtenerDireccionCliente({ 'idPrecliente': datoBusqueda.IdPrecliente });
            var promesaNumeroTab = $aprovacionService.obtenerNumeroTabulador({ 'idUsuario': datoBusqueda.IdUsuario, 'idPrecliente': datoBusqueda.IdPrecliente });
            var promesatabitems = $TabuladorProcedimientoOperacionService.GetTabuladorTab(datoBusqueda.IdPrecliente);
            var promesaDatoCliente = $registroClienteService.ObtieneDatosCliente(datoBusqueda.IdUsuario);
            var promesaDatosTituloSecciones = $registroClienteService.ObtieneDatosTituloSecciones({ 'idPrecliente': datoBusqueda.IdPrecliente });
            //VRF2
            return $q.all({
                promesaCuenta,
                promesaDireccion,
                promesaNumeroTab,
                promesatabitems,
                promesaDatoCliente,
                promesaDatosTituloSecciones
            });
        }

        function resolverPromesa(datoBusqueda) {
            obtenerPromesas3(datoBusqueda).then(function (promesas) {
                //console.log("promesas.promesaDatoCliente.data", promesas);
                if (promesas.promesaCuenta.data.resultado) {
                    vm.listaCuenta = promesas.promesaCuenta.data.data;
                    //console.log("vm.listaCuenta", vm.listaCuenta);
                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaDireccion.data.resultado) {
                    vm.dirrecionCliente = promesas.promesaDireccion.data.data;
                    //console.log("vm.dirrecionCliente", vm.dirrecionCliente);
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

                if (promesas.promesaNumeroTab.data.resultado) {
                    vm.numeroTabs = promesas.promesaNumeroTab.data.data;

                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesatabitems.data.respuesta) {
                    vm.datoProcedimiento = promesas.promesatabitems.data.items;
                    //console.log("vm.datoProcedimiento", vm.datoProcedimiento);

                } else {
                    console.log("Error", promesas.promesatabitems.data);
                }
                if (promesas.promesaDatoCliente.data) {
                    vm.contactoCliente = promesas.promesaDatoCliente.data.Contacto;
                    vm.VucemCliente = promesas.promesaDatoCliente.data.VucemCliente;

                    if (vm.VucemCliente == true)
                        vm.TipoCliente = "agente aduanal";
                    else
                        vm.TipoCliente = "cliente";
                }
                if (promesas.promesaNumeroTab.data.resultado &&
                    promesas.promesaCuenta.data.resultado &&
                    promesas.promesaDireccion.data.resultado)
                    crearArrayProcedimiento();
            })
        }

        var id_estatus_cliente;

        $scope.$on("seleccion_busqueda", function (evet, data) {

            id_estatus_cliente = data.Estatus;

            //console.log("seleccion_busqueda -- aprobador!!", data);
            id_cteSelected = data.IdPrecliente;
            id_usrSelected = data.IdUsuario;
            resolverPromesa(data);

            reinitializeVars();
            vm.buscarDatosTabuladores();
            //vm.buscarDatosTabuladoresContactos();
            vm.buscarDatosTabuladoresTarifas();

            for (var i = 0; i < vm.arrayProcedimiento.length; i++) {
                var procedimiento = vm.arrayProcedimiento[i];

            }
        });

        vm.init = function () {
            $catalogoService.obtenerEstados({ IdPais: "N3" }).then(function (data) {
                //console.log("obtenerEstados: " + data);
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
                    //console.log("aduanas", vm.catalogoAduanas);
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

        var id_ciudad_aux = "";
        vm.buscarDatosTabuladores = function () {

            $tabuladoresService.BuscarDatosTabuladores({ id_precliente: id_cteSelected }).then(function (data) {
                if (data.data.resultado) {
                    //console.log("buscarDatosTabuladores", data.data.data[0]);
                    vm.modelo = data.data.data[0];
                    if (vm.modelo.TipoCliente === 1) { cambiarEtiqueta('Pedimento') }
                    else if (vm.modelo.TipoCliente === 2) { cambiarEtiqueta('Factura'); }
                    else if (vm.modelo.TipoCliente === 3) { $(".nombre-alta, .cliente-pedimento").slideUp('fast'); }
                    id_ciudad_aux = vm.modelo.id_ciudad;
                    vm.seleccionarEstado(vm.modelo.id_estado);
                } else {
                }
            }, function (error) {
                console.log("Error en BuscarDatosTabuladores", error);
            });
        }
        vm.seleccionarEstado = function (id_estado) {
            angular.forEach(vm.catalogoEstado, function (estados, index) {
                if (estados.id == id_estado) {
                    vm.modelo.Estado = vm.catalogoEstado[index];
                    vm.obtenerCiudadNueva(vm.modelo.Estado.id);

                }
            });
        }
        vm.buscarDatosTabuladoresTarifas = function () {
            //console.log("buscarDatosTabuladoresTarifas");
            $tabuladoresService.BuscarDatosTabuladoresTarifas({ id_precliente: id_cteSelected }).then(function (data) {
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

        function obtenerInformacionCte(data) {
            $aprovacionService.ObtenerInfActCte({ idUsuario: data.IdUsuario, idPrecliente: data.IdPrecliente }).then(function (data) {
                vm.modelActCte = data.data.data;
                //console.log("datos act cliente aprobacion!!", vm.modelActCte);
            }, function (error) {
                console.log("Error al obtener datos de inf cliente", error);
            });
        }

        vm.revalidacionProcedimiento = function () {
            $('#popup-confirm').fadeIn('fast');
            $('#popupoverlay').fadeIn('fast');
            $('#popup-confirm .texttarea').fadeIn('fast');
            $('#popup-confirm #obs').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
            vm.modalConfirmar = {};
            vm.modalConfirmar.isRevalidacion = true;
            //console.log("revalidacionProcedimiento");
        }

        vm.aprobarProcedimiento = function () {
            vm.modalConfirmar = {};
            vm.modalConfirmar.isRevalidacion = false;
            $('#popup-confirm').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
        }

        vm.aceptarRevalidacion = function () {
            //console.log("aceptarAprobacion");
            if (vm.modalConfirmar.Observacion) {

                var nuevo_estatus = 0;

                if (id_estatus_cliente === 10) {
                    nuevo_estatus = 12;
                }
                else if (id_estatus_cliente === 11) {
                    nuevo_estatus = 13;
                }

                $aprovacionService.revalidacion({ idUsuario: usuario, idPrecliente: id_cteSelected, estatus: nuevo_estatus, observacion: vm.modalConfirmar.Observacion }).then(function (data) {
                    //vm.cerrarModal();
                    window.location.reload(true);
                }, function (error) {
                    console.log("Error en la revalidacion", error);
                });

            }
            else {
                vm.modalConfirmar.claseError = 'has-error';
                return;
            }
        }

        vm.aceptarRevalidacionAC = function () {
            //console.log("revalidacion act cliente");

            if (vm.modalConfirmarAC.Observacion) {

                $aprovacionService.revalidacionAC({ idUsuario: usuario, idPrecliente: id_cteSelected, observacion: vm.modalConfirmarAC.Observacion }).then(function (data) {
                    if (data.data.resultado) {
                        //vm.cerrarModalAC();
                        //vm.modalOKAprobacion("Se realizó la revalidación satisfactoriamente.");
                        window.location.reload(true);
                    } else {
                        console.log("Error en la revalidacion act cte", data.data.mensaje);
                    }
                }, function (error) {
                    console.log("Error en la revalidacion act cte", error);
                });
            }
            else {
                vm.modalConfirmarAC.claseError = 'has-error';
                return;
            }
        }

        vm.aceptarAprobacion = function (tipoAp) {

            //console.log("aceptarAprobacion");

            var nuevo_estatus = 0;

            if (id_estatus_cliente === 10) {
                nuevo_estatus = 7;
            }
            else if (id_estatus_cliente === 11) {
                nuevo_estatus = 9;
            }
            $('#popup-confirm').fadeOut('fast');
            $aprovacionService.aprobacion({ idUsuario: usuario, idPrecliente: id_cteSelected, estatus: nuevo_estatus }).then(function (data) {
                //vm.modalOKAprobacion("Se realizó la aprobación satisfactoriamente.");
                window.location.reload(true);
            }, function (error) {
                console.log("Error en la aprovacion", error);
            });
        }

        vm.aceptarAprobacionAC = function () {
            $aprovacionService.aprobacionAC({ idUsuario: usuario, idPrecliente: id_cteSelected, observacion: vm.modalConfirmarAC.Observacion }).then(function (data) {
                vm.cerrarModalAC();
            }, function (error) {
                console.log("Error en la aprovacion", error);
            });
        }

        vm.cerrarModal = function () {
            console.log("cerrarModal");
            $('.popupoverlay').fadeOut('fast');
            $('#popup-confirm').fadeOut('fast');
        }

        vm.cerrarModalAC = function () {
            console.log("cerrarModal");
            $('.popupoverlay').fadeOut('fast');
            $('#popup-confirmAC').fadeOut('fast');
        }

        vm.modalOKAprobacion = function (mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popupOKAprobacion').fadeIn('fast');
            $('#popupOKAprobacion .icon i').addClass('far fa-check-circle');
            document.getElementById('mensajeOKAprobacion').innerHTML = mensaje;
        }
    
        function crearArrayProcedimiento() {
            for (var index = 0; index < vm.numeroTabs; index++) {
                var procedimiento = {};
                procedimiento.Cuentas = vm.listaCuenta;
                procedimiento.Precliente = {};
                procedimiento.Precliente.NombreComercial = vm.dirrecionCliente.NombreComercial;
                procedimiento.Precliente.Direccion = vm.dirrecionCliente.Direccion;
                procedimiento.Precliente.ContactoCliente = vm.contactoCliente;
                procedimiento.Dato = vm.datoProcedimiento[index];
                vm.arrayProcedimiento.push(procedimiento);
                procedimiento.Secciones = vm.Secciones[index];
            }
            //console.log("vm.arrayProcedimiento", vm.arrayProcedimiento);
        }

        vm.revalidacionActCliente = function () {
            vm.modalConfirmarAC = {};
            vm.modalConfirmarAC.Observacion = '';
            $('#popup-confirmAC').fadeIn('fast');
            $('#popupoverlay').fadeIn('fast');
            $('#popup-confirmAC .texttarea').fadeIn('fast');
            $('#popup-confirmAC #obs').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
            vm.modalConfirmarAC = {};
            vm.modalConfirmarAC.isRevalidacion = true;
            //console.log("revalidacionProcedimiento");
        }

        vm.aprobarActCliente = function () {
            vm.modalConfirmarAC = {};
            vm.modalConfirmarAC.isRevalidacion = false;
            vm.modalConfirmarAC.Observacion = '';
            $('#popup-confirmAC').fadeIn('fast');
            $('.popupoverlay').fadeIn('fast');
        }

        function reinitializeVars() {
            vm.modelo = {};
            vm.modelo.TipoCliente = 1;
            vm.modelo.IdPrecliente = 1;
            vm.modelo.IdUsuario = window.aplicacionDatoUsuario.IdUsuario;
            vm.modelo.SitioFTP = true;
            vm.modelo.SuspenderCliente = true;
            vm.modelo.EntregaFisica = true;
            vm.modelo.Fondo = true;
            vm.modelo.Financiamiento = true;
            vm.modelo.InformacionContacto = [];
            vm.modelo.TarifaServicio = [];
            vm.modelo.TabuladorDinamico = [];
            vm.arrayProcedimiento = [];

            vm.tabularDinamico = {};
            vm.contacto = {};
            vm.tarifa = {};
        }

        //funcionalidad para llenar procedimiento de operacion
        //function obtenerPromesas(datoBusqueda) {

        //    var promesaformapago = $TabuladorProcedimientoOperacionService.GetFormaPagos();
        //    var promesaicoterms = $TabuladorProcedimientoOperacionService.GetExIncoterms();
        //    var promesaValoracions = $TabuladorProcedimientoOperacionService.GetExMetodoValoracions();
        //    var promesaRegimens = $TabuladorProcedimientoOperacionService.GetRegimens();
        //    var prinesaaplicacionespreferencia = $TabuladorProcedimientoOperacionService.GetApliacacionPreferencia();

        //    var promesaCuenta = $capturaClienteService.obtenerListaCuentaBanco({ 'idPrecliente': datoBusqueda.IdPrecliente });
        //    var promesaDireccion = $capturaClienteService.obtenerDireccionCliente({ 'idPrecliente': datoBusqueda.IdPrecliente });
        //    var promesaNumeroTab = $capturaClienteService.obtenerNumeroTabulador({ 'idUsuario': datoBusqueda.IdUsuario, 'idPrecliente': datoBusqueda.IdPrecliente });
        //    var promesaTabuladorTabs = $capturaClienteService.ObtieneTabsPrecliente(datoBusqueda.IdPrecliente);
        //    var promesatabitems = $TabuladorProcedimientoOperacionService.GetTabuladorTab(datoBusqueda.IdPrecliente);


        //    return $q.all({
        //        promesaCuenta,
        //        promesaDireccion,
        //        promesaNumeroTab,
        //        promesaTabuladorTabs,
        //        promesatabitems,
        //        promesaformapago,
        //        promesaicoterms,
        //        promesaValoracions,
        //        promesaRegimens,
        //        prinesaaplicacionespreferencia
        //    })
        //}

        //function resolverPromesas(datoBusqueda) {
        //    //
        //    obtenerPromesas(datoBusqueda).then(function (promesas) {
        //        console.log("resolver promesas en PO", promesas);
        //        if (promesas.promesaCuenta.data.resultado) {
        //            vm.listaCuenta = promesas.promesaCuenta.data.data;
        //        } else {
        //            console.log("Error", promesas.promesaCuenta.data.mensaje);
        //        }

        //        if (promesas.promesaDireccion.data.resultado) {
        //            vm.dirrecionCliente = promesas.promesaDireccion.data.data;
        //        } else {
        //            console.log("Error", promesas.promesaCuenta.data.mensaje);
        //        }

        //        if (promesas.promesaNumeroTab.data.resultado) {
        //            vm.numeroTabs = promesas.promesaNumeroTab.data.data;

        //        } else {
        //            console.log("Error", promesas.promesaCuenta.data.mensaje);
        //        }

        //        if (promesas.promesaTabuladorTabs.data.resultado) {

        //            console.log("promesas.promesaTabuladorTabs.data.resultado");
        //            console.log(promesas.promesaTabuladorTabs.data.resultado);
        //            var temp = promesas.promesaTabuladorTabs.data.resultado;
        //            vm.idtabs = [];
        //            vm.indices = [];

        //            for (var i = 0; i < temp.length; i++) {

        //                vm.idtabs.push(temp[i].split("|")[0]);
        //                vm.indices.push(temp[i].split("|")[1])

        //            }


        //        } else {
        //            console.log("Error", promesas.promesaTabuladorTabs.data.mensaje);
        //        }

        //        if (promesas.promesaformapago.data.respuesta) {
        //            vm.FormaPagosCat = promesas.promesaformapago.data.items;
        //            //console.log("vm.FormaPagosCat", vm.FormaPagosCat);
        //        }

        //        if (promesas.promesaicoterms.data.respuesta) {
        //            vm.IncotermsCat = promesas.promesaicoterms.data.items;
        //        }

        //        if (promesas.promesaValoracions.data.respuesta) {
        //            vm.MetodoValoracionsCat = promesas.promesaValoracions.data.items;
        //        }

        //        if (promesas.promesaRegimens.data.respuesta) {
        //            vm.RegimensCat = promesas.promesaRegimens.data.items;
        //        }

        //        if (promesas.prinesaaplicacionespreferencia.data.respuesta) {
        //            vm.AplicacionPreferenciaCat = promesas.prinesaaplicacionespreferencia.data.items;

        //        }


        //        if (promesas.promesatabitems.data.respuesta) {
        //            console.log(promesas.promesatabitems.data);
        //            vm.itemstaboper = promesas.promesatabitems.data.items;
        //            console.log("promesas.promesatabitems", promesas.promesatabitems);
        //        }

        //        if (promesas.promesaNumeroTab.data.resultado &&
        //            promesas.promesaCuenta.data.resultado &&
        //            promesas.promesaDireccion.data.resultado &&
        //            promesas.promesaTabuladorTabs.data.resultado &&
        //            promesas.promesatabitems.data.respuesta &&
        //            promesas.promesaformapago.data.respuesta &&
        //            promesas.promesaicoterms.data.respuesta &&
        //            promesas.promesaValoracions.data.respuesta &&
        //            promesas.promesaRegimens.data.respuesta &&
        //            promesas.prinesaaplicacionespreferencia.data.respuesta) {
        //            crearArrayProcedimientoPO();

        //        }



        //        //console.log("usuario en PO", usuario);

        //        //$registroClienteService.ObtieneDatosClientePost({ idusuario: datoBusqueda.IdUsuario }).then(function (data) {
        //        //    var v = data.data;
        //        //    console.log("Datos de Cliente!", v)
        //        //    vm.VucemCliente = data.data.VucemCliente;
        //        //    if (vm.VucemCliente == true)
        //        //        vm.TipoCliente = "agente aduanal";
        //        //    else
        //        //        vm.TipoCliente = "cliente";

        //        //    vm.ContactosEI = v.Contacto;

        //        //    vm.UsrsAduabook = v.Usuarios;

        //        //}, function (error) {
        //        //    console.log("Error", error);
        //        //})

        //        //funcion para hacer el efecto acordeon code.js
        //        acordionProcedimiento();

        //    })


        //}

        //function crearArrayProcedimientoPO() {
        //    vm.arrayProcedimiento = [];
        //    for (var index = 0; index < vm.numeroTabs; index++) {
        //        var procedimiento = {};
        //        procedimiento.Cuentas = vm.listaCuenta;
        //        procedimiento.Precliente = {};
        //        procedimiento.Precliente.NombreComercial = vm.dirrecionCliente.NombreComercial;
        //        procedimiento.Precliente.Direccion = vm.dirrecionCliente.Direccion;
        //        procedimiento.claseSucces = '';
        //        procedimiento.Id_Tabulador = vm.idtabs[index];
        //        procedimiento.Indice = vm.indices[index];



        //        var NvoTab = true;
        //        for (var i = 0; i < vm.itemstaboper.length; i++) {
        //            var _item = vm.itemstaboper[i];
        //            if (_item.Id_Tabulador == procedimiento.Id_Tabulador) {
        //                $.extend(procedimiento, _item);
        //                NvoTab = false;
        //                procedimiento.Vinculacion = procedimiento.Vinculacion == true ? 1 : 2;
        //                procedimiento.AplicacionTLCAN = procedimiento.AplicacionTLCAN == true ? 1 : 2;
        //                procedimiento.Incrementables = procedimiento.Incrementables == true ? 1 : 2;
        //                procedimiento.EnvioProformaAutorizacion = procedimiento.EnvioProformaAutorizacion == true ? 1 : 2;
        //            }
        //        }

        //        if (NvoTab) {
        //            procedimiento.Id_TipodePedimento = 0;
        //            procedimiento.Id_Regimen = 0;
        //            procedimiento.Id_ManejodePedimento = 0;
        //            procedimiento.Id_Incoterm = 0;
        //            procedimiento.Id_MetodoValoracion = 0;
        //            procedimiento.Id_FormaPago = 0;
        //            procedimiento.Vinculacion = 0;
        //            procedimiento.Id_AplicacionPreferencias = 0;
        //            procedimiento.AlicacionTLCAN = 0;
        //            procedimiento.Incrementables = 0;
        //            procedimiento.EnvioProformaAutorizacion = 0;
        //        }


        //        procedimiento.FormaPagosCat = creaarraycatalogo(['Seleccione']).concat(vm.FormaPagosCat);
        //        procedimiento.TipoPedimentoCat = creaarraycatalogo(['Seleeccione', 'Importacion', 'Exportacion']);
        //        procedimiento.RegimensCat = creaarraycatalogo(['Seleccione']).concat(vm.RegimensCat);
        //        procedimiento.ManejoPedimientoCat = creaarraycatalogo(['Seleccione', 'Normal', 'Consolidado', 'Remesa']);
        //        procedimiento.IncotermsCat = creaarraycatalogo(['Seleccione']).concat(vm.IncotermsCat);
        //        procedimiento.MetodoValoracionsCat = creaarraycatalogo(['Seleccione']).concat(vm.MetodoValoracionsCat);
        //        procedimiento.FormaPagosCat = creaarraycatalogo(['Seleccione']).concat(vm.FormaPagosCat);
        //        procedimiento.VinculacionCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
        //        procedimiento.AplicacionPreferenciaCat = creaarraycatalogo(['Seleccione']).concat(vm.AplicacionPreferenciaCat);
        //        procedimiento.AlicacionTLCANCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
        //        procedimiento.IncrementablesCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
        //        procedimiento.EnvioProformaAutorizacionCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);







        //        procedimiento.Id_abuladorProcedimientoOperacion = null;
        //        vm.arrayProcedimiento.push(procedimiento);
        //        console.log(procedimiento.Id_FormaPago)

        //    }

        //    console.log("arrayprocedimiento");
        //    console.log(vm.arrayProcedimiento);
        //}
    }
})();