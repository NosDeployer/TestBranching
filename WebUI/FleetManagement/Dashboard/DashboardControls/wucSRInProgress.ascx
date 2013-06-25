<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucSRInProgress.ascx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucSRInProgress" %>

<div style="width: 230px; height: 460px;">

    <!-- Table element: 1 columns - Add Service Request -->
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
    
    <!-- Table element: 1 columns - SR In Progress Title -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblMyServiceRequest" runat="server" SkinID="LabelTitle2" Text="SR In Progress"
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
    
    <!-- Table element: 1 columns - Service Requests In Progress grid -->   
    <asp:UpdatePanel id="upnlServiceRequestsInProgress" runat="server">
        <contenttemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">            
                <tr>
                    <td>                
                        <asp:GridView id="grdServiceRequestsInProgress" runat="server" 
                            SkinID="GridView" Width="220px" DataKeyNames="ServiceID" OnRowDataBound="grdServiceRequestsInProgress_RowDataBound"
                            DataSourceID="odsServiceRequestsInProgress" OnDataBound="grdServiceRequestsInProgress_DataBound" PageSize="5" 
                            AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdServiceRequestsInProgress_PageIndexChanged">
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
                                        <asp:HyperLink ID="hlkMyServiceRequest" runat="server" SkinID="HyperLink" ToolTip='<%# Bind("ServiceDescription") %>' Text='<%# Bind("InProgressServicesCompleteName") %>' 
                                            NavigateUrl='<%# GetUrl( Eval("ServiceID")) %>' Target="_parent" >
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="State">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblState" runat="server" Style="width: 60px" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView> 
                    </td> 
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator id="cvGrdInProgressServiceRequests" runat="server" SkinID="Validator" Display="Dynamic"
                         ValidationGroup="inProgress" ErrorMessage="At least one option must be selected." 
                         OnServerValidate="cvGrdServiceRequestsInProgress_ServerValidate"></asp:CustomValidator>
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
                <asp:ObjectDataSource ID="odsServiceRequestsInProgress" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucSRInProgress">
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