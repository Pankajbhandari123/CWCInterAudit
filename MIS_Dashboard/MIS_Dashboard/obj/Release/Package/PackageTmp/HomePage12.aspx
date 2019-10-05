<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage12.aspx.cs" Inherits="MIS_Dashboard.HomePage12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <style>
body {
  margin: 0;
  font-size: 28px;
  font-family: Arial, Helvetica, sans-serif;
}

.header {
  background-color: #f1f1f1;
  padding: 30px;
  text-align: center;
}

#navbar {
  overflow: hidden;
  background-color: #0aab8a;
}

#navbar a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

#navbar a:hover {
  background-color: #ddd;
  color: black;
}

#navbar a.active {
  background-color: #0aab8a;
  color: white;
}

.content {
  padding: 16px;
}

.sticky {
  position: fixed;
  top: 0;
  width: 100%;
}

.sticky + .content {
  padding-top: 60px;
}
</style>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>

<script>
    window.jQuery || document.write('<script src="http://mysite.com/jquery.min.js"><\/script>')
</script>
    <script>
        $('.carousel').carousel({
            interval: 6000,
            pause: "false"
        });
    </script>

    <style>
        h5 {
  display: inline-block;
  padding: 10px;
  background: #B9121B;
  border-top-left-radius: 10px;
  border-top-right-radius: 10px;
}

.full-screen {
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}
    </style>
</head>
<body>

<div id="navbar">
 <div class="container">

                <div class="navbar-header">
                    <a href="#" target="_blank">
                        <img class="img-responsive" src="cwc_logo.png" style="margin-top: 1px; height: 50px;" /></a>
                </div>

                <div class="collapse navbar-collapse" align="center">
                    <ul class="nav navbar-nav navbar-right">
                        <h3><span class="smoothScroll" style="color: #fff">CWC Performance Dashboard</span></h3>
                       
                    </ul>
                </div>
            </div>
</div>
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
  </ol>
  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src="https://images.unsplash.com/photo-1432958576632-8a39f6b97dc7?ixlib=rb-0.3.5&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=400&fit=max&ixid=eyJhcHBfaWQiOjE0NTg5fQ&s=6ecedc1e639d8a4b77aa8e85f4962f03" data-color="lightblue" alt="First Image">
      <div class="carousel-caption d-md-block">
        <h5>First Image</h5>
      </div>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="https://images.unsplash.com/photo-1504736038806-94bd1115084e?ixlib=rb-0.3.5&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=400&fit=max&ixid=eyJhcHBfaWQiOjE0NTg5fQ&s=3d045bbf1ecc01c4c9ec011ce5c8977d" data-color="firebrick" alt="Second Image">
      <div class="carousel-caption d-md-block">
        <h5>Second Image</h5>
      </div>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="https://images.unsplash.com/photo-1419064642531-e575728395f2?ixlib=rb-0.3.5&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=400&fit=max&ixid=eyJhcHBfaWQiOjE0NTg5fQ&s=76d5c793e4f8d02d7a9be27bc71256f7" data-color="violet" alt="Third Image">
      <div class="carousel-caption d-md-block">
        <h5>Third Image</h5>
      </div>
    </div>
  </div>
  <!-- Controls -->
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
<span class="carousel-control-prev-icon" aria-hidden="true"></span>
<span class="sr-only">Previous</span>
</a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
<span class="carousel-control-next-icon" aria-hidden="true"></span>
<span class="sr-only">Next</span>
</a>
</div>
    <div class="container-fluid" align="center">
                <div class="row" style="height: 40px;">
                    <div class="col-lg-12" style="background-color: #45484d; left:0; position:  fixed ;bottom:0; right:0; height: 40px;">
                        <p style="color: #fff; margin-top: 10px;" class="text-center">Copyright 2019 © VCS Pvt. Ltd.</p>
                    </div>
                </div>
            </div>

<script>
    window.onscroll = function () { myFunction() };

    var navbar = document.getElementById("navbar");
    var sticky = navbar.offsetTop;

    function myFunction() {
        if (window.pageYOffset >= sticky) {
            navbar.classList.add("sticky")
        } else {
            navbar.classList.remove("sticky");
        }
    }
</script>
</body>
</html>
