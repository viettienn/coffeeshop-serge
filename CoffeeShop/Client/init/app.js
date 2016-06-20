'use strict';

angular.module('coffeeshop', ['ui.router', 'ui.bootstrap', 'ngMaterial', 'ngMdIcons'])
    .config(function ($stateProvider, $urlRouterProvider, $httpProvider) {

        // Set the fallback url
        $urlRouterProvider.otherwise('/main');

        var defineState = function (name, spec) {
            if (window.globals && window.globals.views) {
                spec.templateUrl = window.globals.views.get('Client/' + spec.templateUrl);
                $stateProvider.state(name, spec);
            }
        };

        defineState('main', {
            url: '/main',
            templateUrl: 'home/main.html',
            controller: 'MainController',
            controllerAs: 'mainController'
        });

        defineState('beverages', {
            url: '/beverages',
            templateUrl: 'beverage/beverages.html',
            controller: 'BeveragesController',
            controllerAs: 'beverages'
        });

        defineState('orders', {
            url: '/orders',
            templateUrl: 'order/orders.html',
            controller: 'OrdersController',
            controllerAs: 'orders'
        });

        

    }).run([function () {
        alertify.set({
            labels: {
                ok: "Yes",
                cancel: "No"
            },
            buttonReverse: true,
            buttonFocus: "none"
        });
        }
    ]);
