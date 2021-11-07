<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="Latihan1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DataGrid ID="DGR_USERS" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanged="DGR_USERS_PageIndexChanged" OnItemCommand="DGR_USERS_ItemCommand">
            <HeaderStyle BackColor="LightBlue" />
            <PagerStyle Mode="NextPrev"></PagerStyle>
            <Columns>
                <asp:TemplateColumn HeaderText="CODE">
                    <ItemTemplate>
                        <asp:LinkButton ID="LB_PRODUCT_CD" runat="server" CommandName="Edit" ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="PRODUCT_CD" HeaderText="CODE" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="NAME" HeaderText="PRODUCT NAME"></asp:BoundColumn>
                <asp:BoundColumn DataField="PRODUCT_TYPE_CD" HeaderText="TYPE"></asp:BoundColumn>
                
            </Columns>
        </asp:DataGrid>

        <table>
            <tr>
                <td><asp:Label ID="LB_CD" runat="server">CODE</asp:Label></td>
                <td><asp:TextBox ID="TXT_CD" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="LB_NAME" runat="server">NAME</asp:Label></td>
                <td><asp:TextBox ID="TXT_NAME" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        
        <asp:Button ID="BT_SAVE" Text="SAVE" runat="server" OnClick="BT_SAVE_Click"/>
    </form>
</body>
</html>
