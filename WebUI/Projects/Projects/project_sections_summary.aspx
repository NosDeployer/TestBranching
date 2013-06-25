<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true"
    Codebehind="project_sections_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_sections_summary"
    Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <!-- Content -->
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblSectionId" runat="server" EnableViewState="False" SkinID="Label"
                        Text="ID (Section)" />
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxSectionId" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Width="140px">
                    </asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="5">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalLaterals" runat="server" EnableViewState="false" SkinID="Label"
                        Text="Total Laterals"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Width="290px">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxTotalLaterals" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Width="140px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="5">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="USMH"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="laterals" runat="server" EnableViewState="False" Text="Laterals" SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Width="140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Width="140px"></asp:TextBox>
                </td>
                <td colspan="3" rowspan="5" style="vertical-align: top;">
                    <asp:UpdatePanel id="upnlLateralsNavigator" runat="server">
                        <contenttemplate>
                            <asp:GridView ID="grdLateralsNavigator" runat="server" SkinID="GridView" Width="100%"
                                AutoGenerateColumns="False" PageSize="4" OnDataBound="grdLateralsNavigator_DataBound"
                                AllowPaging="true" DataSourceID="odsLateralNavigator" DataKeyNames="AssetID">
                                <Columns>
                                    <asp:TemplateField HeaderText="Lateral ID">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Width="96px" Wrap="False"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLateralId" runat="server" SkinID="Label" Text='<%# Bind("LateralID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MN#">
                                        <ItemStyle Wrap="False"></ItemStyle>
                                        <HeaderStyle Width="121px"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" SkinID="Label" Text='<%# Bind("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemStyle Wrap="False"></ItemStyle>
                                        <HeaderStyle Width="96px"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblState" runat="server" SkinID="Label" Text='<%# Bind("State") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In Project">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Width="96px"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbxInProject" onclick="return cbxClick();" runat="server"
                                                SkinID="CheckBox" Checked='<%# Eval("InProject") %>'></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    </contenttemplate> </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblWorks" runat="server" EnableViewState="False" SkinID="Label" Text="Works"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ckbxRehabAssessment" runat="server" SkinID="CheckBox" Text="Rehab Assessment"
                                    onclick="return cbxClick();" EnableViewState="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ckbxFullLengthLining" runat="server" SkinID="CheckBox" Text="Full Length Lining"
                                    onclick="return cbxClick();" EnableViewState="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ckbxJunctionLining" runat="server" SkinID="CheckBox" Text="Junction Lining"
                                    onclick="return cbxClick();" EnableViewState="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="2">
                </td>
            </tr>
            <tr>
                <td style="height: 26px" colspan="2">
                </td>
            </tr>
        </table>
        <!-- Page element: Data objects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsLateralNavigator" runat="server" SelectMethod="GetLaterals"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_sections_summary"></asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfAssetID" runat="server" EnableViewState="false" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 750px;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 660px; height: 24px;" align="right">
                </td>
                <td style="height: 24px" align="right">
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:window.close();"
                        SkinID="Button" Text="Close" Width="80px" EnableViewState="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
