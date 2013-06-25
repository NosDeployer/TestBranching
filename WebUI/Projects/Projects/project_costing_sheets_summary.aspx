<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="project_costing_sheets_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHeaderTitle" runat="server" Text="Project" SkinID="LabelPageTitle1" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleClientName" runat="server" Text="Client:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleProject" runat="server" Text="Project:" SkinID="LabelPageTitle2" EnableViewState="False"></asp:Label>
                    <asp:Label ID="lblTitleProjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px;">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuCurrentProject" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Current Project" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mProject" Text="Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectCostingSheets" Text="Project Costing Sheets" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar1_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSections" Text="Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar1_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectSynopsis" Text="Project Synopsis"></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuProjects" runat="server" SkinID="RadPanelBar2" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Projects" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddProject" Text="Add Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mDuplicateProposal" Text="Duplicate Proposal Tool" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mBallparkSummaryReport" Text="Ballpark Summary"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mTotalValueOfProposalsReport" Text="Total Value Of Proposals" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCurrentActiveWorkOnHandReport" Text="Current Active Work On Hand" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectsSummaryReport" Text="Projects Summary" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar2_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProductionReport" Text="Production Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mVideoCompleteReport" Text="Video Complete Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mDetailedCostingSheetReport" Text="Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCombinedDetailedCostingSheetReport" Text="Combined Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mConsolidatedCostingSheetReport" Text="Consolidated Costing Sheet"></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR-->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mPreview" Text="PREVIEW" />
                            
                            <telerik:RadMenuItem Value="mSetInProgress" Text="SET IN PROGRESS" />
                            
                            <telerik:RadMenuItem Value="mApprove" Text="APPROVE" />
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
        
        <!-- Table element: 1 columns - Section Details Title -->
       <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 185px">
                    <asp:Label ID="lblBasicInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="True"></asp:Label>
                </td>
                <td style="width: 185px">
                </td>
                <td style="width: 185px">
                </td>
                <td style="width: 185px">
                     <asp:TextBox ID="tbxState" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxSpecialWhite" Style="width: 175px"></asp:TextBox>
                </td>                
            </tr>
        </table>        
       
        <!-- Page element: 1 column - grid Team Members -->
        <div runat="server" id="dvLabourHourInformation" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTeamMembers" runat="server" SkinID="Label" Text="Labour Hours"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlTeamMembers" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdTeamMembers" runat="server" SkinID="GridView" Width="100%" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,Work_,EmployeeID,RefID"
                                    DataSourceID="odsTeamMembers" OnDataBound="grdTeamMembers_DataBound"
                                    PageSize="10">
                                    <Columns>
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="EmployeeID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeID" runat="server" SkinID="Label" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Work_" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTypeOfWork" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="Team Member">
                                            <HeaderStyle Width="95px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTeamMember" Width="95px" runat="server" SkinID="Label" Text='<%# Eval("Name") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="From">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--7--%>
                                        <asp:TemplateField HeaderText="To">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--8--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement/LH">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurementLH" Width="105px" runat="server" SkinID="Label"
                                                                    Text='<%# Eval("LHUnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--9--%>
                                        <asp:TemplateField HeaderText="LH Qty">
                                            <HeaderStyle Width="58px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblLHQty" Width="58px" runat="server" Text='<%# Eval("LHQuantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--10--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement/Meals" Visible="false">
                                            <HeaderStyle Width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurementMeals" Width="120px" runat="server" SkinID="Label"
                                                                    Text='<%# Eval("MealsUnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--11--%>
                                        <asp:TemplateField HeaderText="Meals Qty" Visible="false">
                                            <HeaderStyle Width="65px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblMealsQty" Width="65px" runat="server" Text='<%# Eval("MealsQuantity") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--12--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement/Motel" Visible="false">
                                            <HeaderStyle Width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurementMotel" Width="120px" runat="server" SkinID="Label"
                                                                    Text='<%# Eval("MotelUnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--13--%>
                                        <asp:TemplateField HeaderText="Motel Qty" Visible="false">
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblMotelQty" Width="60px" runat="server" Text='<%# Eval("MotelQuantity") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--14--%>
                                        <asp:TemplateField HeaderText="LH Cost (CAD)">
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblLHCostCAD" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("LHCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--15--%>
                                        <asp:TemplateField HeaderText="Meals Cost (CAD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMealsCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MealsCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--16--%>
                                        <asp:TemplateField HeaderText="Motel Cost (CAD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMotelCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MotelCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--17--%>
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--18--%>
                                        <asp:TemplateField HeaderText="LH Cost (USD)">
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblLHCostUSD" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("LHCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--19--%>
                                        <asp:TemplateField HeaderText="Meals Cost (USD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMealsCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MealsCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--20--%>
                                        <asp:TemplateField HeaderText="Motel Cost (USD)" Visible="false">
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblMotelCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MotelCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <%--21--%>
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 935px;">
                                </td>
                                <td style="width: 107px; text-align: right;">
                                    </td>
                                <td style="width: 103px; text-align: right;">
                                    
                                </td>
                                <td style="width: 200px;">
                                </td>
                                <td style="width: 107px; text-align: right;">
                                    <asp:Label ID="lblTeamMembersTotalCost" Width="107px" runat="server" SkinID="Label"
                                        Text="Total Cost (CAD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlTeamMembersTotalCostCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxTeamMembersTotalCostCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="103px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlTeamMembersTotalCostUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxTeamMembersTotalCostUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Units-->
        <div runat="server" id="dvTrucksEquipment" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUnits" runat="server" SkinID="Label" Text="Trucks / Equipment Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlUnits" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdUnits" runat="server" SkinID="GridView" Width="100%" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,Work_,UnitID,RefID"
                                    DataSourceID="odsUnits" OnDataBound="grdUnits_DataBound"
                                    PageSize="10">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="UnitID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitID" runat="server" SkinID="Label" Text='<%# Eval("UnitID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Work_" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTypeOfWork" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit Code">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitCode" Width="50px" runat="server" SkinID="Label" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px"></HeaderStyle>                                            
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit Description">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitDescription" Width="120px" runat="server" SkinID="Label" Text='<%# Eval("UnitDescription") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="120px"></HeaderStyle>                                            
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="From">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="To">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" runat="server" Width="105px" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 625px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblUnitsTotalCosts" Width="120px" runat="server" SkinID="Label" Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlUnitsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxUnitsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlUnitsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxUnitsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Materials-->
        <div runat="server" id="dvMaterial" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMaterials" runat="server" SkinID="Label" Text="Material Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlMaterials" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdMaterials" runat="server" SkinID="GridView" Width="100%" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,MaterialID,RefID"
                                    DataSourceID="odsMaterials" OnDataBound="grdMaterials_DataBound"
                                    PageSize="10">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="MaterialID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaterialID" runat="server" SkinID="Label" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProcess" Width="55px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="55px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDescription" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="From">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="To">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="85px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--Column 8--%>
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 500px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblMaterialsTotalCosts" Width="115px" runat="server" SkinID="Label"
                                        Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlMaterialsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxMaterialsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlMaterialsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxMaterialsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Subcontractors-->
        <div runat="server" id="dvSubcontractor" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSubcontractors" runat="server" SkinID="Label" Text="Other/Category/Subcontractor Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlSubcontractors" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdSubcontractors" runat="server" SkinID="GridView" Width="100%" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,SubcontractorID,RefID"
                                    DataSourceID="odsSubcontractors" OnDataBound="grdSubcontractors_DataBound"
                                    PageSize="10">
                                    <Columns>
                                    
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="SubcontractorID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubcontractorID" runat="server" SkinID="Label" Text='<%# Eval("SubcontractorID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Subcontractor">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblSubcontractorCode" Width="50px" runat="server" SkinID="Label" Text='<%# Eval("Subcontractor") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px"></HeaderStyle>                                            
                                        </asp:TemplateField>
                                        
                                        <%--4--%>                                        
                                        <asp:TemplateField HeaderText="Date">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="To" Visible="false">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="90px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--7--%>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--8--%>
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--9--%>
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--10--%>
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" runat="server" Width="105px" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--11--%>
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--12--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="200px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 335px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblSubcontractorsTotalCosts" Width="120px" runat="server" SkinID="Label" Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlSubcontractorsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxSubcontractorsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlSubcontractorsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxSubcontractorsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 200px; text-align: right;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Hotels-->
        <div runat="server" id="dvHotel" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHotels" runat="server" SkinID="Label" Text="Other/Category/Hotel Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlHotels" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdHotels" runat="server" SkinID="GridView" Width="710px" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,HotelID,RefID"
                                    DataSourceID="odsHotels" OnDataBound="grdHotels_DataBound"
                                    PageSize="10">
                                    <Columns>
                                    
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="HotelID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHotelID" runat="server" SkinID="Label" Text='<%# Eval("HotelID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Hotel">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblHotel" Width="210px" runat="server" SkinID="Label" Text='<%# Eval("Hotel") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="210px"></HeaderStyle>                                            
                                        </asp:TemplateField>
                                        
                                        <%--4--%>                                        
                                        <asp:TemplateField HeaderText="Date">
                                            <HeaderStyle Width="132px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="132px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="To" Visible="false">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblRate" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("Rate", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--7--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="200px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 258px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblHotelsTotalCosts" Width="120px" runat="server" SkinID="Label" Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlHotelsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxHotelsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlHotelsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxHotelsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 200px; text-align: right;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Bondings-->
        <div runat="server" id="dvBonding" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBondings" runat="server" SkinID="Label" Text="Other/Category/Bonding Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlBondings" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdBondings" runat="server" SkinID="GridView" Width="710px" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,BondingCompanyID,RefID"
                                    DataSourceID="odsBondings" OnDataBound="grdBondings_DataBound"
                                    PageSize="10">
                                    <Columns>
                                    
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="BondingCompanyID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBondingCompanyID" runat="server" SkinID="Label" Text='<%# Eval("BondingCompanyID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Company">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblBonding" Width="210px" runat="server" SkinID="Label" Text='<%# Eval("Bonding") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="210px"></HeaderStyle>                                            
                                        </asp:TemplateField>
                                        
                                        <%--4--%>                                        
                                        <asp:TemplateField HeaderText="Date">
                                            <HeaderStyle Width="132px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="132px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="To" Visible="false">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblRate" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("Rate", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--7--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="200px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 258px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblBondingsTotalCosts" Width="120px" runat="server" SkinID="Label" Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlBondingsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxBondingsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlBondingsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxBondingsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 200px; text-align: right;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Insurances-->
        <div runat="server" id="dvInsurance" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblInsurances" runat="server" SkinID="Label" Text="Other/Category/Insurance Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlInsurances" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdInsurances" runat="server" SkinID="GridView" Width="710px" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,InsuranceCompanyID,RefID"
                                    DataSourceID="odsInsurances" OnDataBound="grdInsurances_DataBound"
                                    PageSize="10">
                                    <Columns>
                                    
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="InsuranceCompanyID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInsuranceCompanyID" runat="server" SkinID="Label" Text='<%# Eval("InsuranceCompanyID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Company">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblInsurance" Width="210px" runat="server" SkinID="Label" Text='<%# Eval("Insurance") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="210px"></HeaderStyle>                                            
                                        </asp:TemplateField>
                                        
                                        <%--4--%>                                        
                                        <asp:TemplateField HeaderText="Date">
                                            <HeaderStyle Width="132px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="132px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="To" Visible="false">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblRate" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("Rate", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--7--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="200px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 258px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblInsurancesTotalCosts" Width="120px" runat="server" SkinID="Label" Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlInsurancesTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxInsurancesTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlInsurancesTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxInsurancesTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 200px; text-align: right;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Other Category-->
        <div runat="server" id="dvOtherCategory" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOtherCategory" runat="server" SkinID="Label" Text="Other/Category/OtherCategory Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlOtherCategory" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdOtherCategory" runat="server" SkinID="GridView" Width="710px" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,Category,RefID"
                                    DataSourceID="odsOtherCategory" OnDataBound="grdOtherCategory_DataBound"
                                    PageSize="10">
                                    <Columns>
                                    
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="Category" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory" runat="server" SkinID="Label" Text='<%# Eval("Category") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblOtherCategory" Width="210px" runat="server" SkinID="Label" Text='<%# Eval("Category") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="210px"></HeaderStyle>                                            
                                        </asp:TemplateField>
                                        
                                        <%--4--%>                                        
                                        <asp:TemplateField HeaderText="Date">
                                            <HeaderStyle Width="132px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="132px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="To" Visible="false">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblRate" runat="server" Width="100px" SkinID="Label" Text='<%# Eval("Rate", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--7--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="200px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 258px;">
                                </td>
                                <td style="width: 115px; text-align: right;">
                                    <asp:Label ID="lblOtherCategoryTotalCosts" Width="120px" runat="server" SkinID="Label" Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlOtherCategoryTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxOtherCategoryTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="upnlOtherCategoryTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxOtherCategoryTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="width: 200px; text-align: right;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <!-- Page element: 1 column - grid Other Costs-->
        <div runat="server" id="dvOtherCost" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOtherCosts" runat="server" SkinID="Label" Text="Misc Costs"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlOtherCosts" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdOtherCosts" runat="server" SkinID="GridView" Width="810px" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,RefID" DataSourceID="odsOtherCosts"
                                    OnDataBound="grdOtherCosts_DataBound" PageSize="10">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0" >
                                                    <tbody>
                                                        <tr>
                                                            <td >
                                                                <asp:Label ID="lblWorkFunction" Width="150px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="150px" Wrap="false"></HeaderStyle>
                                            <ItemStyle Width="150px" Wrap="false" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDescription" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" Wrap="true"></HeaderStyle>
                                            <ItemStyle Width="100px" Wrap="true" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="From">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="To">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblTo" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUnitOfMeasurement" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="90px" Wrap="true"></HeaderStyle>
                                            <ItemStyle Width="90px" Wrap="true" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQuantity" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px" Wrap="true"></HeaderStyle>
                                            <ItemStyle Width="60px" Wrap="true" />
                                        </asp:TemplateField>
                                        
                                        <%--Column 7--%>
                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px" Wrap="false"></HeaderStyle>
                                            <ItemStyle Width="105px" Wrap="false" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostCAD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" Wrap="true"></HeaderStyle>
                                            <ItemStyle Width="100px" Wrap="true" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="105px" Wrap="true"></HeaderStyle>
                                            <ItemStyle Width="105px" Wrap="true" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTotalCostUSD" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" Wrap="true"></HeaderStyle>
                                            <ItemStyle Width="100px" Wrap="true" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 620px;">
                                </td>
                                <td style="width: 110px; text-align: right;">
                                    <asp:Label ID="lblOtherCostsTotalCosts" runat="server" SkinID="Label" 
                                        Text="(USD) : "></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: right;">
                                    <asp:UpdatePanel ID="upnlOtherCostsTotalCostsCAD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxOtherCostsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="unplOtherCostsTotalCostsUSD" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxOtherCostsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                Width="105px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
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
        
        <!-- Table element: 5 columns - Detailed information title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
            <tr>
                <td colspan="2" style="width:50px;">
                </td>
                <td style="width:100px;">
                </td>
                <td style="width:130px;">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: right;">
                </td>
                <td>                    
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblGrandTotalCost" runat="server" SkinID="Label" 
                        Text="Total Cost (CAD) : "></asp:Label>
                    </td>
                <td>
                    <asp:UpdatePanel ID="upnlTotalCostCad" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxTotalCostCad" runat="server" SkinID="TextBoxRightReadOnly"
                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"> </asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upnlTotalCostUsd" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxTotalCostUsd" runat="server" SkinID="TextBoxRightReadOnly"
                                Width="100px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"> </asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        
        <div runat="server" id="dvRevenue" style="overflow-x: auto; overflow-y: auto; width: 710px">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRevenueInformation" runat="server" SkinID="Label" Text="Revenue Information"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upnlRevenue" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdRevenue" runat="server" SkinID="GridView" Width="700px" AllowPaging="True"
                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,RefIDRevenue" DataSourceID="odsRevenue"
                                    PageSize="9">
                                    <Columns>
                                        <%--0--%>
                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--1--%>
                                        <asp:TemplateField HeaderText="RefIDRevenue" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefIDRevenue" runat="server" SkinID="Label" Text='<%# Eval("RefIDRevenue") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--2--%>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="150px" />
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                    Style="width: 150px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--3--%>
                                        <asp:TemplateField HeaderText="Revenue">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblRevenue" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("Revenue", "{0:n2}") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                        </asp:TemplateField>
                                        
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemTemplate>
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblComment" Width="400px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="400px"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 115px; text-align: left;">
                                    <asp:Label ID="lblRevenueTotal" Width="115px" runat="server" SkinID="Label" Text="Total Revenue : "></asp:Label>
                                </td>
                                <td style="width: 115px; text-align: left;">
                                    <asp:UpdatePanel ID="upTotalRevenue" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbxRevenueTotal" runat="server" SkinID="TextBoxRightReadOnly" Width="115px"
                                                ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height:7px">
                    </td>
                </tr>
            </table>
            
            <table cellpadding="0" cellspacing="0" width="0" style="width: 480px">
                <tr>
                    <td style="width: 120px">
                    </td>
                    <td style="width: 120px">
                    </td>
                    <td style="width: 120px">
                    </td>
                    <td style="width: 120px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblRevenueSummary" runat="server" SkinID="Label" Text="Revenue Summary"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGrandRevenue" runat="server" Text="Revenue" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGrandProfit" runat="server" Text="Profit" SkinID="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGrandGrossMargin" runat="server" Text="Gross Margin" SkinID="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbxGrandTotal" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true"
                            Width="110px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxGrandRevenue" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true"
                            Width="110px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxGrandProfit" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true"
                            Width="110px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxGrandGrossMargin" runat="server" SkinID="TextBoxRightReadOnly"
                            ReadOnly="true" Width="110px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>     
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsTeamMembers" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetLabourHoursInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnits" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetUnitsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterials" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetMaterialsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSubcontractors" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetSubcontractorsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsHotels" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetHotelsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBondings" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetBondingsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsInsurances" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetInsurancesInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOtherCategory" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetOtherCategoryInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOtherCosts" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetOtherCostsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsRevenue" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRevenueInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_summary">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
                        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCostingSheetId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                    <asp:HiddenField ID="hdfBeforeUnloadOrigen" runat="server" />
                    <asp:HiddenField ID="hdfDataChanged" runat="server" />
                    <asp:HiddenField ID="hdfDataChangedMessage" runat="server" /> 
                     <asp:HiddenField ID="hdfDeleteme" runat="server" />
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>