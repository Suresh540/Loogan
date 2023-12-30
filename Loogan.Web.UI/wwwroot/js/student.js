var student = (function () {
    var public = {};
    public.addfavourite = function (ctrl) {
        var src = $(ctrl).prop('src');
        if (src.indexOf('starfull.png') != -1) {
            $(ctrl).removeAttr('src');
            $(ctrl).prop('src', '/images/star.png');
            $(ctrl).prop('title', localizationLib.getLocalizeData("AddFavoriteKey"));
            Alert(localizationLib.getLocalizeData("RemovedFromFavoriteKey"), 'Success');
        } else {
            $(ctrl).removeAttr('src');
            $(ctrl).prop('src', '/images/starfull.png');
            $(ctrl).prop('title', localizationLib.getLocalizeData("RemoveFavoriteKey"));
            Alert(localizationLib.getLocalizeData("AddFavoriteKey"), 'Success');
        }
    }
    return public;
})();
