define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/logger', './Services/productsService', 'materialize'],
    function (router, app, $, ko, logger, productServices) {

        var vm = {
            selectedCategory: ko.observable('sailboat'),
            model : ko.observable({}),


            attached: function () {
                productServices.getProducts();
                vm.model(productServices.model);
            }
        };


        return vm;
});