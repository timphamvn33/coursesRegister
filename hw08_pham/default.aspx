<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="hw08_pham._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW8-Tim Pham</title>
    <style type="text/css">
        .auto-style1 {
            width: 301px;
        }
        .auto-style2 {
            height: 194px;
        }
        .auto-style3 {
            width: 301px;
            height: 194px;
        }
        </style>
</head>
<body>

    <form id="form1" runat="server">
        <a href="\">Home</a>
         <h1>Course register System</h1>
        <asp:CheckBoxList ID="extraCost" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1000">Dom</asp:ListItem>
                <asp:ListItem Value="500">Meal Plan</asp:ListItem>
                <asp:ListItem Value="50">Football Tixs</asp:ListItem>
         </asp:CheckBoxList>
        <table>
            <tr>
                <td>Available Classes</td>
                <td>Registerd Classes</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:ListBox ID="lbxAvailableClasses" runat="server" Height="213px" Width="128px"></asp:ListBox>
                </td>
                <td class="auto-style3">
                    <asp:Button ID="addButton" runat="server" Text="Add" OnClick="AddButton_Click" /><br/>
                    <asp:Button ID="removeButton" runat="server" Text="Remove" OnClick="removeButton_Click" /><br/>
                    <asp:Button ID="resetButton" runat="server" Text="Reset" OnClick="resetButton_Click" /><br/>
                
                   <asp:Label ID="lblHours"  runat="server" Text="Label" >Total Hours: </asp:Label><br />
                    <asp:Label ID="lblCost"  runat="server" Text="Label">Total Cost: </asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:ListBox ID="lbxRegisterClasses"  runat="server" Height="190px" Width="128px"></asp:ListBox>
                </td>
            </tr>
        </table>
        <asp:Label ID="error" runat="server" Text="" Style="color:red" ></asp:Label>
        <table>
            <tr>
                <td>Class Number: <asp:TextBox ID="classNumber" runat="server"></asp:TextBox> </td>
                
                <td>Credit: <asp:TextBox ID="creditNumber" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button3" runat="server" Text="Make Available" OnClick="Button3_Click" /></td>
                <td><asp:Button ID="Button4" runat="server" Text="Remove From Available" OnClick="Button4_Click" /></td>
            </tr>
        </table>
        <asp:Label ID="error2" runat="server" Text="" Style="color:red" Visible="False"></asp:Label>
        
        
        
        </form>
</body>
</html>
