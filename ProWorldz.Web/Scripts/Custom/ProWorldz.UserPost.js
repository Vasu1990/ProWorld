var proWorld = window.proWorld || {};
proWorld.userPost = proWorld.userPost || {};


proWorld.userPost.hideMessage = function (data) {
    $(data).hide("slow")
}

proWorld.userPost.initCkEditor = function () {
    CKEDITOR.replace('editor1');
}

proWorld.userPost.initCkEditor();
