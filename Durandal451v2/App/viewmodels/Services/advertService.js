define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/advert', 'services/logger'],
    function (router, app, $, ko, advert, logger) {
        var self = this;
        self.activate = function (options) {
            console.log('product service activated')
        };

        var vm = {          
            getDic: getDic,
            sendToDb : sendToDb,

        }
        function sendToDb(subjectType, subject, product, contact) {
            advert.saveAdvert({
                subjectType: ko.toJSON(subjectType),
                subject: ko.toJSON(subject),
                contact: ko.toJSON(contact),
                product: ko.toJSON(product),
            }).done(function (data) {
                console.log('Zapisano dane do DB');                    
                logger.log({
                    message: "Zapisano dane do bazy.",                        
                    showToast: true,
                    type: "info"
                });
                router.navigate('#/', 'replace');
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
                        message: "Błąd podczas zapisywania danych!",
                        data: "",
                        showToast: true,
                        type: "error"
                    });
                }
            });
        }

        function getDic() {
            advert.getCategoriesDictionary({

            }).done(function (data) {
                $('#value').select2({
                    data: data,
                });               
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
                        message: "Błąd pobierania słowników.",
                        data: "",
                        showToast: true,
                        type: "error"
                    });
                }
            });
        }

        return vm;
});