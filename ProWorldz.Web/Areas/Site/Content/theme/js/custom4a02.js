/*-----------------------------------------------------------------------------------*/
/*	Custom Script
/*-----------------------------------------------------------------------------------*/

jQuery.validator.addMethod('answercheck', function (value, element) {
    return this.optional(element) || /^\b8\b$/.test(value);
}, "type the correct answer -_-");

jQuery(function($) {
	$(document).ready( function() {

		if(jQuery("#resume-menu").length ) {
		  	//enabling stickUp on the '.navbar-wrapper' class
	        jQuery('#resume-menu').stickUp({
	            parts: {
	                0: 'resume-cover-image',
	                1: 'resume-about-block',
	                2: 'resume-skills-block',
	                3: 'resume-education-block',
	                4: 'resume-experience-block',
	                5: 'resume-portfolio-block',
	                6: 'resume-contact-block'
	            },
	            itemClass: 'menuItem',
	            itemHover: 'active',
	            topMargin: 'auto'
	        });
	    };
	});
});

jQuery(function($) {
	$(document).ready( function() {

		if(jQuery("#company-menu").length ) {
		  	//enabling stickUp on the '.navbar-wrapper' class
	        jQuery('#company-menu').stickUp({
	            parts: {
	                0: 'resume-cover-image',
	                1: 'resume-about-block',
	                2: 'resume-jobs-block',
	                3: 'resume-experience-block',
	                4: 'resume-portfolio-block',
	                5: 'resume-contact-block'
	            },
	            itemClass: 'menuItem',
	            itemHover: 'active',
	            topMargin: 'auto'
	        });

	    };
	});
});

jQuery(function($) {
	$(document).ready( function() {

		if(jQuery("#job-menu").length ) {
		  	//enabling stickUp on the '.navbar-wrapper' class
	        jQuery('#job-menu').stickUp({
	            parts: {
	                0: 'resume-cover-image',
	                1: 'resume-skills-block',
	                2: 'resume-experience-block',
	                3: 'resume-contact-block'
	            },
	            itemClass: 'menuItem',
	            itemHover: 'active',
	            topMargin: 'auto'
	        });

	    };
	});
});


jQuery.noConflict();
jQuery(document).ready(function(){

	jQuery('a.my-account-header-settings-link').click(function(e) {
	    if ( jQuery(".my-account-settings").hasClass('active') ) {
	        jQuery(".my-account-settings").removeClass('active');
	    } else {
        	jQuery(".my-account-settings").addClass('active');
        }
	});

	if (document.getElementsByTagName) {

		var inputElements = document.getElementsByTagName("input");

		for (i=0; inputElements[i]; i++) {

			if (inputElements[i].className && (inputElements[i].className.indexOf("disableAutoComplete") != -1)) {

				inputElements[i].setAttribute("autocomplete","off");

			}

		}

	}

	var fixed = false;
    var topTrigger = jQuery('#header').offset().top;
    jQuery(document).scroll(function() {
        if( jQuery(this).scrollTop() >= topTrigger ) {
            if( !fixed ) {
                fixed = true;
                jQuery('#header').css({'position':'fixed'});
                jQuery('#header').addClass('isStuck');
            }
        } else {
            if( fixed ) {
                fixed = false;
                jQuery('#header').css({'position':'relative'});
                jQuery('#header').removeClass('isStuck');
            }
        }
    });

    jQuery('a[rel="external"]').attr('target', '_blank');

    var owl = jQuery("#owl-demo");
 
  	owl.owlCarousel({
	    navigation : true,
	    singleItem : true,
	    transitionStyle : "goDown",
	    navigationText: [
      		"<i class='fa fa-angle-left arrow-round'></i>",
      		"<i class='fa fa-angle-right arrow-round'></i>"
      	]
  	});


	jQuery('.recipe-search-go-btn').click(function(e) { // run the submit function, pin an event to it
        if (jQuery('input#recipe-search-keyword:text').val().length == 0) { // if s has no value, proceed
            e.preventDefault(); // prevent the default submission
            alert("Your search is empty!"); // alert that the search is empty
            jQuery('#recipe-search-keyword').focus(); // focus on the search input
        }
    });

    jQuery('#print-button').click( function(){
       	jQuery(".toggle").each(function() {
			jQuery(this).find(".togglebox").css("display","block");
			jQuery(this).find(".trigger").addClass( 'active' );
		});

		jQuery(".cbp-so-section").each(function() {
			jQuery(this).css("opacity","1");
			jQuery(this).css("-moz-opacity","1");
			jQuery(this).css("-khtml-opacity","1");
			jQuery(this).css("filter","alpha(opacity=1)");
		});
    });

    jQuery("#resume-cover-image").each(function() {
    	
		jQuery(this).css("height", jQuery(window).height() - 67);
		
	});

    jQuery(".partners img").css("opacity","0.5");
	jQuery(".partners img").hover(function () {
		jQuery(this).stop().animate({ opacity: 1.0 }, "fast");  
	}, function () {
		jQuery(this).stop().animate({ opacity: 0.5 }, "fast");  
	});

    jQuery(".colored-area").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
	});

	if(jQuery("#single-company").length ) {

		var $headHeight = -(jQuery('#single-company #header').height() + 6);
		jQuery('#single-company #header').css("margin-top", $headHeight)

	}

	if(jQuery("#single-resume").length ) {

		var $headHeight = -(jQuery('#single-resume #header').height() + 6);
		jQuery('#single-resume #header').css("margin-top", $headHeight)

	}

	if(jQuery("#single-job").length ) {

		var $headHeight = -(jQuery('#single-job #header').height() + 6);
		jQuery('#single-job #header').css("margin-top", $headHeight)

	}

	jQuery("#home-wpjobus-stats").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
	});

	jQuery("#home-wpjobus-posts").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
	});

	jQuery("#home-featured-companies").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
	});

	jQuery("#home-testimonials").each(function() {
		
		var $thisItemSlider = jQuery(this);
		var $thisWidthSlider = $thisItemSlider.parents().width();
		var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
		jQuery(this).css("width", jQuery(window).width());
		jQuery(this).css("margin-left",$thisItemLeftSlider);
			
	});

	jQuery("#action-box").each(function() {
		
		var $thisItemSlider = jQuery(this);
		var $thisWidthSlider = $thisItemSlider.parents().width();
		var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
		jQuery(this).css("width", jQuery(window).width());
		jQuery(this).css("margin-left",$thisItemLeftSlider);
			
	});

	jQuery("#home-price-plans").each(function() {
		
		var $thisItemSlider = jQuery(this);
		var $thisWidthSlider = $thisItemSlider.parents().width();
		var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
		jQuery(this).css("width", jQuery(window).width());
		jQuery(this).css("margin-left",$thisItemLeftSlider);
			
	});

	// Tooltip
    jQuery('[data-rel]').each(function() {
      jQuery(this).attr('rel', jQuery(this).data('rel'));
  	});
    
    var targets = jQuery( '[rel~=tooltip]' ),
        target  = false,
        tooltip = false,
        title   = false;
 
    targets.bind( 'mouseenter', function()
    {
        target  = jQuery( this );
        tip     = target.attr( 'title' );
        tooltip = jQuery( '<div id="tooltip"></div>' );
 
        if( !tip || tip == '' )
            return false;
 
        target.removeAttr( 'title' );
        tooltip.css( 'opacity', 0 )
               .html( tip )
               .appendTo( 'body' );
 
        var init_tooltip = function()
        {
            if( jQuery( window ).width() < tooltip.outerWidth() * 1.5 )
                tooltip.css( 'max-width', jQuery( window ).width() / 2 );
            else
                tooltip.css( 'max-width', 340 );
 
            var pos_left = target.offset().left + ( target.outerWidth() / 2 ) - ( tooltip.outerWidth() / 2 ),
                pos_top  = target.offset().top - tooltip.outerHeight() - 20;
 
            if( pos_left < 0 )
            {
                pos_left = target.offset().left + target.outerWidth() / 2 - 20;
                tooltip.addClass( 'left' );
            }
            else
                tooltip.removeClass( 'left' );
 
            if( pos_left + tooltip.outerWidth() > jQuery( window ).width() )
            {
                pos_left = target.offset().left - tooltip.outerWidth() + target.outerWidth() / 2 + 20;
                tooltip.addClass( 'right' );
            }
            else
                tooltip.removeClass( 'right' );
 
            if( pos_top < 0 )
            {
                var pos_top  = target.offset().top + target.outerHeight();
                tooltip.addClass( 'top' );
            }
            else
                tooltip.removeClass( 'top' );
 
            tooltip.css( { left: pos_left, top: pos_top } )
                   .animate( { top: '+=10', opacity: 1 }, 50 );
        };
 
        init_tooltip();
        jQuery( window ).resize( init_tooltip );
 
        var remove_tooltip = function()
        {
            tooltip.animate( { top: '-=10', opacity: 0 }, 50, function()
            {
               	jQuery( this ).remove();
            });
 
            target.attr( 'title', tip );
        };
 
        target.bind( 'mouseleave', remove_tooltip );
        tooltip.bind( 'click', remove_tooltip );
    });

	//When page loads...
	jQuery(".tab_content").hide(); //Hide all content
	jQuery("ul.tabs li:first").addClass("active").show(); //Activate first tab
	jQuery(".tab_content:first").show(); //Show first tab content

	//On Click Event
	jQuery("ul.tabs li").click(function() {

		jQuery("ul.tabs li").removeClass("active"); //Remove any "active" class
		jQuery(this).addClass("active"); //Add "active" class to selected tab

		return false;
	});

	// setup ul.tabs to work as tabs for each div directly under div.panes
	jQuery("ul.tabs").tabs("> .pane", {effect: 'fade', fadeIn: 200});




	// Add tag icon
	jQuery('a[class^="tag-link-"]').each(function() {
        alttxt = jQuery(this).text();
        linkhref = jQuery(this).attr('href');

        jQuery(this).replaceWith(function() { return '<a title="tag: ' +alttxt+ '" href="' +linkhref+ '"><i class="fa fa-tag"></i>'+alttxt+'</a>'; });
    });
	 
	jQuery(window).load(function(){

		jQuery('#pageloader').fadeOut(1000);

		jQuery('.page-container .page-content').fadeTo( 300 , 1);

		jQuery('#featured-ads').fadeTo( 300 , 1);

		jQuery('#featured-ads-author').fadeTo( 300 , 1);

		jQuery('#featured-ads-category').fadeTo( 300 , 1);

		jQuery('li.has-submenu > a').each(function(i, ojb) {
	        jQuery(this).addClass('main-has-submenu');
	    });

	    jQuery('ul.sub-menu li.has-submenu > a').each(function(i, ojb) {
	        if ( jQuery(this).hasClass('main-has-submenu') ) {
	            jQuery(this).removeClass('main-has-submenu').addClass('child-has-submenu');
	        } else {
	        	jQuery(this).addClass('child-has-submenu');
	        }
	    });

		jQuery("li a.main-has-submenu").append("<i class='fa fa-chevron-down'></i>");

		jQuery("li a.child-has-submenu").append("<i class='fa fa-chevron-right'></i>");
		

	});

	jQuery(window).bind('resize', function () {

		jQuery(".colored-area").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
		});

		jQuery("#home-wpjobus-stats").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
		});

		jQuery("#home-wpjobus-posts").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
		});

		jQuery("#home-featured-companies").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
				
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
			
		});

		jQuery("#home-testimonials").each(function() {
		
			var $thisItemSlider = jQuery(this);
			var $thisWidthSlider = $thisItemSlider.parents().width();
			var $thisItemLeftSlider = $thisWidthSlider/2 - jQuery(window).width()/2;
					
			jQuery(this).css("width", jQuery(window).width());
			jQuery(this).css("margin-left",$thisItemLeftSlider);
				
		});

	});

	jQuery('ul.dish-menu-info-odd li').each(function(i) {
		var $li = jQuery(this);
		setTimeout(function() {
		    $li.addClass('wpcrown-start-animation');
		}, i*150); // delay 100 ms
	});

	jQuery('#thumbs a').each(function(i) {
		var $li = jQuery(this);
		setTimeout(function() {
		    $li.addClass('wpcrown-start-animation');
		}, i*150); // delay 100 ms
	});

	jQuery('#thumbs-wrapper-feat-recipes a').each(function(i) {
		var $li = jQuery(this);
		setTimeout(function() {
		    $li.addClass('wpcrown-start-animation');
		}, i*150); // delay 100 ms
	});


	jQuery('.remImage').live('click', function() {

		jQuery(this).parent().parent().fadeOut();
		jQuery(this).parent().find('input').attr('name', 'att_remove[]' );

    });

    jQuery(document).ready(function() {
	    jQuery(".target-blank").attr({"target" : "_blank"})
	});

	jQuery(window).scroll(function() {
		if (jQuery(this).scrollTop() > 200) {
			jQuery('.backtop').fadeIn(200);
		} else {
			jQuery('.backtop').fadeOut(200);
		}
	});

	// scroll body to 0px on click
	jQuery(".backtop a").click(function () {
		jQuery("body,html").animate({
			scrollTop: 0
		}, 800);
		return false;
	});

	jQuery(".backtophome a").click(function () {
		jQuery("body,html").animate({
			scrollTop: 0
		}, 800);
		return false;
	});

	jQuery('#tag-index-page').isotope({
		itemSelector: '.tag-group',
		layoutMode: 'masonry'
	});


  


	// Menu filter
	// actiavte menu sorting
	elem = jQuery("#menu-sort-container");
	if (elem.is (".menu-sort-container")) {
	    jQuery.extend( jQuery.Isotope.prototype, {
	    _customModeReset : function() { 
	      
	        this.fitRows = {
	            x : 0,
	            y : 0,
	            height : 0
	          };
	      
	    },
	    _customModeLayout : function( $elems ) { 
	      
	    	var instance    = this,
	        containerWidth  = this.element.width(),
	        props       = this.fitRows,
	        margin      = 30, //margin based on %
	        extraRange  = 2; // adds a little range for % based calculation error in some browsers
	      
	        $elems.css({visibility:'visible'}).each( function() {
	            var $this = jQuery(this),
	            atomW = $this.outerWidth(),
	            atomH = $this.outerHeight(true);
	            
	            if ( props.x !== 0 && atomW + props.x > containerWidth + extraRange ) {
	              	// if this element cannot fit in the current row
	              	props.x = 0;
	              	props.y = props.height;
	            } 
	          
	        	//webkit gets blurry elements if position is a float value
	        	props.x = Math.round(props.x);
	        	props.y = Math.round(props.y);
	         
	            // position the atom
	            instance._pushPosition( $this, props.x, props.y );
	          
	            props.height = Math.max( props.y + atomH, props.height );
	            props.x += atomW + margin;
	        
	        	jQuery('#menu-sort-container').css({visibility:"visible", opacity:1});
	        	jQuery('#filters').css({visibility:"visible", opacity:1});
	        
	        
	          	});
	      
	      	},
	      	_customModeGetContainerSize : function() { 
	      
	        	return { height : this.fitRows.height };
	      
	     	 	},
	      		_customModeResizeChanged : function() { 
	      
	        		return true;
	        
	       		}
	    	});
	    
	      	var $container = jQuery('#menu-sort-container').css({visibility:"visible", opacity:0});

	    	$container.isotope({
	          	itemSelector : '.isotope-item',
	      		layoutMode : 'customMode'
	        });
	        
	        
	        var $optionSets = jQuery('#blog-post .sort_by_cat'),
	            $optionLinks = $optionSets.find('a');

	        $optionLinks.click(function(){
	          	var $this = jQuery(this);
	          	// don't proceed if already selected
	        if ( $this.hasClass('active_sort') ) {
	            return false;
	        }
	        var $optionSet = $this.parents('.sort_by_cat');
	        $optionSet.find('.active_sort').removeClass('active_sort');
	        $this.addClass('active_sort');
	    
	        // make option object dynamically, i.e. { filter: '.my-filter-class' }
	        var options = {},
	            key = $optionSet.attr('data-option-key'),
	            value = $this.attr('data-option-value');
	        // parse 'false' as false boolean
	        value = value === 'false' ? false : value;
	        options[ key ] = value;
	        if ( key === 'layoutMode' && typeof changeLayoutMode === 'function' ) {
	            // changes in layout modes need extra logic
	            changeLayoutMode( $this, options )
	        } else {
	           	// otherwise, apply new options
	          	$container.isotope( options );
	        }
	          
	        return false;
	    });
	};

	elem = jQuery("#carousel-wrapper");
	if (elem.is (".carousel-wrapper")) {

		jQuery('#carousel').carouFredSel({
			responsive: true,
			circular: false,
			auto: false,
			items: {
				visible: 1
			},
			scroll: {
				fx: 'directscroll'
			}
		});

		jQuery('#thumbs').carouFredSel({
			responsive: true,
			circular: false,
			infinite: false,
			auto: false,
			prev: '#prev',
			next: '#next',
			items: {
				visible: {
					min: 1,
					max: 5
				}
			}
		});

		jQuery('#thumbs a').click(function() {
			jQuery('#carousel').trigger('slideTo', '#' + this.href.split('#').pop() );
			jQuery('#thumbs a').removeClass('selected');
			jQuery(this).addClass('selected');
			return false;
		});

	};


	elem = jQuery("#carousel-wrapper-feat-recipes");
	if (elem.is (".carousel-wrapper-feat-recipes")) {

		jQuery('#carousel-feat-recipes').carouFredSel({
			responsive: true,
			circular: false,
			auto: false,
			direction: "up",
			items: {
				visible: 1
			},
			scroll: {
				fx: 'directscroll'
			}
		});

		jQuery('#thumbs-feat-recipes').carouFredSel({
			responsive: false,
			circular: false,
			infinite: false,
			auto: false,
			prev: '#prev',
			next: '#next',
			direction: "up",
			height: "98",
			items: {
				visible: {
					min: 1,
					max: 5
				}
			}
		});

		jQuery('#thumbs-feat-recipes a').click(function() {
			jQuery('#carousel-feat-recipes').trigger('slideTo', '#' + this.href.split('#').pop() );
			jQuery('#thumbs-feat-recipes a').removeClass('selected');
			jQuery(this).addClass('selected');
			return false;
		});

	};

	jQuery("ul.recipe-ingredients li").click(function (){
     	jQuery(this).toggleClass('active');
	});



	//Toggle
	jQuery(".togglebox").hide();
	//slide up and down when click over heading 2
	
	jQuery("h4.trigger").click(function(){
		
		// slide toggle effect set to slow you can set it to fast too.
		jQuery(this).toggleClass("active").next(".togglebox").slideToggle("slow");
	
		return true;
	
	});

	// slide toggle effect set to slow you can set it to fast too.
	jQuery("h4.trigger.first-element").toggleClass("active").next(".togglebox").slideToggle("slow");



	// Add Skill
	jQuery('#template_criterion').hide();
	jQuery('#submit_add_criteria').on('click', function() {		
		$newItem = jQuery('#template_criterion .option_item').clone().appendTo('#review_criteria').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		var criterionText = (id+1);
		$newItem.find('.skill-item-title span').text(criterionText);

		var nameText = 'wpjobus_resume_skills[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_skills[' + id + '][1]';
		var nameTextEmpty = '';
		$newItem.find('.slider_value').attr('id', nameText).attr('name', nameText).val(nameTextEmpty);

		//event handler for newly created element
		$newItem.children('.button_del_criteria').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	// Delete Step
	jQuery('.button_del_criteria').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});



	// Add Skill
	jQuery('#template_job_criterion').hide();
	jQuery('#submit_add_job_criteria').on('click', function() {		
		$newItem = jQuery('#template_job_criterion .option_item').clone().appendTo('#review_job_criteria').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		var criterionText = (id+1);
		$newItem.find('.skill-item-title span').text(criterionText);

		var nameText = 'wpjobus_job_skills[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_job_skills[' + id + '][1]';
		var nameTextEmpty = '';
		$newItem.find('.slider_value').attr('id', nameText).attr('name', nameText).val(nameTextEmpty);

		//event handler for newly created element
		$newItem.children('.button_del_job_criteria').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	// Delete Step
	jQuery('.button_del_job_criteria').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});




	//ADD LANGUAGE
	jQuery('#template_language').hide();
	jQuery('#submit_add_language').on('click', function() {		
		$newItem = jQuery('#template_language .option_item').clone().appendTo('#resume_languages').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		var criterionText = (id+1);
		$newItem.find('.skill-item-title span').text(criterionText);

		var nameText = 'wpjobus_resume_languages[' + id + '][0]';
		$newItem.find('.resume_lang_title').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_languages[' + id + '][1]';
		$newItem.find('.resume_lang_understanding').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_languages[' + id + '][2]';
		$newItem.find('.resume_lang_speaking').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_languages[' + id + '][3]';
		$newItem.find('.resume_lang_writing').attr('id', nameText).attr('name', nameText);

		//event handler for newly created element
		$newItem.children('.button_del_language').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_language').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD JOB LANGUAGE
	jQuery('#template_job_language').hide();
	jQuery('#submit_add_job_language').on('click', function() {		
		$newItem = jQuery('#template_job_language .option_item').clone().appendTo('#job_languages').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		var criterionText = (id+1);
		$newItem.find('.skill-item-title span').text(criterionText);

		var nameText = 'wpjobus_job_languages[' + id + '][0]';
		$newItem.find('.resume_lang_title').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_job_languages[' + id + '][1]';
		$newItem.find('.resume_lang_understanding').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_job_languages[' + id + '][2]';
		$newItem.find('.resume_lang_speaking').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_job_languages[' + id + '][3]';
		$newItem.find('.resume_lang_writing').attr('id', nameText).attr('name', nameText);

		//event handler for newly created element
		$newItem.children('.button_del_job_language').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_job_language').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD JOB BENEFITS
	jQuery('#template_job_benefit').hide();
	jQuery('#submit_add_job_benefit').on('click', function() {		
		$newItem = jQuery('#template_job_benefit .option_item').clone().appendTo('#review_job_benefit').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		var criterionText = (id+1);
		$newItem.find('.skill-item-title span').text(criterionText);

		var nameText = 'wpjobus_job_benefits[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var sliderValue = 'wpjobus_job_benefits['+ id +'][1]';
		$newItem.find('.job-benefit-desc').attr('id', sliderValue).attr('name', sliderValue);

		//event handler for newly created element
		$newItem.children('.button_del_job_benefit').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_job_benefit').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD INSTITUTION
	jQuery('#template_education').hide();
	jQuery('#submit_add_institution').on('click', function() {		
		$newItem = jQuery('#template_education .option_item').clone().appendTo('#resume_institution').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_resume_education[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_education[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_education[' + id + '][2]';
		$newItem.find('.criteria_from_time').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_education[' + id + '][3]';
		$newItem.find('.criteria_to_time').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_education[' + id + '][4]';
		$newItem.find('.criteria_location').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_education[' + id + '][5]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_institution').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_institution').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD SERVICE
	jQuery('#template_service').hide();
	jQuery('#submit_add_service').on('click', function() {		
		$newItem = jQuery('#template_service .option_item').clone().appendTo('#resume_service').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_company_services[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_services[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_services[' + id + '][2]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_service').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_service').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD CLIENT
	jQuery('#template_clients').hide();
	jQuery('#submit_add_client').on('click', function() {		
		$newItem = jQuery('#template_clients .option_item').clone().appendTo('#resume_clients').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_company_clients[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_clients[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_clients[' + id + '][2]';
		$newItem.find('.criteria_from_time').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_clients[' + id + '][3]';
		$newItem.find('.criteria_to_time').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_clients[' + id + '][4]';
		$newItem.find('.criteria_location').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_clients[' + id + '][5]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_client').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_client').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD AWARD
	jQuery('#template_award').hide();
	jQuery('#submit_add_award').on('click', function() {		
		$newItem = jQuery('#template_award .option_item').clone().appendTo('#resume_award').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_resume_award[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_award[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_award[' + id + '][2]';
		$newItem.find('.criteria_from_time').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_award[' + id + '][3]';
		$newItem.find('.criteria_location').attr('id', nameText).attr('name', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_award').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_award').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});



	//ADD WORK EXPERIENCE
	jQuery('#template_work').hide();
	jQuery('#submit_add_work').on('click', function() {		
		$newItem = jQuery('#template_work .option_item').clone().appendTo('#resume_work').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_resume_work[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_work[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_work[' + id + '][2]';
		$newItem.find('.criteria_from_time').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_work[' + id + '][3]';
		$newItem.find('.criteria_to_time').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_work[' + id + '][4]';
		$newItem.find('.resume_work_job_type').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_work[' + id + '][5]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_work').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_work').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD TESTIMONIALS
	jQuery('#template_testimonials').hide();
	jQuery('#submit_add_testimonial').on('click', function() {		
		$newItem = jQuery('#template_testimonials .option_item').clone().appendTo('#resume_testimonials').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_resume_testimonials[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_testimonials[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_testimonials[' + id + '][2]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);

		var nameText = 'your_image_url_img' + id + '3';
		var nameTextEmpty = '';
		$newItem.find('img.criteria-image').attr('id', nameText).attr('src', nameTextEmpty);

		var nameText = 'your_image_url' + id + '3';
		var nameTextTwo = 'wpjobus_resume_testimonials[' + id + '][3]';
		$newItem.find('input.criteria-image-url').attr('id', nameText).attr('name', nameTextTwo);

		var nameText = 'your_image_url_button_remove' + id + '3';
		$newItem.find('input.criteria-image-button-remove').attr('id', nameText);

		var nameText = 'your_image_url_button' + id + '3';
		$newItem.find('input.criteria-image-button').attr('id', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_testimonial').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_testimonial').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD COMP TESTIMONIALS
	jQuery('#template_comp_testimonials').hide();
	jQuery('#submit_add_comp_testimonial').on('click', function() {		
		$newItem = jQuery('#template_comp_testimonials .option_item').clone().appendTo('#company_testimonials').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_company_testimonials[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_testimonials[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_testimonials[' + id + '][2]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);

		var nameText = 'your_image_url_img' + id + '3';
		var nameTextEmpty = '';
		$newItem.find('img.criteria-image').attr('id', nameText).attr('src', nameTextEmpty);

		var nameText = 'your_image_url' + id + '3';
		var nameTextTwo = 'wpjobus_company_testimonials[' + id + '][3]';
		$newItem.find('input.criteria-image-url').attr('id', nameText).attr('name', nameTextTwo);

		var nameText = 'your_image_url_button_remove' + id + '3';
		$newItem.find('input.criteria-image-button-remove').attr('id', nameText);

		var nameText = 'your_image_url_button' + id + '3';
		$newItem.find('input.criteria-image-button').attr('id', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_comp_testimonial').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_comp_testimonial').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	//ADD PORTFOLIO
	jQuery('#template_portfolio').hide();
	jQuery('#submit_add_portfolio').on('click', function() {		
		$newItem = jQuery('#template_portfolio .option_item').clone().appendTo('#resume_portfolio').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_resume_portfolio[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_portfolio[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_resume_portfolio[' + id + '][2]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);

		var nameText = 'your_image_url_img' + id + '3';
		var nameTextEmpty = '';
		$newItem.find('img.criteria-image').attr('id', nameText).attr('src', nameTextEmpty);

		var nameText = 'your_image_url' + id + '3';
		var nameTextTwo = 'wpjobus_resume_portfolio[' + id + '][3]';
		$newItem.find('input.criteria-image-url').attr('id', nameText).attr('name', nameTextTwo);

		var nameText = 'your_image_url_button_remove' + id + '3';
		$newItem.find('input.criteria-image-button-remove').attr('id', nameText);

		var nameText = 'your_image_url_button' + id + '3';
		$newItem.find('input.criteria-image-button').attr('id', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_portfolio').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_portfolio').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});

	//ADD PORTFOLIO
	jQuery('#template_comp_portfolio').hide();
	jQuery('#submit_add_comp_portfolio').on('click', function() {		
		$newItem = jQuery('#template_comp_portfolio .option_item').clone().appendTo('#company_portfolio').show();
		if ($newItem.prev('.option_item').size() == 1) {
			var id = parseInt($newItem.prev('.option_item').attr('id')) + 1;
		} else {
			var id = 0;	
		}
		$newItem.attr('id', id);

		$newItem.find('.skill-item-title span.num').text(id+1);

		var nameText = 'wpjobus_company_portfolio[' + id + '][0]';
		$newItem.find('.criteria_name').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_portfolio[' + id + '][1]';
		$newItem.find('.criteria_name_two').attr('id', nameText).attr('name', nameText);

		var nameText = 'wpjobus_company_portfolio[' + id + '][2]';
		$newItem.find('.criteria_notes').attr('id', nameText).attr('name', nameText);

		var nameText = 'your_image_url_img' + id + '3';
		var nameTextEmpty = '';
		$newItem.find('img.criteria-image').attr('id', nameText).attr('src', nameTextEmpty);

		var nameText = 'your_image_url' + id + '3';
		var nameTextTwo = 'wpjobus_company_portfolio[' + id + '][3]';
		$newItem.find('input.criteria-image-url').attr('id', nameText).attr('name', nameTextTwo);

		var nameText = 'your_image_url_button_remove' + id + '3';
		$newItem.find('input.criteria-image-button-remove').attr('id', nameText);

		var nameText = 'your_image_url_button' + id + '3';
		$newItem.find('input.criteria-image-button').attr('id', nameText);


		//event handler for newly created element
		$newItem.children('.button_del_comp_portfolio').on('click', function () {
			jQuery(this).parent('.option_item').remove();
		});

	});
	
	//DELETE
	jQuery('.button_del_comp_portfolio').on('click', function() {
		jQuery(this).parent('.option_item').remove();
	});


	// Portfolio filter
	// actiavte portfolio sorting
	elem = jQuery("#recipe-sort-container");
	if (elem.is (".recipe-sort-container")) {
	    jQuery.extend( jQuery.Isotope.prototype, {
	      _customModeReset : function() { 
	      
	        this.fitRows = {
	            x : 0,
	            y : 0,
	            height : 0
	          };
	      
	       },
	      _customModeLayout : function( $elems ) { 
	      
	        var instance 		= this,
		        containerWidth 	= this.element.width(),
		        props 			= this.fitRows,
		        margin 			= 32, //margin based on %
		        extraRange		= 0; // adds a little range for % based calculation error in some browsers
	      
	          $elems.css({visibility:'visible'}).each( function() {
	            var $this = jQuery(this),
	                atomW = $this.outerWidth(),
	                atomH = $this.outerHeight(true);
	            
	            if ( props.x !== 0 && atomW + props.x > containerWidth + extraRange ) {
	              // if this element cannot fit in the current row
	              props.x = 0;
	              props.y = props.height;
	            } 
	          
	          //webkit gets blurry elements if position is a float value
	          props.x = Math.round(props.x);
	          props.y = Math.round(props.y);
	         
	            // position the atom
	            instance._pushPosition( $this, props.x, props.y );
	          
	            props.height = Math.max( props.y + atomH, props.height );
	            props.x += atomW + margin;
	        
	        jQuery('#recipe-sort-container').css({visibility:"visible", opacity:1});
	        jQuery('#filters').css({visibility:"visible", opacity:1});
	        
	        
	          });
	      
	      },
	      _customModeGetContainerSize : function() { 
	      
	        return { height : this.fitRows.height };
	      
	      },
	      _customModeResizeChanged : function() { 
	      
	        return true;
	        
	       }
	    });
	    
	    var $container = jQuery('#recipe-sort-container').css({visibility:"visible", opacity:0});

	    $container.isotope({
	       	itemSelector : '.isotope-item',
	     	layoutMode : 'customMode'
	    });
	        
	        
	    var $optionSets = jQuery('#portfolio .sort_by_cat'),
	        $optionLinks = $optionSets.find('a');

	   $optionLinks.click(function(){
		    var $this = jQuery(this);
		    // don't proceed if already selected
		    if ( $this.hasClass('active_sort') ) {
		        return false;
		    }
		    var $optionSet = $this.parents('.sort_by_cat');
		    $optionSet.find('.active_sort').removeClass('active_sort');
		    $this.addClass('active_sort');
		    
		    // make option object dynamically, i.e. { filter: '.my-filter-class' }
		    var options = {},
		        key = $optionSet.attr('data-option-key'),
		        value = $this.attr('data-option-value');
		    // parse 'false' as false boolean
		    value = value === 'false' ? false : value;
		    options[ key ] = value;
		    if ( key === 'layoutMode' && typeof changeLayoutMode === 'function' ) {
		        // changes in layout modes need extra logic
		        changeLayoutMode( $this, options )
		    } else {
		        // otherwise, apply new options
		        $container.isotope( options );
		    }
		          
		return false;

	    });
	};

	if (document.getElementById( 'recipe-block' )) {
		new cbpScroller( document.getElementById( 'recipe-block' ), {
			minDuration : 0.4,
			maxDuration : 0.7,
			viewportFactor : 0.2
		} );
	}



	/* Scroll event handler */
    jQuery(window).bind('scroll',function(e){
    	parallaxScroll();
    });


    /* Scroll the background layers */
	function parallaxScroll(){
		var scrolled = jQuery(window).scrollTop();
		jQuery('#resume-cover-image .coverImageHolder .bgImg').css('top',(0-(scrolled*.25))+'px');

		jQuery('#supersized-arrow-left').css('top',(0-(scrolled*1.35))+'px');
	}


	/* Trigger Top menu */
	jQuery('.menu-nav-trigger').click(function(){
		var $this = jQuery(this);
		if ( $this.hasClass('is-active') ) {
		    $this.removeClass('is-active');

		    if(jQuery("#single-company").length ) {

				headHeight = jQuery('#single-company #header').height() + 6;

			}

			if(jQuery("#single-resume").length ) {

				headHeight = jQuery('#single-resume #header').height() + 6;

			}

			if(jQuery("#single-job").length ) {

				headHeight = jQuery('#single-job #header').height() + 6;

			}

		    jQuery('#single-resume #top').stop().animate({ marginTop: '-30px' }, 500);
		    jQuery('#single-resume #header').stop().animate({ marginTop: '-'+headHeight+'px' }, 500);

		    jQuery('#single-company #top').stop().animate({ marginTop: '-30px' }, 500);
		    jQuery('#single-company #header').stop().animate({ marginTop: '-'+headHeight+'px' }, 500);

		    jQuery('#single-job #top').stop().animate({ marginTop: '-30px' }, 500);
		    jQuery('#single-job #header').stop().animate({ marginTop: '-'+headHeight+'px' }, 500);
		} else {
			$this.addClass('is-active');
			jQuery('#single-resume #top').stop().animate({ marginTop: '0' }, 500);
			jQuery('#single-resume #header').stop().animate({ marginTop: '0' }, 500);

			jQuery('#single-company #top').stop().animate({ marginTop: '0' }, 500);
			jQuery('#single-company #header').stop().animate({ marginTop: '0' }, 500);

			jQuery('#single-job #top').stop().animate({ marginTop: '0' }, 500);
			jQuery('#single-job #header').stop().animate({ marginTop: '0' }, 500);

			jQuery("body,html").animate({
				scrollTop: 0
			}, 800);
			return false;
		}
	});

	jQuery('a[href*=#]:not([href=#])').click(function() {
	    if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
		    var target = jQuery(this.hash);
		    target = target.length ? target : jQuery('[name=' + this.hash.slice(1) +']');
		    if (target.length) {
		        jQuery('html,body').animate({
		          scrollTop: target.offset().top
		        }, 1000);
		        return false;
		    }
	    }
	});


	jQuery('.main-skills-item-bar-color').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');

	        	jQuery(this)
			        .data("origWidth", jQuery(this).width())
			        .width(0)
			        .animate({
			            width: jQuery(this).data("origWidth")
			            }, 1200);
	        }

	    	
	  	}
	});

	jQuery('#home-wpjobus-stats').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
		if (isInView) {

			if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');

	        	jQuery('#home-wpjobus-stats.animate .count').each(function () {
					if(jQuery('#home-wpjobus-stats.animate .count').attr('nomore')!="1") {
						var $this = jQuery(this);
							jQuery({ Counter: 0 }).delay(500).animate({ Counter: $this.text() }, {
								duration: 1000,
								easing: 'swing',
								step: function () {
								  	$this.text(Math.ceil(this.Counter)).delay(3000).parent().parent().parent().attr('nomore','1');;
							}
						});
					}
				});	


	        }
	
		}
	});	

	jQuery('#companies-block-list-ul').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if (jQuery(this).hasClass('animated-list')) {
	            
	        } else {
	        	jQuery(this).addClass('animated-list');

	        	jQuery('#companies-block-list-ul li').each(function(i) {
				var $li = jQuery(this);
				setTimeout(function() {
				    $li.addClass('animate');
				}, i*150); // delay 150 ms
			});
	        }

	    	
	  	}
	});

	jQuery('.main-skills-item-language').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');
	        }

	        jQuery('.main-skills-item-language .full').each(function(i) {
				var $li = jQuery(this);
				setTimeout(function() {
				    $li.addClass('animate');
				}, i*150); // delay 150 ms
			});

			jQuery('.main-skills-item-title-language .fa').each(function(i) {
				var $li = jQuery(this);
				setTimeout(function() {
				    $li.addClass('animate');
				}, i*100); // delay 100 ms
			});

	    	
	  	}
	});

	jQuery('.hobbies-block').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');
	        }

	        jQuery('.hobbies-item').each(function(i) {
				var $li = jQuery(this);
				setTimeout(function() {
				    $li.addClass('animate');
				}, i*150); // delay 100 ms
			});

	    	
	  	}
	});

	jQuery('.education-institution-block').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');
	        }

	    	
	  	}
	});

	jQuery('.job-experience-holder .three_fourth').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');
	        }

	    	
	  	}
	});

	jQuery('.ff-items').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');
	        }

	    	
	  	}
	});

	jQuery('.work-experience-block').bind('inview', function(event, isInView, visiblePartX, visiblePartY) {
	  	if (isInView) {
	    	// element is now visible in the viewport
	    	if ( jQuery(this).hasClass('animate') ) {
	            
	        } else {
	        	jQuery(this).addClass('animate');
	        }

	    	
	  	}
	});

});