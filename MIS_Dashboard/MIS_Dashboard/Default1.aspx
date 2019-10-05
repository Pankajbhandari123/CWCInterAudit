<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" ClientIDMode="Static" AutoEventWireup="true"
     CodeBehind="Default1.aspx.cs" Inherits="MIS_Dashboard.Default1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <script src="Scripts/jquery-3.3.1.min.js"></script>
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
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.bundle.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/d3/5.9.7/d3.min.js"></script>
    <link href="JS/c3.css" rel="stylesheet" />
    <script src="JS/c3.js"></script>
    <script src="JS/canvasjs.js"></script>
    <script src="JS/dashboard1.js"></script>



    <style type="text/css">
        #backButton
        {
            border-radius: 4px;
            padding: 8px;
            border: none;
            font-size: 12px;
            background-color: #2eacd1;
            color: white;
            cursor: pointer;
        }

        .invisible
        {
            display: none;
        }

        .container
        {
            position: relative;
            width: 50%;
        }


        .overlay
        {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            height: 100%;
            width: 100%;
            opacity: 0;
            transition: .5s ease;
            background-color: #008CBA;
        }

        .container:hover .overlay
        {
            opacity: 1;
        }

        .text
        {
            color: black;
            font-size: 20px;
            position: absolute;
            top: 50%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            text-align: center;
        }

        .divheight
        {
            font-size: 20px;
            height: 150px;
        }
    </style>
    <script>
        function getspeedoMeterStatus() {
            //var kpivalue = $('#lblkpi').text();
            //var division = $('#lbldivision').text();

            totalUnits = 0;

            ajaxReq('DefaultHandler.ashx',
                       'getWeekWiseCWCDashboard',
          {
          },
           function (resp) {
               showcumlativeData(resp)
           }, true);
        }

    </script>
    <%--<script>
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

        function showcumlativeData(resp)
        {
            console.log(resp);
            var days100planned;
            var actualarray = [];
            var progressDate = [];
            if (resp.status === true) {
                for (i = 0; i < resp.data.length; i++) {

                    if (resp.data[i].name == "0") {
                        days100planned = resp.data[i].PLANNED_VALUE;
                    }
                    else if (resp.data[i].name == "1") {
                        actualarray.push(resp.data[i].PLANNED_VALUE);
                        progressDate.push(resp.data[i].PROGRESS_DATE);
                    }
                }
                console.log(days100planned);
                console.log(actualarray);
                console.log(progressDate);
                for (i = 0; i < actualarray.length; i++) {

                }
                var pnl = document.getElementById("<%= find.ClientID %>");
                var container12 = $("<div>").addClass("container").appendTo(pnl);
                
               

                for (var i = 0; i < actualarray.length; i++) {
                    var blockDiv;
                    var blockDiv1;
                    var blockDiv2;
                    var blockDiv3;
                    var blockDiv4;// used in the for loop
                    var actualtext = actualarray[i];
                    var date = progressDate[i].slice(0,10);
                    blockDiv = $("<div>").addClass("block").appendTo(container12);
                    blockDiv1 = $("<div>").addClass("alert alert-info").appendTo(blockDiv);
                    $("#blockDiv1").css("font-size", "12px");
                    $("#blockDiv1").css("height", "150px");
                    blockDiv2 = $("<div>").addClass("text").appendTo(blockDiv1);
                    
                   
                    $("#blockDiv2").css("text-align", "center");
                    var $label = $("<label>").text('Planned:').appendTo(blockDiv2);
                    $('<span>').text(days100planned).appendTo(blockDiv2);
                    var $label = $("<label>").text('Actual:').appendTo(blockDiv2);
                    $('<span>').text(actualtext).appendTo(blockDiv2);


                    blockDiv3 = $("<div>").addClass("overlay").appendTo(blockDiv2);
                    blockDiv4 = $("<div>").addClass("text").appendTo(blockDiv3);
                    var $label = $("<label>").text('Planned:').appendTo(blockDiv4);
                    $('<span>').text(days100planned).appendTo(blockDiv4);
                    var $label = $("<label>").text('Actual:').appendTo(blockDiv4);
                    $('<span>').text(actualtext).appendTo(blockDiv4);
                    $('<span>').text(date).appendTo(blockDiv4);
                }
            }
                //$(".first").text(parseInt(actual));
                //$(".first").text(parseInt(planned));
                //$("#lblinitiative").text(initiativetext);


            
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



    </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">

    <div id="FirstKPI" runat="server">

        <%--<div class="panel panel-info">
            <div class="panel-heading" align="center">
                <h4 class="panel-title"><b>Dashboard</b></h4>
            </div>
            <div class="panel-body">--%>
        <div class="row ">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading" align="center">
                        <h4 class="panel-title" id="divheading" runat="server"><b></b></h4>
                        <%-- <asp:LinkButton ID="backButton"  Text="Back" CssClass="btn pull-right" style="display: none; margin-top: -23px;"></asp:LinkButton>--%>
                        <button class="btn pull-right" id="backButton" style="display: none; margin-top: -23px;">Back</button>
                    </div>
                    <div class="panel-body">
                        <%--<button class="btn pull-right" id="backButton" style="display: none">Back</button>--%>
                        <div class="row form-group">
                            <div class="col-xs-2 col-sm-2 col-md-2" id="divcharttype" style="display: none">
                                <label class="control-label" style="font-weight: 100;" for="ddlChartType"><b>Dashboard Type:</b><b class="asterik" style="color: red;">*</b></label>
                                <div>
                                    <asp:DropDownList ID="ddlChartType" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="bar" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="spline" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%-- <div class="col-xs-2 col-sm-2 col-md-2">
                                        <label class="control-label" style="font-weight: 100;" for="ddlDivision"><b>Division:</b><b class="asterik" style="color: red;">*</b></label>
                                        <div>
                                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                            <div class="col-xs-2 col-sm-2 col-md-2">
                                <label class="control-label" style="font-weight: 100;" for="ddlKpiRange"><b>KPI Type:</b><b class="asterik" style="color: red;">*</b></label>
                                <div>
                                    <asp:DropDownList ID="ddlKpiRange" runat="server" CssClass="form-control input-sm">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="row form-group" id="chartsContain" runat="server">
                            <div class="col-xs-6 col-md-6 col-sm-6" id="divoverallcwc" style="display: block;">
                                <div id="chartContainer" runat="server"></div>
                                <div id="cwcdiv" runat="server">
                                    <h6 id="cwcdiv1" runat="server" style="margin-left: -100px" align="center"><b></b></h6>
                                </div>
                            </div>
                            <div class="col-xs-6 col-md-6 col-sm-6" id="divdivsionwise" style="display: block;">
                                <div id="chartContainer1" runat="server"></div>
                                <div id="divisionDiv" runat="server">
                                    <h6 id="divisionDiv1" runat="server" style="margin-left: -100px" align="center"><b></b></h6>
                                </div>
                            </div>
                        </div>
                        <div class="row form-group" id="chartsContain2" runat="server" style="display: none;">
                            <div class="col-xs-12 col-md-12 col-sm-12">
                                <div id="chartContainer2" runat="server"></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <%--<div class="col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h2 class="panel-title"><b>Employee</b></h2>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label for="lblChartType">Project: </label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddlProject" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                &nbsp;
                                  <div class="row">
                                      <div class="col-md-2">
                                          <label for="lblChartType">Employee: </label>
                                      </div>
                                      <div class="col-md-2">
                                          <asp:DropDownList ID="ddlresource" CssClass="dropdown" runat="server"></asp:DropDownList>
                                      </div>

                                      <div class="col-xs-12 col-sm-12 col-md-3">
                                  <div class="col-xs-12 col-sm-12 col-md-3">
                                       <div class="form-group">
                                      <label for="lblChartType">Project: </label>
                                      <asp:DropDownList ID="ddlProject" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"></asp:DropDownList>
                                       </div>
                                  </div>
                                      <div class="col-xs-12 col-sm-12 col-md-3">
                                        <div class="form-group">
                                      <label for="lblChartType">Resources: </label>
                                      <asp:DropDownList ID="ddlresource" CssClass="dropdown" runat="server" OnSelectedIndexChanged="ddlresource_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                       </div>
                                  </div>
                                  </div>
                                <div class="row form-group">
                                    <div id="chartContainer1" runat="server" style="height: 300px; width: 100%; border: 1px solid lightgrey"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
        </div>
        <%--</div>

        </div>--%>
    </div>

    <div id="DivWeekWise" runat="server">
        <div class="row ">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <div class="panel panel-info">
                    <div class="panel-heading" align="center">
                        <h4 class="panel-title" id="H1" runat="server"><b>Week Wise Details</b></h4>
                        <button class="btn pull-right" id="Button1" style="display: none; margin-top: -23px;">Back</button>
                    </div>
                    <div class="panel-body">
                        <%--<div class="row form-group" id="Div3" runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12" id="find" runat="server">
                                <div class="container" id="contain">
                                    <div class="divheight">
                                    <div class="alert alert-success" id="first" >
                                      <div class="text">  <label >Planned:</label>
                                        <span>450</span>
                                        <label >Actual:</label>
                                        <span>300</span></div>
                                        <div class="overlay">
                                            <div class="text" id="firstfirst">Hello World</div>
                                        </div>
                                    </div>
                                        </div>
                                </div>

                                <div class="container" id="Div1">
                                    <div class="alert alert-success" style="font-size: 12px; height: 150px">

                                        <div class="overlay">
                                            <div class="text">Hello World</div>
                                        </div>
                                    </div>
                                </div>

                                <div class="container" id="Div2">
                                    <div class="alert alert-success" style="font-size: 12px; height: 150px">

                                        <div class="overlay">
                                            <div class="text">Hello World</div>
                                        </div>
                                    </div>
                                </div>

                                <div class="container" id="Div4">
                                    <div class="alert alert-success" style="font-size: 12px; height: 150px">

                                        <div class="overlay">
                                            <div class="text">Hello World</div>
                                        </div>
                                    </div>
                                </div>


                                <div class="container" id="Div5">
                                    <div class="alert alert-success" style="font-size: 12px; height: 150px">

                                        <div class="overlay">
                                            <div class="text">Hello World</div>
                                        </div>
                                    </div>
                                </div>


                                <div class="container" id="Div6">
                                    <div class="alert alert-info" style="font-size: 12px; height: 150px">

                                        <div class="overlay">
                                            <div class="text">Hello World</div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>--%>
                        <div class="row form-group" id="Div1" runat="server" style="display: block;">
                            <div class="col-xs-12 col-md-12 col-sm-12">
                                <div id="Div3" runat="server">
                                    <h5 id="divMsg" runat="server" style="margin-left: -120px;display: none;" align="center"><b></b></h5>
                                </div>
                            </div>
                        </div>
                        <div class="row form-group" id="WeekDiv1" runat="server">
                            <div class="col-xs-6 col-md-6 col-sm-6" id="div2" style="display: block;">
                                <div id="weekChartContainer" runat="server"></div>
                                <div id="Div4" runat="server">
                                    <h6 id="weekCWC" runat="server" style="margin-left: -100px" align="center"><b></b></h6>
                                </div>
                            </div>
                            <div class="col-xs-6 col-md-6 col-sm-6" id="div5" style="display: block;">
                                <div id="weekChartContainer1" runat="server"></div>
                                <div id="div7" runat="server">
                                    <h6 id="weekcwcDivision" runat="server" style="margin-left: -100px" align="center"><b></b></h6>
                                </div>
                            </div>
                        </div>
                        <div class="row form-group" id="Div8" runat="server" style="display: none;">
                            <div class="col-xs-12 col-md-12 col-sm-12">
                                <div id="chartContainerWeekWise" runat="server"></div>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
