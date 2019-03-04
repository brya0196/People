(function () {
    'use strict';

    angular.module('app').component('listResidence', {
        templateUrl: '/angular/app/residence/list-residence.html',
        controller: ListController,
        controllerAs: 'vm'
    });

    ListController.$inject = ['$log', '$q', 'ResidenceFactory', 'PersonaFactory', 'ServiceFactory', 'ProvinceFactory', 'CityFactory'];

    function ListController($log, $q, ResidenceFactory, PersonaFactory, ServiceFactory, ProvinceFactory, CityFactory) {
        var vm = this;

        activate();


        function activate() {
            getResidenceData()
                .then(function (response) {
                    vm.residences = response;
                    return vm.residences;
                })
                .catch(function (error) {
                    $log.error(error);
                    alertify.alert("Error", "Se produjo al momento de obtener las residencias").set({ 'movable': false });
                });
        }

        function getResidenceData() {
            var deferred = $q.defer();

            $q.all([
                ResidenceFactory.getAll(),
                ServiceFactory.getAll(),
                PersonaFactory.getAll(),
                ProvinceFactory.getAll(),
                CityFactory.getAll()
            ])
                .then(function (response) {
                    var residences = response[0].data;
                    var services = response[1].data;
                    var people = response[2].data;
                    var province = response[3].data;
                    var city = response[4].data;

                    angular.forEach(residences, function (residence) {
                        var numberOfServices = 0;
                        var numberOfResidents = 0;

                        angular.forEach(services, function (service) {
                            if (service.idResidence === residence.id) numberOfServices += 1;
                        });

                        angular.forEach(people, function (person) {
                            if (person.idResidence === residence.id) numberOfResidents += 1;
                        });

                        if (_.find(city, { id: residence.idCity })) residence.City = _.find(city, { id: residence.idCity });
                        if (_.find(province, { id: residence.City.idProvince })) residence.Province = _.find(province, { id: residence.City.idProvince });

                        residence.numberOfServices = numberOfServices;
                        residence.numberOfResidents = numberOfResidents;
                    });
                    deferred.resolve(residences);
                })
                .catch(function (error) {
                    deferred.reject(error.data);
                });

            return deferred.promise;
        }
    }
})();