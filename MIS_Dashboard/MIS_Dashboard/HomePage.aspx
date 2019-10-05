<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MIS_Dashboard.HomePage" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible" />
    <meta name="viewport"
          content="width=device-width, initial-scale=1, maximum-scale=2, user-scalable=no" />
    <title>HomePage</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="https://kit.fontawesome.com/3b7ae1757d.js"></script>
    <link href="~/css/site.css" rel="stylesheet" />
    @*<script src="http://118.185.3.28/student_management/assets_login/plugins/css-gradientify/gradientify.min.js"></script>*@
    
    <style>
        /* Make the image fully responsive */
        .carousel-inner img {
            width: 100%;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".gradientanimation").gradientify({
                gradients: [
                    { start: [49, 76, 172], stop: [242, 159, 191] },
                    { start: [255, 103, 69], stop: [240, 154, 241] },
                    { start: [33, 229, 241], stop: [235, 236, 117] }
                ]
            });

        });

    </script>
</head>
<body id="divbody" data-spy="scroll" data-target=".navbar-collapse" data-offset="50">
      <nav class="navbar navbar-expand-sm fixed-top shadow" style="background-color:#1E90FF">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a class="navbar-brand" href="#"><img src="images/cwc_logo.png" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <ul class="navbar-nav ">
            <li class="nav-item">
                <a class="nav-link" style="  color:#f5f5f5; " href="#">Home</a>
            </li>&nbsp;&nbsp;
            <li class="nav-item">
                <a class="nav-link" style="  color:#f5f5f5;" href="#">About Us</a>
            </li>&nbsp;&nbsp;
            <li class="nav-item">
                <a class="nav-link" style="  color:#f5f5f5;" href="#">Institutions</a>
            </li>&nbsp;&nbsp;
            <li class="nav-item">
                <a class="nav-link" style="  color:#f5f5f5;" href="#">Reports</a>
            </li>&nbsp;&nbsp;
            <li class="nav-item">
                <a class="nav-link" style="  color:#f5f5f5;" href="#">RTI</a>
            </li>&nbsp;&nbsp;
            <li class="nav-item">
                <a class="nav-link" style=" color:#f5f5f5;" href="#">Documents</a>
            </li>&nbsp;&nbsp;
            <li class="nav-item">
                <a class="nav-link" style="  color:#f5f5f5;" href="#">Contact</a>
            </li>

        </ul>
    </nav>
    
    <section class="login-block gradientanimation" style="margin-top:5%; background-color:#F1F3F4">
        <div class="container" style="padding-top:4%;padding-bottom:4%">
            <div class="row">
                <div class="col-md-8 banner-sec">
                    <div id="demo" class="carousel slide" data-ride="carousel">
                        <ul class="carousel-indicators">
                            <li data-target="#demo" data-slide-to="0" class="active"></li>
                            <li data-target="#demo" data-slide-to="1"></li>
                            <li data-target="#demo" data-slide-to="2"></li>
                        </ul>
                        <div class="carousel-inner rounded">
                            <div class="carousel-item active">
                                <img src="https://www.ispartnersllc.com/wp-content/uploads/internal-auditing.jpg" alt="Los Angeles" width="500" height="330">
                                <div class="carousel-caption">
                                    <h3>Los Angeles</h3>
                                    <p>We had such a great time in LA!</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img src="https://www.dvphilippines.com/hubfs/Should%20You%20Outsource%20Your%20Internal%20Audit.png" alt="Chicago" width="500" height="330">
                                <div class="carousel-caption">
                                    <h3>Chicago</h3>
                                    <p>Thank you, Chicago!</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img src="https://www.ispartnersllc.com/wp-content/uploads/auditing-continuous.jpg" alt="New York" width="500" height="330">
                                <div class="carousel-caption">
                                    <h3>New York</h3>
                                    <p>We love the Big Apple!</p>
                                </div>
                            </div>
                        </div>
                        <a class="carousel-control-prev" href="#demo" data-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                        </a>
                        <a class="carousel-control-next" href="#demo" data-slide="next">
                            <span class="carousel-control-next-icon"></span>
                        </a>
                    </div>
                </div>
              <div class="col-md-4 login-sec" style="margin-left:-2.8%;margin-top:-1px">
                    <form class="login-form" runat="server" method="post">
                        <div class="card" action="">
                            <div class="card-body p-6">
                                <div class="card-title" style="border-bottom:solid 3px #1E90FF;"><h6>Login to your account</h6></div>
                                <div class="form-group">
                                <input class="form-control" id="txtUsername" type="text" name="username" placeholder="Username" autocomplete="off" runat="server">
                                <asp:RequiredFieldValidator ID="require" ErrorMessage="Please Fill Out Username"  ForeColor="Red" ControlToValidate="txtUsername" runat="server" />
                            </div>
                            <div class="form-group">
                                <input class="form-control" id="txtPassword" type="password" onchange="return EncryptValue();"  name="pass" placeholder="Password" runat="server">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Fill Out Password"  ForeColor="Red" ControlToValidate="txtPassword" runat="server" />
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
                            <div class="form-group">
                                <asp:Button ID="btnLogin" class="btn btn-primary btn-lg btn-block login-btn" runat="server" Text="Login" OnClick="btnLogin_Click" />&nbsp;&nbsp;
                            </div>
                        </div>
                            </div>
                        </form>
                
                </div>

            </div>
        </div>
    </section>
    <section>
        <div class="container mt-5">
            <h3 class="pt-4 d-inline latest-news" style="border-bottom:solid 3px #1E90FF">Latest News</h3>

            <a href="" class="btn btn-outline-primary btn-circle d-inline float-right">View all</a>
            <!--  <p class="h5 text-center text-muted">Awesome featured templates</p> -->
            <div class="row mt-5">
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <img class="card-img-top" src="images/jelly-pro-3.jpg" alt="">
                        <div class="card-body">
                            <h4 class="card-title mb-3 text-dark">
                                <a href="#" class="text-decoration-none text-dark font-weight-bold">
                                    Title of a blog post
                                </a>
                            </h4>
                            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. </p>

                        </div>
                        <div class="card-footer text-muted border-0 bg-white">

                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <img class="card-img-top" src="images/jelly-pro-2.jpeg" alt="">
                        <div class="card-body">
                            <h4 class="card-title mb-3 text-dark">
                                <a href="#" class="text-decoration-none text-dark font-weight-bold">
                                    Title of a blog post
                                </a>
                            </h4>
                            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. </p>

                        </div>
                        <div class="card-footer text-muted border-0 bg-white">

                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <img class="card-img-top" src="images/jelly-pro-1.jpeg" alt="">
                        <div class="card-body">
                            <h4 class="card-title mb-3 text-dark">
                                <a href="#" class="text-decoration-none text-dark font-weight-bold">
                                    Title of a blog post
                                </a>
                            </h4>
                            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. </p>

                        </div>
                        <div class="card-footer text-muted border-0 bg-white">

                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <img class="card-img-top" src="images/jelly-pro-3.jpg" alt="">
                        <div class="card-body">
                            <h4 class="card-title mb-3 text-dark">
                                <a href="#" class="text-decoration-none text-dark font-weight-bold">
                                    Title of a blog post
                                </a>
                            </h4>
                            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. </p>

                        </div>
                        <div class="card-footer text-muted border-0 bg-white">

                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <img class="card-img-top" src="images/jelly-pro-2.jpeg" alt="">
                        <div class="card-body">
                            <h4 class="card-title mb-3 text-dark">
                                <a href="#" class="text-decoration-none text-dark font-weight-bold">
                                    Title of a blog post
                                </a>
                            </h4>
                            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. </p>

                        </div>
                        <div class="card-footer text-muted border-0 bg-white">

                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <img class="card-img-top" src="images/jelly-pro-1.jpeg" alt="">
                        <div class="card-body">
                            <h4 class="card-title mb-3 text-dark">
                                <a href="#" class="text-decoration-none text-dark font-weight-bold">
                                    Title of a blog post
                                </a>
                            </h4>
                            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. </p>

                        </div>
                        <div class="card-footer text-muted border-0 bg-white">

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="py-5 text-center" style="background-color:Dodgerblue;color:#F5F7FB;">
        <div class="container">
            <h2 class="text-left"  style="border-bottom:solid 3px #1E90FF">Luckmoshy`s Services</h2>
            <p class="mb-5 text-center">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form.</p>
            <div class="row">
                <div class="col-sm-6 col-lg-4 mb-3">
                    <span style="color: #F5F7FB;">
                        <i class="fas fa-camera fa-9x"></i>
                    </span>
                    <h6>Ex cupidatat eu</h6>
                    <p class="">Ex cupidatat eu officia consequat incididunt labore occaecat ut veniam labore et cillum id et.</p>
                </div>
                <div class="col-sm-6 col-lg-4 mb-3">
                    <span style="color: #F5F7FB;">
                        <i class="fas fa-fingerprint fa-9x"></i>
                    </span>
                    <h6>Tempor aute occaecat</h6>
                    <p class="">Tempor aute occaecat pariatur esse aute amet.</p>
                </div>
                <div class="col-sm-6 col-lg-4 mb-3">
                    <span style="color: #F5F7FB;">
                        <i class="fas fa-file-pdf fa-9x"></i>
                    </span>
                    <h6>Voluptate ex irure</h6>
                    <p class="">Voluptate ex irure ipsum ipsum ullamco ipsum reprehenderit non ut mollit commodo.</p>
                </div>

            </div>
        </div>
    </section>
    <br />
    <br />
    <br />
    <div class="col-12">
        <div class="row row-cards row-deck">
            <div class="col-sm-6 col-xl-3">
                <div class="card">
                    <a href="#"><img class="card-img-top" src="https://preview.tabler.io/demo/photos/david-klaasen-54203-500.jpg" alt="And this isn't my nose. This is a false one."></a>
                    <div class="card-body d-flex flex-column">
                        <h6><a href="#">And this isn't my nose. This is a false one.</a></h6>
                        <div class="text-muted">Look, my liege! The Knights Who Say Ni demand a sacrifice! …Are you suggesting that coconuts migr...</div>
                        <div class="d-flex align-items-center pt-5 mt-auto">
                            <div class="avatar avatar-md mr-3" style="background-image: url(https://semantic-ui.com/examples/assets/images/avatar/nan.jpg)"></div>
                            <div>
                                <a href="./profile.html" class="text-default">Rose Bradley</a>
                                <small class="d-block text-muted">3 days ago</small>
                            </div>
                            <div class="ml-auto text-muted">
                                <a href="javascript:void(0)" class="icon d-none d-md-inline-block ml-3"><i class="fe fe-heart mr-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-xl-3">
                <div class="card">
                    <a href="#"><img class="card-img-top" src="https://preview.tabler.io/demo/photos/david-marcu-114194-500.jpg" alt="Well, I didn't vote for you."></a>
                    <div class="card-body d-flex flex-column">
                        <h6><a href="#">Well, I didn't vote for you.</a></h6>
                        <div class="text-muted">Well, we did do the nose. Why? Shut up! Will you shut up?! You don't frighten us, English pig-dog...</div>
                        <div class="d-flex align-items-center pt-5 mt-auto">
                            <div class="avatar avatar-md mr-3" style="background-image: url(https://semantic-ui.com/examples/assets/images/avatar/nan.jpg)"></div>
                            <div>
                                <a href="./profile.html" class="text-default">Peter Richards</a>
                                <small class="d-block text-muted">3 days ago</small>
                            </div>
                            <div class="ml-auto text-muted">
                                <a href="javascript:void(0)" class="icon d-none d-md-inline-block ml-3"><i class="fe fe-heart mr-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-xl-3">
                <div class="card">
                    <a href="#"><img class="card-img-top" src="https://preview.tabler.io/demo/photos/davide-cantelli-139887-500.jpg" alt="How do you know she is a witch?"></a>
                    <div class="card-body d-flex flex-column">
                        <h6><a href="#">How do you know she is a witch?</a></h6>
                        <div class="text-muted">Are you suggesting that coconuts migrate? No, no, no! Yes, yes. A bit. But she's got a wart. You ...</div>
                        <div class="d-flex align-items-center pt-5 mt-auto">
                            <div class="avatar avatar-md mr-3" style="background-image: url(https://semantic-ui.com/examples/assets/images/avatar/nan.jpg)"></div>
                            <div>
                                <a href="./profile.html" class="text-default">Wayne Holland</a>
                                <small class="d-block text-muted">3 days ago</small>
                            </div>
                            <div class="ml-auto text-muted">
                                <a href="javascript:void(0)" class="icon d-none d-md-inline-block ml-3"><i class="fe fe-heart mr-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-xl-3">
                <div class="card">
                    <a href="#"><img class="card-img-top" src="https://preview.tabler.io/demo/photos/dino-reichmuth-84359-500.jpg" alt="Shut up!"></a>
                    <div class="card-body d-flex flex-column">
                        <h6><a href="#">Shut up!</a></h6>
                        <div class="text-muted">Burn her! How do you know she is a witch? You don't frighten us, English pig-dogs! Go and boil yo...</div>
                        <div class="d-flex align-items-center pt-5 mt-auto">
                            <div class="avatar avatar-md mr-3" style="background-image: url(https://semantic-ui.com/examples/assets/images/avatar/nan.jpg)"></div>
                            <div>
                                <a href="./profile.html" class="text-default">Michelle Ross</a>
                                <small class="d-block text-muted">3 days ago</small>
                            </div>
                            <div class="ml-auto text-muted">
                                <a href="javascript:void(0)" class="icon d-none d-md-inline-block ml-3"><i class="fe fe-heart mr-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    
  
    <footer runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <p>Copyright © Digital Team HTML5 Template | Design: <a href="http://www.tooplate.com" target="_parent">Tooplate</a></p>
                    <hr>
                    <ul class="social-icon">
                        <li><a href="#" class="fa fa-facebook wow fadeIn" data-wow-delay="0.3s"></a></li>
                        <li><a href="#" class="fa fa-twitter wow fadeIn" data-wow-delay="0.6s"></a></li>
                        <li><a href="#" class="fa fa-dribbble wow fadeIn" data-wow-delay="0.9s"></a></li>
                        <li><a href="#" class="fa fa-behance wow fadeIn" data-wow-delay="0.9s"></a></li>
                        <li><a href="#" class="fa fa-tumblr wow fadeIn" data-wow-delay="0.9s"></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </footer>


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
