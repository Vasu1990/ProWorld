var FriendsVM = {};
(function (vm) {
    var TotalFriends = 0;
    var globalOptions;
    var globalCallback;

    vm.FriendModel = ko.observable(0);
    vm.CurrentGridTemplate = function () {
        return 'peopleGridTemplate';
    }
    vm.addFriend = function (data) {
        proWorld.AjaxHelper.AjaxPostCallNoType("/Home/AddFriend", data, OnSuccessAddFriend);

        function OnSuccessAddFriend(responseData) {
            alert("Friend request sent successfully");
            vm.dataSource(globalOptions, globalCallback);
        }
    }

    vm.removeFriend = function (data) {
        proWorld.AjaxHelper.AjaxPostCallNoType("/Home/DeleteFriend", data, OnSuccessDeleteFriend);

        function OnSuccessDeleteFriend(responseData) {
            alert("Friend removed successfully");
            vm.dataSource(globalOptions, globalCallback);
        }
    }
    //most important function that fetch the data for the data table
    vm.dataSource = function (options, callback) {
        globalOptions = options;
        globalCallback = callback

        var dataFormCollection = {
            SearchUser: "",
            GlobalSearchText: { value: "" },
            RecordsToTake: 0,
            RecordsToSkip: 0,
            Columns: {
                ColumnName: "",
                IsSorted: true,
                SortOrder: "asc",
                SearchText: "",
                IsSearchable: true,
                SortDirection: ""
            }
        }
        dataFormCollection = options;

        var _data = JSON.stringify(dataFormCollection);

        proWorld.AjaxHelper.GetCall("/Home/GetTotalFriendCount", OnSuccessGetFreiendCount);

        function OnSuccessGetFreiendCount(totalCount) {
            TotalFriends = totalCount;
            proWorld.AjaxHelper.AjaxPostCall("/Home/GetFriends", _data, OnSuccessGetFriends);
            function OnSuccessGetFriends(responseData) {
                var result = {
                    Data: responseData, //data to be bound to the table
                    TotalRecords: TotalFriends, //this should be returned in your result as total no of records that exists
                    DisplayedRecords: TotalFriends //total records been displayed
                }
                vm.FriendModel(responseData.length);
                callback(result); //required by the plugin
            }
        }
    }

    ko.applyBindings(vm, document.getElementById("wrapTemplate"));

})(FriendsVM);