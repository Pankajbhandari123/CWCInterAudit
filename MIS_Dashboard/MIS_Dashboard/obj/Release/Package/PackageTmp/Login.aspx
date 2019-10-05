<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MIS_Dashboard.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Login V3</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="Login_v3/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Login_v3/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Login_v3/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Login_v3/fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Login_v3/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="Login_v3/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Login_v3/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Login_v3/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="Login_v3/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Login_v3/css/util.css">
    <link href="Login_v3/css/main.css" rel="stylesheet" />
<!--===============================================================================================-->


    
    <style type="text/css">
        :root {
            --input-padding-x: 1.5rem;
            --input-padding-y: .75rem;
        }

        body {
            background: #9CECFB;
            /* fallback for old browsers */
            background: -webkit-linear-gradient(to right, #0052D4, #65C7F7, #9CECFB);
            /* Chrome 10-25, Safari 5.1-6 */
            background: linear-gradient(to right, #0052D4, #65C7F7, #9CECFB);
            /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
        }

        .card-signin {
            border: 0;
            border-radius: 1rem;
            box-shadow: 0 0.5rem 1rem 0 rgba(0, 0, 0, 0.1);
        }

            .card-signin .card-title {
                margin-bottom: 2rem;
                font-weight: 300;
                font-size: 1.5rem;
            }

            .card-signin .card-body {
                padding: 2rem;
            }

        .form-signin {
            width: 100%;
        }

            .form-signin .btn {
                font-size: 80%;
                border-radius: 5rem;
                letter-spacing: .1rem;
                font-weight: bold;
                padding: 1rem;
                transition: all 0.2s;
            }

        .form-label-group {
            position: relative;
            margin-bottom: 1rem;
        }

            .form-label-group input {
                border-radius: 2rem;
            }

           
    </style>
    <script type="text/javascript">
        function OnlyNumeric(evt) {



            var chCode = evt.keyCode ? evt.keyCode : evt.charCode ? evt.charCode : evt.which;

            if (chCode >= 48 && chCode <= 57 ||
             chCode == 46) {
                return true;
            }
            else {
                Message('Message from System', 'btn-warning', 'Please Enter only numeric value.');
                return false;
            }
        }
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
        //End of Script for Msg

    </script>
</head>
<body>
	
	<div class="limiter" runat="server">
		<div class="container-login100" style="background-image: url('images/bg-01.jpg');">
			<div class="wrap-login100">
				<form class="login100-form validate-form" runat="server">
					<span class="login100-form-logo">
                        <img class="img-responsive" src="logo1.png"  style="margin-top: 5px; height: 70px;" />
						<%--<i class="zmdi zmdi-landscape"></i>--%>
					</span>

					<span class="login100-form-title p-b-34 p-t-27">
						Log in
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Enter username" runat="server">
						<input class="input100" id="txtUsername"   type="text" name="username" placeholder="Username" runat="server" required autofocus >
						<span class="focus-input100" data-placeholder="&#xf207;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
						<input class="input100" id="txtPassword" type="password" name="pass" placeholder="Password" runat="server" required autofocus>
						<span class="focus-input100" data-placeholder="&#xf191;"></span>
					</div>

					<div class="contact100-form-checkbox">
						<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
						<label class="label-checkbox100" for="ckb1">
							Remember me
						</label>
					</div>

					<div class="container-login100-form-btn">
						<%--<button type="submit" class="login100-form-btn" id="btnLogin" OnClick="btnLogin_Click" runat="server">
							Login
						</button>--%>
                        <asp:Button ID="some" CssClass="login100-form-btn" runat="server" Text="Login" OnClick="btnLogin_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" CssClass="login100-form-btn" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
					</div>


					<div class="text-center p-t-90">
						<a class="txt1" href="#">
							Forgot Password?
						</a>
					</div>
				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="Login_v3/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="Login_v3/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="Login_v3/vendor/bootstrap/js/popper.js"></script>
	<script src="Login_v3/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="Login_v3/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="Login_v3/vendor/daterangepicker/moment.min.js"></script>
	<script src="Login_v3/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="Login_v3/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>




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




</body>
</html>