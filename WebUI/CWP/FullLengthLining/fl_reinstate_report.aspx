<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="fl_reinstate_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_reinstate_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:RadioButton ID="rbtnSectionId" runat="server" SkinID="RadioButton" Text="Section ID" GroupName="m1Report" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxSectionId" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbtnClient" runat="server" SkinID="RadioButton" Text="Client" GroupName="m1Report" Checked="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" Text="Client" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:dropdownlist id="ddlClient" SkinID="DropDownList" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
				            </asp:dropdownlist>
				        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" Text="Project" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlProject" runat="server">
                        <contenttemplate>
                            <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 160px">
                                <asp:DropDownList ID="ddlProject" SkinID="DropDownList" runat="server" Width="160px">
                                </asp:DropDownList>
                            </TD><TD style="VERTICAL-ALIGN: middle"><asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                            <ProgressTemplate>
                                <asp:Image id="imAjax" runat="server" skinId="Ajax_Grey"></asp:Image> 
                            </ProgressTemplate>
                            </asp:UpdateProgress> </TD></TR></TBODY></TABLE>
                        </contenttemplate>
                        <triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUnitType" runat="server" Text="Unit Type" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:dropdownlist id="ddlUnitType" SkinID="DropDownList" runat="server" Width="160px">
				        <asp:ListItem Text="Imperial" Value="Imperial" Selected="True"></asp:ListItem>
				        <asp:ListItem Text="Metric" Value="Metric"></asp:ListItem>
				    </asp:dropdownlist>
                </td>
            </tr>
        </table>
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
