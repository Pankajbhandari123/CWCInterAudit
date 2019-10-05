<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MIS_Dashboard.Default" %>

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
    <script src="JS/canvasjs.js"></script>
    <script src="JS/Dashboard.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">


    <div id="FirstKPI" runat="server">

        <div class="panel panel-info">
            <div class="panel-heading" align="center">
                <h4 class="panel-title"><b>Dashboard</b></h4>
            </div>
            <div class="panel-body">
                <div class="row ">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <div class="panel panel-info">
                            <div class="panel-heading" align="center">
                            </div>
                            <div class="panel-body">
                                <div class="row form-group">
                                    <div class="col-xs-2 col-sm-2 col-md-2">
                                        <label class="control-label" style="font-weight: 100;" for="ddlChartType"><b>Dashboard Type:</b><b class="asterik" style="color: red;">*</b></label>
                                        <div>
                                            <asp:DropDownList ID="ddlChartType" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Text="column" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="spline" Value="2" ></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-xs-2 col-sm-2 col-md-2">
                                        <label class="control-label" style="font-weight: 100;" for="ddlDivision"><b>Division:</b><b class="asterik" style="color: red;">*</b></label>
                                        <div>
                                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-xs-2 col-sm-2 col-md-2">
                                        <label class="control-label" style="font-weight: 100;" for="ddlKpiRange"><b>KPI Type:</b><b class="asterik" style="color: red;">*</b></label>
                                        <div>
                                            <asp:DropDownList ID="ddlKpiRange" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div id="chartContainer" runat="server" style="height: 350px; width: 100%; border: 1px solid lightgrey"></div>
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
            </div>

        </div>

    </div>

</asp:Content>
