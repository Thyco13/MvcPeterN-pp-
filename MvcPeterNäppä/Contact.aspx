<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MvcPeterNäppä.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Pretend contact Info to Me Peter.</h3>
    <address>
        Gatan 123<br />
        97795 Luleå<br />
        <abbr title="Phone">P:</abbr>
        070-1234567
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">PeterMVCSupport@example.com</a><br />
        
    </address>
</asp:Content>
