
(function DashBoardVMMethods(dashVM) {
    
    var commentEle = {};
    var commentStrip = {};
    var editCommentControls = {};
    var postCommentButton = {};
    var commentTextBox = {};
    var CommentToBeUpdted = {};
    

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
                CreationDate: "",
                Id: ko.observable(0),
                UserName: ko.observable(""),
                UserId: ko.observable(0),
                ModificationDate: ko.observable(""),
                CreatedBy: ko.observable(0),
                ModifiedBy: ko.observable("")
            }

            //cast ko model to json and post request
            var _commentBM = ko.toJS(_commentObj)
            proWorld.AjaxHelper.AjaxPostCall("/Home/PostComment", _commentBM, OnSuccessInsertComment);

            //Insert into list after success
            function OnSuccessInsertComment(result) {
                _commentObj.UserName(result.UserName);
                _commentObj.UserId(result.UserId);
                _commentObj.CreatedBy(result.UserId);
                _commentObj.ModifiedBy(result.UserId);
                _commentObj.ModificationDate(result.ModificationDate);
                //date issue http://www.devcurry.com/2013/04/json-dates-are-different-in-aspnet-mvc.html#.Ufvl1Y3VD6Q
                _commentObj.CreationDate = new Date(parseInt(result.CreationDate.replace(/\/Date\((.*?)\)\//gi, "$1")));
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
        
        CommentToBeUpdted = _commentObj;
        console.log(CommentToBeUpdted);
        //if clicking edit when already editing a comment reset the previous
        if (commentStrip instanceof jQuery) {
            dashVM.CancelEditComment();
        }

        //set global elements for access
        SetGlobalElements(event.target);

         
        ///select ele and get n set text in comment box
        var _commentText = commentEle.text();
        commentTextBox.focus();
         commentTextBox.val(_commentText);

        //hide comment till in edtitng mode
        commentStrip.hide();
        
        //hide show controls
        editCommentControls.removeClass("hidden");
        postCommentButton.hide();
        
    }
    
    dashVM.EditComment = function () {
        console.log(commentTextBox.val());
        CommentToBeUpdted.Comment(commentTextBox.val());
        proWorld.AjaxHelper.AjaxPostCall("/Home/EditComment", CommentToBeUpdted, OnSuccessEditComment);
        
        function OnSuccessEditComment(data) {
            ko.utils.arrayForEach(dashVM.UserPostList(), function (post) {
                if (post.Id() == data.PostId) {
                    var mapping = {
                        key: function (data) {
                            return ko.utils.unwrapObservable(data.Id);
                        },
                        create: function (options) {
                            var innerModel = ko.mapping.fromJS(options.data);
                            return innerModel;
                        }
                    }
                    ko.mapping.fromJS(data, mapping, post.UserComments);
                }
            });

            dashVM.CancelEditComment();
        }
        
       
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

    dashVM.IsCommentOwner = function (CommentCreator,CurrentUser) {
        return CommentCreator() === CurrentUser();
    }

    ko.applyBindings(dashVM, $("#dashBoardWrapper")[0]);

})(UserDashboardVM)


