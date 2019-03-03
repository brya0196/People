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
                        var kindsService = response[2].data;
                        var provinces = response[3].data;
                        var city = response[4].data;


                        if (_.find(city, { id: residence.data.idCity }))
                            residence.data.cityEntity = _.find(city, { id: residence.data.idCity });

                        if (_.find(provinces, { id: residence.data.cityEntity.idProvince }))
                            residence.data.idProvince = _.find(provinces, { id: residence.data.cityEntity.idProvince }).id;

                        angular.forEach(service, function (item) {
                            if (_.find(kindsService, { id: item.idKindService })) item.kindServiceEntity = _.find(kindsService, { id: item.idKindService });
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
            CityFactory.getByIdProvince(id).then(function (response) {
                vm.cities = response.data;
                return vm.cities;
            });
        }

        function save() {

        }

        $scope.$watch('vm.residence.idprovince', function (newValue) {
            if (newValue) getCity(newValue);
        });
    }
})();