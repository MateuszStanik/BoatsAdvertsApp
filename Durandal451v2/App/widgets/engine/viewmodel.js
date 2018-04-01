define(['durandal/app', 'jquery', 'knockout', './AdvertModels/engine', 'knockout.validation', ], function (app, $, ko, engine) {

    return function model() {

        var self = this;

        self.model = ko.validatedObservable(new engine());

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