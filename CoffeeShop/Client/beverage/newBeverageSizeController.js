'use strict';

angular.module('coffeeshop').controller('NewBeverageSizeController',
    ['$uibModalInstance', 'WebService', 'records', function ($uibModalInstance, WebService, records) {
        var ctrl = this;

        ctrl.errorMessage;
        ctrl.size = records.size;
        ctrl.beverage = records.beverage;
        ctrl.add = records.add;

        ctrl.price;
        
        function setPrice() {
            var beverageSize = $.grep(ctrl.beverage.BeveragesSizes, function (item) {
                return item.SizeId === ctrl.size.Id;
            })[0];

            if (beverageSize)
                ctrl.price = $.grep(ctrl.beverage.BeveragePrices, function (item) {
                    return item.BeverageSizeId === beverageSize.Id;
                })[0].Price;
            else
                ctrl.price = 0;
            
        }
        setPrice();
        
        ctrl.save = function () {
            console.log(ctrl.size);
            if ((!ctrl.price || ctrl.price <=0) && ctrl.add) {
                ctrl.errorMessage = 'Invalid price';
            }
            else {
                if (ctrl.price <= 0) {
                    ctrl.errorMessage = 'Must set a price';
                    return;
                }
                WebService.postPromise('beveragesizes/updateSizes/' + ctrl.beverage.Id 
                    + '/' + ctrl.size.Id + '/' + ctrl.price + '/' + ctrl.add)
                  .then(function (response) {
                      console.log(response.data);
                      $uibModalInstance.close();
                  });
            }

        }

        ctrl.cancel = function () {
            $uibModalInstance.dismiss('canceled');
        }

    }]);