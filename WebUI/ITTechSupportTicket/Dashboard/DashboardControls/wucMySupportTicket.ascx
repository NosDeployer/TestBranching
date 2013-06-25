<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMySupportTicket.ascx.cs" Inherits="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.Dashboard.DashboardControls.wucMySupportTicket" %>

<div style="width: 230px; height: 460px;">

    <!-- Table element: 1 columns - Add Support Ticket -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:LinkButton ID="lkbtnAddSupportTicket" runat="server" EnableViewState="False" SkinID="LinkButton">Add Support Ticket</asp:LinkButton></td>
        </tr>        
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table> 
    
    <!-- Table element: 1 columns - My Support Ticket Title -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblMySupportTicket" runat="server" SkinID="LabelTitle2" Text="My Support Ticket" EnableViewState="False"></asp:Label>        
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
                <asp:Label ID="lblState" runat="server" SkinID="Label" Text="State"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlStateMySupportTicket" runat="server" EnableViewState="False" AutoPostBack="true" SkinID="DropDownList" Style="width: 220px" OnSelectedIndexChanged="ddlStateMySupportTicket_SelectedIndexChanged">
                    <asp:ListItem Text="(All)" Value="(All)"></asp:ListItem>
                    <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                    <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                    <asp:ListItem Text="New" Value="New"></asp:ListItem>
                    <asp:ListItem Value="New &#38; In Progress">New &#38; In Progress</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
        
    <!-- Table element: 1 columns - My Support Ticket Grid -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100px">
        <tr>
            <td>
                <asp:UpdatePanel id="upnlMySupportTickets" runat="server">
                    <contenttemplate>
                        <asp:GridView ID="grdMySupportTicket" runat="server" SkinID="GridView" Width="220px"
                            DataKeyNames="SupportTicketID" DataSourceID="odsMySupportTicket" OnDataBound="grdMySupportTicket_DataBound"
                            PageSize="8" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdMySupportTicket_PageIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID" HeaderText="COMPANY_ID"></asp:BoundField>
                                    
                                <asp:BoundField ReadOnly="True" DataField="SupportTicketID" Visible="False" SortExpression="SupportTicketID" HeaderText="SupportTicketID"></asp:BoundField>
                                    
                                <asp:TemplateField HeaderText="Category">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblCategoryNameAssignedToMe" runat="server" Style="width: 30px" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Support Ticket">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:HyperLink ID="hlkMySupportTicket" runat="server" SkinID="HyperLink" Text='<%# Bind("Subject") %>' 
                                            NavigateUrl='<%# GetUrl( Eval("SupportTicketID")) %>' ToolTip='<%# Bind("LastComment") %>' Target="_parent" >
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
                    </contenttemplate>
                </asp:UpdatePanel>    
            </td>
        </tr>        
    </table>
    
    <!-- Table element: 1 columns - Separator -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td style="height: 10px">
            </td>
        </tr>        
    </table> 
    
    <!-- Table element: 1 columns - My Support Ticket Grid On Hold-->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100px">
        <tr>
            <td>
                <asp:UpdatePanel id="upnlOnHold" runat="server">
                    <contenttemplate>
                        <asp:GridView ID="grdMySupportTicketOnHold" runat="server" SkinID="GridView" Width="220px"
                            DataKeyNames="SupportTicketID" DataSourceID="odsMySupportTicketOnHold" OnDataBound="grdMySupportTicketOnHold_DataBound"
                            PageSize="5" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="grdMySupportTicketOnHold_PageIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="COMPANY_ID" Visible="False" SortExpression="COMPANY_ID"
                                    HeaderText="COMPANY_ID"></asp:BoundField>
                                    
                                <asp:BoundField ReadOnly="True" DataField="SupportTicketID" Visible="False" SortExpression="SupportTicketID"
                                    HeaderText="SupportTicketID"></asp:BoundField>
                                    
                                <asp:TemplateField HeaderText="Category">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="30px"></HeaderStyle>
                                    <ItemTemplate>                                
                                        <asp:Label ID="lblCategoryNameAssignedToMeOnHold" runat="server" Style="width: 30px" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Support Ticket On Hold">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>                                
                                        <asp:HyperLink ID="hlkMySupportTicket" runat="server" SkinID="HyperLink" Text='<%# Bind("Subject") %>' 
                                            NavigateUrl='<%# GetUrl( Eval("SupportTicketID")) %>'  ToolTip='<%# Bind("LastComment") %>' Target="_parent" >
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
                    </contenttemplate>
                </asp:UpdatePanel>    
            </td>
        </tr>        
    </table>
    
    <!-- Table element: 1 columns - Go To Navigator -->
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lkbtnAssignServiceRequest" runat="server" EnableViewState="False" 
                SkinID="LinkButton" OnClick="lkbtnViewNavigator_Click">View all my support tickets</asp:LinkButton>
            </td>                
        </tr>        
        <tr>
            <td style="height: 10px">
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
                <asp:ObjectDataSource ID="odsMySupportTicket" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetDetails" TypeName="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.Dashboard.DashboardControls.wucMySupportTicket">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMySupportTicketOnHold" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetDetailsOnHold" TypeName="LiquiForce.LFSLive.WebUI.ITTechSupportTicket.Dashboard.DashboardControls.wucMySupportTicket">
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