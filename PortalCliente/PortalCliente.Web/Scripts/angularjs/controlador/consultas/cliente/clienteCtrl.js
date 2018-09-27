(function () {
    'use strict';

    angular
        .module('app')
        .controller('clienteCtrl', cliente);

    cliente.$inject = ['$scope', '$consultaService', '$catalogoService', '$capturaClienteService', '$aprovacionService'];

    function cliente($scope, $consultaService, $catalogoService, $capturaClienteService, $aprovacionService) {
        //datos de session
        var rolUsuario = window.aplicacionDatoUsuario.Rol;
        var usuario = window.aplicacionDatoUsuario.IdUsuario;
        var idPrecliente = window.aplicacionDatoUsuario.IdPrecliente;

        var precliente_sel = "";

        var vm = $scope;
        //vm.listaAprobador = [];
        vm.inputDisable = true;
        vm.botonActivarCliente = false;
        vm.botonInactivarCliente = false;

        vm.model = {};
        vm.model.DatosCliente = {};
        vm.model.DatoAdicional = {};
        vm.model.UsuarioAudabook = [];

        vm.catalogoPais = [];
        vm.catalogoEstado = [];
        vm.catalogoCiudad = [];

        vm.modelActCte = {};
        //evento 

        $catalogoService.obtenerPais().then(function (data) {

            //console.log("paises", data);
            vm.catalogoPais = data.data.dato;
        }, function (error) {
            console.log("Error", error);
        })

        vm.activarCliente = function () {
            $capturaClienteService.activarCliente({ id_precliente: precliente_sel }).then(function (data) {
                if (data.data.resultado) {
                } else {
                    console.log("Error", data.data.mensaje);
                }
            }, function (error) {
                console.log("Error", error);
            })
        }

        vm.inactivarCliente = function () {
            $capturaClienteService.inactivarCliente({ id_precliente: precliente_sel }).then(function (data) {
                if (data.data.resultado) {
                } else {
                    console.log("Error", data.data.mensaje);
                }
            }, function (error) {
                console.log("Error", error);
            })
        }

        $scope.$on("seleccion_busqueda", function (evet, data) {
            precliente_sel = data.IdPrecliente;

            console.log("id precliente sel", precliente_sel);

        });

        //*****evento buscador***
        $scope.$on("seleccion_busqueda", function (evet, data) {
            cargarRegistroCliente(data);
        });

        function cargarRegistroCliente(usuarioBusqueda) {

            $capturaClienteService.obtenerInfoCliente({ id_usuario: usuarioBusqueda.IdUsuario }).then(function (promesas) {
                var infoCliente = promesas.data.data[0];

                if (rolUsuario === 7 && infoCliente.banderilla === true) { // Alta cliente
                    vm.botonInactivarCliente = true;
                }
                else if (rolUsuario === 5 && infoCliente.banderilla === false) { // Director Comercial
                    vm.botonActivarCliente = true;
                }

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

                angular.forEach(vm.catalogoPais, function (pais, index) {
                    if (pais.Id == vm.model.DatosCliente.IdPais) {
                        vm.model.DatosCliente.Pais = vm.catalogoPais[index];
                        vm.obtenerEstado(vm.model.DatosCliente.Pais);
                    }
                });

                $capturaClienteService.obtenerContactosCliente({ id_precliente: usuarioBusqueda.IdPrecliente }).then(function (promesas) {

                    var contactos = promesas.data.data;
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

                        $capturaClienteService.obtenerPECACliente({ id_precliente: usuarioBusqueda.IdPrecliente }).then(function (promesas) {
                            var cuentas = promesas.data.data;

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

                                $capturaClienteService.obtenerUsrsAduabookCliente({ id_precliente: usuarioBusqueda.IdPrecliente }).then(function (promesas) {
                                    vm.model.UsuarioAudabook = [];

                                    var usuario = promesas.data.data;
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

                                    $aprovacionService.ObtenerInfActCte({ idUsuario: usuarioBusqueda.IdUsuario, idPrecliente: usuarioBusqueda.IdPrecliente }).then(function (data) {
                                        vm.modelActCte = data.data.data;
                                    })
                                    //$capturaClienteService.obtenerCuestionarioCliente({ id_precliente: usuarioBusqueda.IdPrecliente }).then(function (promesas) {

                                    //    $capturaClienteService.obtenerDocumentosCliente({ id_precliente: usuarioBusqueda.IdPrecliente }).then(function (promesas) {

                                    //    })

                                    //})

                                })
                            })
                        })
                    })
                })

            })
        }
        vm.obtenerEstado = function (pais) {
            $catalogoService.obtenerEstados({ idPais: pais.Id }).then(function (data) {
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
                $catalogoService.obtenerCiudades({ idEstado: estado.Id }).then(function (data) {
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
                    if (ciudad.Id == vm.model.DatosCliente.IdCiudad) {
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
                    if (estado.Id == vm.model.DatosCliente.IdEstado) {
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

        function modalExito(mensaje) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup').fadeIn('fast');

            $('#popup .icon i').addClass('far fa-check-circle');
            document.getElementById('mensaje').innerHTML = mensaje;
        }
    }
})();