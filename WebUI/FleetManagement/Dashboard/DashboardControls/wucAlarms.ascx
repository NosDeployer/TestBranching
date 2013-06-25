<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucAlarms.ascx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucAlarms" %>

<div style="width: 230px; height: 460px;">

    <!-- Table element: 1 columns - Add Service Request -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:LinkButton ID="lkbtnCreateServiceRequest" runat="server" EnableViewState="False"
                    OnClick="lkbtnCreateServiceRequest_Click" SkinID="LinkButton">Add Service Request for Checklist</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table> 
    
    <!-- Table element: 1 columns - Alarms Title -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblAlarmsInUnitsChecklist" runat="server" SkinID="LabelTitle2" Text="Alarms In Units Checklist"
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
        
    <!-- Table element: 1 columns - Alarms service grid -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:UpdatePanel id="upnlChecklistAlarms" runat="server">
                    <contenttemplate>
                        <asp:GridView id="grdChecklistAlarms" runat="server" SkinID="GridView" Width="220px" 
                        DataKeyNames="UnitID,RuleID"  OnPageIndexChanging="grdChecklistAlarms_PageIndexChanging"
                        DataSourceID="odsChecklistAlarms" OnDataBound="grdChecklistAlarms_DataBound" PageSize="5" 
                        AllowPaging="True" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID" HeaderText="COMPANY_ID"></asp:BoundField>
                                                                
                                <asp:TemplateField HeaderText="UnitID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitID" runat="server" Style="width: 100px" Text='<%# Bind("UnitID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="RuleID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRuleID" runat="server" Style="width: 100px" Text='<%# Bind("RuleID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Items">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:HyperLink ID="hlkAlarm" runat="server" 
                                        SkinID="HyperLink" Text='<%# Bind("ChecklistAlarmsCompleteName") %>' NavigateUrl='<%# GetUrl( Eval("UnitID")) %>' Target="_parent" ></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="State">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblStateID" runat="server" Style="width: 60px" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </contenttemplate>
                </asp:UpdatePanel>    
            </td> 
        </tr>
        <tr>
            <td>
                <asp:CustomValidator id="cvSelectedServices" runat="server" SkinID="Validator" Display="Dynamic" ValidationGroup="alarms" ErrorMessage="At least one option must be selected." OnServerValidate="grdChecklistAlarms_ServerValidate"></asp:CustomValidator>
            </td>        
        </tr>
    </table>         
    
    <!-- Table element: 1 columns - Space -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td style="height: 15px">
            </td>
        </tr>
    </table>     
   
    <!-- Page element: Data objects -->
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:ObjectDataSource ID="odsChecklistAlarms" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucAlarms">
                </asp:ObjectDataSource>

            </td>
        </tr>
    </table>
    
    <!-- Page element : Tag page -->
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:HiddenField ID="hdfCompanyId" runat="server" />
                <asp:HiddenField ID="hdfEmployeeId" runat="server" />

            </td>
        </tr>
    </table>

</div> 