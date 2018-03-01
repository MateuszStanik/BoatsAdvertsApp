define(['knockout', 'text!components/bank/modal-control.html'], function (ko, templateString) {

    function modalViewModal(params) {
        var self = this;

        //var firstTemplateData = {
        //    text: 'First template',
        //    label: ko.observable('Observable label')
        //};

        //var secondTemplateData = {
        //    text: 'Second template',
        //    simpleLabel: 'Simple text label'
        //};

        self.modalVisible = ko.observable(false);

        self.show = function () {
            self.modalVisible(true);
        };

        self.headerLabel = ko.observable(params.headerLabel || 'Some header text');
        self.bodyTemplate = ko.observable(params.bodyTemplate || 'firstModalTemplate');

        self.bodyData = ko.computed(function () {
            return params.bodyData;
        });

        self.okText = ko.observable();
      
        self.modalSize = ko.observable(params.modalSize || 'modal-lg');
    }

    return {
        template: templateString,
        viewModel: modalViewModal
    }

})
//----------------------------------------------------------------------------------------------
//define(['knockout', 'text!components/bank/modal-control.html'], function (ko, templateString) {

//    function modalViewModal(params) {
//        var self = this;

//        self.showModal = ko.observable(false);
//        self.btnText = ko.observable(params.btnText || 'Text');
//        self.headerText = ko.observable(params.headerText || 'Nagłówek modala');
//        self.ModalId = ko.observable(params.ModalId || 'modalId');
//        self.bodyTemplate = ko.observable(params.bodyTemplate || 'Mateo');
//        self.footerTemplate = ko.observable(params.footerTemplate || 'Foorer text');

//        self.shouldShowModal = function () {
//            self.showModal(true);
//        }
//    }

//    return {
//        template: templateString,
//        viewModel: modalViewModal
//    }

//})
