//var UserDashboardVM = {};
//UserDashboardVM.PostComment = function (data) {
//    alert();
//    console.log(data);
//    ko.applyBindings(UserDashboardVM, $("#dashBoardWrapper")[0]);
//}

(function DashBoardVMMethods(dashVm) {
    dashVm.PostComment = function (data) {
        alert();
        console.log(data);
    }

    ko.applyBindings(dashVm, $("#dashBoardWrapper")[0]);

})(UserDashboardVM)


