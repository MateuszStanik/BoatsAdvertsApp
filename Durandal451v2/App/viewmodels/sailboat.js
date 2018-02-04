define(['plugins/router', 'durandal/app', 'jquery', 'knockout'],
    function (router, app, $, ko) {
    return function () {
        this.AdvertName = ko.observable();
        this.BoatModel = ko.observable();
        this.YachtType = ko.observable();
        this.ProducentName = ko.observable();
        this.BuiltYear = ko.observable();
        this.RudderType = ko.observable();
        this.Length = ko.observable();
        this.Beam = ko.observable();
        this.Weight = ko.observable();
        this.Price = ko.observable();
        this.AdvertDescription = ko.observable();
        this.Name = ko.observable();
        this.SureName = ko.observable();
        this.Email = ko.observable();
        this.City = ko.observable();
        this.AdditionalInformation = ko.observable();
    };
});
