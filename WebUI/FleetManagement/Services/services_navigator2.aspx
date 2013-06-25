<%@ Page Language="C#"  Title="LFS Live" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" CodeBehind="services_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_navigator2" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td >
                    <asp:Label ID="lblTitle" runat="server" Text="Search Service Requests" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuMyServiceRequests" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="My Service Requests" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddServiceRequest" Text="Add Service Request"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuAllServiceRequests" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="All Service Requests" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddServiceRequest" Text="Add Service Request"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mSRManager" Text="Service Requests Manager" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mMyCurrentSR" Text="My Current Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRUnassigned" Text="Unassigned Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRRejected" Text="Rejected Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRAboutToExpire" Text="About To Expire Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRExpired" Text="Expired Service Requests" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>                      
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Search &  Sort Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td>
                    <asp:Label ID="lblSearchAndSort" runat="server" SkinID="LabelTitle1" Text="Search & Sort" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Search & Sort components , 5 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">        
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 135px">
                        <asp:Label ID="lblFor" runat="server" SkinID="Label" Text="For" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 220px">
                    </td>
                    <td style="width: 135px">
                        <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" Text="State"></asp:Label>
                    </td>    
                    <td style="width: 135px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 210px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsState" DataTextField="State" DataValueField="State">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsSortByList" DataTextField="Name" DataValueField="SortID">
                        </asp:DropDownList>
                    </td>                
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px" OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" OnServerValidate="cvForDateRange_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForBoolean" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" 
                            ErrorMessage="Invalid data. (use Y, YES, N, NO, % or leave the field empty)"
                            OnServerValidate="cvForBoolean_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForMoneyCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" 
                            ErrorMessage="Invalid data. (use #.## format)" 
                            OnServerValidate="cvForMoneyCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 7px">
                    </td>
                </tr>
            </table>
        </asp:Panel> 
        
        <asp:Panel ID="pnlDefaultViewSearch" runat="server" Width="100%" DefaultButton="btnGo">          
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">            
                <tr>
                    <td>
                        <asp:Label ID="lblView" runat="server" SkinID="Label" Text="View" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel id="upnlViews" runat="server">
                            <contenttemplate>
                                <asp:DropDownList style="WIDTH: 540px" id="ddlView" runat="server" SkinID="DropDownListLookup">
                                </asp:DropDownList> 
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60px" class="Background_SearchAndSort">
                            <tr>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button  ID="btnViewAdd" runat="server" style="width: 16px; height:16px" ToolTip="Add View" OnClientClick="return btnViewAddClick();" EnableViewState="False" SkinID="ViewAddButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewEdit" runat="server" style="width: 16px; height:16px" ToolTip="Edit View" OnClientClick="return btnViewEditClick();" EnableViewState="False" SkinID="ViewEditButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewDelete" runat="server" style="width: 16px; height:16px" ToolTip="Delete View" OnClientClick="return btnViewDeleteClick();" EnableViewState="False" OnClick="btnViewDelete_Click" SkinID="ViewDeleteButton" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnGo" runat="server" SkinID="Button" Text="Go" Style="width: 80px"
                            EnableViewState="False" OnClick="btnGo_Click" OnClientClick="return btnGoClick();" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <!-- Page element : Horizontal Rule -->
        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td style="height: 2px" class="Background_Separator">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Section title - Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select a service." Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label" Text="Total Rows"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <div runat="server" id="dvGrid" style="overflow-x:auto; overflow-y:hidden; Width:625px">
                    <asp:GridView ID="grdServicesNavigator" runat="server" AutoGenerateColumns="False" DataKeyNames="ServiceID"
                        SkinID="GridView">
                        <Columns>
                        
                            <%--Column 0--%>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server" Checked='<%# Bind("Selected") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 1--%>
                            <asp:TemplateField HeaderText="ServiceID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblServiceID" runat="server" Style="width: 100px" Text='<%# Bind("ServiceID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            
                            <%--Column 2--%>
                            <asp:TemplateField HeaderText="Service Number">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblServiceNumber" runat="server" Style="width: 60px" Text='<%# Bind("ServiceNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 3--%>
                            <asp:TemplateField HeaderText="Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDateTime_" runat="server" Style="width: 100px" Text='<%# Bind("DateTime_", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 4--%>
                            <asp:TemplateField HeaderText="Fixed Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxMTO" runat="server" Checked='<%# Bind("MTO") %>'
                                        onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 5--%>
                            <asp:TemplateField HeaderText="Service State">
                                <ItemTemplate>
                                    <asp:Label ID="lblState" runat="server" Style="width: 100px" Text='<%# Bind("State") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 6--%>
                            <asp:TemplateField HeaderText="Problem Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblProblemDescription" runat="server" Style="width: 120px" Text='<%# Bind("ProblemDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 7--%>
                            <asp:TemplateField HeaderText="Unit Code">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitCode" runat="server" Style="width: 80px" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 8--%>
                            <asp:TemplateField HeaderText="Unit Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitDescription" runat="server" Style="width: 120px" Text='<%# Bind("UnitDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 9--%>
                            <asp:TemplateField HeaderText="VIN/SN">
                                <ItemTemplate>
                                    <asp:Label ID="lblVIN" runat="server" Style="width: 120px" Text='<%# Bind("VIN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 10--%>
                            <asp:TemplateField HeaderText="Unit State">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitState" runat="server" Style="width: 100px" Text='<%# Bind("UnitState") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 11--%>
                            <asp:TemplateField HeaderText="Checklist Rule">
                                <ItemTemplate>
                                    <asp:Label ID="lblChecklistRule" runat="server" Style="width: 100px" Text='<%# Bind("ChecklistRule") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 12--%>
                            <asp:TemplateField HeaderText="Checklist State">
                                <ItemTemplate>
                                    <asp:Label ID="lblChecklistState" runat="server" Style="width: 100px" Text='<%# Bind("ChecklistState") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 13--%>
                            <asp:TemplateField HeaderText="Created by">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBy" runat="server" Style="width: 100px" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 14--%>
                            <asp:TemplateField HeaderText="Mileage">
                                <ItemTemplate>
                                    <asp:Label ID="lblMileage" runat="server" Style="width: 100px" Text='<%# Bind("Mileage") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 15--%>
                            <asp:TemplateField HeaderText="Assign Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAssignDateTime" runat="server" Style="width: 100px" Text='<%# Bind("AssignDateTime", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 16--%>
                            <asp:TemplateField HeaderText="Deadline Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDeadlineDate" runat="server" Style="width: 100px" Text='<%# Bind("DeadlineDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 17--%>
                            <asp:TemplateField HeaderText="Assigned to">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssignedTo" runat="server" Style="width: 100px" Text='<%# Bind("AssignedTo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 18--%>
                            <asp:TemplateField HeaderText="Accepted Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAcceptDateTime" runat="server" Style="width: 100px" Text='<%# Bind("AcceptDateTime", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 19--%>
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Style="width: 100px" Text='<%# Bind("StartDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 20--%>
                            <asp:TemplateField HeaderText="Unit Out Of Service Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStartWorkOutOfServiceDate" runat="server" Style="width: 100px" Text='<%# Bind("StartWorkOutOfServiceDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 21--%>
                            <asp:TemplateField HeaderText="Unit Out Of Service Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartWorkOutOfServiceTime" runat="server" Style="width: 100px" Text='<%# Bind("StartWorkOutOfServiceTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 22--%>
                            <asp:TemplateField HeaderText="Start Work Mileage">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartWorkMileage" runat="server" Style="width: 100px" Text='<%# Bind("StartWorkMileage") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 23--%>
                            <asp:TemplateField HeaderText="Complete Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompleteDate" runat="server" Style="width: 100px" Text='<%# Bind("CompleteDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 24--%>
                            <asp:TemplateField HeaderText="Unit Back In Service Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompleteWorkBackToServiceDate" runat="server" Style="width: 100px" Text='<%# Bind("CompleteWorkBackToServiceDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 25--%>
                            <asp:TemplateField HeaderText="Unit Back In Service Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompleteWorkBackToServiceTime" runat="server" Style="width: 100px" Text='<%# Bind("CompleteWorkBackToServiceTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 26--%>
                            <asp:TemplateField HeaderText="Complete Work Mileage">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompleteWorkMileage" runat="server" Style="width: 100px" Text='<%# Bind("CompleteWorkMileage") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 27--%>
                            <asp:TemplateField HeaderText="Work Details">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompleteWorkDetailDescription" runat="server" Style="width: 100px" Text='<%# Bind("CompleteWorkDetailDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 28--%>
                            <asp:TemplateField HeaderText="Preventable">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxCompleteWorkDetailPreventable" runat="server" Checked='<%# Bind("CompleteWorkDetailPreventable") %>'
                                        onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 29--%>
                            <asp:TemplateField HeaderText="Labour Hours">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompleteWorkDetailTMLabourHours" runat="server" Style="width: 100px" Text='<%# GetRound(Eval("CompleteWorkDetailTMLabourHours"),2) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                          
                                                        
                            <%--Column 30--%>
                            <asp:TemplateField HeaderText="Notes">
                                <ItemTemplate>
                                    <asp:Label ID="lblNotes" runat="server" Style="width: 100px" Text='<%# Bind("Notes") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 31--%>
                            <asp:TemplateField HeaderText="Working Location">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkingLocation" runat="server" Style="width: 100px" Text='<%# Bind("WorkingLocation") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                    &nbsp;
                    </div>
                </td>
                <td style="vertical-align: top">
                
                    <!-- Table element: 1 column -->
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                
                        <!-- Page element : Buttons -->
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                Style="width: 80px" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                    Style="width: 80px" OnClick="btnEdit_Click" />
                            </td>
                        </tr>                        
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnGoToSRManager" runat="server" EnableViewState="False" SkinID="Button" Text="SR Manager"
                                Style="width: 80px" OnClick="btnGoToSRManager_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnExportList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                    Text="Delete" Style="width: 80px" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 60px">
                </td>
                <td>
                </td>
            </tr>
        </table>       
                
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsViewForDisplayList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Services" Name="fmType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Services" Name="fmType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsState" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Services.ServiceStateList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
             
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedServiceId" runat="server" />
                    <asp:HiddenField ID="hdfBtnOrigin" runat="server" />
                    <asp:HiddenField ID="hdfFmType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>