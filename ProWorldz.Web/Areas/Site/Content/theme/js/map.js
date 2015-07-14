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

									latLng: [40.733469153062224,-73.99564161738283],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Atomized-Media-free-vector-logo1.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Atomized Media</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/679">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.788971576244954,-122.4571810029297],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/digital-side-vector-logo-download.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">DigitalSide</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/670">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.7127837,-74.00594130000002],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/emma-allen.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Paula Aniston</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/653">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.76950189592819,-122.40192749722291],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/IMG_6048.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Julia Brown</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/565">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.74140337523371,-74.05022993525392],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/halftonedot-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Technician</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/509">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72421678517121,-74.00785103281862],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/halftonedot-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/508">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.704911131640095,-74.00907412012941],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/halftonedot-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Halftone Dot</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/506">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.893081982538106,-87.66052558647459],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/plantcloud-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Marketer</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/504">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.808033517004176,-87.7025826238281],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/plantcloud-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/503">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.803427029267496,-87.60027244316404],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/plantcloud-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Plant Cloud</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/501">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.73529882962477,-122.45649435742189],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/music-dj-logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/457">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.769637590885694,-122.40405180676271],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/music-dj-logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/455">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.777710992665305,-122.40422346813966],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/music-dj-logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Musicset DJ</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/452">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.736720997900726,-73.991350082959],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/townhall-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/449">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.760909732966475,-73.98087873896486],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/townhall-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/445">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72063907487923,-74.00358095606691],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/townhall-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Townhall</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/442">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.900093710936666,-87.68438651787108],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/mansilhouette-498x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/440">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.89549384841012,-87.7904732488281],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/mansilhouette-498x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/439">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.85510306003233,-87.7183754705078],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/mansilhouette-498x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Man Silhouette</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/437">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.75565970228647,-122.48327353222658],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/solidsociety-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/435">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.76229274332331,-122.41128304226686],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Cyberoam-Preview.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Digital PR manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/434">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.78563088932842,-122.41501667721559],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/solidsociety-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">SolidSociety</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/432">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.706131115359234,-74.01763573130495],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/media-fury-production.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">PR manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/430">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72533884560117,-74.000533966626],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/media-fury-production.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/429">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72624948943461,-73.99323835810549],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/media-fury-production.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">MediaFury</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/427">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.78704572394614,-87.96762778984373],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/TracksnBeats-logo-download.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/425">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.88367323787924,-87.64374568687742],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/TracksnBeats-logo-download.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/424">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.7817977017611,-87.68803432213133],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/TracksnBeats-logo-download.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Tracks and Beats</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/422">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72215149405797,-73.97950544794924],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/monkeyrule-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/420">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.76273003437759,-73.97298231562502],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/monkeyrule-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/419">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.69118070743963,-73.97521391352541],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/monkeyrule-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">MonkeyRule</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/417">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.74561570516129,-122.49700644238283],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/zpeedy-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Marketer</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/415">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.80558797743989,-122.41014578564454],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/zpeedy-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/414">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.77516694858126,-122.40918019039918],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/zpeedy-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">ZpeedyLetter</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/412">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.88531867011119,-87.62771680580443],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Global-Valley-Logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/410">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.873464221104655,-87.63065650688475],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Global-Valley-Logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Business Consultant</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/409">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.86937376620413,-87.62808158623045],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Global-Valley-Logo.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Global Valley</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/407">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.707806523246546,-74.00216474970705],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Cyberoam-Preview.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Online PR manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/405">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.70790411852334,-74.00752916773683],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/birdfly-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Customer Assistant</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/403">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.778185871197984,-122.4328480027466],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/birdfly-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">BirdFly</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/394">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.69573613816446,-73.98654356440431],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/goodwaves-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Marketer</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/383">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.70595218581224,-74.01291504343874],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/goodwaves-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Technician</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/381">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.7433542685131,-73.99220838984377],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/goodwaves-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">GoodWaves</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/372">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.890638078528575,-87.78154685722654],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/network-solutions.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Insurance Planner</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/369">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.84180430655356,-87.70601585136717],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/network-solutions.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">HR Manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/367">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.885222820852235,-87.64511897789305],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/network-solutions.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Network Solutions</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/358">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.77358959728355,-122.43276217205812],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/bloxkspilled-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Truck Driver</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/355">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.78417247103689,-122.42694714291383],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/bloxkspilled-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Business Consultant</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/353">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.764481007451785,-122.42765524609376],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/bloxkspilled-493x328.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Bloxks Piled</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/343">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.71408486133612,-73.9923585935486],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Cyberoam-Preview.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Online PR Manager</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/340">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.72605435251928,-73.98800268610842],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Cyberoam-Preview.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Customer Assistant</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/331">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.7127837,-74.00594130000002],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/Cyberoam-Preview.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Cyberoam</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/322">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.70298141850828,-122.4571810029297],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/william-sanders3.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">William Sanders</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/299">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.87402344264563,-87.92642905937498],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/olivia-murphy1.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Olivia Murphy</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/287">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.713661986690994,-74.03881445368654],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/ethan-grant.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Ethan Grant</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/278">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.63177912221374,-122.44344809277345],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/sophia-parker1.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Sophia Parker</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/269">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.681490854615774,-88.17636802421873],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/jacob-nelson.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Jacob Nelson</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/257">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.81393807190219,-73.94036665400392],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/emma-allen.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Emma Allen</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/248">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.71303119944708,-122.40980246289064],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/michael-clark.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Michael Clark</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/239">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.82773530897622,-87.67031028496092],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/jennifer-watson1.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Jennifer Watson</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/228">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.69404415739639,-73.93590345820314],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/marco-robinson1.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Marco Robinson</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/220">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.683149475813075,-122.45031454785158],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/jessica-smith1.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Jessica Smith</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/210">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.91031444143993,-87.82961204277342],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/gregory-stewart.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Gregory Stewart</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/199">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.70604978380657,-74.0068210645569],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/meryl-stone.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Meryl Stone</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/188">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.77426803207358,-122.4139008782654],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/mark-jasons.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Mark Jasons</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/175">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.874327018004585,-87.63872459160154],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/hellen-whitehouse1.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Hellen Whitehouse</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/166">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.731371628820554,-74.04216185053713],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/john-ramirez.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">John Ramirez</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/154">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.787658,-122.42854869999996],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/profile-3.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Mary Johnsons</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/145">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [41.887043932183126,-87.64868095146483],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/pilor38.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">John Doe</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/137">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.774183228065276,-122.4206385873108],
									options: {
										icon: "images/icon-job.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/80-author.png" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">UI/UX Design</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/job/102">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [40.70348359757785,-73.98117923547363],
									options: {
										icon: "images/icon-company.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/80-author.png" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Themes Dojo</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/company/86">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

								}
							,

							 
								{

									latLng: [37.774590286418004,-122.42817023022462],
									options: {
										icon: "images/icon-resume.png",
										shadow: "images/shadow.png",
									},
									data: '<div class="marker-holder"><div class="marker-content"><div class="marker-image"><span class="helper"></span><img src="images/tumblr_mw2b8qu8IW1r46py4o1_1280.jpg" /></div><div class="marker-info-holder"><div class="marker-info"><div class="marker-info-title">Alex Gurghis</div><div class="marker-info-link"><a href="http://alexgurghis.com/themes/wpjobus/resume/52">View Profile</a></div></div></div><div class="arrow-down"></div><div class="close"></div></div></div>'

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

