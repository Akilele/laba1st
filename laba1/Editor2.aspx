<%@ Page Title="Редактирование" Language="C#" AutoEventWireup="true" CodeBehind="Editor2.aspx.cs" Inherits="laba1.Editor2" %>
<form id="form3" runat="server">
    <p><asp:label runat="server" text="id посетителя: "></asp:label>
     <asp:dropdownlist id="visitor" runat="server"></asp:dropdownlist></p>
    <!--<asp:textbox runat="server" style="margin-left: 175px" id="id_visitor"></asp:textbox></p>-->
    <p><asp:label runat="server" text="Дата посещения: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 0px" id="date"></asp:textbox></p>
    <p><asp:label runat="server" text="Название книги: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 5px" Width="140px" id="book_name"></asp:textbox></p>
    <p><asp:label runat="server" text="Код книги: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 42px" Width="141px" id="code"></asp:textbox></p>
    <p><asp:label runat="server" text="Автор книги: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 25px" Width="144px" id="author"></asp:textbox></p>
    <p><asp:label runat="server" text="Возраст книги: "></asp:label>
    <asp:textbox runat="server" style="margin-left: 16px" Width="144px" id="age"></asp:textbox></p>
    <asp:button runat="server" ID="apply" text="Применить" OnClick="apply_Click" />
    <asp:button runat="server" ID="history" text="История обращений всех читателей" OnClick="history_Click" />
</form>