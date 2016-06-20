'use strict';

angular.module('coffeeshop').controller('BeveragesController',
    ['WebService', '$uibModal', function (WebService, $uibModal) {
        var ctrl = this;
        ctrl.sizes;
        ctrl.beveragesList;

        ctrl.load = function () {

            WebService.getPromise('beveragesizes/getSizes')
            .then(function (response) {
                ctrl.sizes = response.data;
                console.log(ctrl.sizes)
            });

            WebService.getPromise('beverages')
            .then(function (response) {
                ctrl.beveragesList = response.data;
                console.log(ctrl.beveragesList)
            });
        }

        ctrl.isAvailable = function (sizeId, beveragesSizesList) {
            for (var i = 0; i < beveragesSizesList.length; i++) {
                if (beveragesSizesList[i].SizeId === sizeId && beveragesSizesList[i].Active) {
                    return true;
                }
            }
            return false;
        }

        
        ctrl.getPrice = function (sizeId, beveragesSizes, beveragePrices) {
            var beverageSize = $.grep(beveragesSizes, function (item) {
                return item.SizeId === sizeId;
            })[0];

            if(beverageSize)
            for (var i = 0; i < beveragePrices.length; i++) {
                if (beveragePrices[i].BeverageSizeId === beverageSize.Id) {
                    return beveragePrices[i].Price;
                }
            }
        }

        ctrl.add_remove = function (beverage, size, add) {
            console.log(beverage);
            console.log(size);
            console.log(add);
            
            var instance = $uibModal.open({
                animation: true,
                templateUrl: window.globals.views.get('Client/beverage/new-beverage-size-modal.html'),
                controller: 'NewBeverageSizeController as modal',
                backdrop: 'static',
                size: 'md',
                keyboard: false,
                resolve: {
                    records: function () {
                        return {
                            size: size,
                            beverage: beverage,
                            add: add
                        };
                    }
                }
            });

            instance.result.then(function () {
                
                
            }, function () {
                
            })['finally'](function () {
                ctrl.load();
            });
        }

        

        
        ctrl.cancel = function () {
            $uibModalInstance.dismiss('canceled');
        }

        ctrl.load();

    }]);