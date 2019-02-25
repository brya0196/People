(function () {
    'use strict';

    angular.module('app').component('login', {
        templateUrl: '/angular/app/login/login.html',
        controller: LoginController,
        controllerAs: 'vm'
    });

    LoginController.$inject = [];

    function LoginController() {
        var vm = this;
    }

})();