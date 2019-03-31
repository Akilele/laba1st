<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="laba1._Default" %>
<form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"> 
        <Columns>
            <asp:BoundField runat="server" DataField="id" HeaderText="id"/>
            <asp:BoundField runat="server" DataField="fio" HeaderText="ФИО"/> 
            <asp:BoundField runat="server" DataField="ticket_number" HeaderText="Номер читательского билета"/> 
            <asp:BoundField runat="server" DataField="birth" HeaderText="Дата рождения"/> 
            <asp:BoundField runat="server" DataField="gender" HeaderText="Пол"/> 
            <asp:ButtonField CommandName="history" Text="История обращений" />
            <asp:ButtonField CommandName="remove" Text="Удалить" />
            <asp:ButtonField CommandName="change" Text="Редактировать" />
        </Columns> 
    </asp:GridView>
    <asp:button runat="server" ID="create" text="Создать" OnClick="create_Click" />
    <asp:button runat="server" ID="all_history" text="История обращений всех читателей" OnClick="all_history_Click1" />
</form>