﻿define(['plugins/router', 'knockout', 'durandal/system', 'services/item', 'services/logger', 'pgwslider'], function (router, ko, system, item, logger) {
    var masterVm = ko.observable();

  
    var vm = {
   
        activate: activate,
        deactivate: deactivate,
        masterVm: masterVm,
        model: ko.observable({}),

        attached: function () {

           


            $('.pgwSlideshow').pgwSlideshow({
                maxHeight: 800,
                transitionEffect: 'fading'
            });
        }
    };

    return vm;

    function activate(id) {
        system.log('Master View ' + id + ' Activated');
        return loadObservables(id);
       
    }

    function deactivate() {
        system.log('Master View ' + masterVm().id + ' Deactivated');
    }

    function loadObservables(id) {
        masterVm({ id: id, name: 'Master' });

        item.getItemDetails({
            subjectId: id,
        }).done(function (data) {
            vm.model(data);
            console.log('Zapisano dane z DB');
            console.log(data);
            logger.log({
                message: "Pobrano dane z bazy.",
                showToast: true,
                type: "info"
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
                    message: "Błąd podczas pobierania danych!",
                    data: "",
                    showToast: true,
                    type: "error"
                });
            }
        });
    }
});