<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true" CodeBehind="project_subcontractor_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_subcontractor_add" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 660px">
        <!-- Table element : 3 columns -->
        <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;">
            <tr>
                <td style="width: 220px">
                    <asp:Label id="lblSubcontractorId" runat="server" EnableViewState="False" Text="Client" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 220px">
                </td>
                <td style="width: 220px">
                    <asp:Label id="lblRoyalties" runat="server" EnableViewState="False" Text="Royalties (%)" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlSubcontractorId" runat="server" SkinID="DropDownList" Width="210px">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="tbxRoyalties" runat="server" SkinID="TextBox" Width="210px" EnableViewState="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSubcontractorId" runat="server" ControlToValidate="ddlSubcontractorId"
                        Display="Dynamic" ErrorMessage="Please select a Sub-Contractor" InitialValue="-1"
                        SkinID="Validator" EnableViewState="False"></asp:RequiredFieldValidator></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="lblSubcontractorWrittenQuote" runat="server" EnableViewState="False" Text="Has he provided a written quote?" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label id="lblSubcontractorSurveyedSite" runat="server" EnableViewState="False" Text="Has he surveyed the site?" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label id="lblSubcontractorWorkedBefore" runat="server" EnableViewState="False" Text="Have we worked before?" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxSubcontractorWrittenQuote" runat="server" SkinID="CheckBox" Text="Yes" EnableViewState="False"/>
                </td>
                <td>
                    <asp:CheckBox ID="cbxSubcontractorSurveyedSite" runat="server" SkinID="CheckBox" Text="Yes" EnableViewState="False"/>
                </td>
                <td>
                    <asp:CheckBox ID="cbxSubcontractorWorkedBefore" runat="server" SkinID="CheckBox" Text="Yes" EnableViewState="False"/>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label id="lblSubcontractorRole" runat="server" EnableViewState="False" Text="Explain the role of the sub-contractor" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="tbxSubcontractorRole" runat="server" Height="44px" SkinID="TextBox" TextMode="MultiLine" Width="650px" EnableViewState="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label id="lblSubcontractorAgreement" runat="server" EnableViewState="False" Text="Has a Sub-Contractor agreement been issued to Sub’s?" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxSubcontractorAgreement" runat="server" SkinID="CheckBox" Text="Yes" EnableViewState="False"/>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label id="lblSubcontractorIssues" runat="server" EnableViewState="False" Text="Issues with Sub?" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="tbxSubcontractorIssues" runat="server" Height="44px" SkinID="TextBox" TextMode="MultiLine" Width="650px" EnableViewState="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="lblSubcontractorPurchaseOrder" runat="server" EnableViewState="False" Text="Is Purchase Order included?" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label id="lblSubcontractorInsuranceCertificate" runat="server" EnableViewState="False" Text="Is Sub Insurance Certificate included?" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label id="lblSubcontractorWSIB" runat="server" EnableViewState="False" Text="Is Sub WSIB included?" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxSubcontractorPurchaseOrder" runat="server" SkinID="CheckBox" Text="Yes" EnableViewState="False"/>
                </td>
                <td>
                    <asp:CheckBox ID="cbxSubcontractorInsuranceCertificate" runat="server" SkinID="CheckBox" Text="Yes" EnableViewState="False"/>
                </td>
                <td>
                    <asp:CheckBox ID="cbxSubcontractorWSIB" runat="server" SkinID="CheckBox" Text="Yes" EnableViewState="False"/>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label id="lblSubcontractorMOLForm1000" runat="server" EnableViewState="False" Text="Is MOL Form 1000 from Sub included?" SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox id="tbxSubcontractorMOLForm1000" runat="server" SkinID="TextBoxReadOnly" Width="110px" ReadOnly="True" Text='NA' EnableViewState="False"></asp:TextBox>
                    <asp:DropDownList ID="ddlSubcontractorMOLForm1000" runat="server" SkinID="DropDownList" Width="110px">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>            
        </table>
        <!-- Page element : Tag page -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                </td>
            </tr>
		</table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 660;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 90px">
                    <asp:Button ID="btnAdd" runat="server" Height="22px" SkinID="Button" Text="Add" Width="80px" EnableViewState="False" OnClick="btnAdd_Click" OnClientClick="btnAddClick();" />
                </td>
                <td style="width: 490px">
                </td>
                <td style="width: 80px">
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="btnCancelClick()" SkinID="Button" Text="Cancel" Width="80px" EnableViewState="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
