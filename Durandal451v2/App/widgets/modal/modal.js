define(['knockout', 'text!components/bank/modal-control.html'], function (ko, templateString) {

    function modalViewModal(params) {
        var self = this;
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

