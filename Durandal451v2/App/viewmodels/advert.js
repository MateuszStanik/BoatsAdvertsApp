define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'services/advert', 'services/logger', './Services/advertService', 'dropzone', 'smartWizard', 'select2', 'knockout.validation'],
    function (router, app, $, ko, advert, logger, advertService, dropzone) {

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
                        message: 'Prosze wprowadzic wartość',
                        params: '^[0-9]+(\,[0-9]{1,2})?$',
                    },
                    required: true,
                }),
            },
            
            //sendToDb: function ()
            //{
            //    advertService.sendToDb(vm.selectedCategory, vm.advert, vm.crazyModel, vm.crazyModelContact);
            //},
           
            attached: function () {
                advertService.getDic();
                vm.setSelect2Values();
                var baseUrl = $.getBasePath();
                var sucessFlag = true;
                var myDropzone = new dropzone("#myId", {                   
                    url: baseUrl + "api/Advert/UploadImage",
                    autoProcessQueue: false,  
                    maxFileSize: 10,
                    uploadMultiple: true,
                    parallelUploads: 100,
                    maxFiles: 10,
                    addRemoveLinks: true,
                    acceptedFiles: ".jpeg,.jpg,.png,.gif",
                    dictDefaultMessage: "Przeciągnij tu zdjęcia wystawianego przedmiotu",
                    dictRemoveFile: "Usuń plik",
                    dictCancelUpload: "Anuluj",
                    
                    success: function (file, response, action) {                        
                        if (sucessFlag == true) {
                            logger.log({
                                message: "Ogłoszenie zostało dodane!",
                                data: "",
                                showToast: true,
                                type: "info"
                            });
                            sucessFlag = false;
                        }
                      
                    },
                    error: function (file, response) {
                        logger.log({
                            message: "Błąd podczas zapisywania danych!",
                            data: "",
                            showToast: true,
                            type: "error"
                        });
                    }
                });
                myDropzone.on('sending', function (file, xhr, formData) {
                    if (file == myDropzone.files[0]) {
                        formData.append('subjectType', ko.toJSON(vm.selectedCategory));
                        formData.append('subject', ko.toJSON(vm.advert));
                        formData.append('contact', ko.toJSON(vm.crazyModelContact));
                        formData.append('product', ko.toJSON(vm.crazyModel));
                    }
                });

                $('#saveAllFiles').on('click', function(e){
                    myDropzone.processQueue();
                });

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

                $("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {
                    vm.errorsStep0 = ko.validation.group(vm.advert);
                    vm.errorsStep1 = ko.validation.group(vm.crazyModel());
                    vm.errorsStep2 = ko.validation.group(vm.crazyModelContact());

                    if (stepDirection == 'forward')
                    {
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
                        if (stepNumber == 2) {
                            if (vm.errorsStep2().length > 0) {
                                vm.errorsStep2.showAllMessages();
                                return false;
                            }
                        }
                    }
                    
                });
            },
        };
        
        function setSelect2Values() { }

        return vm;            
    });