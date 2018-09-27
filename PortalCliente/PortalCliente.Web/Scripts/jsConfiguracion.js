var postback; 
var listRoles; 
var editando; 
var editandoRol;

$(".js-example-basic-single").select2();

$(function () {
	if (postback == undefined)
	{
        GetRoles();
        getmodulos();
        GetUsuariosActuales();
        GetRolesRoles();
        postback = 0;
		editando = false; 
        editandoRol = true;
	}
});

$(document).ready(function () {
	$("#btnUsuario").click(function () {
		$("#dvUsuarios").show();
		$("#dvRoles").hide();
	});

	$("#btnRoles").click(function () {
		$("#dvUsuarios").hide();
		$("#dvRoles").show();
	});

	$("#btnGuardar").click(function () {
		guardaUsuario();
    });

    $("#btnCancelar").click(function () {
        limpiaGuardarUsuario();
        fneditando(false);
    });

	$("#ddlRol").change(function () {
		var id = $(this).val();
		muestraporrol(id,false);
	});

    $("#btnGuardarRol").click(function () {
        GuardaRol();
    });

    obtenerEquipoOperativo();
});

function muestraporrol(id, editandousr) {
    if (id == 2) //cliente
    {
        $("#dvPrecliente").show();
        if (editandousr != undefined && editandousr == true) {

        } else {
            getidprecliente()
        }
        $("#txtpwd").prop("disabled", false);
        $("#txtpwd").val("");
        $("#dvGrupoLider").hide();
        $("#txtGrupo").val("");
        $("#txtmail").prop("disabled", false);
    }
    else if (id == 3) // lider
    {
        $("#dvPrecliente").hide();
        $("#txtpwd").prop("disabled", true);
        $("#txtpwd").val("");
        $("#dvGrupoLider").show();
		$("#txtGrupo").val("");
		debugger;
		if (editandousr != undefined && editandousr == true) {
			$("#txtmail").prop("disabled", false);
			
		} else
		{
			$("#txtmail").prop("disabled", true);
			
		}
        

    } else // otro 
    {
        $("#dvGrupoLider").hide();
        $("#txtGrupo").val("");
        $("#dvPrecliente").hide();
        $("#txtpwd").prop("disabled", true);
        $("#txtpwd").val("");
		if (editandousr != undefined && editandousr == true) {
			$("#txtmail").prop("disabled", false);

		} else {
			$("#txtmail").prop("disabled", true);

		}
    }
}

function guardaUsuario() {
	try
	{
		var txtnombreusuario = $("#txtnombreusuario").val().trim();
		var ddlRol = $("#ddlRol").val();
		var txtcuentausuario = $("#txtcuentausuario").val().trim();
		var txtpwd = $("#txtpwd").val().trim();
		var txtmail = $("#txtmail").val().trim();

		var correcto = true;

		if (txtnombreusuario.length == 0)
		{
			correcto = false;    
		}

		if (ddlRol == 0)
		{
			correcto = false;
		}

		if (txtcuentausuario.length == 0)
		{
			correcto = false; 
		}

        if (txtpwd.length == 0 && ddlRol == 2) {
            correcto = false;
        } else if (ddlRol != 2)
        {
            txtpwd = "";
        }

        

		 if (txtmail.length == 0)
		 {
             //correcto = false; 
             txtmail = "";
         }

        if (ddlRol != 2) {
            if (!ExisteAuda(txtcuentausuario))
            {
                mensajerror('Cuenta de usuario no existe en Aduasis..');
                return;
            }
        }

        if (ddlRol == 3) {
            if (!$("#txtGrupo").val()) {
                correcto = false;
            }
        }

		var datos = {};
		datos.nombre = txtnombreusuario;
		datos.usuario = txtcuentausuario;
		datos.contrasenia = txtpwd;
		datos.correo = txtmail;
        datos.id_rol = ddlRol;

        if ($("#factchecksi8").prop("checked")) {
            datos.Activo = true;
        } else {
            datos.Activo = false;
        }


        if (ddlRol == 3) {
            datos.grupo = $("#txtGrupo").val(); 
        }
        var _url = "../Configuracion/GuardaUsuario";
        if (editando)
        {
            datos.id_usuario = $("#hduser").val();
            var _url = "../Configuracion/UpdateUsuario";
            

        }
        
        if (correcto) {
            $.ajax({
                url: _url,
                type: 'POST',
                contentType: 'application/json',
                datatype: 'json',
                data: JSON.stringify({ "usuario": datos }),
				success: function (data) {
					if (data.Resultado) {
						limpiaGuardarUsuario();
						GetUsuariosActuales();
						mensajepop("Alta de usuario");
						fneditando(false);
					} else
					{
						if (data.Mensaje != undefined)
						{
							mensajerror(data.Mensaje);
						}
					}
                    
                },
				error: function (data) {

					if (contiene(data,'Cuenta de usuario no existe en Aduasis'))
					{
						mensajerror('Cuenta de usuario no existe en Aduasis');
					}
                }
            });
        }
        else
        {
            mensajerror("todos los campso son obligatorios"); 
        }
	}
	catch (err) {
		console.log(err);
	}
}

function limpiaGuardarUsuario()
{
	$("#txtnombreusuario").val("");
	$("#ddlRol").val("");
	$("#txtcuentausuario").val("");
	$("#txtpwd").val("");
	$("#txtmail").val("");
	$("#dvGrupoLider").hide();
	$("#txtGrupo").val("");
	$("#dvPrecliente").hide();
	$("#txtpwd").prop("disabled", true);
    $("#txtpwd").val("");
	$("#ddlRol").prop("disabled", false);
	$("#txtidprecliente").val("");
    GetRoles();
}

function GetRoles()
{
	$.ajax({
		url: "../Configuracion/GetRoles",
		type: 'GET',
        contentType: 'application/json',
        async: false,
		datatype: 'json',
        success: function (data) {
            listRoles = [];
			console.log(data);
			$("#ddlRol").empty();
			$("#ddlRol").append(new Option("Rol", 0));   
			for (var i = 0; i < data.length; i++)
            {
                var item = {}; 
				console.log(data[i]);
                $("#ddlRol").append(new Option(data[i].descripcion, data[i].id_rol));
                item.id = data[i].id_rol;
                item.desc = data[i].descripcion;
                listRoles[i] = item;
			}
		},
		error: function (data) {
			debugger;
			alert("error");
		}
	});
}

function GetUsuariosActuales()
{
    try
    {
        $.ajax({
            url: "../Configuracion/GetUsuarios",
            type: 'GET',
            contentType: 'application/json',
            datatype: 'json',
            success: function (data) {
                //console.log(data);
                console.log("usuarios");
                console.log(data.usuarios);
                var strTable = "";
                strTable = '<table class="table table-responsive table-hover table-striped table-bordered" id="tblGrid"><thead><tr><th>Nombre</th><th>Usuario</th><th>Rol</th><th>Correo</th><th></th><th></th></tr></thead><tbody>';
                for (var i = 0; i < data.usuarios.length; i++) {
                     var v = data.usuarios[i];
                    strTable += '<tr><td>' + v.nombre + '</td><td>' + v.usuario + '</td><td>' + getRolDesc(v.id_rol) + '</td><td>' + v.correo + '</td>';
                    strTable += '<td>';
                    strTable += '<a href="#" id="btnEdit-' + v.id_usuario + '" class="btn btn-primary editRow">Editar</a></td>';
                    strTable += '<td>';
                    if (v.Activo) {
                        strTable += '<a href = "#" data-toggle="modal" data-target="#modalborrar" id = "btnDel-' + v.id_usuario + '" class="btn btn-danger deleterow" >Inactivar</a > ';
                    } else
                    {
                        strTable += '<a href = "#" data-toggle="modal" data-target="#modalborrar" id = "btnAct-' + v.id_usuario + '" class="btn btn-primary deleterow" >Activar</a > ';
                    }
                    strTable += '</td></tr>';
                }

                //console.log(strTable);

                $("#dvGridUsuarios").empty();
                $("#dvGridUsuarios").html(strTable);
                $("#tblGrid").DataTable({
                    "language": {
                        "lengthMenu": "Mostrando _MENU_ filas por pagina",
                        "zeroRecords": "No hay datos",
                        "info": "Mostrando pagina _PAGE_ de _PAGES_",
                        "infoEmpty": "No hay datos disponibles",
                        "infoFiltered": "(filtrando de _MAX_ total de filas)",
                        "search": "Buscar",
                        "paginate": {
                            "previous": "Anterior",
                            "next": "Siguiente"
                        }
                    }
                });
            },
            error: function (data) {
                debugger;
                alert("error");
            }
        });            
    }
    catch (err)
    {
        console.log(err.message);
    }
}

function getRolDesc(id)
{
    var desc = "";
    for (var i = 0; i < listRoles.length; i++)
    {
        if (listRoles[i].id == id)
        {
            desc = listRoles[i].desc;
        }
    }
    return desc; 
}

$(function () {

    $(".toggle-password").click(function () {

        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $($(this).attr("toggle"));
        if (input.attr("type") == "password") {
            input.attr("type", "text");
        } else {
            input.attr("type", "password");
        }
    });

    $(document).on("click", ".deleterow", function () {
        var id = $(this).attr("id").split("-")[1];
        var _act = $(this).attr("id").split("-")[0];
        var acivar = false;
        if (_act == 'btnAct')
        {
            acivar = true;
        }

        //if (confirm("¿Seguro de eliminar el registro?"))
        //{
            $.ajax({
                url: "../Configuracion/DeleteUsuario",
                type: 'POST',
                contentType: 'application/json',
                datatype: 'json',
                data: JSON.stringify({ "id": id, "activar": acivar }),
                success: function (data) {
                    GetUsuariosActuales();
                    if (acivar) {
                        mensajepop("El usuario se activo de forma correcta");
                    } else
                    {
                        mensajepop("El usuario se inactivo de forma correcta");
                    }
                    
                },
                error: function (data) {
                    debugger;
                    alert("error");
                }
            });
        //} 
    });
});

$(function () {
    $(document).on("click", ".editRow", function () {
        var id = $(this).attr("id").split("-")[1];
        $("#hduser").val(id);
        fneditando(true);
        GetUsuarioByID(id);
    });
});

function GetUsuarioByID(id)
{
    try
    {       
        $.ajax({
            url: "../Configuracion/GetUsuarioById?id=" + id,
            type: 'GET',
            contentType: 'application/json',
            datatype: 'json',
            success: function (data) {   
               
                var v = data.usuario;

                if (v.id_rol == 2) {
                    $("#ddlRol").prop("disabled", true);
                } else {
                    $("#ddlRol").prop("disabled", false);
                    $("#ddlRol option[value='2']").each(function () {
                        $(this).remove();
                    });
                }

                $("#txtnombreusuario").val(v.nombre);
                $("#ddlRol").val(v.id_rol);
                muestraporrol(v.id_rol, true);
                $("#txtcuentausuario").val(v.usuario);
                $("#txtpwd").val(v.contrasenia);
                $("#txtmail").val(v.correo);
                debugger;
				if (v.id_rol == 3)
				{
                    $("#txtGrupo").val(v.grupo);
                }
                debugger;
                if (v.Activo) {
                    $("#factchecksi8").prop("checked", true);
                    $("#factcheckno8").prop("checked", false);
                    
                } else
                {
                    $("#factchecksi8").prop("checked", false);
                    $("#factcheckno8").prop("checked", true);
                }
            },
            error: function (data) {
                debugger;
                alert("error");
            }
        });        
    }
    catch (err)
    {
        console.log(err);
    }
}

function fneditando(estado)
{
    editando = estado; 
    if (estado) {
        $("#txttitulo").empty();
        $("#txttitulo").html("Editar Usuario");
    }
    else
    {
        $("#txttitulo").empty();
        $("#txttitulo").html("Alta Usuario");
    }
}

//SECCION DE roles 
function getmodulos()
{
    try
    {
        $.ajax({
            url: "../Configuracion/GetModulos",
            type: 'GET',
            contentType: 'application/json',
            async: false,
            datatype: 'json',
            success: function (data) {
				var strhtml = "";
				for (var i = 0; i < data.modulos.length; i++)
				{
					strhtml += '<div onclick="checa('+ data.modulos[i].id_modulo +')"><input type="checkbox" id="cc-' + data.modulos[i].id_modulo + '"  class="factcheck csboxpant" /><label><span><div></div></span>' + data.modulos[i].descripcion +'</label></div>'
					
				}
				$("#dvPantallas").empty();
				$("#dvPantallas").html(strhtml);
             
            },
            error: function (data) {
                debugger;
                alert("error");
            }
        });
    }
    catch (err)
    {
        console.log(err);
    }
}

function mensajepop(mensaje)
{
    $('.popupoverlay').fadeIn('fast');
    $('#popup').fadeIn('fast');

    $('#popup .icon i').addClass('far fa-check-circle');
    document.getElementById('mensaje').innerHTML = mensaje;
}

function mensajerror(mensaje)
{
	$('.popupoverlay').fadeIn('fast');
	$('#popup-error').fadeIn('fast');

	$('#popup-error .icon i').addClass('fas fa-exclamation-circle');
	document.getElementById('mensaje-aviso').innerHTML = mensaje;
}

function GuardaRol()
{
	var modulos = [];
	var cont = 0;
	$(".csboxpant").each(function () {

		if ($(this).is(":checked"))
		{
			modulos[cont] = $(this).attr("id").split("-")[1];
			cont++;
		}
	});

	var _modulos = "";
    for (var i = 0; i < modulos.length; i++)
    {
        if (i == modulos.length - 1) {
            _modulos += modulos[i];
        }
        else
        {
            _modulos += modulos[i] + "|";   
        }
        
    }
    var descripcionrol = "pantallas#"+ _modulos; 

    var datos = {};
	datos.descripcion = descripcionrol;
    var _urlrol = "../Configuracion/EditRol";
		datos.id_rol = $("#hdRol").val();
	
	if (modulos.length > 0) {
		$.ajax({
			url: _urlrol,
			type: 'POST',
			contentType: 'application/json',
			datatype: 'json',
			data: JSON.stringify({ "rol": datos }),
			success: function (data) {
				//alert("El rol se guardo de forma correcta");

                mensajepop("El rol se guardó correctamente.");
				$("#ddlModulos").empty();
				getmodulos();
			//	$("#txtRolDesc").val("");
				GetRolesRoles();
				if (editandoRol)
				{
					fneditandorol(true);
				}
			},
			error: function (data) {
				debugger;
				alert("error");
			}
		});
	} else
    {
        mensajerror("complete los datos"); 
	}
    
    
    
}


$(document).ready(function () {
    $("#btAceptaModal").click(function () {
        $('.popupoverlay').fadeOut('fast');
        $('#popup').fadeOut('fast');
    });
});
    
function GetRolesRoles() {
    $.ajax({
        url: "../Configuracion/GetRoles",
        type: 'GET',
        contentType: 'application/json',
        async: false,
        datatype: 'json',
        success: function (data) {
          
            $("#ddlRolesEdit").empty();
            $("#ddlRolesEdit").append(new Option("Seleccione", "0")); 
            for (var i = 0; i < data.length; i++)
            {
                var v = data[i];
                $("#ddlRolesEdit").append(new Option(v.descripcion,v.id_rol));
            }


    //        var strTable = "";
    //        strTable = '<table class="table table-responsive table-hover table-striped table-bordered" id="tblGridm"><thead><tr><th>Descripción</th><th></th></tr></thead><tbody>';// <th>Usuario</th><th></th><th></th></tr></thead><tbody>';
    //        for (var i = 0; i < data.length; i++) {
    //            var v = data[i];
    //            strTable += '<tr><td>' + v.descripcion + '</td>';
				//strTable += '<td>';
				//strTable += '<a href="#" id="btnEdit-' + v.id_rol + '" class="btn btn-primary editRowRol"><i class="fa fa-pencil fa-fw"></i>Editar</a></td>';
    //            //strTable += '<td><a href="#" data-toggle="modal" data-target="#modalborrar" id="btnDel-' + v.id_usuario + '" class="btn btn-danger deleterow"><i class="fa fa-trash-o fa-fw"></i>Eliminar</a>';
    //            //strTable += '</td>
    //            strTable += '</tr >';
    //        }

    //        console.log(strTable);

    //        $("#dvGridRoles").empty();
    //        $("#dvGridRoles").html(strTable);
    //        $("#tblGridm").DataTable({
    //            "language": {
    //                "lengthMenu": "Mostrando _MENU_ filas por pagina",
    //                "zeroRecords": "No hay datos",
    //                "info": "Mostrando pagina _PAGE_ de _PAGES_",
    //                "infoEmpty": "No hay datos disponibles",
    //                "infoFiltered": "(filtrando de _MAX_ total de filas)",
    //                "search": "Buscar",
    //                "paginate": {
    //                    "previous": "Anterior",
    //                    "next": "Siguiente"
    //                }
    //            }
    //        });
        },
        error: function (data) {
            console.error(data); 
        }
    });
}

function checa(id)
{
	debugger;
	if ($("#cc-" + id).prop("checked")) {
		$("#cc-" + id).prop("checked", false);
	} else {
		$("#cc-" + id).prop("checked", true);
	}
}

$(function () {
	$(document).on("click", ".editRowRol", function () {
		var id = $(this).attr("id").split("-")[1]; 
		$("#hdRol").val(id);
		fneditandorol(true);
		GetDatosRolEditar(id);
		return false;
	});
});


$(function () {
    $(document).on("change", "#ddlRolesEdit", function () {
        var id = $(this).val();
        $("#hdRol").val(id);
        GetDatosRolEditar(id)
    });
});

function fneditandorol(estado)
{
	editandoRol = estado;
	$("#txtRoltitulo").empty();
	if (estado) {
		$("#txtRoltitulo").html("Roles");
	} else {
		$("#txtRoltitulo").html("Roles");
	}
}


function GetDatosRolEditar(idrol)
{
	//$.ajax({
	//	url: "../Configuracion/GetRolByID?id=" + idrol,
	//	type: 'GET',
	//	contentType: 'application/json',
	//	async: false,
	//	datatype: 'json',
	//	success: function (data) {
	//		console.log(data);
	//		$("#txtRolDesc").val(data.descripcion);
	//	},
	//	error: function (data) {
	//		console.error(data);
	//	}
	//});


	$.ajax({
		url: "../Configuracion/GetModulosByRol?idrol=" + idrol,
		type: 'GET',
		contentType: 'application/json',
		async: false,
		datatype: 'json',
		success: function (data) {
			console.log(data);
			$(".csboxpant").each(function () {
				if (estaelrol($(this).attr("id").split("-")[1], data.modulos)) {
					$(this).prop("checked", true);
				} else
				{
					$(this).prop("checked", false);
				}
			});
		},
		error: function (data) {
			console.error(data);
		}
	});

	function estaelrol(id, array)
	{
		var esta = false; 
		for (var i = 0; i < array.length; i++)
		{
			if (id == array[i].id_modulo)
			{
				esta = true;
			}
		}
		return esta;
	}
}


function contiene(data, str) {
	try {
		debugger;
		var msg = JSON.parse(data.responseText).Error;
		if (msg.indexOf(str) >= 0) {
			return true;
		}
		return false;
	}
	catch (err) { return false; }
}


function getidprecliente()
{
	$.ajax({
		url: "../Configuracion/Getnextprecliente",
		type: 'GET',
		contentType: 'application/json',
		async: false,
		datatype: 'json',
		success: function (data) {
			var precliente = data.next;
			$("#txtidprecliente").val(formatoPreCliente(data.next));
		},
		error: function (data) {

		}
	});
}


function ExisteAuda(usr) {
    var res = false;
    $.ajax({
        url: "../Configuracion/ExisteAuda?usuario=" + usr,
        type: 'GET',
        contentType: 'application/json',
        async: false,
        datatype: 'json',
        success: function (data) {
            res = data.res;
            
        },
        error: function (data) {

        }
    });
    return res;
}

function formatoPreCliente(numero)
{
	debugger;
	var ceros = 'PRE_';
	for (var i = 0; i < (5 - numero.toString().length); i++)
	{
		ceros += '0';
	}
	return ceros + numero; 
}


function obtenerEquipoOperativo() {
    $.ajax({
        url: $("#url-equipo-operativo").val(),
        type: 'GET',
        contentType: 'application/json',
        async: false,
        datatype: 'json',
        success: function (data) {
            if (data.resultado) {
                $.each(data.data, function (i, item) {
                    $('#txtGrupo').append($('<option>', {
                        value: item.IdEquipo,
                        text: item.Descripcion
                    }));
                });
            }
            else {
                console.log("Ocurrió un problema al obtener el catalogo de Equipo Operativo");

            }

        },
        error: function (data) {
            console.log("error: obtenerEquipoOperativo", data);
        }
    });

}