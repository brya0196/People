(function () {
    'use strict';

    angular
        .module('app')
        .directive('residentList', residentList);

    residentList.$inject = ['$window'];

    function residentList($window) {
        // Usage:
        //     <residents_list></residents_list>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            scope: {
                residents: '='
            },
            templateUrl: '/angular/common/directives/resident-list/resident-list.html'
        };
        return directive;

        function link(scope, element, attrs) {
            scope.$watch('residents', function (newVal) {
                console.log(newVal);
            });
        }
    }

})();