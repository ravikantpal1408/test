<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <div>
   
       
     <script src="https://maps.googleapis.com/maps/api/js?libraries=places&key=AIzaSyCMlNhGUiUZBM1dHIFDZz1NAFUbN7f_epA"></script>
      

<script type="text/javascript">
    function initialize() {
        var input = document.getElementById('searchTextField');
        //alert(input);
        var autocomplete = new google.maps.places.Autocomplete(input);
        alert(autocomplete);
        google.maps.event.addListener(autocomplete, 'place_changed', function() {
            var place = autocomplete.getPlace();
            alert(place);
            //var = place.name;
            var lat = place.geometry.location.lat();
            alert(lat);

            var lon = place.geometry.location.lng();
            alert(lon);
            //alert("This function is working!");
            //alert(place.name);
            //alert(place.address_components[0].long_name);

        });
    }
    google.maps.event.addDomListener(window, 'load', initialize);

</script>


        <%--<script type="text/javascript">
            var loc = document.getElementById("searchTextField").value;
            alert(loc);
            function getLatLngFromAddress(loc) {

                var address = loc;
                var geocoder = new google.maps.Geocoder();

                geocoder.geocode({ 'address': address }, function (results, status) {

                    if (status == google.maps.GeocoderStatus.OK) {
                        $('#latitude').val(results[0].geometry.location.Pa);
                        $('#longitude').val(results[0].geometry.location.Qa);

                    } else {
                        console.log("Geocode was not successful for the following reason: " + status);
                    }
                });
            }

        </script>--%>

<input id="searchTextField" type="text" size="50" placeholder="Enter a location" autocomplete="on" runat="server" />  

    </div>
 
</body>
</html>
