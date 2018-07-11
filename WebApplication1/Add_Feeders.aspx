<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="Add_Feeders.aspx.cs" Inherits="WebApplication1.Add_Feeders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
     <script type="text/javascript">
         $(function () {
             $.ajax({
                 type: "POST",
                 url: "Add_Bins.aspx/GetCustomers1",
                 data: '{}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (r) {
                     var ddlCustomers = $("[id*=ddlzone]");
                     ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                     $.each(r.d, function () {
                         ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                     });
                 }
             });

             $("#<%=DdlZone.ClientID%>").change(function () {
                //alert("Handler for .change() called.");
                var value = $("#<%=DdlZone.ClientID%>").val();

                $.ajax({
                    type: "POST",
                    url: "Add_Bins.aspx/Getwards",
                    data: "{ 'zone' : '" + value + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                        var ddlCustomers = $("[id*=ddlward]");
                        ddlCustomers.empty().append('<option selected="selected" value="0">--select--</option>');
                        $.each(r.d, function () {
                            ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                        });
                    }
                });



            });




        });

</script>
    <script>
        function ravi() {
            //  alert(lat);
            // if (lat=='')
            // {
            //     document.getElementById("<%= blat.ClientID %>").disabled = false;

            //  }
            document.getElementById("<%= blon.ClientID %>").value = "";
            document.getElementById("<%= blat.ClientID %>").value = "";
            document.getElementById("<%= blon.ClientID %>").readOnly = false;
            document.getElementById("<%= blat.ClientID %>").readOnly = false;
            // var manual = document.getElementById('address').value;
            //alert(manual);

        }
    </script>

    <script>


        function initAutocomplete() {
            var input = document.getElementById('address');
            //alert(input);

            var autocomplete = new google.maps.places.Autocomplete(input);
            //alert(autocomplete);
            //if (autocomplete == '')
            //{
            // document.getElementById("<%= blon.ClientID %>").disabled = false;

            //}
            autocomplete.addListener('place_changed', function () {

                var address = document.getElementById('address').value;

                getLatitudeLongitude(showResult, address)
                var place = autocomplete.getPlace();
                var lat = place.geometry.location.lat();
                var lon = place.geometry.location.lng();
                // ravi(lat);

                // alert(address);
                if (lat != '' && lon != '') {
                    document.getElementById("<%= blat.ClientID %>").readOnly = true;
                    document.getElementById("<%= blon.ClientID %>").readOnly = true;
                    document.getElementById("<%= blat.ClientID %>").value = lat;
                    document.getElementById("<%= blon.ClientID %>").value = lon;



                }
                //ravi();
                // else { alert("not done")}
                // alert(adress);
                // alert(place);
                // alert(lat);
                // alert(lon);
                // document.getElementById('blat').val() = "ok";

                // document.getElementById('address').innerHTML = address;



            });

            function showResult(result) {
                //alert("ok3");
                //document.getElementById('blat').value = result.geometry.location.lat();
                //document.getElementById('blon').value = result.geometry.location.lng();
                //var me = result.geometry.location.lat();
                //alert(me);
            }
            function getLatitudeLongitude(callback, address) {
                // alert("under lat");
                // If adress is not supplied, use default value 'Ferrol, Galicia, Spain'
                // address = address || 'acme digitek, Lucknow, India';
                // Initialize the Geocoder
                geocoder = new google.maps.Geocoder();
                if (geocoder) {
                    geocoder.geocode({
                        'address': address
                    }, function (results, status) {
                        //alert("ok2");
                        //alert(address);
                        if (status == google.maps.GeocoderStatus.OK) {
                            callback(results[0]);
                        }
                    });
                }
            }





        }
    </script>
    
    
    
     <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCq3TfsFZJr_-nwvYqSFSTMAMrKKDW36NQ&libraries=places&callback=initAutocomplete" async="async" defer="defer"></script>
   
    
    
    
     <div class="row">
        <div style="margin-top:12px;"><fieldset><legend><h3>Enter Feeder Details</h3></legend></fieldset></div>
        <br />
           <div>
          <div class="col-sm-2">Zone</div>
            <asp:DropDownList ID="DdlZone" AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
         <br />

        <div>
          <div class="col-sm-2">Ward</div>
        <asp:DropDownList ID="DdlWard" class="form-control" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server"></asp:DropDownList>
        </div>
             <br />
        <div>
           <div class="col-sm-2">Area Name</div>
            <input required="required" id="address" class="form-control" type="text"  placeholder="Search for Location" onchange="ravi();" value="<% =ServerValue %>" name="Name"/>
            <br />
         <%--  <asp:TextBox ID="get_address" class="form-control" runat="server" Visible="false"></asp:TextBox>--%>

    </div>
       
    <br />
    <div>
        <div class="col-sm-2">Latitude</div>
        <asp:TextBox ID="blat" required="required" class="form-control"  runat="server" ></asp:TextBox>
      
    </div>
         <br />
    <div>
          <div class="col-sm-2">Longitude</div>
        <asp:TextBox ID="blon" required="required"  class="form-control"   runat="server"  ></asp:TextBox>
        </div>
         <br />
        <div>
          <div class="col-sm-2">Feeder Name</div>
        <asp:TextBox ID="f_name" required="required" class="form-control" runat="server"></asp:TextBox>
            
        </div>
         <br />
       <%--     <div>
          <div class="col-sm-2">Serial ID</div>
        <asp:TextBox required="required" ID="serialid" class="form-control" runat="server"></asp:TextBox>
                  
       

        </div>--%>
         

 
         <br />
     <br />
          <div class="col-sm-1">

              <asp:Button ID="Button1" CssClass="btn btn-default"  runat="server" Text="Submit" OnClick="Button1_Click" />
              <asp:Button ID="Btnupdate" CssClass="btn btn-default"  runat="server" Text="Update" OnClick="Btnupdate_Click" Visible="false" />
        </div>
         <div class="col-sm-2">
            
             <asp:LinkButton ID="Btncancle" CssClass="btn btn-danger"  runat="server" Text="Cancel" Visible="false" OnClick="Btncancle_Click"></asp:LinkButton>
        </div>
         <br />
         
      
    <div>
        </div>
    </div>
</asp:Content>
