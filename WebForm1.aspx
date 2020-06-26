<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="excel.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
 <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <link rel="stylesheet" href="css/mdb.min.css" />
    <link rel="stylesheet" href="css/mdb.min.css.map" />
    <title>Webssite|Analyzer</title>
    <style>
        .avatar-pic {
            width: 150px;
        }
        
        .row img {
            width: 200px;
            margin: auto;
        }
        </style>
</head>

<body><form runat="server">

    <!-- Header Section -->
    <nav class=" navbar navbar-expand-lg navbar-light" style=" background-color: rgb(48, 226, 137);">

        <a class="navbar-brand " href="# "><img src="ms.png" height="42" width="100" /></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333">
      <span class="navbar-toggler-icon"></span>
    </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent-333">
            <ul class="navbar-nav mr-auto ">
                <li class="nav-item active ">
                    <a class="nav-link " href="# ">Home
            <span class="sr-only ">(current)</span>
          </a>
                </li>
                <li class="nav-item ">
                    <a class="nav-link " href="# ">Features</a>
                </li>
                <li class="nav-item ">
                    <a class="nav-link " href="# ">Pricing</a>
                </li>
                <li class="nav-item dropdown ">
                    <a class="nav-link dropdown-toggle" id="navbarDropdownMenuLink-333" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dropdown
          </a>
                    <div class="dropdown-menu dropdown-default " aria-labelledby="navbarDropdownMenuLink-333 ">
                        <a class="dropdown-item " href="# ">Action</a>
                        <a class="dropdown-item " href="# ">Another action</a>
                        <a class="dropdown-item " href="# ">Something else here</a>
                    </div>
                </li>
            </ul>

        </div>
    </nav>
    <div class="alert alert-success alert-dismissible fade show my-0" role="alert">
        <strong>Website Analyzer! Anytime! Anywhere!</strong> Check whether your website is working or not.<br />
        <strong> Just provide the name of urls in first column of your excel and name the second and third column as Website Status and Website Status Code.</strong>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
    </div>
    <br>
    <br>
            <!-- ADD A GRIDVIEW CONTROL. -->
            <div>
                <asp:GridView ID="GridView1"  class="mx-auto" CssClass="Grid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="243px" style="margin: auto;" Width="598px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                
             
            </div>
    <asp:Button ID="Button1" class="btn btn-success text-center"  style="margin-left:600px;" runat="server" Text="Download" OnClick="Button1_Click" />
     
    </form>
        <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" ></script>
</body>
</html>
