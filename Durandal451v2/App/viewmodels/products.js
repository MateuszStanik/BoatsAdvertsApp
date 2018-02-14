define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/logger', 'materialize'],
    function (router, app, $, ko, logger) {

        var vm = {
            selectedCategory: ko.observable('sailboat'),
        };


        return vm;
});