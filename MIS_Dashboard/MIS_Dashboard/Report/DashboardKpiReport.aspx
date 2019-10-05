<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="DashboardKpiReport.aspx.cs" Inherits="MIS_Dashboard.Report.DashboardKpiReport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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
            console.log("Hello Im ");
            if (resp.status === true) {
                for (i = 0; i < resp.data.length; i++) {

                    if (resp.data[i].name == "0") {
                        planned = resp.data[i].PLANNED_VALUE;
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title" align="center"><b>Action Planned</b></h3>
            <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
            <div class="pull-right" style="margin-top: -23px; height: 18px;">
                <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-danger" runat="server" OnClientClick="javascript:window.close()" formnovalidate />
            </div>
        </div>
    </div>

    <div id="DivSpeedoMeter" runat="server" align="center">
        <div class="panel panel-info" style="width: 500px;">
            <%--<div class="panel-body" style="width:500px;">
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
            </div>--%>
        </div>

    </div>


    <div id="divGirdShow" runat="server" align="center">

        <div class="panel panel-info">
            <%--<div class="panel-heading">
                <h3 class="panel-title"><b></b></h3>

            </div>--%>
            <div class="panel-body" style="width: 500px;">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <canvas id="SpeedoGas" class="alert-success"></canvas>
                        <div class="alert-info" runat="server">
                            <div>
                                <label style="color: seagreen">Planned:</label><span id="Plan" style="color: blueviolet"></span>
                                <label style="color: blueviolet">Units</label>
                            </div>
                            <div>
                                <label style="color: seagreen">Actual:</label><span id="actual" style="color: blueviolet"> </span>
                                <label style="color: blueviolet">Units</label>
                            </div>
                        </div>
                        <%--<div>
                            <label for="lblInitiative" style="color: seagreen" id="lblInitiative"></label>
                        </div>--%>
                    </div>
                </div>
            </div>
            <div class="panel-body">

                <div class="table-responsive ">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <div class="panel-group">
                            <asp:GridView ID="grdvUser" runat="server" OnPreRender="grdvUser_PreRender" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found" AutoGenerateColumns="true" GridLines="None" HeaderStyle-Wrap="true"
                                Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display"
                                OnRowDataBound="grdvUser_RowDataBound" OnRowCreated="grdvUser_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="5px" />
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="Initiative">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInitiative" runat="server" Text='<%#Eval("INITIATIVE") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" Width="200px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Scheme/ program, if any">
                                            <ItemTemplate>
                                                <asp:Label ID="lblScheme" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Requires changes in law (Yes/No)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblchanges" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parameter (s)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparameter" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                              <asp:Label ID="lblunit" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" Width="50" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="In 100 days" >
                                            <ItemTemplate>
                                             <asp:Label ID="lbl100days" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="15 Aug. 2022">
                                            <ItemTemplate>
                                              <asp:Label ID="lblAug" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="1-year(2019-20)">
                                            <ItemTemplate>
                                               <asp:Label ID="lbl1year" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="2-year(2020-21)">
                                            <ItemTemplate>
                                              <asp:Label ID="lbltwoyear" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="3-year(2021-22)">
                                            <ItemTemplate>
                                              <asp:Label ID="lblthreeyear" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="4-year(2022-23)">
                                            <ItemTemplate>
                                               <asp:Label ID="lblfouryear" runat="server" Text='<%#Eval("SCHEME") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="5-year(2022-24)">
                                            <ItemTemplate>
                                              <asp:Label ID="lblfiveyear" runat="server" Text='<%#Eval("SCHEME") %>' />
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
</asp:Content>
