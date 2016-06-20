'use strict';

angular.module('coffeeshop').controller('NewBeverageController',
    ['$uibModalInstance', 'WebService', function ($uibModalInstance, WebService) {
        var ctrl = this;

        ctrl.beverage = new Beverage();
        
        ctrl.beverageTypes;
        ctrl.sizes;

        ctrl.errorMessage;
        
        ctrl.load = function () {
            //load beverages
            WebService.getPromise('beverages/getTypes')
              .then(function (response) {
                  ctrl.beverageTypes = response.data;
                  console.log(ctrl.beverageTypes);
              });

            WebService.getPromise('beveragesizes/getSizes')
              .then(function (response) {
                  ctrl.sizes = response.data;
                  console.log(ctrl.sizes);
              });
        };

        ctrl.addNewPriceEntry = function () {
            var beveragePrice = new BeveragePrice();
            //add to the new list
            ctrl.beverage.BeveragePrices.push(beveragePrice);
        }

        //set default entry
        ctrl.addNewPriceEntry();
        

        ctrl.save = function () {

            WebService.postPromise('beverages/', ctrl.beverage)
              .then(function (response) {
                  console.log(response.data);
                  $uibModalInstance.close();
              });
        }

        ctrl.cancel = function () {
            $uibModalInstance.dismiss('canceled');
        }

        ctrl.load();
    }]);