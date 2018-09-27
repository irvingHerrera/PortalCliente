(function () {
    'use strict';

    angular
        .module('app')
        .controller('preClienteCtrl', preCliente);

    preCliente.$inject = ['$scope', '$consultaService', '$capturaClienteService','$aprovacionService','$q'];

    function preCliente($scope, $consultaService, $capturaClienteService, $aprovacionService, $q) {
        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        var precliente_sel = "";

        var vm = $scope;
        vm.listaAprobador = [];
        //rolUsuario = 6;
        vm.habGerenteComercial = true;

        vm.model = {};
        vm.model.DatosCliente = {};
        vm.model.DatoAdicional = {};
        vm.model.UsuarioAudabook = [];
        

        function obtenerPromesas(usuarioBusqueda) {
            var promesaCapturaCliente = $capturaClienteService.obtenerInfoCliente({ id_usuario: usuarioBusqueda.IdUsuario });
            var promesaContactoCliente = $capturaClienteService.obtenerContactosCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaCuenta = $capturaClienteService.obtenerPECACliente({ id_precliente: usuarioBusqueda.IdPrecliente });
            var promesaUsuarioAduabook = $capturaClienteService.obtenerUsrsAduabookCliente({ id_precliente: usuarioBusqueda.IdPrecliente });
           
            return $q.all({
                promesaCapturaCliente,
                promesaContactoCliente,
                promesaCuenta,
                promesaUsuarioAduabook
                
            });

        }
        function resolverPromesa(promesaGeneral) {

            promesaGeneral.then(function (promesas) {
                //console.log("promesas.promesaCapturaCliente", promesas.promesaCapturaCliente);
                //console.log("promesas.promesaContactoCliente", promesas.promesaContactoCliente);
                //console.log("promesas.promesaCuenta", promesas.promesaCuenta);
                //console.log("promesas.promesaUsuarioAduabook", promesas.promesaUsuarioAduabook);
               
                if (promesas.promesaCapturaCliente.data.resultado) {

                  
                    var infoCliente = promesas.promesaCapturaCliente.data.data[0];
                    vm.model.DatosCliente.IdPrecliente = infoCliente.id_precliente;
                    console.log("Hola", infoCliente.id_precliente);
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
                    vm.model.DatosCliente.Pais = infoCliente.pais;
                    vm.model.DatosCliente.Ciudad = infoCliente.ciudad;
                    vm.model.DatosCliente.Estado = infoCliente.estado;
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
            var promesaGeneral = obtenerPromesas(usuarioBusqueda);
            resolverPromesa(promesaGeneral);
        }
        function obtenerInformacionCte(data) {
            $aprovacionService.ObtenerInfActCte({ idUsuario: data.IdUsuario, idPrecliente: data.IdPrecliente }).then(function (data) {
                vm.modelActCte = data.data.data;
                console.log("datos act cliente aprobacion!!", vm.modelActCte);
            }, function (error) {
                console.log("Error al obtener datos de inf cliente", error);
            });
        }
        function ObtenerAprobacionDePreAltaCliente(data) {
            $consultaService.ObtenerAprobacionDePreAltaCliente({ idPrecliente: data.IdPrecliente }).then(function (data) {
                vm.aproPreAlta = data.data.data;
                console.log("Aprobacion De Pre Alta Cliente!!", vm.aproPreAlta);
            }, function (error) {
                console.log("Error al obtener Aprobacion De Pre Alta Cliente", error);
            });
        }
        function ObtenerAprobacionDeAltaCliente(data) {
            $consultaService.ObtenerAprobacionDeAltaCliente({ idPrecliente: data.IdPrecliente }).then(function (data) {
                vm.aproAltaCliente = data.data.data;
                console.log("Aprobacion De  Alta Cliente!!", vm.aproAltaCliente);
            }, function (error) {
                console.log("Error al obtener Aprobacion De  Alta Cliente", error);
            });
        }
        //evento 
        $scope.$on("seleccion_busqueda", function (evet, data) {
            console.log("seleccion_busqueda controlador aprobador", data);
            vm.classTopAprobador = '';
            vm.listaAprobador = [];

            precliente_sel = data.IdPrecliente;

            if (data.Estatus === 6 && rolUsuario === 5) {
                vm.habGerenteComercial = false;
            }
            else {
                vm.habGerenteComercial = true;
            }
            //vm.habGerenteComercial = !((rolUsuario == 6) && (precliente_sel != undefined));

            console.log("id precliente sel", precliente_sel);
            //vm.obtenerListaNoAprobador(data);
            cargarRegistroCliente(data);
            obtenerInformacionCte(data);
            ObtenerAprobacionDePreAltaCliente(data);
            ObtenerAprobacionDeAltaCliente(data);
            vm.inputDisable = true;
        });

        //codigo duro
        vm.obtenerListaNoAprobador = function (precliente) {
            $consultaService.ObtenerUsrsNoAprobado({ id_precliente: precliente.IdPrecliente, id_estatus: 6 })
                .then(function (data) {
                    vm.listaAprobador = data.data.data;

                    console.log("visible listado", data);


                    if (vm.listaAprobador.length > 0) {
                        vm.classTopAprobador = 'top-aprobador';
                    }
                    else {
                        vm.classTopAprobador = '';
                    }
                }, function (error) {
                    console.log("Error", data.data.mensaje + ' ' + error);
                })
        }

        vm.AprobacionPrealta = function (data) {
            $consultaService.AprobacionPrealta({ idUsuario: usuario, idPrecliente: precliente_sel })
                .then(function (data) {
                    var response = data.data;
                    console.log("response aprobacion", response);
                    if (response.resultado) {
                        modalExito("Cliente Aprobado Prealta");
                    } else {
                        modalError(response.mensaje);
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
        }
    }
})();