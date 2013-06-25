<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="vacations_cancel_vacation_request.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_cancel_vacation_request" %>

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
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Cancel Vacation Requests"></asp:Label>
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
                            <telerik:RadMenuItem Value="mCancelRequest" Text="CANCEL REQUEST" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <!-- Page element : No results bar -->
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 10px">
                </td>
                <td style="width: 730px" class="Background_NavigatorsNoResults">
                    <asp:Label ID="lblNoResults" runat="server" Text="No vacations for cancel."></asp:Label>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
        </table>
        
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="At least one vacation request must be selected."
                        Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td style="width: 625px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Total Rows"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Panel ID="pnlGrid" runat="server" Width="740px" Height="200px" ScrollBars="Auto">
                        <asp:GridView ID="grdVacations" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="RequestID" SkinID="GridView" >
                            <Columns>
                            
                                <%--Column 0--%>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelected" runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 1--%>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Width="80px" Text='<%# Bind("StartDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 2--%>
                                <asp:TemplateField HeaderText="End Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate" runat="server" Width="80px" Text='<%# Bind("EndDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 3--%>
                                <asp:TemplateField HeaderText="Team Member">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeName" runat="server" Width="90px" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 4--%>
                                <asp:TemplateField HeaderText="State">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Width="80px" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 5--%>
                                <asp:TemplateField HeaderText="Detail">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetails" runat="server" Width="370px" Text='<%# Bind("Details") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 6--%>
                                <asp:TemplateField HeaderText="EmployeeID" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeId" runat="server" Width="0px" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>                    
                    </asp:Panel> 
                </td>                
            </tr>
        </table>
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
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
</asp:Content>