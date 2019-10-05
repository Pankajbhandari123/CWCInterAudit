<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MIS_Dashboard.HomePage" %>

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
    
    <script>

        $(function () {
            $("img[scr = 'templatecss/images/ICD LONI RTG.jpg']").attr('height', 800);
            $("img[scr = 'templatecss/images/IMG_20180517_123829.jpg']").attr('height', 900);
            $("img[scr = 'templatecss/images/SAHIBABAD I.jpg']").attr('height', 900);
        })
    </script>
   

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

    <style>
        .myModal
        {
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            display: block;
            z-index: 999;
        }

        .myModal-body
        {
            margin-top: 30px;
            margin-left: auto;
            margin-right: auto;
            width: 600px;
            min-height: 20px;
        }

        .container12
        {
            position: absolute;
            right: 0;
            margin: 20px;
            max-width: 300px;
            padding: 16px;
            background-color: white;
        }
    </style>
    <%-- Speedp Meter End--%>

    <script type="text/javascript">
        $(function () {
            //Normal Configuration
            $("[id*=txtUName]").MaxLength({ MaxLength: 30 });
            $("[id*=txtPwd]").MaxLength({ MaxLength: 40 });
            $("[id*=txtCaptcha]").MaxLength({ MaxLength: 6 });
        });
    </script>

</head>
<body id="divbody" data-spy="scroll" data-target=".navbar-collapse" data-offset="50">

    <!-- preloader section -->
    <div class="preloader">
        <div class="sk-spinner sk-spinner-circle">
            <div class="sk-circle1 sk-circle"></div>
            <div class="sk-circle2 sk-circle"></div>
            <div class="sk-circle3 sk-circle"></div>
            <div class="sk-circle4 sk-circle"></div>
            <div class="sk-circle5 sk-circle"></div>
            <div class="sk-circle6 sk-circle"></div>
            <div class="sk-circle7 sk-circle"></div>
            <div class="sk-circle8 sk-circle"></div>
            <div class="sk-circle9 sk-circle"></div>
            <div class="sk-circle10 sk-circle"></div>
            <div class="sk-circle11 sk-circle"></div>
            <div class="sk-circle12 sk-circle"></div>
        </div>
    </div>

    <!-- navigation section -->
    <section class="navbar navbar-fixed-top custom-navbar" role="navigation" style="background-color: #0aab8a; color: #000;">
        <%----%>
        <div class="container">

            <div class="navbar-header">
                <a href="#" target="_blank">
                    <img class="img-responsive" src="cwc_logo.png" style="margin-top: 5px; height: 50px;" /></a>
            </div>

            <div class="collapse navbar-collapse">
                <ul class="nav navbar-nav navbar-right">
                    <h3><span class="smoothScroll" style="color: #fff">CWC Performance Dashboard</span></h3>
                    <%-- <li><a href="#home" class="smoothScroll">HOME</a></li>--%>
                    <%-- <li><a href="#work" class="smoothScroll">Dasboard</a></li>--%>
                    <%--	<li><a href="#about" class="smoothScroll">ABOUT</a></li>
				<li><a href="#team" class="smoothScroll">TEAM</a></li>
				<li><a href="#portfolio" class="smoothScroll">PORTFOLIO</a></li>
				<li><a href="#pricing" class="smoothScroll">PRICING</a></li>
                    <li><a href="Login.aspx" class="smoothScroll">Login</a></li>--%>
                    <%-- <li><a href="#myModal" data-toggle="modal" data-target="#myModal" class="smoothScroll"><b>Login</b></a></li>--%>
                </ul>
            </div>
        </div>
    </section>


    <!-- home section -->
    <section id="home" runat="server" visible="true" >
        <div id="myModal" runat="server" style="margin-left: 900px;">
            <div class="modal-dialog modal-login" style="background-color: aqua;">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="avatar">
                            <img src="logo1.png" alt="CWC">
                        </div>
                        <h4 class="modal-title">Login</h4>
                        <%--<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>--%>
                    </div>
                    <div id="Div1" class="modal-body" runat="server">
                        <form id="Form1" runat="server">
                            <div class="form-group">
                                <input class="form-control" id="txtUsername" type="text" name="username" placeholder="Username" runat="server">
                                <asp:RequiredFieldValidator ID="require" ErrorMessage="Please Fill Out Username"  ForeColor="Red" ControlToValidate="txtUsername" runat="server" />
                            </div>
                            <div class="form-group">
                                <input class="form-control" id="txtPassword" type="password" name="pass" placeholder="Password" runat="server">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Fill Out Password"  ForeColor="Red" ControlToValidate="txtPassword" runat="server" />
                            </div>
                            <div class="row">
                                <%--<div class="col-md-12 col-lg-12">--%>
                                <div class="col-md-3 col-lg-3" align="right">
                                    <asp:Image ID="imgCaptcha" runat="server" Width="100" Height="30" />
                                </div>
                                <div class="col-md-1 col-lg-1">
                                </div>
                                <div class="col-md-1 col-lg-1">
                                    <asp:ImageButton ID="ImgBtnRefresh" runat="server" ImageUrl="images/refresh.png" OnClick="ImgBtnRefresh_Click" />
                                </div>
                                <%-- <div class="col-md-5 col-lg-5" align="right">
                                        <h5><span style="color: red;">*</span>Enter&nbsp;Captca&nbsp;Code&nbsp;</h5>
                                    </div>--%>
                                <div class="col-md-1 col-lg-1">
                                    <span style="color: red;">*</span>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <asp:TextBox ID="txtCaptcha" runat="server" PlaceHolder="Enter Captca" CssClass="form-control input-sm" Width="100px"> 
                                    </asp:TextBox><asp:Label ID="lblCaptcha" runat="server" Text=""></asp:Label>
                                </div>
                                <%-- </div>--%>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnLogin" class="btn btn-primary btn-lg btn-block login-btn" runat="server" Text="Login" OnClick="btnLogin_Click" />&nbsp;&nbsp;
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                    <%--    <a href="#forgetModal" data-toggle="modal" data-target="#forgetModal"><b>Forgot Password?</b></a>--%>
                        <a href="ForgetPassword.aspx">Forgot Password?</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- work section -->
    <section id="work" runat="server" visible="false">
        <div class="container">
            <%--<div class="row">
                <div class="col-12 col-lg-6 col-xl-3">
                    <div class="card gradient-purpink">
                        <div class="card-body">
                            <div class="media">
                                <div class="media-body text-left">
                                    <h4 class="text-white">$4530</h4>
                                    <span class="text-white">Revenue</span>
                                </div>
                                <div class="align-self-center"><span id="widget-chart-4">
                                    <canvas width="81" height="35" style="display: inline-block; width: 81px; height: 35px; vertical-align: top;"></canvas>
                                </span></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-lg-6 col-xl-3">
                    <div class="card bg-dark">
                        <div class="card-body">
                            <div class="media">
                                <div class="media-body text-left">
                                    <h4 class="text-white">2500</h4>
                                    <span class="text-white">Total Orders</span>
                                </div>
                                <div class="align-self-center"><span id="widget-chart-5">
                                    <canvas width="80" height="40" style="display: inline-block; width: 80px; height: 40px; vertical-align: top;"></canvas>
                                </span></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-lg-6 col-xl-3">
                    <div class="card gradient-ibiza">
                        <div class="card-body">
                            <div class="media">
                                <div class="media-body text-left">
                                    <h4 class="text-white">7850</h4>
                                    <span class="text-white">Comments</span>
                                </div>
                                <div class="align-self-center"><span id="widget-chart-6">
                                    <canvas width="75" height="40" style="display: inline-block; width: 75px; height: 40px; vertical-align: top;"></canvas>
                                </span></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-lg-6 col-xl-3">
                    <div class="card bg-dark">
                        <div class="card-body">
                            <div class="media">
                                <div class="media-body text-left">
                                    <h4 class="text-white">3524</h4>
                                    <span class="text-white">Total Views</span>
                                </div>
                                <div class="align-self-center"><span id="widget-chart-7">
                                    <canvas width="100" height="25" style="display: inline-block; width: 100px; height: 25px; vertical-align: top;"></canvas>
                                </span></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="row">
                <%-- <div class="col-md-12 col-sm-12">
                    <div class="section-title">
                        <h2 class="heading bold">CWC Dashboard</h2>
                        <hr>
                    </div>
                </div>--%>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="0.6s">
                    <%--<i class="icon-cloud medium-icon"></i>--%>
                    <h3>100 Days</h3>
                    <hr>
                    <canvas id="SpeedoGas" style="width: 300px; height: 200px;"></canvas>

                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="0.9s">
                    <%--	<i class="icon-mobile medium-icon"></i>--%>
                    <h3>1-Year(15 August 2019-2020)</h3>
                    <hr>
                    <canvas id="SpeedoFirstYear" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-laptop medium-icon"></i>--%>
                    <h3>2-Year(15 August 2020-2021)</h3>
                    <hr>
                    <canvas id="SpeedoSecondYear" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-compass medium-icon"></i>--%>
                    <h3>3-Year(15 August 2021-2022)</h3>
                    <hr>
                    <canvas id="SpeedoThirdYear" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-chat medium-icon"></i>--%>
                    <h3>4-Year(15 August 2022-2023)</h3>
                    <hr>
                    <canvas id="SpeedoFourYear" style="width: 300px; height: 200px;"></canvas>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="1s">
                    <%--<i class="icon-browser medium-icon"></i>--%>
                    <h3>5-Year(15 August 2023-2024)</h3>
                    <hr>
                    <canvas id="SpeedoFifthYear" style="width: 300px; height: 200px;"></canvas>
                </div>
            </div>
        </div>
    </section>

    <!-- about section -->
    

    <!-- team section -->
    

    <!-- portfolio section -->
    

    <!-- pricing section -->
    

    <!-- contact section -->
    

    <!-- footer section -->
    <footer runat="server" visible="false">
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
