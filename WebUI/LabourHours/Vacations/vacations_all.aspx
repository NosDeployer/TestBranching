<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="vacations_all.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_all" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->   
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuMyVacations" runat="server" SkinID="RadPanelBar" Visible="false" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" >
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="My Vacations" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbMyViewVacations" Text="View Vacations"></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuAllVacations" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" >
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Vacations" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbVacationsForDDL" PostBack="false">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblVacationsFor" runat="server" Text="Vacations For" SkinID="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 2px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlVacationsFor" runat="server" SkinID="DropDownList" Style="width: 100%" ></asp:DropDownList>                                                     
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbViewVacations" Text="View Vacations" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbNonWorkingDaysDefinition" Text="Non Working Days Definition" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbVacationsSetup" Text="Vacations Setup" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbVacationsSummaryReport" Text="Vacations Summary Report" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>      
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel ID="upTitle" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Vacations Calendar"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mAddVacation" Text="ADD VACATION" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
         <!-- Table element: 6 columns - Vacations Definition -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblWorkingLocation" runat="server" SkinID="Label" Text="Working Location" Visible="false"></asp:Label>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="upnlWorkingLocation" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlWorkingLocation" runat="server" AutoPostBack="true" Height="16px" Visible="false"
                                SkinID="DropDownList" Width="240px" OnSelectedIndexChanged="ddlWorkingLocation_SelectedIndexChanged">
                                <asp:ListItem Value="CA">LFS Canada</asp:ListItem>
                                <asp:ListItem Value="US">LFS USA</asp:ListItem>
                            </asp:DropDownList>
                            
                            <asp:UpdateProgress ID="upWorkingLocation" runat="server" AssociatedUpdatePanelID="upnlWorkingLocation">
                                <ProgressTemplate>
                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
            <%--<tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>--%>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitleGrdVacations" runat="server" SkinID="Label" Text="Vacations"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="lblLegend" runat="server" SkinID="Label" Text="Legend"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    </td>
                <td colspan="3">
                    <table id="tdLegendVacations" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 325px">
                        <tr>
                            <td style="width: 15px; height: 15px; background-color: #00e000">
                            </td>
                            <td style="width: 10px;">
                            </td>
                            <td style="width: 200px">
                                <asp:Label ID="lblPaidColor" runat="server" Text="Paid Days" SkinID="Label"></asp:Label>
                            </td>                        
                            <td style="width: 15px; height: 15px; background-color: #ff624a">
                            </td>
                            <td style="width: 10px;">
                            </td>
                            <td style="width: 200px">
                                <asp:Label ID="lblUnpaid" runat="server" Text="Unpaid Days" SkinID="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                 </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:UpdatePanel ID="upnlVacations" runat="server">
                        <ContentTemplate>
                            <telerik:RadScheduler runat="server" ID="tkrsVacations" SkinID="RadScheduler" HoursPanelTimeFormat="htt"  
                                Height="570px" ShowViewTabs="True" SelectedView="MonthView" Width="740px"
                                AllowDelete="False" AllowEdit="False" allowInsert="False"
                                OnNavigationComplete="tkrsVacations_NavigationComplete" 
                                OnClientAppointmentClick="OnClientAppointmentClick"
                                
                                DataSourceID="odsVacations" DataKeyField="VacationID"
                                DataStartField="StartDate" DataEndField="EndDate" 
                                DataSubjectField="EmployeeName" onappointmentdatabound="tkrsVacations_AppointmentDataBound" 
                            >       
                            </telerik:RadScheduler>
                            
                        </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
            </tr>            
        </table>
        
        <!-- Page element : Data objects -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsVacations" runat="server" 
                        FilterExpression="(Deleted = 0)" SelectMethod="GetVacationsNew" TypeName="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_all">
                    </asp:ObjectDataSource>
                </td>
            </tr>
		</table>
		
		<!-- Page element : Hidden fields -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfIsVacationManager" runat="server" />
                </td>
            </tr>
		</table>
    </div>
</asp:Content>