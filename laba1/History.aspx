<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="laba1._History" %>
<form id="form2" runat="server">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand"> 
        <Columns>
            <asp:BoundField runat="server" DataField="id" HeaderText="id"/>
            <asp:BoundField runat="server" DataField="id_visitor" HeaderText="id Посетителя"/>
            <asp:BoundField runat="server" DataField="date" HeaderText="Дата обращения"/> 
            <asp:BoundField runat="server" DataField="book_name" HeaderText="Название книги"/> 
            <asp:BoundField runat="server" DataField="code" HeaderText="Уникальный код книги"/> 
            <asp:BoundField runat="server" DataField="author" HeaderText="Автор книги"/> 
            <asp:BoundField runat="server" DataField="age" HeaderText="Дата возраста"/> 
            <asp:ButtonField CommandName="change" Text="Редактировать" />
            <asp:ButtonField CommandName="remove" Text="Удалить" />
        </Columns> 
    </asp:GridView>
    <asp:button runat="server" ID="create" text="Создать" OnClick="create_Click" />
    <asp:button runat="server" ID="list" text="Список посетителей" OnClick="list_Click" />
</form>