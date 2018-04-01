define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                Brand: ko.observable(),
                Power: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    }
                }),
                TypeOfEngine: ko.observable().extend({
                    required: true
                }),
                TypeOfFuel: ko.observable().extend({
                    required: true
                }),
                BuiltYear: ko.observable(),
            }
            return vm;
        };
    });
