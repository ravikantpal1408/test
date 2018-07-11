<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="plan_collection.aspx.cs" Inherits="WebApplication1.plan_collection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="tags/jquery.tagsinput.min.css" rel="stylesheet" />
    <script src="tags/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="dist1/sweetalert-dev.js"></script>
    <link href="dist1/sweetalert.css" rel="stylesheet" />
 <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true"  runat="server"></asp:ScriptManager>
    <style>
        .table-bordered>tbody>tr>td, 
        .table-bordered>tbody>tr>th, 
        .table-bordered>tfoot>tr>td, 
        .table-bordered>tfoot>tr>th, 
        .table-bordered>thead>tr>td, 
        .table-bordered>thead>tr>th {
                                        border: 1px solid #ddd;
                                    }

    </style>

    <script>

        function deleteRow() {
           
            $('#grdDemo td').click(function () {

                var binid = $(this).siblings('td').html();
                
                $.ajax({
                    type: "POST",
                    url: "plan_collection.aspx/fn_del_bin",
                    contentType: "application/json;charset=utf-8",
                    data: "{'binid':'"+binid+"'}",
                    dataType: "json",
                    success: function (data)
                    {
                        BindGridView();
                        init(1, 0, 0, 0, 0);
                        //swal("Entry Deleted Successfully!!")
                        

                    }
                    
                    


                });


            });
            
           

        }

    </script>
    <script>


        $(document).ready(function () {
            BindGridView();

        });
        
        function BindGridView() {

            $.ajax({
                type: "POST",
                url: "plan_collection.aspx/fn_get_grid_data",
                contentType: "application/json;charset=utf-8",
                data: {},
                dataType: "json",
                success: function (data) {
                    
                    //alert(JSON.stringify(data.d));
                    $("#grdDemo").empty();

                    if (data.d.length > 0) {
                        $("#grdDemo").append("<tr class='gradeA even'><th>BinId</th> <th>BinName</th>  <th>Zone</th> <th>Ward</th><th>Route</th> <th>Vehicle</th> <th>Vehicle Type</th> <th>Driver's ID</th> <th>Driver Name</th>  <th>Date</th> <th>delete</th></tr>");
                        for (var i = 0; i < data.d.length; i++) {
                      
                            
                            $("#grdDemo").append("<tr class='gradeA even' id='id'><td >" +
                            data.d[i].BinId + "</td> <td >" +
                            data.d[i].BinName + "</td> <td>" +
                            data.d[i].Zone + "</td> <td>" +
                            data.d[i].Ward + "</td> <td>" +
                            data.d[i].Route + "</td> <td>" +
                            data.d[i].Vehicle + "</td> <td>" +
                            data.d[i].vtype + "</td> <td>" +
                            data.d[i].did + "</td> <td>" +
                            data.d[i].dnm + "</td> <td>" +
                            data.d[i].Date + "</td><td><a style='color:black' onClick='deleteRow();' class='delete'><i class='fa fa-trash-o' style='font-size:30px;'></i></a></td></tr>");
                         
                        }
                    }
                    
                }

                
            });
           
        }

        



    </script>
    <script>
       //ZONE
        $(function () {
            $.ajax({
                type: "POST",
                url: "plan_collection.aspx/GetZone",
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

            //Ward
            $("#<%=ddl_zone.ClientID%>").change(function () {
                // alert("Handler for .change() called.");
                var zn = $("#<%=ddl_zone.ClientID%>").val();
                init(1, zn, 0, 0, 0);
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

                         var ddlCustomers = $("[id*=ddl_ward");
                         ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                         $.each(r.d, function () {
                             ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                         });
                     }
                 });
                 //$.ajax({
                 //    type: "POST",
                 //    url: "plan_collection.aspx/fn_get_route_zone_ws",
                 //    data: "{ 'zone' : '" + zn + "'}",
                 //    contentType: "application/json; charset=utf-8",
                 //    dataType: "json",
                 //    success: function (r) {


                 //        if (r.d == null || r.d == '') {
                 //            location.reload();


                 //        }

                 //        var ddlCustomers = $("[id*=ddl_route");
                 //        ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                 //        $.each(r.d, function () {
                 //            ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                 //        });
                 //    }
                 //});




            });

            $("#<%=ddl_ward.ClientID%>").change(function () {
                var wrd = $("#<%=ddl_ward.ClientID%>").val();
                var zn = $("#<%=ddl_zone.ClientID%>").val();
                init(1, zn, wrd, 0, 0);

                if (wrd != '' || wrd != '0') {
                    $.ajax({
                        type: "POST",
                        url: "plan_collection.aspx/fn_ddl_route",
                        data: "{ 'ward' : '" + wrd + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            if (r.d == null || r.d == '') {


                                swal('Opss !!', 'No Routes are Defined !!');


                            }

                            else {
                                var ddlCustomers = $("[id*=ddl_route]");
                                ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                $.each(r.d, function () {
                                    ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                });
                            }


                        }
                    });
                }
                else {
                    var ddlCustomers = $("[id*=ddl_route]");
                    ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                    swal('Please Select Ward', 'Thank You!!')

                }
            });




        });
        $("#<%=ddl_route.ClientID%>").change(function () {
            var routeid = $("#<%=ddl_route.ClientID%>").val();
                   var zn = $("#<%=ddl_zone.ClientID%>").val();
                   var wrd = $("#<%=ddl_ward.ClientID%>").val();
                   alert(routeid);
                   if (routeid == '0')
                   { }







               });

    </script>
    <script>

        //Google Autocomplete Feature
        function ravi() {

            var input = document.getElementById('address');
            var geocoder = new google.maps.Geocoder();
            var autocomplete = new google.maps.places.Autocomplete(input);

            autocomplete.addListener('place_changed', function () {
                getLatitudeLongitude(showResult, address)
                var place = autocomplete.getPlace();
                var lat = place.geometry.location.lat();
                var lon = place.geometry.location.lng();
                if (lat != '' && lon != '') {
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

          

    <script   src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCMlNhGUiUZBM1dHIFDZz1NAFUbN7f_epA&libraries=places"></script>

    

   <script>
       function fn_filter_route_ws()
       {
           
           var routeid = $("#<%=ddl_route.ClientID%>").val();
           var zn = $("#<%=ddl_zone.ClientID%>").val();
           var wrd = $("#<%=ddl_ward.ClientID%>").val();
           //alert(wrd)
           if (routeid != '0') {
               //alert(routeid)

               init(1, 0, 0, 0, routeid);



           }
           else {

               init(1, zn, wrd, 0, 0);


           }


       }


   </script>
 


        



   <script type="text/javascript">

       window.onload = function () {


           init(1, 0, 0, 0, 0);
           
       }

       function init(m, n, l, type, routeid) {


          var btype = type;
          var zone = n;
          var markers;
          var value = 1;
          var j = 0;
          var ward = l;
          var rid = routeid;
          var markersp1 = [];
          var markersp2 = [];
          //alert(rid)
          $.ajax({
              type: 'POST',
              url: 'plan_collection.aspx/ConvertDataTabletoString',
              data: "{ 's' : '" + value + "','zone':'" + zone + "','ward':'" + ward + "','type':'" + btype + "','rid':'" + rid + "'}",
              contentType: 'application/json; charset=utf-8',
              dataType: 'json',
              success: function (data) {


                  if (data.d == '') {

                      alert("No Such Bin Found");



                  }
                  markers = data.d;

                  //alert(JSON.stringify(markers));

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
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "fullred1";
                                      break;
                                  }
                              }
                              else if (data.Priority == "MED") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "medred1";
                                      break;
                                  }

                              }
                              else if (data.Priority == "LOW") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {

                                      icon = "lowred1";
                                      break;
                                  }
                              }
                       
                              else {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "R_BIN1";
                                      break;
                                  }
                              }
                          case "H":

                              if (data.Priority == "HIGH") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "fullorange1";
                                      break;
                                  }
                              }
                              else if (data.Priority == "MED") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "medorange1";
                                      break;
                                  }

                              }
                              else if (data.Priority == "LOW") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {

                                      icon = "loworange1";
                                      break;
                                  }
                              }
                           
                              else {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "O_BIN1";
                                      break;
                                  }
                              }
                          case "E":

                              if (data.Priority == "HIGH") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "fullgreen1";
                                      break;
                                  }
                              }
                              else if (data.Priority == "MED") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "medgreen1";
                                      break;
                                  }

                              }
                              else if (data.Priority == "LOW") {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {

                                      icon = "lowgreen1";
                                      break;
                                  }
                              }
                      
                              else {
                                  if (data.status == "P") {

                                      icon = "tick";
                                      break;
                                  }
                                  else {
                                      icon = "G_BIN1";
                                      break;
                                  }
                              }
                          case "D":
                              //alert(data.Bin_Type);
                              icon = "click";
                              break;
                          case "PU":
                              icon = "PU";
                              break;


                      }
                      //alert(icon);
                      icon = "map_img/" + icon + ".png";

                                

                      var marker = new google.maps.Marker({
                          position: myLatlng,
                          map: map,
                          title: data.AreaName,
                          Type: data.Bin_Type,
                          //animation: google.maps.Animation.DROP,
                          icon: new google.maps.MarkerImage(icon)
                      });

                      (function (marker, data) {//RIGHT FLAG

                          if (data.Bin_Type == 'F' || data.Bin_Type == 'H' || data.Bin_Type == 'E') {
                              google.maps.event.addListener(marker, "rightclick", function () {

                                  //<input class='form-control' type='text' id='address' style='display:none' placeholder='Location'></br><input class='form-control' style='display:none' type='text' id='txt_lat' placeholder='Latitude'></br><input class='form-control' style='display:none'  type='text' id='txt_lon' placeholder='Longitude'></br><p>select only route in order to change the path of bin.</p>
                                  infoWindow.setContent("<div style='width:200px'><a  href='javascript:ravi();' id='h' style='color:black'><center><h5>Click</h5></center></a></br><select id='ddl_zone' class='form-control' style='width:154px'><option>-----Select_Zone-----</option></select><br><select id='ddl_wardss' class='form-control' style='width:154px'></select><br></br><select id='ddl_routess' class='form-control' style='width:154px'></select></br><a id='click_r' style='color:black;'><center><h5>Change Route</h5></center></a></div>");
                                  infoWindow.open(map, marker);

                                
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

                                      
                                  });
                                  $("#ddl_zone").change(function () {
                                      // alert("Handler for .change() called.");
                                      var zn = $("#ddl_zone").val();

                                      $.ajax({
                                          type: "POST",
                                          url: "plan_collection.aspx/fn_get_wards",
                                          data: "{ 'zone' : '" + zn + "'}",
                                          contentType: "application/json; charset=utf-8",
                                          dataType: "json",
                                          success: function (r) {


                                              if (r.d == null || r.d == '') {
                                                 // location.reload();


                                              }

                                              var ddlCustomers = $("[id*=ddl_wardss");
                                              ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                              $.each(r.d, function () {
                                                  ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                              });
                                          }
                                      });
                                  });


                                  $("#ddl_wardss").change(function () {
                                      // alert("Handler for .change() called.");
                                      var wd = $("#ddl_wardss").val();

                                      $.ajax({
                                          type: "POST",
                                          url: "plan_collection.aspx/fn_ddl_route",
                                          data: "{ 'ward' : '" + wd + "'}",
                                          contentType: "application/json; charset=utf-8",
                                          dataType: "json",
                                          success: function (r) {


                                              if (r.d == null || r.d == '') {
                                              //    location.reload();


                                              }

                                              var ddlCustomers = $("[id*=ddl_routess");
                                              ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                              $.each(r.d, function () {
                                                  ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                              });
                                          }
                                      });
                                  });



                                  $(function () {
                                      $('#click_r').click(function () {

                                          //alert("bing")
                                          var bname = data.AreaName;
                                          var binid = data.BinId;
                                          var lat = data.lat;
                                          var lon = data.lon;
                                          //var txtlat = document.getElementById('txt_lat').value;
                                          //var txtlon = document.getElementById('txt_lon').value;
                                          var dl_zn = document.getElementById('ddl_zone').value;
                                          //alert("zone"+dl_zn)
                                          var dl_wrd = document.getElementById('ddl_wardss').value;
                                          //alert("ward"+dl_wrd)
                                          var dl_rt = document.getElementById('ddl_routess').value;
                                          //alert("route"+dl_rt);
                                          if (dl_zn != '0' && (dl_wrd != '0'|| dl_wrd!=null) && (dl_rt != '0' ||dl_rt!=null)) {


                                              $.ajax({
                                                  type: "POST",
                                                  url: "plan_collection.aspx/fn_change_routesss",
                                                  data: "{'binid' : '" + binid + "','binName':'"+bname+"','lat':'"+lat+"','lon':'"+lon+"','zone':'" + dl_zn + "','ward' : '" + dl_wrd + "','rid':'" + dl_rt + "'}",
                                                  contentType: "application/json; charset=utf-8",
                                                  dataType: "json",
                                                  success: function (datas) {

                                                      if (datas.d == '') {
                                                          swal("No Such Bins!!");


                                                      }
                                                      else {
                                                          swal("Changes have been applied !!!");
                                                          //  init(1, 0, 0, 0, 0);
                                                      }



                                                  }
                                              });



                                          }
                                          else {

                                              swal("please select Zone/ward/Route");
                                          }

                           

                                      });
                                  });

                              });



                          }
                          if(data.Bin_Type=='D')
                          {
                              google.maps.event.addListener(marker, "click", function (e) {

                                  infoWindow.setContent("<div style='width:180px'><a href='javascript:' id='h' style='color:black'><center><h5>Select</h5></center></a></br>VEHICLE:<select id='ddl_vehicle' class='form-control' style='width:154px'><option>-----Select_Vehicle-----</option></select></br>Driver:<select id='ddl_driver' class='form-control' style='width:154px'><option>-----Select_Driver-----</option></select><br><a  href='javascript:ravi();' id='click' style='color:black'><center><h5>Assign</h5></center></a></div>");
                                  //</br>Already Selected Routes: <select id='pre' class='form-control' style='width:154px'><option>----PreSelected-----</option></select>
                                  infoWindow.open(map, marker);
                                  var len=markersp1.length;
                                   // $(function () {
                                      $.ajax({
                                          type: "POST",
                                          url: "plan_collection.aspx/fn_get_pre_routes",
                                          data: "{}",
                                          contentType: "application/json; charset=utf-8",
                                          dataType: "json",
                                          success: function (r) {
                                              var ddlCustomers = $("[id*=pre");
                                              ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                              $.each(r.d, function () {
                                                  ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                              });
                                          }

                                      });
                                      $.ajax({
                                          type: "POST",
                                          url: "plan_collection.aspx/fn_get_driver",
                                          data: "{}",
                                          contentType: "application/json; charset=utf-8",
                                          dataType: "json",
                                          success: function (r) {
                                              var ddlCustomers = $("[id*=ddl_driver");
                                              ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                              $.each(r.d, function () {
                                                  ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                              });
                                          }






                                      });
                         

                                  $(function () {
                                      $.ajax({
                                          type: "POST",
                                          url: "plan_collection.aspx/fn_get_vehicle",
                                          data: '{}',
                                          contentType: "application/json; charset=utf-8",
                                          dataType: "json",
                                          success: function (r) {
                                              var ddlCustomers = $("[id*=ddl_vehicle]");
                                              ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                                              $.each(r.d, function () {
                                                  ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                                              });
                                          }
                                      });
                                  });



                                  var wrd = $("#<%=ddl_ward.ClientID%>").val();
                                 
                                  var zn = $("#<%=ddl_zone.ClientID%>").val();
                                  var rt = $("#<%=ddl_route.ClientID%>").val();
                                  $("#click").click(function () {


                                      var ddl_d = document.getElementById('ddl_driver').value;
                                      var ddl_d_nm = document.getElementById('ddl_driver').text;
                                      var ddl_v = document.getElementById('ddl_vehicle').value;
                                      var ddl_vtype = document.getElementById('ddl_vehicle').text;
                                      

                                      if (len != '0' && ddl_d != '0' && ddl_v != '0') {
                                          
                                          $.ajax({
                                              type: "POST",
                                              url: "plan_collection.aspx/fn_Schedule_bins_",
                                              data: "{ 'mar' : '" + markersp1 + "','veh':'" + ddl_v + "','vtype':'" + ddl_vtype + "','driverID':'" + ddl_d + "','dname':'" + ddl_d_nm + "'}",
                                              contentType: "application/json; charset=utf-8",
                                              dataType: "json",
                                              success: function (result) {
                               
                                                  // location.reload();
                                                  init(1, 0, 0, 0, rt)
                                                  BindGridView();

                                              }

                                          });

                                      }
                                      else {

                                          swal('Please Select Bins/Zone/Ward/Route/Vehicle ', 'Thank You');

                                      }
                                  });


                              });


                          }
                      
                          if (data.Bin_Type == 'F' || data.Bin_Type == 'H' || data.Bin_Type == 'E') {

                              google.maps.event.addListener(marker, "click", function (e) {
                                  infoWindow.setContent("<div style='width:200px'><a  href='javascript:ravi();' id='h' style='color:black'><center><h5><label id='check'></label></br><input type='checkbox' style='width:20px;height:20px' id='chk_bx'></br></br><a id='uchk' style='color:black' ><i  class='fa fa-trash-o' style='color:red;font-size:30px' aria-hidden='true'></a></div>");
                                  infoWindow.open(map, marker);//flag1
                              
                                  $("#check").text(data.AreaName);
                                  //alert("ok")
                                  $(function () {
                               
                                      $('#chk_bx').change(function () {
                                      
                                          marker.setIcon('map_img/tick.png');
                                          if (markersp1.length != 0)  {
                                             
                                              for (var gm = 0; gm < markersp1.length ; gm++) {

                                                  if (markersp1.indexOf(data.BinId) > -1) {

                                                      swal('Bin Already Exist');
                                                      //break;
                                                  }
                                                  else {

                                                     
                                                      var bnm = data.AreaName;
                                                      var bid = data.BinId;
                                                      markersp1.push(bid);
                                                      markersp2.push(bnm);
                                                      //document.getElementById('bin_txt').in = markersp2;
                                                      var htm = "<label>" + markersp1 + "</label>&nbsp;&nbsp;&nbsp<i id='del' href='javascript:del();' style='color:red;font-size:30px' class='fa fa-trash-o' aria-hidden='true'></i>";
                                                      htm = htm + "</br><label>" + markersp2 + "</label>";
                                                      //   htm = htm + "<i id='del' href='javascript:del();' class='fa fa-trash-o' aria-hidden='true'></i>";
                                                      $('#bin_txt').html(htm);
                                                      del(markersp1, markersp2, bid, bnm);


                                                      break;
                                                  }



                                              }
                                          }
                                          else if (markersp1.length == 0) {
                                             
                                              var bnm = data.AreaName;
                                              var bid = data.BinId;
                                              markersp1.push(bid);
                                              markersp2.push(bnm);
                                              //document.getElementById('bin_txt').value = markersp2;
                                              document.getElementById('abc').style.display = 'block';
                                              var htm = "<label>" + markersp1 + "</label>&nbsp;&nbsp;&nbsp<i href='javascript:del();' style='color:red;font-size:30px' id='del' class='fa fa-trash-o' aria-hidden='true'></i>";
                                              // htm = htm + "<i id='del' href='javascript:del();' class='fa fa-trash-o' aria-hidden='true'></i>";
                                              htm = htm + "</br><label>" + markersp2 + "</label>";

                                              $('#bin_txt').html(htm);
                                              del(markersp1, markersp2, bid, bnm);





                                          }
                               
                                
                                

                                      });


                                      $('#uchk').click(function () {
                                          switch (data.Bin_Type) {

                                              case "F":

                                                  if (data.Priority == "HIGH") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "fullred1";
                                                          break;
                                                      }
                                                  }
                                                  else if (data.Priority == "MED") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "medred1";
                                                          break;
                                                      }

                                                  }
                                                  else if (data.Priority == "LOW") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {

                                                          icon = "lowred1";
                                                          break;
                                                      }
                                                  }

                                                  else {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "R_BIN1";
                                                          break;
                                                      }
                                                  }
                                              case "H":

                                                  if (data.Priority == "HIGH") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "fullorange1";
                                                          break;
                                                      }
                                                  }
                                                  else if (data.Priority == "MED") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "medorange1";
                                                          break;
                                                      }

                                                  }
                                                  else if (data.Priority == "LOW") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {

                                                          icon = "loworange1";
                                                          break;
                                                      }
                                                  }

                                                  else {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "O_BIN1";
                                                          break;
                                                      }
                                                  }
                                              case "E":

                                                  if (data.Priority == "HIGH") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "fullgreen1";
                                                          break;
                                                      }
                                                  }
                                                  else if (data.Priority == "MED") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "medgreen1";
                                                          break;
                                                      }

                                                  }
                                                  else if (data.Priority == "LOW") {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {

                                                          icon = "lowgreen1";
                                                          break;
                                                      }
                                                  }

                                                  else {
                                                      if (data.status == "P") {

                                                          icon = "tick";
                                                          break;
                                                      }
                                                      else {
                                                          icon = "G_BIN1";
                                                          break;
                                                      }
                                                  }
                                              case "D":
                                                  //alert(data.Bin_Type);
                                                  icon = "click";
                                                  break;
                                              case "PU":
                                                  icon = "PU";
                                                  break;


                                          }
                                
                                          marker.setIcon("map_img/" + icon + ".png");//SET
                                          var idx = $.inArray(data.BinId, markersp1);
                                          //alert(idx)
                                          if (idx == -1) {
                                              swal('Select Bin Does Not Exits');

                                        
                                             
                                          } else {
                                              //alert("no")
                                              markersp1.splice(idx, 1);
                                              markersp2.splice(idx, 1);
                                              //document.getElementById('bin_txt').value = markersp2;
                                              var htm = "<label>" + markersp1 + "</label>&nbsp;&nbsp;&nbsp<a onclick=deletebin(" + data.BinId + ")><i style='color:red;font-size:30px' id='del' class='fa fa-trash-o' aria-hidden='true'></i></a>";
                                              //htm = htm + "<i id='del' class='fa fa-trash-o' aria-hidden='true'></i>";
                                              htm = htm + "</br><label>" + markersp2 + "</label>";

                                              $('#bin_txt').html(htm);
                                              //del(markersp1, markersp2, bid, bnm);

                                              swal('Bin Removed Succesfully');
                                              //alert("after")
                                             
                                          }
                                    

                                      });
                                  });

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
    <div class="col-sm-4" style="" id="zone">
                
     <fieldset><legend>Zone</legend></fieldset>
         <asp:UpdatePanel ID="udp_1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="ddl_zone" Height="25px" Width="200px" runat="server">
                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                    


            </asp:DropDownList>
             
          </ContentTemplate>
    </asp:UpdatePanel>

</div>

            <div class="col-sm-4" style="" id="ward">
                
     <fieldset><legend>Ward</legend></fieldset>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="ddl_ward" Height="25px" Width="200px" runat="server">
                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
 
            </asp:DropDownList>
             
          </ContentTemplate>
    </asp:UpdatePanel>

</div>
        <div class="col-sm-4">
           
        <fieldset><legend>Select Route</legend></fieldset>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
               <ContentTemplate>
                    <asp:DropDownList ID="ddl_route"  onchange="fn_filter_route_ws();" runat="server" Height="25px" Width="200px" >

                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                  </asp:DropDownList>
               </ContentTemplate>
         </asp:UpdatePanel>
      

      </div>


    </div>

  <div id="grd_vw" style="margin-top:6%">
      <table id="grdDemo" cellspacing="0" rules="all" border="1" class="table table-bordered table-striped" role="grid" style="border-collapse:collapse;"  >

        </table>
     



  </div>



    <br />
    
    
  




</asp:Content>
