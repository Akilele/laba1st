<%@ Page Title="Редактирование" Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="laba1.Editor" %>
<form id="form3" runat="server">
    <p><asp:label runat="server" text="ФИО: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 175px" id="fio"></asp:textbox></p>
    <p><asp:label runat="server" text="Номер читательского билета: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 17px" id="number"></asp:textbox></p>
    <p><asp:label runat="server" text="Дата рождения: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 110px" Width="144px" id="date"></asp:textbox></p>
    <p><asp:label runat="server" text="Пол: "></asp:label>
    <asp:DropDownList ID="gender" runat="server" Height="20px" style="margin-left: 185px" Width="143px">
            <asp:ListItem Value="0">Женский</asp:ListItem>
            <asp:ListItem Value="1">Мужской</asp:ListItem>
        </asp:DropDownList></p>
    <asp:button runat="server" ID="apply" text="Применить" OnClick="apply_Click" />
    <asp:button runat="server" ID="default" text="Список посетителей" OnClick="default_Click" />
</form>