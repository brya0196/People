(function () {
    'use strict';

    angular.module('app').component('editResidence', {
        templateUrl: "/angular/app/residence/form-residence.html",
        controller: EditResidenceController,
        controllerAs: 'vm'
    });

    EditResidenceController.$inject = ['$scope', '$q', '$log', 'kindServiceFactory', 'ProvinceFactory', 'CityFactory', 'ResidenceFactory', 'ServiceFactory', 'PersonaFactory'];

    function EditResidenceController($scope, $q, $log, kindServiceFactory, ProvinceFactory, CityFactory, ResidenceFactory, ServiceFactory, PersonaFactory) {
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
            var url = window.location.pathname.split("/");
            var id = url[url.length - 1];

            ResidenceFactory.getById(id).then(function (residence) {
                $q.all([
                    ServiceFactory.getAllByIdResidence(residence.data.id),
                    PersonaFactory.getByIdResidence(residence.data.id),
                    kindServiceFactory.getAll(),
                    ProvinceFactory.getAll(),
                    CityFactory.getAll()
                ])
                    .then(function (response) {
                        var service = response[0].data;
                        var persona = response[1].data;
                        vm.kindsService = response[2].data;
                        var provinces = response[3].data;
                        var city = response[4].data;


                        if (_.find(city, { id: residence.data.idCity }))
                            residence.data.cityEntity = _.find(city, { id: residence.data.idCity });

                        if (_.find(provinces, { id: residence.data.cityEntity.idProvince }))
                            residence.data.idProvince = _.find(provinces, { id: residence.data.cityEntity.idProvince }).id;

                        angular.forEach(service, function (item) {
                            if (_.find(vm.kindsService, { id: item.idKindService }))
                                item.kindServiceEntity = _.find(vm.kindsService, { id: item.idKindService });
                        });

                        vm.residence = residence.data;
                        vm.services = service;
                        vm.residents = persona;
                    });
            });

            ProvinceFactory.getAll().then(function (response) {
                vm.provinces = response.data;
                return vm.provinces;
            });
        }

        function saveResident() {
            if (vm.resident.id) {
                PersonaFactory.update(vm.resident).then(function (response) { getPersona(); });
            }
            else {
                PersonaFactory.add(vm.resident).then(function (response) { getPersona(); });
            }
        }

        function deleteResident(id) {

        }

        function getPersona() {
            PersonaFactory.getByIdResidence(vm.residence.id).then(function (response) {
                vm.residents = response.data;
            });
        }

        function updateResident(id) {
            PersonaFactory.getById(id).then(function (response) {
                response.data.birthdate = moment(response.data.birthdate).format("YYYY-MM-DD");
                vm.resident = response.data;
                return vm.residence;
            });
        }

        function saveService() {
            if (vm.service.id) {
                ServiceFactory.update(vm.service).then(function (response) { getServices(); });
            }
            else {
                vm.service.idResidence = vm.residence.id;
                ServiceFactory.add(vm.service).then(function (response) { getServices(); });
            }
        }

        function deleteService(id) {
            ServiceFactory.remove(id).then(function (response) {
                getServices();
            });
        }

        function updateService(id) {
            ServiceFactory.getById(id).then(function (response) {
                vm.service = response.data;
                return vm.service;
            });
        }

        function getServices() {
            ServiceFactory.getAllByIdResidence(vm.residence.id).then(function (response) {
                angular.forEach(response.data, function (item) {
                    if (_.find(vm.kindsService, { id: item.idKindService })) item.kindServiceEntity = _.find(vm.kindsService, { id: item.idKindService });
                });

                vm.services = response.data;
            });
        }

        function clean() {
            vm.resident = {};
            vm.service = {};
        }

        function getCity(id) {
            CityFactory.getByIdProvince(id).then(function (response) {
                vm.cities = response.data;
                return vm.cities;
            });
        }

        function save() {

        }

        $scope.$watch('vm.residence.idProvince', function (newValue) {
            if (newValue) getCity(newValue);
        });
    }
})();