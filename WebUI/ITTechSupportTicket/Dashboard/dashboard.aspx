<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm4.master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.Dashboard.dashboard" %>

<%@ Register Src="DashboardControls/wucMySupportTicket.ascx" TagName="wucMySupportTicket"
    TagPrefix="uc8" %>  
<%@ Register Src="DashboardControls/wucSupportTicketAssignedToMe.ascx" TagName="wucSupportTicketAssignedToMe"
    TagPrefix="uc9" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td >
                    <asp:Label ID="lblTitle" runat="server" Text="Dashboard" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
   <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
           <tr>
                <td >
                    <asp:WebPartManager ID="wpmWebPartManager" runat="server">
                        <Personalization ProviderName="WebPartsProvider" />
                    </asp:WebPartManager>                    
                </td>
           </tr>
        </table>
        
        
        
        <table cellpadding="0" cellspacing="0" border="0" style="width: 844px">
            <tr>
                <td style="width: 94px; vertical-align: top;">
                </td>
                
                <td style="width: 250px; vertical-align: top;">                    
                </td>                
                <td style="width: 250px; vertical-align: top;">
                </td>                
                <td style="vertical-align: top;">  
                </td>
            </tr>
            <tr>
                <td style="width: 94px; vertical-align: top;">
                </td>                
                <td style="vertical-align: top;">
                    <asp:WebPartZone ID="wpzMySupportTicket" runat="server" Width="240px" SkinID="Dashboard">
                        <ZoneTemplate>
                            <uc8:wucMySupportTicket id="wucMySupportTicket" title="Support Ticket's I Created" runat="server">
                            </uc8:wucMySupportTicket>
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>                
                <td style=" vertical-align: top;">
                    <asp:WebPartZone ID="wpzSupportTicketAssignedToMe" runat="server" Width="240px" SkinID="Dashboard">
                        <ZoneTemplate>
                            <uc9:wucSupportTicketAssignedToMe id="wucSupportTicketAssignedToMe" title="Support Ticket's Assigned To Me" runat="server">
                            </uc9:wucSupportTicketAssignedToMe>
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>
                <td style="vertical-align: top;">                    
                </td>
            </tr>   
            <tr>
                <td style="height: 60px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>            
        </table>
   </div>
</asp:Content>