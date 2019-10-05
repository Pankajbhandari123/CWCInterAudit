<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ActualHistoryDetails.aspx.cs" Inherits="MIS_Dashboard.Report.ActualHistoryDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                                    title: 'Actual History Details',
                                    exportOptions: {
                                        columns: ':not(:last-child)',
                                        modifier: {
                                            selected: true,
                                            page: 'current'
                                        }
                                    }
                                },
                              {
                                  extend: 'pdfHtml5',
                                  // text: '<i class="fa fa-file-pdf-o style="font-size:23px;"></i>',
                                  //  text: 'Print current page',
                                  autoPrint: false,
                                  orientation: 'landscape',
                                  text: 'pdf',
                                  titleAttr: 'Export to PDF',
                                  title: 'Actual History Details',
                                  exportOptions: {
                                      columns: ':not(:last-child)',
                                      modifier: {
                                          selected: true,
                                          page: 'current'
                                      }
                                  },
                              },
                                'colvis'
                ],
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
                //lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]]
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

    <%-- <style>
        txtCalender
        {
            position: absolute;
            left: 0px;
            top: 0px;
            z-index: +1;
        }
    </style>--%>

    <style type="text/css">
        .ajax__calendar_container
        {
            z-index: 1000;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title" align="center"><b>Actual History Details</b></h3>
            <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
        </div>
    </div>





    <div id="divEnterDetails" runat="server">

        <div class="panel panel-info">
            <div class="panel-heading colorpanelhead">
                <asp:Label ID="Label1" runat="server" CssClass="labelPageHeader" Text="Actual History Details"></asp:Label>
            </div>

            <%-- Entry Record--%>
            <div class="panel-body">
                <div class="row ">

                    <div id="DivForDivision" runat="server" class="col-xs-3 col-sm-3 col-md-3">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlDivision"><b>Division:</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Select Division" InitialValue="-1" ForeColor="Red" ControlToValidate="ddlDivision" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div id="Div1" runat="server" class="col-xs-3 col-sm-3 col-md-3">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlInitiative"><b>Initiative:</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <asp:DropDownList ID="ddlInitiative" runat="server" CssClass="form-control input-sm" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Please Select Division" InitialValue="-1" ForeColor="Red" ControlToValidate="ddlInitiative" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-3 col-sm-3 col-md-3">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="txtRecordDate"><b>Kpi:</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <asp:DropDownList ID="ddlKpiRange" runat="server" CssClass="form-control input-sm" >
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-3 col-sm-3 col-md-3">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="txtRecordDate"><b>Progress Date:</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <%--  <asp:DropDownList ID="ddlProgressDate" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtRecordDate" runat="server" CssClass="form-control input-sm" onkeydown="return false;"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="txtRecordDate"  TargetControlID="txtRecordDate" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="validtxtRecordDate" runat="server" ControlToValidate="txtRecordDate" ErrorMessage="Mandatory Field" ValidationGroup="g1" CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>



                </div>


            </div>

            <div id="divSubmition" runat="server">
                <div class="row" align="center" style="text-align: center">
                    <div class="col-md-12">
                        <asp:Button ID="btnGenerate" Text="Generate" align="center" CssClass="btn btn-success" OnClick="btnGenerate_Click" runat="server" />
                    </div>
                </div>
            </div>
            </br>
            <div id="divGirdShow"  runat="server" visible="false">
                <div class="row ">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <div class="panel-group">
                            <asp:GridView ID="grdvUser" OnPreRender="grdvUser_PreRender" runat="server" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found for Users" AutoGenerateColumns="false" GridLines="None" HeaderStyle-Wrap="true"
                                Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Initiative" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInitiative" runat="server" Text='<%#Eval("Initiative") %>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-justify" Width="250px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Parameter (s)">
                                        <ItemTemplate>
                                            <asp:Label ID="txtParameter" runat="server" Text='<%#Eval("Parameter") %>'></asp:Label><br />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" Width="100px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="ddlUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" Width="50" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="KPI Value">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKpi" runat="server" Text='<%#Eval("KPI_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" Width="50" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Planned">
                                        <ItemTemplate>
                                            <asp:Label ID="txtIn100DaysPlanned" runat="server" Text='<%#Eval("PLANNED_VALUE") %>'></asp:Label><br />
                                            <asp:Label ID="txtIn100DaysRemarksPlanned" runat="server" Text='<%#Eval("PLANNED_VALUE_REMRAKS") %>' TextMode="MultiLine" placeholder="Remarks"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" Width="150px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Actual">
                                        <ItemTemplate>
                                            <asp:Label ID="txtIn100Days" runat="server"  Text='<%#Eval("ACTUAL_VALUE") %>'></asp:Label><br />
                                            <asp:Label ID="txtIn100DaysRemarks" runat="server" TextMode="MultiLine" Text='<%#Eval("ACTUAL_VALUE_REMRAKS") %>'  placeholder="Remarks"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" Width="150px"/>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>




</asp:Content>
