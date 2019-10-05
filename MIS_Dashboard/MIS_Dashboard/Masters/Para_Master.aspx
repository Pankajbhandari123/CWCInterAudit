<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Para_Master.aspx.cs" Inherits="MIS_Dashboard.Para_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <script src="bootstrap-4.3.1-dist/css/GridView.css"></script>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">
      <br />
                   <div class="panel panel-info">

        <div class="panel-heading">
            <h3 class="panel-title" align="center"><b>Report Master</b></h3>
            <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
        </div>
                <div class="panel panel-info">
                        <div class="panel-heading colorpanelhead">
                        <asp:Label ID="lblHead" runat="server" CssClass="labelPageHeader" Text="Report"></asp:Label>

                    </div>
                    <div class="pull-right" style="margin-top: -31px; height: 18px;">
                        <asp:LinkButton ID="btnAddNewUser" runat="server" CausesValidation="false" CssClass="btn btn-danger btn-sm" Text="Add New"></asp:LinkButton>
                    </div>
                                    <asp:GridView ID="grdvUser" runat="server" OnPreRender="grdvUser_PreRender" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found for Users" AutoGenerateColumns="False" GridLines="None" HeaderStyle-Wrap="true"
                                        Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Para Subject">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("ParaId") %>' />
                                                    <asp:HiddenField ID="hdnRegionRecNo" runat="server" Value="0" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Report Number">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("ReportNumber") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Active Status">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("ActiveStatus") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Operation">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click"
                                                        ToolTip="Edit"><h4 class="glyphicon glyphicon-edit"></h4></asp:LinkButton>&nbsp;&nbsp;
                                               <asp:LinkButton ID="lnkbtnDelete" OnClick="lnkbtnDelete_Click" runat="server"
                                                    ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to Delete this User ?');"><h4 class="glyphicon glyphicon-trash text-danger"></h4></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" />
                                            </asp:TemplateField>
                                        </Columns>
                    </asp:GridView>
                </div>
                       </div>
    <div class="row" runat="server">
                <div class="row ">
                    <div class="col-xs-1 col-sm-1 col-md-1">
                    </div>

                    <div class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100;" for="ddlOfficeStatus"><b>Report Number :</b><b class="asterik" style="color: red;">*</b></label>
                            <div class="input-group input-append  text-center">
                                <asp:DropDownList ID="ddlReportNumber" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>                                <asp:Label ID="lblTotalExtend" runat="server" Visible="false"></asp:Label>
                                <span class="input-group-addon add-on" id="Span1" runat="server"><span class="glyphicon glyphicon-list-alt"></span></span>
                                 </div>
                        </div>
                    </div>
                    <div class="col-xs-1 col-sm-1 col-md-1">
                    </div>
                    <div class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100" for="txtRegion"><b>Para Subject :</b><b class="astrik" style="color: red;">*</b></label>
                            <div class="input-group input-append  text-center">
                                <asp:TextBox ID="txtParaSubject" MaxLength="30" CssClass="form-control input-sm" runat="server" required style="left: -1px; top: 0px"></asp:TextBox>
                                <span class="input-group-addon add-on" id="Span4" runat="server"><span class="glyphicon glyphicon-list-alt"></span></span>

                            </div>
                        </div>
                    </div>
                </div>
    </div>
    <div id="divRptInsertIncreament" runat="server" visible="true"  style="padding-top: 10px; width:60%; padding-left:20%;">
        <asp:Repeater ID="rptActivity" runat="server" >
                          
                                        <HeaderTemplate>&nbsp;&nbsp;&nbsp;&nbsp;
                                          
                <table style="width: 100%;" class="tableRepeaterCSS">
                                                <tr class="alert-info">
                                                    <th style="border-right: 1px solid grey; background-color: #f5f5f5;">S.No</th>
                                                    <th style="border-right: 1px solid grey; background-color: #f5f5f5;">Sub Activity  
                                                    </th>
                                                    <th style ="border-right:1px solid grey; background-color:#f5f5f5;">Operation
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <tr>
                    <td align="center">
                                                    <%#Container.ItemIndex+1 %>
                                                    <asp:HiddenField ID="hdnParaID" Value='<%#Eval("paraId") %>' runat="server"/>
                                                </td>
                    <td align="center">
                                                      <asp:TextBox ID="txtParaName"  CssClass="form-control input-sm" runat="server" Width="250" Text='<%#Eval("ParaName") %>' Style="text-align: left"  autocomplete="off"></asp:TextBox></td>
                    <td align="center">
                                                    <asp:ImageButton ID="imgbtnAddRowactivity" ImageUrl="~/images/add.png" runat="server" OnClick ="imgbtnAddRowactivity_Click" CssClass="glyphicon glyphicon-plus-sign"  ></asp:ImageButton>
                                                    <asp:ImageButton ID="imgbtnDeleteRowactivity" ImageUrl="~/images/Remove.jpg" runat="server" OnClick ="imgbtnDeleteRowactivity_Click" CssClass="glyphicon glyphicon-minus-sign"></asp:ImageButton>
                                               
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
        <br />
            <br/>
            <br />
            <br />
    </div>
                    <div class="row" align="center" style="text-align: center">
                    <div class="col-md-12">
                        <asp:Button ID="btnSave" Text="Save" align="center" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"/>
                        <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-info" runat="server" OnClick="btnClear_Click" OnClientClick="return confirm('Are you sure you want to Clear Data?');" formnovalidate />
                        <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-danger" runat="server" OnClick="btnCancel_Click" OnClientClick="return confirm('Are you sure you want to go back?');" formnovalidate />
                    </div>
                </div>
</asp:Content>
