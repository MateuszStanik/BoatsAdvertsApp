define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                               
                BoatModel : ko.observable(),          
                ProducentName : ko.observable(),
                BuiltYear: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 2018)',
                        params: '^[1-2][0-9][0-9][0-9]$',
                    },
                    required: true
                }),
                EngineType : ko.observable(),
                Length: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true
                }),
                Beam : ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                }),
                Weight : ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                }),
               
            }

            return vm;
        };
    });
