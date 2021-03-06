﻿(function () {
    'use strict';

    angular
        .module('app')
        .directive('serviceList', serviceList);

    serviceList.$inject = ['$window'];

    function serviceList($window) {
        // Usage:
        //     <service-list></service-list>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            scope: {
                services: '=',
                ondelete: '&',
                onupdate: '&'
            },
            templateUrl: '/angular/common/directives/service-list/service-list.html'
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