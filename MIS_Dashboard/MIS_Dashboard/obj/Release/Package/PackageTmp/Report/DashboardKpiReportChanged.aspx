<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardKpiReportChanged.aspx.cs" Inherits="MIS_Dashboard.Report.DashboardKpiReportChanged" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MIS Dashboard</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%-- <link href="menu_source/styles.css" rel="stylesheet" />
  <link href="bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.13/css/all.css" />

    <link href="bootstrap-4.3.1-dist/css/main.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap-4.3.1-dist/css/style.css" rel="stylesheet" />
    <link href="bootstrap-4.3.1-dist/css/Grid.css" rel="stylesheet" />
    <link href="bootstrap-4.3.1-dist/css/style2.css" rel="stylesheet" />
    <link href="bootstrap-4.3.1-dist/css/GridView.css" rel="stylesheet" />
    <script src="bootstrap-4.3.1-dist/js/jquery.js"></script>--%>

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/menu.css" />
    <link rel="stylesheet" type="text/css" href="Content/menu.css" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.13/css/all.css" />




    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.4/css/buttons.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.4/css/buttons.jqueryui.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.13/css/dataTables.jqueryui.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.4/js/buttons.colVis.min.js"></script>
    <script src="../JS/Speedometer.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#grdvUser').DataTable({

                buttons: [
                                {
                                    extend: 'copyHtml5',
                                    exportOptions: {
                                        columns: ':not(:last-child)',
                                        modifier: {
                                            selected: true
                                        }
                                    }
                                },
                                {
                                    extend: 'excelHtml5',
                                    // text: '<i class="fa fa-file-excel-o" style="font-size:17px;"></i>',
                                    //  text: 'Print current page',
                                    autoPrint: false,
                                    orientation: 'landscape',
                                    titleAttr: 'Export to Excel',
                                    title: 'Action list',
                                    exportOptions: {
                                        modifier: {
                                            selected: true,
                                            page: 'current'
                                        }
                                    }
                                },
                              //{
                              //    extend: 'pdfHtml5',
                              //    // text: '<i class="fa fa-file-pdf-o style="font-size:23px;"></i>',
                              //    //  text: 'Print current page',
                              //    autoPrint: false,
                              //    orientation: 'landscape',
                              //    text: 'pdf',
                              //    titleAttr: 'Export to PDF',
                              //    title: 'Action list',
                              //    exportOptions: {
                              //        modifier: {
                              //            selected: true,
                              //            page: 'current',
                              //            pageSize: 'A0',
                              //            alignment: 'center',
                              //        }
                              //    }
                              //},
                                'colvis'
                ],
                //   columns: ['All'   ],
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                bJQueryUI: true,
                bAutoWidth: false,
                "bProcessing": true,
                "bScrollAutoCss": true,
                "sPaginationType": "full_numbers",
                "bRetrieve": true,
                "fnInitComplete": function () {
                    this.css("visibility", "visible");
                },
                "sScrollXInner": "150%",
                "bScrollCollapse": true,

                sDom: 'BT<"clear"><"H"lfr>t<"F"ip>'
            });

            $('#GridView1').DataTable({

                buttons: [
                                {
                                    extend: 'copyHtml5',
                                    exportOptions: {
                                        columns: ':not(:last-child)',
                                        modifier: {
                                            selected: true
                                        }
                                    }
                                },
                                {
                                    extend: 'excelHtml5',
                                    // text: '<i class="fa fa-file-excel-o" style="font-size:17px;"></i>',
                                    //  text: 'Print current page',
                                    autoPrint: false,
                                    orientation: 'landscape',
                                    titleAttr: 'Export to Excel',
                                    title: 'Action list',
                                    exportOptions: {
                                        modifier: {
                                            selected: true,
                                            page: 'current'
                                        }
                                    }
                                },
                              //{
                              //    extend: 'pdfHtml5',
                              //    // text: '<i class="fa fa-file-pdf-o style="font-size:23px;"></i>',
                              //    //  text: 'Print current page',
                              //    autoPrint: false,
                              //    orientation: 'landscape',
                              //    text: 'pdf',
                              //    titleAttr: 'Export to PDF',
                              //    title: 'Action list',
                              //    exportOptions: {
                              //        modifier: {
                              //            selected: true,
                              //            page: 'current',
                              //            pageSize: 'A0',
                              //            alignment: 'center',
                              //        }
                              //    }
                              //},
                                'colvis'
                ],
                //   columns: ['All'   ],
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                bJQueryUI: true,
                bAutoWidth: false,
                "bProcessing": true,
                "bScrollAutoCss": true,
                "sPaginationType": "full_numbers",
                "bRetrieve": true,
                "fnInitComplete": function () {
                    this.css("visibility", "visible");
                },
                "sScrollXInner": "150%",
                "bScrollCollapse": true,

                sDom: 'BT<"clear"><"H"lfr>t<"F"ip>'
            });
        });

    </script>

    <script>

        function isNumberKey(evt) {
            var ele = document.getElementsByTagName('status2');

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>

    <%-- Speedo Meter Start--%>
    <script>
        var totalUnits = 0;

        //ready function start
        //$(document).ready(function () {

        //    /*Production Data Start Using Speedo Meter */
        //    var kpivalue = $('#lblkpi').val();
        //    var division = $('#lbldivision').val();

        //    getspeedoMeterStatus(kpivalue, division);
        //    /*Production Data End Using Speedo Meter*/


        //});


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
            var planned = 0;
            var actual = 0;
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
                        planned = resp.data[i].PLANNED_VALUE;
                        initiativetext = resp.data[i].INITIATIVE;
                    }
                    else if (resp.data[i].name == "1") {
                        actual = resp.data[i].PLANNED_VALUE;
                    }
                }
                console.log(planned);
                console.log(actual);

                maxGas = planned / 5;

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

                var target = document.getElementById('SpeedoGas'); // your canvas element
                var gauge = new Gauge(target).setOptions(opts); // create sexy gauge!
                gauge.maxValue = planned; // set max gauge value
                gauge.setMinValue(0);  // Prefer setter over gauge.minValue = 0
                gauge.animationSpeed = 10; // set animation speed (32 is default value)
                gauge.set(actual); // set actual value

                $("#actual").text(parseInt(actual));
                $("#Plan").text(parseInt(planned));
                $("#lblinitiative").text(initiativetext);


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

        function getspeedoMeterStatus(kpivalue, division, initiativerecno) {
            //var kpivalue = $('#lblkpi').text();
            //var division = $('#lbldivision').text();

            totalUnits = 0;

            ajaxReq('../DefaultHandler.ashx',
                       'getSpeedoMeterStatusForKpi',
          {
              "kpivalue": kpivalue,
              "division": division,
              "initiativerecno": initiativerecno
          },
           function (resp) {
               showcumlativeData(resp)
           }, true);
        }


    </script>
    <%-- Speedp Meter End--%>
</head>
<body onload="window.history.forward(-1)">
    <script>
        var myVar = setInterval(function () { myTimer() }, 1000);

        function myTimer() {
            var d = new Date(),
                minutes = d.getMinutes().toString().length == 1 ? '0' + d.getMinutes() : d.getMinutes(),
                hours = d.getHours().toString().length == 1 ? '0' + d.getHours() : d.getHours(),
                ampm = d.getHours() >= 12 ? 'PM' : 'AM',
                months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

            document.getElementById("lblTime").innerHTML = days[d.getDay()] + ' ' + months[d.getMonth()] + ' ' + d.getDate() + ' ' + d.getFullYear() + ' ' + hours + ':' + minutes + ampm;

        }
    </script>
    <form id="form1" runat="server" autocomplete="off">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="container-fluid" style="background-color: #fff; color: #000;">
                <div class="row" style="border-bottom: thin">
                    <div class="col-lg-3">
                        <a href="#" target="_blank">
                            <img class="img-responsive" src="logo.png" style="margin-top: 5px; height: 70px;" /></a>
                    </div>

                    <div class="col-lg-7 text-center">
                        <h1 style="margin-top: 30px; color: #006e2e;">Action Planned Dashboard</h1>
                    </div>
                    <div class="col-lg-2" style="float: right;">
                        <br />
                        <b>Welcome :</b>
                        <asp:Label ID="lblUsernameDisplay" Text="Administrator" Style="margin-top: 8px; height: 20px; font-family: Verdana; font-size: 12px; color: green;"
                            runat="server"></asp:Label>
                        <asp:Label ID="lblDate" runat="server" Font-Bold="True" Style="margin-top: 8px; height: 20px; font-family: Verdana; font-size: 12px; color: black;"></asp:Label><br />
                        <asp:Label ID="lblTime" runat="server" Font-Bold="True" Style="margin-top: 8px; height: 20px; font-family: Verdana; font-size: 12px; color: black;"></asp:Label>
                    </div>
                </div>
                <div class="row" style="height: 10px;"></div>
            </div>

            <%------------------------------------Top Header End------------------------------%>


            <%------------------------------------Header End------------------------------%>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">

                        <%--<div class="panel panel-info">
                            <div class="panel-heading">
                                <h3 class="panel-title" align="center"><b></b></h3>
                                <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
                                <div class="pull-right" style="margin-top: -23px; height: 18px;">
                                    <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-danger" runat="server" OnClientClick="javascript:window.close()" formnovalidate />
                                </div>
                            </div>
                        </div>--%>

                        <%--<div id="DivSpeedoMeter" runat="server" align="center">
                            <div class="panel panel-info" style="width: 500px;">
                                <div class="panel-body" style="width: 500px;">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12">
                                            <canvas id="SpeedoGas" class="alert-success"></canvas>

                                            <div>
                                                <label style="color: seagreen">Planned:</label><span id="Plan" style="color: blueviolet"></span>
                                                <label style="color: blueviolet">Units</label>
                                            </div>
                                            <div>
                                                <label style="color: seagreen">Actual:</label><span id="actual" style="color: blueviolet"> </span>
                                                <label style="color: blueviolet">Units</label>
                                            </div>
                                            <div>
                                                <label for="lblInitiative" style="color: seagreen" id="lblInitiative"></label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>--%>


                        <div id="divGirdShow" runat="server">

                            <div class="panel panel-info">
                                <%--<div class="panel-heading" align="center">
                                    <h4 class="panel-title" id="divheading" runat="server"><b>Report</b></h4>
                                </div>--%>


                                <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-danger pull-right" runat="server" OnClientClick="javascript:window.close()" formnovalidate />
                                <div class="row">
                                    <div class="col-md-12" align="center">
                                        <asp:Label ID="lblInfo" Text="" align="center" runat="server" Style="font: bold;" />
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3"></div>
                                        <div class="col-lg-3 col-md-3 col-sm-3">
                                            <canvas id="SpeedoGas" style="width: 400px;"></canvas>
                                            <%--class="alert-success"--%>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3" style="margin-left: 200px; margin-top: 50px">
                                            <div id="Div1" runat="server">
                                                <div>
                                                    <label style="color: seagreen">Planned:</label><span id="Plan" style="color: blueviolet"></span>
                                                    <label style="color: blueviolet">Units</label>
                                                </div>
                                                <div>
                                                    <label style="color: seagreen">Actual:</label><span id="actual" style="color: blueviolet"> </span>
                                                    <label style="color: blueviolet">Units</label>
                                                </div>
                                                <div>
                                                    <label style="color: seagreen">Initiative:</label><span id="lblinitiative" style="color: blueviolet"> </span>

                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="panel-body">

                                    <div class="table-responsive ">
                                        <div class="col-xs-12 col-sm-12 col-md-12">
                                            <div class="panel-group">
                                                <asp:GridView ID="grdvUser" runat="server" OnPreRender="grdvUser_PreRender" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found" AutoGenerateColumns="false" GridLines="None" HeaderStyle-Wrap="true"
                                                    Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display"
                                                    OnRowDataBound="grdvUser_RowDataBound" OnRowCreated="grdvUser_RowCreated">
                                                    <%--<Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="5px" />
                                                        </asp:TemplateField>

                                                        
                                                    </Columns>--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No." HeaderStyle-Width="20px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="5px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Division" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("Division") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="250px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Progress Date" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProgressDate" runat="server" Text='<%#Eval("Process Date") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="250px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Initiative" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInitiative" runat="server" Text='<%#Eval("Initiative") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="250px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Scheme/ program, if any" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblScheme" runat="server" Text='<%#Eval("Scheme/ program, if any") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="50px" CssClass="text-justify" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Requires changes in law (Yes/No)" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblChanges" runat="server" Text='<%#Eval("Requires") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="100px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Parameter (s)" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtParameter" runat="server" Text='<%#Eval("Parameter") %>'></asp:Label><br />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="100px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Unit" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="ddlUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label>
                                                                <%--<asp:DropDownList ID="ddlUnit" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="50" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="In 100 days (Planned)" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtIn100DaysPlanned" runat="server" Text='<%#Eval("NAME12") %>'></asp:Label><br />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="150px" />
                                                        </asp:TemplateField>

                                                        <%--<asp:TemplateField HeaderText="In 100 days (Actual)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtIn100Days" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txtIn100DaysRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>--%>

                                                        <%--    <asp:TemplateField HeaderText="15 Aug. 2022">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt15August" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt15AugustRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="1-year(2019-20)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt1year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt1yearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="2-year(2020-21)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt2Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt2YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="3-year(2021-22)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt3Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt3YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="4-year(2022-23)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt4Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt4YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="5-year(2022-24)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt5Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt5YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="GridView1" runat="server" OnPreRender="GridView1_PreRender" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found" AutoGenerateColumns="false" GridLines="None" HeaderStyle-Wrap="true"
                                                    Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display"
                                                    OnRowDataBound="GridView1_RowDataBound" >
                                                    <%--<Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="5px" />
                                                        </asp:TemplateField>

                                                        
                                                    </Columns>--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No." HeaderStyle-Width="20px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="5px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Division" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("Division") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="250px" />
                                                        </asp:TemplateField>

                                                       
                                                        <asp:TemplateField HeaderText="Initiative" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInitiative" runat="server" Text='<%#Eval("Initiative") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="250px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Scheme/ program, if any" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblScheme" runat="server" Text='<%#Eval("Scheme/ program, if any") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="50px" CssClass="text-justify" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Requires changes in law (Yes/No)" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblChanges" runat="server" Text='<%#Eval("Requires") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="100px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Parameter (s)" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtParameter" runat="server" Text='<%#Eval("Parameter") %>'></asp:Label><br />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="100px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Unit" HeaderStyle-Width="200px" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="ddlUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label>
                                                                <%--<asp:DropDownList ID="ddlUnit" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="50" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="In 100 days (Planned)" HeaderStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtIn100DaysPlanned" runat="server" Text='<%#Eval("NAME12") %>'></asp:Label><br />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-justify" Width="150px" />
                                                        </asp:TemplateField>

                                                        <%--<asp:TemplateField HeaderText="In 100 days (Actual)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtIn100Days" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txtIn100DaysRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>--%>

                                                        <%--    <asp:TemplateField HeaderText="15 Aug. 2022">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt15August" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt15AugustRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="1-year(2019-20)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt1year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt1yearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="2-year(2020-21)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt2Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt2YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="3-year(2021-22)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt3Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt3YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="4-year(2022-23)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt4Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt4YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="5-year(2022-24)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt5Year" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txt5YearRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--For Show Messages--%>
                                <div class="modal fade" id="MsgBox" tabindex="-1" role="dialog" aria-labelledby="purchaseLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header btn-danger">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4><i id="Icon" class="glyphicon glyphicon-thumbs-up">&nbsp;</i><span class="modal-title" id="ShowTitle"></span></h4>
                                            </div>
                                            <div class="modal-body" id="ShowBody">
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" id="modalbtn" class="btn" data-dismiss="modal">Close</button>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <button type="button" style="display: none" id="btnShowPopup" class="btn btn-lg"
                                    data-toggle="modal" data-target="#MsgBox">
                                    Launch modal
                                </button>

                                <%--End--%>
                            </div>

                        </div>



                        <div id="divSubmition" runat="server" visible="false">
                            <div class="row" align="center" style="text-align: center">
                                <div class="col-md-12">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <%------------------------------------Footer Start------------------------------%>
           <%-- <div class="container-fluid">
                <div class="row" style="height: 40px;">
                    <div class="col-lg-12" style="background-color: #45484d; left: 0; position: relative; bottom: 0; right: 0; height: 40px;">
                        <p style="color: #fff; margin-top: 10px;" class="text-center">Copyright 2019 © VCS Pvt. Ltd.</p>
                    </div>
                </div>
            </div>--%>
            <%------------------------------------Footer End------------------------------%>
        </div>
        <%--  <div class="panel-footer">Powered by Vedang</div>--%>
    </form>
</body>
</html>
