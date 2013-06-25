<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucExpiredItems.ascx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucExpiredItems" %>

<div style="width: 230px; height: 460px;">

    <!-- Table element: 1 columns - Expired Items Title -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblUnitChecklistExpiredServices" runat="server" SkinID="LabelTitle2" Text="Expired SR"
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
    
    <!-- Table element: 1 columns - Expired Service Requests grid -->
    <asp:UpdatePanel id="upnlExpiredServiceRequests" runat="server">
        <contenttemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                <tr>
                    <td>
                        <asp:GridView id="grdExpiredServiceRequests" runat="server" SkinID="GridView" Width="220px" 
                        DataKeyNames="ServiceID" OnRowDataBound="grdExpiredServiceRequests_RowDataBound"
                        DataSourceID="odsExpiredServiceRequests" OnDataBound="grdExpiredServiceRequests_DataBound" PageSize="5" 
                        AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdExpiredServiceRequests_PageIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID" HeaderText="COMPANY_ID"></asp:BoundField>
                                
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
                                        <asp:HyperLink ID="hlkExpiredServices" runat="server" SkinID="HyperLink" ToolTip='<%# Bind("ServiceDescription") %>' Text='<%# Bind("ExpiredServicesCompleteName") %>' 
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
                        <asp:CustomValidator id="cvGrdExpiredServiceRequests" runat="server" SkinID="Validator" Display="Dynamic"
                         ValidationGroup="expired" ErrorMessage="At least one option must be selected." 
                         OnServerValidate="cvGrdExpiredServiceRequests_ServerValidate"></asp:CustomValidator>
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
                <asp:LinkButton ID="lkbtnServiceRequestManager" runat="server" EnableViewState="False" 
                SkinID="LinkButton" OnClick="lkbtnServiceRequestManager_Click">Service Requests Management Tool</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>  
    
    <!-- Page element: Data objects -->
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:ObjectDataSource ID="odsExpiredServiceRequests" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucExpiredItems">
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
            </td>
        </tr>
    </table>

</div>