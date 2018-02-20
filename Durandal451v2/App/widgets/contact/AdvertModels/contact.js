define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                Name: ko.observable('Mateusz'),
                SureName: ko.observable('adsf'),
                PhoneNumber: ko.observable('234'),
                Email: ko.observable('mat@gmail.com').extend({
                    email: true,
                    required: true
                }),
                City: ko.observable('Kato'),
                AdditionalInformation: ko.observable('brak'),
            }

            return vm;
        };
    });
