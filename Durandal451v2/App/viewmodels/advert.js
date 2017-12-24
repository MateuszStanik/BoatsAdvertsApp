define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/advert', 'smartWizard', 'select2'],
    function (router, app, $, ko, advert) {

        var vm = {
            dicCategories: ko.observable(),
            testValue: ko.observable(),
            getDic: getDic,
            setSelect2Values:setSelect2Values,
            attached: function () {
                vm.getDic();
                vm.setSelect2Values();

                //$('#value').select2({
                //    data: vm.dicCategories()
                //});
              

                $('#smartwizard').smartWizard({
                    selected: 0,
                    theme: 'dots',
                    transitionEffect: 'fade',
                    showStepURLhash: true,
                });
               
            },
          
          

           
        };
        return vm;
        function setSelect2Values() {
        
        }
        
        function getDic() {
            advert.getCategoriesDictionary({
               
            }).done(function (data) {
                $('#value').select2({
                    data: data
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

       
    });