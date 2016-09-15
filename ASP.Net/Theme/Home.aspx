<%@ Page Language="C#" MasterPageFile="~/Master1.master" Title="Themes sample" StylesheetTheme="Blue" %>

<script runat="server">   
  public void Page_PreInit()
   {
        // Sets the Theme for the page.
        this.Theme = "Blue";
        if (Request.Form != null && Request.Form.Count > 0)
            this.Theme = this.Request.Form[5].Trim();
    } 
</script>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 id="title1">Switchable Themes on a Page</h1><br />
    <h2 id="title2">Note how the master page content and the page content are affected</h2>
    <p>Select a color from the drop-down list below to change the appearance of this page.</p>
    <br /><br />
    <asp:dropdownlist id="ddlThemes" runat="server" autopostback="true" >
        <asp:listitem value="Blue">I'd like the page to be blue!</asp:listitem>
        <asp:listitem value="Red">I'd like the page to be red!</asp:listitem>
        <asp:listitem value="Green">I'd like the page to be green!</asp:listitem>
    </asp:dropdownlist>
</asp:Content>

