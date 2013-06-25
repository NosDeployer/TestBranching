<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="vacations_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_edit" %>
     
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
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Vacations Summary"></asp:Label>
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
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                    <asp:UpdatePanel ID="upnlMissingData" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMissingData" runat="server" SkinID="LabelError" Text=""></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Table element: 1 columns - Basic Information Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblBasicInformation" runat="server" SkinID="LabelTitle1" Text="Basic Information" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 4 columns  -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 187px">
                </td>
                <td style="width: 187px">
                </td>
                <td style="width: 187px">
                </td>
                <td style="width: 189px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmployee" runat="server" Text="Team Member" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMax" runat="server" Text="Total paid vacation days per Year" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRemaining" runat="server" Text="Remaining Paid Vacation Days" SkinID="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxEmployee" runat="server" SkinID="TextBoxReadOnly" Width="177px"
                        ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlMax" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxMax" runat="server" SkinID="TextBoxReadOnly" Width="177px" ReadOnly="true"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlRemaining" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxRemaining" runat="server" SkinID="TextBoxReadOnly" Width="177px"
                                ReadOnly="true"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Vacation Definition -->
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
                    <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:TextBox ID="tbxComments" runat="server" SkinID="TextBox" Width="740px" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
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
                                Height="570px" AllowDelete="true" AllowEdit="true" AllowInsert="true" Width="740px"
                                StartEditingInAdvancedForm="False" ShowViewTabs="True" SelectedView="MonthView"                             
                                
                                DataSourceID="odsVacations" DataKeyField="VacationID" 
                                DataStartField="StartDate" DataEndField="EndDate" DataSubjectField="PaymentType"
                                
                                OnAppointmentInsert="tkrsVacations_AppointmentInsert" 
                                OnAppointmentDelete="tkrsVacations_AppointmentDelete" 
                                OnAppointmentUpdate="tkrsVacations_AppointmentUpdate"
                                OnNavigationComplete="tkrsVacations_NavigationComplete"
                                onappointmentcommand="tkrsVacations_AppointmentCommand" 
                                onformcreated="tkrsVacations_FormCreated"
                                
                                Localization-ConfirmDeleteText="Are you sure you want delete this vacation?" 
                                Localization-ConfirmOK="Yes" Localization-ConfirmCancel="No" onappointmentdatabound="tkrsVacations_AppointmentDataBound"                        
                                >
                                    
                                <InlineInsertTemplate>
                                    <div class="rsAptEditTextareaWrapper">
                                        <asp:RadioButtonList runat="server" ID="rbtnPaymentType" SkinID="RadioButtonListWithoutBorder"
                                            RepeatDirection="Vertical" DataSourceID="odsPaymentType" DataValueField="PaymentType"
                                            DataTextField="PaymentType">
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="rsEditOptions">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" Text="Save" CommandName="Insert"> </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" Text="Cancel" CommandName="Cancel"> </asp:LinkButton>
                                    </div>
                                </InlineInsertTemplate>
                               
                                <InlineEditTemplate>
                                    <div class="rsAptEditTextareaWrapper">
                                        <asp:RadioButtonList runat="server" ID="rbtnPaymentType" SkinID="RadioButtonListWithoutBorder"
                                            RepeatDirection="Vertical" DataSourceID="odsPaymentType" DataValueField="PaymentType"
                                            DataTextField="PaymentType">
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="rsEditOptions">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Save" CommandName="Update"> </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" Text="Cancel" CommandName="Cancel"> </asp:LinkButton>
                                    </div>
                                </InlineEditTemplate>
                                
                            </telerik:RadScheduler>
                            
                            <asp:ObjectDataSource ID="odsPaymentType" runat="server" SelectMethod="Load" 
                                TypeName="LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsPaymentTypeList">
                                <SelectParameters>
                                    <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
                        FilterExpression="(Deleted = 0)" SelectMethod="GetVacationsNew" TypeName="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_edit" 
                        DeleteMethod="DummyVacationsNew" InsertMethod="DummyVacationsNew" UpdateMethod="DummyVacationsNew">
                    </asp:ObjectDataSource>
                </td>
            </tr>
		</table>
		
		<!-- Page element : Hidden fields -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfEmployeeId" runat="server" />
                    <asp:HiddenField ID="hdfVacationId" runat="server" />
                    <asp:HiddenField ID="hdfRequestId" runat="server" />
                    <asp:HiddenField ID="hdfIsVacationManager" runat="server" />
                </td>
            </tr>
		</table>
    </div>
</asp:Content>