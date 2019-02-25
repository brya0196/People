﻿(function () {
    'use strict';

    angular.module('app').component('addResidence', {
        templateUrl: "/angular/app/residence/add-residence/add-residence.html",
        controller: AddResidenceController,
        controllerAs: 'vm'
    });

    AddResidenceController.$inject = [];

    function AddResidenceController() {
        var vm = this;

        vm.residents = [];
        vm.resident = {};
        vm.saveResident = saveResident;
        vm.deleteResident = deleteResident;
        vm.clean = clean;

        function saveResident() {
            vm.residents.push(vm.resident);
            vm.resident = {};
        }

        function deleteResident(id) {

        }

        function clean() {
            vm.resident = {};
        }
    }
})();