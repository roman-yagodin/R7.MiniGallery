<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewMiniGallery.ascx.cs" Inherits="R7.MiniGallery.ViewMiniGallery" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnJsInclude id="includeLightboxJs" runat="server" />
<dnn:DnnCssInclude id="includeLightboxCss" runat="server" />
<asp:Literal id="literalLightboxScript" runat="server" Mode="PassThrough" />

<asp:DataList id="listImages" DataKeyField="ImageID" runat="server" CssClass="MG_List"
	RepeatLayout="Flow" RepeatDirection="Horizontal" OnItemDataBound="listImages_ItemDataBound">
	<ItemTemplate>
		<asp:HyperLink id="linkEdit" runat="server" Visible="<%# IsEditable %>">
			<asp:Image id="imageEdit" runat="server" ImageUrl="<%# EditIconUrl %>" Visible="<%# IsEditable %>" ResourceKey="Edit" CssClass="MG_Edit" />
		</asp:HyperLink>
		<asp:HyperLink id="linkImage" runat="server">
			<asp:Image id="imageImage" runat="server" CssClass="MG_Image" />
		</asp:HyperLink>
		<%-- <asp:Label id="labelTitle" runat="server" CssClass="MG_Title" /> --%>
		<%-- <asp:Label id="labelInfo" runat="server" /> --%>
	</ItemTemplate>
	<ItemStyle CssClass="MG_Item" />
	<AlternatingItemStyle CssClass="MG_AltItem" />
</asp:DataList>
