(function () {
    'use strict';

    angular.module('app').directive('pieChart', pieChart);

    pieChart.$inject = ['$window', '$log'];

    function pieChart($window, $log) {
        // Usage:
        //     <pie-chart></pie-chart>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            scope: {
                data: '=',
                lebels: '='
            },
            template: '<div class="card"><canvas class="card-body" id="pieChart_{{id}}"></canvas></div>'
        };
        return directive;

        function link(scope, element, attrs) {
            scope.id = attrs.id;
            angular.element(element).ready(function () {
                var ctx = angular.element("#pieChart_" + scope.id);

                var pieChart = new Chart(ctx, {
                    type: 'pie',
                    data: {
                        datasets: [
                            {
                                data: [],
                                backgroundColor: ['#ff6384', '#fd7e14', '#dc3545', '#20c997', '#007bff']
                            }
                        ],
                        labels: [],
                    },
                    options: {}
                });

                scope.$watch('data', function () {
                    pieChart.data.datasets[0].data = scope.data;
                    pieChart.update();
                });

                scope.$watch('lebels', function () {
                    pieChart.data.labels = scope.lebels;
                    pieChart.update();
                });
            });
        }
    }
})();