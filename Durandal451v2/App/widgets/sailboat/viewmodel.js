define(['durandal/app', 'jquery', 'knockout', './AdvertModels/sailboat', 'knockout.validation'], function (app, $, ko, sailboat) {

    return function model() {

        //ko.validation.init({
        //    messagesOnModified: false
        //});

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
        };

    };


});

//define(['durandal/app', 'jquery', 'knockout', './AdvertModels/sailboat'], function (app, $, ko, sailboat) {
//    var self = this;

//    self.activate = function (options) {
//        vm.modelS(new sailboat());
//        options.data(vm.modelS());
//    };

//    var vm = {
//        modelS: ko.observable(),
//        activate: self.activate,

//    }

//    return vm;
//});