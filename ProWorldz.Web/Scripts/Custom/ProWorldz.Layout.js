
var LayoutVM = {};

(function (vm) {

    vm.friendInfo = ko.observableArray();
    vm.allFriendsInfo = ko.observableArray();
    vm.chatBoxes = ko.observable();
    

    // Enabling Popover Friend request - JS (hidden content and title capturing)
    $("#popoverFriendrequest").popover({
        html: true,
        content: function () {
            return $('#popoverFriendrequestContent').html();
        },
        placement: "bottom",
        title: function() {
            return $('#popoverFriendrequestTitle').html();
        }
    }).click(function() {
        $(".freindRequestBox.navbarUser").each(function () {
            ko.cleanNode(this);
            ko.applyBindings(vm, this); //refresh bindings for dynamic functions to work
        });
    });

    //get friend requests to show in notification bar
    function onSuccessGetFrndRequest(data) {
        vm.friendInfo(ko.mapping.fromJS(data)());
    }
    proWorld.AjaxHelper.GetCall("/Home/GetFriendequests", onSuccessGetFrndRequest);

    //get list of all friends for chat bar
    function onSuccessGetAllFriends(data) {
        vm.allFriendsInfo(ko.mapping.fromJS(data)());
        console.log(vm.allFriendsInfo());
    }

    function getAllChatFrnds() {
        proWorld.AjaxHelper.GetCall("/Home/GetAllFriends", onSuccessGetAllFriends);
    };

    getAllChatFrnds();

//flag to check if user is online while binding list
    vm.isOnline = function (data) {
        return data.IsOnline() === true ? "online" : "offline";
    };

    //accept/reject friend request from notification bar
    vm.AcceptFriend = function (data) {
        function onSuccessConfirmFriend(responseData) {
            vm.friendInfo.remove(data);
            alert("Congratulations! You have made a new friend.");
            
            if (vm.friendInfo().length == 0) {
                $('.popover').popover('hide');
            }
        }

        proWorld.AjaxHelper.AjaxPostCallNoType("/Home/ConfirmRequest", data, onSuccessConfirmFriend);
    }
    vm.RejectFriend = function (data) {
        function onSuccessDeleteFriend(responseData) {
            vm.friendInfo.remove(data);
            alert("Friend request rejected");

            if (vm.friendInfo().length == 0) {
                $('.popover').popover('hide');
            }
        }

        proWorld.AjaxHelper.AjaxPostCallNoType("/Home/DeleteFriend", data, onSuccessDeleteFriend);
    }

    vm.friendInfo.subscribe(function (changes) {

        getAllChatFrnds();

    }, null, "arrayChange");


    //////CHAT HUB CLIENT CODE///////////////

    //custom array to add chat boxes
    vm.chatObjectArray = ko.observableArray();

    //cretae instance for chat hub
    var chat = $.connection.chatHub;

    ////on chat hub load
    $.connection.hub.start().done(function () {
        chat.server.createAuth();  //add current user to SignalR context
    });


    //add chat box when user clicks on a friend from friend list
    vm.CreateChatBox = function (data) {
        console.log(data);


        var chatBoxIdUser = data.UserId() + data.FriendName();//if user clicks again on same frnd
        var chatBoxIdFriend = data.FriendId() + data.UserName();//if friend clicks again user

        var chatBoxArrLen = vm.chatObjectArray().length;
        if (chatBoxArrLen > 0) {//means you have people you are chatting with
            for (var i = 0; i < chatBoxArrLen; i++) {
                if (vm.chatObjectArray()[i].chatBoxId() === chatBoxIdUser || vm.chatObjectArray()[i].chatBoxId() === chatBoxIdFriend) {
                    alert("already chatting");
                    return;
                }
            }
        }

        var chatObject = {
            chatHostId: ko.observable(data.UserId()),
            chatHostName: ko.observable(data.UserName()),
            chatMsgBoxtext: ko.observable(),
            chatMessageList: ko.observableArray([]),
            chatFriendName: ko.observable(data.FriendName()),
            chatBoxId: ko.observable(chatBoxIdUser),
            chatFriendId: ko.observable(data.FriendId()),
            chatFriendImage: ko.observable(data.FriendImage()),
            chatHostImage: ko.observable(),
            chatMessage: ko.observable()
        }

        vm.chatObjectArray.push(chatObject);

        //var chatBox = $("#chatBox").html();
        //$(".footer").append(chatBox);
        //$(".footer.navbarUser").each(function () {
        //        ko.cleanNode(this);
        //        ko.applyBindings(vm, this);
        //});
    }



    //send chat message to other user
    vm.SendChatMessage = function (data) {

        if (data.chatMsgBoxtext() != undefined && data.chatMsgBoxtext() != "") {

            var chatMessage = data.chatHostName() + " : " + ko.toJS(data.chatMsgBoxtext);
            var msgObj = { "chatMessage": chatMessage, "chatMsgDateTime": getCurretnDate(), chatterId: data.chatHostId() }
            data.chatMessage = msgObj;

            data.chatMessageList.push(msgObj); //push to chat list array to display on user screen

            data.chatMsgBoxtext("");//clear chat input text
            var model = ko.toJS(data);
            console.log(model);
            // Call the Send method on the hub.
            chat.server.sendChatMessage(model);
        } else {
            alert("please enter a chat message");
        }
    }


    //append chat box on user to which new chat is sent
    chat.client.appendChatBoxOnFriend = function (chatDetail) {

        var chatObject = ko.mapping.fromJS(chatDetail);
        console.log(chatObject);


        var chatBoxArrLen = vm.chatObjectArray().length;
        if (chatBoxArrLen > 0) {


            var chatBoxIdUser = chatObject.chatFriendId() + chatObject.chatHostName();//if user clicks again on same frnd
            var chatBoxIdFriend = chatObject.chatHostId() + chatObject.chatFriendName();//if friend clicks again user

            //create temporary mesage object to push into chat box
            var msgObject = {
                chatMessage: chatDetail.chatMessage.chatMessage,
                chatMsgDateTime: chatDetail.chatMessage.chatMsgDateTime,
                chatterId: chatDetail.chatMessage.chatterId
            }
            var chatBoxExists = false;

            for (var i = 0; i < chatBoxArrLen; i++) {
                //check if a chatbox with the passed id exists on the UI
                if (vm.chatObjectArray()[i].chatBoxId() === chatBoxIdUser || vm.chatObjectArray()[i].chatBoxId() === chatBoxIdFriend) {
                    vm.chatObjectArray()[i].chatMessageList.push(msgObject);
                    chatBoxExists = true;
                }
            }

            //append a chatbox on screen if it does not exists
            if (!chatBoxExists) {
                vm.chatObjectArray.push(chatObject);

                //CreateChatBox
                var chatBox = $("#chatBox").html();
                $(".footer").append(chatBox);
                $(".footer.navbarUser").each(function () {
                    ko.cleanNode(this);
                    ko.applyBindings(vm, this); //refresh bindings for dynamic functions to work
                });
            }

        } else {
            vm.chatObjectArray.push(chatObject);
        }

    };


    //get template to append the chat mesage in comment box
    vm.SelectedTemplate = function (userId, chatterId) {
        return userId() === chatterId ? "right" : "left";
    }

    //close  chat box
    vm.closeCurrentBox = function (data) {
        vm.chatObjectArray.remove(data);
    }

    //minimise chat box
    vm.minimiseCurrentBox = function (data, event) {
        var clickedBox = $(event.target);
        $(clickedBox).closest('div.chatBox').next('div').toggle();
        $(clickedBox).closest('div.panel-default').toggleClass('minimise');
    }
    /////////////END CHAT HUB CODE///////////////


    // apply binding on structure like this
    /*
        <div class="navBarUser"></div>
        <div></div>
        <div class="navBarUser"></div>
    omit the center div
    */
    $(".navbarUser").each(function () {
        ko.applyBindings(vm, this);
    });
})(LayoutVM);

