(function () {
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

        vm.services = [];
        vm.service = {};

        //functions
        vm.saveResident = saveResident;
        vm.deleteResident = deleteResident;
        vm.saveService = saveService;
        vm.deleteService = deleteService;

        vm.clean = clean;

        function saveResident() {
            vm.residents.push(vm.resident);
            vm.resident = {};
        }

        function deleteResident(id) {
            vm.residents.splice(id, 1);
        }

        function saveService() {
            vm.services.push(vm.service);
            vm.service = {};
        }

        function deleteService(id) {
            vm.services.splice(id, 1);
        }

        function clean() {
            vm.resident = {};
        }
    }
})();