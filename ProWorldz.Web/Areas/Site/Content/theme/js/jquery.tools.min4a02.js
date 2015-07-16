/*!
 * jQuery Tools v1.2.7 - The missing UI library for the Web
 * 
 * overlay/overlay.js
 * scrollable/scrollable.js
 * tabs/tabs.js
 * tooltip/tooltip.js
 * 
 * NO COPYRIGHTS OR LICENSES. DO WHAT YOU LIKE.
 * 
 * http://flowplayer.org/tools/
 * 
 */
(function(b){function m(a,c){var d=this,h=a.add(d),n=b(window),e,f,k,g=b.tools.expose&&(c.mask||c.expose),l=Math.random().toString().slice(10);g&&("string"==typeof g&&(g={color:g}),g.closeOnClick=g.closeOnEsc=!1);var i=c.target||a.attr("rel");f=i?b(i):a;if(!f.length)throw"Could not find Overlay: "+i;a&&-1==a.index(f)&&a.click(function(b){d.load(b);return b.preventDefault()});b.extend(d,{load:function(a){if(d.isOpened())return d;var p=o[c.effect];if(!p)throw'Overlay: cannot find effect : "'+c.effect+
 '"';c.oneInstance&&b.each(q,function(){this.close(a)});a=a||b.Event();a.type="onBeforeLoad";h.trigger(a);if(a.isDefaultPrevented())return d;k=true;g&&b(f).expose(g);var j=c.top,e=c.left,i=f.outerWidth({margin:true}),m=f.outerHeight({margin:true});typeof j=="string"&&(j=j=="center"?Math.max((n.height()-m)/2,0):parseInt(j,10)/100*n.height());e=="center"&&(e=Math.max((n.width()-i)/2,0));p[0].call(d,{top:j,left:e},function(){if(k){a.type="onLoad";h.trigger(a)}});if(g&&c.closeOnClick)b.mask.getMask().one("click",
 d.close);if(c.closeOnClick)b(document).on("click."+l,function(a){b(a.target).parents(f).length||d.close(a)});if(c.closeOnEsc)b(document).on("keydown."+l,function(a){a.keyCode==27&&d.close(a)});return d},close:function(a){if(!d.isOpened())return d;a=a||b.Event();a.type="onBeforeClose";h.trigger(a);if(!a.isDefaultPrevented()){k=false;o[c.effect][1].call(d,function(){a.type="onClose";h.trigger(a)});b(document).off("click."+l+" keydown."+l);g&&b.mask.close();return d}},getOverlay:function(){return f},
 getTrigger:function(){return a},getClosers:function(){return e},isOpened:function(){return k},getConf:function(){return c}});b.each(["onBeforeLoad","onStart","onLoad","onBeforeClose","onClose"],function(a,e){if(b.isFunction(c[e]))b(d).on(e,c[e]);d[e]=function(a){if(a)b(d).on(e,a);return d}});e=f.find(c.close||".close");!e.length&&!c.close&&(e=b('<a class="close"></a>'),f.prepend(e));e.click(function(a){d.close(a)});c.load&&d.load()}b.tools=b.tools||{version:"@VERSION"};b.tools.overlay={addEffect:function(a,
 b,d){o[a]=[b,d]},conf:{close:null,closeOnClick:!0,closeOnEsc:!0,closeSpeed:"fast",effect:"default",fixed:!b.browser.msie||6<b.browser.version,left:"center",load:!1,mask:null,oneInstance:!0,speed:"normal",target:null,top:"10%"}};var q=[],o={};b.tools.overlay.addEffect("default",function(a,c){var d=this.getConf(),h=b(window);d.fixed||(a.top+=h.scrollTop(),a.left+=h.scrollLeft());a.position=d.fixed?"fixed":"absolute";this.getOverlay().css(a).fadeIn(d.speed,c)},function(a){this.getOverlay().fadeOut(this.getConf().closeSpeed,
 a)});b.fn.overlay=function(a){var c=this.data("overlay");if(c)return c;b.isFunction(a)&&(a={onBeforeLoad:a});a=b.extend(!0,{},b.tools.overlay.conf,a);this.each(function(){c=new m(b(this),a);q.push(c);b(this).data("overlay",c)});return a.api?c:this}})(jQuery);(function(d){function p(f,b){var c=d(b);return 2>c.length?c:f.parent().find(b)}function u(f,b){var c=this,n=f.add(c),g=f.children(),l=0,j=b.vertical;k||(k=c);1<g.length&&(g=d(b.items,f));1<b.size&&(b.circular=!1);d.extend(c,{getConf:function(){return b},getIndex:function(){return l},getSize:function(){return c.getItems().size()},getNaviButtons:function(){return h.add(m)},getRoot:function(){return f},getItemWrap:function(){return g},getItems:function(){return g.find(b.item).not("."+b.clonedClass)},
move:function(a,b){return c.seekTo(l+a,b)},next:function(a){return c.move(b.size,a)},prev:function(a){return c.move(-b.size,a)},begin:function(a){return c.seekTo(0,a)},end:function(a){return c.seekTo(c.getSize()-1,a)},focus:function(){return k=c},addItem:function(a){a=d(a);if(b.circular){g.children().last().before(a);g.children().first().replaceWith(a.clone().addClass(b.clonedClass))}else{g.append(a);m.removeClass("disabled")}n.trigger("onAddItem",[a]);return c},seekTo:function(a,e,f){a.jquery||(a=
a*1);if(b.circular&&a===0&&l==-1&&e!==0||!b.circular&&a<0||a>c.getSize()||a<-1)return c;var i=a;a.jquery?a=c.getItems().index(a):i=c.getItems().eq(a);var h=d.Event("onBeforeSeek");if(!f){n.trigger(h,[a,e]);if(h.isDefaultPrevented()||!i.length)return c}i=j?{top:-i.position().top}:{left:-i.position().left};l=a;k=c;if(e===void 0)e=b.speed;g.animate(i,e,b.easing,f||function(){n.trigger("onSeek",[a])});return c}});d.each(["onBeforeSeek","onSeek","onAddItem"],function(a,e){if(d.isFunction(b[e]))d(c).on(e,
b[e]);c[e]=function(a){if(a)d(c).on(e,a);return c}});if(b.circular){var q=c.getItems().slice(-1).clone().prependTo(g),r=c.getItems().eq(1).clone().appendTo(g);q.add(r).addClass(b.clonedClass);c.onBeforeSeek(function(a,b,d){if(!a.isDefaultPrevented()){if(b==-1){c.seekTo(q,d,function(){c.end(0)});return a.preventDefault()}b==c.getSize()&&c.seekTo(r,d,function(){c.begin(0)})}});var o=f.parents().add(f).filter(function(){if(d(this).css("display")==="none")return true});o.length?(o.show(),c.seekTo(0,0,
function(){}),o.hide()):c.seekTo(0,0,function(){})}var h=p(f,b.prev).click(function(a){a.stopPropagation();c.prev()}),m=p(f,b.next).click(function(a){a.stopPropagation();c.next()});b.circular||(c.onBeforeSeek(function(a,e){setTimeout(function(){if(!a.isDefaultPrevented()){h.toggleClass(b.disabledClass,e<=0);m.toggleClass(b.disabledClass,e>=c.getSize()-1)}},1)}),b.initialIndex||h.addClass(b.disabledClass));2>c.getSize()&&h.add(m).addClass(b.disabledClass);b.mousewheel&&d.fn.mousewheel&&f.mousewheel(function(a,
e){if(b.mousewheel){c.move(e<0?1:-1,b.wheelSpeed||50);return false}});if(b.touch){var s,t;g[0].ontouchstart=function(a){a=a.touches[0];s=a.clientX;t=a.clientY};g[0].ontouchmove=function(a){if(a.touches.length==1&&!g.is(":animated")){var b=a.touches[0],d=s-b.clientX,b=t-b.clientY;c[j&&b>0||!j&&d>0?"next":"prev"]();a.preventDefault()}}}if(b.keyboard)d(document).on("keydown.scrollable",function(a){if(b.keyboard&&!a.altKey&&!a.ctrlKey&&!a.metaKey&&!d(a.target).is(":input")&&!(b.keyboard!="static"&&k!=
c)){var e=a.keyCode;if(j&&(e==38||e==40)){c.move(e==38?-1:1);return a.preventDefault()}if(!j&&(e==37||e==39)){c.move(e==37?-1:1);return a.preventDefault()}}});b.initialIndex&&c.seekTo(b.initialIndex,0,function(){})}d.tools=d.tools||{version:"@VERSION"};d.tools.scrollable={conf:{activeClass:"active",circular:!1,clonedClass:"cloned",disabledClass:"disabled",easing:"swing",initialIndex:0,item:"> *",items:".items",keyboard:!0,mousewheel:!1,next:".next",prev:".prev",size:1,speed:400,vertical:!1,touch:!0,
wheelSpeed:0}};var k;d.fn.scrollable=function(f){var b=this.data("scrollable");if(b)return b;f=d.extend({},d.tools.scrollable.conf,f);this.each(function(){b=new u(d(this),f);d(this).data("scrollable",b)});return f.api?b:this}})(jQuery);(function(d){function n(c,a,b){var e=this,l=c.add(this),g=c.find(b.tabs),f=a.jquery?a:c.children(a),i;g.length||(g=c.children());f.length||(f=c.parent().find(a));f.length||(f=d(a));d.extend(this,{click:function(a,h){var f=g.eq(a),j=!c.data("tabs");"string"==typeof a&&a.replace("#","")&&(f=g.filter('[href*="'+a.replace("#","")+'"]'),a=Math.max(g.index(f),0));if(b.rotate){var k=g.length-1;if(0>a)return e.click(k,h);if(a>k)return e.click(0,h)}if(!f.length){if(0<=i)return e;a=b.initialIndex;f=g.eq(a)}if(a===
i)return e;h=h||d.Event();h.type="onBeforeClick";l.trigger(h,[a]);if(!h.isDefaultPrevented())return m[j?b.initialEffect&&b.effect||"default":b.effect].call(e,a,function(){i=a;h.type="onClick";l.trigger(h,[a])}),g.removeClass(b.current),f.addClass(b.current),e},getConf:function(){return b},getTabs:function(){return g},getPanes:function(){return f},getCurrentPane:function(){return f.eq(i)},getCurrentTab:function(){return g.eq(i)},getIndex:function(){return i},next:function(){return e.click(i+1)},prev:function(){return e.click(i-
1)},destroy:function(){g.off(b.event).removeClass(b.current);f.find('a[href^="#"]').off("click.T");return e}});d.each(["onBeforeClick","onClick"],function(a,c){if(d.isFunction(b[c]))d(e).on(c,b[c]);e[c]=function(a){if(a)d(e).on(c,a);return e}});b.history&&d.fn.history&&(d.tools.history.init(g),b.event="history");g.each(function(a){d(this).on(b.event,function(b){e.click(a,b);return b.preventDefault()})});f.find('a[href^="#"]').on("click.T",function(a){e.click(d(this).attr("href"),a)});location.hash&&
"a"==b.tabs&&c.find('[href="'+location.hash+'"]').length?e.click(location.hash):(0===b.initialIndex||0<b.initialIndex)&&e.click(b.initialIndex)}d.tools=d.tools||{version:"@VERSION"};d.tools.tabs={conf:{tabs:"a",current:"current",onBeforeClick:null,onClick:null,effect:"default",initialEffect:!1,initialIndex:0,event:"click",rotate:!1,slideUpSpeed:400,slideDownSpeed:400,history:!1},addEffect:function(c,a){m[c]=a}};var m={"default":function(c,a){this.getPanes().hide().eq(c).show();a.call()},fade:function(c,
a){var b=this.getConf(),e=b.fadeOutSpeed,d=this.getPanes();e?d.fadeOut(e):d.hide();d.eq(c).fadeIn(b.fadeInSpeed,a)},slide:function(c,a){var b=this.getConf();this.getPanes().slideUp(b.slideUpSpeed);this.getPanes().eq(c).slideDown(b.slideDownSpeed,a)},ajax:function(c,a){this.getPanes().eq(0).load(this.getTabs().eq(c).attr("href"),a)}},j,k;d.tools.tabs.addEffect("horizontal",function(c,a){if(!j){var b=this.getPanes().eq(c),e=this.getCurrentPane();k||(k=this.getPanes().eq(0).width());j=!0;b.show();e.animate({width:0},
{step:function(a){b.css("width",k-a)},complete:function(){d(this).hide();a.call();j=!1}});e.length||(a.call(),j=!1)}});d.fn.tabs=function(c,a){var b=this.data("tabs");b&&(b.destroy(),this.removeData("tabs"));d.isFunction(a)&&(a={onBeforeClick:a});a=d.extend({},d.tools.tabs.conf,a);this.each(function(){b=new n(d(this),c,a);d(this).data("tabs",b)});return a.api?b:this}})(jQuery);(function(e){function p(a,b,d){var f=d.relative?a.position().top:a.offset().top,c=d.relative?a.position().left:a.offset().left,h=d.position[0],f=f-(b.outerHeight()-d.offset[0]),c=c+(a.outerWidth()+d.offset[1]);/iPad/i.test(navigator.userAgent)&&(f-=e(window).scrollTop());var i=b.outerHeight()+a.outerHeight();"center"==h&&(f+=i/2);"bottom"==h&&(f+=i);h=d.position[1];a=b.outerWidth()+a.outerWidth();"center"==h&&(c-=a/2);"left"==h&&(c-=a);return{top:f,left:c}}function n(a,b){var d=this,f=a.add(d),c,
h=0,i=0,m=a.attr("title"),q=a.attr("data-tooltip"),r=o[b.effect],l,s=a.is(":input"),n=s&&a.is(":checkbox, :radio, select, :button, :submit"),t=a.attr("type"),j=b.events[t]||b.events[s?n?"widget":"input":"def"];if(!r)throw'Nonexistent effect "'+b.effect+'"';j=j.split(/,\s*/);if(2!=j.length)throw"Tooltip: bad events configuration for "+t;a.on(j[0],function(a){clearTimeout(h);b.predelay?i=setTimeout(function(){d.show(a)},b.predelay):d.show(a)}).on(j[1],function(a){clearTimeout(i);b.delay?h=setTimeout(function(){d.hide(a)},
b.delay):d.hide(a)});m&&b.cancelDefault&&(a.removeAttr("title"),a.data("title",m));e.extend(d,{show:function(k){if(!c){if(q)c=e(q);else if(b.tip)c=e(b.tip).eq(0);else if(m)c=e(b.layout).addClass(b.tipClass).appendTo(document.body).hide().append(m);else{c=a.next();c.length||(c=a.parent().next())}if(!c.length)throw"Cannot find tooltip for "+a;}if(d.isShown())return d;c.stop(true,true);var g=p(a,c,b);b.tip&&c.html(a.data("title"));k=e.Event();k.type="onBeforeShow";f.trigger(k,[g]);if(k.isDefaultPrevented())return d;
g=p(a,c,b);c.css({position:"absolute",top:g.top,left:g.left});l=true;r[0].call(d,function(){k.type="onShow";l="full";f.trigger(k)});g=b.events.tooltip.split(/,\s*/);if(!c.data("__set")){c.off(g[0]).on(g[0],function(){clearTimeout(h);clearTimeout(i)});if(g[1]&&!a.is("input:not(:checkbox, :radio), textarea"))c.off(g[1]).on(g[1],function(b){b.relatedTarget!=a[0]&&a.trigger(j[1].split(" ")[0])});b.tip||c.data("__set",true)}return d},hide:function(a){if(!c||!d.isShown())return d;a=e.Event();a.type="onBeforeHide";
f.trigger(a);if(!a.isDefaultPrevented()){l=false;o[b.effect][1].call(d,function(){a.type="onHide";f.trigger(a)});return d}},isShown:function(a){return a?l=="full":l},getConf:function(){return b},getTip:function(){return c},getTrigger:function(){return a}});e.each(["onHide","onBeforeShow","onShow","onBeforeHide"],function(a,c){if(e.isFunction(b[c]))e(d).on(c,b[c]);d[c]=function(a){if(a)e(d).on(c,a);return d}})}e.tools=e.tools||{version:"@VERSION"};e.tools.tooltip={conf:{effect:"toggle",fadeOutSpeed:"fast",
predelay:0,delay:30,opacity:1,tip:0,fadeIE:!1,position:["top","center"],offset:[0,0],relative:!1,cancelDefault:!0,events:{def:"mouseenter,mouseleave",input:"focus,blur",widget:"focus mouseenter,blur mouseleave",tooltip:"mouseenter,mouseleave"},layout:"<div/>",tipClass:"tooltip"},addEffect:function(a,b,d){o[a]=[b,d]}};var o={toggle:[function(a){var b=this.getConf(),d=this.getTip(),b=b.opacity;1>b&&d.css({opacity:b});d.show();a.call()},function(a){this.getTip().hide();a.call()}],fade:[function(a){var b=
this.getConf();!e.browser.msie||b.fadeIE?this.getTip().fadeTo(b.fadeInSpeed,b.opacity,a):(this.getTip().show(),a())},function(a){var b=this.getConf();!e.browser.msie||b.fadeIE?this.getTip().fadeOut(b.fadeOutSpeed,a):(this.getTip().hide(),a())}]};e.fn.tooltip=function(a){var b=this.data("tooltip");if(b)return b;a=e.extend(!0,{},e.tools.tooltip.conf,a);"string"==typeof a.position&&(a.position=a.position.split(/,?\s/));this.each(function(){b=new n(e(this),a);e(this).data("tooltip",b)});return a.api?
b:this}})(jQuery);