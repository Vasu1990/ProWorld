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
        $('#ddlCity').find('option:gt(0)').remove();
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
    $("#hdCommunityName").val($('#ddlCommunity :selected').text())
    $("#hdSubCommunityName").val($('#ddlSubCommunity :selected').text())
    $.get('/Account/GetSubCommunityByCommunity/' + Id, function (data) {
        debugger;
        $('#ddlSubCommunity').find('option:gt(0)').remove();
        $(data).each(function (index, value) {
            var newOption = $('<option value="' + value.Id + '">' + value.Name + '</option>');
            $('#ddlSubCommunity').append(newOption);
        });
    })

}

function ChangeSubCommunity(Id) {
    debugger;
    $("#hdSubCommunityName").val($('#ddlSubCommunity :selected').text())


}

function checkMail(value) {
   
    console.log(value)
    proWorld.AjaxHelper.GetCall("/Home/CheckMail?email="+value , OnSuccessGetCheckMail);
    function OnSuccessGetCheckMail(data) {
        debugger;
        if (data) {
            $("#txtEmail").val("");
            alert("Email Already Exist.")

        }

       
    }
}


$('.form_date').datetimepicker({
    format: "dd MM yyyy",
    startDate: "1970-02-02",

    todayBtn: 1,
    language: 'fr',
    weekStart: 1,
    
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    minView: 2,
    forceParse: 0,
    showMeridian: 0


});