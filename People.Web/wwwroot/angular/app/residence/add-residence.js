(function () {
    'use strict';

    angular.module('app').component('addResidence', {
        templateUrl: "/angular/app/residence/form-residence.html",
        controller: AddResidenceController,
        controllerAs: 'vm'
    });

    AddResidenceController.$inject = ['$q', '$log', 'kindServiceFactory', 'ProvinceFactory', 'CityFactory', 'ResidenceFactory', 'ServiceFactory', 'PersonaFactory'];

    function AddResidenceController($q, $log, kindServiceFactory, ProvinceFactory, CityFactory, ResidenceFactory, ServiceFactory, PersonaFactory) {
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

                kindServiceFactory.getById(service.idKindService).then(function (response) {
                    vm.service.kindServiceEntity = response.data;
                    vm.service.payment = service.payment;
                    vm.service.idKindService = service.idKindService;

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
            CityFactory.getByIdProvince(id).then(function (response) {
                vm.cities = response.data;
                return vm.cities;
            });
        }

        function save() {
            var datos = {
                residence: null,
                residents: null,
                services: null
            };

            ResidenceFactory.add(vm.residence)
                .then(function (response) {
                    datos.residence = angular.copy(response.data);

                    angular.forEach(vm.residents, function(item){
                        item.idresidence = datos.residence.id;
                    });

                    angular.forEach(vm.services, function(item){
                        item.idresidence = datos.residence.id;
                    });
    
                    $q.all([
                        vm.services.length > 0 ? ServiceFactory.addAll(vm.services) : null,
                        vm.residents.length > 0 ? PersonaFactory.addAll(vm.residents) : null
                    ])
                        .then(function (response) {
                            $log.info(response);
                            debugger;
                            vm.services = angular.copy(response[0].data);
                            vm.residents = angular.copy(response[1].data);

                            alertify.alert("Agregada nueva residencia",
                                "Se agrego la nueva Residencia sin problema",
                                function () {
                                    window.location.href = "/residence";
                                })
                                .set({
                                    'movable': false,
                                    'closableByDimmer': false
                                });


                        })
                        .catch(function (error) {
                            $log.error(error);
                            $log.info(datos);
                            ResidenceFactory.remove(datos.residence.id);

                            alertify.alert("Error Agregando", "Se produjo al agregar la nueva residencia").set({ 'movable': false });

                            if (datos.services != null) {
                                angular.forEach(datos.services, function (item) {
                                    ServiceFactory.remove(item.id);
                                });
                            }

                            if (datos.residents != null) {
                                angular.forEach(datos.residents, function (item) {
                                    PersonService.remove(item.id);
                                });
                            }
                        });
                })
                .catch(function (error) {
                    $log.error(error);

                    alertify.alert("Error Agregando", "Se produjo al agregar la nueva residencia").set({ 'movable': false });
                    ResidenceFactory.remove(datos.residence.id);

                    if (datos.services != null) {
                        angular.forEach(datos.services, function (item) {
                            ServiceFactory.remove(item.id);
                        });
                    }

                    if (datos.residents != null) {
                        angular.forEach(datos.residents, function (item) {
                            PersonService.remove(item.id);
                        });
                    }
                });
        }
    }
})();