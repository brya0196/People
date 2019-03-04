(function () {
    'use strict';

    angular.module('app').component('navBar', {
        templateUrl: '/angular/app/navbar/navbar.html',
        controller: NavbarController,
        controllerAs: 'vm'
    });

    NavbarController.$inject = ['$log', 'AuthenticationFactory'];

    function NavbarController($log, AuthenticationFactory) {
        var vm = this;

        vm.user = {};

        vm.$onInit = onInit;
        vm.logout = logout;

        function onInit() {
            vm.user = AuthenticationFactory.getUserInfo();
            if (AuthenticationFactory.authenticated) window.location.href = "/";
            
            $log.info(vm.user);
        }

        function logout() {
            $log.info("logout");
            if (AuthenticationFactory.logout()) window.location.href = "/";
        }
    }

})();