'use strict';

angular.module('coffeeshop').controller('BeveragesController',
    ['WebService', function (WebService) {
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

        ctrl.isAvailable = function (id, list) {
            for (var i = 0; i < list.length; i++) {
                if (list[i].SizeId === id) {
                    console.log('true')
                    return true;
                }
            }
            return false;
        }

        ctrl.getPrice = function (id, list) {
            for (var i = 0; i < list.length; i++) {
                if (list[i].BeverageSizeId === id) {
                    return list[i].Price;
                }
            }
        }

        ctrl.save = function () {

            console.log(ctrl.size);
            if (!ctrl.size.Name) {
                ctrl.errorMessage = 'Specify the name';
            }
            else {
                WebService.postPromise('beveragesizes/insertSize/', ctrl.size)
                  .then(function (response) {
                      console.log(response.data);
                      $uibModalInstance.dismiss();
                  });
            }

        }

        ctrl.cancel = function () {
            $uibModalInstance.dismiss('canceled');
        }

        ctrl.load();

    }]);