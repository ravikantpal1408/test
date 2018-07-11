<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="bin-sensor-policy.aspx.cs" Inherits="WebApplication1.bin_sensor_policy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
   
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="js/bin_policy.js"></script>
     <fieldset><legend><h3>Bin Sensor Policy</h3></legend></fieldset>

      <div class="row"  >
            <div class="col-sm-1"></div>
            <div class="col-sm-6">
                <div class="row">
 
                    <table border="0" class="table">


                        <tr>
                            <td><b>Select a Policy:</b><br /><select class="form-control" id="policy" onchange="showsubpolicy()">
                                <option value="0">select</option>
                                <option value="1">Global Policy</option>
                                <option value="2">Zone-Wise Policy</option>
                                <option value="3">Ward-Wise Policy</option>
                                <option value="4">Individual Policy</option>

                                </select>

                            </td>

                    


                        </tr>

                    </table>



                    
                    </div>
                </div>
          </div>


    <div class="row" id="global_div" style="display:none">
        <fieldset><legend><h4>Global Policy</h4></legend></fieldset>


        <br />
        <table  >
            <tr>

                <td style="padding:10px">

                    <input type="text" required="required" class="form-control" id="devicename" placeholder="Device Name" />
                      <input type="hidden" id="gl_id"   />
                   
                </td>

                   <td style="padding:10px">
                    <input type="text" required="required" class="form-control" id="pi" placeholder="Polling Interval" />

                </td>
                <td style="padding:10px">
                     <input type="text" required="required" class="form-control" id="kai" placeholder="Keep Alive Interval" />

                </td>
                <td style="padding:10px">

                     <input type="text" required="required" class="form-control" id="th_lv" placeholder="Thresh-hold interval" />

                </td>
             
                <td style="padding:10px">

                    <a onclick="sbt_g_policy()" id="sbt_gl" class="btn btn-success" >Submit</a>
                    <a onclick="udp_g_policy()" id="udp_gl" class="btn btn-warning" style="display:none" >Update</a>

                </td>



            </tr>
             


        </table>
        
       
      
       
        <br />
        


        <table id="globalbin" class="table"  style="text-align:center" border="1">



                    </table>

    </div>




    <div class="row" id="Div1" style="display:none">
        <fieldset><legend><h4>Zone-Wise Policy</h4></legend></fieldset>


        <br />

        <b>Select Zone</b>
        
        <br />
        <table  >


            <tr><td colspan="4">

                <select id="ddl_zone" onchange="zone_ws_ddl()" class="form-control"  ><option value="0">Select</option></select>


                </td></tr>
            <tr>

                <td style="padding:10px">

                    <input type="text" required="required" class="form-control" id="Text1" placeholder="Device Name" />
                      <input type="hidden" id="Hidden1"   />
                   
                </td>

                         <td style="padding:10px">
                    <input type="text" required="required" class="form-control" id="Text4" placeholder="Polling Interval" />

                </td>
                <td style="padding:10px">
                     <input type="text" required="required" class="form-control" id="Text2" placeholder="Keep Alive Interval" />

                </td>
                <td style="padding:10px">

                     <input type="text" required="required" class="form-control" id="Text3" placeholder="Thresh-hold interval" />

                </td>
       
                <td style="padding:10px">

                    <a onclick="sbt_zn_policy()" id="ssss" class="btn btn-success" >Submit</a>
                    <a onclick="udp_zn_policy()" id="A2" class="btn btn-warning" style="display:none" >Update</a>

                </td>



            </tr>
             


        </table>
        
       
      
       
        <br />
        


        <table id="zonaltable" class="table"  style="text-align:center" border="1">



                    </table>

    </div>



    <div class="row" id="ddd" style="display:none">
        <fieldset><legend><h4>Ward-Wise Policy</h4></legend></fieldset>


        <br />

        <b>Select Zone</b>
        
        <br />
        <table  >


            <tr><td colspan="4">

                <select id="Select1" onchange="bind_ward()" class="form-control"  ><option value="0">Select</option></select>


                </td></tr>


            <tr><td  colspan="4" style="padding:10px">Select Ward:</td></tr>


            <tr><td colspan="4">

                <select id="Select2" onchange="ward_ws_ddl_()" class="form-control"  ><option value="0">Select</option></select>


                </td></tr>
            <tr>

                <td style="padding:10px">

                    <input type="text" required="required" class="form-control" id="Text5" placeholder="Device Name" />
                      <input type="hidden" id="Hidden2"   />
                   
                </td>

                                <td style="padding:10px">
                    <input type="text" required="required" class="form-control" id="Text8" placeholder="Polling Interval" />

                </td>
                <td style="padding:10px">
                     <input type="text" required="required" class="form-control" id="Text6" placeholder="Keep Alive Interval" />

                </td>
                <td style="padding:10px">

                     <input type="text" required="required" class="form-control" id="Text7" placeholder="Thresh-hold interval" />

                </td>

                <td style="padding:10px">

                    <a onclick="sbt_wr_policy()" id="sbt_wrd" class="btn btn-success" >Submit</a>
                    <a onclick="udp_wr_policy()" id="udp_wrd" class="btn btn-warning" style="display:none" >Update</a>

                </td>



            </tr>
             


        </table>
        
       
      
       
        <br />
        


        <table id="wardtable" class="table"  style="text-align:center" border="1">



                    </table>

    </div>
    


    <div class="row" id="single" style="display:none">

        <fieldset><legend><h4>Individual Policy for sensors</h4></legend></fieldset>


        <div id="bindindividual_" >


            
             


        </div>
        
       
      
       


    </div>




    <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Individual Edit</h4>
        </div>
        <div class="modal-body">
          <input type="text" class="form-control" placeholder="Device Name" id="devicename_in" />
            <input type="hidden" id="binid123" />
            <br />
            <input type="text" class="form-control" placeholder="Polling Interval" id="poll_in" /><br />
            <input type="text" class="form-control" placeholder="Keep Alive interval" id="keep_in" /><br />
            <input type="text" class="form-control" placeholder="Threshold" id="thresh_in" /><br />


            <a class="btn btn-success" id="udp_in" onclick="udp_in_policy()">UPDATE</a> 
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>

</asp:Content>
