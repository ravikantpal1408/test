<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" Async="true" CodeBehind="Bin_map_new.aspx.cs" Inherits="WebApplication1.Bin_map_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <script src="dist1/sweetalert-dev.js"></script>
     <link href="dist1/sweetalert.css" rel="stylesheet" />
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true"  runat="server"></asp:ScriptManager>
        <div id="map_show" style="height:600px"></div>

    <br />
    <div>
        <style type="text/css">
            .drp_1 {
                width:200px;
                height:25px;

            }
        </style>
        <div class="row">
            <div class="col-sm-4">
      
                <fieldset><legend>Filters</legend>
                  <asp:DropDownList ID="ddl_filter" CssClass="drp_1" runat="server" OnSelectedIndexChanged="ddl_filter_SelectedIndexChanged"  >
                       <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                       <asp:ListItem Value="1">Bins</asp:ListItem>
                       <asp:ListItem Value="2">Feeders</asp:ListItem>
                       <asp:ListItem Value="3">Processing Units</asp:ListItem>

                    </asp:DropDownList>
                    </fieldset>
    <br />
                <div class="col-sm-4" style="display:none" id="div_bin_type">
                
                <fieldset><legend>Type</legend></fieldset>
         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="binType"  CssClass="drp_1" runat="server">
                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                        <asp:ListItem Value="E">Empty</asp:ListItem>
                        <asp:ListItem Value="H">Half-Filled</asp:ListItem>
                        <asp:ListItem Value="F">Full</asp:ListItem>


            </asp:DropDownList>
             
          </ContentTemplate>
    </asp:UpdatePanel>

</div>
          </div>
             <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
            <script type="text/javascript">

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




                });

</script>

            
            <div class="col-sm-4">
                <fieldset><legend>Zone Wise</legend></fieldset>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddl_zone" CssClass="drp_1" runat="server" OnSelectedIndexChanged="ddl_zone_SelectedIndexChanged">
                    


                </asp:DropDownList>
          </ContentTemplate>
    </asp:UpdatePanel>

</div>
            <div class="col-sm-4">
        <fieldset><legend>Ward Wise</legend></fieldset>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <asp:DropDownList ID="ddl_ward" CssClass="drp_1"   runat="server"></asp:DropDownList>
                </ContentTemplate>
    </asp:UpdatePanel>
            </div>
        </div>
        <br />
    <div style="margin-left:1%">
        <fieldset><legend>Indicators :</legend></fieldset>
       
            <div id="d1" class="col-sm-4" style="width:800px">
                <asp:Label ID="Label1" runat="server" Text="Filled Bins"></asp:Label>&nbsp&nbsp<img id="img1" src="map_img/R_BIN1.png" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
               

                <asp:Label ID="Label2" runat="server" Text="Empty Bins"></asp:Label>&nbsp&nbsp<img id="img2" src="map_img/G_BIN1.png" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                

                <asp:Label ID="Label3" runat="server" Text="Half-Filled Bins"></asp:Label>&nbsp&nbsp<img id="img3" src="map_img/O_BIN1.png" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

            </div><br /><br />
            <div id="d4" class="col-sm-4" style="width:150px">
                <asp:Label ID="Label4" runat="server" Text="Feeder Point"></asp:Label>&nbsp&nbsp<img id="img4" src="map_img/feeder_point.png" />

            </div>
            <div id="d5" class="col-sm-4">
                <asp:Label ID="Label5" runat="server" Text="Processing Units"></asp:Label>&nbsp&nbsp<img id="img5" src="map_img/PU.png" />
            </div>
    </div>
    </div>



    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
 <script type="text/javascript">

 </script>




    <script src="https://maps.googleapis.com/maps/api/js?libraries=places&key=AIzaSyCMlNhGUiUZBM1dHIFDZz1NAFUbN7f_epA"></script>
   
      <script type="text/ecmascript">


      </script>
    
        <script type="text/javascript">

            window.onload = function () {


                initialize(0, 0, 0, 0);

            }

            $("#<%=binType.ClientID%>").change(function () {
                var zone = $("#<%=ddl_zone.ClientID%>").val();
                var ward = $("#<%=ddl_ward.ClientID%>").val();
                var sf = $("#<%=ddl_filter.ClientID%>").val();
                var bintype = $("#<%=binType.ClientID%>").val();


                if (sf == '1' && (zone == '0' || zone == '' || zone == null) && bintype == '0')
                    //&& (ward == '0' || ward == null|| ward=='') 
                {
                    // alert(ward);
                    initialize(1, 0, 0, 0);


                }
                if (sf == '1' && (zone == '0' || zone == '') && (bintype != '' || bintype != '0'))// && (ward == null || ward == '0'|| ward=='')
                {


                    // alert(ward);
                    initialize(1, 0, 0, bintype);


                }
                if (sf == '1' && zone != '' && (bintype != '' || bintype != '0'))
                    //&& (ward == '0' || ward == null || ward == '')
                {


                    //   alert(ward);
                    if (ward == null) {
                        initialize(1, zone, 0, bintype);
                    } else {
                        initialize(1, zone, ward, bintype);
                    }

                }


            });
            $("#<%=ddl_zone.ClientID%>").change(function () {
                var zone = $("#<%=ddl_zone.ClientID%>").val();
                var ward = $("#<%=ddl_ward.ClientID%>").val();
                var selected_filter = $("#<%=ddl_filter.ClientID%>").val();
                var type = $("#<%=binType.ClientID%>").val();

                if (selected_filter == '0' || selected_filter == '') {
                    initialize(0, zone, 0, 0);
                    //alert("Please select Bins option from Filters !!");
                }
                if (selected_filter == '1' && (type == '' || type == '0' || type == null))//&& (ward=='0'||ward==null||ward=='')
                {

                    initialize(1, zone, 0, 0);


                }
                if (selected_filter == '1' && (type != '' || type != '0' || type != null))//&& (ward == '0' || ward == null || ward == '')
                {
                    initialize(1, zone, 0, type);
                }
               
                if (selected_filter == '2') {

                    initialize(2, zone, 0, 0);

                }
                if (selected_filter == '3') {

                    initialize(3, zone, 0, 0);

                }
                //   initialize(4,zone,0);
            });

            $("#<%=ddl_ward.ClientID%>").change(function () {
                var ward = $("#<%=ddl_ward.ClientID%>").val();
                var zone = $("#<%=ddl_zone.ClientID%>").val();
                var selected_filter = $("#<%=ddl_filter.ClientID%>").val();
                var type = $("#<%=binType.ClientID%>").val();

                if (selected_filter == '0' && zone != '0') {
                    initialize(0, zone, ward, 0);
                }

                if (selected_filter == '1' && (ward != '' || ward != null || ward != '0') && (zone != '0' || zone != '' || zone != null)) {
                    initialize(1, zone, ward, type);
                }
                else if (selected_filter == '1' && (zone == '0' || zone == '' || zone == null))//&& (ward == '' || ward == null || ward == '0')
                {
                    initialize(1, 0, 0, 0);
                }
                if (selected_filter == '2') {
                    initialize(2, zone, ward, 0);


                }
                if (selected_filter == '3') {
                    initialize(3, zone, ward, 0);


                }

            });


            $("#<%=ddl_filter.ClientID%>").change(function () {
                var value = $("#<%=ddl_filter.ClientID%>").val();
                // if()

                //alert(value);
                if (value == 1) {

                    initialize(1, 0, 0, 0);

                    document.getElementById("div_bin_type").style.display = 'block';
                    document.getElementById('d1').style.display = 'block';
                    document.getElementById('d4').style.display = 'none';
                    document.getElementById('d5').style.display = 'none';

                }
                else {
                    document.getElementById("div_bin_type").style.display = 'none';
                }

                if (value == 2) {
                    initialize(2, 0, 0, 0);
                    document.getElementById('d4').style.display = 'block';
                    document.getElementById('d1').style.display = 'none';

                    document.getElementById('d5').style.display = 'none';
                }
                if (value == 3) {
                    initialize(3, 0, 0, 0);
                    document.getElementById('d1').style.display = 'none';
                    document.getElementById('d5').style.display = 'block';
                    document.getElementById('d4').style.display = 'none';
                }
                if (value == 0) {
                    initialize(0, 0, 0, 0);



                    document.getElementById('d1').style.display = 'block';
                    document.getElementById('d4').style.display = 'block';
                    document.getElementById('d5').style.display = 'block';

                }
            });

            function initialize(m, n, l, type) {




                var btype = type;
                var zone = n;
                var markers;
                var value = m;
                var j = 0;
                var ward = l;

                // alert(ward);
                //alert(value);
                $.ajax({
                    type: 'POST',
                    url: 'Bin_map_new.aspx/ConvertDataTabletoString',
                    data: "{ 's' : '" + value + "','zone':'" + zone + "','ward':'" + ward + "','type':'" + btype + "'}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
         

                        if (data.d == '') {

                            //  alert("No Such Bin Found");
                            sweetAlert("Oops...", "NO SUCH BINS ARE FOUND !", "error");



                        }
                        markers = data.d;
                   


                        var mapOptions = {
                            center: new google.maps.LatLng(markers[0].lat, markers[0].lon),
                            zoom: 13,
                            mapTypeId: google.maps.MapTypeId.ROADMAP
                           
                            // marker:true
                        };


                        var infoWindow = new google.maps.InfoWindow();
                        var latlngbounds = new google.maps.LatLngBounds();
                        var map = new google.maps.Map(document.getElementById("map_show"), mapOptions);
                        var i = 0;
                        var m = 0;

                        var interval = setInterval(function () {
                        var data = markers[i]

                        var myLatlng = new google.maps.LatLng(data.lat, data.lon)


            

                     
                        var icon;

                       
                            switch (data.Bin_Type) {

                                case "F":

                                    if (data.Priority == "HIGH") {
                                        
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
                                    google.maps.event.addListener(marker, "rightclick", function () {
                                        infoWindow.setContent("<div style='width:100px'><b>SET PRIORITY</b></br><a href='javascript:;' onclick='ravi();' id='h'style='color:black'>HIGH</a>&nbsp;&nbsp;<i style='color:red' class='fa fa-dot-circle-o' aria-hidden='true'></i><br><a id='med' onclick='ravi();' style='color:black'>MED</a><br><a id='low' style='color:black' onclick='ravi();'>LOW</a><br><a id='remove' style='color:black' onclick='ravi();'>Remove</a></div>");
                                        infoWindow.open(map, marker);



                                        $(function () {
                                            $('#h').click(function () {

                                                var priority = document.getElementById('h').text;
                                                var ll = data.lat;
                                                // alert(ll);
                                                if (priority == 'HIGH') {
                                                    //    alert(priority);
                                                    $.ajax({
                                                        type: 'POST',
                                                        url: 'Bin_map_new.aspx/setpriority',
                                                        data: "{ 'prior' : '" + priority + "','lat':'" + ll + "'}",
                                                        contentType: 'application/json; charset=utf-8',
                                                        dataType: 'json',
                                                        success: function (data) {
                                                            // alert(data.d);
                                                            initialize(0, 0, 0, 0);
                                                        }
                                                    });
                                    
                                                }
                                                //    initialize(0, 0, 0);
                                            });



                                        });
                                        $(function () {
                                            $('#med').click(function () {

                                                var priority = document.getElementById('med').text;
                                                var ll = data.lat;
                                                if (priority == 'MED') {
                                                    $.ajax({
                                                        type: 'POST',
                                                        url: 'Bin_map_new.aspx/setpriority',
                                                        data: "{ 'prior' : '" + priority + "','lat':'" + ll + "'}",
                                                        contentType: 'application/json; charset=utf-8',
                                                        dataType: 'json',
                                                        success: function (data) {
                                                            //alert(data.d);
                                                            initialize(0, 0, 0, 0);
                                                        }
                                                    });


                                                }
                                                //   initialize(0, 0, 0);
                                            });





                                        });
                                        $(function () {
                                            $('#low').click(function () {

                                                var priority = document.getElementById('low').text;
                                                var ll = data.lat;

                                                if (priority == 'LOW') {
                                                    $.ajax({
                                                        type: 'POST',
                                                        url: 'Bin_map_new.aspx/setpriority',
                                                        data: "{ 'prior' : '" + priority + "','lat':'" + ll + "'}",
                                                        contentType: 'application/json; charset=utf-8',
                                                        dataType: 'json',
                                                        success: function (data) {
                                                            // alert(data.d);
                                                            initialize(0, 0, 0, 0);
                                                        }
                                                    });
                                                                                                        
                                                }
                                                //    initialize(0, 0, 0);
                                            });






                                        });
                                        $(function () {

                                            $('#remove').click(function () {

                                                var priority = document.getElementById('remove').text;
                                                //alert(priority);
                                                var ll = data.lat;
                                                // alert(ll);
                                                if (priority == 'Remove') {
                                                    //    alert(priority);
                                                    $.ajax({
                                                        type: 'POST',
                                                        url: 'Bin_map_new.aspx/setpriority',
                                                        data: "{ 'prior' : '" + priority + "','lat':'" + ll + "'}",
                                                        contentType: 'application/json; charset=utf-8',
                                                        dataType: 'json',
                                                        success: function (data) {
                                                            //  alert(data.d);
                                                            initialize(0, 0, 0, 0);
                                                        }
                                                    });
                                     
                                                }
                                           
                                            });

                                        });




                                    });


                                }

                                google.maps.event.addListener(marker, "click", function (e) {
                                    infoWindow.setContent(data.Areaid, data.AreaName);



                                    if (data.Bin_Type == "FED" || data.Bin_Type == "PU") {
                                        infoWindow.setContent(data.AreaName);
                                        infoWindow.open(map, marker);

                                    }

                                    else {
                                        //   alert(data.BinId);
                                        //   alert(data.Areaid);


                                        $.ajax({

                                            url: "binPictorialView.aspx?binid=" + data.BinId, asynch: false, success: function (result) {
                                                //alert(result);
                                                infoWindow.setContent(result);
                                                infoWindow.open(map, marker);
                                                //alert(data.BinId);
                                                //alert(data.Areaid);

                                            }
                                        });
                                    }

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




    

   <%-- to display filters--%>
    
</asp:Content>
