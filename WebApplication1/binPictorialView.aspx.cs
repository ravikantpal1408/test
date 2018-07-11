using MAPConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAPBusiness;

namespace WebApplication1
{
    public partial class binPictorialView : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        connections con = new connections();
        string BinId = string.Empty;
        string BinType = string.Empty;
        string Areaid = string.Empty;
        long result = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            DataSet dsmstbintype = new DataSet();
            DataSet dsSelectsensorvalue = new DataSet();
         // DataSet ds = new DataSet();
            business ob = new business();
           
            //tring result = task("1014", "2");

            // Response.Write(result);
            //if (!IsPostBack)
            //{
            //    BinId = Request.QueryString["Bid"].ToString();
            //    Areaid = Request.QueryString["loc"].ToString();
            //    task(BinId, Areaid);
            //}
            if (Request.QueryString["binid"].ToString() == "1053" || Request.QueryString["binid"].ToString() == "1040")
            {
                task(Request.QueryString["binid"].ToString());
                    //, Request.QueryString["areaid"].ToString());
            }
            else
            {

                BinId = Request.QueryString["binid"].ToString();
               // Areaid = Request.QueryString["areaid"].ToString();

                try
                {
                    long a = 0;
                    if (BinId != null)
                    {
                        // ds = con.conn("select * from Mst_Bin where BinId ='" + BinId + "'");
                        ds = ob.fn_bind_device(BinId);
                        //dsmstbintype = con.conn("select Bin_Type,SerialId from Mst_BinDevice where BinId='" + BinId + "'");
                        dsmstbintype = ob.fn_bind_dsmstbintype(BinId);
                        if (dsmstbintype.Tables[0].Rows.Count > 0)
                        {
                            BinType = dsmstbintype.Tables[0].Rows[0]["Bin_Type"].ToString();

                           // dsSelectsensorvalue = con.conn("select top 1 SensorOne from IOT_String where deletestatus is null and location='" + Areaid + "' order by datetime desc");

                            string serialid = ds.Tables[0].Rows[0]["SerialId"].ToString();

                            dsSelectsensorvalue = ob.fn_sensor_input(serialid);
                            
                             a = Convert.ToInt64(dsSelectsensorvalue.Tables[0].Rows[0]["SensorOne"].ToString());


                            //if (BinType == "F")
                            //{
                            //    result = map(a, 290, 370, 0, 146);




                            //}
                            //else if (BinType == "H")
                            //{
                            //    result = map(a, 0, 140, 0, 146);

                            //}


                        }

                        bin_design(a);
                    }

                }
                catch
                { }
            }
        }




        public long map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public void bin_design(long z)
        {
            string color = "";
            //string a = Request.QueryString["w"].ToString();
            //if (Request.QueryString["w"].ToString() != "")
            //{
            //long heightx = Convert.ToInt64(a);
            //long percent = ((Convert.ToInt64(a) * 100) / 284);
            long percent = ((z * 100) / 146);
            //percent = (100 - percent);
            if (percent < 0)
            {
                percent = 0;
            }
            else if (percent > 100)
            {
                percent = 100;
            }
            lbl_binPercent.Text = percent + "%";
            if (percent == 0)
            {
                emptyspace.Attributes.Add("style", "height:100px;");
                color = "#4CAF50;";
            }

            else if (percent <= 10)
            {
                //filledspace.Attributes.Add("style", "background-color:#4CAF50;");
                emptyspace.Attributes.Add("style", "height:80px;");
                color = "#4CAF50;";
            }
            else if (percent > 10 && percent <= 25)
            {
                emptyspace.Attributes.Add("style", "height:70px;");
                color = "#8BC34A;";
            }
            else if (percent > 25 && percent <= 39)
            {
                emptyspace.Attributes.Add("style", "height:60px;");
                color = "#CDDC39;";
            }
            else if (percent >= 40 && percent <= 45)
            {
                emptyspace.Attributes.Add("style", "height:50px;");
                //filledspace.Attributes.Add("style", "background-color:#CDDC39;");
                color = "#FFEB3B;";
            }
            else if (percent > 45 && percent <= 60)
            {
                emptyspace.Attributes.Add("style", "height:45px;");
                color = "#FFC107";
            }
            else if (percent > 60 && percent <= 73)
            {
                emptyspace.Attributes.Add("style", "height:30px;");
                color = "#CC0000";
            }
            else if (percent > 73 && percent <= 79)
            {
                emptyspace.Attributes.Add("style", "height:20px;");
                color = "#CC0000";

            }
            else if (percent > 79 && percent <= 90)
            {
                emptyspace.Attributes.Add("style", "height:12px;");
                color = "#CC0000";
            }
            else
            {

                color = "#FF5722";
            }
            filledspace.Attributes.Add("style", "background-color:" + color);
            //emptyspace.Attributes.Add("style", "height:" + z + "px;");
            //}
        }

        public string task(string BinId)
        {
            business ob = new business();
            DataSet dsmstbintype = new DataSet();
            DataSet dsSelectsensorvalue = new DataSet();
            DataSet dsserialid = new DataSet();
            DataSet ds = new DataSet();
            try
            {

                //dsserialid = con.FN_ExecuteQuerySingle("select top 1 substring(message,9,10) as serialid  from newsms where len(message)>50 order by receiveddate desc");
               // string serialid = dsserialid.Tables[0].Rows[0]["serialid"].ToString();
                if ( BinId !=null)
                {
                   

                      //  ds = con.conn("Select * from Mst_Bin where BinId ='"+BinId+"'");
                    ds = ob.fn_bind_device(BinId);
                        //dsmstbintype = con.conn("select Bin_Type,SerialId from Mst_BinDevice where BinId='"+BinId+"'");
                    dsmstbintype = ob.fn_Mst_BinDevice(BinId);
                        long sensorone = 0;

                        if (dsmstbintype.Tables[0].Rows.Count > 0)
                        {
                            BinType = dsmstbintype.Tables[0].Rows[0]["Bin_Type"].ToString();
                            if (BinId == "1041")
                            {
                                //dsSelectsensorvalue = con.conn("select top 1 isnull(substring(message,35,3),0) as sensorone from newsms where len(message)>50 and message LIKE '%Serial0001%' order by receiveddate desc");
                                dsSelectsensorvalue = ob.fn_sub_string();
                            }
                            else
                            {
                             //   dsSelectsensorvalue = con.conn("select top 1 isnull(substring(message,35,3),0) as sensorone from newsms where len(message)>50 and message LIKE '%Serial0004%' order by receiveddate desc");
                                dsSelectsensorvalue = ob.fn_sub_string_2();
                            }
                            //dsSelectsensorvalue = con.FN_ExecuteQuerySingle("with abc as(select top 2 isnull(substring(message,35,3),0) as sensorone,isnull(substring(message,9,10),0) as serialid  from newsms where len(message)>50  order by receiveddate desc)select * from abc where serialid='Serial0004'");
                            if (dsSelectsensorvalue.Tables[0].Rows.Count > 0)
                            {

                                sensorone = Convert.ToInt32(dsSelectsensorvalue.Tables[0].Rows[0]["sensorone"].ToString());
                               

                            }
                            // dsSelectsensorvalue = con.FN_ExecuteQuerySingle("select top 1 SensorOne from IOT_String where deletestatus is null and location='" + Areaid + "' order by datetime desc");
                            long a = sensorone;


                            if (BinType == "F")
                            {
                                result = map(a, 290, 370, 0, 146);

                            }
                            else if (BinType == "H")
                            {
                                result = map(a, 0, 140, 0, 146);

                            }


                        }


                        long percent = ((result * 100) / 146);
                        //percent = (100 - percent);
                        if (percent < 0)
                        {
                            percent = 0;
                        }
                        else if (percent > 100)
                        {
                            percent = 100;
                        }



                        bin_design(result);

                    


                }
               
           
             return result.ToString();
            }
            catch
            {

                return "";

            }
            }

        
    }
}
