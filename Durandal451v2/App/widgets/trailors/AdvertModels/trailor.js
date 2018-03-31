define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                Weight: ko.observable(),
                Length: ko.observable(),
                Width: ko.observable(),
                Capcity: ko.observable(),
                Brand: ko.observable(),
                BuiltYear: ko.observable(),
            }

            return vm;
        };
    });
