define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/logger', './Services/productsService', 'materialize'],
    function (router, app, $, ko, logger, productServices) {
        var vm = {
            activate: activate,
            selectedCategory: ko.observable('sailboat'),
            model : ko.observable({}),
            ImageTMP: ko.observable("../../Content/images/6034941_20161201023704697_1_XLARGE.jpg"),

            attached: attached            
        };

        function activate(id) {
            console.log(id);
            return loadObservables(id);
        }

        function attached(id) {
                
                //productServices.getImages(vm.model.SubjectId);
                
                //vm.images(productServices.images);
        }

        function loadObservables(id) {
            productServices.getProducts(id);
            vm.model(productServices.model);


        }
        return vm;
});