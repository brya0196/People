(function () {
    'use strict';

    angular.module('app').component('addResidence', {
        templateUrl: "/angular/app/residence/add-residence/add-residence.html",
        controller: AddResidenceController,
        controllerAs: 'vm'
    });

    AddResidenceController.$inject = ['$q', '$log', 'kindServiceFactory', 'ProvinceFactory', 'CityProvince', 'ResidenceFactory', 'ServiceFactory', 'PersonService'];

    function AddResidenceController($q, $log, kindServiceFactory, ProvinceFactory, CityProvince, ResidenceFactory, ServiceFactory, PersonService) {
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
            if (!vm.residentOnUpdate) vm.residents.push(vm.resident);
            vm.residentOnUpdate = false;
            vm.resident = {};
        }

        function deleteResident(id) {
            vm.residents.splice(id, 1);
        }

        function updateResident(id) {
            vm.residentOnUpdate = true;
            vm.resident = vm.residents[id];
        }

        function saveService() {
            if (!vm.serviceOnUpdate) {
                var service = angular.copy(vm.service);

                kindServiceFactory.getById(service.idkindservice).then(function (response) {
                    vm.service.kindservice = response.data;
                    vm.service.payment = service.payment;
                    vm.service.idkindservice = service.idkindservice;

                    vm.services.push(vm.service);
                    vm.service = {};
                    return vm.services;
                });
            }
            vm.serviceOnUpdate = false;
            vm.service = {};
        }

        function deleteService(id) {
            vm.services.splice(id, 1);
        }

        function updateService(id) {
            vm.serviceOnUpdate = true;
            vm.service = vm.services[id];
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
            ResidenceFactory.add(vm.residence)
                .then(function(response){
                    var residence = response.data;

                    angular.forEach(vm.residents, function(item){
                        item.idresidence = residence.id;
                    });

                    angular.forEach(vm.services, function(item){
                        item.idresidence = residence.id;
                        delete item.kindservice;
                    });
    
                    $q.all([
                        ServiceFactory.add(JSON.stringify(vm.services)),
                        PersonService.add(JSON.stringify(vm.residents))
                    ])
                        .then(function (response) {
                            $log.info(response);
                        });
                })
                .catch(function(error){ 
                    $log.error(error.data);
                });
        }
    }
})();