define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/products', 'services/logger'],
    function (router, app, $, ko, products, logger) {
        var self = this;
        self.Model = ko.observable({});
        self.Images = ko.observable();
        var vm = {
            getProducts: getProducts,
            getImages: getImages,
            model: self.Model,
            images: self.Images
        }

        function getProducts() {
            products.getAllProducts({
            }).done(function (data) {
                console.log('Pobrano dane z DB');
                self.Model(data);
                //router.navigate('#/', 'replace');
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

        function getImages(id) {
            products.getImages({
            }).done(function (data) {
                console.log('Pobrano dane z DB');
                self.Images(data);
                //router.navigate('#/', 'replace');
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

        return vm;
    });