<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mReport1.Master" AutoEventWireup="true" CodeBehind="projects_summary_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.projects_summary_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <!-- Page element: Range data 2 columns -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblCountry" runat="server" Text="Country" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="160px" SkinID="DropDownList">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="1">Canada</asp:ListItem>
                        <asp:ListItem Value="2">USA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
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
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProject" runat="server" Text="Project" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="ddlProject" SkinID="DropDownList" runat="server" Width="160px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                <ProgressTemplate>
                                                    <asp:Image ID="imAjax" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblState" runat="server" Text="Select State" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" Width="160px" SkinID="DropDownList">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="Bidding" Text= "Bidding"></asp:ListItem>
                          <asp:ListItem Value="Awarded" Text= "Awarded"></asp:ListItem>                                
                          <asp:ListItem Value="Lost Bid" Text= "Lost Bid"></asp:ListItem>                                
                          <asp:ListItem Value="Canceled" Text= "Canceled"></asp:ListItem>                                
                          <asp:ListItem Value="Waiting" Text= "Waiting"></asp:ListItem>                                
                          <asp:ListItem Value="Active" Text= "Active"></asp:ListItem>                                
                          <asp:ListItem Value="Complete" Text= "Complete"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCurrency" runat="server" Text="Select Currency" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCurrency" runat="server" Width="160px" SkinID="DropDownList">
                        <asp:ListItem>CAD</asp:ListItem>
                        <asp:ListItem>USD</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExchangeRate" runat="server" Text="Exchange (CAD to USD)" SkinID="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxExchangeRate" runat="server" Width="160px" SkinID="TextBox">1.00</asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvExchangeRate" runat="server" ControlToValidate="tbxExchangeRate"
                        Display="Dynamic" ErrorMessage="Please provide an exchange rate." SkinID="Validator"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvExchangeRate" runat="server" ControlToValidate="tbxExchangeRate"
                        Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck"
                        SkinID="Validator" Type="Currency"></asp:CompareValidator></td>
            </tr>
        </table>
    </div>
</asp:Content>