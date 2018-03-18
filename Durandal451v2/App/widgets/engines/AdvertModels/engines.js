define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                Brand: ko.observable("Mercury"),
                Power: ko.observable(),
                TypeOfEngine: ko.observable(),
                TypeOfFuel: ko.observable(),
                BuiltYear: ko.observable(),
            }
            return vm;
        };
    });
