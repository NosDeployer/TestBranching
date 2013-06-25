<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="vacations_non_working_days_definition.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_non_working_days_definition" %>
 
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
                                    <telerik:RadPanelItem runat="server" Value="nbNonWorkingDaysDefinition" Text="Non Working Days Definition" Selected="true" PostBack="false" ></telerik:RadPanelItem>
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
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Non Working Days Definition"></asp:Label>
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
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
         <!-- Table element: 6 columns - Non working Days Definition -->
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
                <td colspan="6">
                    <asp:Label ID="lblWorkingLocation" runat="server" SkinID="Label" Text="Working Location"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:UpdatePanel ID="upnlWorkingLocation" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlWorkingLocation" runat="server" AutoPostBack="true" Height="16px"
                                SkinID="DropDownList" Width="220px" OnSelectedIndexChanged="ddlWorkingLocation_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:UpdateProgress ID="upWorkingLocation" runat="server" AssociatedUpdatePanelID="upnlWorkingLocation">
                                <ProgressTemplate>
                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblTitleGrdVacations" runat="server" SkinID="Label" Text="Non working days"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:UpdatePanel ID="upnlVacations" runat="server">
                        <ContentTemplate>
                            <telerik:RadScheduler runat="server" ID="tkrsNonWorkingDays" SkinID="RadScheduler" HoursPanelTimeFormat="htt"
                                Height="570px" StartEditingInAdvancedForm="false" ShowViewTabs="true" SelectedView="MonthView" Width="740px"                            
                                
                                DataSourceID="odsNonWorkingDaysGrid" DataKeyField="NonWorkingDayID" 
                                DataStartField="StartDate" DataEndField="EndDate" DataSubjectField="Description"
                                
                                OnAppointmentInsert="tkrsNonWorkingDays_AppointmentInsert" 
                                OnAppointmentDelete="tkrsNonWorkingDays_AppointmentDelete" 
                                OnAppointmentUpdate="tkrsNonWorkingDays_AppointmentUpdate"
                                OnNavigationComplete="tkrsNonWorkingDays_NavigationComplete"
                                
                                Localization-ConfirmDeleteText="Are you sure you want delete this non working day?" 
                                Localization-ConfirmOK="Yes" Localization-ConfirmCancel="No"                        
                                Localization-AdvancedEditAppointment="Edit non working day" 
                                Localization-AdvancedNewAppointment="New non working day" 
                                Localization-AdvancedSubjectRequired="Please provide a subject" 
                                Localization-AdvancedAllDayEvent="All day">
                                                                
                                <AdvancedForm Enabled="false" DateFormat="M/d/yyyy" TimeFormat="h:mm tt" Modal="true"></AdvancedForm>
                            </telerik:RadScheduler>
                            
                            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Skin="Vista" ToolTipZoneID="ConfigurationPanel1"
                                AutoTooltipify="true">
                            </telerik:RadToolTipManager>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlWorkingLocation" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Data objects -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsNonWorkingDaysGrid" runat="server" 
                        FilterExpression="(Deleted = 0)" SelectMethod="GetNonWorkingDaysNew" TypeName="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_non_working_days_definition" 
                        DeleteMethod="DummyNonWorkingDaysNew" InsertMethod="DummyNonWorkingDaysNew" UpdateMethod="DummyNonWorkingDaysNew">
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