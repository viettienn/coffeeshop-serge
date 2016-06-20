'use strict';

angular.module('coffeeshop').factory('WebService', ['$http', function ($http) {
    var prefix = "service/";

    var reqPromise = function (req) {
        req.url = req.url;
        var promise = $http(req);

        promise.then(function (res) {
            
        }, function () {
            console.log('error occured');
            
        });

        console.log('Server Request (' + req.method + ') -> ' + req.url);
        return promise;
    }

    var master = {
        getPromise: function (route, params) {

            var url = prefix + route + (params ? "?" + params : "");
            var promise = reqPromise({ method: 'GET', url: url });
            
            return promise;
        },

        postPromise: function (route, data) {

            var url = prefix + route;
            var promise = reqPromise({ method: 'POST', url: url, data: data });
            
            return promise;
        },

        putPromise: function (route, data) {

            var url = prefix + route;
            return reqPromise({ method: 'PUT', url: url, data: data });
        },

        deletePromise: function (route) {

            var url = prefix + route;
            var promise = reqPromise({ method: 'DELETE', url: url });
            
            return promise;
        }
    };

    return master;
}]);