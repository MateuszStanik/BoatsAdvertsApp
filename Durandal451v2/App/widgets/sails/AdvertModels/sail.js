define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
               
                LeechLenght: ko.observable(),
                FootLenght: ko.observable(),
                LuffLenght: ko.observable(),
                Brand: ko.observable(),
                SailArea: ko.observable()
            }

            return vm;
        };
    });
