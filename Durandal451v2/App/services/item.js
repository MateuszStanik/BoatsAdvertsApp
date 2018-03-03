define(['jquery', 'jquery.utilities'],
    function ($) {
        // Routes
        var baseUrl = $.getBasePath(),
        getItemDetailsUrl = baseUrl + "api/Item/GetItemDetails",
        getItemImagesUrl = baseUrl + "api/Item/GetItemImages",
        siteUrl = baseUrl;

        // Other private operations
        function getSecurityHeaders() {
            var accessToken = sessionStorage["accessToken"] || localStorage["accessToken"];

            if (accessToken) {
                return { "Authorization": "Bearer " + accessToken };
            }

            return {};
        }

        var advertService = {
            getItemDetails: getItemDetails,
            getItemImages: getItemImages,
            returnUrl: siteUrl,
        };

        $.ajaxPrefilter(function (options, originalOptions, jqXHR) {
            jqXHR.failJSON = function (callback) {
                jqXHR.fail(function (jqXHR, textStatus, error) {
                    var data;

                    try {
                        data = $.parseJSON(jqXHR.responseText);
                    }
                    catch (e) {
                        data = null;
                    }

                    callback(data, textStatus, jqXHR);
                });
            };
        });

        return advertService;

        function getItemDetails(data) {
            return $.ajax(getItemDetailsUrl, {
                type: "GET",
                data: data,
                cache: false,
                headers: getSecurityHeaders()
            });
        }

        function getItemImages(data) {
            return $.ajax(getItemImagesUrl, {
                type: "GET",
                data: data,
                cache: false,
                headers: getSecurityHeaders()
            });
        }
    });