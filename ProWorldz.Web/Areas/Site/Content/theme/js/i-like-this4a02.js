function likeThis(postId) {
	if (postId != '') {
		jQuery('#iLikeThis-'+postId+' .likes-count').text('...');
		
		jQuery.post(templateDir + "/inc/like/like.php",
			{ id: postId },
			function(data){
				jQuery('#iLikeThis-'+postId+' .likes-count').text(data);
				jQuery('#iLikeThis-'+postId+' a').replaceWith('<i class="fa fa-heart"></i>');
			});
	}
}