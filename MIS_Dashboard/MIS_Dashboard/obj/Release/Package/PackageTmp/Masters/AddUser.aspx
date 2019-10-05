<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="MIS_Dashboard.Masters.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <style type="text/css">
        .material-switch > input[type="checkbox"]
        {
            display: none;
        }

        .material-switch > label
        {
            cursor: pointer;
            height: 0px;
            position: relative;
            width: 40px;
        }

            .material-switch > label::before
            {
                background: rgb(0, 0, 0);
                box-shadow: inset 0px 0px 10px rgba(0, 0, 0, 0.5);
                border-radius: 8px;
                content: '';
                height: 16px;
                margin-top: -8px;
                position: absolute;
                opacity: 0.3;
                transition: all 0.4s ease-in-out;
                width: 40px;
            }

            .material-switch > label::after
            {
                background: rgb(255, 255, 255);
                border-radius: 16px;
                box-shadow: 0px 0px 5px rgba(0, 0, 0, 0.3);
                content: '';
                height: 24px;
                left: -4px;
                margin-top: -8px;
                position: absolute;
                top: -4px;
                transition: all 0.3s ease-in-out;
                width: 24px;
            }

        .material-switch > input[type="checkbox"]:checked + label::before
        {
            background: inherit;
            opacity: 0.5;
        }

        .material-switch > input[type="checkbox"]:checked + label::after
        {
            background: inherit;
            left: 20px;
        }
    </style>
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph" runat="server">

    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>

            <div class="panel panel-info">
                <div class="panel-heading colorpanelhead">
                    <asp:Label ID="lblHead" runat="server" CssClass="labelPageHeader" Text="User Management"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="row ">
                        <%--  <div class="col-xs-12 col-sm-12 col-md-4" id="id1">

                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="txtLoginName">
                                    District :<b class="astrik">*</b>
                                </label>
                                <div class="input-group input-append">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm" required>
                                    </asp:DropDownList>
                                    <span class="input-group-addon add-on" id="Span8" runat="server"><span class="glyphicon glyphicon-globe"></span></span>
                                </div>
                            </div>

                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-4" id="id2">

                            <div class="form-group"  >
                                <label class="control-label" style="font-weight: 100" for="txtLoginName">
                                    Industrial eState :<b class="astrik">*</b>
                                </label>
                                <div class="input-group input-append">
                                    <asp:DropDownList ID="ddlIIE" runat="server" CssClass="form-control input-sm" required>
                                    </asp:DropDownList>
                                    <span class="input-group-addon add-on" id="Span9" runat="server"><span class="glyphicon glyphicon-home"></span></span>
                                </div>
                            </div>

                        </div>--%>
                        <div class="col-xs-12 col-sm-12 col-md-4">

                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="txtLoginName">
                                    Login Name :<b class="astrik" style="color: red;">*</b>
                                </label>
                                <div class="input-group input-append">
                                    <asp:TextBox ID="txtLoginName" MaxLength="30" CssClass="form-control input-sm" runat="server" required></asp:TextBox>
                                    <span class="input-group-addon add-on" id="Span2" runat="server"><span class="glyphicon glyphicon-user"></span></span>
                                </div>
                            </div>

                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="txtDisplayName">Display Name :<b class="astrik" style="color: red;">*</b></label>
                                <div class="input-group input-append">
                                    <asp:TextBox ID="txtDisplayName" MaxLength="30" CssClass="form-control input-sm" runat="server" required></asp:TextBox>
                                    <span class="input-group-addon add-on" id="Span1" runat="server"><span class="glyphicon glyphicon-tag"></span></span>
                                </div>
                            </div>

                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="txtEmailID">Email ID :<b class="astrik" style="color: red;">*</b></label>
                                <div class="input-group input-append">
                                    <asp:TextBox ID="txtEmailID" MaxLength="100" CssClass="form-control input-sm" runat="server" OnTextChanged="txtEmailID_TextChanged" AutoPostBack="true" required></asp:TextBox>
                                    <span class="input-group-addon add-on" id="Span3" runat="server"><span class="glyphicon glyphicon-envelope"></span></span>
                                </div>
                            </div>

                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="txtContactNo">Contact No :<b class="astrik" style="color: red;">*</b></label>
                                <div class="input-group input-append">
                                    <asp:TextBox ID="txtContactNo" MaxLength="30" CssClass="form-control input-sm" runat="server" required onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <span class="input-group-addon add-on" id="Span4" runat="server"><span class="glyphicon glyphicon-phone"></span></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="ddlRole">Role :<b class="astrik" style="color: red;">*</b></label>
                                <div class="input-group input-append">
                                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control input-sm" required>
                                    </asp:DropDownList>
                                    <span class="input-group-addon add-on" id="Span5" runat="server"><span class="fa fa-users"></span></span>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="ddlDivision">Division :<b class="astrik" style="color: red;">*</b></label>
                                <div class="input-group input-append">
                                    <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control input-sm" required>
                                    </asp:DropDownList>
                                    <span class="input-group-addon add-on" id="Span8" runat="server"><span class="fa fa-users"></span></span>
                                    <%--<asp:RequiredFieldValidator ID="ddlrequired" runat="server" ControlToValidate="ddlDivision" InitialValue="0" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="txtPassword">Password :<b class="astrik" style="color: red;">*</b></label>
                                <div class="input-group input-append">
                                    <asp:TextBox ID="txtPassword" MaxLength="30" TextMode="Password" CssClass="form-control input-sm" runat="server" Enabled="false" required></asp:TextBox>
                                    <span class="input-group-addon add-on" id="Span6" runat="server"><span class="glyphicon glyphicon-pencil"></span></span>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100" for="txtConfirmPassword">Confirm Password :</label>
                                <div class="input-group input-append">
                                    <asp:TextBox ID="txtConfirmPassword" MaxLength="30" TextMode="Password" CssClass="form-control input-sm" runat="server" Enabled="false" required></asp:TextBox>
                                    <span class="input-group-addon add-on" id="Span7" runat="server"><span class="glyphicon glyphicon-pencil"></span></span>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-2">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100">Set Default Password :</label>
                                <div class="material-switch">
                                    <asp:CheckBox ID="chkbxPswd" ClientIDMode="Static" Checked="true" AutoPostBack="true" runat="server" OnCheckedChanged="chkbxPswd_CheckedChanged" />
                                    <label for="chkbxPswd" title="if you want to set default password for this user on this button" class="label-success"></label>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100">User must change password at first logon:</label>
                                <div class="material-switch">
                                    <asp:CheckBox ID="chkChangePassword" ClientIDMode="Static" runat="server" Checked="true" />
                                    <label for="chkChangePassword" class="label-warning"></label>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-2 col-sm-12 col-md-2">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100">Inactive User :</label>
                                <div class="material-switch">
                                    <asp:CheckBox ID="chkbxInactive" ClientIDMode="Static" runat="server" />
                                    <label for="chkbxInactive" title="if want to to set user as Inactive user on this button" class="label-danger"></label>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-3">
                            <div class="form-group">
                                <label class="control-label" style="font-weight: 100">Locked User :</label>
                                <div class="material-switch">
                                    <asp:CheckBox ID="chkbxLock" ClientIDMode="Static" runat="server" />
                                    <label for="chkbxLock" title="if you want to lock this particular user on this button" class="label-info"></label>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-12">
                            <hr />
                            <div class="form-group text-center">
                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success disable" runat="server" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" Visible="false" Text="Update" CssClass="btn btn-warning disable" runat="server"
                                    OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-info disable" runat="server" OnClick="btnClear_Click" formnovalidate />
                                <%--  //added this - --%>
                                <asp:Button ID="btnCancel" Text="Back" CssClass="btn btn-danger disable" runat="server" OnClick="btnCancel_Click" OnClientClick="return confirm('Are you sure you want to Go Back?');" formnovalidate />
                                <%--  //added this - --%>
                            </div>
                        </div>
                    </div>
                </div>
               <%-- <div class="panel-footer">Powered by Vedang </div>--%>
            </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="update" runat="server">
        <ProgressTemplate>
            <div class="UpdateProcess">
                <div class="UpdateProcessDiv">
                    <img src="../Images/ballsNew.svg" />
                    <p style="color: white; font-weight: 100">Please wait while your request is processing...</p>
                </div>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
