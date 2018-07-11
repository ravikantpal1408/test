<%@ Page Title="" Language="C#"  EnableEventValidation="false" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true"  CodeBehind="pre_defined_routes.aspx.cs" Inherits="WebApplication1.pre_defined_routes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script src="dist1/sweetalert-dev.js"></script>
    <link href="dist1/sweetalert.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true"  runat="server"></asp:ScriptManager>

    <script>
        function ravi() {
           
            var input = document.getElementById('address');              
            var geocoder = new google.maps.Geocoder();
            var autocomplete = new google.maps.places.Autocomplete(input);
         
            autocomplete.addListener('place_changed', function () {
                getLatitudeLongitude(showResult, address)
                var place = autocomplete.getPlace();
                var lat = place.geometry.location.lat();
                var lon = place.geometry.location.lng();
                if (lat != '' && lon != '')
                { 
                    document.getElementById('txt_lat').value = lat;
                    document.getElementById('txt_lon').value = lon;
                }

            });
            function showResult(result) {

            }
            function getLatitudeLongitude(callback, address) {

                geocoder = new google.maps.Geocoder();
                if (geocoder) {
                    geocoder.geocode({
                        'address': address
                    }, function (results, status) {
                       if (status == google.maps.GeocoderStatus.OK) {
                            callback(results[0]);
                        }
                    });
                }
            }
        }
    </script>

          

    <script   src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCMlNhGUiUZBM1dHIFDZz1NAFUbN7f_epA&libraries=places&callback=ravi"></script>


    <script type ="text/javascript">
        
                function route() {
               
                    
                    //alert("Handler for .change() called.");
                    var routeid = $("#<%=ddl_route_select.ClientID%>").val();
                    var zn = $("#<%=ddl_zone.ClientID%>").val();
                    var wrd = $("#<%=ddl_ward.ClientID%>").val();
                       //       alert(routeid)             
                        if (routeid != "0") {

                            init(1, 0, 0, 0, routeid);
                       
         

                        }
                        else {
                            
                            init(1, zn, wrd, 0, 0);
                        }

             

            }

    </script>
    <script>



    </script>
    <script>

        $(function () {
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
                var zn = $("#<%=ddl_zone.ClientID%>").val();
            
                $.ajax({

                           type: "POST",
                           url: "Bin_map_new.aspx/Getwards",
                           data: "{ 'zone' : '" + zn + "'}",
                           contentType: "application/json; charset=utf-8",
                           dataType: "json",
                           success: function (r) {
                               
                            
                               if (r.d == null || r.d == '') {
                                   location.reload();


                               }
                               init(1, zn, 0, 0, 0);
                               var ddlCustomers = $("[id*=ddl_ward");
                               ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                               $.each(r.d, function () {
                                   ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                               });
                           }
                       });



                   });

            $("#<%=ddl_ward.ClientID%>").change(function () {
                var wrd = $("#<%=ddl_ward.ClientID%>").val();
                var zn = $("#<%=ddl_zone.ClientID%>").val();
    
                if (wrd != '' || wrd != '0') {

                    $.ajax({
                        type: "POST",
                        url: "pre_defined_routes.aspx/get_route_",
                        data: "{ 'ward' : '" + wrd + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            //if (r.d == null || r.d == '') {


                            // swal('Opss !!', 'No Routes are Defined !!');


                            // }
                            init(1, zn, wrd, 0, 0);


                            var ddlCustomers = $("[id*=ddl_route_select]");
                            ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                            $.each(r.d, function () {
                                ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                            });


                        }
                    });
                }
                //}
               // else {
                  //  var ddlCustomers = $("[id*=ddl_route_select]");
                 //   ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');


                //    swal('Please Select Ward','Thank You!!')

               // }
            });




        });
       
 




    </script>
 


        



   <script type="text/javascript">

       window.onload = function () {


           init(1, 0, 0, 0, 0);

       }

      function init(m, n, l, type,routeid) {


                //alert(routeid)
                var btype = type;
                var zone = n;
                var markers;
                var value = 1;
                var j = 0;
                var ward = l;
                var rid = routeid;
                //alert(rid)
                $.ajax({
                    type: 'POST',
                    url: 'pre_defined_routes.aspx/ConvertDataTabletoString',
                    data: "{ 's' : '" + value + "','zone':'" + zone + "','ward':'" + ward + "','type':'" + btype + "','rid':'"+rid+"'}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {


                        if (data.d == '') {

                            alert("No Such Bin Found");



                        }
                        markers = data.d;

                       // alert(JSON.stringify(markers));

                        var mapOptions = {
                            center: new google.maps.LatLng(26.8439479, 80.935326),
                            zoom: 14,
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
                            //alert(myLatlng)





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
                                        
                                      
                                        infoWindow.setContent("<div style='width:200px'><a  href='javascript:ravi();' id='h' style='color:black'><center><h5>Click</h5></center></a></br><input class='form-control' type='text' id='address' style='display:none' placeholder='Location'></br><input class='form-control' style='display:none' type='text' id='txt_lat' placeholder='Latitude'></br><input class='form-control' style='display:none'  type='text' id='txt_lon' placeholder='Longitude'></br><p>select only route in order to change the path of bin.</p></br><select id='select_route' class='form-control' style='display:none'  style='width:154px'><option>-----Select_Route-----</option><select></br><a  href='javascript:ravi();' id='click' style='color:black;display:none'><center><h5>Change</h5></center></a></div>");
                                        infoWindow.open(map, marker);

                                        //click
                                        $(function () {
                                            $('#click').click(function () {
                                           
                                                alert("bing")
                                                var bname=data.AreaName;
                                              
                                                var binid = data.BinId;
                                                var txtlat = document.getElementById('txt_lat').value;
                                                var txtlon = document.getElementById('txt_lon').value;
                                                var rid = document.getElementById('select_route').value;
                                                //alert(rid);
                                                if (txtlat == '' && txtlon == '') {
                                                    if (rid == '0') {

                                                        alert(rid)
                                                        //  alert("Please UPDATE Lat/lon");

                                                        $.ajax({
                                                            type: "POST",
                                                            url: "pre_defined_routes.aspx/fn_assignment",
                                                            data: "{'binid' : '" + binid + "','lat':'" + data.lat + "','lon' : '" + data.lon + "','rid':'" + rid + "'}",
                                                            contentType: "application/json; charset=utf-8",
                                                            dataType: "json",
                                                            success: function (datas) {

                                                                if (datas.d == '') {
                                                                    alert("No Such Bins!!");


                                                                }
                                                                else {
                                                                    alert("Changes have been applied !!!");
                                                                     init(1, 0, 0, 0, 0);
                                                                }



                                                            }
                                                        });
                                                    }
                                                    else if (rid != '0') {
                                                        //alert("hey")

                                                        $.ajax({
                                                            type: "POST",
                                                            url: "pre_defined_routes.aspx/fn_assignment",
                                                            data: "{'binid' : '" + binid + "','lat':'" + data.lat + "','lon' : '" + data.lon + "','rid':'" + rid + "'}",
                                                            contentType: "application/json; charset=utf-8",
                                                            dataType: "json",
                                                            success: function (datas) {

                                                                if (datas.d == '') {
                                                                    alert("No Such Bins!!");


                                                                }
                                                                else {
                                                                    alert("Changes has been applied !!!");
                                                                     init(1, 0, 0, 0, 0);
                                                                }



                                                            }
                                                        });

                                                    }

                                   
                                                }
                                                else {
                                              

                                                    $.ajax({
                                                        type: "POST",
                                                        url: "pre_defined_routes.aspx/fn_assignment",
                                                        data: "{'binid' : '" + binid + "','lat':'" + txtlat + "','lon' : '" + txtlon + "','rid':'" + rid + "'}",
                                                        contentType: "application/json; charset=utf-8",
                                                        dataType: "json",
                                                        success: function (datas) {

                                                            if (datas.d == '') {
                                                                alert("No Such Bins!!");


                                                            }
                                                            else {
                                                                alert("Changes have been applied !!!");
                                                                init(1, 0, 0, 0, 0);
                                                            }



                                                        }
                                                    });
                                                }



                                            });
                                        });

                                        $(function () {
                                            $('#h').click(function () {
                                                document.getElementById('address').style.display = 'block';
                                                document.getElementById('txt_lat').style.display = 'block';
                                                document.getElementById('txt_lon').style.display = 'block';
                                                document.getElementById('select_route').style.display = 'block';
                                                document.getElementById('click').style.display = 'block';
                                            

                                                $.ajax({
                                                    type: "POST",
                                                    url: "pre_defined_routes.aspx/fn_select_path",
                                                    data: "{}",
                                                    contentType: "application/json; charset=utf-8",
                                                    dataType: "json",
                                                    success: function (r) {

                                                        var ddlCustomers = $("[id*=select_route]");
                                                        ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                                        $.each(r.d, function () {
                                                            ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                                        });


                                                    }
                                                });
                                            

                                            });
                                        });


                                    });
                                    


                                }
                                if (data.Bin_Type == "E" || data.Bin_Type == "F" || data.Bin_Type == "H") {
                                    google.maps.event.addListener(marker, "click", function (e) {
                                        infoWindow.setContent("<div style='width:200px'><center><a  href='javascript:ravi();' id='h' style='color:black'><h5>Bin Info:</h5></a></br><b>BinID:<a style='color:black'>" + data.BinId + "</a></b></br><b>Bin Name : </b><b><a style='color:black'>" + data.AreaName + "</a></b></center></div>");
                                        infoWindow.open(map, marker);
                                    });
                                }


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


    <div id="map_show" style="height:600px" >
    
    </div>

     <br />
    <div class="row">
    <div class="col-sm-4">
           
        <fieldset><legend>Select Zone</legend></fieldset>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                    <asp:DropDownList ID="ddl_zone"  runat="server" Height="25px" Width="200px" ></asp:DropDownList>
               </ContentTemplate>
         </asp:UpdatePanel>
      

      </div>
        <div class="col-sm-4">
           
        <fieldset><legend>Select Ward</legend></fieldset>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
               <ContentTemplate>
                    <asp:DropDownList ID="ddl_ward"  runat="server" Height="25px" Width="200px" >

                          <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>

                    </asp:DropDownList>
               </ContentTemplate>
         </asp:UpdatePanel>
      

      </div>
      <div class="col-sm-4">
           
        <fieldset><legend>Select Route</legend></fieldset>
         <asp:UpdatePanel ID="udp_route" runat="server">
               <ContentTemplate>
                    <asp:DropDownList ID="ddl_route_select"  onchange="route();" runat="server" Height="25px" Width="200px" >

                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>


                    </asp:DropDownList>
               </ContentTemplate>
         </asp:UpdatePanel>
          <br />
      
 
      </div>

    </div>
    <br />


        
    <br />
    <div class="row" >
            <fieldset><legend><h1>Add Routes </h1></legend></fieldset> 
    </div>
        <div class="col-sm-3">
           
         
           
        <fieldset><legend>Zone</legend></fieldset>
        <select id="ddl_zone_a" class="form-control"><option value="0">Select</option></select>
         </div>
        <div class="col-sm-3">   
          
             <fieldset><legend>Ward</legend></fieldset>
             <select id="ddl_ward_a" class="form-control"><option value="0">Select</option></select>
            </div>
        <div class="col-sm-3"> 
             
            <fieldset><legend>Route Name</legend></fieldset>
            <input type="text" id="txt_route" class="form-control" />
        </div>
          <div class="col-sm-3"> 
           <a  id="r_sbt" class="btn btn-info  textbox"  style="margin-top:50px">Submit</a>
              <a  id="a_edit" class="btn btn-info  textbox"  style="margin-top:50px"  onclick="BindGridView() ;"  data-toggle="modal" data-target="#myModal">Edit</a>



                               <div class="modal fade" id="myModal" role="dialog" >
                                <div class="modal-dialog modal-md">
                                  <div class="modal-content">
                                    <div class="modal-header">
                                      <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                                      <%--<h4 class="modal-title">Type</h4>--%>
                                    </div>
                                        <div class="modal-body">
                                         <h1>Routes Details</h1><br />
                                            <%--<input type="text" placeholder="command" id="cmd" class="form-control" /><br />--%>
                                         
                                          <%--<button type="button" onclick=" send_cmd();" id="send" class="btn btn-primary">Send</button>--%>
                                        </div>
                                      <div class="col-sm-12">
                                            <table id="grdRoute" class="table table-bordered table-striped" role="grid" >
                      
                                          </table> 
                                          </div>

                                        <div class="modal-footer">
                                      <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                  </div>
                                </div>
                              </div>
           
        </div>
    <script>
        $(function () {
            $.ajax({
                type: "POST",
                url: "Bin_map_new.aspx/GetCustomers",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {

                    var ddlCustomers = $("[id*=ddl_zone_a]");
                    ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                    $.each(r.d, function () {
                        ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                }
            });

            $("#ddl_zone_a").change(function () {
                // alert("Handler for .change() called.");
                var zn = $("#ddl_zone_a").val();
               // 
                
                   $.ajax({

                       type: "POST",
                       url: "Bin_map_new.aspx/Getwards",
                       data: "{ 'zone' : '" + zn + "'}",
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       success: function (r) {


                           if (r.d == null || r.d == '') {
                               location.reload();


                           }
                           init(1, zn, 0, 0, 0);
                           var ddlCustomers = $("[id*=ddl_ward_a");
                           ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                           $.each(r.d, function () {
                               ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                           });
                       }
                   });



            });
            $("#ddl_zone_a").change(function () {

                var wrd = $("#ddl_ward_a").val();
                if (wrd != "0") {
                    init(1, zn, wrd, 0, 0);


                }
                else {


                    init(1, zn, wrd, 0, 0);

                }



            });

        });
        $("#r_sbt").click(function () { 
       


            //alert("ok")
            var wrd = $("#ddl_ward_a").val();
            var rout = $("#txt_route").val();

            if (wrd == "0" || rout == "") {

                swal("Please select route or ward!!")
            }
            else {
                $.ajax({

                    type: "POST",
                    url: "pre_defined_routes.aspx/fn_insert_routes",
                    data: "{ 'ward' : '" + wrd + "','route':'" + rout + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {

                        document.getElementById('txt_route').value = '';
                        swal("Route Successfully Inserted !!");

                    }
                });



            }
        })
       





    </script>
    <script>
        function BindGridView() {

            $.ajax({
                type: "POST",
                url: "pre_defined_routes.aspx/fn_get_grid_data",
                contentType: "application/json;charset=utf-8",
                data: {},
                dataType: "json",
                success: function (data) {

                    //alert(JSON.stringify(data.d));
                    $("#grdRoute").empty();

                    if (data.d.length > 0) {
                        $("#grdRoute").append("<tr class='gradeA even'><th>Route ID</th> <th>Route</th> <th> Ward </th> <th>Zone</th> <th>Delete</th> </tr>");// <th>Ward ID</th> <th> Ward </th><th>Zone ID</th> <th>Zone</th> 
                        for (var i = 0; i < data.d.length; i++) {


                            $("#grdRoute").append("<tr class='gradeA even' id='id'><td >" +
                            data.d[i].routid + "</td> <td >" +
                            data.d[i].routeName + "</td> <td> " +
                            // data.d[i].wardid + "</td> <td>" +
                            data.d[i].ward_name + "</td> <td>" +
                            //data.d[i].Zoneid + "</td> <td>" +
                            data.d[i].ZoneName + "</td> " +
                            "<td><a style='color:black' onClick='deleteRow();' class='delete'><i class='fa fa-trash-o' style='font-size:30px;'></i></a></td></tr>");

                        



                        }
                    }

                }


            });

        }
        function deleteRow() {
            $('#grdRoute td').click(function () {

                var rid = $(this).siblings('td').html();

                $.ajax({
                    type: "POST",
                    url: "pre_defined_routes.aspx/fn_del_bin",
                    contentType: "application/json;charset=utf-8",
                    data: "{'routeid':'" + rid + "'}",
                    dataType: "json",
                    success: function (data) {
                        BindGridView();
                        //init(1, 0, 0, 0, 0);
                        swal("Entry Deleted Successfully!!")


                    }




                });


            });

        }

      

    </script>



</asp:Content>
