(function () {
    'use strict';

    angular
        .module('app')
        .service('$layoutServiceLogin', layout);

    layout.$inject = ['$http'];

    function layout($http) {
        var baseUrl = "/Login/";

        this.validarLogin = function (parametro) {
            return $http({
                method: "post",
                data: parametro,
                url: baseUrl + "ValidarLogin",
            });
        }
    }

})();