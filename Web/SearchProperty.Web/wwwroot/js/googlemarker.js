function initMap() {
    // Create a new map
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 6,
        center: { lat: 42.7250, lng: 25.4833 }
    });

    // Add a click event listener to the map to add a marker when the user clicks on the map
    google.maps.event.addListener(map, 'click', function (event) {
        addMarker(event.latLng, map);
    });

    // Add a marker to the map at the specified location
    function addMarker(location, map) {

        if (map.marker) {
            // Remove the existing marker from the map
            map.marker.setMap(null);
        }

        // Create a new marker
        var marker = new google.maps.Marker({
            position: location,
            map: map
        });

        // Save the marker on the map object
        map.marker = marker;

        // Save the address text for the marker
        var addressText = getAddressText(location);
        marker.addressText = addressText;

        // Add a click event listener to the marker to remove it when the user clicks on it
        google.maps.event.addListener(marker, 'click', function () {
            marker.setMap(null);
        });

        // Get the address text for a given location
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ location: marker.position }, function (results, status) {
            if (status === "OK") {
                if (results[0]) {

                    var address = results[0].formatted_address;
                    document.getElementById('address').innerHTML = address
                    console.log(address);

                    $("#full-address").val(address);
                    $("#street-address").val(results[0].address_components[0].long_name + " " + results[0].address_components[1].long_name);
                    $("#town").val(results[0].address_components[3].long_name);
                    $("#neighborhood ").val(results[0].address_components[2].long_name);
                    $("#lat").val(results[0].geometry.location.lat());
                    $("#lng").val(results[0].geometry.location.lng());

                }
            }
        });
    }
    function getAddressText(location) {
        // Replace this with code to get the address text for the location using the Google Maps Geocoding API

    }
};