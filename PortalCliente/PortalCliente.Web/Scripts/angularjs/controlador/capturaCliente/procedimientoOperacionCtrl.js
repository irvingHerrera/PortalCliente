(function () {
    'use strict';

    angular
        .module('app')
        .controller('procedimientoOperacionCtrl', procedimientoOperacion);

	procedimientoOperacion.$inject = ['$scope', '$TabuladorProcedimientoOperacionService', '$registroClienteService', '$capturaClienteService','$aprovacionService', '$q'];

	function procedimientoOperacion($scope, $TabuladorProcedimientoOperacionService, $registroClienteService, $capturaClienteService, $aprovacionService, $q) {
        var vm = $scope;

        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        vm.camposFinanciamiento = false;

        vm.listaCuenta = [];
        vm.dirrecionCliente = {};
        vm.arrayProcedimiento = [];
        vm.contactoCliente = [];
        vm.numeroTabs;

        vm.Monto;
        vm.Parausoen;
        vm.PuntoReorden;
        vm.Recuperacion;
        vm.Plazo;
        vm.Condiciones;


        vm.ContactosEI = {};
        vm.Secciones = [];
        vm.UsrsAduabook = [];
        vm.VucemCliente;
        vm.TipoCliente;

        vm.idtabs = [];

        $scope.$on("seleccion_busqueda", function (evet, data) {
			vm.arrayProcedimiento = [];
            resolverPromesas(data);
        });

        var id_precliente;

        function obtenerPromesas(datoBusqueda) {

            vm.camposFinanciamiento = false;
            id_precliente = datoBusqueda.IdPrecliente;

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
                    //vm.Secciones = promesas.promesaDatosTituloSecciones.data.data;
                    /*
                    var temp = promesas.promesaTabuladorTabs.data.resultado;
                    vm.idtabs = [];
                    vm.indices = [];

                    for (var i = 0; i < temp.length; i++) {

                        vm.idtabs.push(temp[i].split("|")[0]);
                        vm.indices.push(temp[i].split("|")[1])

                    }
                    */
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
                vm.agregarContactoEI = function (ContactosEI,indice) {
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

                vm.actualizarFilaContactoEI = function (index,indice) {
                    //console.log("actualizarFilaContactoEI" + index);
                    saveFilasPO(index, indice);
                    window.saveFilas(index)
                };

                vm.editarFilaContactoEI = function (index,indice) {
                    //console.log("editarFilaContactoEI" + index);
                    EditFilasPO(index, indice);
                    window.editFilas(index)
                };

                vm.eliminarFilaContactoEI = function (index, indice) {
                    //console.log("eliminarFilaContacto" + index);
                    vm.arrayProcedimiento[indice - 1].ContactosEI.splice(index, 1);
                }
                //***Grid contacto EI**//



                //$registroClienteService.ObtieneDatosCliente(datoBusqueda.IdUsuario).then(function (data) {
                //    var v = data.data;

                //    vm.VucemCliente = data.data.VucemCliente;
                //    if (vm.VucemCliente == true)
                //        vm.TipoCliente = "agente aduanal";
                //    else
                //        vm.TipoCliente = "cliente";

                //    vm.ContactosEI = v.Contacto;
                //    console.log("contactos ei", vm.ContactosEI);

                //    vm.UsrsAduabook = v.Usuarios;
                //    //console.log("usrs aduabook", vm.UsrsAduabook);

                //}, function (error) {
                //    console.log("Error", error);
                //})

                //funcion para hacer el efecto acordeon code.js
                acordionProcedimiento();

            })
        }

        vm.init = function () {

        }

        vm.guardarProcedimiento = function (procedimiento) {
            procedimiento.claseSucces = "bg-green";
            procedimiento.guardado = true;
        }

        vm.TerminarProcedimiento = function () {
            $TabuladorProcedimientoOperacionService.puedeActualizarProcedimiento(id_precliente)
                .then(function (data) {
                    if (data.data.respuesta)
                    {
                        /*
                        //Actualiza a -->Para aprobacion procedimiento Prealta
                        $aprovacionService.NoAprobado({ idUsuario: usuario, idPrecliente: idPrecliente, estatus: 10, observacion: "" })
                            .then(function (data) {
                                $('.popupoverlay').fadeIn('fast');
                                $('#popupOk').fadeIn('fast');
                                $('#popupOk .icon i').addClass('far fa-check-circle');
                                document.getElementById('mensajeok').innerHTML = "Se concluyó el proceso Procedimiento de Operación exitosamente";
                            }, function (error) {
                                console.log("Error", data.data.mensaje + ' ' + error);
                            });
                        */

                        // Actualizamos estatus de pre/cliente
                        $TabuladorProcedimientoOperacionService.GuardarTerminarProcedimientoOperacion({ id_precliente: id_precliente }).then(function (data) {
                            if (data.data.resultado) {
                                $('.popupoverlay').fadeIn('fast');
                                $('#popupFinOperaciones').fadeIn('fast');
                                $('#popupFinOperaciones .icon i').addClass('far fa-check-circle');
                                document.getElementById('mensajeFinOperaciones').innerHTML = "Se concluyó el proceso Procedimiento de Operación exitosamente";
                                // refresh -----------
                                // window.location.reload(true);
                            }
                        }, function (error) {
                            console.log("Error en TerminarProcedimientoOperacion");
                        });

                    } else
                    {
                        $('.popupoverlay').fadeIn('fast');
                        $('#popupNo').fadeIn('fast');
                        document.getElementById('mensajeNo').innerHTML = "Es necesario capturar un procedimiento por cada tabulador para poder actualizar el cliente";
                    }
                });
			
			$capturaClienteService.obtenerDocumentosCliente({ id_precliente: idPrecliente, id_usuario: usuario }).then(function (data) {
				if (data.data.resultado) {
					//alert("Se concluyó el proceso Procedimiento de Operación exitosamente");
				} else {
					console.log("Error", data.data.mensaje);
				}

			}, function (error) {
				console.log("Error", error);
			})


		}

			

           
        


        vm.GuardaTabuladorRegistroOperacion = function (Procedimiento) {

            $(".reqpo" + Procedimiento.Indice).css({ 'border-color': '' });
            $(".ddlreqpo" + Procedimiento.Indice).css({ 'border': '0px solid black' });

            var correcto = true;
            $(".reqpo" + Procedimiento.Indice).each(function () {
                if (this.attributes[1].nodeValue === "Procedimiento.Parausoen" ||
                    this.attributes[1].nodeValue === "Procedimiento.PuntoReorden" ||
                    this.attributes[1].nodeValue === "Procedimiento.Recuperacion" ||
                    this.attributes[1].nodeValue === "Procedimiento.Plazo" ||
                    this.attributes[1].nodeValue === "Procedimiento.Condiciones") {
                }
                else {
                    if ($(this).val().trim().length == 0) {
                        $(this).css({ 'border-color': 'red' });
                        correcto = false;
                    }
                }
            });

            $(".ddlreqpo" + Procedimiento.Indice).each(function () {
                if ($(this).val() == 0) {
                    $(this).css({ 'border': '1px solid red' });
                    correcto = false;
                }
            });

            if (correcto) {

                Procedimiento.Vinculacion = Procedimiento.Vinculacion == 1 ? true : false;
                Procedimiento.AplicacionTLCAN = Procedimiento.AplicacionTLCAN == 1 ? true : false;
                Procedimiento.Incrementables = Procedimiento.Incrementables == 1 ? true : false;
                Procedimiento.EnvioProformaAutorizacion = Procedimiento.EnvioProformaAutorizacion == 1 ? true : false;
                Procedimiento.GrupoGeneralEEI = Procedimiento.GrupoGeneralEEI == 1 ? true : false;

                $TabuladorProcedimientoOperacionService.GuardaTabuladorProcedimiento(Procedimiento).then(function (data) {
                   // console.log("correcto tabulador procedimiento operacion");

                    $('.popupoverlay').fadeIn('fast');
                    $('#popupOk').fadeIn('fast');
                    $('#popupOk .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensajeok').innerHTML = "Se guardó correctamente la información.";
                    Procedimiento.claseSucces = "bg-green";
                    colapsarTab();
                }, function (error) {
                    console.log("Error", error);
                })
            } else {
                $('.popupoverlay').fadeIn('fast');
                $('#popupNo').fadeIn('fast');
                document.getElementById('mensajeNo').innerHTML = "Es necesario capturar todos los datos obligatorios";
            }

        }

        function colapsarTab() {
            var comprobar = $('.menujq > ul > li > a').next();
            $('.menujq li').removeClass('activa');
            $('.menujq > ul > li > a').closest('li').addClass('activa');
            if ((comprobar.is('ul')) && (comprobar.is(':visible'))) {
                $('.menujq > ul > li > a').closest('li').removeClass('activa');
                comprobar.slideUp('normal');
            }
            if ((comprobar.is('ul')) && (!comprobar.is(':visible'))) {
                $('.menujq ul ul:visible').slideUp('normal');
                comprobar.slideDown('normal');
            }
        }

        //funciones js--
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
                procedimiento.Precliente.ContactoCliente = vm.contactoCliente;
                /*
                for (var ii = 0; ii < vm.Secciones.length; ii++) {
                    procedimiento.Secciones.push(vm.Secciones[ii])
                }
                */

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
                console.log(procedimiento.Id_FormaPago)

            }

            console.log("arrayprocedimiento");
            console.log(vm.arrayProcedimiento);
        }
    }

})();


$(function () {
    $(document).on("click", "#btnmensajeNo", function () {
        document.getElementById('popupNo').style.display = 'none'
        $('.popupoverlay').fadeOut('fast');
        return false;
    });
    $(document).on("click", "#btnmensajeok", function () {
        document.getElementById('popupOk').style.display = 'none'
        $('.popupoverlay').fadeOut('fast');
        return false;
    });
});

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

