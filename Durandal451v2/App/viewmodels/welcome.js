define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'smartWizard', 'select2'],
    function (router, app, $, ko) {
    var vm = {
        attached: function () {

            $('#test').select2();
            
        },
    };
    return vm;
});