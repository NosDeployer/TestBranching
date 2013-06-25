<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="jl_tobuild_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.jl_tobuild_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblClient" runat="server" Text="Client" SkinID="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel id="upnlClient" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                        <asp:dropdownlist id="ddlClient" SkinID="DropDownList" tabIndex="1" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
			            </asp:dropdownlist>
			        </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td height="7" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblProject" runat="server" Text="Project" SkinID="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel id="upnlProject" runat="server">
                    <contenttemplate>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 160px">
                            <asp:DropDownList ID="ddlProject" SkinID="DropDownList" TabIndex="2" runat="server" Width="160px">
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
            <td style="height: 7px" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="cbxAutoFillLinerOrdered" runat="server" SkinID="CheckBox" Text="Autofill Liner In Process"
                    EnableViewState="False"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td style="width: 19px;">
            
            </td>
            <td>
                <asp:Label ID="lblToBeUsedByOfficeOnly" runat="server" EnableViewState="False" SkinID="Label">(to be used by office only)
                </asp:Label></td>

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
