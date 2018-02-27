define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                Name: ko.observable('Mateusz').extend({ min:3, max: 99 }),
                SureName: ko.observable('adsf').extend({ min: 3, max: 99 }),
                PhoneNumber: ko.observable('234').extend({ min: 6, max: 10 }),
                Email: ko.observable('mat@gmail.com').extend({
                    email: true,
                    required: true,
                    max: 99,
                }),
                City: ko.observable('Kato').extend({ min: 2, max: 99 }),
                AdditionalInformation: ko.observable('brak').extend({max: 254 }),
            }

            return vm;
        };
    });
