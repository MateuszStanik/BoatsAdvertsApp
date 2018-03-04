define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'knockout.validation'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                Name: ko.observable(),
                SureName: ko.observable(),
                PhoneNumber: ko.observable(),
                Email: ko.observable().extend({
                    email: true,
                    required: true
                }),
                City: ko.observable(),
                AdditionalInformation: ko.observable(),
            }

            return vm;
        };
    });
