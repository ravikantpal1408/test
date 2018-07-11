



$(document).ready(function () {

  
    globaltable();



   // alert("ok")
    $.ajax({
        type: "POST",
        url: "car.asmx/bindddlzonewise__",
        data: "{ }",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            //alert("ok")
            var res = JSON.parse(data.d);


            for (var i = 0; i < res.length; i++) {

                $("#ddl_zone").append($('<option></option>')
                          .attr('value', res[i].Zone_id)
                          .text(res[i].Zone_Name));


                $("#Select1").append($('<option></option>')
             .attr('value', res[i].Zone_id)
             .text(res[i].Zone_Name));
                //ggwise


             //   $("#ggwise").append($('<option></option>')
             //.attr('value', res[i].garageid)
             //.text(res[i].garagename));







            }
            
        }
    });


})


function showsubpolicy() {


    //alert("ok")

    var policytype = $("#policy").val();





    if (policytype == "1") {

        $("#global_div").show();
        var zoneid=$("#ddl_zone").val();
        //ddl_zone
        globaltable();
        zonewstable(zoneid);

        var zzid = $("#Select1").val();
        var wwrd = $("#Select2").val();
        wardwstable(zzid, wwrd);


        //everything Hidden


    }
    else {


        $("#global_div").hide();
    }
    if (policytype == "2") {
        //document.getElementById("Div1").reset();
        $("#Div1").show();

        //everything Hidden


    }
    else {

        //document.getElementById("Div1").reset();
        $("#Div1").hide();
    }
    if (policytype == "3") {
       // alert(policytype)
        //document.getElementById("ddd").reset();
        $("#ddd").show();

        //everything Hidden


    }
    else {
        //document.getElementById("ddd").reset();

        $("#ddd").hide();
    }
    if (policytype == "4") {
        // alert(policytype)
       // document.getElementById("single").reset();
        $("#single").show();
        bindindividual();
        //everything Hidden


    }
    else {

        //document.getElementById("single").reset();
        $("#single").hide();
    }




}


function bindindividual()
{

    $.ajax({
        type: "POST",
        url: "car.asmx/bindindividual",
        data: "{}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            // alert(JSON.stringify(data.d))

            var result = JSON.parse(data.d);

            if (data.d == '' || data.d == null) {

                alert("Sorry No Data Found");
                $("#bindindividual_").html("");
                bindindividual_
            }
            else {

                //alert(JSON.stringify(data.d))
                //alert(result.length)


                $("#bindindividual_").html("");
                var res = '';
                var devicenm = '';
                var pollin = '';
                var keepin = '';
                var thrshin = '';

              //  res = res + "<tr><th style='text-align:center'><b>DEVICE NAME</b></th><th style='text-align:center'><b>POLLING INTERVAL</b></th><th style='text-align:center'><b>KEEP ALIVE INTERVAL</b></th><th style='text-align:center'><b>THRESHOLD INTERVAL</b></th><th style='text-align:center'><b>ACTION</b></th></tr>";
                //alert(JSON.stringify(data.d))
                //alert(result.length)
                for (var i = 0; i < result.length; i++) {
                    res = res + "<div class='col-sm-1' style='border-top:1px solid;border-right:1px solid;border-left:1px solid' > ";

                    if (result[i].Devicename == '' || result[i].Devicename == null) {
                        devicenm = 'NULL';


                    }
                    else {

                        devicenm = result[i].Devicename;


                    }
                    if (result[i].poll_interval == '' || result[i].poll_interval == null) {
                        pollin = '0';


                    }
                    else {

                        pollin = result[i].poll_interval;


                    }
                    if (result[i].keepaliveinterval == '' || result[i].keepaliveinterval == null) {
                        keepin = '0';


                    }
                    else {

                        keepin = result[i].keepaliveinterval;


                    }
                    if (result[i].threshold == '' || result[i].threshold == null) {
                        thrshin = '0';


                    }
                    else {

                        thrshin = result[i].threshold;


                    }


                    res = res + "<div class='dropdown'><a class='dropdown-toggle'  style='color:black;cursor:pointer' data-toggle='dropdown'>" + "<i class='fa fa-trash fa-2x'   style='color:grey'></i>" + "</a><ul class='dropdown-menu'><li class='dropdown-header'>Details:</li><li><a>DEVICE NAME :<b>" + devicenm + "</b></a></li><li><a>POLL INTERVAL:<b>" + pollin + "</b></a></li><li><a>KEEP ALIVE :<b>" + keepin + "</b></a></li><li><a>THRESHOLD: <b>" + thrshin + "</b></a></li><li><a class='btn btn-warning' style='cursor:pointer' " + " data-toggle='modal' data-target='#myModal' onclick=editind(" + result[i].BinId + ",'" + devicenm + "'," + pollin + "," + keepin + "," + thrshin + ")><b>EDIT</b></a></li></ul></div></div>";



                }


               // alert(res)
                $("#bindindividual_").html(res);





            }



        }
    });



}


function editind(binid,dname,pin,keep,thresh)
{
   // alert(binid)
    $("#binid123").val(binid);
  //  alert($("#binid123").val(binid))
    $("#devicename_in").val(dname);
    $("#poll_in").val(pin);
    $("#keep_in").val(keep);
    $("#thresh_in").val(thresh);



}


function udp_in_policy()
{

    var bid = $("#binid123").val();

   // alert($("#binid123").val())
   var dname = $("#devicename_in").val();
   var pin = $("#poll_in").val();
   var kai = $("#keep_in").val();
   var thresh = $("#thresh_in").val();

   $.ajax({
       type: "POST",
       url: "car.asmx/update_in_policy",
       data: "{'binid':'" + bid + "','device_nm':'" + dname + "','poll':'"+pin+"','keep':'"+kai+"','thresh':'"+thresh+"'}",
       dataType: "json",
       contentType: "application/json;charset=utf-8",
       success: function (data) {

           bindindividual()
           alert("Individual Policy Set successfully");


       }
   });



}

function sbt_g_policy() {


    var d_nm = $("#devicename").val();
    var pi = $("#pi").val();
    var kai = $("#kai").val();
    var th_lv = $("#th_lv").val();

    if (d_nm == "")
    {

        alert("Device Name cannot be left blank");
        return false;


    }

    if (pi == "") {

        alert("Polling interval cannot be left blank");
        return false;


    }
    if (kai == "") {

        alert("Keep alive interval cannot be left blank");
        return false;


    }
    if (th_lv == "") {

        alert("Threshold levels  interval cannot be left blank");
        return false;


    }


    $.ajax({
        type: "POST",
        url: "car.asmx/makeglobalpolicy",
        data: "{'devicename':'" + d_nm + "','poll_int':'" + pi + "','kai':'" + kai + "','th_lvl':'" + th_lv + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Policy Submitted Successfully")
            $("#devicename").val("");
            $("#pi").val("");
            $("#kai").val("");
            $("#th_lv").val("");
            globaltable();
        }
    });









}


function sbt_wr_policy()
{

    var zoneid = $("#Select1").val();
    var wardid = $("#Select2").val();


    var d_nm = $("#Text5").val();
    var pi = $("#Text6").val();
    var kai = $("#Text7").val();
    var th_lv = $("#Text8").val();


    if (zoneid == "0" || zoneid == null) {

        alert("Kindly Select Zone");
        return false;


    }
    if (wardid == "0" || zoneid == null) {

        alert("Kindly Select Ward");
        return false;


    }


    if (d_nm == "") {

        alert("Device Name cannot be left blank");
        return false;


    }

    if (pi == "") {

        alert("Polling interval cannot be left blank");
        return false;


    }
    if (kai == "") {

        alert("Keep alive interval cannot be left blank");
        return false;


    }
    if (th_lv == "") {

        alert("Threshold levels  interval cannot be left blank");
        return false;


    }


    $.ajax({
        type: "POST",
        url: "car.asmx/makewardpolicy",
        data: "{'zoneid':'" + zoneid + "','wardid':'"+wardid+"','devicename':'" + d_nm + "','poll_int':'" + pi + "','kai':'" + kai + "','th_lvl':'" + th_lv + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Policy Submitted Successfully")
            $("#Text5").val("");
            $("#Text6").val("");
            $("#Text7").val("");
            $("#Text8").val("");
            wardwstable(zoneid, wardid);

        }
    });









}



function bind_ward()
{
    var zoneid = $("#Select1").val();
    $("#Select2").html("");

    if (zoneid != "0" || zoneid != null) {

        $.ajax({
            type: "POST",
            url: "car.asmx/getwards",
            data: "{'zoneid':'" + zoneid + "'}",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (data) {


                var res = JSON.parse(data.d);


                for (var i = 0; i < res.length; i++) {

                    $("#Select2").append($('<option></option>')
                              .attr('value', res[i].ward_id)
                              .text(res[i].ward_name));
                }


            }
        });


    }
    else {

        alert("Select Zone First")


    }

}

function sbt_zn_policy()
{
    var zoneid = $("#ddl_zone").val();

    var d_nm = $("#Text1").val();
    var pi = $("#Text2").val();
    var kai = $("#Text3").val();
    var th_lv = $("#Text4").val();


    if (zoneid == "0" || zoneid==null) {

        alert("Kindly Select Zone");
        return false;


    }

    if (d_nm == "") {

        alert("Device Name cannot be left blank");
        return false;


    }

    if (pi == "") {

        alert("Polling interval cannot be left blank");
        return false;


    }
    if (kai == "") {

        alert("Keep alive interval cannot be left blank");
        return false;


    }
    if (th_lv == "") {

        alert("Threshold levels  interval cannot be left blank");
        return false;


    }


    $.ajax({
        type: "POST",
        url: "car.asmx/makezonalpolicy",
        data: "{'zoneid':'"+zoneid+"','devicename':'" + d_nm + "','poll_int':'" + pi + "','kai':'" + kai + "','th_lvl':'" + th_lv + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Policy Submitted Successfully")
            $("#Text1").val("");
            $("#Text2").val("");
            $("#Text3").val("");
            $("#Text4").val("");
            zonewstable(zoneid);
            
        }
    });






}

function zone_ws_ddl()
{
    var zoneid = $("#ddl_zone").val();
    zonewstable(zoneid);
   

}

function zonewstable(zoneid)
{
   // alert("ok")
   
    $.ajax({
        type: "POST",
        url: "car.asmx/zonewstable",
        data: "{'zoneid':'" + zoneid + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

           // alert(JSON.stringify(data.d))

            var result = JSON.parse(data.d);

            if (data.d == '' || data.d == null) {

                alert("Sorry No Data Found");
                $("#zonaltable").html("");

            }
            else {


               


                $("#zonaltable").html("");
                var res = '';

                res = res + "<tr><th style='text-align:center'><b>DEVICE NAME</b></th><th style='text-align:center'><b>POLLING INTERVAL</b></th><th style='text-align:center'><b>KEEP ALIVE INTERVAL</b></th><th style='text-align:center'><b>THRESHOLD INTERVAL</b></th><th style='text-align:center'><b>ACTION</b></th></tr>";
                //alert(JSON.stringify(data.d))
                //alert(result.length)
                for (var i = 0; i < result.length; i++) {
                    res = res + "<tr>";
                    res = res + "<td>" + result[i].Devicename + "</td>";
                    res = res + "<td>" + result[i].poll_interval + "</td>";
                    res = res + "<td>" + result[i].keepaliveinterval + "</td>";
                    res = res + "<td>" + result[i].threshold + "</td>";
                    res = res + "<td><a class='btn btn-default' onclick=editbinzonal('" + result[i].id + "','" + result[i].Devicename + "','" + result[i].poll_interval + "','" + result[i].keepaliveinterval + "','" + result[i].threshold + "')><i class='fa fa-pencil'></i></a>&nbsp;<a  class='btn btn-default' style='display:none' onclick=zonal_del(" + result[i].id + ") ><i class='fa fa-trash'></i></a></td>";
                    res = res + "</tr>";

                }



                $("#zonaltable").html(res);





            }



        }
    });



}


function ward_ws_ddl_() {
   
    var zoneid = $("#Select1").val();
    var wardid = $("#Select2").val();
    wardwstable(zoneid, wardid);

}


function wardwstable(zoneid, wardid) {

    //alert("ok")

    //alert(zoneid)
    //alert(wardid)
    $.ajax({
        type: "POST",
        url: "car.asmx/wardwstable",
        data: "{'zoneid':'" + zoneid + "','wardid':'"+wardid+"'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            // alert(JSON.stringify(data.d))

            if (data.d == '' || data.d == null) {

                alert("Sorry No Data Found");
                $("#wardtable").html("");

            }
            else {


                var result = JSON.parse(data.d);


                $("#wardtable").html("");
                var res = '';

                res = res + "<tr><th style='text-align:center'><b>DEVICE NAME</b></th><th style='text-align:center'><b>POLLING INTERVAL</b></th><th style='text-align:center'><b>KEEP ALIVE INTERVAL</b></th><th style='text-align:center'><b>THRESHOLD INTERVAL</b></th><th style='text-align:center'><b>ACTION</b></th></tr>";
                //alert(JSON.stringify(data.d))
                //alert(result.length)
                for (var i = 0; i < result.length; i++) {
                    res = res + "<tr>";
                    res = res + "<td>" + result[i].Devicename + "</td>";
                    res = res + "<td>" + result[i].poll_interval + "</td>";
                    res = res + "<td>" + result[i].keepaliveinterval + "</td>";
                    res = res + "<td>" + result[i].threshold + "</td>";
                    res = res + "<td><a class='btn btn-default' onclick=editbinward('" + result[i].id + "','" + result[i].Devicename + "','" + result[i].poll_interval + "','" + result[i].keepaliveinterval + "','" + result[i].threshold + "')><i class='fa fa-pencil'></i></a>&nbsp;<a  class='btn btn-default'  style='display:none' onclick=ward_del(" + result[i].id + ") ><i class='fa fa-trash'></i></a></td>";
                    res = res + "</tr>";

                }



                $("#wardtable").html(res);





            }



        }
    });



}


function ward_del(id)
{
    var zid = $("#Select1").val();
    var wid = $("#Select2").val()

    $.ajax({
        type: "POST",
        url: "car.asmx/ward_del",
        data: "{'id':'" + id + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Deleted Successfully");
            wardwstable(zid, wid);

        }
    })



}

function udp_wr_policy()
{

    var zoneid = $("#Select1").val();
    var wardid = $("#Select2").val();
    var id = $("#Hidden2").val();

    var d_nm = $("#Text5").val();
    //alert(d_nm)
    var poll_int = $("#Text8").val();
    // alert(poll_int)
    var keep = $("#Text6").val();
    // alert(keep)
    var thresh = $("#Text7").val();
    //alert(thresh)

    $.ajax({
        type: "POST",
        url: "car.asmx/updatewardpolicy",
        data: "{'zoneid':'" + zoneid + "','wardid':'" + wardid + "','devicename':'" + d_nm + "','poll_int':'" + poll_int + "','kai':'" + keep + "','th_lvl':'" + thresh + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Updated Successfully");
            wardwstable(zoneid, wardid);

        }
    })



}



function editbinward(id, devicename, poll_interval, keep_alive_int, threshold_level)
{

    $("#Hidden2").val(id);


    $("#Text5").val(devicename);

    $("#Text6").val(keep_alive_int);
    $("#Text7").val(threshold_level);
    $("#Text8").val(poll_interval);
    $("#sbt_wrd").hide();
    $("#udp_wrd").show();



    //sbt_wrd


}









function globaltable()
{
    
    $.ajax({
        type: "POST",
        url: "car.asmx/globaltable",
        data: "{}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

           // alert(JSON.stringify(data.d))

            if (data.d == '' || data.d == null) {

                alert("Sorry No Data Found");
                $("#globalbin").html("");

            }
            else {


                var result = JSON.parse(data.d);


                $("#globalbin").html("");
                var res = '';

                res = res + "<tr><th style='text-align:center'><b>DEVICE NAME</b></th><th style='text-align:center'><b>POLLING INTERVAL</b></th><th style='text-align:center'><b>KEEP ALIVE INTERVAL</b></th><th style='text-align:center'><b>THRESHOLD INTERVAL</b></th><th style='text-align:center'><b>ACTION</b></th></tr>";
                //alert(JSON.stringify(data.d))
                //alert(result.length)
                for (var i = 0; i < result.length; i++)
                {
                    res = res + "<tr>";
                    res = res + "<td>" + result[i].Devicename + "</td>";
                    res = res + "<td>" + result[i].poll_interval + "</td>";
                    res = res + "<td>" + result[i].keepaliveinterval + "</td>";
                    res = res + "<td>" + result[i].threshold + "</td>";
                    res = res + "<td><a class='btn btn-default' onclick=editbinglobal('" + result[i].id + "','" + result[i].Devicename + "','" + result[i].poll_interval + "','" + result[i].keepaliveinterval + "','" + result[i].threshold + "')><i class='fa fa-pencil'></i></a>&nbsp;<a  class='btn btn-default'  style='display:none' onclick=global_del(" + result[i].id + ") ><i class='fa fa-trash'></i></a></td>";
                    res = res + "</tr>";

                }



                $("#globalbin").html(res);





            }



        }
    });



}

function zonal_del(id)
{
    var zid = $("#ddl_zone").val()

    $.ajax({
        type: "POST",
        url: "car.asmx/zonal_del",
        data: "{'id':'" + id + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Deleted Successfully");
            zonewstable(zid);

        }
    })


}

function global_del(id)
{

    $.ajax({
        type: "POST",
        url: "car.asmx/global_del",
        data: "{'id':'" + id + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Deleted Successfully");
            globaltable();

        }
    })


}

function udp_g_policy() {


    // alert("ok")


    var id = $("#gl_id").val();
    //alert(id)
    var d_nm = $("#devicename").val();
    //alert(d_nm)
    var poll_int = $("#pi").val();
   // alert(poll_int)
    var keep = $("#kai").val();
   // alert(keep)
    var thresh = $("#th_lv").val();
    //alert(thresh)

    $.ajax({
        type: "POST",
        url: "car.asmx/updateglobalpolicy",
        data: "{'id':'" + id + "','devicename':'" + d_nm + "','poll_int':'" + poll_int + "','kai':'" + keep + "','th_lvl':'" + thresh + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Updated Successfully");
            globaltable();

        }
    })




}




function editbinglobal(id,dnm, pi, kai, thlvl)
{
    // alert(id)
    $("#gl_id").val(id);
    $("#devicename").val(dnm);
    $("#pi").val(pi);
    $("#kai").val(kai);
    $("#th_lv").val(thlvl);

    


  //  alert($("#gl_id").val())
    $("#udp_gl").show();
    $("#sbt_gl").hide();






}

//udp_zn_policy


function udp_zn_policy() {


    // alert("ok")

    var zid = $("#ddl_zone").val()
    //alert(zid)
  //  var id = $("#Hidden1").val();
    //alert(id)
    var d_nm = $("#Text1").val();
    //alert(d_nm)
    var poll_int = $("#Text4").val();
    // alert(poll_int)
    var keep = $("#Text2").val();
    // alert(keep)
    var thresh = $("#Text3").val();
    //alert(thresh)

    $.ajax({
        type: "POST",
        url: "car.asmx/updatezonalpolicy",
        data: "{'zid':'" + zid + "','Devicename':'" + d_nm + "','poll_interval':'" + poll_int + "','keepaliveinterval':'" + keep + "','threshold':'" + thresh + "'}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            alert("Updated Successfully");
            zonewstable(zid);

        }
    })




}





function editbinzonal(id, dnm, pi, kai, thlvl) {
    // alert(id)
    $("#Hidden1").val(id);
    $("#Text1").val(dnm);
    $("#Text4").val(pi);
    $("#Text2").val(kai);
    $("#Text3").val(thlvl);




    //  alert($("#gl_id").val())
    $("#ssss").hide();
    $("#A2").show();
    






}