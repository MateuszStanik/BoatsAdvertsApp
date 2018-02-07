define(['durandal/app', 'jquery', 'knockout'], function (app, $, ko) {

    return function model() {
        var self = this;
        self.activate = function (options) {
            self.model = options.data;

        };
     
    };
   
    
});