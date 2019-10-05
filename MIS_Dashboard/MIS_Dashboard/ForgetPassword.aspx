<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="MIS_Dashboard.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords" content="">
    <meta name="description" content="">
    <!--

Template 2075 Digital Team

http://www.tooplate.com/view/2075-digital-team

-->
    <link rel="stylesheet" href="templatecss/css/bootstrap.min.css">
    <link rel="stylesheet" href="templatecss/css/font-awesome.min.css">
    <link rel="stylesheet" href="templatecss/css/animate.min.css">
    <link rel="stylesheet" href="templatecss/css/et-line-font.css">
    <link rel="stylesheet" href="templatecss/css/nivo-lightbox.css">
    <link rel="stylesheet" href="templatecss/css/nivo_themes/default/default.css">
    <link rel="stylesheet" href="templatecss/css/style.css">
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,300,500' rel='stylesheet' type='text/css'>
    <script src="Scripts/jquery-3.3.1.min.js"></script>



    <%--Login model Style Start--%>
    <style type="text/css">
        body
        {
            font-family: 'Varela Round', sans-serif;
        }

        .modal-login
        {
            color: #636363;
            width: 350px;
        }

            .modal-login .modal-content
            {
                padding: 20px;
                border-radius: 5px;
                border: none;
            }

            .modal-login .modal-header
            {
                border-bottom: none;
                position: relative;
                justify-content: center;
            }

            .modal-login h4
            {
                text-align: center;
                font-size: 26px;
                margin: 30px 0 -15px;
            }

            .modal-login .form-control:focus
            {
                border-color: #70c5c0;
            }

            .modal-login .form-control, .modal-login .btn
            {
                min-height: 40px;
                border-radius: 3px;
            }

            .modal-login .close
            {
                position: absolute;
                top: -5px;
                right: -5px;
            }

            .modal-login .modal-footer
            {
                background: #ecf0f1;
                border-color: #dee4e7;
                text-align: center;
                justify-content: center;
                margin: 0 -20px -20px;
                border-radius: 5px;
                font-size: 13px;
            }

                .modal-login .modal-footer a
                {
                    color: #999;
                }

            .modal-login .avatar
            {
                position: absolute;
                margin: 0 auto;
                left: 0;
                right: 0;
                top: -70px;
                width: 95px;
                height: 95px;
                border-radius: 50%;
                z-index: 9;
                background: #ffffff;
                padding: 15px;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

                .modal-login .avatar img
                {
                    width: 100%;
                }

            .modal-login.modal-dialog
            {
                margin-top: 80px;
            }

            .modal-login .btn
            {
                color: #fff;
                border-radius: 4px;
                background: #60c7c1;
                text-decoration: none;
                transition: all 0.4s;
                line-height: normal;
                border: none;
            }

                .modal-login .btn:hover, .modal-login .btn:focus
                {
                    background: #45aba6;
                    outline: none;
                }

        .trigger-btn
        {
            display: inline-block;
            margin: 100px auto;
        }
    </style>
    <%--Login model Style End--%>

    <%--Message Pop Up MOdal Start--%>
    <script type="text/javascript">
        function Message(title, cssClass, msg) {
            $("#ShowBody1").empty();
            $("#ShowTitle1").empty();

            $(".modal-header1").removeClass('btn-danger btn-success btn-warning');
            $("#ShowTitle1").removeClass('btn-danger btn-success btn-warning');
            $("#ShowTitle1").addClass(cssClass);
            $(".modal-header1").addClass(cssClass)
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



            $('#ShowBody1').append('<p>' + msg + '</p>');


            $('#ShowTitle1').append(title);
            $("#btnShowPopup").click();


        }
    </script>
    <%--Message Pop Up MOdal End--%>
</head>
<body style="background-color: lightcyan;">
    <form id="form1" runat="server">
        <section class="navbar navbar-fixed-top custom-navbar" role="navigation" style="background-color: #0aab8a; color: #000;">
            <%----%>
            <div class="container">

                <div class="navbar-header">
                    <a href="#" target="_blank">
                        <img class="img-responsive" src="cwc_logo.png" style="margin-top: 5px; height: 50px;" /></a>
                </div>

                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <h3><span class="smoothScroll" style="color: #fff">CWC Performance Dashboard</span></h3>
                        <%-- <li><a href="#home" class="smoothScroll">HOME</a></li>--%>
                        <%-- <li><a href="#work" class="smoothScroll">Dasboard</a></li>--%>
                        <%--	<li><a href="#about" class="smoothScroll">ABOUT</a></li>
				<li><a href="#team" class="smoothScroll">TEAM</a></li>
				<li><a href="#portfolio" class="smoothScroll">PORTFOLIO</a></li>
				<li><a href="#pricing" class="smoothScroll">PRICING</a></li>
                    <li><a href="Login.aspx" class="smoothScroll">Login</a></li>--%>
                        <%-- <li><a href="#myModal" data-toggle="modal" data-target="#myModal" class="smoothScroll"><b>Login</b></a></li>--%>
                    </ul>
                </div>
            </div>
        </section>
        <div class="row form-group" style="padding-top: 120px;">
            <div class="container" runat="server">
                <div id="pwdModal" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <%--   <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>--%>
                                <h1 class="text-center">Forget Password?</h1>
                            </div>
                            <div class="modal-body">
                                <div class="col-md-12">
                                    <div class="panel panel-default">
                                        <div class="panel-body">
                                            <div class="text-center">

                                                <p>If you have forgotten your password you can reset it here.</p>
                                                <div class="panel-body">
                                                    <fieldset>
                                                        <div class="form-group">
                                                            <input class="form-control input-lg" id="txtForgetUser" placeholder="Username" runat="server" name="email" type="text">
                                                        </div>
                                                        <div class="row">
                                                            <%--<div class="col-md-12 col-lg-12">--%>
                                                            <div class="col-md-3 col-lg-3" align="right">
                                                                <asp:Image ID="imgCaptcha" runat="server" Width="100" Height="30" />
                                                            </div>
                                                            <div class="col-md-1 col-lg-1">
                                                            </div>
                                                            <div class="col-md-1 col-lg-1">
                                                                <asp:ImageButton ID="ImgBtnRefresh" runat="server" ImageUrl="images/refresh.png" OnClick="ImgBtnRefresh_Click" />
                                                            </div>
                                                            <%-- <div class="col-md-5 col-lg-5" align="right">
                                        <h5><span style="color: red;">*</span>Enter&nbsp;Captca&nbsp;Code&nbsp;</h5>
                                    </div>--%>
                                                            <div class="col-md-1 col-lg-1">
                                                                <span style="color: red;">*</span>
                                                            </div>
                                                            <div class="col-md-2 col-lg-2">
                                                                <asp:TextBox ID="txtCaptcha" runat="server" PlaceHolder="Enter Captca" CssClass="form-control input-sm" Width="100px"> 
                                                                </asp:TextBox><asp:Label ID="lblCaptcha" runat="server" Text=""></asp:Label>
                                                            </div>
                                                            <%-- </div>--%>
                                                        </div>
                                                        <asp:Button ID="btnSubmit" class="btn btn-lg btn-primary btn-block" runat="server" Text="Send My Password" OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="btnBack" class="btn btn-lg btn-primary btn-block" runat="server" Text="Back" OnClick="btnBack_Click" />
                                                    </fieldset>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="col-md-12">
                                    <%--<button class="btn" data-dismiss="modal" aria-hidden="true">Cancel</button>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--For Show Messages--%>
        <div class="modal fade" id="MsgBox" tabindex="-1" role="dialog" aria-labelledby="purchaseLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header1 btn-danger">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4><i id="Icon" class="glyphicon glyphicon-thumbs-up">&nbsp;</i><span class="modal-title" id="ShowTitle1"></span></h4>
                    </div>
                    <div class="modal-body" id="ShowBody1">
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
    </form>
    <script src="templatecss/js/jquery.js"></script>
    <script src="templatecss/js/bootstrap.min.js"></script>
    <script src="templatecss/js/smoothscroll.js"></script>
    <script src="templatecss/js/isotope.js"></script>
    <script src="templatecss/js/imagesloaded.min.js"></script>
    <script src="templatecss/js/nivo-lightbox.min.js"></script>
    <script src="templatecss/js/jquery.backstretch.min.js"></script>
    <script src="templatecss/js/wow.min.js"></script>
    <script src="templatecss/js/custom.js"></script>
</body>
</html>
