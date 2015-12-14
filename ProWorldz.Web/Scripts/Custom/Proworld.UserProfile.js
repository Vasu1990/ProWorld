var profileVM = {};

(function (viewModel) {

    viewModel.LoadUserData = function () {

        proWorld.AjaxHelper.GetCall('/Home/LoadUserProfileDetail/' + UserId, onSuccess);

        function onSuccess(response) {
            alert("hi")
        }
    }
    viewModel.LoadUserData();

})(profileVM);