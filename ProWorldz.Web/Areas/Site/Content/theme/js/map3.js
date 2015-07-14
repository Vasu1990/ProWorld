			var mapDiv,
				map,
				infobox;
			jQuery(document).ready(function($) {

				mapDiv = $("#wpjobus-main-map");
				mapDiv.height(500).gmap3({
					map: {
						options: {
							"draggable": true
							,"mapTypeControl": true
							,"mapTypeId": google.maps.MapTypeId.ROADMAP
							,"scrollwheel": false
							,"panControl": true
							,"rotateControl": false
							,"scaleControl": true
							,"streetViewControl": true
							,"zoomControl": true
							,"styles": [
    {
        "featureType": "landscape.natural",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "visibility": "on"
            },
            {
                "color": "#e0efef"
            }
        ]
    },
    {
        "featureType": "poi",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "visibility": "on"
            },
            {
                "hue": "#1900ff"
            },
            {
                "color": "#c0e8e8"
            }
        ]
    },
    {
        "featureType": "landscape.man_made",
        "elementType": "geometry.fill"
    },
    {
        "featureType": "road",
        "elementType": "geometry",
        "stylers": [
            {
                "lightness": 100
            },
            {
                "visibility": "simplified"
            }
        ]
    },
    {
        "featureType": "road",
        "elementType": "labels",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "water",
        "stylers": [
            {
                "color": "#7dcdcd"
            }
        ]
    },
    {
        "featureType": "transit.line",
        "elementType": "geometry",
        "stylers": [
            {
                "visibility": "on"
            },
            {
                "lightness": 700
            }
        ]
    }
] 						}
					}
					,marker: {
						values: [

							 
								{

									latLng: [40.74140337523371,-74.05022993525392],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/halftonedot-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Technician</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72421678517121,-74.00785103281862],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/halftonedot-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.893081982538106,-87.66052558647459],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/plantcloud-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Marketer</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}

							,

							 
								{

									latLng: [41.808033517004176,-87.7025826238281],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/plantcloud-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.73529882962477,-122.45649435742189],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/music-dj-logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.769637590885694,-122.40405180676271],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/music-dj-logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.736720997900726,-73.991350082959],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/townhall-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.760909732966475,-73.98087873896486],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/townhall-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.900093710936666,-87.68438651787108],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/mansilhouette-498x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.89549384841012,-87.7904732488281],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/mansilhouette-498x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.75565970228647,-122.48327353222658],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/solidsociety-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.76229274332331,-122.41128304226686],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Cyberoam-Preview.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Digital PR manager</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.706131115359234,-74.01763573130495],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/media-fury-production.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">PR manager</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72533884560117,-74.000533966626],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/media-fury-production.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.78704572394614,-87.96762778984373],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/TracksnBeats-logo-download.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.88367323787924,-87.64374568687742],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/TracksnBeats-logo-download.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72215149405797,-73.97950544794924],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/monkeyrule-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.76273003437759,-73.97298231562502],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/monkeyrule-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="job.html">View Job Offer</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

														
						],
						options:{
							draggable: false
						},
						cluster:{
			          		radius: 20,
							// This style will be used for clusters with more than 0 markers
							0: {
								content: "<div class='cluster cluster-1'>CLUSTER_COUNT</div>",
								width: 62,
								height: 62
							},
							// This style will be used for clusters with more than 20 markers
							20: {
								content: "<div class='cluster cluster-2'>CLUSTER_COUNT</div>",
								width: 82,
								height: 82
							},
							// This style will be used for clusters with more than 50 markers
							50: {
								content: "<div class='cluster cluster-3'>CLUSTER_COUNT</div>",
								width: 102,
								height: 102
							},
							events: {
								click: function(cluster) {
									map.panTo(cluster.main.getPosition());
									map.setZoom(map.getZoom() + 2);
								}
							}
			          	},
						events: {
							click: function(marker, event, context){
								map.panTo(marker.getPosition());

								var ibOptions = {
								    pixelOffset: new google.maps.Size(-125, -88),
								    alignBottom: true
								};

								infobox.setOptions(ibOptions)

								infobox.setContent(context.data);
								infobox.open(map,marker);

								// if map is small
								var iWidth = 260;
								var iHeight = 300;
								if((mapDiv.width() / 2) < iWidth ){
									var offsetX = iWidth - (mapDiv.width() / 2);
									map.panBy(offsetX,0);
								}
								if((mapDiv.height() / 2) < iHeight ){
									var offsetY = -(iHeight - (mapDiv.height() / 2));
									map.panBy(0,offsetY);
								}

							}
						}
					}
				},"autofit");

				map = mapDiv.gmap3("get");
			    infobox = new InfoBox({
			    	pixelOffset: new google.maps.Size(-50, -65),
			    	closeBoxURL: '',
			    	enableEventPropagation: true
			    });
			    mapDiv.delegate('.infoBox .close','click',function () {
			    	infobox.close();
			    });

			    if (Modernizr.touch){
			    	map.setOptions({ draggable : false });
			        var draggableClass = 'inactive';
			        var draggableTitle = "Activate map";
			        var draggableButton = $('<div class="draggable-toggle-button '+draggableClass+'">'+draggableTitle+'</div>').appendTo(mapDiv);
			        draggableButton.click(function () {
			        	if($(this).hasClass('active')){
			        		$(this).removeClass('active').addClass('inactive').text("Activate map");
			        		map.setOptions({ draggable : false });
			        	} else {
			        		$(this).removeClass('inactive').addClass('active').text("Deactivate map");
			        		map.setOptions({ draggable : true });
			        	}
			        });
			    }

			});			