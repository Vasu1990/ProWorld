function LoadCommunity(Id) {

    $.get('/Account/GetCommunityByCountry/' + Id, function (data) {
        debugger;
        $('#ddlCommunity').find('option:gt(0)').remove();
        $(data).each(function (index, value) {
            var newOption = $('<option value="' + value.Id + '">' + value.Name + '</option>');
            $('#ddlCommunity').append(newOption);
        });
    })
    $.get('/Account/GetStateByCountry/' + Id, function (data) {
        debugger;
        $('#ddlState').find('option:gt(0)').remove();
        $(data).each(function (index, value) {
            var newOption = $('<option value="' + value.StateId + '">' + value.Name + '</option>');
            $('#ddlState').append(newOption);
        });
    })
}

function LoadCity(Id) {
    debugger;
    $.get('/Account/GetCityByState/' + Id, function (data) {
        $('#ddlCity').find('option:gt(0)').remove();
        $(data).each(function (index, value) {
            var newOption = $('<option value="' + value.Id + '">' + value.Name + '</option>');
            $('#ddlCity').append(newOption);
        });
    })

}

function LoadSubCommunity(Id) {
    debugger;
    $.get('/Account/GetSubCommunityByCommunity/' + Id, function (data) {
        debugger;
        $('#ddlSubCommunity').find('option:gt(0)').remove();
        $(data).each(function (index, value) {
            var newOption = $('<option value="' + value.Id + '">' + value.Name + '</option>');
            $('#ddlSubCommunity').append(newOption);
        });
    })

}