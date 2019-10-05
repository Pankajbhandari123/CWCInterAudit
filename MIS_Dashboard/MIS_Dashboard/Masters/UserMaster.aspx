<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="MIS_Dashboard.Masters.UserMaster" %>

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
                                    title: 'User Master list',
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
                                  title: 'User Master list',
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
            <h3 class="panel-title" align="center"><b>User Master</b></h3>
            <asp:Label ID="UserId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblLoginName" runat="server" Visible="false"></asp:Label>
        </div>
    </div>

    <div id="divGirdShow" class="panel panel-info" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="panel panel-info">
                    <div class="panel-heading colorpanelhead">
                        <asp:Label ID="lblHead" runat="server" CssClass="labelPageHeader" Text="User Management"></asp:Label>
                       
                    </div>
                    <div class="pull-right" style="margin-top: -35px;">
                        <asp:LinkButton ID="btnAddNewUser" runat="server" CausesValidation="false" CssClass="btn btn-danger btn-sm" OnClick="btnAddNewUser_Click" Text="Add New User"></asp:LinkButton>
                    </div>
                    <div class="panel-body">

                        <div class="row ">
                            <div class="col-xs-12 col-sm-12 col-md-12">
                                <%--<div id="divDownload" runat="server" class="DivDownload">
                                <custom:Pager ID="custPager" runat="server" OnPageChanged="custPager_PageChanged"
                                    OnExportToExcel="custPager_ExportToExcel" OnExportToWord="custPager_ExportToWord" />
                            </div>--%>
                                <div class="panel-group">
                                    <asp:GridView ID="grdvUser" runat="server" OnPreRender="grdvUser_PreRender" ClientIDMode="Static" ShowHeaderWhenEmpty="true" EmptyDataText="No data found for Users" AutoGenerateColumns="False" GridLines="None" HeaderStyle-Wrap="true"
                                        Width="100%" ShowFooter="true" CssClass="GridTabletrCss table table-striped table-bordered table-hover display" OnRowDataBound="grdvUser_RowDataBound">

                                        <Columns>
                                            <asp:TemplateField HeaderText="Operation" HeaderStyle-CssClass="text-center" >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEdit" OnClick="lnkbtnEdit_Click" runat="server"
                                                        ToolTip="Edit" Text="Edit"><%--<h4 class="glyphicon glyphicon-edit"></h4>--%></asp:LinkButton>&nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkbtnDelete" OnClick="lnkbtnDelete_Click" runat="server"
                                                    ToolTip="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete this User ?');"><%--<h4 class="glyphicon glyphicon-trash text-danger"></h4>--%></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Login Name" HeaderStyle-CssClass="text-center" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLoginName" runat="server" Text='<%#Eval("LOGIN_NAME") %>' />
                                                    <asp:HiddenField ID="hdnUserRecNo" runat="server" Value='<%#Eval("USER_RECNO") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Email ID" HeaderStyle-CssClass="text-center" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmailID" runat="server" Text='<%#Eval("EMAILID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Role" HeaderStyle-CssClass="text-center" >
                                                <ItemStyle CssClass="text-left" />
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnROLE_RECNO" runat="server" Value='<%#Eval("ROLE_RECNO") %>' />
                                                    <asp:Label ID="lblRole" runat="server" Text='<%#Eval("ROLE_NAME") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Active/Inactive" HeaderStyle-CssClass="text-center" >
                                                <ItemStyle CssClass="text-left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActiveStatus" runat="server" Text='<%#Eval("ACTIVE_STATUS") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center" >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnbtnViewDetails" runat="server" CssClass="text-center" ToolTip="View User Details" Text="View" OnClick="lnbtnViewDetails_Click"><%--<h4 class="glyphicon glyphicon-eye-open text-info" ></h4>--%></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit Rights" HeaderStyle-CssClass="text-center" >
                                                <ItemStyle CssClass="text-center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnRights" CssClass="text-center" OnClick="lnkbtnRights_Click" runat="server"
                                                        ToolTip="Edit/View Rights" Text="Edit/View Rights" >
                                                <%--<h4 class="glyphicon glyphicon-wrench text-warning"></h4>--%></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        <%--    <asp:TemplateField HeaderText="Edit Dashboard Rights">
                                                <ItemStyle CssClass="text-center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnDashboardRights" CssClass="text-center" OnClick="lnkbtnDashboardRights_Click" runat="server"
                                                        ToolTip="Edit Dashboard Rights">
                                                <h4 class="glyphicon glyphicon-wrench text-warning"></h4></asp:LinkButton>
                                                </ItemTemplate>


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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="UpdateProcess">
                <div class="UpdateProcessDiv">
                    <img src="../Images/ballsNew.svg" />
                    <p style="color: white; font-weight: bold">Please wait while your request is processing...</p>
                </div>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
