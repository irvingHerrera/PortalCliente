(function () {
    'use strict';

    angular
        .module('app')
        .controller('datoOperacionPrOpCtrl', datoOperacionPrOp);

    datoOperacionPrOp.$inject = ['$scope', '$TabuladorProcedimientoOperacionService', '$registroClienteService', '$capturaClienteService', '$q', '$consultaService'];

    function datoOperacionPrOp($scope, $TabuladorProcedimientoOperacionService, $registroClienteService, $capturaClienteService, $q, $consultaService) {
        var vmPO = $scope;

        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        vmPO.listaCuenta = [];
        vmPO.dirrecionCliente = {};
        vmPO.arrayProcedimiento = [];
        vmPO.numeroTabs;



        vmPO.ContactosEI = [];
        vmPO.UsrsAduabook = [];
        vmPO.VucemCliente;
        vmPO.TipoCliente;

        vmPO.idtabs = [];

        $scope.$on("seleccion_busqueda", function (evet, data) {
            console.log("seleccion busqueda de PO");
            resolverPromesas(data);
            //debugger;
            for (var i = 0; i < vmPO.arrayProcedimiento.length; i++) {

                var procedimiento = vmPO.arrayProcedimiento[i];

            }

        });

        function obtenerPromesas(datoBusqueda) {

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
                prinesaaplicacionespreferencia
            })
        }


        function resolverPromesas(datoBusqueda) {
            //
            obtenerPromesas(datoBusqueda).then(function (promesas) {
                console.log("resolver promesas en PO", promesas);
                if (promesas.promesaCuenta.data.resultado) {
                    vmPO.listaCuenta = promesas.promesaCuenta.data.data;
                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaDireccion.data.resultado) {
                    vmPO.dirrecionCliente = promesas.promesaDireccion.data.data;
                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaNumeroTab.data.resultado) {
                    vmPO.numeroTabs = promesas.promesaNumeroTab.data.data;

                } else {
                    console.log("Error", promesas.promesaCuenta.data.mensaje);
                }

                if (promesas.promesaTabuladorTabs.data.resultado) {

                    console.log("promesas.promesaTabuladorTabs.data.resultado");
                    console.log(promesas.promesaTabuladorTabs.data.resultado);
                    var temp = promesas.promesaTabuladorTabs.data.resultado;
                    vmPO.idtabs = [];
                    vmPO.indices = [];

                    for (var i = 0; i < temp.length; i++) {

                        vmPO.idtabs.push(temp[i].split("|")[0]);
                        vmPO.indices.push(temp[i].split("|")[1])

                    }


                } else {
                    console.log("Error", promesas.promesaTabuladorTabs.data.mensaje);
                }

                if (promesas.promesaformapago.data.respuesta) {
                    vmPO.FormaPagosCat = promesas.promesaformapago.data.items;
                    //console.log("vmPO.FormaPagosCat", vmPO.FormaPagosCat);
                }

                if (promesas.promesaicoterms.data.respuesta) {
                    vmPO.IncotermsCat = promesas.promesaicoterms.data.items;
                }

                if (promesas.promesaValoracions.data.respuesta) {
                    vmPO.MetodoValoracionsCat = promesas.promesaValoracions.data.items;
                }

                if (promesas.promesaRegimens.data.respuesta) {
                    vmPO.RegimensCat = promesas.promesaRegimens.data.items;
                }

                if (promesas.prinesaaplicacionespreferencia.data.respuesta) {
                    vmPO.AplicacionPreferenciaCat = promesas.prinesaaplicacionespreferencia.data.items;

                }


                if (promesas.promesatabitems.data.respuesta) {
                    console.log(promesas.promesatabitems.data);
                    vmPO.itemstaboper = promesas.promesatabitems.data.items;
                    console.log("promesas.promesatabitems", promesas.promesatabitems);
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
                    promesas.prinesaaplicacionespreferencia.data.respuesta) {
                    crearArrayProcedimiento();

                }



                //console.log("usuario en PO", usuario);

                $registroClienteService.ObtieneDatosClientePost({ idusuario: datoBusqueda.IdUsuario }).then(function (data) {
                    var v = data.data;
                    console.log("Datos de Cliente!", v)
                    vmPO.VucemCliente = data.data.VucemCliente;
                    if (vmPO.VucemCliente == true)
                        vmPO.TipoCliente = "agente aduanal";
                    else
                        vmPO.TipoCliente = "cliente";

                    vmPO.ContactosEI = v.Contacto;

                    vmPO.UsrsAduabook = v.Usuarios;

                }, function (error) {
                    console.log("Error", error);
                })

                //funcion para hacer el efecto acordeon code.js
                acordionProcedimiento();

            })
        }

        vmPO.init = function () {
            console.log("init de PO");
        }

        vmPO.guardarProcedimiento = function (procedimiento) {
            procedimiento.claseSucces = "bg-green";
            procedimiento.guardado = true;
        }

        vmPO.TerminarProcedimiento = function () {
            $capturaClienteService.obtenerDocumentosCliente({ id_precliente: idPrecliente, id_usuario: usuario }).then(function (data) {
                if (data.data.resultado) {
                    alert("Se concluyó el proceso Procedimiento de Operación exitosamente");
                } else {
                    console.log("Error", data.data.mensaje);
                }

            }, function (error) {
                console.log("Error", error);
            })
        }


        vmPO.GuardaTabuladorRegistroOperacion = function (Procedimiento) {

            $(".reqpo" + Procedimiento.Indice).css({ 'border-color': '' });
            $(".ddlreqpo" + Procedimiento.Indice).css({ 'border': '0px solid black' });



            var correcto = true;
            $(".reqpo" + Procedimiento.Indice).each(function () {
                if ($(this).val().trim().length == 0) {
                    $(this).css({ 'border-color': 'red' });

                    correcto = false;
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

                $TabuladorProcedimientoOperacionService.GuardaTabuladorProcedimiento(Procedimiento).then(function (data) {
                    console.log("correcto tabulador procedimiento operacion");

                    $('.popupoverlay').fadeIn('fast');
                    $('#popupOk').fadeIn('fast');
                    $('#popupOk .icon i').addClass('far fa-check-circle');
                    document.getElementById('mensajeok').innerHTML = "Se guardó correctamente la información.";

                }, function (error) {
                    console.log("Error", error);
                })
            } else {
                $('.popupoverlay').fadeIn('fast');
                $('#popupNo').fadeIn('fast');
                document.getElementById('mensajeNo').innerHTML = "Es necesario capturar todos los datos obligatorios";
            }

        }

        //    vmPO.GetApliacacionPreferencia = function () {
        //        $TabuladorProcedimientoOperacionService.GetApliacacionPreferencia().then(function (data) {              
        //vmPO.AplicacionPreferenciaCat = data.data.items;

        //        }, function (error) {
        //            console.log(error);
        //        });
        //    }








        //funciones js--
        function crearArrayProcedimiento() {
            for (var index = 0; index < vmPO.numeroTabs; index++) {
                var procedimiento = {};
                procedimiento.Cuentas = vmPO.listaCuenta;
                procedimiento.Precliente = {};
                procedimiento.Precliente.NombreComercial = vmPO.dirrecionCliente.NombreComercial;
                procedimiento.Precliente.Direccion = vmPO.dirrecionCliente.Direccion;
                procedimiento.claseSucces = '';
                procedimiento.Id_Tabulador = vmPO.idtabs[index];
                procedimiento.Indice = vmPO.indices[index];



                var NvoTab = true;
                for (var i = 0; i < vmPO.itemstaboper.length; i++) {
                    var _item = vmPO.itemstaboper[i];
                    if (_item.Id_Tabulador == procedimiento.Id_Tabulador) {
                        $.extend(procedimiento, _item);
                        NvoTab = false;
                        procedimiento.Vinculacion = procedimiento.Vinculacion == true ? 1 : 2;
                        procedimiento.AplicacionTLCAN = procedimiento.AplicacionTLCAN == true ? 1 : 2;
                        procedimiento.Incrementables = procedimiento.Incrementables == true ? 1 : 2;
                        procedimiento.EnvioProformaAutorizacion = procedimiento.EnvioProformaAutorizacion == true ? 1 : 2;
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
                    procedimiento.AlicacionTLCAN = 0;
                    procedimiento.Incrementables = 0;
                    procedimiento.EnvioProformaAutorizacion = 0;
                }


                procedimiento.FormaPagosCat = creaarraycatalogo(['Seleccione']).concat(vmPO.FormaPagosCat);
                procedimiento.TipoPedimentoCat = creaarraycatalogo(['Seleeccione', 'Importacion', 'Exportacion']);
                procedimiento.RegimensCat = creaarraycatalogo(['Seleccione']).concat(vmPO.RegimensCat);
                procedimiento.ManejoPedimientoCat = creaarraycatalogo(['Seleccione', 'Normal', 'Consolidado', 'Remesa']);
                procedimiento.IncotermsCat = creaarraycatalogo(['Seleccione']).concat(vmPO.IncotermsCat);
                procedimiento.MetodoValoracionsCat = creaarraycatalogo(['Seleccione']).concat(vmPO.MetodoValoracionsCat);
                procedimiento.FormaPagosCat = creaarraycatalogo(['Seleccione']).concat(vmPO.FormaPagosCat);
                procedimiento.VinculacionCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
                procedimiento.AplicacionPreferenciaCat = creaarraycatalogo(['Seleccione']).concat(vmPO.AplicacionPreferenciaCat);
                procedimiento.AlicacionTLCANCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
                procedimiento.IncrementablesCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);
                procedimiento.EnvioProformaAutorizacionCat = creaarraycatalogo(['Seleccione', 'SI', 'NO']);







                procedimiento.Id_abuladorProcedimientoOperacion = null;
                vmPO.arrayProcedimiento.push(procedimiento);
                console.log(procedimiento.Id_FormaPago)

            }

            console.log("arrayprocedimiento");
            console.log(vmPO.arrayProcedimiento);
        }
    }

})();


//$(function () {
//    $(document).on("click", "#btnmensajeNo", function () {
//        document.getElementById('popupNo').style.display = 'none'
//        $('.popupoverlay').fadeOut('fast');
//        return false;
//    });
//    $(document).on("click", "#btnmensajeok", function () {
//        document.getElementById('popupOk').style.display = 'none'
//        $('.popupoverlay').fadeOut('fast');
//        return false;
//    });
//});

//function creaarraycatalogo(items) {
//    var array = [];

//    for (var i = 0; i < items.length; i++) {
//        var item = {};
//        item.Id = i;
//        item.Descripcion = items[i];
//        item.Clave = "";
//        array.push(item);
//    }
//    return array;
//}

