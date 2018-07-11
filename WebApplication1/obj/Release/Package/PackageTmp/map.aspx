<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="WebApplication1.map" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Map</title>
    <link rel="stylesheet" type="text/css" href="tcal.css" />
	<script type="text/javascript" src="tcal.js"></script> 
    <link href="vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Custom%20CSS/Custom.css" rel="stylesheet" />
    <link href="Custom%20CSS/map.css" rel="stylesheet" />
    <link href="vendor/morrisjs/morris.css" rel="stylesheet" />
    <link href="vendor/metisMenu/metisMenu.css" rel="stylesheet" />
    <link href="vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="dist/css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="Custom%20CSS/toggle.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper" >

        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <a class="navbar-brand" id="dash_123" href="test123.aspx">
                  <div class="navbar-header" id="dash_1" >
                    <span style="font-size:30px;cursor:pointer" >&#9776;MAIN DASHBOARD</span>
                      <script type="text/javascript">

                      </script>
              
                  </div>
              
             </a>
            

                     
         </nav>
        <div id="map_show" style="height:500px">
            <asp:Label ID="area" runat="server" display="false"></asp:Label>
            <asp:Label ID="lat" runat="server"  display="false"></asp:Label>
            <asp:Label ID="lon" runat="server"  display="false"></asp:Label>
        </div>

         <script src="http://maps.google.com/maps/api/js?sensor=false"></script>
         <%--<script>
             var labels = 'bin';
             var labelIndex = 0;
             function initialize() {
                 var map_area = document.getElementById("area").value;
                 
                 var map_lat = document.getElementById("lat").value;
                 var map_lon = document.getElementById("lon").value;
                 var locations = [
                     [map_area, map_lat, map_lon],
                     //['Empty', 26.8570044, 80.9446608],
                     ['Empty', 26.8593074, 80.9087018]
                 ];
                 var locations2 = [
                    ['half-Empty', 26.8563611, 80.9457686],
                    ['half-Empty', 26.8570034, 80.9447708],
                    ['half-Empty', 26.8593374, 80.9045918]
                 ];
                 var locations3 = [
                    ['Filled', 26.8563711, 80.9437686],
                    ['Filled', 26.8570934, 80.9447508],
                    ['Filled', 26.8893374, 80.9145918]
                 ];
                 console.log('in')

                 var mapOptions = {
                     center: new google.maps.LatLng(22.5488912, 88.3956024),
                     zoom:14,
                     mapTypeControl: false,
                     panControl: false,
                     streetViewControl: false,
                     zoomControl: false,
                     disableDoubleClickZoom: true,
                 };
                 var map = new google.maps.Map(document.getElementById('map_show'), mapOptions);
                 var marker, marker2, marker3, k, j, i;
                 
                 var infowindow = new google.maps.InfoWindow();
                 for (i = 0; i < locations.length; i++) {
                     
                     var p = new google.maps.LatLng(locations[i][1], locations[i][2]);
                     marker = new google.maps.Marker({
                         icon: 'map_img/bin_g.png',
                         position: p,
                         label: labels[labelIndex++ % labels.length],
                         map: map,
                        
                     });
                     google.maps.event.addListener(marker, 'click', (function (marker, i) {
                         return function () {
                             infowindow.setContent(locations[i][0]);
                             infowindow.open(map, marker);
                         }
                     })(marker, i));
                 }
                 for (j = 0; j < locations2.length; j++) {
                     var q = new google.maps.LatLng(locations2[j][1], locations2[j][2]);
                     marker2 = new google.maps.Marker({
                         icon: 'map_img/bin_o1.png',
                         position: q,
                         label: labels[labelIndex++ % labels.length],
                         map: map,
                        
                     });
                     google.maps.event.addListener(marker2, 'click', (function (marker2, j) {
                         return function () {
                             infowindow.setContent(locations2[j][0]);
                             infowindow.open(map, marker2);
                         }
                     })(marker2, j));
                 }
                 for (k = 0; k < locations3.length; k++) {
                     var r = new google.maps.LatLng(locations3[k][1], locations3[k][2]);
                     marker3 = new google.maps.Marker({
                         icon: 'map_img/bin_red1.png',
                         label: labels[labelIndex++ % labels.length],
                         position: r,
                         map: map,
                     
                     });
                     google.maps.event.addListener(marker3, 'click', (function (marker3, k) {
                         return function () {
                             infowindow.setContent(locations3[k][0]);
                             infowindow.open(map, marker3);
                         }
                     })(marker3, k));

                 }
             }
             google.maps.event.addDomListener(window, 'load', initialize);
         </script>--%>
        <script type="text/javascript">
            var markers = [
            <asp:Repeater ID="rptMarkers" runat="server">
            <ItemTemplate>
                     {
                         "title": '<%# Eval("AreaName") %>',
                         "lat": '<%# Eval("Latitude") %>',
                         "lng": '<%# Eval("Longitude") %>',
                         "Type": '<%# Eval("Type") %>'
            
                      }
        </ItemTemplate>
        <SeparatorTemplate>
              ,
            </SeparatorTemplate>
            </asp:Repeater>
                ];
</script>
        <script type="text/javascript">

            window.onload = function () {

                var mapOptions = {
                    center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                    zoom: 4,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                var infoWindow = new google.maps.InfoWindow();
                var latlngbounds = new google.maps.LatLngBounds();
                var map = new google.maps.Map(document.getElementById("map_show"), mapOptions);
                var i = 0;
                var interval = setInterval(function () {
                    var data = markers[i]
                    var myLatlng = new google.maps.LatLng(data.lat, data.lng);

                    // to resizee images on map

                    var icon 
                    //= {

                    //    scaledSize: new google.maps.Size(50, 50), // scaled size
                    //    origin: new google.maps.Point(0, 0), // origin
                    //    anchor: new google.maps.Point(0, 0) // anchor
                    //};


                    //



                    // var icon = "";

                    switch (data.Type) {
                        case "E":
                            icon = "bin_g";
                            break;
                        case "F":
                            icon = "bin_red1";
                            break;
                        case "H":
                            icon = "bin_o1";
                            break;
                    }
                    icon = "map_img/" + icon + ".png";

                    var marker = new google.maps.Marker({
                        position: myLatlng,
                        map: map,
                        title: data.title,
                        animation: google.maps.Animation.DROP,
                        icon: new google.maps.MarkerImage(icon)
                    });
                    (function (marker, data) {
                        google.maps.event.addListener(marker, "click", function (e) {
                            infoWindow.setContent(data.Areaid);

                           // $.ajax({
                               // url: "binPictorialView.aspx?binid=" + data.bin + "&areaid=" + data.Areaid, asynch: false, success: function (result) {
                                    infoWindow.setContent(data.title);
                                    infoWindow.open(map, marker);
                               // }
                          //  });



                            //alert("hello");
                            infoWindow.open(map, marker);
                        });

                    })(marker, data);
                    latlngbounds.extend(marker.position);
                    i++;
                    if (i == markers.length) {
                        clearInterval(interval);
                        var bounds = new google.maps.LatLngBounds();
                        map.setCenter(latlngbounds.getCenter());
                        map.fitBounds(latlngbounds);
                    }
                }, 80);

            }


        </script>
      

        
    
    </div>
        

        






    </form>







     <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBu5nZKbeK-WHQ70oqOWo-_4VmwOwKP9YQ"></script>
   
    <script src="js/map_123.js"></script>
    
   <script src="../vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="../vendor/raphael/raphael.min.js"></script>
    <script src="../vendor/morrisjs/morris.min.js"></script>
    <script src="../data/morris-data.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>
    <script src="js/toggle.js"></script>
</body>
</html>
