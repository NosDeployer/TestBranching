<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mDialog2.Master" AutoEventWireup="true" CodeBehind="units_add_attachment.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_add_attachment" %>

<%@ Register TagPrefix="Upload" Namespace="Brettle.Web.NeatUpload" Assembly="Brettle.Web.NeatUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 400px;">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 400px;">
                    <asp:Label runat="server" ID="lblDescription" SkinID="Label" Text="Description"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="tbxDescription" SkinID="TextBox" Width="300px"></asp:TextBox>
                </td>                    
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator SkinID="Validator" runat="server" ID="rfvDescription" Display="Dynamic" ErrorMessage="The description is missing." InitialValue="" ControlToValidate="tbxDescription"></asp:RequiredFieldValidator> 
                </td>                
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblFile" SkinID="Label" Text="File"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <Upload:InputFile id="nuifAttachment" runat="server" />
                </td>              
            </tr>
            <tr>
                <td>
                    <%--<Upload:ProgressBar id="nupbAttachment" runat="server" inline="true" />--%>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">                    
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <!-- BUTTONS -->
    <div style="width: 400px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 90px">
                    <asp:Button ID="btnAdd" runat="server" SkinID="Button" Text="Add" Width="80px" EnableViewState="False" OnClick="btnAdd2_Click" />
                </td>
                <td style="width: 180px">
                </td>
                <td style="width: 90px">
                    <asp:Button ID="btnCancel" runat="server" OnClientClick="btnCloseClick();" SkinID="Button" Text="Close" Width="80px" EnableViewState="False" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:HiddenField ID="hdfUpdate" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>