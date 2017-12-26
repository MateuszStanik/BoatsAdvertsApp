define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/advert', 'smartWizard', 'select2'],
    function (router, app, $, ko, advert) {

        var vm = {
            dicCategories: ko.observable(),
            testValue: ko.observable(),
            selectedCategory: ko.observable(''),
            getDic: getDic,
            setSelect2Values:setSelect2Values,
            attached: function () {
                vm.getDic();
                vm.setSelect2Values();

                //$('#value').select2({
                //    data: vm.dicCategories()
                //});
                $('#value').on('select2:select', function (e) {
                    var data = e.params.data;
                    console.log(data.id);
                    vm.selectedCategory(data.id);
                });
                //$('#value').change(function () {
                //    //var theID = $(test).val(); // works
                //    //var theSelection = $(test).filter(':selected').text(); // doesn't work
                //    var theID = $('#value').select2('data').id;
                //    var theSelection = $('#value').select2('data').text;
                //    vm.selectedCategory(theID);
                //});

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
        return vm;
        function setSelect2Values() {
        
        }
        
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

       
    });