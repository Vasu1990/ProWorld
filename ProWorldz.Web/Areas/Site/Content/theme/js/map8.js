var mapDiv,
        map,
        infobox;
jQuery(document).ready(function($) {

    mapDiv = $("#resume-map");
    mapDiv.height(600).gmap3({
        map: {
            options: {
                "center": [37.76950189592819, -122.40192749722291]
                , "zoom": 16
                , "draggable": true
                , "mapTypeControl": true
                , "mapTypeId": google.maps.MapTypeId.ROADMAP
                , "scrollwheel": false
                , "panControl": true
                , "rotateControl": false
                , "scaleControl": true
                , "streetViewControl": true
                , "zoomControl": true
                , "styles": [
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
                ]}
        }
        , marker: {
            values: [
                {
                    latLng: [37.76950189592819, -122.40192749722291],
                    options: {
                        icon: "images/icon-services.png",
                        shadow: "images/shadow.png",
                    }
                }

            ],
            options: {
                draggable: false
            }
        }
    });

    map = mapDiv.gmap3("get");

    infobox = new InfoBox({
        pixelOffset: new google.maps.Size(-50, -65),
        closeBoxURL: '',
        enableEventPropagation: true
    });
    mapDiv.delegate('.infoBox .close', 'click', function() {
        infobox.close();
    });

    if (Modernizr.touch) {
        map.setOptions({draggable: false});
        var draggableClass = 'inactive';
        var draggableTitle = "Activate map";
        var draggableButton = $('<div class="draggable-toggle-button ' + draggableClass + '">' + draggableTitle + '</div>').appendTo(mapDiv);
        draggableButton.click(function() {
            if ($(this).hasClass('active')) {
                $(this).removeClass('active').addClass('inactive').text("Activate map");
                map.setOptions({draggable: false});
            } else {
                $(this).removeClass('inactive').addClass('active').text("Deactivate map");
                map.setOptions({draggable: true});
            }
        });
    }

});
