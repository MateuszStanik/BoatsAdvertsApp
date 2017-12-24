define(['jquery', 'jquery.utilities'],
    function ($) {
        // Routes
        var baseUrl = $.getBasePath(),
        getCategoriesDictionaryUrl = baseUrl + "api/Advert/GetDicCategories",      
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
            getCategoriesDictionary: getCategoriesDictionary,
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

        function getCategoriesDictionary() {
            return $.ajax(getCategoriesDictionaryUrl, {
                type: "GET",
                cache: false,
                headers: getSecurityHeaders()
            });
        }
});