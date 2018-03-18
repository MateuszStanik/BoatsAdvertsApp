define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/logger', './Services/productsService', 'services/products', 'materialize', 'knockout-paging'],
    function (router, app, $, ko, logger, productServices, products) {
        var vm = {
            activate: activate,
            selectedCategory: ko.observable('sailboat'),
            //model: ko.observableArray(productServices.Model),//.withMergeConstructor(productServices.Model),
            model : ko.observableArray([]),
            //ImageTMP: ko.observable("../../Content/images/6034941_20161201023704697_1_XLARGE.jpg"),
            attached: attached,
            //list: ko.observableArray(['a', 'b', 'c', 'd', 'e', 'f', 'g', 'e', 'f', 'g', 'e', 'f', 'g']),
            pageSize : ko.observable(9),
            pageIndex : ko.observable(0),
            moveToPage : function (index) {
               vm.pageIndex(index);
            } 
           
        };

        function activate(id) {
            getProducts(id);
            return loadObservables(id);
        }

        function attached(id) {

        }
        function getProducts(id) {
            products.getAllProducts({
                id: id,
            }).done(function (data) {              
                vm.model(data);
            }).always(function () {
            }).failJSON(function (data) {
                if (data && data.error_description) {
                    logger.log({
                        message: data.error_description,
                        data: data.error_description,
                        showToast: true,
                        type: "error"
                    });
                } else {
                    logger.log({
                        message: "Błąd podczas pobierania danych!",
                        data: "",
                        showToast: true,
                        type: "error"
                    });
                }
            });
        }

        function loadObservables(id) {
           // productServices.getProducts(id);
            //vm.model(productServices.Model);
           
             pagedList = ko.dependentObservable(function () {
                var size = vm.pageSize();
                var start = vm.pageIndex() * size;
                return vm.model.slice(start, start + size);
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