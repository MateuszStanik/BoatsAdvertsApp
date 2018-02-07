define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/advert', 'services/logger', './AdvertModels/sailboat', './AdvertModels/motorBoat', 'smartWizard', 'select2'],
    function (router, app, $, ko, advert, logger, sailboat, motorBoat) {

        var vm = {
            dicCategories: ko.observable(),
            testValue: ko.observable(),
            selectedCategory: ko.observable(1),
            getDic: getDic,
            setSelect2Values: setSelect2Values,

            model: new sailboat(),

                    
            attached: function () {
                vm.getDic();
                vm.setSelect2Values();
                $('#value').on('select2:select', function (e) {
                    var data = e.params.data;
                    console.log(data.id);
                    vm.selectedCategory(data.id);
                });
             
                $('#smartwizard').smartWizard({
                    selected: 0,
                    theme: 'dots',
                    transitionEffect: 'fade',
                    showStepURLhash: true,           
                    lang: { 
                        next: 'Dalej',
                        previous: 'Wstecz'
                       
                    },

                });               
            },
        };

        function getDic() {
            advert.getCategoriesDictionary({

            }).done(function (data) {
                $('#value').select2({
                    data: data,
                });
                vm.testValue(data[0].id);
            }).always(function () {
                console.log(vm.dicCategories());
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

        function setSelect2Values() {
        
        }

        return vm;
       

       
       
    });