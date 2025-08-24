<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Assignment1.Question2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Select a Product</h1>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                <asp:ListItem Text="-- Select a Product --" Value=""></asp:ListItem>

            </asp:DropDownList>
            <br />
            <asp:Image ID="Image1" runat="server" Width="400px" Height="250px" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Get the Product Price" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="LabelPrice" runat="server" Text="Label" ForeColor="#FF0066"></asp:Label>
        </div>
    </form>
</body>
</html>
