<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignUserRights.aspx.cs" Inherits="MIS_Dashboard.Masters.AssignUserRights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


 <script>

        function Message(title, cssClass, msg) {
            $("#ShowBody").empty();
            $("#ShowTitle").empty();

            $(".modal-header").removeClass('btn-danger btn-success btn-warning');
            $("#ShowTitle").removeClass('btn-danger btn-success btn-warning');
            $("#ShowTitle").addClass(cssClass);
            $(".modal-header").addClass(cssClass)
            if (cssClass === 'btn-danger') {
                $("#modalbtn").removeClass('btn-success btn-warning');
                $("#modalbtn").addClass('btn-danger');
                $("#Icon").removeClass('glyphicon-thumbs-up glyphicon-warning-sign');
                $("#Icon").addClass('glyphicon-thumbs-down');
            }
            else if (cssClass === 'btn-success') {
                $("#modalbtn").removeClass('btn-danger btn-warning');
                $("#modalbtn").addClass('btn-success');
                $("#Icon").removeClass('glyphicon-thumbs-down glyphicon-warning-sign');
                $("#Icon").addClass('glyphicon-thumbs-up');
            }
            else {
                $("#modalbtn").removeClass('btn-danger btn-success ');
                $("#modalbtn").addClass('btn-warning');
                $("#Icon").removeClass('glyphicon-thumbs-down glyphicon-thumbs-up');
                $("#Icon").addClass('glyphicon-warning-sign');
            }

            $('#ShowBody').append('<p>' + msg + '</p>');

            $('#ShowTitle').append(title);
            $("#btnShowPopup").click();
        }
    </script>

    <style type="text/css">
        body {
            font-weight: normal;
            font-size:13px;
        }

        label {
            font-weight: normal;
            font-size: 85%;
        }

        th {
            text-align: center;
            font-size: 85%;
            background-color: black;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">

     <div class="panel panel-danger">
        <div class="panel-heading">
            <h3 class="panel-title">Assign Rights</h3>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 text-center">
                </div>

                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 text-center">
                    <div class="panel panel-danger">
                        <div class="panel-heading row">
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 text-center">
                                <b>View</b>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 text-center">
                                <b>Entry/Edit</b>
                            </div>
                        </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto; height:390px;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:Table ID="tb" runat="server" CssClass="table table-bordered" Style="border: none;">
                                            </asp:Table>--%>
                                            <asp:Table ID="tblPageRights" runat="server" CssClass="table table-bordered" BorderWidth="0"></asp:Table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div class="panel-footer alert-danger">
                            <div class="row">
                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <asp:Button ID="btnAssign" CssClass="btn-success btn btn-block" runat="server" Text="Assign" OnClick="btnAssign_Click" />
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <asp:Button ID="btnCancel" CssClass="btn-danger btn btn-block" runat="server" OnClientClick="return confirm('Are you sure you want to Go Back?');" Text="Back" OnClick="btnCancel_Click" />
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 text-center">
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

</asp:Content>