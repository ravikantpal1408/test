using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MAPBusiness;
using MAPConnection;
using System.Runtime.InteropServices;
//using System.Object;
//using System.EventArgs;
//using System.Windows.RoutedEventArgs;
//using System.Windows.Input.InputEventArgs;
//        System.Windows.Input.MouseEventArgs
//          System.Windows.Input.MouseButtonEventArgs


namespace WebApplication1
{
    public partial class vehicle_driver : System.Web.UI.Page
    {

        connections con=new connections();
        business ob=new business();
        DataSet ds=new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            bind_grid_vehicle();
            bind_grid_Driver();

        }



        public void bind_grid_vehicle()
        {
            ds = con.FN_ExecuteQuerySingle("select vehicle_num,vehicle_type from Mst_Vehicles");
            grid_vehicle.DataSource = ds;
            grid_vehicle.DataBind();

        
        }




        public void bind_grid_Driver()
        {
            ds = con.FN_ExecuteQuerySingle("select DriverID,DriverName from Mst_Drivers");
            grid_driver.DataSource = ds;
            grid_driver.DataBind();


        }


        //private void onMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Label element = sender as Label;
        //    if (element == null)
        //        return;
        //    DragDrop.DoDragDrop(element, new DataObject(this), DragDropEffects.Move);
        //}

    }
}