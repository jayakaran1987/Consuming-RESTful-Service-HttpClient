var app = angular.module("app", ['ngRoute', 'kendo.directives']);
// Angular routing partial views

app.config(function ($routeProvider) {
    $routeProvider
        .when('/home', {
            templateUrl: 'app/views/home/MovieDetailView.html',
            controller: 'MovieDetailController'
        })
        .otherwise({
            redirectTo: '/home'
        });
});

// Angular directive used to check Poster is availble 
// If Poster is not available replace with Default Image

app.directive('checkImage', function ($http) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            attrs.$observe('ngSrc', function (ngSrc) {
                $http.get(ngSrc).success(function () {
                }).error(function () {
                    element.attr('src', '/Content/images/no_image.jpg'); // set default image
                });
            });
        }
    };
});
