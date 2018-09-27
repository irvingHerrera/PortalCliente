$(document).ready(function () {
	$("#btnGuardarDatosAdicionales").click(function () {

		var _idpreciente = window.aplicacionDatoUsuario.IdPrecliente;
		var datosadicionales = {};

		var _giro = $('#txtDAGiro').val();
		var _Telefono = $('#txtDATE').val();
		var _numero_empleados = $('#txtDANE').val();
		var _ventas_anuales = $('#txtDAVA').val();
		var _pagina_web = $('#txtPW').val();
		var _patemtes_operacion = $('#txtOper').val();
		var _frecuencia = $('#txtFrecuencia').val();
		var _correoarribo = $("#idCorreoArriboDA").val();
		var _vucemC = $("#factchecksi8").is(':checked');
        var _vucemG = $("#factcheckno8").is(':checked');

        var correcto = true;
        debugger;

        if (_giro.trim().length == 0)
        {
            correcto = false;   
        }
        if (_Telefono.trim().length == 0) {
            correcto = false;
        }
        if (_numero_empleados.trim().length == 0) {
            correcto = false;
        }
        if (_ventas_anuales.trim().length == 0) {
            correcto = false;
        }
        if (_pagina_web.trim().length == 0) {
            correcto = false;
        }
        if (_patemtes_operacion.trim().length == 0) {
            correcto = false;
        }
        if (_frecuencia.trim().length == 0) {
            correcto = false;
        }

        if (_correoarribo.trim().length == 0) {
            correcto = false;
        }



		datosadicionales.id_precliente = _idpreciente;
		datosadicionales.giro = _giro;
		datosadicionales.Telefono = _Telefono;
		datosadicionales.numero_empleados = _numero_empleados;
		datosadicionales.ventas_anuales = _ventas_anuales;
		datosadicionales.pagina_web = _pagina_web;
		datosadicionales.patemtes_operacion = _patemtes_operacion;
		datosadicionales.frecuencia = _frecuencia
        datosadicionales.correoarribo = _correoarribo;
        datosadicionales.tiempo_establecido = _Telefono;
		datosadicionales.vucemC = _vucemC
		datosadicionales.vucemG = _vucemG;


		var datos = [];
		var i = 0;
		$('#tblusrs tr').each(function () {
			if (i > 1) {
				var item = {};
				var nombre = $(this).find("td").eq(0).find("input").val();
				var puesto_departamento = $(this).find("td").eq(1).find("input").val();
				var telefono = $(this).find("td").eq(2).find("input").val();
				var correo = $(this).find("td").eq(3).find("input").val();
				var admon = $(this).find("td").eq(4).find("input").val();
				var oper = $(this).find("td").eq(5).find("input").val();

				item.id_precliente = _idpreciente;
				item.nombre = nombre;
				item.puesto_departamento = puesto_departamento;
				item.telefono = telefono;
				item.correo = correo;
				item.admon = admon;
				item.oper = oper;

				datos[i - 2] = item;
			}
			i++;
		});

		var mensaje = "";
		if (!correcto)
		{
			mensaje = "Se deben llenar todos los campos";
		}

		if (datos.length == 0)
		{
			mensaje += "<br /> debe agregar por lo menos un usuario aduabook";
			correcto = false;
		}
	
		if (correcto) {
			$.ajax({
				url: "../DatosAdicionales/GuardaDatosAdicionales",
				type: 'POST',
				contentType: 'application/json',
				datatype: 'json',
				data: JSON.stringify({ "datosadicionales": datosadicionales, "usuariosaudabook": datos }),
				success: function (data) {
					//$("input").val("");
					mensajepop_okAdicionales();
				},
				error: function (data) {
					debugger;
					alert("error");
				}
			});

		} else
		{
			$('.popupoverlay').fadeIn('fast');
			$("#mensajeError").empty();
			$("#mensajeError").html(mensaje);
			$("#popupError").show();
		}
		
		console.log(datos);
    });

    $("#btAceptaModalError").click(function () {
        $("#popupError").hide();
        $('.popupoverlay').fadeOut('fast');
    });

    function mensajepop_okAdicionales() {
        /*
		$('.popupoverlay').fadeIn('fast');
		$('#popupok').fadeIn('fast');

		$('#popupok .icon i').addClass('far fa-check-circle');
		document.getElementById('mensajeok').innerHTML = mensaje;
		*/
        $('.popupoverlay').fadeIn('fast');
        $('#popupDatosAdicionales').fadeIn('fast');
        $('#popupDatosAdicionales .icon i').addClass('far fa-check-circle');
        document.getElementById('mensajeDatosAdicionales').innerHTML = "Se guardó correctamente la información.";
    }

});
