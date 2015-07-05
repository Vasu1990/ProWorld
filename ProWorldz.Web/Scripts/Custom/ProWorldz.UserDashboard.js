
(function DashBoardVMMethods(dashVM) {
    
    var commentEle = {};
    var commentStrip = {};
    var editCommentControls = {};
    var postCommentButton = {};
    var commentTextBox = {};

    function SetGlobalElements(clickedEditIcon) {

        commentEle = $(clickedEditIcon).closest("div[data-container='comment-controls']").siblings("[data-control='text-comment']");
        commentStrip = commentEle.closest("ul.comment-box").first('[data-container="comment-strip"]');
        var _commentBox = commentStrip.closest('[data-container="comment-box"]');
        editCommentControls = _commentBox.siblings().find("[data-control='edit-comment-controls']");
        postCommentButton = _commentBox.siblings().find("[data-control='post-comment-control']");
        commentTextBox = _commentBox.siblings().find(".txtUserComment");
    }

    dashVM.PostComment = function(data,event) {
        //get comment value
        var _commentText = $(event.target).closest('div.input-group').find('input.txtUserComment').val();
    
        if (_commentText != "") {
            $(event.target).closest('div.input-group').find('input.txtUserComment').val("");
            
            //var ele = $(event.target).closest('input.txtUserComment').val();
            //this is not working because input is not the parent of event.target 
            //closest() traverses up through its ancestors only http://stackoverflow.com/questions/16705266/jquery-cant-get-closest-to-search-up-dom-tree

            //create local object to push in array
            var _commentObj = {
                Comment: ko.observable(_commentText),
                PostId: ko.observable(data.Id()),
                ImageUrl: ko.observable(data.ImageUrl()),
                CreationDate: ko.observable(""),
                Id: ko.observable(0),
                UserName:ko.observable("")
            }

            //cast ko model to json and post request
            var _commentBM = ko.toJS(_commentObj)
            proWorld.AjaxHelper.AjaxPostCall("/Home/PostComment", _commentBM, OnSuccessInsertComment);

            //Insert into list after success
            function OnSuccessInsertComment(result) {
                _commentObj.UserName(result.UserName);
                _commentObj.CreationDate(result.CreationDate);
                _commentObj.PostId(result.PostId);
                _commentObj.Id(result.Id);
                data.UserComments.push(_commentObj);
            }
            
        }
    }

    dashVM.DeleteComment = function (_commentObj) {

        ko.utils.arrayForEach(dashVM.UserPostList(), function (post) {
            if (post.Id() == _commentObj.PostId()) {
                    var _commentBM = ko.toJS(_commentObj)
                    proWorld.AjaxHelper.AjaxPostCall("/Home/DeleteComment", _commentBM, OnSuccessDeleteComment);
                    function OnSuccessDeleteComment() {
                        post.UserComments.remove(_commentObj);
                    }
                }
            });

           
            
    }
    dashVM.StartEditComment = function (_commentObj, event) {
        
        //if clicking edit when already editing a comment reset the previous
        if (commentStrip instanceof jQuery) {
            dashVM.CancelEditComment();
        }

        //set global elements for access
        SetGlobalElements(event.target);

         
        ///select ele and get n set text in comment box
         var _commentText = commentEle.text();
         commentTextBox.val(_commentText);

        //hide comment till in edtitng mode
        commentStrip.hide();
        
        //hide show controls
        editCommentControls.removeClass("hidden");
        postCommentButton.hide();
        
    }
    
    dashVM.EditComment = function (_commentBM) {
        console.log(_commentBM);
       // proWorld.AjaxHelper.AjaxPostCall("/Home/EditComment", _commentBM, OnSuccessEditComment);
        

        function OnSuccessEditComment() {
            dashVM.CancelEditComment();
        }
        
        
        //ko.utils.arrayForEach(dashVM.UserPostList(), function (post) {
        //    if (post.Id() == _commentObj.PostId()) {
        //        var _commentBM = ko.toJS(_commentObj)
        //        proWorld.AjaxHelper.AjaxPostCall("/Home/DeleteComment", _commentBM, OnSuccessDeleteComment);
        //        function OnSuccessDeleteComment() {
        //            post.UserComments.remove(_commentObj);
        //        }
        //    }
        //});
    }
    dashVM.CancelEditComment = function () {

        //show comment back
        commentStrip.show();

        //hide show controls
        editCommentControls.addClass("hidden");
        postCommentButton.show();

        //reset comment box
        commentTextBox.val("");
    }


    ko.applyBindings(dashVM, $("#dashBoardWrapper")[0]);

})(UserDashboardVM)


