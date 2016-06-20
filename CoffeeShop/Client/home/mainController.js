'use strict';

angular.module('coffeeshop').controller('MainController',
    ['$uibModal', 'WebService', '$mdDialog', '$mdMedia', '$timeout', function ($uibModal, WebService, $mdDialog, $mdMedia, $timeout) {
        var ctrl = this;
        ctrl.response;

        ctrl.customFullscreen = $mdMedia('xs') || $mdMedia('sm');

        ctrl.addNewOrder = function () {
            ctrl.showOrderModal();
        }

        ctrl.editNewOrder = function (order) {
            ctrl.showOrderModal(order);
        }

        function showResponse(msg) {
            ctrl.response = msg;
            $timeout(function () {
                ctrl.response = '';
            }, 3000);
            console.log('response');
        }

        ctrl.showOrderModal = function (order) {

            var instance = $uibModal.open({
                animation: true,
                templateUrl: window.globals.views.get('Client/order/new-order-modal.html'),
                controller: 'NewOrderController as modal',
                backdrop: 'static',
                size: 'md',
                keyboard: false,
                resolve: {
                    record: function () {
                        return order;
                    }
                }
            });

            instance.result.then(function () {
                showResponse('New order added!');
            }, function () {
                
            })['finally'](function () {

            });
        }

        ctrl.showBeverageModal = function () {

            var instance = $uibModal.open({
                animation: true,
                templateUrl: window.globals.views.get('Client/beverage/new-beverage-modal.html'),
                controller: 'NewBeverageController as modal',
                backdrop: 'static',
                size: 'md',
                keyboard: false
            });

            instance.result.then(function () {
                showResponse('New beverage added!');
            }, function () {
                
            })['finally'](function () {

            });
        }

        //new way to display dialog using material design
        ctrl.addNewSize = function () {

            var instance = $uibModal.open({
                animation: true,
                templateUrl: window.globals.views.get('Client/beverage/new-size-modal.html'),
                controller: 'NewSizeController as modal',
                backdrop: 'static',
                size: 'sm',
                keyboard: false
            });

            instance.result.then(function () {
                showResponse('New size added!');
            }, function () {
                

            })['finally'](function () {

            });
        };

        ctrl.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);