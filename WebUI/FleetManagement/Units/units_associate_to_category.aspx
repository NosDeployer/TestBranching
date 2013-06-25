<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mDialog2.Master" AutoEventWireup="true" CodeBehind="units_associate_to_category.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_associate_to_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 450px;">
        <!-- Page element: 1 column - Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblInstruction" runat="server" SkinID="LabelTitle1" Text="Please select the category you would like to associate" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;" >
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Panel ID="pnlCategories" Width="428px" Height="400px" runat="server" ScrollBars="Auto" BorderStyle="Solid" BorderWidth="1px">
                        <asp:TreeView ID="tvCategoriesRoot"  PathSeparator="|" OnTreeNodePopulate="PopulateNode"
                        ExpandDepth="1" runat="server" SkinID="TreeView">
                            <Nodes>
                                <asp:TreeNode Text="Trenchless University" PopulateOnDemand="True" Value="Trenchless University"></asp:TreeNode>
                            </Nodes>
                        </asp:TreeView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvCategories" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You need to select a category."
                        OnServerValidate="cvCategories_ServerValidate"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 450px;">
        <table border="0" cellpadding="0" cellspacing="0" width="450">
            <tr>
                <td style="width: 90px">
                    <asp:Button ID="btnAssociate" runat="server" Height="22px" SkinID="Button" Text="Associate" Width="80px" EnableViewState="False" OnClick="btnAssociate_Click" OnClientClick="return btnAssociateClick();" />
                </td>
                <td style="width: 190px">
                </td>
                <td style="width: 80px">
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="btnCloseClick();"
                        SkinID="Button" Text="Close" Width="80px" EnableViewState="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>