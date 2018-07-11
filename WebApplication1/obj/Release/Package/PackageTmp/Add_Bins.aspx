<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="Add_Bins.aspx.cs" Inherits="WebApplication1.Add_Bins" EnableEventValidation="false" %>
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

             $("#<%=ddlzone.ClientID%>").change(function () {
                 //alert("Handler for .change() called.");
                 var value = $("#<%=ddlzone.ClientID%>").val();

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
             $("#<%=ddlward.ClientID%>").change(function () {
                 //alert("Handler for .change() called.");
                 var value = $("#<%=ddlward.ClientID%>").val();

                 $.ajax({
                     type: "POST",
                     url: "Add_Bins.aspx/get_route",
                     data: "{ 'ward' : '" + value + "'}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (r) {
                         var ddlCustomers = $("[id*=ddl_route]");
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
        function send_route_id()
        {
            //alert("")
            var value = $("#<%=ddl_route.ClientID%>").val();
            if(value!=null || value!="" ||value!="0")
            {

                $.ajax({
                    url: "Add_Bins.aspx?route_id=" + value, asynch: false, success: function (result) {


                    }
                });
            }
           



        }





    </script>

   


    <script>
        function ravi() {
      
            document.getElementById("<%= blon.ClientID %>").value = "";
            document.getElementById("<%= blat.ClientID %>").value = "";
            document.getElementById("<%= blon.ClientID %>").readOnly = false;
            document.getElementById("<%= blat.ClientID %>").readOnly = false;
    

        }
    </script>

    <script>


        function initAutocomplete() {
            var input = document.getElementById('address');
            //alert(input);

            var autocomplete = new google.maps.places.Autocomplete(input);
 
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
   



            });

                   function showResult(result) {
              
                   }
                   function getLatitudeLongitude(callback, address) {
             
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
        
         
        <div style="margin-top:12px;"><fieldset><legend><h3>Enter Bin Details</h3></legend></fieldset></div>
        <br />
           <div>
          <div class="col-sm-2">Zone</div>
            <asp:DropDownList ID="ddlzone" class="form-control" runat="server" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
        </div>
         <br />

        <div>
          <div class="col-sm-2">Ward</div>
        <asp:DropDownList ID="ddlward" class="form-control" runat="server" OnSelectedIndexChanged="ddlward_SelectedIndexChanged1" ></asp:DropDownList>
        </div>
             <br />
           <div>
          <div class="col-sm-2">Route</div>
        <asp:DropDownList ID="ddl_route" class="form-control" runat="server" OnSelectedIndexChanged="ddl_route_SelectedIndexChanged" ></asp:DropDownList>
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
          <div class="col-sm-2">Bin Name</div>
        <asp:TextBox ID="b_name" required="required" class="form-control" runat="server"></asp:TextBox>
            
        </div>
         <br />
            <div>
          <div class="col-sm-2">Serial ID</div>
        <asp:TextBox required="required" ID="serialid" class="form-control" runat="server"></asp:TextBox>
                  
       

        </div>
         

 
         <br />
     <br />
          <div class="col-sm-1">

              <asp:Button ID="Button1" CssClass="btn btn-default"  runat="server" Text="Submit" OnClientClick="send_route_id();" OnClick="Button1_Click" />
              <asp:Button ID="Btnupdate" CssClass="btn btn-default"  runat="server" Text="Update" OnClick="Btnupdate_Click" Visible="false" />
        </div>
         <div class="col-sm-2">



            <asp:Button ID="Btncancle" CssClass="btn btn-danger"  runat="server" Text="Cancel" Visible="false" OnClick="Btncancle_Click"/>
            
         
         
         
         </div>
         <br />
         
      
    <div>
        </div>
            
    </div>
          
</asp:Content>
