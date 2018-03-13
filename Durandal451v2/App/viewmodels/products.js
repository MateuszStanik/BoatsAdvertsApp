define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/logger', './Services/productsService', 'materialize', 'knockout-paging'],
    function (router, app, $, ko, logger, productServices) {
        var vm = {
            activate: activate,
            selectedCategory: ko.observable('sailboat'),
            model: ko.observableArray([]),
            ImageTMP: ko.observable("../../Content/images/6034941_20161201023704697_1_XLARGE.jpg"),

            attached: attached,

            list: ko.observableArray(['a', 'b', 'c', 'd', 'e', 'f', 'g', 'e', 'f', 'g', 'e', 'f', 'g']),
            pageSize : ko.observable(2),
            pageIndex : ko.observable(0),
            moveToPage : function (index) {
               vm.pageIndex(index);
            } 
           
        };

        function activate(id) {
            console.log(id);
            //loadObservables(id);
            
           
        return loadObservables(id);
        }

        function attached(id) {
            console.log(id);
            //productServices.getImages(vm.model.SubjectId);                
            //vm.images(productServices.images);
           
        }

        function loadObservables(id) {
            productServices.getProducts(id);
            vm.model(productServices.model);
            vm.model.valueHasMutated();
             pagedList = ko.dependentObservable(function () {
                var size = vm.pageSize();
                var start = vm.pageIndex() * size;

                //var tmo = vm.model;
                //var sliced = tmo.prototype.slice(start, start + size);
                return vm.model;
            });
            maxPageIndex = ko.dependentObservable(function () {
                return Math.ceil(vm.model().length / vm.pageSize()) - 1;
            });
            previousPage = function () {
                if (vm.pageIndex() > 0) {
                    vm.pageIndex(vm.pageIndex() - 1);
                }
            };
            nextPage = function () {
                if (vm.pageIndex() < maxPageIndex()) {
                    vm.pageIndex(vm.pageIndex() + 1);
                }
            };
            allPages = ko.dependentObservable(function () {
                var pages = [];
                for (i = 0; i <= maxPageIndex() ; i++) {
                    pages.push({ pageNumber: (i + 1) });
                }
                return pages;
            });
        }
        return vm;
});