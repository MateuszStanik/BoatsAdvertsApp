define(['durandal/app', 'jquery', 'knockout', './AdvertModels/motorBoat', 'knockout.validation'], function (app, $, ko, motorBoat) {

    return function model() {

        var self = this;

        self.model = ko.validatedObservable(new motorBoat());
        
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