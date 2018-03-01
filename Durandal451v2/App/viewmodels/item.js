define(['plugins/router', 'knockout', 'durandal/system', 'fotorama'], function (router, ko, system) {
    var masterVm = ko.observable();

  
    var vm = {
   
        activate: activate,
        deactivate: deactivate,
        masterVm: masterVm,

        attached: function () {
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
    }
});