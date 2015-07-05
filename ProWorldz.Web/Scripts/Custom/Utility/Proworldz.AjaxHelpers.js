proWorld.AjaxHelper = proWorld.AjaxHelper || {};

//Ajax Get Call
proWorld.AjaxHelper.GetCall = function (fullUrl, callbackFunction) {
    $.ajax({
        url: fullUrl,
        cache: false,
        success: function (data) {
            callbackFunction(aAbloy.keyDash.Utils.GetJson(data));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};

//Ajax Post Call
proWorld.AjaxHelper.AjaxPostCall = function (fullUrl, dataObj, callbackFunction) {
    $.ajax({
        url: fullUrl,
        cache: false,
        type: 'post',
        data: dataObj,
        success: function (data) {
            callbackFunction(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};
