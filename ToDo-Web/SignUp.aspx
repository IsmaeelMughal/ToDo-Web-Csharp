<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ToDo_Web.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My ToDo List</title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
</head>
<body>
    <div class="container"> 
        <h1 class="text-center">SignUp Form</h1>
        <form id="signUpForm" class="container" runat="server">
             <div class="mb-3">
                <label for="signupNicknameTextBox" class="form-label">Nickname</label>
                <asp:TextBox CssClass="form-control" ID="signupNicknameTextBox" runat="server" OnTextChanged="signupNicknameTextBox_TextChanged"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="signupEmailTextbox" class="form-label">Email address</label>
                <asp:TextBox CssClass="form-control" ID="signupEmailTextbox" runat="server" OnTextChanged="signupNicknameTextBox_TextChanged"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="signupPasswordTextbox" class="form-label">Password</label>
                <asp:TextBox CssClass="form-control" ID="signupPasswordTextbox" runat="server" OnTextChanged="signupNicknameTextBox_TextChanged" ></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="signupConfirmPasswordTextbox" class="form-label">Confirm Password</label>
                <asp:TextBox CssClass="form-control" ID="signupConfirmPasswordTextbox" runat="server" OnTextChanged="signupNicknameTextBox_TextChanged"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="toLoginLbl" class="form-label">Alredy Have an Account?</label>
                <asp:Button CssClass="btn btn-dark" ID="toLoginLbl" runat="server" Text="Login" OnClick="toLoginLbl_Click"></asp:Button>
            </div>
            <asp:Button ID="signUpBtn" CssClass="btn btn-dark" runat="server" Text="Signup" OnClick="signUpBtn_Click"></asp:Button>
            <asp:Label ID="errorLbl" CssClass="text-danger fw-bold" runat="server" Visible="False"></asp:Label>
        </form>
  </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
</body>
</html>
