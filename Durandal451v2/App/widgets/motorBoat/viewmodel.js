define(['durandal/app', 'jquery', 'knockout', './AdvertModels/motorBoat'], function (app, $, ko, motorBoat) {

    return function model() {

        var self = this;

        self.model = ko.observable(new motorBoat());
        
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

//define(['durandal/app', 'jquery', 'knockout', './AdvertModels/motorBoat'], function (app, $, ko, motorBoat) {
//    var self = this;

//    self.activate = function (options) {
//        vm.modelS(new motorBoat());
//        options.data(vm.modelS());
//    };

//    var vm = {
//        modelS: ko.observable(),
//        activate: self.activate,

//    }

//    return vm;
//});