(function () {
    'use strict';

    angular.module('app').component('editResidence', {
        templateUrl: "/angular/app/residence/form-residence.html",
        controller: EditResidenceController,
        controllerAs: 'vm'
    });

    EditResidenceController.$inject = ['$q', '$log', 'kindServiceFactory', 'ProvinceFactory', 'CityProvince', 'ResidenceFactory', 'ServiceFactory', 'PersonaFactory'];

    function EditResidenceController($q, $log, kindServiceFactory, ProvinceFactory, CityProvince, ResidenceFactory, ServiceFactory, PersonaFactory) {
        var vm = this;

        activate();
        vm.residence = {};
        vm.residents = [];
        vm.resident = {};

        vm.services = [];
        vm.service = {};

        //functions
        vm.saveResident = saveResident;
        vm.deleteResident = deleteResident;
        vm.updateResident = updateResident;

        vm.saveService = saveService;
        vm.deleteService = deleteService;
        vm.updateService = updateService;

        vm.getCity = getCity;

        vm.clean = clean;
        vm.save = save;

        function activate() {
            ProvinceFactory.getAll().then(function (response) {
                vm.provinces = response.data;
                return vm.provinces;
            });
        }

        function saveResident() {
           
        }

        function deleteResident(id) {
           
        }

        function updateResident(id) {
           
        }

        function saveService() {
            
        }

        function deleteService(id) {
            
        }

        function updateService(id) {
            
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

        function save() {
            
        }
    }
})();