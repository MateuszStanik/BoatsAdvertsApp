define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/logger', './Services/productsService', 'materialize'],
    function (router, app, $, ko, logger, productServices) {

        var vm = {
            selectedCategory: ko.observable('sailboat'),
            model : ko.observable({}),
            //images : ko.observable(),
            ImageTMP: ko.observable("../../Content/images/6034941_20161201023704697_1_XLARGE.jpg"),
            attached: function () {
                productServices.getProducts();
                vm.model(productServices.model);
                //productServices.getImages(vm.model.SubjectId);
                
                //vm.images(productServices.images);
            }
        };


        return vm;
});