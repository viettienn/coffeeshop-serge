'use strict';

angular.module('coffeeshop').controller('MainController',
    ['$uibModal', 'WebService', '$mdDialog', '$mdMedia', function ($uibModal, WebService, $mdDialog, $mdMedia) {
        var ctrl = this;

        ctrl.customFullscreen = $mdMedia('xs') || $mdMedia('sm');

        ctrl.addNewOrder = function () {
            ctrl.showOrderModal();
        }

        ctrl.editNewOrder = function (order) {
            ctrl.showOrderModal(order);
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

            }, function () {
                console.log('Cancelled');

            })['finally'](function () {

            });
        }

        //new way to display dialog using material design
        ctrl.addNewSize = function () {

            var instance = $uibModal.open({
                animation: true,
                templateUrl: window.globals.views.get('Client/beverage/new-beverage-size-modal.html'),
                controller: 'NewBeverageSizeController as modal',
                backdrop: 'static',
                size: 'sm',
                keyboard: false
            });

            instance.result.then(function () {

            }, function () {
                console.log('Cancelled');

            })['finally'](function () {

            });
        };

        ctrl.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);