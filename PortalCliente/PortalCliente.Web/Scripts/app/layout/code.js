window.onload = function () {
    $('#preloader').fadeOut('fast');
    $('body').css({ 'overflow': 'visible' });


    $('#datos-inicio').fadeIn('fast');
    $('.popupoverlay.captura').fadeIn('fast');

    $('#terminos').fadeIn('fast');
    $('.popupoverlay.terminos').fadeIn('fast');

};

function acordionProcedimiento() {
    setTimeout(function () {
        $('.menujq > ul > li > a').click(function () {
            var comprobar = $(this).next();
            $('.menujq li').removeClass('activa');
            $(this).closest('li').addClass('activa');
            if ((comprobar.is('ul')) && (comprobar.is(':visible'))) {
                $(this).closest('li').removeClass('activa');
                comprobar.slideUp('normal');
            }
            if ((comprobar.is('ul')) && (!comprobar.is(':visible'))) {
                $('.menujq ul ul:visible').slideUp('normal');
                comprobar.slideDown('normal');
            }
        });
    }, 100);
}

$(document).ready(function () {


    var indicador = 1;

    $('#menu-compress').on('click', function () {

        if (indicador == 1) {

            $('.navbar-menu').animate({ 'width': '50px' }, 300);
            $('.content-body').animate({ 'padding-left': '50px' }, 300);
            $('.wrapper').animate({ 'left': '50px' }, 300);
            $('.cssmenu > ul > li > a > span').fadeOut(100);
            $('.cssmenu ul ul').css({ 'display': 'block' });
            $('.cssmenu ul ul').addClass('submenu');
            $('.cssmenu ul ul').addClass('comprimido');
            $('.cssmenu ul li').addClass('subcont');
            $('.cssmenu > ul > li > .toblock').fadeIn('fast');


            indicador = 2;

        } else if (indicador == 2) {
            $('.navbar-menu').animate({ 'width': '250px' }, 300);
            $('.content-body').animate({ 'padding-left': '250px' }, 300);
            $('.wrapper').animate({ 'left': '250px' }, 300);
            setTimeout("$('.cssmenu > ul > li > a > span').fadeIn(100)", 300);
            $('.cssmenu ul ul').css({ 'display': 'none' });
            $('.cssmenu ul ul').removeClass('submenu');
            $('.cssmenu ul ul').removeClass('comprimido');
            $('.cssmenu ul li').removeClass('subcont');
            $('.has-sub').removeClass('active');
            $('.cssmenu > ul > li > .toblock').fadeOut('fast');
            indicador = 1;

        }

    });

    $('.close').click(function () {
        if (indicador == 1) {
            $('.cssmenu ul li').removeClass('open');
            $('.cssmenu ul ul').slideUp();
            $('.sub1,.sub2,.sub3').removeClass('active');
        } else if (indicador == 2) {
            $('.sub1,.sub2,.sub3').removeClass('active');
        }
    });

    $('.cssmenu a').on('click', function (event) {

        if ($(this).hasClass('anormal')) {

        } else if ($(this).hasClass('normal')) {

            $('#opensub').slideUp('fast');
            $('#opensub').parent().removeClass('open');
            $('.cssmenu a').removeClass('active');
            $(this).addClass('active');
            $('#con-sub').removeClass('active');

        } else if ($(this).hasClass('normali')) {

            $('.cssmenu a').removeClass('active');
            $(this).addClass('active');

        }

        if (screen.width < 768) {
            $('#menu').slideUp('slow');
            $('#overlay-menu-responsive').fadeOut('fast');
            responsive = 1;
        }
    });

    $('.menu-sections .btn-operaciones').on('click', function (event) {
        $('.menu-sections .btn-operaciones').removeClass('active');
        $(this).addClass('active');
    });


    var responsive = 1;
    $('#menu-responsive').click(function () {

        if (responsive == 1) {
            $('#menu').slideDown('slow');
            $('#overlay-menu-responsive').fadeIn('fast');
            //$('#menu').addClass('toggle-active');
            //$('#menu').removeClass('toggle-inactive');
            responsive = 2;
        } else if (responsive == 2) {
            $('#menu').slideUp('slow');
            $('#overlay-menu-responsive').fadeOut('fast');
            //$('#menu').addClass('toggle-inactive');
            //$('#menu').removeClass('toggle-active');
            setTimeout(function () {
                $('#menu').removeAttr("style");
            }, 800);
            responsive = 1;
        }
    });

    $('.factcheck').click(function () {

        if ($('#factchecksi').prop('checked')) {
            $(".facsame").prop('disabled', true);
        } else if ($('#factcheckno').prop('checked')) {
            $(".facsame").prop('disabled', false);
        }
    });




    $('.tipo-cliente').click(function () {

        if ($('#ped-fact').prop('checked')) {
            $(".nombre-alta, .cliente-pedimento").slideUp('fast');
        } else if ($('#fact').prop('checked')) {
            $(".nombre-alta, .cliente-pedimento").slideDown('fast');
        } else if ($('#ped').prop('checked')) {
            $(".nombre-alta, .cliente-pedimento").slideDown('fast');
        }


    });

    $('#factcheckno1').click(function () {
        //$("#in6Tab, #in7Tab, #in8Tab").slideUp('fast');
        $("#ftpdatos").slideUp('fast');
        
    });
    
    $('#factchecksi1').click(function () {
        //$("#in6Tab, #in7Tab, #in8Tab").slideDown('fast');
        $("#ftpdatos").slideDown('fast');
    });

    $('.ans1').click(function () {

        if ($('#ans1checksi').prop('checked')) {
            $('.selec-a1').css({ 'visibility': 'visible', 'opacity': '1' })
        } else if ($('#ans1checkno').prop('checked')) {
            $('.selec-a1').css({ 'visibility': 'hidden', 'opacity': '0' })
        }

    });

    $('.ans2').click(function () {

        if ($('#ans2checksi').prop('checked')) {
            $('.selec-a2').css({ 'visibility': 'visible', 'opacity': '1' })
        } else if ($('#ans2checkno').prop('checked')) {
            $('.selec-a2').css({ 'visibility': 'hidden', 'opacity': '0' })
        }

    });

    $('.ans9').click(function () {

        if ($('#ans9checksi').prop('checked')) {
            $('.selec-a9').css({ 'visibility': 'visible', 'opacity': '1' })
        } else if ($('#ans9checkno').prop('checked')) {
            $('.selec-a9').css({ 'visibility': 'hidden', 'opacity': '0' })
        }

    });


    //$('.fa-cloud-upload-alt').click(function () {

    //    $('#cargar').fadeIn('fast');
    //    $('.popupoverlay').fadeIn('fast');

    //});

    $('.carta').click(function () {

        $('#capturaCarta').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');

    });


    $('.mot1').click(function () {

        if ($('#mot1si').prop('checked')) {
            $('.motivo20').fadeIn('fast')
            $('#motivo1').fadeOut('fast')
        } else if ($('#mot1no').prop('checked')) {
            $('.motivo20').fadeOut('fast')
            $('#motivo1').fadeIn('fast')
        }

    });

    $('.mot2').click(function () {

        if ($('#mot2si').prop('checked')) {
            $('.motivo2').fadeIn('fast')
            $('#motivo2').fadeOut('fast')
        } else if ($('#mot2no').prop('checked')) {
            $('.motivo2').fadeOut('fast')
            $('#motivo2').fadeIn('fast')
        }

    });

    $('.entrega').click(function () {

        if ($('#entregasi').prop('checked')) {
            $('#entrega').slideDown('fast')
        } else if ($('#entregano').prop('checked')) {
            $('#entrega').slideUp('fast')
        }

    });

    $('.fondo').click(function () {

        if ($('#factchecksi6').prop('checked')) {
            $('#monto').prop('disabled', false);
        } else if ($('#factcheckno6').prop('checked')) {
            $('#monto').prop('disabled', true);
        }

    });

    $('.financiamiento').click(function () {

        if ($('#factchecksi7').prop('checked')) {
            $('#fincheck').slideDown('fast')
        } else if ($('#factcheckno7').prop('checked')) {
            $('#fincheck').slideUp('fast')
        }

    });


    $('#btn-datos-inicio').click(function () {

        if (document.getElementById('in-id').value == "") {
            $('#in-id').addClass('falta');
            $('#id-req').fadeIn('fast');
        } else if (document.getElementById('in-name').value == "") {
            $('#in-name').addClass('falta');
            $('#name-req').fadeIn('fast');
        } else {

            $('#datos-inicio').fadeOut('fast');
            $('.popupoverlay.captura').fadeOut('fast');

            document.getElementById('idprecliente').innerHTML = document.getElementById('in-id').value;
            document.getElementById('namecliente').innerHTML = document.getElementById('in-name').value;
        }

    });

    $('#revalidacion, #revalidacion2, #revalidacion3').click(function () {

        $('#popup-confirm').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('#popup-confirm .texttarea').fadeIn('fast');
        $('#popup-confirm #obs').fadeIn('fast');
        document.getElementById('mensaje').innerHTML = ""

    });

    $('#aprobar, #aprobar2, #aprobar3').click(function () {

        $('#popup-confirm .texttarea').fadeOut('fast');
        $('#popup-confirm #obs').fadeOut('fast');
        $('#popup-confirm').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        document.getElementById('mensaje').innerHTML = ""

    });

    $('#rechazar, #rechazar2, #rechazar3').click(function () {

        $('#popup-confirm #obs').fadeOut('fast');
        $('#popup-confirm .texttarea').fadeOut('fast');
        document.getElementById('mensaje').innerHTML = "¿Desea rechazar el trámite del cliente?"
        $('#popup-confirm').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');

    });

    $('#inactivar').click(function () {

        $('#popup-confirm').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');

    });


    $('#solicitud-cliente, #proc-ope').click(function () {

        $('#popup-confirm').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');

    });
    /*$('#proc-ope').click(function () {  
   
        $('#popup-confirm').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('#idpre').fadeIn('fast');
        $('#razon').fadeOut('fast');

    }); */


    

    $('#btnCerrarVisualizaDocumentos').click(function () {
        $('#popupVisualizaDocumentos').fadeOut('fast');
        $('.popupoverlay').fadeOut('fast');
    });


    $('.ver-doc').click(function () {
        $('#ver-documento').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc2').click(function () {
        $('#ver-documento2').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc3').click(function () {
        $('#ver-documento3').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc4').click(function () {
        $('#ver-documento4').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc5').click(function () {
        $('#ver-documento5').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc6').click(function () {
        $('#ver-documento6').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc7').click(function () {
        $('#ver-documento7').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc8').click(function () {
        $('#ver-documento8').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc9').click(function () {
        $('#ver-documento9').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.ver-doc10').click(function () {
        $('#ver-documento10').fadeIn('fast');
        $('#popupoverlay').fadeIn('fast');
        $('.popup').fadeOut('fast');
    });
    $('.close-doc').click(function () {
        $('#ver-documento').fadeOut('fast');
        $('#ver-documento2').fadeOut('fast');
        $('#ver-documento3').fadeOut('fast');
        $('#ver-documento4').fadeOut('fast');
        $('#ver-documento5').fadeOut('fast');
        $('#ver-documento6').fadeOut('fast');
        $('#ver-documento7').fadeOut('fast');
        $('#ver-documento8').fadeOut('fast');
        $('#ver-documento9').fadeOut('fast');
        $('#ver-documento10').fadeOut('fast');
        $('#popupoverlay').fadeOut('fast');
    });

    $('.close-documento').click(function () {
        $('#verdocumentos').fadeOut('fast');
        $('#popupVisualizaDocumentos').fadeIn('fast');
    });

    $('#terminar2-1').click(function () {

        $('.popupoverlay').fadeIn('fast');
        $('#popup-confirma').fadeIn('fast');

        $('#popup-confirma .icon i').addClass('fas fa-exclamation-circle');
        document.getElementById('mensaje-confirma').innerHTML = "¿Confirma que la información capturada por el cliente coincide con la documentación proporcionada?";

    });

    $('#botonActivarCliente').click(function () {
        $('.popupoverlay').fadeIn('fast');
        $('#popupActivarCliente').fadeIn('fast');
        $('#popupActivarCliente .icon i').addClass('fas fa-exclamation-circle');
        document.getElementById('mensajeActivarCliente').innerHTML = "¿Confirma que desea activar el cliente?";
    });
    $('#botonInactivarCliente').click(function () {
        $('.popupoverlay').fadeIn('fast');
        $('#popupInactivarCliente').fadeIn('fast');
        $('#popupInactivarCliente .icon i').addClass('fas fa-exclamation-circle');
        document.getElementById('mensajeInactivarCliente').innerHTML = "¿Confirma que desea inactivar el cliente?";
    });

    $('.terminar2-2').click(function () {

        $('.popupoverlay').fadeIn('fast');
        $('#popup').fadeIn('fast');

        $('#popup .icon i').addClass('far fa-check-circle');
        document.getElementById('mensaje').innerHTML = "Se guardó correctamente la información.";
    });



    $('#si').click(function () {

        $('.menu-sections .btn-operaciones').removeClass('active');
        /*$('#paso1').addClass('visited');
        $('#icon-t1-1').removeClass('fa-list-alt');
        $('#icon-t1-1').addClass('fa-check-circle');*/

        $('#paso2').addClass('active');
        $('#paso2').prop('disabled', false);

        $('#cont-paso1').fadeOut('fast');
        $('#cont-paso2').fadeIn('fast');

    });

    $('#no').click(function () {

        $('#popup-confirma').fadeOut('fast');
        $('#popupoverlay').fadeOut('fast');
        $('.correcdoc').fadeIn('fast');

    });

    $('.acept2-2').click(function () {

        $('.menu-sections .btn-operaciones').removeClass('active');
        /*$('#paso2').addClass('visited');
        $('#icon-t1-2').removeClass('fa-table');
        $('#icon-t1-2').addClass('fa-check-circle');*/

        $('#paso3').addClass('active');
        $('#paso3').prop('disabled', false);

        $('#cont-paso2').fadeOut('fast');
        $('#cont-paso3').fadeIn('fast');

        $('.acept2-2').fadeOut('fast');
        $('.acept2-3').fadeIn('fast');

    });

    $('.acept2-3').click(function () {

        $('.menu-sections .btn-operaciones').removeClass('active');
        /*$('#paso3').addClass('visited');
        $('#icon-t1-3').removeClass('fa-file-alt');
        $('#icon-t1-3').addClass('fa-check-circle');*/

        $('#paso4').addClass('active');
        $('#paso4').prop('disabled', false);

        $('#cont-paso3').fadeOut('fast');
        $('#cont-paso4').fadeIn('fast');

        $('.acept2-3').fadeOut('fast');
        $('.acept2-4').fadeIn('fast');

    });

    /*$('.acept2-4').click(function () { 

      location.reload();
  
    });*/

    /*

      Añadir elementos a tablas

    */

    filas = 0;
    filas2 = 0;
    filas3 = 0;
    lineas = 0;
    lineas2 = 0;
    lineas3 = 0;

    $('#add-tr').click(function () {

        var area = document.getElementById('area-in').value;
        var nombre = document.getElementById('nombre-in').value;
        var email = document.getElementById('email-in').value;
        var telefono = document.getElementById('telefono-in').value;
        //var puesto = document.getElementById('puesto-in').value;
        var puesto = '';

        if ((area == "") || (nombre == "") || (email == "") || (telefono == "") || (puesto == "")) {
            //$('.popupoverlay').fadeIn('fast');
            //$('#popup-error').fadeIn('fast');

            //$('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            //document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos de la fila.";
        } else {
            filas++;
            lineas++

            //    var midiv = document.createElement("tr");
            //    midiv.setAttribute("class", "table-rows");
            //    midiv.setAttribute("id", "fila" + filas);
            //    midiv.innerHTML = '<td><input type="text" class="form-control" value="' + area + '" disabled></td>\
            //<td><input type="text" class="form-control" value="'+ nombre + '" disabled></td>\
            //<td><input type="email" class="form-control" value="'+ email + '" disabled></td>\
            //<td><input type="tel" class="form-control" value="'+ telefono + '" disabled></td>\
            //<td><input type="text" class="form-control" value="'+ puesto + '" disabled></td>\
            //<td><i id="save'+ filas + '" class="fas fa-save btn-save boxtool" onclick="saveFilas(' + filas + ')">\
            //    <div class="tooltip">Guardar</div></i><i id="edit'+ filas + '" class="fas fa-pencil-alt boxtool" onclick="editFilas(' + filas + ')">\
            //    <div class="tooltip">Editar</div></i><i class="fas fa-trash-alt boxtool" onclick="removeFilas('+ filas + ')">\
            //    <div class="tooltip">Borrar</div></i>\
            //</td>'

            //    document.getElementById("numbers1").appendChild(midiv);

            document.getElementById('area-in').value = ""
            document.getElementById('nombre-in').value = ""
            document.getElementById('email-in').value = ""
            document.getElementById('telefono-in').value = ""
            document.getElementById('puesto-in').value = ""
        }



    });

    $('#add-tr2').click(function () {

        var banco = document.getElementById('banco-in').value;
        var cuenta = document.getElementById('cuenta-in').value;
        var identificador = document.getElementById('identificador-in').value;
        var patentes = document.getElementById('patentes-in').value;
        var aduana = document.getElementById('aduana-in').value;

        if ((banco == "") || (cuenta == "") || (identificador == "") || (patentes == "") || (aduana == "")) {
            console.log("agregar banco js");
        } else {
            //    filas2++
            //    lineas2++


            //    var midiv = document.createElement("tr");
            //    midiv.setAttribute("class", "table-rows");
            //    midiv.setAttribute("id", "fila" + filas2);
            //    midiv.innerHTML = '<td><input type="text" class="form-control" value="' + banco + '" disabled></td>\
            //<td><input type="text" class="form-control" value="'+ cuenta + '" disabled></td>\
            //<td><input type="text" class="form-control" value="'+ identificador + '" disabled></td>\
            //<td><input type="text" class="form-control" value="'+ patentes + '" disabled></td>\
            //<td><input type="text" class="form-control" value="'+ aduana + '" disabled></td>\
            //<td><i id="save'+ filas2 + '" class="fas fa-save btn-save boxtool" onclick="saveFilas(' + filas2 + ')">\
            //    <div class="tooltip">Guardar</div></i><i id="edit'+ filas2 + '" class="fas fa-pencil-alt boxtool" onclick="editFilas(' + filas2 + ')">\
            //    <div class="tooltip">Editar</div></i><i class="fas fa-trash-alt boxtool" onclick="removeFilas('+ filas2 + ')">\
            //    <div class="tooltip">Borrar</div></i>\
            //</td>'

            //    document.getElementById("numbers2").appendChild(midiv);

            document.getElementById('banco-in').value = ""
            document.getElementById('cuenta-in').value = ""
            document.getElementById('identificador-in').value = ""
            document.getElementById('patentes-in').value = ""
            document.getElementById('aduana-in').value = ""
        }



    });

    //$('.add-trPO').click(function () {
      
    //    var id = $(this).attr("id").split[1]; 
    //    var banco = document.getElementById('nombre-' + id).value;
    //    var cuenta = document.getElementById('email-' + id).value;
    //    var identificador = document.getElementById('telefono-' + id).value;
    //    var patentes = document.getElementById('puesto-' + id).value;

    //    document.getElementById('nombre-' + id).value = "";
    //    document.getElementById('email-' + id).value = "";
    //    document.getElementById('telefono-' + id).value = "";
    //    document.getElementById('puesto-' + id).value = "";
    //    console.log("Si hace algo");
        
    //});

    $('#add-tr3').click(function () {

        var nombre = document.getElementById('nombre_in').value;
        var puesto = document.getElementById('puesto_in').value;
        var telefono = document.getElementById('telefono_in').value;
        var correo = document.getElementById('correo_in').value;
        var admon = document.getElementById('admon_in').value;
        var oper = document.getElementById('oper_in').value;

        if ((nombre == "") || (puesto == "") || (telefono == "") || (correo == "") || (admon == "") || (oper == "")) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos de la fila.";
        } else {
            filas3++
            lineas3++


            var midiv = document.createElement("tr");
            midiv.setAttribute("class", "table-rows");
            midiv.setAttribute("id", "fila" + filas3);
            midiv.innerHTML = '<td><input type="text" class="form-control" value="' + nombre + '" disabled></td>\
        <td><input type="text" class="form-control" value="'+ puesto + '" disabled></td>\
        <td><input type="text" class="form-control" value="'+ telefono + '" disabled></td>\
        <td><input type="text" class="form-control" value="'+ correo + '" disabled></td>\
        <td><input type="text" class="form-control" value="'+ admon + '" disabled></td>\
        <td><input type="text" class="form-control" value="'+ oper + '" disabled></td>\
        <td><i id="save'+ filas3 + '" class="fas fa-save btn-save boxtool" onclick="saveFilas(' + filas3 + ')">\
            <div class="tooltip">Guardar</div></i><i id="edit'+ filas3 + '" class="fas fa-pencil-alt boxtool" onclick="editFilas(' + filas3 + ')">\
            <div class="tooltip">Editar</div></i><i class="fas fa-trash-alt boxtool" onclick="removeFilas('+ filas3 + ')">\
            <div class="tooltip">Borrar</div></i>\
        </td>'

            document.getElementById("numbers3").appendChild(midiv);

            document.getElementById('nombre_in').value = ""
            document.getElementById('puesto_in').value = ""
            document.getElementById('telefono_in').value = ""
            document.getElementById('correo_in').value = ""
            document.getElementById('admon_in').value = ""
            document.getElementById('oper_in').value = ""
        }



    });

    /*

      Botones de guardar

    */


    $('#guardar1').click(function () {

        check = 0;

        for (i = 1; i <= 20; i++) {

            if (document.getElementById('in' + i).value == '') {

                $('#in' + i).addClass('falta');
                $('#cont-paso1').scrollTop(0);
                $('#req' + i).fadeIn('fast');

                check++

            } else {
                $('#in' + i).removeClass('falta');

            }
        };

        if (lineas == 0) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
            $('#req-table1').fadeIn('fast');
        } else {
            $('#req-table1').fadeOut('fast');
        }

        if (lineas2 == 0) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
            $('#req-table2').fadeIn('fast');
        } else {
            $('#req-table1').fadeOut('fast');
        }

        if ((check > 0)) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
            $('#cont-paso1').scrollTop(0);
        } else {
            $('.popupoverlay').fadeIn('fast');
            $('#popup').fadeIn('fast');

            $('#popup .icon i').addClass('far fa-check-circle');
            document.getElementById('mensaje').innerHTML = "Se guardó correctamente la información.";
        };

    });

    $('.acept').click(function () {
        console.log("hola");
        $('.menu-sections .btn-operaciones').removeClass('active');
        $('#paso1').addClass('visited');
        $('#icon-t1-1').removeClass('fa-list-alt');
        $('#icon-t1-1').addClass('fa-check-circle');

        $('#paso2').addClass('active');
        $('#paso2').prop('disabled', false);

        $('#cont-paso1').fadeOut('fast');
        $('#cont-paso2').fadeIn('fast');
        $('.acept').fadeOut('fast');

    });

    $('.aceptarDatosCliente').click(function () {
        console.log("aceptarDatosCliente");
        $('.menu-sections .btn-operaciones').removeClass('active');
        $('#paso1').addClass('visited');
        $('#icon-t1-1').removeClass('fa-list-alt');
        $('#icon-t1-1').addClass('fa-check-circle');

        $('#paso2').addClass('active');
        $('#paso2').prop('disabled', false);

        $('#cont-paso1').fadeOut('fast');
        $('#cont-paso2').fadeIn('fast');

        $('.popupoverlay').fadeOut('fast');
        $('#popupDatosCliente').fadeOut('fast');
    });

    $('.aceptarDatosAdicionales').click(function () {
        console.log("aceptarDatosAdicionales");
        $('.menu-sections .btn-operaciones').removeClass('active');
        $('#paso2').addClass('visited');
        $('#icon-t1-1').removeClass('fa-list-alt');
        $('#icon-t1-1').addClass('fa-check-circle');

        $('#paso3').addClass('active');
        $('#paso3').prop('disabled', false);

        $('#cont-paso2').fadeOut('fast');
        $('#cont-paso3').fadeIn('fast');

        $('.popupoverlay').fadeOut('fast');
        $('#popupDatosAdicionales').fadeOut('fast');
    });

    $('.aceptarDatosTabuladores').click(function () {
        console.log("aceptarDatosTabuladores");
        $('.popupoverlay').fadeOut('fast');
        $('#mensajeDatosTabuladores').fadeOut('fast');
        $('#popupDatosTabuladores').fadeOut('fast');
        window.location.reload(true);
    });

    $('.aceptarSO').click(function () {
        console.log("aceptarSO");
        $('.popupoverlay').fadeOut('fast');
        $('#mensajeSO').fadeOut('fast');
        $('#popupSO').fadeOut('fast');
        window.location.reload(true);
    });

    $('.AprobadoSI').click(function () {
        console.log("AprobadoSI");
        $('.popupoverlay').fadeOut('fast');
        $('#mensajeAprobadoSI').fadeOut('fast');
        $('#popupAprobadoSI').fadeOut('fast');
        window.location.reload(true);
    });

    $('.aceptarOKAprobacion').click(function () {
        console.log("aceptarOKAprobacion");
        $('.popupoverlay').fadeOut('fast');
        $('#mensajeOKAprobacion').fadeOut('fast');
        $('#popupOKAprobacion').fadeOut('fast');
        window.location.reload(true);
    });

    $('.aceptarPaso1').click(function () {
        $('.popupoverlay').fadeOut('fast');
        $('#mensajePaso1').fadeOut('fast');
        $('#popupPaso1').fadeOut('fast');
    });

    $('.aceptarNoAprobadoRefresh').click(function () {
        $('.popupoverlay').fadeOut('fast');
        $('#mensajeNoAprobadoRefresh').fadeOut('fast');
        $('#popupNoAprobadoRefresh').fadeOut('fast');
        window.location.reload(true);
    });

    $('.aceptarFinOperaciones').click(function () {
        $('.popupoverlay').fadeOut('fast');
        $('#mensajeFinOperaciones').fadeOut('fast');
        $('#popupFinOperaciones').fadeOut('fast');
        window.location.reload(true);
    });

    $('.aceptarCuestionesSeguridad').click(function () {
        console.log("aceptarCuestionesSeguridad");
        $('.menu-sections .btn-operaciones').removeClass('active');
        $('#paso3').addClass('visited');
        $('#icon-t1-1').removeClass('fa-list-alt');
        $('#icon-t1-1').addClass('fa-check-circle');

        $('#paso4').addClass('active');
        $('#paso4').prop('disabled', false);

        $('#cont-paso3').fadeOut('fast');
        $('#cont-paso4').fadeIn('fast');

        $('.popupoverlay').fadeOut('fast');
        $('#popupCuestionesSeguridad').fadeOut('fast');
    });

    $('.aceptFin').click(function () {
        console.log("aceptFin");
        /*
        $('.menu-sections .btn-operaciones').removeClass('active');
        $('#paso1').addClass('visited');
        $('#icon-t1-1').removeClass('fa-list-alt');
        $('#icon-t1-1').addClass('fa-check-circle');
        */
        /*
        $('#paso2').addClass('active');
        $('#paso2').prop('disabled', false);

        $('#cont-paso1').fadeOut('fast');
        $('#cont-paso2').fadeIn('fast');
        $('.acept').fadeOut('fast');
        */
        $('#popupFin').fadeOut('fast');
        $('.popupoverlay').fadeOut('fast');
    });

    $('.aceptPaso1').click(function () {
        $('#popupPaso1').fadeOut('fast');
        $('.popupoverlay').fadeOut('fast');
    });

    $('#guardar2').click(function () {

        $('.acept2').fadeIn('fast');

        check = 0;

        for (i = 21; i <= 28; i++) {

            if (document.getElementById('in' + i).value == '') {

                $('#in' + i).addClass('falta');
                $('#cont-paso2').scrollTop(0);
                $('#req' + i).fadeIn('fast');

                check++

            } else {
                $('#in' + i).removeClass('falta');

            }
        };

        if (lineas3 == 0) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
            $('#req-table3').fadeIn('fast');
        } else {
            $('#req-table3').fadeOut('fast');
        }


        if ((check > 0)) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-aviso').innerHTML = "Se deben llenar todos los campos";
            $('#cont-paso2').scrollTop(0);
        } else {
            $('.popupoverlay').fadeIn('fast');
            $('#popup').fadeIn('fast');

            $('#popup .icon i').addClass('far fa-check-circle');
            document.getElementById('mensaje').innerHTML = "Se guardó correctamente la información.";
        };

    });

    $('.acept2').click(function () {

        $('.menu-sections .btn-operaciones').removeClass('active');
        $('#paso2').addClass('visited');
        $('#icon-t1-2').removeClass('fas fa-list-ul');
        $('#icon-t1-2').addClass('far fa-check-circle');

        $('#paso3').addClass('active');
        $('#paso3').prop('disabled', false);

        $('#cont-paso2').fadeOut('fast');
        $('#cont-paso3').fadeIn('fast');
        $('.acept2').fadeOut('fast');

    });


    $('#guardar3').click(function () {

        check = 0;
        check2 = 0;

        $('.acept3').fadeIn('fast');

        for (i = 1; i <= 20; i++) {

            if ($('#ans' + i + 'checksi').prop('checked')) {

                if ((i == 1) || (i == 2) || (i == 9)) {
                    if (document.getElementById('select' + i).value == '') {
                        $('#select' + i).css({ 'border-color': 'red' });
                        $('#req' + i).fadeIn('fast');
                        check2++
                    } else {
                        $('#select' + i).css({ 'border-color': '#ccc' });
                        $('#req' + i).fadeOut('fast');
                    }
                }

                if (document.getElementById('name' + i).value == '') {
                    $('#name' + i).css({ 'border-color': 'red' });
                    $('#checksi' + i).css({ 'border-color': '#62a8ea' })
                    $('#checkno' + i).css({ 'border-color': '#62a8ea' })
                    check2++
                } else {
                    $('#checksi' + i).css({ 'border-color': '#62a8ea' })
                    $('#checkno' + i).css({ 'border-color': '#62a8ea' })
                    $('#name' + i).css({ 'border-color': '#ccc' });

                }


            } else if ($('#ans' + i + 'checkno').prop('checked')) {
                $('#checksi' + i).css({ 'border-color': '#62a8ea' })
                $('#checkno' + i).css({ 'border-color': '#62a8ea' })


            } else {
                $('#checksi' + i).css({ 'border-color': 'red' })
                $('#checkno' + i).css({ 'border-color': 'red' })
                $('#cont-paso2').scrollTop(0);

                check++

            }
        };

        if ((check > 0) || (check2 > 0)) {
            $('.popupoverlay').fadeIn('fast');
            $('#popup-error').fadeIn('fast');

            $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            document.getElementById('mensaje-aviso').innerHTML = "Debes responder todas las preguntas";
            $('#cont-paso3').scrollTop(0);
        } else {
            $('.popupoverlay').fadeIn('fast');
            $('#popup').fadeIn('fast');

            $('#popup .icon i').addClass('far fa-check-circle');
            document.getElementById('mensaje').innerHTML = "Se guardó correctamente la información.";
            $('#cont-paso3').scrollTop(0);
        };

    });

    $('.acept3').click(function () {


        $('.menu-sections .btn-operaciones').removeClass('active');
        $('#paso3').addClass('visited');
        $('#icon-t1-3').removeClass('fas fa-lock');
        $('#icon-t1-3').addClass('far fa-check-circle');

        $('#paso4').addClass('active');
        $('#paso4').prop('disabled', false);

        $('#cont-paso1').fadeOut('fast');
        $('#cont-paso2').fadeOut('fast');
        $('#cont-paso3').fadeOut('fast');
        $('#cont-paso4').fadeIn('fast');
        $('.acept3').fadeOut('fast');

    });


    $('#guardar4').click(function () {
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

        /*
        $('.acept4').fadeIn('fast');

        for (i = 1; i <= 32; i++) {

            input = '#in' + i;

            if (input.value == "") {
                input.css({ 'border': '1px solid red' })

            } else {
                $('.popupoverlay').fadeIn('fast');
                $('#popup').fadeIn('fast');

                $('#popup .icon .far').addClass('fa-check-circle');
                document.getElementById('mensaje').innerHTML = "Carga exitosa.";
            }
        }
        */

    });

    $('.acept4').click(function () {

        location.reload();

    });

    $('#btn1, .closeall, .acept, .acept2, .acept3, .btn-aviso').click(function () {

        $('.popupoverlay').fadeOut('fast');
        $('.popup').fadeOut('fast');
        $('.popup-documento').fadeOut('fast');
        $('.popup-terminos').fadeOut('fast');

    });

    $(document).ready(function () {
        setTimeout(function () {

            $('.menujq > ul > li:has(ul)').addClass('desplegable');
            $('.menujq > ul > li > a').click(function () {
                var comprobar = $(this).next();
                $('.menujq li').removeClass('activa');
                $(this).closest('li').addClass('activa');
                if ((comprobar.is('ul')) && (comprobar.is(':visible'))) {
                    $(this).closest('li').removeClass('activa');
                    comprobar.slideUp('normal');
                }
                if ((comprobar.is('ul')) && (!comprobar.is(':visible'))) {
                    $('.menujq ul ul:visible').slideUp('normal');
                    comprobar.slideDown('normal');
                }
            });

        }, 100);


    });

    $(document).ready(function () {
        $('.menujq2 > ul > li:has(ul)').addClass('desplegable');
        $('.menujq2 > ul > li > a').click(function () {
            var comprobar = $(this).next();
            //$('.menujq2 li').removeClass('activa');
            $(this).closest('li').addClass('activa');
            if ((comprobar.is('ul')) && (comprobar.is(':visible'))) {
                $(this).closest('li').removeClass('activa');
                comprobar.slideUp('normal');
            }
            if ((comprobar.is('ul')) && (!comprobar.is(':visible'))) {
                //$('.menujq2 ul ul:visible').slideUp('normal');
                comprobar.slideDown('normal');
            }
        });
    });

    newmail = 0;

    var emails_so = "";

    $("#addmails").keypress(function (e) {

        newmail++;

        var mail = document.getElementById('addmails').value;
        var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;

        //13 es el código de la tecla
        if ((e.which == 13) || (e.which == 8)) {

            if (document.getElementById('addmails').value == "") {

            } else if (regex.test($('#addmails').val().trim())) {
                var correo = document.createElement("div");
                correo.setAttribute("id", "mail" + newmail);
                correo.setAttribute("class", "correo");
                correo.innerHTML = '' + mail + ' <i class="fas fa-trash-alt quitar" onclick="removeMail(' + newmail + ')"></i>';

                document.getElementById("lista-emails").prepend(correo);
                emails_so = emails_so + correo;
                document.getElementById('addmails').value = "";

            } else {
                $('.popupoverlay').fadeIn('fast');
                $('#popup-error').fadeIn('fast');

                $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
                document.getElementById('mensaje-aviso').innerHTML = "No es un correo válido";
            }

        }


    });

});

function cambiarEtiqueta(etiqueta) {
    $("#etiqueta").text(etiqueta);
}

//newtab = 1

function addTab(newtab) {

    newtab++

    var midiv = document.createElement("div");
    midiv.setAttribute("id", "tabulador" + newtab);
    midiv.setAttribute("class", "row no-margin");
    midiv.innerHTML = '<hr><h3 class="subtitle">Tabulador ' + newtab + '  \
        <i id="new-tabulador" class="fas fa-plus boxtool icon-tabulador add" onclick="addTab('+ newtab + ')"><div class="tooltip">Agregar tabulador</div></i>\
        <i class="fas fa-trash-alt boxtool icon-tabulador" onclick="removeTab('+ newtab + ')"><div class="tooltip">Eliminar tabulador</div></i></h3>\
  <div class="row">\
  <div class="col-sm-3">\
    <div class="tag-text">Tipo de operación</div>\
    <div class="form-group">\
      <select class="form-control facsame" name="state" id="TipoOperacionTab' + newtab + '">\
        <option value="">Seleccionar</option>\
        <option value="Especiales">Especiales</option>\
        <option value="Importación">Importación</option>\
        <option value="Exportación">Exportación</option>\
      </select>           \
    </div>\
  </div>\
  <div class="col-sm-3">\
    <div class="tag-text">Aduana</div>\
    <div class="form-group">\
      <select class="form-control facsame" name="state" id="AduanaTab' + newtab + '" data-ng-options="\aduana as aduana.aduana for aduana in catalogoAduanas\" data-ng-model="nuevoTabs.catalogoAduanas.Id_Aduana">\
        <option value="">Seleccionar</option>\
      </select>           \
    </div>\
  </div>  \
  <div class="col-sm-3">\
    <div class="tag-text">Clave pedimento</div>\
    <div class="form-group">\
      <select class="form-control facsame" name="state" id="ClavePedimentoTab' + newtab + '" data-ng-options="descripcion as descripcion.descripcion for descripcion in catalogoClavePedimento data-ng-model="catalogoClavePedimento.clave">\
        <option value="">Seleccionar</option>\
      </select>           \
    </div>\
  </div>  \
  <div class="col-sm-3">\
    <div class="tag-text">Moneda</div>\
    <div class="form-group">\
      <select class="form-control facsame" name="state" id="MonedaTab' + newtab + '">\
        <option value="">Seleccionar</option>\
        <option value="MonedaNacional">Moneda Nacional</option>\
        <option value="Dolares">Dolares</option>\
      </select>           \
    </div>\
  </div>  \
  </div>\
  <div class="row">\
  <div class="col-sm-3">\
    <div class="tag-text">Facturación</div>\
    <div class="form-group">\
      <select class="form-control facsame" name="state" id="FacturacionTab' + newtab + '">\
        <option value="">Seleccionar</option>\
        <option value="Porpedimento">Por pedimento</option>\
        <option value="Consolidada">Consolidada</option>\
      </select>           \
    </div>\
  </div>  \
  <div class="col-sm-4">\
    <div class="form-group">\
      <div class="tag-text">Días libres en almacén Laredo</div>\
      <input type="text" class="form-control datos" placeholder="" id="DiasLibresTab1' + newtab + '">\
    </div>\
  </div>  \
  <div class="col-sm-5"></div>\
  </div>\
  <div class="row">\
  <div class="col-sm-12">\
    <div class="table-responsive">\
          <table class="tablesorter table table-striped table-bordered table-hover">\
              <thead class="table-rows star">\
                  <tr>\
                      <th>Empresa <i class="fa fa-angle-down"></i></th>\
                      <th>Concepto facturación <i class="fa fa-angle-down"></i></th>\
                      <th>Concepto autofacturación <i class="fa fa-angle-down"></i></th>\
                      <th>Tarifa venta <i class="fa fa-angle-down"></i></th>\
                      <th>Tarifa de compra <i class="fa fa-angle-down"></i></th>\
                      <th></th>\
                  </tr>\
              </thead>\
              <tbody id="numbers">\
                  <tr class="table-rows">\
                      <td>\
                          <select class="form-control" name="state">\
                <option value="">--</option>\
                <option value="WY">2</option>\
                <option value="WY">3</option>\
                <option value="WY">4</option>\
                <option value="WY">5</option>\
                <option value="WY">6</option>\
              </select>\
            </td>\
            <td>\
                          <select class="form-control" name="state">\
                <option value="">--</option>\
                <option value="WY">2</option>\
                <option value="WY">3</option>\
                <option value="WY">4</option>\
                <option value="WY">5</option>\
                <option value="WY">6</option>\
              </select>\
            </td>\
                      <td>\
                          <select class="form-control" name="state">\
                <option value="">--</option>\
                <option value="WY">2</option>\
                <option value="WY">3</option>\
                <option value="WY">4</option>\
                <option value="WY">5</option>\
                <option value="WY">6</option>\
              </select>\
            </td>\
                      <td>\
                        <div class="col-sm-6 no-padding">\
                        <input type="number" class="form-control" placeholder="">\
                        </div>\
                        <div class="col-sm-6">\
                        <select class="form-control" name="state">\
                <option value="USD">USD</option>\
                <option value="MXN">MXN</option>\
                <option value="EUR">EUR</option>\
              </select>\
              </div>\
                      </td>\
                      <td>\
                        <div class="col-sm-6 no-padding">\
                        <input type="number" class="form-control" placeholder="">\
                        </div>\
                        <div class="col-sm-6">\
                        <select class="form-control" name="state">\
                <option value="USD">USD</option>\
                <option value="MXN">MXN</option>\
                <option value="EUR">EUR</option>\
              </select>\
              </div>\
            </td>\
                      <td>\
                          <i class="fas fa-plus boxtool"><div class="tooltip">Agregar</div></i>\
                      </td>\
                  </tr>\
                  <tr class="table-rows last">\
                      <td>xxxxx</td>\
                      <td>xxxxx</td>\
                      <td>xxxxx</td>\
                      <td>xxxxx</td>\
                      <td>xxxxxx</td>\
                      <td>\
                          <i class="fas fa-pencil-alt boxtool"><div class="tooltip">Editar</div></i>\
                          <i class="fas fa-trash-alt boxtool"><div class="tooltip">Borrar</div></i>\
                      </td>\
                  </tr>\
               </tbody>\
          </table>\
      </div>\
  </div>\
  </div>'

    document.getElementById("news-tabuladores").appendChild(midiv);


    var posicion = getElementById('tabulador' + newtab)
    $('#cont-paso2').scrollTo(posicion);

};

function showPasoCaptura(num) {
    paso = '#cont-pasot' + num;
    $('.cont-datos').fadeOut('fast');
    $(paso).fadeIn('fast');
    if (num === 4) {
        $("#cont-paso4").css("display", "");
    }
    else {
        $("#cont-paso4").css("display", "none");
    }
}

function showPaso(num) {
    paso = '#cont-paso' + num;

    $('.cont-datos').fadeOut('fast');
    $(paso).fadeIn('fast');
}

function showPasoAlta(num) {
    paso = '#cont-paso' + num;

    $('.cont-datos').fadeOut('fast');
    $(paso).fadeIn('fast');
}

function removeFilas(num) {

    var paquete = document.getElementById("numbers" + num);
    var object = document.getElementById("fila" + num)

    paquete = object.parentNode;
    paquete.removeChild(object);
}
function editFilas(num) {
    var paquete = document.getElementById("numbers" + num);
    var object = document.getElementById("fila" + num);
    var btnedit = document.getElementById("edit" + num);
    var btnsave = document.getElementById("save" + num);

    $('#fila' + num + ' .form-control').prop('disabled', false);
    $(btnedit).fadeOut('fast');
    $(btnsave).fadeIn('fast');

}
function saveFilas(num) {
    var object = document.getElementById("fila" + num);
    var btnedit = document.getElementById("edit" + num);
    var btnsave = document.getElementById("save" + num);

    $('#fila' + num + ' .form-control').prop('disabled', true);
    $(btnsave).fadeOut('fast');
    $(btnedit).fadeIn('fast');
}


function EditFilasPO(num, tabindice) {
    var object =  document.getElementById("po" + tabindice + "fila" + num);
    var btnedit = document.getElementById("po" + tabindice + "edit" + num);
    var btnsave = document.getElementById("po" + tabindice + "save" + num);

    $('#po' + tabindice +'fila' + num + ' .form-control').prop('disabled', false);
    $(btnedit).fadeOut('fast');
    $(btnsave).fadeIn('fast');

}
function saveFilasPO(num, tabindice) {
    var object = document.getElementById("po" + tabindice + "fila" + num);
    var btnedit = document.getElementById("po" + tabindice + "edit" + num);
    var btnsave = document.getElementById("po" + tabindice + "save" + num);

    $('#po' + tabindice + 'fila' + num + ' .form-control').prop('disabled', true);
    $(btnsave).fadeOut('fast');
    $(btnedit).fadeIn('fast');
}





function removeTab(num) {

    var paquete = document.getElementById("news-tabuladores");
    var object = document.getElementById("tabulador" + num)

    paquete = object.parentNode;
    paquete.removeChild(object);
}
function removeMail(num) {

    var paquete = document.getElementById("lista-emails");
    var object = document.getElementById("mail" + num)

    paquete = object.parentNode;
    paquete.removeChild(object);
}


