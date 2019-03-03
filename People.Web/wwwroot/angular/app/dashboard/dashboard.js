(function () {
    'use strict';

    angular.module('core').component('dashboard', {
        templateUrl: '/angular/app/dashboard.html',
        controller: DashboardController,
        controllerAs: 'vm'
    });

    DashboardController.$inject = [];

    function DashboardController() {
        var vm = this;

        vm.$onInit = onInit;

        function onInit() {

        }
    }
})();