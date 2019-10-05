<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/MasterPage.Master" 
    ClientIDMode="Static" AutoEventWireup="true" CodeBehind="DivisionMaster.aspx.cs" Inherits="MIS_Dashboard.Masters.DivisionMaster" %>

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
    <script type="text/javascript">
        $(function () {
            //Normal Configuration
            $("[id*=txtDivisionName]").MaxLength({ MaxLength: 100 });
        });
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">

    <br />

    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title" align="center"><b>Division Master Final</b></h3>
            <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
        </div>
    </div>


    <div id="divGirdShow" class="panel panel-info" runat="server">
        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
      <%--  <div class="panel panel-info">
            <div class="panel-heading colorpanelhead">
                <asp:Label ID="lblHead" runat="server" CssClass="labelPageHeader" Text="Division"></asp:Label>

            </div>
            <div class="pull-right" style="margin-top: -23px; height: 18px;">
                <asp:LinkButton ID="btnAddNewUser" runat="server" OnClick="btnAddNewUser_Click" CausesValidation="false" CssClass="btn btn-danger btn-sm" Text="Add New"></asp:LinkButton>
            </div>--%>
         <div class="panel-heading">
            <h3 class="panel-title"><b>Division</b></h3>
            <div class="pull-right" style="margin-top: -23px; height: 18px;">
                <asp:LinkButton ID="btnAddNewUser" runat="server" Text="Add New" OnClick="btnAddNewUser_Click" ToolTip="Click here to add new Division" CausesValidation="false" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
            </div>
        </div>
            <div class="panel-body">

                <div class="row ">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <div class="panel-group">
                            <asp:GridView ID="grdvUser" runat="server" OnPreRender="grdvUser_PreRender" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found for Users" AutoGenerateColumns="False" GridLines="None" HeaderStyle-Wrap="true"
                                Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display">

                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Division Name" HeaderStyle-CssClass="text-center" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDivisionname" runat="server" Text='<%#Eval("DIVISION_NAME") %>' />
                                            <asp:HiddenField ID="hdnDivisionrecno" runat="server" Value='<%#Eval("DIVISION_RECNO") %>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-left"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Active Status" HeaderStyle-CssClass="text-center" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActivestatus" runat="server" Text='<%#Eval("ACTIVE_STATUS").ToString() == "0" ? "Active" : "Inactive" %>' ForeColor='<%#Eval("ACTIVE_STATUS").ToString() == "0" ? System.Drawing.Color.Green : System.Drawing.Color.Red %>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-left" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Operation" HeaderStyle-CssClass="text-center" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click"
                                                ToolTip="Edit Record" Text="Edit"><%--<h4 class="glyphicon glyphicon-edit"></h4>--%></asp:LinkButton>&nbsp;&nbsp;
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
        <%--</div>--%>
        <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>


    <div id="divEnterDetails" runat="server" visible="false">

        <div class="panel panel-info">
            <div class="panel-heading colorpanelhead">
                <asp:Label ID="Label1" runat="server" CssClass="labelPageHeader" Text="Division"></asp:Label>
            </div>

            <div class="panel-body">
                <div class="row ">
                   <%-- <div class="col-xs-2 col-sm-2 col-md-2"></div>--%>
                    <div class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100" for="txtContactNo"><b>Division Name:</b><b class="astrik" style="color: red;">*</b></label>
                            <div class="input-group input-append  text-center">
                                <asp:TextBox ID="txtDivisionName" MaxLength="100" CssClass="form-control input-sm" runat="server" required></asp:TextBox>
                                <%--<span class="input-group-addon add-on" id="Span4" runat="server"><span class="glyphicon glyphicon-list-alt"></span></span>--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-4 col-sm-4 col-md-4" runat="server" id="divactive" visible="false">

                        <div class="form-group">
                            <label class="control-label" style="font-weight: 100" for="txtLoginName">
                                <b>Active Status :</b><b class="astrik" style="color: red">*</b>
                            </label>
                            <div>
                                <asp:RadioButton ID="rbtActive" Text="Active" runat="server" GroupName="status1" Checked="true" />
                                <asp:RadioButton ID="rbtInactive" Text="Inactive" runat="server" GroupName="status1" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" align="center" style="text-align: center">
                    <div class="col-md-12">
                        <asp:Button ID="btnSave" Text="Save" align="center" CssClass="btn btn-success" OnClick="btnSave_Click" runat="server" />
                        <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-info" runat="server" OnClick="btnClear_Click" OnClientClick="return confirm('Are you sure you want to Clear Data?');" formnovalidate />
                        <asp:Button ID="btnBack" Text="Back" CssClass="btn btn-danger" OnClick="btnBack_Click" runat="server" OnClientClick="return confirm('Are you sure you want to go back?');" formnovalidate />
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
