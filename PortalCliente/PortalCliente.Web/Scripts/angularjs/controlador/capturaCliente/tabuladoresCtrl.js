(function () {
    'use strict';

    angular
        .module('app')
        .controller('tabuladoresCtrl', tabuladores);

    tabuladores.$inject = ['$scope', '$tabuladoresService', "$catalogoService", "$q"];

    function tabuladores($scope, $tabuladoresService, $catalogoService, $q) {
        var vm = $scope;
        vm.modelo = {};
        //vm.modelo.TipoCliente = 1;
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
        vm.catalogoEquipoOperativo = [];
        vm.modelo.EjecutivoVenta = window.aplicacionDatoUsuario.Nombre;

        vm.tabularDinamico = {};
        vm.contacto = {};
        vm.tarifa = {};

        //vm.empresaGrid = {};

        vm.guardarTabulador = function () {
            console.log("modelo", vm.modelo);

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
            }
            if (document.getElementById('factchecksi1').checked) {
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
            }
            if (document.getElementById('entregasi').checked) {
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
                /*
                if (!vm.tab.catalogoEstado) { // estado
                    $('#in15').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.catalogoCiudad) { // ciudad
                    $('#in16').css({ 'border-color': 'red' });
                    error++;
                }
                */
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

            //if (document.getElementById("cteped4").checked === false && document.getElementById("ctefact4").checked === false) {
            //    $('#l6').css({ 'color': 'red' });
            //    error++;
            //}
            //else {
            //    if (document.getElementById('in18').value == '') {
            //        $('#in18').css({ 'border-color': 'red' });
            //        error++;
            //    }
            //}
            //if (document.getElementById("cteped3").checked === false && document.getElementById("ctefact3").checked === false) {
            //    $('#l7').css({ 'color': 'red' });
            //    error++;
            //}
            //else {
            //    if (document.getElementById('in19').value == '') {
            //        $('#in19').css({ 'border-color': 'red' });
            //        error++;
            //    }
            //}
            //if (document.getElementById("cteped2").checked === false && document.getElementById("ctefact2").checked === false) {
            //    $('#l8').css({ 'color': 'red' });
            //    error++;
            //}
            //else {
            //    if (document.getElementById('in20').value == '') {
            //        $('#in20').css({ 'border-color': 'red' });
            //        error++;
            //    }
            //}
            //if (document.getElementById("cteped1").checked === false && document.getElementById("ctefact1").checked === false) {
            //    $('#l9').css({ 'color': 'red' });
            //    error++;
            //}
            //else {
            //    if (document.getElementById('in21').value == '') {
            //        $('#in21').css({ 'border-color': 'red' });
            //        error++;
            //    }
            //}



            //if (document.getElementById('in22').value == '') {
            //    $('#in22').css({ 'border-color': 'red' });
            //    error++;
            //}
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
                console.log("ImpuestoPeca");
                if (!vm.modelo.Banco) {
                    $('#in44').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.modelo.BancoId) {
                    $('#in45').css({ 'border-color': 'red' });
                    error++;
                }
            }

            if (error > 0) {
                console.log("error");
                modalError("Se deben llenar todos los campos.");
                return;
            }

            $tabuladoresService.GuardarTabuladores(vm.modelo).then(function (data) {
                if (data.data.resultado) {
                    modalOKTabuladores();
                } else {
                    modalError("Error al guardar los datos, reintentar.");
                }
            }, function (error) {
                console.log("Error en guardarTabulador", error);
                modalError("Error al guardar los datos, reintentar.");
            });
        }

        vm.obtenerCiudad = function (estado) {
            $catalogoService.obtenerCiudades({ IdEstado: estado }).then(function (data) {
                if (data.data.resultado) {
                    vm.catalogoCiudad = data.data.dato;
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }

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

                } else {
                }
            }, function (error) {
                console.log("Error en BuscarDatosTabuladores", error);
            });
        }

        vm.buscarDatosTabuladoresContactos = function () {
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
                        filasContactosTab++;
                    });
                } else {
                }
            }, function (error) {
                console.log("Error en buscarDatosTabuladoresContactos", error);
            });
        }

        vm.buscarDatosTabuladoresTarifas = function () {
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
                        filasTarifasTab++;
                    });
                } else {
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
            console.log("tabEmpresa.empresaGrid", tabEmpresa.empresaGrid);
            if (validarCampoEmpresa(tabEmpresa.empresaGrid)) {
                filasEmpresaTab++;
                tabEmpresa.empresaGrid.UsuarioCreacion = 'Test';
                tabEmpresa.empresaGrid.catalogoConceptoFacturacion = angular.copy(vm.catalogoConceptoFacturacion);
                console.log("tabEmpresa", angular.copy(tabEmpresa));
                //
                angular.forEach(tabEmpresa.empresaGrid.catalogoConceptoFacturacion, function (elemento, index) {
                    if (elemento.id === tabEmpresa.empresaGrid.ConceptoFacturacion.id) {
                        console.log("elemento", elemento);
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
                    //console.log("conceptoFacturacion", tab.catalogoConceptoFacturacion);
                    //cargaciudad();
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
                    //if (empresa.TarifaVenta !== 0 || empresa.TarifaCompra !== 0)
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
            $('#popupFin').fadeIn('fast');
            $('#popupFin .icon i').addClass('fas fa-exclamation-circle');
            window.document.getElementById('mensajeFin').innerHTML = mensaje;
        };

        vm.tab = {};
        vm.tabContacto = {};
        vm.tabModeloContacto = [];
        vm.tabTarifa = {};
        vm.tabModeloTarifa = [];
        vm.tabEmpresa = {};
        vm.tabModeloEmpresa = [];
        vm.modeloNombre = []; ///////////////////////////////////////////////////////
        vm.valoresNombre = {}; ////////////////////////////////////////////////////
        vm.modeloTabs = []; ///////////////////////////////////////////////////////
        vm.modeloTabsEmpresa = []; ///////////////////////////////////////////////////////
        vm.valoresTab = {}; ////////////////////////////////////////////////////
        vm.valoresTabEmpresa = {}; ////////////////////////////////////////////////////
        vm.valoresTabAuxiliar = {}; ////////////////////////////////////////////////////
        vm.valoresTabEmpresaAuxiliar = {}; ////////////////////////////////////////////////////
        vm.modeloTabsEmpresaAuxiliar = []; ///////////////////////////////////////////////////////

        var idUsuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = 0;
        var filasContactosTab = 0;
        var filasTarifasTab = 0;
        var filasEmpresaTab = 0;
        var numero_tabs = 1;

        //evento 
        $scope.$on("seleccion_busqueda", function (evet, data) {
            idPrecliente = data.IdPrecliente;
            vm.modelo.IdPrecliente = data.IdPrecliente;
            vm.buscarDatosTabuladores(data.IdPrecliente);
            vm.buscarDatosTabuladoresContactos();
            vm.buscarDatosTabuladoresTarifas();
            vm.buscarDatosTabuladoresTabs();
        });

        //vm.obtenerEstado();

        vm.guardarDatosTabuladores = function () {
            var error = 0;

            resetearCamposTabuladores(numero_tabs);

            if (idPrecliente == 0) {
                modalError("Favor de consultar un precliente previamente.");
                return;
            }

            // Iniciales
            /*
            if (!vm.tab.ejecutivoventas) {
                $('#in1').css({ 'border-color': 'red' });
                error++;
            }
            */
            if (!vm.tab.equipooperacion) {
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
            if (!vm.tab.rfc) {
                $('#in3').css({ 'border-color': 'red' });
                error++;
            }
            if (vm.tab.tipocliente < 3) {
                if (!vm.tab.nombreclientealta) {
                    $('#in4').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.cliente) {
                    $('#in5').css({ 'border-color': 'red' });
                    error++;
                }
            }

            // Instrucciones de Facturación
            if (!(document.getElementById('factchecksi1').checked) && !(document.getElementById('factcheckno1').checked)) {
                $('#l4').css({ 'color': 'red' });
                error++;
            }
            if (vm.tab.consitio === true) {
                if (!vm.tab.paginaweb) {
                    $('#in6Tab').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.usuario) {
                    $('#in7Tab').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.password) {
                    $('#in8Tab').css({ 'border-color': 'red' });
                    error++;
                }
            }
            if (!(document.getElementById('entregasi').checked) && !(document.getElementById('entregano').checked)) {
                $('#l5').css({ 'color': 'red' });
                error++;
            }
            if (vm.tab.conentregafisica === true) {
                if (!vm.tab.diasrevision) {
                    $('#in9').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.horariorevision) {
                    $('#in10').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.personasrecibenfacturas) {
                    $('#in11').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.numerojuegocopias) {
                    $('#in12').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.callenumero) {
                    $('#in13').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.colonia) {
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
                /*
                if (!vm.tab.catalogoEstado) { // estado
                    $('#in15').css({ 'border-color': 'red' });
                    error++;
                }
                if (!vm.tab.catalogoCiudad) { // ciudad
                    $('#in16').css({ 'border-color': 'red' });
                    error++;
                }
                */
                if (!vm.tab.codigopostal) {
                    $('#in17').css({ 'border-color': 'red' });
                    error++;
                }
            }

            // Tabuladores General
            if (document.getElementById("cteped4").checked === false && document.getElementById("ctefact4").checked === false) {
                $('#l6').css({ 'color': 'red' });
                error++;
            }
            else {
                if (document.getElementById('in18').value == '') {
                    $('#in18').css({ 'border-color': 'red' });
                    error++;
                }
            }
            if (document.getElementById("cteped3").checked === false && document.getElementById("ctefact3").checked === false) {
                $('#l7').css({ 'color': 'red' });
                error++;
            }
            else {
                if (document.getElementById('in19').value == '') {
                    $('#in19').css({ 'border-color': 'red' });
                    error++;
                }
            }
            if (document.getElementById("cteped2").checked === false && document.getElementById("ctefact2").checked === false) {
                $('#l8').css({ 'color': 'red' });
                error++;
            }
            else {
                if (document.getElementById('in20').value == '') {
                    $('#in20').css({ 'border-color': 'red' });
                    error++;
                }
            }
            if (document.getElementById("cteped1").checked === false && document.getElementById("ctefact1").checked === false) {
                $('#l9').css({ 'color': 'red' });
                error++;
            }
            else {
                if (document.getElementById('in21').value == '') {
                    $('#in21').css({ 'border-color': 'red' });
                    error++;
                }
            }
            if (document.getElementById('in22').value == '') {
                $('#in22').css({ 'border-color': 'red' });
                error++;
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
            if (!vm.tab.diaspago) {
                $('#in28').css({ 'border-color': 'red' });
                error++;
            }
            if (!vm.tab.horariopago) {
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
                if (!vm.tab.MontoFondo) {
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
                if (!vm.tab.puntoreorden) {
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
                if (!vm.tab.condiciones) {
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
            if (!vm.tab.ventasmensual) {
                $('#in39').css({ 'border-color': 'red' });
                error++;
            }

            // Pie de N tabuladores
            if (!vm.tab.datosadicionales) {
                $('#in40').css({ 'border-color': 'red' });
                error++;
            }
            if (document.getElementById('in41').value == '') {
                $('#in41').css({ 'border-color': 'red' });
                error++;
            }
            if (!vm.tab.digitoscuenta) {
                $('#in42').css({ 'border-color': 'red' });
                error++;
            }
            if (!vm.tab.instruccionesespeciales) {
                $('#in43').css({ 'border-color': 'red' });
                error++;
            }

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

            if (error > 0) {
                modalError("Se deben llenar todos los campos.");
                return;
            }

            // GUARDAR INFORMACION GENERAL DE TABULADORES
            vm.tab.Contactos = vm.tabModeloContacto;
            vm.tab.Tarifas = vm.tabModeloTarifa;
            vm.tab.idPrecliente = idPrecliente;
            vm.tab.idUsuario = idUsuario;
            vm.tab.id_ciudad = vm.tab.id_ciudad.id_ciudad;
            vm.tab.id_estado = vm.catalogoEstado.id_estado.id_estado;

            //vm.tab.Empresa = vm.tabModeloEmpresa;
            //vm.tab.Tabuladores = vm.tabModeloEmpresa;

            // GUARDAR INFORMACION DE TABS

            $tabuladoresService.GuardarTabuladores(vm.tab).then(function (data) {
                debugger;
                var resultado = data.data.resultado;
                if (data.data.resultado) {
                    $('.popupoverlay').fadeIn('fast');
                    $('#popupDatosTabuladores').fadeIn('fast');
                    $('#popupDatosTabuladores .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensajeDatosTabuladores').innerHTML = "Se guardó correctamente la información.";
                }
                else {
                    modalError(data.data.mensaje);
                }
            }, function (error) {
                console.log("error", error);
            })

        };

        vm.verTabs = function () {
            vm.TabsAgregados = vm.modeloTabs;
        };

        vm.agregarNombre = function (modelo) {
            debugger;
            vm.modeloNombre.push(modelo);
            vm.valoresNombre = {};
        };

        ////////////////////////////////////////////////////////////////////////////////////////////////

        vm.agregarTab = function (modelo) {
            var tempConcepto = {};
            modelo.catalogoConceptoFacturacion = angular.copy(vm.catalogoConceptoFacturacion);
            angular.forEach(modelo.catalogoConceptoFacturacion, function (data, index) {
                if (modelo.Empresa.id_concepto_facturacion === data.id_concepto_facturacion) {
                    tempConcepto = data;
                    console.log("encontrado", tempConcepto);
                    return;
                }
            })
            modelo.id_concepto_facturacion = tempConcepto;


            vm.modeloTabs.push(modelo);
            vm.modeloTabsEmpresa = vm.modeloTabsEmpresaAuxiliar;
            vm.valoresTab = {};
            vm.modeloTabsEmpresaAuxiliar = [];
            numero_tabs++;
        };

        // NORMAL
        vm.agregarValoresEmpresa = function (empresa) {
            var tempConcepto = {};
            if (validarEmpresa(empresa)) {
                empresa.catalogoConceptoFacturacion = angular.copy(vm.catalogoConceptoFacturacion);
                angular.forEach(empresa.catalogoConceptoFacturacion, function (data, index) {
                    if (empresa.id_concepto_facturacion.id_concepto_facturacion === data.id_concepto_facturacion) {
                        tempConcepto = data;
                        console.log("encontrado", tempConcepto);
                        return;
                    }
                })
                empresa.id_concepto_facturacion = tempConcepto;
                vm.modeloTabsEmpresa.push(empresa);
                vm.valoresTabEmpresa = {};
                filasEmpresaTab++;
                $('#req-table1').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        }

        // AUXILIAR
        vm.agregarValoresEmpresaAuxiliar = function (empresa) {
            var tempConcepto = {};
            if (validarEmpresaAuxiliar(empresa)) {
                empresa.catalogoConceptoFacturacion = angular.copy(vm.catalogoConceptoFacturacion);
                angular.forEach(empresa.catalogoConceptoFacturacion, function (data, index) {
                    if (empresa.id_concepto_facturacion.id_concepto_facturacion === data.id_concepto_facturacion) {
                        tempConcepto = data;
                        console.log("encontrado", tempConcepto);
                        return;
                    }
                })
                empresa.id_concepto_facturacion = tempConcepto;
                vm.modeloTabsEmpresaAuxiliar.push(empresa);
                vm.valoresTabEmpresaAuxiliar = {};
                //filasEmpresaTab++;
                $('#req-table1').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        }

        function validarEmpresa(empresa) {
            if (empresa) {
                if (!empresa.empresa || !empresa.id_concepto_facturacion || !empresa.id_concepto_autofacturacion
                    || !empresa.tarifaVenta || !empresa.tarifaVentaTipoMoneda || !empresa.tarifaCompra
                    || !empresa.tarifaCompraTipoMoneda) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        function validarEmpresaAuxiliar(empresa) {
            if (empresa) {
                if (!empresa.empresa || !empresa.id_concepto_facturacion || !empresa.id_concepto_autofacturacion
                    || !empresa.tarifaVenta || !empresa.tarifaVentaTipoMoneda || !empresa.tarifaCompra
                    || !empresa.tarifaCompraTipoMoneda) {
                    return false;
                }
                else {
                    return true;
                }
            } else {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        vm.obtenerEstado = function () {
            $tabuladoresService.obtenerEstados({ idPais: 'N3' }).then(function (data) {
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




        //vm.agregarContactoTab = function (contacto) {
        //    if (validarCampoContactoTab(contacto)) {
        //        //contacto.UsuarioCreacion = 'Test';
        //        vm.tabModeloContacto.push(contacto);
        //        vm.tabContacto = {};
        //        filasContactosTab++;
        //        $('#req-table1').fadeOut('fast');
        //    } else {
        //        modalError("Se deben llenar todos los campos de la fila.");
        //    }
        //}

        //vm.eliminarFilaContactoTab = function (index) {
        //    vm.tabModeloContacto.splice(index, 1);
        //    filasContactosTab--;
        //}

        //vm.editarFilaContactoTab = function (index) {
        //    console.log(index);
        //    editFilasTab(index)
        //}

        //vm.actualizarFilaContactoTab = function (index) {
        //    saveFilasTab(index)
        //}

        vm.agregarTarifa = function (tarifa) {
            if (validarCampoTarifa(tarifa)) {
                //contacto.UsuarioCreacion = 'Test';
                vm.tabModeloTarifa.push(tarifa);
                vm.tabTarifa = {};
                filasTarifasTab++;
                $('#req-table1').fadeOut('fast');
            } else {
                modalError("Se deben llenar todos los campos de la fila.");
            }
        }

        vm.eliminarFilaTarifa = function (index) {
            vm.tabModeloTarifa.splice(index, 1);
            filasTarifasTab--;
        }

        vm.editarFilaTarifa = function (index) {
            console.log(index);
            editFilasTarifa(index)
        }

        vm.actualizarFilaTarifa = function (index) {
            saveFilasTarifa(index)
        }


        //vm.agregarEmpresa = function (empresa) {
        //    console.log("agregarEmpresa", empresa);
        //    var tempConcepto = {};
        //    if (validarCampoEmpresa(empresa)) {
        //        //contacto.UsuarioCreacion = 'Test';

        //        empresa.catalogoConceptoFacturacion = angular.copy(vm.catalogoConceptoFacturacion);

        //        angular.forEach(empresa.catalogoConceptoFacturacion, function (data, index) {
        //            if (empresa.id_concepto_facturacion.id_concepto_facturacion === data.id_concepto_facturacion) {
        //                tempConcepto = data;
        //                console.log("encontrado", tempConcepto);
        //                return;
        //            }
        //        })


        //        empresa.id_concepto_facturacion = tempConcepto;

        //        /*$tabuladoresService.ObtenerConceptoFacturacion({ empresa: empresa.empresa }).then(function (data) {
        //            if (data.data.resultado) {
        //                empresa.catalogoConceptoFacturacion = data.data.data;

        //                angular.forEach(empresa.catalogoConceptoFacturacion, function (data, index) {
        //                    if (empresa.id_concepto_facturacion.id_concepto_facturacion === data.id_concepto_facturacion) {
        //                        tempConcepto = data;
        //                        console.log("encontrado", tempConcepto);
        //                        return;
        //                    }
        //                })


        //                empresa.id_concepto_facturacion = tempConcepto;
        //                console.log("obtenerConceptoFacturacionEdicion", vm.catalogoConceptoFacturacion);
        //                //cargaciudad();
        //            } else {
        //                console.log("Error", data.data.mensaje);
        //            }

        //        }, function (error) {
        //            console.log("Error", error);
        //        })*/





        //        //vm.tabModeloEmpresa.push(empresa);
        //        vm.modeloTabsEmpresa.push(empresa);
        //        vm.tabEmpresa = {};
        //        filasEmpresaTab++;
        //        $('#req-table1').fadeOut('fast');
        //    } else {
        //        modalError("Se deben llenar todos los campos de la fila.");
        //    }
        //}

        //vm.eliminarFilaEmpresa = function (index) {
        //    vm.tabModeloEmpresa.splice(index, 1);
        //    filasEmpresaTab--;
        //}

        //vm.editarFilaEmpresa = function (index, num_tab) {
        //    console.log(index);
        //    editFilasEmpresa(index, num_tab)
        //}

        //vm.actualizarFilaEmpresa = function (index, num_tab) {
        //    saveFilasEmpresa(index, num_tab)
        //}


        vm.agregarNuevoTab = function (nuevaTab) {
            vm.nuevoTabs.push(nuevaTab);
            numero_tabs++;
        }

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



    function modalError(mensaje) {
        debugger;
        $('.popupoverlay').fadeIn('fast');
        $('#popupFin').fadeIn('fast');
        $('#popupFin .icon .far').addClass('fa-check-circle');
        window.document.getElementById('mensajeFin').innerHTML = mensaje;
    };

    function modalOK(mensaje) {
        debugger;
        $('.popupoverlay').fadeIn('fast');
        $('#popupFin').fadeIn('fast');
        $('#popupFin .icon i').addClass('fa-check-circle');
        window.document.getElementById('mensajeFin').innerHTML = mensaje;
    };

    function modalOKTabuladores(mensaje) {
        $('.popupoverlay').fadeIn('fast');
        $('#popupDatosTabuladores').fadeIn('fast');
        $('#popupDatosTabuladores .icon i').addClass('far fa-check-circle');
        document.getElementById('mensajeDatosTabuladores').innerHTML = "Se guardó correctamente la información.";
    };

    function editFilasTab(num) {
        var paquete = document.getElementById("numbersTab");
        var object = document.getElementById("filaTab" + num);
        var btnedit = document.getElementById("editTab" + num);
        var btnsave = document.getElementById("saveTab" + num);
        $('#filaTab' + num + ' .form-control').prop('disabled', false);
        $(btnedit).fadeOut('fast');
        $(btnsave).fadeIn('fast');
    }

    function saveFilasTab(num) {
        var object = document.getElementById("filaTab" + num);
        var btnedit = document.getElementById("editTab" + num);
        var btnsave = document.getElementById("saveTab" + num);
        $('#filaTab' + num + ' .form-control').prop('disabled', true);
        $(btnsave).fadeOut('fast');
        $(btnedit).fadeIn('fast');
    }

    function validarCampoTarifa(tarifa) {
        if (tarifa) {
            if (!tarifa.servicio || !tarifa.tarifa || !tarifa.notas) {
                return false;
            }
            else {
                return true;
            }
        } else {
            return false;
        }
    }

    function editFilasTarifa(num) {
        var paquete = document.getElementById("numbersTarifas");
        var object = document.getElementById("filaTarifa" + num);
        var btnedit = document.getElementById("editTarifa" + num);
        var btnsave = document.getElementById("saveTarifa" + num);
        $('#filaTarifa' + num + ' .form-control').prop('disabled', false);
        $(btnedit).fadeOut('fast');
        $(btnsave).fadeIn('fast');
    }

    function saveFilasTarifa(num) {
        var object = document.getElementById("filaTarifa" + num);
        var btnedit = document.getElementById("editTarifa" + num);
        var btnsave = document.getElementById("saveTarifa" + num);
        $('#filaTarifa' + num + ' .form-control').prop('disabled', true);
        $(btnsave).fadeOut('fast');
        $(btnedit).fadeIn('fast');
    }

    function validarCampoEmpresa(empresa) {
        if (empresa) {
            if (!empresa.empresa || !empresa.id_concepto_facturacion || !empresa.id_concepto_autofacturacion
                || !empresa.tarifaVenta || !empresa.tarifaVentaTipoMoneda || !empresa.tarifaCompra
                || !empresa.tarifa_compra_tipo_moneda) {
                return false;
            }
            else {
                return true;
            }
        } else {
            return false;
        }
    }

    function editFilasEmpresa(num, num_tab) {
        var paquete = document.getElementById("numbersEmpresa" + num_tab);
        var object = document.getElementById("filaTab" + num_tab + num);
        var btnedit = document.getElementById("editTab" + num_tab + num);
        var btnsave = document.getElementById("saveTab" + num_tab + num);
        $('#filaTab' + num_tab + num + ' .form-control').prop('disabled', false);
        $(btnedit).fadeOut('fast');
        $(btnsave).fadeIn('fast');
    }

    function saveFilasEmpresa(num, num_tab) {
        var object = document.getElementById("filaTab" + num_tab + num);
        var btnedit = document.getElementById("editTab" + num_tab + num);
        var btnsave = document.getElementById("saveTab" + num_tab + num);
        $('#filaTab' + num_tab + num + ' .form-control').prop('disabled', true);
        $(btnsave).fadeOut('fast');
        $(btnedit).fadeIn('fast');
    }





})();