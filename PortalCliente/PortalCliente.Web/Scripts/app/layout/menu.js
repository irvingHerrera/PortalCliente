
(function ($) {
    $(document).ready(function () {

        $('.cssmenu li.has-sub>a').on('click', function () {
            menuAcordion(this);
        });

        $('.cssmenu>ul>li.has-sub>a').append('<span class="holder"></span>');

        if (window.location.pathname === '/') {
            $($(".cssmenu a")[0]).attr("class", "normal active");
        } else {
            $(".cssmenu a").each(function (index, element) {
                if (!$(element).hasClass('anormal')) {
                    var pathNavegador = window.location.pathname.toLowerCase();

                    pathNavegador = pathNavegador.indexOf('index') > -1 ? pathNavegador.replace("/index", "") : pathNavegador;
                    if ($(element).attr("href").toLowerCase() === pathNavegador) {
                        $(element).attr("class", "normal active");
                    } else {
                        $(element).attr("class", "normal");
                    }
                }

            });
        }

        $("#opensub a").each(function (index, element) {
            if ($(element).attr("href") === window.location.pathname) {
                $(element).attr("class", "normali active");
                menuAcordion($('.cssmenu li.has-sub>a')[0]);
            } else {
                $(element).attr("class", "normali");
            }
        });

    });

    function menuAcordion(elementOrigin) {
        $(elementOrigin).removeAttr('href');
        var element = $(elementOrigin).parent('li');
        if (element.hasClass('open')) {
            element.removeClass('open');
            $(elementOrigin).removeClass('active');
            element.find('li').removeClass('open');
            element.find('ul').slideUp();
        }
        else {
            element.addClass('open');
            element.children('ul').slideDown();
            element.siblings('li').children('ul').slideUp();
            element.siblings('li').removeClass('open');
            element.siblings('li').find('li').removeClass('open');
            element.siblings('li').find('ul').slideUp();
            $(elementOrigin).removeClass('active');
        }
    }

})(jQuery);
