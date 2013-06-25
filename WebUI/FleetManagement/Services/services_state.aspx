<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="services_state.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_state"  Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
       <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Service Information" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px;">
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
                            <telerik:RadMenuItem Value="mAssign" Text="YES, ASSIGN" />
                            
                            <telerik:RadMenuItem Value="mAccept" Text="YES, ACCEPT" />
                            
                            <telerik:RadMenuItem Value="mReject" Text="YES, REJECT" />
                            
                            <telerik:RadMenuItem Value="mStartWork" Text="YES, START WORK" />
                            
                            <telerik:RadMenuItem Value="mCompleteWork" Text="YES, COMPLETE WORK" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
   
    <!-- State Data -->
    <div style="width: 750px">
    
        <!-- Table element: 1 columns - State change message-->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblState" runat="server" SkinID="Label" Text="Are you sure you want change state of the service request?" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
        </table>        
    
        <!-- Table element: 1 panel for Assignment info  -->
        <asp:Panel ID="pnlAssignment" runat="server"  Width="100%">
        
            <!-- Table element: 5 columns  -->
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td style="width: 150px; height: 10px;">
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
                        <asp:Label ID="LabelDeadlineDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Deadline Date"></asp:Label>
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
                    <td>
                        <telerik:RadDatePicker ID="tkrdpPnlAssignDeadlineDate" runat="server" Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                        </telerik:RadDatePicker>
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
            </table>

            <!-- Table element: 5 columns  -->
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td colspan="2" style="width: 290px">
                        <asp:RadioButton ID="rbtnPnlAssignToTeamMember" runat="server" 
                            GroupName="Begin" SkinID="RadioButton" Text="To Team Member" Checked="True" /></td>
                    <td colspan="2" style="width: 290px">
                        <asp:RadioButton ID="rbtnPnlAssignToThirdPartyVendor" runat="server" 
                            GroupName="Begin" SkinID="RadioButton" Text="To Third Party Vendor" /></td>
                    <td style="width: 150px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlPnlAssignAssignToTeamMember" runat="server" DataMember="DefaultView"
                            DataSourceID="odsEmployee" DataTextField="FullName" DataValueField="EmployeeID"
                            EnableViewState="False" SkinID="DropDownList" Style="width: 290px">
                        </asp:DropDownList></td>
                    <td colspan="2">
                        <asp:TextBox ID="tbxPnlAssignAssignToThirdPartyVendor" runat="server" SkinID="TextBox" 
                        Style="width: 290px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CustomValidator ID="cvTeamMember" runat="server" ControlToValidate="ddlPnlAssignAssignToTeamMember"
                            Display="Dynamic" ErrorMessage="Please select a team member." OnServerValidate="cvTeamMember_ServerValidate"
                            SkinID="Validator" ValidationGroup="assignmentInformation"></asp:CustomValidator></td>
                    <td colspan="2">
                        <asp:CustomValidator ID="cvThirdPartyVendor" runat="server" ControlToValidate="tbxPnlAssignAssignToThirdPartyVendor"
                            Display="Dynamic" ErrorMessage="Please provide a third party vendor." OnServerValidate="cvThirdPartyVendor_ServerValidate"
                            SkinID="Validator" ValidationGroup="assignmentInformation" ValidateEmptyText="True"></asp:CustomValidator></td>
                    <td>
                    </td>
                </tr>
            </table>                                      
        </asp:Panel>            
                    
        <!-- Page element : Assignment Reject -->
        <asp:Panel ID="pnlAssignmentReject" runat="server"  Width="100%">
                                                     
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td style="width: 150px; height: 10px;">
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
                        <asp:Label ID="lblPnlAssignmentRejectDataRejectedReason" runat="server" EnableViewState="False"
                            SkinID="Label" Text="Rejected Reason"></asp:Label></td>
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
                    <td colspan="5">
                        <asp:TextBox ID="tbxPnlAssignmentRejectDataRejectedReason" runat="server" EnableViewState="False" Rows="4" SkinID="TextBox"
                            Style="width: 740px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            </table>              
        </asp:Panel>
        
        <!-- Page element : Start Work -->
        <asp:Panel ID="pnlStartWork" runat="server"  Width="100%">
                                                     
            <!-- Table element: 5 columns  -->
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td style="width: 150px; height: 10px;">
                        <asp:Label ID="lblPnlStartWorkUnitOutOfServiceDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Out Of Service Date"></asp:Label>
                    </td>
                    <td style="width: 150px">
                        <asp:Label ID="lblPnlStartWorkStartMileage" runat="server" EnableViewState="False" SkinID="Label" Text="Mileage"></asp:Label>
                    </td>
                    <td style="width: 150px">
                        <asp:Label ID="lblPnlStartWorkUnitOutOfServiceTime" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Out Of Service Time" Visible="false"></asp:Label>
                    </td>                    
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadDatePicker ID="tkrdpPnlStartWorkUnitOutOfServiceDate" runat="server" Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPnlStartWorkStartMileage" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 110px"></asp:TextBox>
                        <asp:Label ID="lblPnlStartWorkStartMileageUnitOfMeasurement" runat="server" EnableViewState="False" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPnlStartWorkUnitOutOfServiceTime" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 140px" Visible="false"></asp:TextBox>
                    </td>                    
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvUnitOutOfServiceDate" runat="server" ControlToValidate="tkrdpPnlStartWorkUnitOutOfServiceDate"
                            Display="Dynamic" ErrorMessage="Please select a date." OnServerValidate="tkrdpPnlStartWorkUnitOutOfServiceDate_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="startWorkInformation"></asp:CustomValidator>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvStartMileage" runat="server" ControlToValidate="tbxPnlStartWorkStartMileage"
                            Display="Dynamic" ErrorMessage="Please provide a mileage." OnServerValidate="cvStartMileage_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="startWorkInformation"></asp:CustomValidator>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvUnitOutOfServiceTime" runat="server" ControlToValidate="tbxPnlStartWorkUnitOutOfServiceTime"
                            Display="Dynamic" ErrorMessage="Invalid format. (use XX:XX or XX:XX AM or XX:XX PM)"
                            OnServerValidate="cvUnitOutOfServiceTime_ServerValidate" SkinID="Validator" ValidationGroup="startWorkTimeInformation"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvEmpyOutOfService" runat="server" ControlToValidate="tbxPnlStartWorkUnitOutOfServiceTime"
                            Display="Dynamic" ErrorMessage="Please provide the out of service time." OnServerValidate="cvEmpyOutOfService_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="startWorkTimeInformation"></asp:CustomValidator>
                    </td>                    
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>  
        </asp:Panel>
        
        <!-- Page element : Complete Work -->
        <asp:Panel ID="pnlCompleteWork" runat="server"  Width="100%">
                                                     
            <!-- Table element: 5 columns  -->
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td style="width: 150px; height: 10px;">
                        <asp:Label ID="lblPnlCompleteWorkUnitBackInServiceDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Back In Service Date"></asp:Label>
                    </td>                    
                    <td style="width: 150px">
                        <asp:Label ID="lblPnlCompleteWorkCompleteMileage" runat="server" EnableViewState="False" SkinID="Label" Text="Mileage"></asp:Label>
                    </td>
                    <td style="width: 150px">
                        <asp:Label ID="lblPnlCompleteWorkUnitBackInServiceTime" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Back In Service Time" Visible="false"></asp:Label>
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadDatePicker ID="tkrdpPnlCompleteWorkUnitBackInServiceDate" runat="server" Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPnlCompleteWorkCompleteMileage" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 110px"></asp:TextBox>
                        <asp:Label ID="lblPnlCompleteWorkCompleteMileageUnitOfMeasurement" runat="server" EnableViewState="False" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPnlCompleteWorkUnitBackInServiceTime" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 140px" Visible="false"></asp:TextBox>
                    </td>                    
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvUnitBackInServiceDate" runat="server" ControlToValidate="tkrdpPnlCompleteWorkUnitBackInServiceDate"
                            Display="Dynamic" ErrorMessage="Please select a date." OnServerValidate="cvUnitBackInServiceDate_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="completeWorkInformation"></asp:CustomValidator>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvCompleteMileage" runat="server" ControlToValidate="tbxPnlCompleteWorkCompleteMileage"
                            Display="Dynamic" ErrorMessage="Please provide a mileage." OnServerValidate="cvCompleteMileage_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="completeWorkInformation"></asp:CustomValidator>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvUnitBackInServiceTime" runat="server" ControlToValidate="tbxPnlCompleteWorkUnitBackInServiceTime"
                            Display="Dynamic" ErrorMessage="Invalid format. (use XX:XX or XX:XX AM or XX:XX PM)"
                            OnServerValidate="cvUnitBackInfServiceTime_ServerValidate" SkinID="Validator" ValidationGroup="completeWorkTimeInformation"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvEmptyBackInServiceTime" runat="server" ControlToValidate="tbxPnlCompleteWorkUnitBackInServiceTime"
                            Display="Dynamic" ErrorMessage="Please provide the back in service time." OnServerValidate="cvEmptyBackInServiceTime_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="completeWorkTimeInformation"></asp:CustomValidator>
                    </td>                    
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadByAssignableSrsAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="assignableSrs" Type="Int32" />
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>

        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                                                                                    
                    <asp:HiddenField ID="hdfServiceId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfUnitType" runat="server" />
                    <asp:HiddenField ID="hdfCompanyLevel" runat="server" />
                    <asp:HiddenField ID="hdfMileageUnitOfMeasurement" runat="server" />
               </td>
            </tr>
        </table>
    </div>
</asp:Content>