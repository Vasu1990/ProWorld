
proWorld.userPost = proWorld.userPost || {};


proWorld.userPost.BindUIevents = function () {

    $('#divPost').hide();
    CKEDITOR.replace('editor1');
    //CKEDITOR.replace('editor2');
    $("#createPost").click(function() {
        $('#divPost').toggle("slow");
    });

}

proWorld.userPost.hideMessage = function (data) {
    $(data).hide("slow");
}

proWorld.userPost.BindUIevents();