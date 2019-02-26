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
                residents: '=',
                ondelete: '&',
                onupdate: '&'
            },
            templateUrl: '/angular/common/directives/resident-list/resident-list.html'
        };
        return directive;

        function link(scope, element, attrs) {
            scope.id = attrs.id;

            scope.onUpdate = function (id) {
                scope.onupdate({ id: id });
            };

            scope.onDelete = function (id) {
                scope.ondelete({ id: id });
            };
        }
    }

})();