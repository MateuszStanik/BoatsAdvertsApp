﻿define(['durandal/app', 'jquery', 'knockout', './AdvertModels/trailor'], function (app, $, ko, trailor) {

    return function model() {
        var self = this;

        self.model = ko.observable(new trailor());

        self.isEditable = ko.observable(true);

        self.activate = function (options) {            
            if (options.isEditable == true) {
                options.crazy(self.model());
            }
            if (options.isEditable == false) {
                self.model(options.crazy());
            }
            self.isEditable(options.isEditable);
        };
     
    };
   
    
});