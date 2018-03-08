define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                
                BoatModel: ko.observable('sailboat'),
                YachtType: ko.observable('kilowy'),
                ProducentName: ko.observable('benetau'),
                BuiltYear: ko.observable(2010).extend({pattern: {message: 'Proszę wprowadzić wartość (np. 2018)', params: '^[1-2][0-9][0-9][0-9]$'}, required: true}),
                RudderType : ko.observable('rumpel'),
                Length: ko.observable(23).extend({ pattern: { message: 'Proszę wprowadzić wartość (np. 99,99)', params: '^[0-9]+(\,[0-9]{1,2})?$'}, required: true }),
                Beam: ko.observable(23).extend({ pattern: { message: 'Proszę wprowadzić wartość (np. 99,99)', params: '^[0-9]+(\,[0-9]{1,2})?$'}}),
                Weight: ko.observable(123).extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                }),
                Displacement: ko.observable(12).extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                }),
                Draft: ko.observable(12).extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                }),
                EngineType: ko.observable(1),
                EnginePower: ko.observable(1).extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                }),
                HullType : ko.observable(12),
                SailsArea : ko.observable(1).extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość (np. 99,99)',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                }),
                IsEngine : ko.observable('true'),

            }
            return vm;

    };
});
