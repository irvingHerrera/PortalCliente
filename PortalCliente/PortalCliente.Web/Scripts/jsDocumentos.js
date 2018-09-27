var numeroDocumento = 0;

function UploadDocumento() {
    try {
        var _id = window.aplicacionDatoUsuario.IdPrecliente;//$("#in1").val();
        if (_id > 0) {
            var files = $("#flsubir").get(0).files;

            // Se desactivan los documentos activos del precliente por tipo de documento
            if (files.length > 0) {
                $.ajax({
                    url: "../DocumentosCliente/DesactivarDocumentos?id_precliente=" + _id + "&tipo_documento=" + $("#hdTipo").val(),
                    contentType: 'application/json',
                    async: false,
                    datatype: 'json',
                    success: function (data) {
                        console.log(data);
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }

            // Se guardan los "n" documentos
            for (var i in files) {
                var _tipo = $("#hdTipo").val();
                var data = new FormData();
                if (files.length > 0) {
                    //data.append("UploadedDocument", files[0]);
                    data.append("UploadedDocument", files[i]);
                    data.append("id", _id);
                    data.append("tipo", _tipo);
                }
                $.ajax({
                    url: "../DocumentosCliente/GuardaDocumento",
                    type: 'POST',
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (data) {
                        if (!data.Error) {
                            reemplazaicono(_tipo, "Documento(s) cargado(s)");
                            //reemplazaicono(_tipo, files[0].name);
                            mensajepop_ok("Correcto");
                            $("#dvnamedoc" + _tipo).removeClass("alert-danger");
                            numeroDocumento += 1;
                            $("#flsubir").val("");
                        } else {
                            $('.popupoverlay').fadeIn('fast');
                            $("#mensajeError").empty();
                            $("#mensajeError").html("El tipo de archivo no es admitido.");
                            $("#popupError").show();
                        }
                    },
                    error: function (data) {
                        console.log(data);
                        //alert("Error");
                    }
                });
            }
        } else {
            //alert("error");
            console.log(data);
        }
    }
    catch (err) {
        console.log(err);
        ShowModal(false);
    }
}

$(document).ready(function () {
    $("#btnSubirArchivo").click(function () {
        UploadDocumento();
        return false;
    });

    $("#guardar4").click(function () {
        if ($('#mot1no').prop('checked')) {
            var valor = $('#motivo1').val();
            if (valor == "") {
                $('.popupoverlay').fadeIn('fast');
                $('#popupFin').fadeIn('fast');
                $('#popupFin .icon .far').addClass('fa-check-circle');
                document.getElementById('mensajeFin').innerHTML = "Favor de capturar motivo por el cual no envía la encomienda de respaldo.";
                $('#cont-paso4').scrollTop(0);
                $('#motivo1').addClass('falta');
                return;
            }
        }
        fnTerminar();
        return false;
    });
});

function setIDdoc(id) {
    console.log("entro" + id);
    $("#hdTipo").val(id);
}

function mensajepop_ok(mensaje) {
    $('.popupoverlay').fadeIn('fast');
    $('#popupok').fadeIn('fast');

    $('#popupok .icon i').addClass('far fa-check-circle');
    document.getElementById('mensajeok').innerHTML = mensaje;
}

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

$(document).ready(function () {
    $("#btAceptaModal").click(function () {
        $('.popupoverlay').fadeOut('fast');
        $('#popupok').fadeOut('fast');
    });
});

function reemplazaicono(id, documento) {
    $("#dvDoc" + id).empty();
    if (id == 2)
        $("#dvDoc" + id).html('<span class="fas fa-check-circle icon boxtool motivo' + id + ' motivo20"><div class="tooltip big">' + documento + '</div></span>  <i class="fas fa-sync-alt icon boxtool motivo20"><div class="tooltip">Actualizar</div></i>');
    else
        $("#dvDoc" + id).html('<span class="fas fa-check-circle icon boxtool motivo' + id + '"><div class="tooltip big">' + documento + '</div></span>  <i class="fas fa-sync-alt icon boxtool"><div class="tooltip">Actualizar</div></i>');


}

function fnTerminar() {
    try {
        var mensaje = "";
        var carta = false;
        var idpre = window.aplicacionDatoUsuario.IdPrecliente;
        if ($("#mot1no").is(":checked")) {
            carta = true;
            mensaje = $("#mensaje1").val();
        }
        $.ajax({
            url: "../DocumentosCliente/DocumentosCargadosPorPrecliente?idprecliente=" + idpre + "&carga=" + carta + "&mensaje=" + mensaje,
            type: 'GET',
            contentType: 'application/json',
            async: false,
            datatype: 'json',
            success: function (data) {
                $("#dvDocsCargados").empty();
                var strhtml = "";
                for (var i = 0; i < data.documentos.length; i++) {
                    strhtml += data.documentos[i].split("|")[0] + "<br />";
                }

                var totalesdoc = 10;
                if (carta) {
                    totalesdoc = 8;
                }

                if (data.documentos.length >= totalesdoc) {
                    //$("#dvDocsCargados").html(strhtml);
                    //$("#dvDocsCargados").html("carga exitosa");
                    //$('.popupoverlay').fadeIn('fast');
                    //$('#popupDocumentosOk').fadeIn('fast')
                    //$('#popupDocumentosOk .icon i').addClass('far fa-check-circle');

                    //mensajepop_ok("Carga exitosa");

                    $('.popupoverlay').fadeIn('fast');
                    $('#popupCerrarPreCliente').fadeIn('fast');
                    $('#popupCerrarPreCliente .icon i').addClass('far fa-check-circle');

                } else {
                    $('.popupoverlay').fadeIn('fast');
                    $("#mensajeError").empty();
                    $("#mensajeError").html("Carga incompleta");
                    $("#popupError").show();
                }


                for (var i = 1; i <= 11; i++) {
                    if (i > 2 || !carta) {
                        if (!contieneId(i, data.documentos)) {
                            $("#dvnamedoc" + i).addClass("alert-danger");
                        }
                    }
                }



            },
            error: function (data) {

            }
        });
    }
    catch (err) {
        console.log(err);
    }
}

$('#btSICerrarPreCliente').click(function () {

    $('.popupoverlay').fadeOut('fast');
    $('#popupCerrarPreCliente').fadeOut('fast');

    var v_idusuario = window.aplicacionDatoUsuario.IdUsuario;
    var v_idprecliente = window.aplicacionDatoUsuario.IdPrecliente;
    var v_con_carta_encomienda = false;
    if ($('#mot1si').prop('checked')) {
        v_con_carta_encomienda = true;
    }
    var v_motivo_sin_carta_encomienda = $('#motivo1').val();

    $.ajax({
        url: "../RegistroCliente/CerrarPrecliente?id_usuario=" + v_idusuario +
            "&con_carta_encomienda=" + v_con_carta_encomienda +
            "&id_precliente=" + v_idprecliente +
            "&motivo_sin_carta_encomienda=" + v_motivo_sin_carta_encomienda,
        type: 'POST',
        contentType: 'application/json',
        async: false,
        datatype: 'json',
        success: function (data) {
            if (data.resultado == true) {
                window.location.href = "/Login/Index";
            }
        },
        error: function (data) {
            $('.popupoverlay').fadeIn('fast');
            $("#mensajeError").empty();
            $("#mensajeError").html("Hubo un problema, intentar nuevamente.");
            $("#popupError").show();
        }
    });
});

$('#btNOCerrarPreCliente').click(function () {
    $('.popupoverlay').fadeOut('fast');
    $('#popupCerrarPreCliente').fadeOut('fast');
});

$(function () {
    $(document).on("click", ".fa-sync-alt", function () {
        $('#cargar').fadeIn('fast');
        $('.popupoverlay').fadeIn('fast');
    });
});

$(function () {
    $(document).on("click", "#btAceptaModalDoc", function () {
        $('#popupDocumentosOk').fadeOut('fast');
        $('.popupoverlay').fadeOut('fast');
    });
});

function contieneId(id, array) {
    var res = false;
    for (var i = 0; i < array.length; i++) {
        if (id == array[i].split("|")[1]) {
            res = true;
        }
    }
    return res;
}