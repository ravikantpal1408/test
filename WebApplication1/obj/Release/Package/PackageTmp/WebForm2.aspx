<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="dist1/sweetalert-dev.js"></script>
     <link href="dist1/sweetalert.css" rel="stylesheet" />
    <div id="map" style="height:800px"></div>



     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?libraries=places&key=AIzaSyCMlNhGUiUZBM1dHIFDZz1NAFUbN7f_epA"></script>
   


    <script>


var geocoder;
var map;
var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
var value = 1;

$.ajax({
    type: 'POST',
    url: 'WebForm2.aspx/getbins',
    data: "{ 'm' : '" + value +"'}",
    contentType: 'application/json; charset=utf-8',
    dataType: 'json',
    success: function (data) {


        if (data.d == '') {

            sweetAlert("Oops...", "NO BINS FOUND !", "error");



        }
   
        var locations = data.d;


    //alert(JSON.stringify(data.d));
        function initialize() {
            directionsDisplay = new google.maps.DirectionsRenderer();


            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 14,
                center: new google.maps.LatLng(26.8439479, 80.935326),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            directionsDisplay.setMap(map);
            var infowindow = new google.maps.InfoWindow();

            var marker, i;
          
            var request = {
                travelMode: google.maps.TravelMode.DRIVING
            };
            for (i = 0; i < locations.length; i++)
            {

                var data = locations[i];
                var icon;
               //alert(locations[0].Sequence);


                switch (data.Type) {
                    

                    case "F":

                        if (data.Priority == "HIGH") {
                            //alert(data.Priority);
                            icon = "fullred1";
                            break;
                        }
                        else if (data.Priority == "MED") {
                            icon = "medred1";
                            break;

                        }
                        else if (data.Priority == "LOW") {

                            icon = "lowred1";
                            break;
                        }
                        else {
                            icon = "R_BIN1";
                            break;
                        }
                    case "H":

                        if (data.Priority == "HIGH") {
                            //alert(data.Priority);
                            icon = "fullorange1";
                            break;
                        }
                        else if (data.Priority == "MED") {
                            icon = "medorange1";
                            break;

                        }
                        else if (data.Priority == "LOW") {

                            icon = "loworange1";
                            break;
                        }
                        else {
                            icon = "O_BIN1";
                            break;
                        }
                    case "E":

                        if (data.Priority == "HIGH") {
                            // alert(data.Priority);
                            icon = "fullgreen1";
                            break;
                        }
                        else if (data.Priority == "MED") {
                            icon = "medgreen1";
                            break;

                        }
                        else if (data.Priority == "LOW") {

                            icon = "lowgreen1";
                            break;
                        }
                        else {
                            icon = "G_BIN1";
                            break;
                        }
                    case "FED":
                        icon = "feeder_point";
                        break;
                    case "PU":
                        icon = "PU";
                        break;


                }
                //alert(icon);
                icon = "map_img/" + icon + ".png";

                // var t=markers[i][i]; 



                
                    marker = new google.maps.Marker({
                            icon: new google.maps.MarkerImage(icon),
                            position: new google.maps.LatLng(data.lat, data.lon),
                            map: map
      
                    });
                  //  marker.addListener('click', toggleBounce);

                google.maps.event.addListener(marker, 'click', (function(marker, i) {
                    return function () {
                        //alert(locations[i].BinId);
                        infowindow.setContent(locations[i].BinName);
                        infowindow.open(map, marker);
                    }
                })(marker, i));
                if (i == 0) request.origin = marker.getPosition();
                else if (i == locations.length - 1) request.destination = marker.getPosition();
                else {
                    if (!request.waypoints) request.waypoints = [];
                    //alert(marker.getPosition());
                    request.waypoints.push({
                        location: marker.getPosition(),
                        stopover: true
                    });
                }

            }
            directionsService.route(request, function (result, status) {
                //alert(JSON.stringify(result));
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(result);
                }
            });
        
        }
        google.maps.event.addDomListener(window, "load", initialize);
        
    }
});
    
    </script>
    
</asp:Content>
