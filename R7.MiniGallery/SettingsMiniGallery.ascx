<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsMiniGallery.ascx.cs" Inherits="R7.MiniGallery.SettingsMiniGallery" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>

<style type="text/css">
.MG_Settings .comboTarget { float:left;width:100px }
.MG_Settings .textTarget { float:left;width:310px!important;margin-left:10px }
</style>

<div class="dnnForm dnnClear MG_Settings">
	
	<h2 class="dnnFormSectionHead"><a href="" ><asp:Label runat="server" ResourceKey="sectionBaseSettings.Text" /></a></h2>
	<fieldset>
		<div class="dnnFormItem">
			<dnn:Label id="labelStyleSet" runat="server" controlname="textStyleSet" suffix=":" />
			<asp:TextBox id="textStyleSet" runat="server" CssClass="NormalTextBox" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelMaxHeight" runat="server" controlname="textMaxHeight" suffix=":" />
			<asp:TextBox id="textMaxHeight" runat="server" CssClass="NormalTextBox" />
			<asp:RangeValidator id="valMaxHeight" ControlToValidate="textMaxHeight" MinimumValue="-1" /> 
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelImageWidth" runat="server" controlname="textImageWidth" suffix=":" />
			<asp:TextBox id="textImageWidth" runat="server" CssClass="NormalTextBox" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelImageHeight" runat="server" controlname="textImageHeight" suffix=":" />
			<asp:TextBox id="textImageHeight" runat="server" CssClass="NormalTextBox" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelTarget" runat="server" controlname="comboTarget" suffix=":" />
			<dnn:DnnComboBox id="comboTarget" runat="server" CssClass="comboTarget" />
			<asp:TextBox id="textTarget" runat="server" CssClass="textTarget" />
	   	</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelUseLightbox" runat="server" controlname="checkUseLightbox" suffix="?" />
			<asp:CheckBox id="checkUseLightbox" runat="server" />
		</div>
		<!--
		<div class="dnnFormItem">
			<dnn:Label id="labelUseScrollbar" runat="server" controlname="checkUseScrollbar" suffix="?" />
			<asp:CheckBox id="checkUseScrollbar" runat="server" Enabled="false" />
		</div>
		-->
		<div class="dnnFormItem">
			<dnn:Label id="labelShowTitles" runat="server" controlname="checkShowTitles" suffix="?" />
			<asp:CheckBox id="checkShowTitles" runat="server" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelColumns" runat="server" controlname="comboColumns" suffix=":" />
			<dnn:DnnComboBox id="comboColumns" runat="server" />
			<%-- <asp:DropDownList ID="ddlColumns" runat="server" Style="width:120px" /> --%>
			<%-- <b> x </b> 
			<asp:DropDownList ID="ddlRows" runat="server" Style="width:100px" /> --%>
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelExpand" runat="server" controlname="checkExpand" suffix="?" />
			<asp:CheckBox id="checkExpand" runat="server" />
		</div>
		<%--
		<div class="dnnFormItem">
			<dnn:Label id="labelRows" runat="server" controlname="ddlRows" suffix=":" />
			
	   	</div>--%>
		<div class="dnnFormItem">
			<dnn:Label id="labelNumberOfRecords" runat="server" controlname="textNumberOfRecords" suffix=":" />
			<asp:TextBox id="textNumberOfRecords" runat="server" CssClass="NormalTextBox" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelSortOrder" runat="server" controlname="checkSortOrder" suffix=":" />
			<asp:CheckBox id="checkSortOrder" runat="server" />
		</div>

	</fieldset>
	
	<h2 class="dnnFormSectionHead"><a href="" ><asp:Label runat="server" ResourceKey="ImageHandler.Section" /></a></h2>
	<fieldset>
		<div class="dnnFormItem" style="margin-bottom:15px">
			<dnn:Label id="labelUseImageHandler" runat="server" controlname="checkUseImageHandler" suffix="?" />
			<asp:CheckBox id="checkUseImageHandler" runat="server" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelImageHandlerParams" runat="server" controlname="textImageHandlerParams" suffix=":" />
			<asp:TextBox id="textImageHandlerParams" runat="server" Style="font-family:Monospace" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelThumbWidth" runat="server" controlname="textThumbWidth" suffix=":" />
			<asp:TextBox id="textThumbWidth" runat="server" CssClass="NormalTextBox" />
		</div>
		<div class="dnnFormItem">
			<dnn:Label id="labelThumbHeight" runat="server" controlname="textThumbHeight" suffix=":" />
			<asp:TextBox id="textThumbHeight" runat="server" CssClass="NormalTextBox" />
		</div>
	</fieldset>

	<h2 class="dnnFormSectionHead"><a href="" ><asp:Label runat="server" ResourceKey="sectionHeader.Text" /></a></h2>
	<fieldset>
		<div class="dnnFormItem">
			<div class="dnnLabel"></div>
			<dnn:TextEditor id="editorHeader" runat="server" height="300" HtmlEncode="false" />
		</div>
	</fieldset>
	
	<h2 class="dnnFormSectionHead"><a href="" ><asp:Label runat="server" ResourceKey="sectionFooter.Text" /></a></h2>
	<fieldset>
		<div class="dnnFormItem">
			<div class="dnnLabel"></div>
			<dnn:TextEditor id="editorFooter" runat="server" height="300" HtmlEncode="false" />
		</div>
	</fieldset>
	
	<div class="dnnFormItem"></div>
	
</div>