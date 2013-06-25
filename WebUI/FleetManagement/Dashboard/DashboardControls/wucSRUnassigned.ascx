<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucSRUnassigned.ascx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucSRUnassigned" %>

<div style="width: 230px; height: 460px;">

    <!-- Table element: 1 columns - Service Request Tools -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:LinkButton ID="lkbtnAddServiceRequest" runat="server" EnableViewState="False" SkinID="LinkButton">Add Service Request</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>   

    <!-- Table element: 1 columns - Unassigned Service Requests title -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblUnassignedServiceRequest" runat="server" SkinID="LabelTitle2" Text="Unassigned SR"
                EnableViewState="False"></asp:Label>                
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
    
    <!-- Table element: 1 columns - Dropdownlist for working location -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblWorkingLocation" runat="server" SkinID="Label" Text="Working Location"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlWorkingLocation" runat="server" AutoPostBack="true" Height="16px" SkinID="DropDownList"
                 Width="220px" OnSelectedIndexChanged="ddlWorkingLocation_SelectedIndexChanged">                   
                </asp:DropDownList>  
            </td>
        </tr>
        <tr>
            <td style="height: 7px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblType" runat="server" SkinID="Label" Text="Unit Type"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" Height="16px" SkinID="DropDownList"
                 Width="220px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                    <asp:ListItem Text="(All)" Value="(All)" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="MTO / DOT" Value="MTO / DOT"></asp:ListItem>
                    <asp:ListItem Text="Vehicle" Value="Vehicle"></asp:ListItem>
                    <asp:ListItem Text="Equipment" Value="Equipment"></asp:ListItem>
                    <asp:ListItem Text="Safety Equipment" Value="Safety Equipment"></asp:ListItem>
                </asp:DropDownList>  
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
    
    <!-- Table element: 1 columns - Unassigned Service Requests grid -->
    <asp:UpdatePanel id="upnlUnassignedServiceRequests" runat="server">
        <contenttemplate>    
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                <tr>
                    <td>
                        <asp:GridView id="grdUnassignedServiceRequests" runat="server" SkinID="GridView" Width="220px" 
                            OnPageIndexChanging="grdUnassignedServiceRequests_PageIndexChanging" DataKeyNames="ServiceID" 
                            DataSourceID="odsUnassignedServiceRequests" OnDataBound="grdUnassignedServiceRequests_DataBound" PageSize="5" 
                            AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdUnassignedServiceRequests_PageIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="ServiceID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblServiceID" runat="server" Style="width: 100px" Text='<%# Bind("ServiceID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                      
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Service Request">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:HyperLink ID="hlkUnnasignedServiceRequest" runat="server" SkinID="HyperLink" ToolTip='<%# Bind("ServiceDescription") %>' Text='<%# Bind("UnassignedServicesCompleteName") %>' 
                                            NavigateUrl='<%# GetUrl( Eval("ServiceID")) %>' Target="_parent" >
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView> 
                    </td> 
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator id="cvGrdUnassignedServiceRequests" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="unassigned" ErrorMessage="At least one option must be selected." OnServerValidate="cvGrdUnassignedServiceRequests_ServerValidate"></asp:CustomValidator>
                    </td>        
                </tr>
            </table>   
       </contenttemplate>
    </asp:UpdatePanel>            
    
    <!-- Table element: 1 columns - Space -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td style="height: 15px">
            </td>
        </tr>
    </table>   

    <!-- Table element: 1 columns - Assign Service Request -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
               <asp:LinkButton ID="lkbtnAssignServiceRequest" runat="server" EnableViewState="False" 
               SkinID="LinkButton" OnClick="lkbtnAssignServiceRequest_Click">Assign Service Request</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 7px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lkbtnServiceRequestManager" runat="server" EnableViewState="False" 
                SkinID="LinkButton" OnClick="lkbtnServiceRequestManager_Click">Service Requests Management Tool</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>   
    
    <!-- Table element: 1 columns - Alarm reminders -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_Remainder">
        <tr>                   
            <td>
                <asp:Label ID="lblReminder" runat="server" SkinID="LabelTitle2" Text="Reminder"
                EnableViewState="False"></asp:Label>                
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>    
        
    <!-- Table element: 1 columns - Alarms -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;" class="Background_Remainder">
        <tr>
            <td style="width: 10px">
            </td> 
            <td>
               <asp:LinkButton ID="lkbtnUnassignedServiceRequests" runat="server" EnableViewState="False" 
               SkinID="LinkButton" OnClick="lkbtnUnassignServiceRequests_Click">Unassigned Service Requests</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="height: 7px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lkbtnRejectedServiceRequests" runat="server" EnableViewState="False"
                    OnClick="lkbtnRejectedServiceRequests_Click" SkinID="LinkButton">Rejected Service Requests</asp:LinkButton></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
    
    <!-- Page element: Data objects -->
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:ObjectDataSource ID="odsUnassignedServiceRequests" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucSRUnassigned">
                </asp:ObjectDataSource>

            </td>
        </tr>
    </table>
    
    <!-- Page element : Tag page -->
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:HiddenField ID="hdfCompanyId" runat="server" />
                <asp:HiddenField ID="hdfOriginBtn" runat="server" />
                <asp:HiddenField ID="hdfEmployeeId" runat="server" />
            </td>
        </tr>
    </table>
    
</div>