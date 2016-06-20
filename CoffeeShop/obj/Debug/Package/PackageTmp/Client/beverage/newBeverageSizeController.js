'use strict';

angular.module('coffeeshop').controller('NewBeverageSizeController',
    ['$uibModalInstance', 'WebService', function ($uibModalInstance, WebService) {
        var ctrl = this;

        ctrl.errorMessage;

        ctrl.size = new Size();
      
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

    }]);