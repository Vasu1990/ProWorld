window.wp=window.wp||{},function(a,b){var c;"undefined"!=typeof _wpPluploadSettings&&(c=function(a){var d,e,f=this,g=-1!=navigator.userAgent.indexOf("Trident/")||-1!=navigator.userAgent.indexOf("MSIE "),h={container:"container",browser:"browse_button",dropzone:"drop_element"};if(this.supports={upload:c.browser.supported},this.supported=this.supports.upload,this.supported){this.plupload=b.extend(!0,{multipart_params:{}},c.defaults),this.container=document.body,b.extend(!0,this,a);for(d in this)b.isFunction(this[d])&&(this[d]=b.proxy(this[d],this));for(d in h)this[d]&&(this[d]=b(this[d]).first(),this[d].length?(this[d].prop("id")||this[d].prop("id","__wp-uploader-id-"+c.uuid++),this.plupload[h[d]]=this[d].prop("id")):delete this[d]);(this.browser&&this.browser.length||this.dropzone&&this.dropzone.length)&&(g||"flash"!==plupload.predictRuntime(this.plupload)||this.plupload.required_features&&this.plupload.required_features.hasOwnProperty("send_binary_string")||(this.plupload.required_features=this.plupload.required_features||{},this.plupload.required_features.send_binary_string=!0),this.uploader=new plupload.Uploader(this.plupload),delete this.plupload,this.param(this.params||{}),delete this.params,e=function(a,b,d){d.attachment&&d.attachment.destroy(),c.errors.unshift({message:a||pluploadL10n.default_error,data:b,file:d}),f.error(a,b,d)},this.uploader.bind("init",function(a){var d,e,g,h=f.dropzone;if(g=f.supports.dragdrop=a.features.dragdrop&&!c.browser.mobile,h){if(h.toggleClass("supports-drag-drop",!!g),!g)return h.unbind(".wp-uploader");h.bind("dragover.wp-uploader",function(){d&&clearTimeout(d),e||(h.trigger("dropzone:enter").addClass("drag-over"),e=!0)}),h.bind("dragleave.wp-uploader, drop.wp-uploader",function(){d=setTimeout(function(){e=!1,h.trigger("dropzone:leave").removeClass("drag-over")},0)}),b(f).trigger("uploader:ready")}}),this.uploader.init(),this.browser?this.browser.on("mouseenter",this.refresh):(this.uploader.disableBrowse(!0),b("#"+this.uploader.id+"_html5_container").hide()),this.uploader.bind("FilesAdded",function(a,b){_.each(b,function(a){var b,d;plupload.FAILED!==a.status&&(b=_.extend({file:a,uploading:!0,date:new Date,filename:a.name,menuOrder:0,uploadedTo:wp.media.model.settings.post.id},_.pick(a,"loaded","size","percent")),d=/(?:jpe?g|png|gif)$/i.exec(a.name),d&&(b.type="image",b.subtype="jpg"===d[0]?"jpeg":d[0]),a.attachment=wp.media.model.Attachment.create(b),c.queue.add(a.attachment),f.added(a.attachment))}),a.refresh(),a.start()}),this.uploader.bind("UploadProgress",function(a,b){b.attachment.set(_.pick(b,"loaded","percent")),f.progress(b.attachment)}),this.uploader.bind("FileUploaded",function(a,b,d){var g;try{d=JSON.parse(d.response)}catch(h){return e(pluploadL10n.default_error,h,b)}return!_.isObject(d)||_.isUndefined(d.success)?e(pluploadL10n.default_error,null,b):d.success?(_.each(["file","loaded","size","percent"],function(a){b.attachment.unset(a)}),b.attachment.set(_.extend(d.data,{uploading:!1})),wp.media.model.Attachment.get(d.data.id,b.attachment),g=c.queue.all(function(a){return!a.get("uploading")}),g&&c.queue.reset(),void f.success(b.attachment)):e(d.data&&d.data.message,d.data,b)}),this.uploader.bind("Error",function(a,b){var d,f=pluploadL10n.default_error;for(d in c.errorMap)if(b.code===plupload[d]){f=c.errorMap[d],_.isFunction(f)&&(f=f(b.file,b));break}e(f,b,b.file),a.refresh()}),this.uploader.bind("PostInit",function(){f.init()}))}},b.extend(c,_wpPluploadSettings),c.uuid=0,c.errorMap={FAILED:pluploadL10n.upload_failed,FILE_EXTENSION_ERROR:pluploadL10n.invalid_filetype,IMAGE_FORMAT_ERROR:pluploadL10n.not_an_image,IMAGE_MEMORY_ERROR:pluploadL10n.image_memory_exceeded,IMAGE_DIMENSIONS_ERROR:pluploadL10n.image_dimensions_exceeded,GENERIC_ERROR:pluploadL10n.upload_failed,IO_ERROR:pluploadL10n.io_error,HTTP_ERROR:pluploadL10n.http_error,SECURITY_ERROR:pluploadL10n.security_error,FILE_SIZE_ERROR:function(a){return pluploadL10n.file_exceeds_size_limit.replace("%s",a.name)}},b.extend(c.prototype,{param:function(a,c){return 1===arguments.length&&"string"==typeof a?this.uploader.settings.multipart_params[a]:void(arguments.length>1?this.uploader.settings.multipart_params[a]=c:b.extend(this.uploader.settings.multipart_params,a))},init:function(){},error:function(){},success:function(){},added:function(){},progress:function(){},complete:function(){},refresh:function(){var a,c,d,e;if(this.browser){for(a=this.browser[0];a;){if(a===document.body){c=!0;break}a=a.parentNode}c||(e="wp-uploader-browser-"+this.uploader.id,d=b("#"+e),d.length||(d=b('<div class="wp-uploader-browser" />').css({position:"fixed",top:"-1000px",left:"-1000px",height:0,width:0}).attr("id","wp-uploader-browser-"+this.uploader.id).appendTo("body")),d.append(this.browser))}this.uploader.refresh()}}),c.queue=new wp.media.model.Attachments([],{query:!1}),c.errors=new Backbone.Collection,a.Uploader=c)}(wp,jQuery);