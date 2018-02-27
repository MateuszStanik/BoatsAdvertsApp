requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'knockout': '../Scripts/knockout-2.3.0',
        'knockout.validation': '../Scripts/knockout.validation',
        'bootstrap': '../Scripts/bootstrap',
        'jquery': '../Scripts/jquery-3.3.1',
        'jquery.utilities': '../Scripts/jquery.utilities',
        'toastr': '../Scripts/toastr',
        'smartWizard': '../Scripts/jquery.smartWizard',
        'select2': '../Scripts/select2',
        'materialize': '../Scripts/materialize/materialize',
        'dropzone': '../Scripts/dropzone/dropzone-amd-module',
        //"jQueryInputmask": "../Scripts/jquery.inputmask/jquery.inputmask",
        "inputmask": "../Scripts/jquery.inputmask.bundle",
    },
    shim: {
        'jquery.utilities': {
            deps: ['jquery']
        },
        'select2': {
            deps: ['jquery']
        },
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        },
        'knockout.validation': {
            deps: ['knockout']
        },
        'smartWizard':{
            deps: ['jquery'],
        },
        "smartWizard": {
            "exports": 'smartWizard'
        },
        'materialize': {
            deps: ['jquery'],
        },
        'dropzone': {
            deps: ['jquery']
        },
        'inputmask': {
            deps: ['jquery'],
            exports: 'Inputmask'
        },
    }
});

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'durandal/composition', 'global/session', 'knockout', 'knockout.validation'],
    function (system, app, viewLocator,composition, session, ko) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Durandal 451';

    app.configurePlugins({
        
        router: true,
        dialog: true,
        widget: {
            kinds: ['contact']
            //kinds: ['sailboat', 'sailboatSummarize', 'motorBoat', 'motorBoatSummarize', 'contact', 'contactSummarize']
        },
        
    });

    composition.addBindingHandler('hasFocus');

    composition.addBindingHandler('inputmask', {
        init: function (element, valueAccessor, allBindingsAccessor) {

        var mask = valueAccessor();

        var observable = mask.value;

        if (ko.isObservable(observable)) {

            $(element).on('focusout change', function () {

                if ($(element).inputmask('isComplete')) {
                    observable($(element).val());
                } else {
                    observable(null);
                }

            });
        }

        $(element).inputmask(mask);


        },
        update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var mask = valueAccessor();

        var observable = mask.value;

        if (ko.isObservable(observable)) {

            var valuetoWrite = observable();

            $(element).val(valuetoWrite);
        }
    }
    });
    composition.addBindingHandler('select2', {
        init: function (el, valueAccessor, allBindingsAccessor, viewModel) {
            ko.utils.domNodeDisposal.addDisposeCallback(el, function () {
                $(el).select2('destroy');
            });

            var allBindings = allBindingsAccessor(),
                select2 = ko.utils.unwrapObservable(allBindings.select2);

            $(el).select2(select2);
        },
        update: function (el, valueAccessor, allBindingsAccessor, viewModel) {
            var allBindings = allBindingsAccessor();

            if ("value" in allBindings) {
                if ((allBindings.select2.multiple || el.multiple) && allBindings.value().constructor != Array) {
                    $(el).val(allBindings.value().split(',')).trigger('change');
                }
                else {
                    $(el).val(allBindings.value()).trigger('change');
                }
            } else if ("selectedOptions" in allBindings) {
                var converted = [];
                var textAccessor = function (value) { return value; };
                if ("optionsText" in allBindings) {
                    textAccessor = function (value) {
                        var valueAccessor = function (item) { return item; }
                        if ("optionsValue" in allBindings) {
                            valueAccessor = function (item) { return item[allBindings.optionsValue]; }
                        }
                        var items = $.grep(allBindings.options(), function (e) { return valueAccessor(e) == value });
                        if (items.length == 0 || items.length > 1) {
                            return "UNKNOWN";
                        }
                        return items[0][allBindings.optionsText];
                    }
                }
                $.each(allBindings.selectedOptions(), function (key, value) {
                    converted.push({ id: value, text: textAccessor(value) });
                });
                $(el).select2("data", converted);
            }
            $(el).trigger("change");
        }
    });
    configureKnockout();
    
    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });

    function configureKnockout()
    {
        ko.validation.init({
            insertMessages: true,
            decorateElement: true,
            errorElementClass: 'has-error',
            errorMessageClass: 'help-block'
        });

        if (!ko.utils.cloneNodes) {
            ko.utils.cloneNodes = function (nodesArray, shouldCleanNodes) {
                for (var i = 0, j = nodesArray.length, newNodesArray = []; i < j; i++) {
                    var clonedNode = nodesArray[i].cloneNode(true);
                    newNodesArray.push(shouldCleanNodes ? ko.cleanNode(clonedNode) : clonedNode);
                }
                return newNodesArray;
            };
        }

        ko.bindingHandlers.ifIsInRole = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                ko.utils.domData.set(element, '__ko_withIfBindingData', {});
                return { 'controlsDescendantBindings': true };
            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var withIfData = ko.utils.domData.get(element, '__ko_withIfBindingData'),
                    dataValue = ko.utils.unwrapObservable(valueAccessor()),
                    shouldDisplay = session.userIsInRole(dataValue),
                    isFirstRender = !withIfData.savedNodes,
                    needsRefresh = isFirstRender || (shouldDisplay !== withIfData.didDisplayOnLastUpdate),
                    makeContextCallback = false;

                if (needsRefresh) {
                    if (isFirstRender) {
                        withIfData.savedNodes = ko.utils.cloneNodes(ko.virtualElements.childNodes(element), true /* shouldCleanNodes */);
                    }

                    if (shouldDisplay) {
                        if (!isFirstRender) {
                            ko.virtualElements.setDomNodeChildren(element, ko.utils.cloneNodes(withIfData.savedNodes));
                        }
                        ko.applyBindingsToDescendants(makeContextCallback ? makeContextCallback(bindingContext, dataValue) : bindingContext, element);
                    } else {
                        ko.virtualElements.emptyNode(element);
                    }

                    withIfData.didDisplayOnLastUpdate = shouldDisplay;
                }
            }
        };
    }
});