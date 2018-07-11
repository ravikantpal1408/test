


$(document).ready(function () {



   // alert("ok")
    getSensor();






})


function getSensor()
{

    $.ajax({
        type: "POST",
        url: "car.asmx/getsensorhealth",
        data: "{}",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var result = JSON.parse(data.d);
            //alert(JSON.stringify(result))

            var res = '';


            var health = '';
            var healthstatus = '';


            if (data.d == '' || data.d == null) {



                res = res + "<h3>NO DATA</h3>"


            }
            else {


                $("#row1").html("");
                for (var i = 0; i < result.length; i++) {


                    switch (result[i].sensorhealth) {

                        case '1':
                            health = " <i class='fa fa-trash fa-2x'  data-toggle='tooltip()' title='" + result[i].BinId + "' style='color:green'></i>";
                            healthstatus = 'Good';
                            break;
                        case '2':
                            health = " <i class='fa fa-trash fa-2x'  data-toggle='tooltip()' title='" + result[i].BinId + "' style='color:orange'></i>";
                            healthstatus = 'Health at Risk';
                            break;
                        case '3':
                            health = " <i class='fa fa-trash fa-2x'  data-toggle='tooltip()' title='" + result[i].BinId + "' style='color:red'></i>";
                            healthstatus = 'Dead';
                            break;

                    
                        default:
                            health = " <i class='fa fa-trash fa-2x'  data-toggle='tooltip()' title='" + result[i].BinId + "' style='color:black'></i>";
                            healthstatus = 'Sensor Not installed';
                            break;

                    }
              
                    var HTstatus = 'SENSOR NOT INSTALLED';


                    res = res + "<div class='col-sm-1' style='border-top:1px solid;border-right:1px solid;border-left:1px solid' > ";

                    res = res + "<div class='dropdown'><a class='dropdown-toggle'  style='color:black;cursor:pointer' data-toggle='dropdown'>" + health + "</a><ul class='dropdown-menu'><li class='dropdown-header'>Details:</li><li><a>Bin ID :<b>" + result[i].BinId + "</b></a></li><li><a>Bin Name:<b>" + result[i].BinName + "</b></a></li><li><a>Health Status: <b>" + healthstatus + "</b></a></li></ul></div></div>";

                }








            }



    
            $("#row1").html(res);





        }
    });





}