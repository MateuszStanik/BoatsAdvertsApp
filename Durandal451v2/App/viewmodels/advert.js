define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/advert', 'services/logger', './Services/advertService', 'smartWizard', 'select2', 'knockout.validation'],
    function (router, app, $, ko, advert, logger, advertService) {

        //ko.validation.init({
        //    messagesOnModified: true
        //});

        var vm = {
            dicCategories: ko.observable(),
            testValue: ko.observable(),
            selectedCategory: ko.observable('sailboat'),
            setSelect2Values: setSelect2Values,           
            crazyModel: ko.observable(),
            crazyModelContact: ko.observable(),


            advert: {
                AdvertName: ko.observable().extend({ required: true }),
                AdvertDescription: ko.observable().extend({ required: true }),
                Price: ko.observable().extend({
                    pattern: {
                        message: 'Proszę wprowadzić wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
            },
            
           

            sendToDb: function ()
            {
                advertService.sendToDb(vm.selectedCategory, vm.advert, vm.crazyModel, vm.crazyModelContact);
            },

            //test: function(){
            //    if (vm.errors().length > 0) {
            //        vm.errors.showAllMessages();
            //        console.log(vm.errors().length);
            //        return;
            //    }
            //},


            attached: function () {
                advertService.getDic();
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

                vm.errorsStep0 = ko.validation.group(vm.advert);
                vm.errorsStep1 = ko.validation.group(vm.crazyModel());

                $("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {
                    // Enable finish button only on last step
                    if (stepNumber == 0) {
                        if (vm.errorsStep0().length > 0) {
                            vm.errorsStep0.showAllMessages();
                            return false;
                        }
                    }
                    if (stepNumber == 1) {
                        if (vm.errorsStep1().length > 0) {
                            vm.errorsStep1.showAllMessages();
                            return false;
                        }
                    }
                });
            },
        };

        
        function setSelect2Values() { }

        return vm;            
    });