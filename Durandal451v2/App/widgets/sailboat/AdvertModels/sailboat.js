define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {

                
                BoatModel: ko.observable().extend({ required: true }),
                YachtType: ko.observable().extend({ required: true }),
                ProducentName: ko.observable().extend({ required: true }),
                BuiltYear : ko.observable(),
                RudderType : ko.observable(),
                Length: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
                Beam: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
                Weight: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
                Displacement: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
                Draft: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
                EngineType: ko.observable(),
                EnginePower: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
                HullType : ko.observable(),
                SailsArea : ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
                IsEngine : ko.observable(),

            }
            return vm;

    };
});
