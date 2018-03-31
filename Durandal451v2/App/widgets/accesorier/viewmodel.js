define(['durandal/app', 'jquery', 'knockout', './AdvertModels/accessory'], function (app, $, ko, contact) {

    return function model() {
        var self = this;

        self.model = ko.observable(new contact());

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