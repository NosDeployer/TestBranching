<%@ Control Language="C#" AutoEventWireup="true" Codebehind="wucItemsAboutToExpire.ascx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucItemsAboutToExpire" %>
    
<div style="width: 230px; height: 460px;">

    <!-- Table element: 1 columns - SR About To Expired Title -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblSrAboutToExpired" runat="server" SkinID="LabelTitle2" Text="SR About To Expired"
                EnableViewState="False"></asp:Label>        
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
    
    <!-- Table element: 1 columns - Dropdownlist for periods and working location -->
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
                <asp:Label ID="lblPeriod" runat="server" SkinID="Label" Text="Period"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlPeriod" runat="server" AutoPostBack="true" Height="16px" SkinID="DropDownList"
                 EnableViewState="false" Width="220px" OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged">
                    <asp:ListItem Text="0 days" Value="0 days" Selected="True"></asp:ListItem>                                 
                    <asp:ListItem Text="1 days" Value="1 days"></asp:ListItem>
                    <asp:ListItem Text="5 days" Value="5 days"></asp:ListItem>
                    <asp:ListItem Text="1 week" Value="1 week"></asp:ListItem>
                    <asp:ListItem Text="1 month" Value="1 month"></asp:ListItem>
                    <asp:ListItem Text="3 months" Value="3 months"></asp:ListItem>
                    <asp:ListItem Text="6 months" Value="6 months"></asp:ListItem>
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
    
    <!-- Table element: 1 columns - Items About To Expire grid -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100px">
        <tr>
            <td>
                <asp:UpdatePanel id="upnlItemsAboutToExpire" runat="server">
                    <contenttemplate>
                        <asp:GridView ID="grdItemsAboutToExpire" runat="server" SkinID="GridView" Width="220px"
                            DataKeyNames="ServiceID" DataSourceID="odsItemsAboutToExpire" OnDataBound="grdItemsAboutToExpire_DataBound"
                            PageSize="5" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdItemsAboutToExpire_PageIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID"
                                    HeaderText="COMPANY_ID"></asp:BoundField>
                                    
                                <asp:BoundField ReadOnly="True" DataField="ServiceID" Visible="False" SortExpression="ServiceID"
                                    HeaderText="ServiceID"></asp:BoundField>
                                    
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Service Request">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:HyperLink ID="hlkItemsAboutToExpire" runat="server" SkinID="HyperLink" ToolTip='<%# Bind("ServiceDescription") %>' Text='<%# Bind("ItemsAboutToExpireCompleteName") %>' 
                                            NavigateUrl='<%# GetUrl( Eval("ServiceID")) %>' Target="_parent" >
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </contenttemplate>
                </asp:UpdatePanel>    
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
                <asp:ObjectDataSource ID="odsItemsAboutToExpire" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetDetails" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls.wucItemsAboutToExpire">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    
    <!-- Page element : Tag page -->
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                <asp:HiddenField ID="hdfCompanyId" runat="server" />
            </td>
        </tr>
    </table>
    
</div>