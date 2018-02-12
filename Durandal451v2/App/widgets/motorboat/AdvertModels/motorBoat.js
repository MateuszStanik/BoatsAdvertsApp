define(['plugins/router', 'durandal/app', 'jquery', 'knockout'],
    function (router, app, $, ko) {
        return function () {
            var vm = {
                               
                BoatModel : ko.observable(),          
                ProducentName : ko.observable(),
                BuiltYear : ko.observable(),
                EngineType : ko.observable(),
                Length : ko.observable(),
                Beam : ko.observable(),
                Weight : ko.observable(),
               
            }

            return vm;
        };
    });
