(function () {
    'use strict';

    angular.module('app').component('login', {
        templateUrl: '/angular/app/login/login.html',
        controller: LoginController,
        controllerAs: 'vm'
    });

    LoginController.$inject = ['$log', 'AuthenticationFactory'];

    function LoginController($log, AuthenticationFactory) {
        var vm = this;

        vm.user = {};

        vm.login = login;

        function login() {
            AuthenticationFactory.login(vm.user)
                .then(function (response) {
                    $log.info(response);
                    window.location.href = "/dashboard";
                })
                .catch(function (error) {
                    $log.info(error);

                    alertify.alert("Error", "Usuario o Contraseña incorrectos").set({ 'movable': false });
                });
        }
    }

})();