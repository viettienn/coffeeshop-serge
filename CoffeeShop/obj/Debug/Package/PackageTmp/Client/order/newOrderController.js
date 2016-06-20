'use strict';

angular.module('coffeeshop').controller('NewOrderController',
    ['$uibModalInstance', 'record', 'WebService', function ($uibModalInstance, record, WebService) {
        var ctrl = this;

        ctrl.order = record || new Order();

        ctrl.beverages;
        ctrl.errorMessage;
        ctrl.beverageSizes = [];
        ctrl.beveragePrice;

        ctrl.load = function () {
            //load beverages
            WebService.getPromise('beverages/')
              .then(function (response) {
                  ctrl.beverages = response.data;
                  console.log(ctrl.beverages);
              });
        };

        ctrl.getSizes = function () {
            WebService.getPromise('beveragesizes/' + ctrl.order.BeverageId)
              .then(function (response) {
                  ctrl.beverageSizes = response.data;
                  console.log(ctrl.beverageSizes);
              });
        }

        ctrl.getPrice = function () {
            WebService.getPromise('beverageprices/' + ctrl.order.BeverageId + '/' + ctrl.order.BeverageSizeId)
              .then(function (response) {
                  ctrl.beveragePrice = response.data;
                  ctrl.order.BeveragePriceId = ctrl.beveragePrice.Id;
                  console.log(ctrl.beveragePrice);
              });
        }

        ctrl.save = function () {
            
            WebService.postPromise('orders/', ctrl.order)
              .then(function (response) {
                  console.log(response.data);
                  $uibModalInstance.dismiss();
              });
        }

        ctrl.cancel = function () {
            $uibModalInstance.dismiss('canceled');
        }

        ctrl.load();
    }]);