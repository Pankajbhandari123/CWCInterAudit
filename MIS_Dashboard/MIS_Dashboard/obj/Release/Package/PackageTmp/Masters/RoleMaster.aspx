<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoleMaster.aspx.cs" Inherits="MIS_Dashboard.Masters.RoleMaster" %>

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
            $('#grdvAddrole').DataTable({

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
            <h3 class="panel-title" align="center"><b>Role Master</b></h3>
            <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
        </div>
    </div>


    <div id="divGirdShow" class="panel panel-info" runat="server">
        <div class="panel-heading">
            <h3 class="panel-title"><b>Role Information</b></h3>
            <div class="pull-right" style="margin-top: -23px; height: 18px;">
                <asp:LinkButton ID="lbtnAddRole" runat="server" Text="Add Role" OnClick="lbtnAddRole_Click" ToolTip="Click here to add new Role" CausesValidation="false" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
            </div>
        </div>

        <br />
        <div id="Griddiv" runat="server">
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <div class="panel-group">
                            <asp:GridView ID="grdvAddrole" runat="server" OnPreRender="grdvAddrole_PreRender" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found of Company Status" AutoGenerateColumns="False" GridLines="None" HeaderStyle-Wrap="true"
                                Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display" OnRowDataBound="grdvAddrole_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="20px" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Role Name" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>

                                            <asp:Label ID="lblRoleNmae" runat="server" Text='<%# Eval("ROLE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role Type" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblRoleType" runat="server" Text='<%# Eval("ROLE_USER_TYPE").ToString() == "1" ? "INTERNAL" :"EXTERNAL" %>'></asp:Label>
                                            <asp:HiddenField ID="hdnRolerecno" runat="server" Value='<%#Eval("ROLE_RECNO") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operation" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbtnEdit" OnClick="lkbtnEdit_Click" ToolTip="Edit" Text="Edit" runat="server"><%--<h4 class="glyphicon glyphicon-edit"></h4>--%></asp:LinkButton>
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

    <div id="divEnterDetails" runat="server" visible="false">
        <div class="panel-body">
            <div class="row ">
                <div class="col-xs-2 col-sm-2 col-md-2"></div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <label class="control-label" style="font-weight: 100" for="txtContactNo">Role Name:<b class="astrik">*</b></label>
                        <div class="input-group input-append  text-center">
                            <asp:TextBox ID="txtrolename" MaxLength="30" CssClass="form-control input-sm" runat="server" required></asp:TextBox>
                            <span class="input-group-addon add-on" id="Span4" runat="server"><span class="glyphicon glyphicon-list-alt"></span></span>

                        </div>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">

                    <div class="form-group">
                        <label class="control-label" style="font-weight: 100" for="txtLoginName">
                            Role Type :<b class="astrik">*</b>
                        </label>
                        <div class="input-group input-append">
                            <asp:DropDownList ID="ddlRoleType" runat="server" CssClass="form-control input-sm" required>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdnRole" runat="server" Value='<%#Eval("Role") %>' />
                            <span class="input-group-addon add-on" id="Span9" runat="server"><span class="glyphicon glyphicon-home"></span></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" align="center">
                <div class="col-md-12">
                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success " OnClick="btnSave_Click" runat="server" />
                    <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-info" runat="server" OnClientClick="return confirm('Are you sure you want to Clear Data?');" formnovalidate />
                    <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-danger" OnClick="btnBack_Click" runat="server" OnClientClick="return confirm('Are you sure you want to go back?');" formnovalidate />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
