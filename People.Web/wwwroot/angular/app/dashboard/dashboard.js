(function () {
    'use strict';

    angular.module('app').component('dashboard', {
        templateUrl: '/angular/app/dashboard/dashboard.html',
        controller: DashboardController,
        controllerAs: 'vm'
    });

    DashboardController.$inject = ['$q', '$log', 'ServiceFactory', 'kindServiceFactory', 'PersonaFactory'];

    function DashboardController($q, $log, ServiceFactory, kindServiceFactory, PersonaFactory) {
        var vm = this;

        vm.$onInit = onInit;

        function onInit() {
            var data = [
                ServiceFactory.getAll(),
                kindServiceFactory.getAll()
            ];


            $q.all(data).then(function (response) {
                var service = response[0].data;
                var kindService = response[1].data; 

                vm.serviceData = {
                    data: [0, 0, 0, 0, 0],
                    labels: []
                };

                angular.forEach(kindService, function (item) {
                    vm.serviceData.labels.push(item.name);
                    return vm.serviceData;
                });

                angular.forEach(service, function (item) {
                    if (item.idKindService === 1) vm.serviceData.data[0] += 1;
                    if (item.idKindService === 2) vm.serviceData.data[1] += 1;
                    if (item.idKindService === 3) vm.serviceData.data[2] += 1;
                    if (item.idKindService === 4) vm.serviceData.data[3] += 1;
                    if (item.idKindService === 5) vm.serviceData.data[4] += 1;
                    return vm.serviceData;
                });
                

                return response;
            });
        }
    }
})();