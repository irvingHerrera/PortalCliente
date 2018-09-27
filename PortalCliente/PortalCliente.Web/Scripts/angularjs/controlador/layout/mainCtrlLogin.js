(function () {
    'use strict';

    angular
        .module('app')
        .controller('mainCtrlLogin', main);

    main.$inject = ['$scope', '$layoutServiceLogin'];

    function main($scope, $layoutServiceLogin) {
        var vmm = $scope;
        vmm.login = {};

        vmm.ValidarLogin = function () {

            console.log("entrando a ValidarLogin");

            angular.post("/Login/ValidarLogin", vmm.login);

            //$layoutServiceLogin.validarLogin(vmm.login).then(function (data) {
            //    var resultado = data.data.resultado;
            //    console.log("resultado", resultado);
            //    if (resultado === true) {
            //        console.log("Login correcto...");
            //        //$('.popupoverlay').fadeIn('fast');
            //        //$('#popup').fadeIn('fast');
            //        //$('#popup .icon i').addClass('far fa-check-circle');
            //        //document.getElementById('mensaje').innerHTML = "Login correcto.";
            //        //$('#cont-paso3').scrollTop(0);
            //        // Abrir pantalla principal de usuario
            //        // Obtener datos de usuario
            //    }
            //    else {
            //        console.log("Login incorrecto...");
            //        $('.popupoverlay').fadeIn('fast');
            //        $('#popup-error').fadeIn('fast');
            //        $('#popup-error .icon i').addClass('fas fa-exclamation-circle');
            //        document.getElementById('mensaje-aviso').innerHTML = "Usuario y/o contraseña erróneos, verifica.";
            //        $('#cont-paso3').scrollTop(0);
            //    }
            //}, function (error) {
            //    // Mostrar mensaje de intentar nuevamente
            //    console.log("error en ValidarLogin", error);
            //});
            //console.log("saliendo a ValidarLogin");
        }
    }

})();