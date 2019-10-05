<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword1.aspx.cs" Inherits="MIS_Dashboard.Masters.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style>
        body {
            font-size: 12px;
        }
    </style>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.4/css/buttons.dataTables.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/buttons/1.2.4/css/buttons.jqueryui.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.13/css/dataTables.jqueryui.min.css" />
    <%-- <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/redmond/jquery-ui.css" />--%>
    <link href="../assets/redmond/jquery-ui.min.css" rel="stylesheet" />
    <link href="../assets/redmond/theme.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <script src="//cdn.datatables.net/buttons/1.2.4/js/buttons.colVis.min.js"></script>

    <link href="../Grids/css/buttons.jqueryui.min.css" rel="stylesheet" />


    <script type="text/javascript">
        $(document).ready(function () {
            $('#gridAllDataShow').DataTable({

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
                                    titleAttr: 'Export to Excel',
                                    title: 'ChangePassword list',
                                    exportOptions: {
                                        columns: ':not(:last-child)',
                                        modifier: {
                                            selected: true
                                        }
                                    }
                                },
                              {
                                  extend: 'pdfHtml5',
                                  // text: '<i class="fa fa-file-pdf-o style="font-size:23px;"></i>',
                                  text: 'pdf',
                                  titleAttr: 'Export to PDF',
                                  title: 'ChangePassword list',
                                  exportOptions: {
                                      columns: ':not(:last-child)',
                                      modifier: {
                                          selected: true
                                      }
                                  },
                              },
                                'colvis'
                ],
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                bJQueryUI: true,
                sDom: 'BT<"clear"><"H"lfr>t<"F"ip>'
                //lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">

    <div class="panel panel-info">
        <div class="panel-heading">
            <div class="panel-title">
                <b>Change Password</b>
                 <asp:Label ID="lblUserId" runat="server" visible="false"></asp:Label> 
                 <asp:Label ID="lblLoginName" runat="server" visible="false"></asp:Label> 
            </div>
        </div>
        <div class="panel-body" align="center">

            <div class="row " align="center">
                <div class="col-md-4"></div>
                                <div class="col-md-2">
                                   <h5><b>Old Password :</b><b class="asterisk" style="color:red">*</b></h5>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox  ID="txtOldPassword" CssClass="form-control input-sm" runat="server" TextMode="Password" ></asp:TextBox>
                                    <%--<span class="input-group-addon add-on" id="Span6" runat="server"><span class="glyphicon glyphicon-pencil"></span></span>--%>
                                </div>                               
               </div>
            &nbsp
            <div class="row">
                 <div class="col-md-4"></div>
                                <div class="col-md-2">
                                    <h5><b>New Password :</b><b class="asterisk" style="color:red">*</b></h5>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox  ID="txtNewPassword" CssClass="form-control input-sm" runat="server" TextMode="Password"></asp:TextBox>
                                    <%--<span class="input-group-addon add-on" id="Span1" runat="server"><span class="glyphicon glyphicon-pencil"></span></span>--%>
                                </div>                                
            </div>
            &nbsp
            <div class="row" align="center">
                <div class="col-md-12" >
                     <div class="col-md-4"></div>
                     <div class="col-md-2">
                                   <h5><b>Confirm Password :</b><b class="asterisk" style="color:red">*</b></h5> 
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox  ID="txtConfirmPassword"  CssClass="form-control input-sm" runat="server" TextMode="Password" ></asp:TextBox>
                                    <%--<span class="input-group-addon add-on" id="Span2" runat="server"><span class="glyphicon glyphicon-pencil"></span></span>--%>
                                    <asp:CompareValidator ID="validatorConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"  CssClass="ValidationError" ControlToCompare="txtNewPassword" ErrorMessage="Password must be the same" ToolTip="Password must be the same" ForeColor="Red" />
                                </div>
                </div>
                               
            </div>
            &nbsp
            <div class="row" align="center">
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" CausesValidation="false" OnClick="btnSave_Click"  />
                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass=" btn btn-danger" CausesValidation="false" OnClick="btnBack_Click"  OnClientClick="return confirm('Are you sure you want to Go Back?');" />
                </div>
            </div>
        </div>
    </div>

     <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/date/bootstrap-datetimepicker.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript">

        $('.date').datetimepicker({
            language: 'en',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 0,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 1,
            format: 'dd-M-yyyy'
        });

    </script>
</asp:Content>
