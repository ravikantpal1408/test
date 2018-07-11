<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="assign_bin_through_map.aspx.cs" Inherits="WebApplication1.assign_bin_through_map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true"  runat="server"></asp:ScriptManager>
    
    <script   src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCMlNhGUiUZBM1dHIFDZz1NAFUbN7f_epA&libraries=places&callback=init"></script>
     
         
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script>
        $(function () {
            // alert("ok");
            $.ajax({
                type: "POST",
                url: "Bin_map_new.aspx/GetCustomers",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var ddlCustomers = $("[id*=ddl_zone]");
                    ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                    $.each(r.d, function () {
                        ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                }
            });

            $("#<%=ddl_zone.ClientID%>").change(function () {
                // alert("Handler for .change() called.");
                var value = $("#<%=ddl_zone.ClientID%>").val();

                  $.ajax({
                      type: "POST",
                      url: "Bin_map_new.aspx/Getwards",
                      data: "{ 'zone' : '" + value + "'}",
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (r) {
                          var ddlCustomers = $("[id*=ddl_ward");
                          ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                          $.each(r.d, function () {
                              ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                          });
                      }
                  });



            });



            $("#<%=ddl_ward.ClientID%>").change(function () {
              //  alert("ok")
                // alert("Handler for .change() called.");
                var value = $("#<%=ddl_ward.ClientID%>").val();
                alert(value)
                        $.ajax({
                            type: "POST",
                            url: "assign_bin_through_map.aspx/get_route",
                            data: "{ 'ward' : '" + value + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {
                                alert("ok")
                                var ddlCustomers = $("[id*=ddl_route");
                                ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                $.each(r.d, function () {
                                    ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                });
                            }
                        });



                    });






        });
    </script>

    <script type="text/javascript">

        window.onload = function () {


            init(1, 0, 0, 0);

        }

        function init(m, n, l, type) {




            var btype = type;
            var zone = n;
            var markers;
            var value = m;
            var j = 0;
            var ward = l;

            $.ajax({
                type: 'POST',
                url: 'Bin_map_new.aspx/ConvertDataTabletoString',
                data: "{ 's' : '" + value + "','zone':'" + zone + "','ward':'" + ward + "','type':'" + btype + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {


                    if (data.d == '') {

                        alert("No Such Bin Found");



                    }
                    markers = data.d;

                    //  alert(JSON.stringify(data.d));

                    var mapOptions = {
                        center: new google.maps.LatLng(26.8439479, 80.935326),
                        zoom: 14,
                        mapTypeId: google.maps.MapTypeId.ROADMAP

                        // marker:true
                    };


                    var infoWindow = new google.maps.InfoWindow();
                    var latlngbounds = new google.maps.LatLngBounds();
                    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
                    var i = 0;
                    var m = 0;

                    var interval = setInterval(function () {
                        var data = markers[i]

                        var myLatlng = new google.maps.LatLng(data.lat, data.lon)





                        var icon;


                        switch (data.Bin_Type) {

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

                        var marker = new google.maps.Marker({
                            position: myLatlng,
                            map: map,
                            title: data.AreaName,
                            Type: data.Bin_Type,
                            //animation: google.maps.Animation.DROP,
                            icon: new google.maps.MarkerImage(icon)
                        });

                        (function (marker, data) {
                            if (data.Bin_Type == 'F' || data.Bin_Type == 'H' || data.Bin_Type == 'E') {



                            }

                            google.maps.event.addListener(marker, "click", function (e) {
                                //alert()
                                infoWindow.setContent(data.AreaName);





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
            });
        }


        </script>
    <div id="map" style="height:600px" ></div>
           

                    <div class="col-sm-4">
                     <fieldset><legend>Zone Wise</legend></fieldset>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
    
                             <asp:DropDownList ID="ddl_zone" runat="server"></asp:DropDownList>
                
               
                        </ContentTemplate>
                    </asp:UpdatePanel>
                     
                     </div>
        <div class="col-sm-4">
                     <fieldset><legend>Ward Wise</legend></fieldset>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
    
                             <asp:DropDownList ID="ddl_ward" runat="server"></asp:DropDownList>
                
           
                        </ContentTemplate>
                    </asp:UpdatePanel>
                     
                     </div>
            <div class="col-sm-4">
                     <fieldset><legend>Route</legend></fieldset>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
    
                             <asp:DropDownList ID="ddl_route" runat="server"></asp:DropDownList>
                
               
                        </ContentTemplate>
                    </asp:UpdatePanel>
                     
                     </div>



</asp:Content>
