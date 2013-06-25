<%@ Page Language="C#" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" CodeBehind="units_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_navigator2" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td >
                    <asp:Label ID="lblTitle" runat="server" Text="Search Units" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuUnits" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Units" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddUnit" Text="Add Unit"></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mCategories" Text="Categories" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCompanyLevels" Text="Company Levels" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mUnitsInformationReport" Text="Units Information Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mUnitsChecklistReport" Text="Units Checklists Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mUnitsWithAlarmsReport" Text="Units With Alarms Report" ></telerik:RadPanelItem>
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
        
        <!-- Page element: Search & Sort components , 4 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 135px">
                        <asp:Label ID="lblFor" runat="server" SkinID="Label" Text="For" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 355px">
                    </td>                    
                    <td style="width: 135px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label></td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 345px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
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
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" OnServerValidate="cvForDateRange_ServerValidate"
                            SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForBoolean" runat="server" ControlToValidate="tbxCondition1" 
                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use Y, YES, N, NO, % or leave the field empty)"
                            SkinID="Validator" ValidateEmptyText="True" OnServerValidate="cvForBoolean_ServerValidate">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForMoneyCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use #.## format)" 
                            OnServerValidate="cvForMoneyCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 7px">
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
                        <asp:DropDownList style="WIDTH: 540px" id="ddlView" runat="server" SkinID="DropDownListLookup">
                        </asp:DropDownList> 
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60px" class="Background_SearchAndSort">
                            <tr>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewAdd" runat="server" style="width: 16px; height: 16px" ToolTip="Add View" OnClientClick="return btnViewAddClick();" EnableViewState="False" SkinID="ViewAddButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewEdit" runat="server" style="width: 16px; height: 16px" ToolTip="Edit View" OnClientClick="return btnViewEditClick();" EnableViewState="False" SkinID="ViewEditButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewDelete" runat="server" style="width: 16px; height: 16px" ToolTip="Delete View" OnClientClick="return btnViewDeleteClick();" EnableViewState="False" OnClick="btnViewDelete_Click" SkinID="ViewDeleteButton" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnGo" runat="server" SkinID="Button" Text="Go" Style="width: 80px"
                            EnableViewState="False" OnClick="btnGo_Click" OnClientClick="return btnGoClick();" /></td>
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
        
        <!-- Page element: Section title - Results-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label></td>
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
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select a unit."
                        Display="Dynamic" SkinID="Validator"></asp:CustomValidator></td>
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
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Total Rows"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Panel ID="pnlGrid" runat="server" Height="330px" Width="625px" ScrollBars="Horizontal">                                                         
                        <asp:GridView ID="grdUnitsNavigator" runat="server" AutoGenerateColumns="False" DataKeyNames="UnitID"
                            SkinID="GridView">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                            Checked='<%# Bind("Selected") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="UnitID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitID" runat="server" Style="width: 100px" Text='<%# Bind("UnitID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 2--%>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" runat="server" Style="width: 100px" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>     
                                
                                <%--Column 3--%>                       
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Style="width: 130px" Text='<%# Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 4--%>
                                <asp:TemplateField HeaderText="VIN/SN">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVinSN" runat="server" Style="width: 80px" Text='<%# Bind("VIN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <%--Column 5--%>
                                <asp:TemplateField HeaderText="State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Style="width: 80px" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 6--%>
                                <asp:TemplateField HeaderText="Manufacturer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblManufacturer" runat="server" Style="width: 80px" Text='<%# Bind("Manufacturer") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <%--Column 7--%>
                                <asp:TemplateField HeaderText="Model">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModel" runat="server" Style="width: 80px" Text='<%# Bind("Model") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 8--%>
                                <asp:TemplateField HeaderText="Is Towable?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIsTowable" runat="server" Checked='<%# Bind("IsTowable") %>'
                                            onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 9--%>
                                <asp:TemplateField HeaderText="Insurance Class">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsuranceClass" runat="server" Style="width: 80px" Text='<%# Bind("InsuranceClass") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 10--%>
                                <asp:TemplateField HeaderText="Ryder Specified">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsuranceClassRyderSpecified" runat="server" Style="width: 80px" Text='<%# Bind("InsuranceClassRyderSpecified") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 11 (before Column 9--%> 
                                <asp:TemplateField HeaderText="Model Year">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear" runat="server" Style="width: 70px" Text='<%# Bind("Year") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                
                                <%--Column 12--%>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Style="width: 200px" Text='<%# Bind("Categories") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 13--%>
                                <asp:TemplateField HeaderText="Company Level">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyLevel" runat="server" Style="width: 200px" Text='<%# Bind("CompanyLevel") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 14--%>
                                <asp:TemplateField HeaderText="Acquisition Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcquisitionDate" runat="server" Style="width: 200px" Text='<%# Bind("AcquisitionDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 15--%>
                                <asp:TemplateField HeaderText="Cost (CAD)">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostCad" runat="server" Style="width: 200px" Text='<%# Bind("CostCad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 16--%>
                                <asp:TemplateField HeaderText="Cost (USD)">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostUsd" runat="server" Style="width: 200px" Text='<%# Bind("CostUsd") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 17--%>
                                <asp:TemplateField HeaderText="License Country">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLicenseCountry" runat="server" Style="width: 200px" Text='<%# Bind("LicenseCountry") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 18--%>
                                <asp:TemplateField HeaderText="License State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLicenseState" runat="server" Style="width: 200px" Text='<%# Bind("LicenseState") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 19--%>
                                <asp:TemplateField HeaderText="License Plate Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLicensePlateNumbver" runat="server" Style="width: 200px" Text='<%# Bind("LicensePlateNumbver") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 20--%>
                                <asp:TemplateField HeaderText="Apportioned Tag Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAportionedTagNumber" runat="server" Style="width: 200px" Text='<%# Bind("AportionedTagNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 21--%>
                                <asp:TemplateField HeaderText="Actual Weight">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActualWeight" runat="server" Style="width: 200px" Text='<%# Bind("ActualWeight") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 22--%>
                                <asp:TemplateField HeaderText="Registered Weight">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDRegisteredWeight" runat="server" Style="width: 200px" Text='<%# Bind("RegisteredWeight") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 23--%>
                                <asp:TemplateField HeaderText="Tire Size Front">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTireSizeFront" runat="server" Style="width: 200px" Text='<%# Bind("TireSizeFront") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 24--%>
                                <asp:TemplateField HeaderText="Tire Size Back">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTireSizeBack" runat="server" Style="width: 200px" Text='<%# Bind("TireSizeBack") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 25--%>
                                <asp:TemplateField HeaderText="Number Of Axes">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberOfAxes" runat="server" Style="width: 200px" Text='<%# Bind("NumberOfAxes") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 26--%>
                                <asp:TemplateField HeaderText="Fuel Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFuelType" runat="server" Style="width: 200px" Text='<%# Bind("FuelType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 27--%>
                                <asp:TemplateField HeaderText="Beginning Odometer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBeginningOdometer" runat="server" Style="width: 200px" Text='<%# Bind("BeginningOdometer") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 28--%>
                                <asp:TemplateField HeaderText="Is Reefer Equipped?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIsReeferEquipped" runat="server" Checked='<%# Bind("IsReeferEquipped") %>'
                                            onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 29--%>
                                <asp:TemplateField HeaderText="Is PTO Equipped?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIsPTOEquipped" runat="server" Checked='<%# Bind("IsPTOEquipped") %>'
                                            onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                                             
                                <%--Column 30--%>
                                <asp:TemplateField HeaderText="Owner Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwnerType" runat="server" Style="width: 150px" Text='<%# Bind("OwnerType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 31--%>
                                <asp:TemplateField HeaderText="Owner Country">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwnerCountry" runat="server" Style="width: 150px" Text='<%# Bind("OwnerCountry") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 32--%>
                                <asp:TemplateField HeaderText="Owner State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwnerState" runat="server" Style="width: 150px" Text='<%# Bind("OwnerState") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 33--%>
                                <asp:TemplateField HeaderText="Owner Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwnerName" runat="server" Style="width: 150px" Text='<%# Bind("OwnerName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 34--%>
                                <asp:TemplateField HeaderText="Contact Info">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwnerContact" runat="server" Style="width: 150px" Text='<%# Bind("OwnerContact") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 35--%>
                                <asp:TemplateField HeaderText="Qualified Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQualifiedDate" runat="server" Style="width: 150px" Text='<%# Bind("QualifiedDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 36--%>
                                <asp:TemplateField HeaderText="Not Qualified Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotQualifiedDate" runat="server" Style="width: 150px" Text='<%# Bind("NotQualifiedDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 37--%>
                                <asp:TemplateField HeaderText="Not Qualified Explain">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotQualifiedExplain" runat="server" Style="width: 150px" Text='<%# Bind("NotQualifiedExplain") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 38--%>
                                <asp:TemplateField HeaderText="Notes">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotes" runat="server" Style="width: 250px" Text='<%# Bind("Notes") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>                    
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
                            <asp:Parameter DefaultValue="Units" Name="fmType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Units" Name="fmType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="inFor" Type="Boolean" />
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
                    <asp:HiddenField ID="hdfSelectedUnitId" runat="server" />
                    <asp:HiddenField ID="hdfBtnOrigin" runat="server" />
                    <asp:HiddenField ID="hdfFmType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>