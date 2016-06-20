'use strict';

angular.module('coffeeshop').controller('OrdersController', ['$uibModal', 'WebService', function ($uibModal, WebService) {
    var ctrl = this;
    ctrl.ordersList = [];
    ctrl.ordersSummary = [];

    ctrl.load = function () {
        WebService.getPromise('orders/')
              .then(function (response) {
                  ctrl.ordersList = response.data;
                  console.log(ctrl.ordersList);
              });

        WebService.getPromise('orders/getSummary')
              .then(function (response) {
                  ctrl.ordersSummary = response.data;
                  console.log(ctrl.ordersSummary);
              });
    };

    ctrl.addNewOrder = function () {
        ctrl.showModal();
    }

    ctrl.editNewOrder = function (order) {
        ctrl.showModal(order);
    }

    ctrl.showModal = function (order) {

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
            //reload all product types 
            ctrl.load();
        }, function () {
            console.log('Cancelled');
            ctrl.load();
        })['finally'](function () {

        });
    }

    ctrl.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

    ctrl.load();
}]);