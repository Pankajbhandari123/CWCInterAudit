<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ActionActualEntry.aspx.cs" Inherits="MIS_Dashboard.Process.ActionActualEntry" %>

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
                                    title: 'Role Master list',
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
                                  title: 'Role Master list',
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

    <style>
txtCalender {
  position: absolute;
  left: 0px;
  top: 0px;
  z-index: +1;
}
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title" align="center"><b>Action Actual</b></h3>
            <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
        </div>
    </div>


    <div id="divGirdShow" class="panel panel-info" runat="server">

        <div class="panel panel-info">
            <div class="panel-heading colorpanelhead">
                <h3 class="panel-title"><b>Action Actual</b></h3>
                <div class="pull-right" style="margin-top: -23px; height: 18px;">
                    <asp:LinkButton ID="btnAddNew" runat="server" CausesValidation="false" CssClass="btn btn-danger btn-sm" OnClick="btnAddNew_Click" Text="Add New"></asp:LinkButton>
                </div>
            </div>
            <div class="panel-body">

                <div class="row ">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <div class="panel-group">
                            <asp:GridView ID="grdvUser" OnPreRender="grdvUser_PreRender" runat="server" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found for Users" AutoGenerateColumns="false" GridLines="None" HeaderStyle-Wrap="true"
                                Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display">

                                <Columns>

                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Office Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOfficeType" runat="server" Text='<%#Eval("OFFICE_TYPE").ToString()== "0" ? "Corporation Office" : "Regional Office" %>' />
                                            <asp:HiddenField ID="hdnDivisionRecno" runat="server" Value='<%#Eval("DIVISION_REGION_RECNO") %>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Divsion">
                                        <ItemTemplate>
                                            <asp:Label ID="lnlDivision" runat="server" Text='<%#Eval("DIVISION_REGION_NAME") %>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Record Entry Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecordDate" runat="server" Text="" />  <%-- Text='<%#Eval("RECORD_ENTRY_DATE") %>'--%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Operation">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click"
                                                ToolTip="Edit" Text="Edit"><%--<h4 class="glyphicon glyphicon-edit">--%></h4></asp:LinkButton>&nbsp;&nbsp;
                                              <%--  <asp:LinkButton ID="lnkbtnDelete" OnClick="lnkbtnDelete_Click" runat="server"
                                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to Delete this User ?');"><h4 class="glyphicon glyphicon-trash text-danger"></h4></asp:LinkButton>--%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" />
                                    </asp:TemplateField>
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


    <div id="divEnterDetails" runat="server" visible="false">

        <div class="panel panel-info">
            <div class="panel-heading colorpanelhead">
                <asp:Label ID="Label1" runat="server" CssClass="labelPageHeader" Text="Action Planned"></asp:Label>
            </div>

            <%-- Entry Record--%>
            <div class="panel-body">
                <div class="row ">
                    <div class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlOfficeStatus"><b>Record Date:</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <asp:TextBox ID="txtRecordDate" runat="server" CssClass="form-control input-sm"  onkeydown="return false;" OnTextChanged="txtRecordDate_TextChanged"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="txtRecordDate"  CssClass="txtCalender" TargetControlID="txtRecordDate" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="validtxtRecordDate" runat="server" ControlToValidate="txtRecordDate" ErrorMessage="Mandatory Field" ValidationGroup="g1" CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlOfficeStatus"><b>Office Type:</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <asp:DropDownList ID="ddlOfficeStatus" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlOfficeStatus_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Corporation Office" Value="0" />
                                    <%-- <asp:ListItem Text="Regional Office" Value="1" />--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div id="DivForDivision" runat="server" class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlDivision"><b>Division:</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Select Division" InitialValue="0" ForeColor="Red" ControlToValidate="ddlDivision" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div id="DivForRegion" runat="server" visible="false" class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlRegion"><b>Region:</b><b class="asterik" style="color: red;"> </b></label>
                            <div>
                                <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Please Select Region" InitialValue="0" ForeColor="Red" ControlToValidate="ddlRegion" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

                <%--<div class="row" >
                    <div class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlOfficeStatus"><b>Reamrks :</b><b class="asterik" style="color: red;">*</b></label>
                            <div>
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>


            <%-- Actual Grid Data--%>
            <div class="panel-body">
                <div id="divPlannedGrid" runat="server" visible="false">
                    <div class="table-responsive">
                        <div class="col-xs-12 col-sm-12 col-md-12">
                            <div class="panel-group">
                                <asp:GridView ID="GridView1" runat="server" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found" AutoGenerateColumns="false" GridLines="None" HeaderStyle-Wrap="true"
                                    Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display"
                                     OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="5px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Initiative">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInitiative" runat="server" Text='<%#Eval("INITIATIVE") %>' />
                                                <asp:HiddenField ID="hdnInitiativeRecNo" runat="server" Value='<%#Eval("INITIATIVE_RECNO") %>' />
                                                <asp:HiddenField ID="hdnActualRecno" runat="server" Value='<%#Eval("ACTUAL_RECNO") %>' />
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
                                                <asp:DropDownList ID="ddlRequireChanges" runat="server" CssClass="form-control dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlRequireChanges_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                                                </asp:DropDownList><br />
                                                <asp:TextBox ID="txtRequireChangesRemarks" runat="server" TextMode="MultiLine" Visible="false" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parameter (s)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtParameter" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txtParameterRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="ddlUnit" runat="server" Text='<%#Eval("UNIT_NAME") %>'></asp:Label>
                                                <%--<asp:DropDownList ID="ddlUnit" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" Width="50" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="In 100 days">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtIn100Days" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event);"></asp:TextBox><br />
                                                <asp:TextBox ID="txtIn100DaysRemarks" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" placeholder="Remarks"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="text-center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="15 Aug. 2022">
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
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>



    <div id="divSubmition" runat="server" visible="false">
        <div class="row" align="center" style="text-align: center">
            <div class="col-md-12">
                <asp:Button ID="btnSave" Text="Save" align="center" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-info" runat="server" OnClientClick="return confirm('Are you sure you want to Clear Data?');" formnovalidate />
                <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-danger" OnClick="btnBack_Click" runat="server" OnClientClick="return confirm('Are you sure you want to go back?');" formnovalidate />
            </div>
        </div>
    </div>
</asp:Content>
