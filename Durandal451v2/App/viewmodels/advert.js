define(['plugins/router', 'durandal/app', 'jquery', 'knockout', 'smartWizard', 'select2'],
    function (router, app, $, ko) {
        var smartWizard = require('smartWizard');

        var vm = {           
            attached: function () {
                var elem = document.getElementById('value');
                $('#value').select2();
                $('#smartwizard').smartWizard({
                    selected: 0,
                    theme: 'dots',
                    transitionEffect: 'fade',
                    showStepURLhash: true,
                });
            }
        };
     
        return vm;
    });