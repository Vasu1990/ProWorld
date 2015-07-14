jQuery(function($) {
    jQuery('#contact').validate({
        rules: {
            contactName: {
                required: true
            },
            email: {
                required: true,
                email: true
            },
            message: {
                required: true
            },
            answer: {
                required: true,
                answercheck: true
            }
        },
        messages: {
            name: {
                required: "Come on, you have a name don’t you?"
            },
            email: {
                required: "No email, no message."
            },
            message: {
                required: "You have to write something to send this form."
            },
            answer: {
                required: ""
            }
        },
        submitHandler: function(form) {
            jQuery('#contact .input-submit').css('display', 'none');
            jQuery('#contact .submit-loading').css('display', 'block');
            jQuery(form).ajaxSubmit({
                type: "POST",
                data: jQuery(form).serialize(),
                url: 'http://alexgurghis.com/themes/wpjobus/wp-admin/admin-ajax.php',
                success: function(data) {
                    jQuery('#contact :input').attr('disabled', 'disabled');
                    jQuery('#contact').fadeTo("slow", 0, function() {
                        jQuery('#contact').css('display', 'none');
                        jQuery(this).find(':input').attr('disabled', 'disabled');
                        jQuery(this).find('label').css('cursor', 'default');
                        jQuery('#success').fadeIn();
                    });
                },
                error: function(data) {
                    jQuery('#contact').fadeTo("slow", 0, function() {
                        jQuery('#error').fadeIn();
                    });
                }
            });
        }
    });
});
