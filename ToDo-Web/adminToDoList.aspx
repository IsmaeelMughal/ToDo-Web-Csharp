<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminToDoList.aspx.cs" Inherits="ToDo_Web.adminToDoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My ToDo List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
</head>
<body>
    <div class="container"> 
        <h1 class="text-center">Admin DashBoard</h1>
        <form id="adminForm" runat="server">
            <div class="row">
                <div class="col-md-8">
                    <div class="mb-3">
                        <label for="titleTextbox" class="form-label">Title</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="titleTextbox" ></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="descriptionTextbox" class="form-label">Description</label>
                        <asp:TextBox CssClass="form-control" Height="100px" ID="descriptionTextbox" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="usersCombobox" class="form-label">Available Users</label>
                        <asp:DropDownList CssClass="form-control" ID="usersCombobox" runat="server" OnSelectedIndexChanged="usersCombobox_SelectedIndexChanged" OnTextChanged="usersCombobox_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="col d-flex justify-content-center align-items-center flex-column">
                    <asp:Button type="submit" CssClass="btn btn-dark mx-3 my-3" Width="100px" ID="addBtn" runat="server" Text="ADD" OnClick="addBtn_Click" ></asp:Button>
                    <asp:Button type="submit" CssClass="btn btn-dark mx-3 my-3" Width="100px" ID="updateBtn" runat="server" Text="UPDATE" OnClick="updateBtn_Click" ></asp:Button>
                    <asp:Button type="submit" CssClass="btn btn-dark mx-3 my-3" Width="100px" ID="deleteBtn" runat="server" Text="DELETE" OnClick="deleteBtn_Click" ></asp:Button>
                    <asp:Button type="submit" CssClass="btn btn-dark mx-3 my-3" Width="100px" ID="SignOutButton" runat="server" Text="SignOut" OnClick="SignOutButton_Click"></asp:Button>
                    <asp:Label ID="errorLbl" CssClass="text-danger fw-bold" runat="server" Visible="False"></asp:Label>
                </div>
            </div>
        </form>
        <div class="row">
            <h1 class="text-center">All Tasks</h1>
            <table class="table table-striped mt-3">
                <thead>
                  <tr class="bg-dark text-light">
                    <th>Title</th>
                    <th>Description</th>
                    <th>User</th>
                  </tr>
                </thead>
                <tbody>
                    <% foreach(var task in todos){ %>
                            <tr>
                                 <td ><%= task.Title %></td> 
                                 <td><%= task.Description %></td> 
                                 <td><%= task.UserEmail %></td> 
                            </tr>
                       <% } %>
                </tbody>
            </table>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
</body>
</html>

