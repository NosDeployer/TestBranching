<%@ Page Language="C#" MasterPageFile="../../mForm4.Master" AutoEventWireup="true" 
CodeBehind="dashboard.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.dashboard" Title="LFS Live" %>

<%@ Register Src="DashboardControls/wucItemsAboutToExpire.ascx" TagName="wucItemsAboutToExpire"
    TagPrefix="uc7" %>
<%@ Register Src="DashboardControls/wucAlarms.ascx" TagName="wucAlarms" 
    TagPrefix="uc1" %>
<%@ Register Src="DashboardControls/wucSRUnassigned.ascx" TagName="wucSRUnassigned"
    TagPrefix="uc3" %>
<%@ Register Src="DashboardControls/wucSRInProgress.ascx" TagName="wucSRInProgress"
    TagPrefix="uc4" %>
<%@ Register Src="DashboardControls/wucMyServiceRequest.ascx" TagName="wucMyServiceRequest"
    TagPrefix="uc5" %>
<%@ Register Src="DashboardControls/wucExpiredItems.ascx" TagName="wucExpiredItems"
    TagPrefix="uc6" %>
<%@ Register Src="DashboardControls/wucMyToDoList.ascx" TagName="wucMyToDoList"
    TagPrefix="uc8" %>  
<%@ Register Src="DashboardControls/wucToDoListAssignedToMe.ascx" TagName="wucToDoListAssignedToMe"
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
                <td style=" vertical-align: top; width: 250px">
                    <asp:WebPartZone ID="wpzMyServiceRequest" runat="server"  SkinID="Dashboard" Width="240px">
                        <ZoneTemplate>
                            <uc5:wucMyServiceRequest id="wucMyServiceRequest" title="My Assigned SR"  runat="server">
                            </uc5:wucMyServiceRequest>
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>
                
                <td style=" vertical-align: top; width: 250px">
                    <asp:WebPartZone ID="wpzAboutToExpireItems" runat="server"  SkinID="Dashboard" Width="240px">
                        <ZoneTemplate>
                            <uc7:wucItemsAboutToExpire ID="WucItemsAboutToExpire" title="SR About To Expired"  runat="server" />
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>
                
                <td style=" width: 250px; vertical-align: top;">
                    <asp:WebPartZone ID="wpzExpiredItems" runat="server"  SkinID="Dashboard" Width="240px">
                        <ZoneTemplate>
                            <uc6:wucExpiredItems id="wucExpiredItems" title="Expired SR" runat="server">
                            </uc6:wucExpiredItems>
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>
            </tr>
            <tr>
                <td style="height: 30px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style=" width: 94px; vertical-align: top;">
                </td>
                <td style="vertical-align: top;">  
                    <asp:WebPartZone ID="wpzSRInProgress" runat="server" Width="240px" SkinID="Dashboard">
                        <ZoneTemplate>
                            <uc4:wucSRInProgress id="wucSRInProgress" title="SR In Progress" runat="server">
                            </uc4:wucSRInProgress>
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>
                <td style="vertical-align: top;">
                    <asp:WebPartZone ID="wpzMyToDo" runat="server" Width="240px" SkinID="Dashboard">
                        <ZoneTemplate>
                            <uc8:wucMyToDoList id="wucMyToDoList" title="To Do's I Created" runat="server">
                            </uc8:wucMyToDoList>
                        </ZoneTemplate>
                    </asp:WebPartZone>
                </td>
                <td style="vertical-align: top;">
                    <asp:WebPartZone ID="wpzToDoListAssignedToMe" runat="server" Width="240px" SkinID="Dashboard">
                        <ZoneTemplate>
                            <uc9:wucToDoListAssignedToMe id="wucToDoListAssignedToMe" title="To Do's Assigned To Me" runat="server">
                            </uc9:wucToDoListAssignedToMe>
                        </ZoneTemplate>
                    </asp:WebPartZone>
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