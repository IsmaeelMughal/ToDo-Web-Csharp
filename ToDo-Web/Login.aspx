<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ToDo_Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> My ToDo List</title>

    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
</head>
<body>
    <div class="container">
        <h1 class="text-center">Login Form</h1>
        <form id="loginForm" class="container" runat="server">
            <div class="mb-3">
                <label for="LoginEmailTextbox" class="form-label">Email address</label>
                <asp:TextBox CssClass="form-control" ID="LoginEmailTextbox" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="LoginPasswordTextbox" class="form-label">Password</label>
                <asp:TextBox CssClass="form-control" ID="LoginPasswordTextbox" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="toSignupLbl" class="form-label">Need an Account?</label>
                <asp:Button CssClass="btn btn-dark" ID="toSignupLbl" runat="server" Text="SignUp" OnClick="toSignupLbl_Click"></asp:Button>
            </div>
            <asp:Button ID="loginBtn" CssClass="btn btn-dark" runat="server" Text="Login" OnClick="loginBtn_Click"></asp:Button>
            <asp:Label ID="errorLbl" CssClass="text-danger fw-bold" runat="server" Visible="False"></asp:Label>
        </form>
  </div>

    <!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
</body>
</html>
