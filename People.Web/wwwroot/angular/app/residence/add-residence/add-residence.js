(function () {
    'use strict';

    angular.module('app').component('addResidence', {
        templateUrl: "/angular/app/residence/add-residence/add-residence.html",
        controller: AddResidenceController,
        controllerAs: 'vm'
    });

    AddResidenceController.$inject = ['kindServiceFactory', 'ProvinceFactory', 'CityProvince'];

    function AddResidenceController(kindServiceFactory, ProvinceFactory, CityProvince) {
        var vm = this;

        activate();
        vm.residents = [];
        vm.resident = {};

        vm.services = [];
        vm.service = {};

        //functions
        vm.saveResident = saveResident;
        vm.deleteResident = deleteResident;
        vm.saveService = saveService;
        vm.deleteService = deleteService;
        vm.getCity = getCity;

        vm.clean = clean;

        function activate() {
            ProvinceFactory.getAll().then(function (response) {
                vm.provinces = response.data;
                return vm.provinces;
            });
        }

        function saveResident() {
            vm.residents.push(vm.resident);
            vm.resident = {};
        }

        function deleteResident(id) {
            vm.residents.splice(id, 1);
        }

        function saveService() {
            kindServiceFactory.getById(vm.service.idkindservice).then(function (response) {
                vm.service.kindservice = response.data;
                vm.services.push(vm.service);
                vm.service = {};
                return vm.services;
            });
            
        }

        function deleteService(id) {
            vm.services.splice(id, 1);
        }

        function clean() {
            vm.resident = {};
        }

        function getCity(id) {
            CityProvince.getByIdProvince(id).then(function (response) {
                vm.cities = response.data;
                return vm.cities;
            });
        }
    }
})();