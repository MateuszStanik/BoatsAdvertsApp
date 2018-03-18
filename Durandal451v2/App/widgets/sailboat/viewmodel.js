﻿define(['durandal/app', 'jquery', 'knockout', './AdvertModels/sailboat', '../../services/advert', 'services/logger', 'knockout.validation', 'select2'], function (app, $, ko, sailboat, advert, logger) {

    return function model() {

        var self = this;

        self.model = ko.validatedObservable(new sailboat());

        self.isEditable = ko.observable(true);

        self.activate = function (options) {

            if (options.isEditable == true) {
                options.crazy(self.model());
            }
            if (options.isEditable == false) {
                self.model(options.crazy());
            }
            self.isEditable(options.isEditable);

            $('#yearbook').on('select2:select', function (e) {
                var data = e.params.data;
                self.model().BuiltYear(data.id);
            });

        };

        self.getDicYearBook =function() {
            advert.getYearbooksDictionary({

            }).done(function (data) {
                $('#yearbook').select2({
                    data: data,
                });
            }).always(function () {
            }).failJSON(function (data) {
                if (data && data.error_description) {
                    logger.log({
                        message: data.error_description,
                        data: data.error_description,
                        showToast: true,
                        type: "error"
                    });
                } else {
                    logger.log({
                        message: "Błąd pobierania słowników.",
                        data: "",
                        showToast: true,
                        type: "error"
                    });
                }
            });
        };
        self.attached = function () {
            self.getDicYearBook();
          
           
        };

    };


});

