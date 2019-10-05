<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage1.aspx.cs" Inherits="MIS_Dashboard.HomePage1" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords" content="">
    <meta name="description" content="">
    <!--

Template 2075 Digital Team

http://www.tooplate.com/view/2075-digital-team

-->
    <link rel="stylesheet" href="templatecss/css/bootstrap.min.css">
    <link rel="stylesheet" href="templatecss/css/font-awesome.min.css">
    <link rel="stylesheet" href="templatecss/css/animate.min.css">
    <link rel="stylesheet" href="templatecss/css/et-line-font.css">
    <link rel="stylesheet" href="templatecss/css/nivo-lightbox.css">
    <link rel="stylesheet" href="templatecss/css/nivo_themes/default/default.css">
    <link rel="stylesheet" href="templatecss/css/style.css">
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,300,500' rel='stylesheet' type='text/css'>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="JS/Speedometer.js"></script>
    <script src="JS/canvasjs.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>


    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <%--Login model Style Start--%>
    <style type="text/css">
        body
        {
            font-family: 'Varela Round', sans-serif;
        }

        .modal-login
        {
            color: #636363;
            width: 350px;
        }

            .modal-login .modal-content
            {
                padding: 20px;
                border-radius: 5px;
                border: none;
            }

            .modal-login .modal-header
            {
                border-bottom: none;
                position: relative;
                justify-content: center;
            }

            .modal-login h4
            {
                text-align: center;
                font-size: 26px;
                margin: 30px 0 -15px;
            }

            .modal-login .form-control:focus
            {
                border-color: #70c5c0;
            }

            .modal-login .form-control, .modal-login .btn
            {
                min-height: 40px;
                border-radius: 3px;
            }

            .modal-login .close
            {
                position: absolute;
                top: -5px;
                right: -5px;
            }

            .modal-login .modal-footer
            {
                background: #ecf0f1;
                border-color: #dee4e7;
                text-align: center;
                justify-content: center;
                margin: 0 -20px -20px;
                border-radius: 5px;
                font-size: 13px;
            }

                .modal-login .modal-footer a
                {
                    color: #999;
                }

            .modal-login .avatar
            {
                position: absolute;
                margin: 0 auto;
                left: 0;
                right: 0;
                top: -70px;
                width: 95px;
                height: 95px;
                border-radius: 50%;
                z-index: 9;
                background: #ffffff;
                padding: 15px;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

                .modal-login .avatar img
                {
                    width: 100%;
                }

            .modal-login.modal-dialog
            {
                margin-top: 80px;
            }

            .modal-login .btn
            {
                color: #fff;
                border-radius: 4px;
                background: #60c7c1;
                text-decoration: none;
                transition: all 0.4s;
                line-height: normal;
                border: none;
            }

                .modal-login .btn:hover, .modal-login .btn:focus
                {
                    background: #45aba6;
                    outline: none;
                }

        .trigger-btn
        {
            display: inline-block;
            margin: 100px auto;
        }
    </style>
    <%--Login model Style End--%>

    <%-- Speedo Meter Start--%>
    <script>
        function getspeedoMeterStatus() {
            //var kpivalue = $('#lblkpi').text();
            //var division = $('#lbldivision').text();

            totalUnits = 0;

            ajaxReq('DefaultHandler.ashx',
                       'getSpeedoMeterStatusForKpiAllCWC',
          {
          },
           function (resp) {
               showcumlativeData(resp)
           }, true);
        }

    </script>
    <script>
        var totalUnits = 0;

        //ready function start
        $(document).ready(function () {
            getspeedoMeterStatus();

        });




        //ready function End

        function ajaxReq(handler, reqType, data, callbackFun, asyc) {
            if (asyc) asyc = true; else asyc = false;
            $.ajax({
                url: handler + "?request=" + reqType,
                type: "post",
                async: asyc,
                data: data,
                error: function (jqXHR, exception) {
                    alert("Oops! Something went wrong.");
                    var msg = '';
                    if (jqXHR.status === 0) {
                        msg = 'Not connect.\n Verify Network.';
                    } else if (jqXHR.status == 404) {
                        msg = 'Requested page not found. [404]';
                    } else if (jqXHR.status == 500) {
                        msg = 'Internal Server Error [500].';
                    } else if (exception === 'parsererror') {
                        msg = 'Requested JSON parse failed.';
                    } else if (exception === 'timeout') {
                        msg = 'Time out error.';
                    } else if (exception === 'abort') {
                        msg = 'Ajax request aborted.';
                    } else {
                        msg = 'Uncaught Error.\n' + jqXHR.responseText;
                    }
                    $('#post').html(msg);
                }
            }).done(callbackFun);
        }


        /*Production Data Start Using Speedo Meter */

        function showcumlativeData(resp) {
            console.log(resp);
            var days100planned = 0;
            var days100actual = 0;
            var days1planned = 0;
            var days1actual = 0;
            var days2planned = 0;
            var days2actual = 0;
            var days3planned = 0;
            var days3actual = 0;
            var days4planned = 0;
            var days4actual = 0;
            var days5planned = 0;
            var days5actual = 0;
            var percentGas = 0;
            var percentWaterPrd = 0;
            var percentWaterlvl = 0;
            var maxGas = 0;
            var maxwaterprod = 0;
            var maxwaterlvl = 0;
            var cumgas = 0;
            var cumwaterprd = 0;
            var cumwaterlvl = 0;
            var initiativetext;
            console.log("Hello Im ");
            if (resp.status === true) {
                for (i = 0; i < resp.data.length; i++) {

                    if (resp.data[i].name == "0") {
                        days100planned = resp.data[i].days100_PLANNED_VALUE;
                        days1planned = resp.data[i].days1_YearPLANNED_VALUE;
                        days2planned = resp.data[i].days2_YearPLANNED_VALUE;
                        days3planned = resp.data[i].days3_YearPLANNED_VALUE;
                        days4planned = resp.data[i].days4_YearPLANNED_VALUE;
                        days5planned = resp.data[i].days5_YearPLANNED_VALUE;
                        initiativetext = resp.data[i].INITIATIVE;
                    }
                    else if (resp.data[i].name == "1") {
                        days100actual = resp.data[i].days100_PLANNED_VALUE;
                        days1actual = resp.data[i].days1_YearPLANNED_VALUE;
                        days2actual = resp.data[i].days2_YearPLANNED_VALUE;
                        days3actual = resp.data[i].days3_YearPLANNED_VALUE;
                        days4actual = resp.data[i].days4_YearPLANNED_VALUE;
                        days5actual = resp.data[i].days5_YearPLANNED_VALUE;
                    }
                }
                console.log(days100planned);
                console.log(days100actual);

                maxGas = days100planned / 5;
                max1yearGas = days1planned / 5;
                max2yearGas = days2planned / 5;
                max3yearGas = days3planned / 5;
                max4yearGas = days4planned / 5;
                max5yearGas = days5planned / 5;

                var opts = {
                    angle: -0.1, // The span of the gauge arc
                    lineWidth: 0.44, // The line thickness
                    radiusScale: 1, // Relative radius
                    pointer: {
                        length: 0.6, // // Relative to gauge radius
                        strokeWidth: 0.035, // The thickness
                        color: '#000000' // Fill color
                    },
                    limitMax: false,     // If false, max value increases automatically if value > maxValue
                    limitMin: false,     // If true, the min value of the gauge will be fixed
                    colorStart: '#6FADCF',   // Colors
                    colorStop: '#8FC0DA',    // just experiment with them
                    strokeColor: '#E0E0E0',  // to see which ones work best for you
                    generateGradient: true,
                    highDpiSupport: true,     // High resolution support
                    // font:12,
                    // renderTicks is Optional
                    renderTicks: {
                        divisions: 5,
                        divWidth: 1.1,
                        divLength: 0.7,
                        divColor: '#193317',
                        subDivisions: 3,
                        subLength: 0.5,
                        subWidth: 0.6,
                        subColor: '#666666'
                    },
                    percentColors: [[0.0, "#a9d70b"], [0.50, "#f9c802"], [1.0, "#ff0000"]],
                    staticLabels: {
                        font: "10px sans-serif",  // Specifies font
                        labels: [0, maxGas, maxGas + maxGas, maxGas + maxGas + maxGas, maxGas + maxGas + maxGas + maxGas, maxGas + maxGas + maxGas + maxGas + maxGas],  // Print labels at these values
                        color: "#000000",  // Optional: Label text color
                        fractionDigits: 0  // Optional: Numerical precision. 0=round off.
                    },
                    staticZones: [
                     { strokeStyle: "#F03E3E", min: 0, max: maxGas, height: 0.6 }, // Red from 100 to 130
                     { strokeStyle: "#FFDD00", min: maxGas, max: maxGas + maxGas, height: 0.6 }, // Yellow
                     { strokeStyle: "#30B32D", min: maxGas + maxGas, max: maxGas + maxGas + maxGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: maxGas + maxGas + maxGas, max: maxGas + maxGas + maxGas + maxGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: maxGas + maxGas + maxGas + maxGas, max: maxGas + maxGas + maxGas + maxGas + maxGas, height: 0.6 }
                    ]
                };

                var opts1 = {
                    angle: -0.1, // The span of the gauge arc
                    lineWidth: 0.44, // The line thickness
                    radiusScale: 1, // Relative radius
                    pointer: {
                        length: 0.6, // // Relative to gauge radius
                        strokeWidth: 0.035, // The thickness
                        color: '#000000' // Fill color
                    },
                    limitMax: false,     // If false, max value increases automatically if value > maxValue
                    limitMin: false,     // If true, the min value of the gauge will be fixed
                    colorStart: '#6FADCF',   // Colors
                    colorStop: '#8FC0DA',    // just experiment with them
                    strokeColor: '#E0E0E0',  // to see which ones work best for you
                    generateGradient: true,
                    highDpiSupport: true,     // High resolution support
                    // font:12,
                    // renderTicks is Optional
                    renderTicks: {
                        divisions: 5,
                        divWidth: 1.1,
                        divLength: 0.7,
                        divColor: '#193317',
                        subDivisions: 3,
                        subLength: 0.5,
                        subWidth: 0.6,
                        subColor: '#666666'
                    },
                    percentColors: [[0.0, "#a9d70b"], [0.50, "#f9c802"], [1.0, "#ff0000"]],
                    staticLabels: {
                        font: "10px sans-serif",  // Specifies font
                        labels: [0, max1yearGas, max1yearGas + max1yearGas, max1yearGas + max1yearGas + max1yearGas, max1yearGas + max1yearGas + max1yearGas + max1yearGas, max1yearGas + max1yearGas + max1yearGas + max1yearGas + max1yearGas],  // Print labels at these values
                        color: "#000000",  // Optional: Label text color
                        fractionDigits: 0  // Optional: Numerical precision. 0=round off.
                    },
                    staticZones: [
                     { strokeStyle: "#F03E3E", min: 0, max: max1yearGas, height: 0.6 }, // Red from 100 to 130
                     { strokeStyle: "#FFDD00", min: max1yearGas, max: max1yearGas + max1yearGas, height: 0.6 }, // Yellow
                     { strokeStyle: "#30B32D", min: max1yearGas + max1yearGas, max: max1yearGas + max1yearGas + max1yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max1yearGas + max1yearGas + max1yearGas, max: max1yearGas + max1yearGas + max1yearGas + max1yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max1yearGas + max1yearGas + max1yearGas + max1yearGas, max: max1yearGas + max1yearGas + max1yearGas + max1yearGas + max1yearGas, height: 0.6 }
                    ]
                };

                var opts2 = {
                    angle: -0.1, // The span of the gauge arc
                    lineWidth: 0.44, // The line thickness
                    radiusScale: 1, // Relative radius
                    pointer: {
                        length: 0.6, // // Relative to gauge radius
                        strokeWidth: 0.035, // The thickness
                        color: '#000000' // Fill color
                    },
                    limitMax: false,     // If false, max value increases automatically if value > maxValue
                    limitMin: false,     // If true, the min value of the gauge will be fixed
                    colorStart: '#6FADCF',   // Colors
                    colorStop: '#8FC0DA',    // just experiment with them
                    strokeColor: '#E0E0E0',  // to see which ones work best for you
                    generateGradient: true,
                    highDpiSupport: true,     // High resolution support
                    // font:12,
                    // renderTicks is Optional
                    renderTicks: {
                        divisions: 5,
                        divWidth: 1.1,
                        divLength: 0.7,
                        divColor: '#193317',
                        subDivisions: 3,
                        subLength: 0.5,
                        subWidth: 0.6,
                        subColor: '#666666'
                    },
                    percentColors: [[0.0, "#a9d70b"], [0.50, "#f9c802"], [1.0, "#ff0000"]],
                    staticLabels: {
                        font: "10px sans-serif",  // Specifies font
                        labels: [0, max2yearGas, max2yearGas + max2yearGas, max2yearGas + max2yearGas + max2yearGas, max2yearGas + max2yearGas + max2yearGas + max2yearGas, max2yearGas + max2yearGas + max2yearGas + max2yearGas + max2yearGas],  // Print labels at these values
                        color: "#000000",  // Optional: Label text color
                        fractionDigits: 0  // Optional: Numerical precision. 0=round off.
                    },
                    staticZones: [
                     { strokeStyle: "#F03E3E", min: 0, max: max2yearGas, height: 0.6 }, // Red from 100 to 130
                     { strokeStyle: "#FFDD00", min: max2yearGas, max: max2yearGas + max2yearGas, height: 0.6 }, // Yellow
                     { strokeStyle: "#30B32D", min: max2yearGas + max2yearGas, max: max2yearGas + max2yearGas + max2yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max2yearGas + max2yearGas + max2yearGas, max: max2yearGas + max2yearGas + max2yearGas + max2yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max2yearGas + max2yearGas + max2yearGas + max2yearGas, max: max2yearGas + max2yearGas + max2yearGas + max2yearGas + max2yearGas, height: 0.6 }
                    ]
                };

                var opts3 = {
                    angle: -0.1, // The span of the gauge arc
                    lineWidth: 0.44, // The line thickness
                    radiusScale: 1, // Relative radius
                    pointer: {
                        length: 0.6, // // Relative to gauge radius
                        strokeWidth: 0.035, // The thickness
                        color: '#000000' // Fill color
                    },
                    limitMax: false,     // If false, max value increases automatically if value > maxValue
                    limitMin: false,     // If true, the min value of the gauge will be fixed
                    colorStart: '#6FADCF',   // Colors
                    colorStop: '#8FC0DA',    // just experiment with them
                    strokeColor: '#E0E0E0',  // to see which ones work best for you
                    generateGradient: true,
                    highDpiSupport: true,     // High resolution support
                    // font:12,
                    // renderTicks is Optional
                    renderTicks: {
                        divisions: 5,
                        divWidth: 1.1,
                        divLength: 0.7,
                        divColor: '#193317',
                        subDivisions: 3,
                        subLength: 0.5,
                        subWidth: 0.6,
                        subColor: '#666666'
                    },
                    percentColors: [[0.0, "#a9d70b"], [0.50, "#f9c802"], [1.0, "#ff0000"]],
                    staticLabels: {
                        font: "10px sans-serif",  // Specifies font
                        labels: [0, max3yearGas, max3yearGas + max3yearGas, max3yearGas + max3yearGas + max3yearGas, max3yearGas + max3yearGas + max3yearGas + max3yearGas, max3yearGas + max3yearGas + max3yearGas + max3yearGas + max3yearGas],  // Print labels at these values
                        color: "#000000",  // Optional: Label text color
                        fractionDigits: 0  // Optional: Numerical precision. 0=round off.
                    },
                    staticZones: [
                     { strokeStyle: "#F03E3E", min: 0, max: max3yearGas, height: 0.6 }, // Red from 100 to 130
                     { strokeStyle: "#FFDD00", min: max3yearGas, max: max3yearGas + max3yearGas, height: 0.6 }, // Yellow
                     { strokeStyle: "#30B32D", min: max3yearGas + max3yearGas, max: max3yearGas + max3yearGas + max3yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max3yearGas + max3yearGas + max3yearGas, max: max3yearGas + max3yearGas + max3yearGas + max3yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max3yearGas + max3yearGas + max3yearGas + max3yearGas, max: max3yearGas + max3yearGas + max3yearGas + max3yearGas + max3yearGas, height: 0.6 }
                    ]
                };

                var opts4 = {
                    angle: -0.1, // The span of the gauge arc
                    lineWidth: 0.44, // The line thickness
                    radiusScale: 1, // Relative radius
                    pointer: {
                        length: 0.6, // // Relative to gauge radius
                        strokeWidth: 0.035, // The thickness
                        color: '#000000' // Fill color
                    },
                    limitMax: false,     // If false, max value increases automatically if value > maxValue
                    limitMin: false,     // If true, the min value of the gauge will be fixed
                    colorStart: '#6FADCF',   // Colors
                    colorStop: '#8FC0DA',    // just experiment with them
                    strokeColor: '#E0E0E0',  // to see which ones work best for you
                    generateGradient: true,
                    highDpiSupport: true,     // High resolution support
                    // font:12,
                    // renderTicks is Optional
                    renderTicks: {
                        divisions: 5,
                        divWidth: 1.1,
                        divLength: 0.7,
                        divColor: '#193317',
                        subDivisions: 3,
                        subLength: 0.5,
                        subWidth: 0.6,
                        subColor: '#666666'
                    },
                    percentColors: [[0.0, "#a9d70b"], [0.50, "#f9c802"], [1.0, "#ff0000"]],
                    staticLabels: {
                        font: "10px sans-serif",  // Specifies font
                        labels: [0, max4yearGas, max4yearGas + max4yearGas, max4yearGas + max4yearGas + max4yearGas, max4yearGas + max4yearGas + max4yearGas + max4yearGas, max4yearGas + max4yearGas + max4yearGas + max4yearGas + max4yearGas],  // Print labels at these values
                        color: "#000000",  // Optional: Label text color
                        fractionDigits: 0  // Optional: Numerical precision. 0=round off.
                    },
                    staticZones: [
                     { strokeStyle: "#F03E3E", min: 0, max: max4yearGas, height: 0.6 }, // Red from 100 to 130
                     { strokeStyle: "#FFDD00", min: max4yearGas, max: max4yearGas + max4yearGas, height: 0.6 }, // Yellow
                     { strokeStyle: "#30B32D", min: max4yearGas + max4yearGas, max: max4yearGas + max4yearGas + max4yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max4yearGas + max4yearGas + max4yearGas, max: max4yearGas + max4yearGas + max4yearGas + max4yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max4yearGas + max4yearGas + max4yearGas + max4yearGas, max: max4yearGas + max4yearGas + max4yearGas + max4yearGas + max4yearGas, height: 0.6 }
                    ]
                };

                var opts5 = {
                    angle: -0.1, // The span of the gauge arc
                    lineWidth: 0.44, // The line thickness
                    radiusScale: 1, // Relative radius
                    pointer: {
                        length: 0.6, // // Relative to gauge radius
                        strokeWidth: 0.035, // The thickness
                        color: '#000000' // Fill color
                    },
                    limitMax: false,     // If false, max value increases automatically if value > maxValue
                    limitMin: false,     // If true, the min value of the gauge will be fixed
                    colorStart: '#6FADCF',   // Colors
                    colorStop: '#8FC0DA',    // just experiment with them
                    strokeColor: '#E0E0E0',  // to see which ones work best for you
                    generateGradient: true,
                    highDpiSupport: true,     // High resolution support
                    // font:12,
                    // renderTicks is Optional
                    renderTicks: {
                        divisions: 5,
                        divWidth: 1.1,
                        divLength: 0.7,
                        divColor: '#193317',
                        subDivisions: 3,
                        subLength: 0.5,
                        subWidth: 0.6,
                        subColor: '#666666'
                    },
                    percentColors: [[0.0, "#a9d70b"], [0.50, "#f9c802"], [1.0, "#ff0000"]],
                    staticLabels: {
                        font: "10px sans-serif",  // Specifies font
                        labels: [0, max5yearGas, max5yearGas + max5yearGas, max5yearGas + max5yearGas + max5yearGas, max5yearGas + max5yearGas + max5yearGas + max5yearGas, max5yearGas + max5yearGas + max5yearGas + max5yearGas + max5yearGas],  // Print labels at these values
                        color: "#000000",  // Optional: Label text color
                        fractionDigits: 0  // Optional: Numerical precision. 0=round off.
                    },
                    staticZones: [
                     { strokeStyle: "#F03E3E", min: 0, max: max5yearGas, height: 0.6 }, // Red from 100 to 130
                     { strokeStyle: "#FFDD00", min: max5yearGas, max: max5yearGas + max5yearGas, height: 0.6 }, // Yellow
                     { strokeStyle: "#30B32D", min: max5yearGas + max5yearGas, max: max5yearGas + max5yearGas + max5yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max5yearGas + max5yearGas + max5yearGas, max: max5yearGas + max5yearGas + max5yearGas + max5yearGas, height: 0.6 }, // Green
                     { strokeStyle: "#30B32D", min: max5yearGas + max5yearGas + max5yearGas + max5yearGas, max: max5yearGas + max5yearGas + max5yearGas + max5yearGas + max5yearGas, height: 0.6 }
                    ]
                };



                var target = document.getElementById('SpeedoGas'); // your canvas element
                var gauge = new Gauge(target).setOptions(opts); // create sexy gauge!
                gauge.maxValue = days100planned; // set max gauge value
                gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
                gauge.animationSpeed = 10; // set animation speed (32 is default value)
                gauge.set(days100actual); // set actual value

                var target = document.getElementById('SpeedoFirstYear'); // your canvas element
                var gauge = new Gauge(target).setOptions(opts1); // create sexy gauge!
                gauge.maxValue = days1planned; // set max gauge value
                gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
                gauge.animationSpeed = 10; // set animation speed (32 is default value)
                gauge.set(days1actual); // set actual value

                var target = document.getElementById('SpeedoSecondYear'); // your canvas element
                var gauge = new Gauge(target).setOptions(opts2); // create sexy gauge!
                gauge.maxValue = days2planned; // set max gauge value
                gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
                gauge.animationSpeed = 10; // set animation speed (32 is default value)
                gauge.set(days2actual); // set actual value

                var target = document.getElementById('SpeedoThirdYear'); // your canvas element
                var gauge = new Gauge(target).setOptions(opts3); // create sexy gauge!
                gauge.maxValue = days3planned; // set max gauge value
                gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
                gauge.animationSpeed = 10; // set animation speed (32 is default value)
                gauge.set(days3actual); // set actual value

                var target = document.getElementById('SpeedoFourYear'); // your canvas element
                var gauge = new Gauge(target).setOptions(opts4); // create sexy gauge!
                gauge.maxValue = days4planned; // set max gauge value
                gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
                gauge.animationSpeed = 10; // set animation speed (32 is default value)
                gauge.set(days4actual); // set actual value

                var target = document.getElementById('SpeedoFifthYear'); // your canvas element
                var gauge = new Gauge(target).setOptions(opts5); // create sexy gauge!
                gauge.maxValue = days5planned; // set max gauge value
                gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
                gauge.animationSpeed = 10; // set animation speed (32 is default value)
                gauge.set(days5actual); // set actual value

                //$("#actual").text(parseInt(actual));
                //$("#Plan").text(parseInt(planned));
                //$("#lblinitiative").text(initiativetext);


            }
        }

        function cumlativeData() {
            ajaxReq('./HomePageDashboard/PrdtnDashBoardDayWise.ashx',
                      'getCumlativeDayWisePrdtnStatus',
                      {

                      },
                      function (resp) {
                          showcumlativeData(resp)
                      }, true);

        }



    </script>
    <%-- Speedp Meter End--%>
</head>
<body data-spy="scroll" data-target=".navbar-collapse" data-offset="50">



    <!-- navigation section -->
    <section class="navbar navbar-fixed-top custom-navbar" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon icon-bar"></span>
                    <span class="icon icon-bar"></span>
                    <span class="icon icon-bar"></span>
                </button>
                <%--<a href="#" class="navbar-brand">CWC</a>--%>
                <h3><span class="smoothScroll" style="color: seagreen">Performance Dashboard</span></h3>
            </div>
            <div class="collapse navbar-collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#myModal" data-toggle="modal" data-target="#myModal" class="smoothScroll">Login</a></li>
                </ul>
            </div>
        </div>
    </section>

    <!-- home section -->

    <div id="myModal" class="modal fade" runat="server">
        <div class="modal-dialog modal-login">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="avatar">
                        <img src="logo1.png" alt="CWC">
                    </div>
                    <h4 class="modal-title">Login</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" runat="server">
                    <form  runat="server">
                        <div class="form-group">
                            <input class="form-control" id="txtUsername"   type="text" name="username" placeholder="Username" runat="server" >
                        </div>
                        <div class="form-group">
                            <input class="form-control" id="txtPassword" type="password" name="pass" placeholder="Password" runat="server">
                        </div>
                        <div class="form-group" >
                            <asp:Button ID="btnLogin" class="btn btn-primary btn-lg btn-block login-btn" runat="server" Text="Login" OnClick="btnLogin_Click" />&nbsp;&nbsp;
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <a href="#">Forgot Password?</a>
                </div>
            </div>
        </div>
    </div>

    <div class="container" style="height: 500px; margin-top: 100px">
        <div class="row">
            <div class="col-md-6 col-sm-6 col-lg-6">
                <div id="myCarousel" class="carousel slide" data-ride="carousel" style="height: 500px; margin-top: 100px">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="templatecss/images/ICD LONI RTG.jpg" alt="Los Angeles" style="width: 100%; height: 500px;">
                        </div>

                        <div class="item">
                            <img src="templatecss/images/IMG_20180517_123829.jpg" alt="Chicago" style="width: 100%;">
                        </div>

                        <div class="item">
                            <img src="templatecss/images/SAHIBABAD I.jpg" alt="New york" style="width: 100%;">
                        </div>
                    </div>

                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>

            <div class="col-md-6 col-sm-6 col-lg-6">

               <%-- <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 wow fadeInUp" data-wow-delay="0.6s">
                        <h3>100 Days</h3>
                        <hr>
                        <canvas id="Canvas1" class="alert-success"></canvas>

                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 wow fadeInUp" data-wow-delay="0.9s">
                        <h3>1-Year(15 August 2019-2020)</h3>
                        <hr>
                        <canvas id="Canvas2" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 wow fadeInUp" data-wow-delay="1s">
                        <h3>2-Year(15 August 2020-2021)</h3>
                        <hr>
                        <canvas id="Canvas3" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 wow fadeInUp" data-wow-delay="1s">
                        <h3>3-Year(15 August 2021-2022)</h3>
                        <hr>
                        <canvas id="Canvas3" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 wow fadeInUp" data-wow-delay="1s">
                        <h3>3-Year(15 August 2022-2023)</h3>
                        <hr>
                        <canvas id="Canvas5" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 wow fadeInUp" data-wow-delay="1s">
                        <h3>5-Year(15 August 2023-2024)</h3>
                        <hr>
                        <canvas id="Canvas6" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                    </div>
                </div>--%>
            </div>

        </div>
    </div>

    <!-- work section -->
    <section id="work">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="section-title">
                        <h1 class="heading bold">WHAT WE DO</h1>
                        <hr>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="0.6s">
                    <%--<i class="icon-cloud medium-icon"></i>--%>
                    <h3>100 Days</h3>
                    <hr>
                    <canvas id="SpeedoGas" class="alert-success" style="width: 300px; height: 200px;"></canvas>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="0.9s">
                    <%--	<i class="icon-mobile medium-icon"></i>--%>
                    <h3>1-Year(15 August 2019-2020)</h3>
                    <hr>
                    <canvas id="SpeedoFirstYear" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-laptop medium-icon"></i>--%>
                    <h3>2-Year(15 August 2020-2021)</h3>
                    <hr>
                    <canvas id="SpeedoSecondYear" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-compass medium-icon"></i>--%>
                    <h3>3-Year(15 August 2021-2022)</h3>
                    <hr>
                    <canvas id="SpeedoThirdYear" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-chat medium-icon"></i>--%>
                    <h3>4-Year(15 August 2022-2023)</h3>
                    <hr>
                    <canvas id="SpeedoFourYear" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-browser medium-icon"></i>--%>
                    <h3>5-Year(15 August 2023-2024)</h3>
                    <hr>
                    <canvas id="SpeedoFifthYear" class="alert-success" style="width: 300px; height: 200px;"></canvas>
                </div>
            </div>
        </div>
    </section>

    <!-- about section -->
    <section id="about" runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 text-center">
                    <div class="section-title">
                        <strong>02</strong>
                        <h1 class="heading bold">OUR AGENCY</h1>
                        <hr>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12">
                    <img src="templatecss/images/about-img.jpg" class="img-responsive" alt="about img">
                </div>
                <div class="col-md-6 col-sm-12">
                    <h3 class="bold">DIGITAL TEAM</h3>
                    <h1 class="heading bold">Best Design Agency from California</h1>
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="active"><a href="#design" aria-controls="design" role="tab" data-toggle="tab">DESIGN</a></li>
                        <li><a href="#mobile" aria-controls="mobile" role="tab" data-toggle="tab">MOBILE</a></li>
                        <li><a href="#social" aria-controls="social" role="tab" data-toggle="tab">SOCIAL</a></li>
                    </ul>
                    <!-- tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="design">
                            <p>Duis aute irure dolor in <a href="#">reprehenderit</a> in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Sed id est tincidunt, iaculis nulla vel, sodales metus. Morbi interdum accumsan augue, in accumsan neque lacinia sed. Fusce cursus eu ligula ut gravida.</p>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet. Dolore magna aliquam erat volutpat.</p>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="mobile">
                            <p>Aenean commodo ligula eget dolor. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                            <p><a href="#">Duis aute irure dolor</a> in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet.</p>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="social">
                            <p>Pellentesque elementum, lacus sit amet <a href="#">hendrerit</a> posuere, quam quam tristique nisi, nec ornare ligula magna id nisl. Donec blandit enim ac semper facilisis. Curabitur eu laoreet mauris, eget fermentum velit.</p>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet. Dolore magna aliquam erat volutpat.</p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- team section -->
    <section id="team" runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="section-title">
                        <strong>03</strong>
                        <h1 class="heading bold">TALENTED TEAM</h1>
                        <hr>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 wow fadeIn" data-wow-delay="0.9s">
                    <div class="team-wrapper">
                        <img src="templatecss/images/team1.jpg" class="img-responsive" alt="team img">
                        <div class="team-des">
                            <h4>Cindy</h4>
                            <h3>Senior Designer</h3>
                            <hr>
                            <ul class="social-icon">
                                <li><a href="#" class="fa fa-facebook wow fadeIn" data-wow-delay="0.3s"></a></li>
                                <li><a href="#" class="fa fa-twitter wow fadeIn" data-wow-delay="0.6s"></a></li>
                                <li><a href="#" class="fa fa-dribbble wow fadeIn" data-wow-delay="0.9s"></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 wow fadeIn" data-wow-delay="1.3s">
                    <div class="team-wrapper">
                        <img src="templatecss/images/team2.jpg" class="img-responsive" alt="team img">
                        <div class="team-des">
                            <h4>Mary</h4>
                            <h3>Core Developer</h3>
                            <hr>
                            <ul class="social-icon">
                                <li><a href="#" class="fa fa-facebook wow fadeIn" data-wow-delay="0.3s"></a></li>
                                <li><a href="#" class="fa fa-twitter wow fadeIn" data-wow-delay="0.6s"></a></li>
                                <li><a href="#" class="fa fa-dribbble wow fadeIn" data-wow-delay="0.9s"></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 wow fadeIn" data-wow-delay="1.6s">
                    <div class="team-wrapper">
                        <img src="templatecss/images/team3.jpg" class="img-responsive" alt="team img">
                        <div class="team-des">
                            <h4>Linda</h4>
                            <h3>Manager</h3>
                            <hr>
                            <ul class="social-icon">
                                <li><a href="#" class="fa fa-facebook wow fadeIn" data-wow-delay="0.3s"></a></li>
                                <li><a href="#" class="fa fa-twitter wow fadeIn" data-wow-delay="0.6s"></a></li>
                                <li><a href="#" class="fa fa-dribbble wow fadeIn" data-wow-delay="0.9s"></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 wow fadeIn" data-wow-delay="1.6s">
                    <div class="team-wrapper">
                        <img src="templatecss/images/team4.jpg" class="img-responsive" alt="team img">
                        <div class="team-des">
                            <h4>Sandar</h4>
                            <h3>Accountant</h3>
                            <hr>
                            <ul class="social-icon">
                                <li><a href="#" class="fa fa-facebook wow fadeIn" data-wow-delay="0.3s"></a></li>
                                <li><a href="#" class="fa fa-twitter wow fadeIn" data-wow-delay="0.6s"></a></li>
                                <li><a href="#" class="fa fa-dribbble wow fadeIn" data-wow-delay="0.9s"></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- portfolio section -->
    <div id="portfolio" runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="section-title">
                        <strong>04</strong>
                        <h1 class="heading bold">OUR PORTFOLIO</h1>
                        <hr>
                    </div>
                    <!-- ISO section -->
                    <div class="iso-section">
                        <ul class="filter-wrapper clearfix">
                            <li><a href="#" data-filter="*" class="selected opc-main-bg">All</a></li>
                            <li><a href="#" class="opc-main-bg" data-filter=".html">HTML</a></li>
                            <li><a href="#" class="opc-main-bg" data-filter=".photoshop">Photoshop</a></li>
                            <li><a href="#" class="opc-main-bg" data-filter=".wordpress">Wordpress</a></li>
                            <li><a href="#" class="opc-main-bg" data-filter=".mobile">Mobile</a></li>
                        </ul>
                        <div class="iso-box-section wow fadeIn" data-wow-delay="0.9s">
                            <div class="iso-box-wrapper col4-iso-box">

                                <div class="iso-box html wordpress mobile col-lg-4 col-md-4 col-sm-6">
                                    <a href="templatecss/images/portfolio-img1.jpg" data-lightbox-gallery="portfolio-gallery">
                                        <img src="templatecss/images/portfolio-img1.jpg" alt="portfolio img"></a>
                                </div>

                                <div class="iso-box wordpress col-lg-4 col-md-4 col-sm-6">
                                    <a href="templatecss/images/portfolio-img2.jpg" data-lightbox-gallery="portfolio-gallery">
                                        <img src="templatecss/images/portfolio-img2.jpg" alt="portfolio img"></a>
                                </div>

                                <div class="iso-box html mobile col-lg-4 col-md-4 col-sm-6">
                                    <a href="templatecss/images/portfolio-img3.jpg" data-lightbox-gallery="portfolio-gallery">
                                        <img src="templatecss/images/portfolio-img3.jpg" alt="portfolio img"></a>
                                </div>

                                <div class="iso-box wordpress col-lg-4 col-md-4 col-sm-6">
                                    <a href="templatecss/images/portfolio-img4.jpg" data-lightbox-gallery="portfolio-gallery">
                                        <img src="templatecss/images/portfolio-img4.jpg" alt="portfolio img"></a>
                                </div>

                                <div class="iso-box html photoshop col-lg-4 col-md-4 col-sm-6">
                                    <a href="templatecss/images/portfolio-img5.jpg" data-lightbox-gallery="portfolio-gallery">
                                        <img src="templatecss/images/portfolio-img5.jpg" alt="portfolio img"></a>
                                </div>

                                <div class="iso-box photoshop col-lg-4 col-md-4 col-sm-6">
                                    <a href="templatecss/images/portfolio-img6.jpg" data-lightbox-gallery="portfolio-gallery">
                                        <img src="templatecss/images/portfolio-img6.jpg" alt="portfolio img"></a>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- pricing section -->
    <section id="pricing" runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 text-center">
                    <div class="section-title">
                        <strong>05</strong>
                        <h1 class="heading bold">OUR PRICING</h1>
                        <hr>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="plan plan-one wow bounceIn" data-wow-delay="0.3s">
                        <div class="plan_title">
                            <i class="icon-mobile medium-icon"></i>
                            <h3>BASIC</h3>
                            <h2>$150 <span>per year</span></h2>
                        </div>
                        <ul>
                            <li>100 GB Cloud Storage</li>
                            <li>5 Pro Websites</li>
                            <li>10 Secured Emails</li>
                            <li>24-hour Support</li>
                        </ul>
                        <button class="btn btn-warning">Get it now</button>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="plan plan-two wow bounceIn" data-wow-delay="0.3s">
                        <div class="plan_title">
                            <i class="icon-desktop medium-icon"></i>
                            <h3>BUSINESS</h3>
                            <h2>$260 <span>per year</span></h2>
                        </div>
                        <ul>
                            <li>200 GB Cloud Storage</li>
                            <li>10 Pro Websites</li>
                            <li>20 Secured Emails</li>
                            <li>30-Minute Support</li>
                        </ul>
                        <button class="btn btn-warning">Take this!</button>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="plan plan-three wow bounceIn" data-wow-delay="0.3s">
                        <div class="plan_title">
                            <i class="icon-cloud medium-icon"></i>
                            <h3>PROFESSIONAL</h3>
                            <h2>$380 <span>per year</span></h2>
                        </div>
                        <ul>
                            <li>500 GB Cloud Storage</li>
                            <li>20 Pro Websites</li>
                            <li>40 Secured Emails</li>
                            <li>Live Support</li>
                        </ul>
                        <button class="btn btn-warning">Buy Now</button>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- contact section -->
    <section id="contact" runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 text-center">
                    <div class="section-title">
                        <strong>06</strong>
                        <h1 class="heading bold">CONTACT US</h1>
                        <hr>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 contact-info">
                    <h2 class="heading bold">CONTACT INFO</h2>
                    <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteu sunt in culpa qui officia deserunt mollit anim id.</p>
                    <div class="col-md-6 col-sm-4">
                        <h3><i class="icon-envelope medium-icon wow bounceIn" data-wow-delay="0.6s"></i>EMAIL</h3>
                        <p>hello@company.com</p>
                    </div>
                    <div class="col-md-6 col-sm-4">
                        <h3><i class="icon-phone medium-icon wow bounceIn" data-wow-delay="0.6s"></i>PHONES</h3>
                        <p>010-020-0340 | 090-080-0760</p>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12">
                    <form action="#" method="get" class="wow fadeInUp" data-wow-delay="0.6s">
                        <div class="col-md-6 col-sm-6">
                            <input type="text" class="form-control" placeholder="Name" name="name">
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <input type="email" class="form-control" placeholder="Email" name="email">
                        </div>
                        <div class="col-md-12 col-sm-12">
                            <textarea class="form-control" placeholder="Message" rows="7" name="message"></textarea>
                        </div>
                        <div class="col-md-offset-4 col-md-8 col-sm-offset-4 col-sm-8">
                            <input type="submit" class="form-control" value="SEND MESSAGE">
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>

    <!-- footer section -->
    <footer id="Footer1" runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <p>Copyright © Digital Team HTML5 Template | Design: <a href="http://www.tooplate.com" target="_parent">Tooplate</a></p>
                    <hr>
                    <ul class="social-icon">
                        <li><a href="#" class="fa fa-facebook wow fadeIn" data-wow-delay="0.3s"></a></li>
                        <li><a href="#" class="fa fa-twitter wow fadeIn" data-wow-delay="0.6s"></a></li>
                        <li><a href="#" class="fa fa-dribbble wow fadeIn" data-wow-delay="0.9s"></a></li>
                        <li><a href="#" class="fa fa-behance wow fadeIn" data-wow-delay="0.9s"></a></li>
                        <li><a href="#" class="fa fa-tumblr wow fadeIn" data-wow-delay="0.9s"></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </footer>


    <script src="templatecss/js/jquery.js"></script>
    <script src="templatecss/js/bootstrap.min.js"></script>
    <script src="templatecss/js/smoothscroll.js"></script>
    <script src="templatecss/js/isotope.js"></script>
    <script src="templatecss/js/imagesloaded.min.js"></script>
    <script src="templatecss/js/nivo-lightbox.min.js"></script>
    <script src="templatecss/js/jquery.backstretch.min.js"></script>
    <script src="templatecss/js/wow.min.js"></script>
    <script src="templatecss/js/custom.js"></script>

</body>
</html>
