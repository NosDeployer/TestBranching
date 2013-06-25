<%@ Page Language="C#"  MasterPageFile="./../../mForm6.master"  AutoEventWireup="true" CodeBehind="ra_lining_plan.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.RehabAssessment.ra_lining_plan"  Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Rehab Assessment Plan" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleClientName" runat="server" Text="Client:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleProjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" SkinID="ButtonPageTitle" EnableViewState="False" OnClick="btnChange_Click"/>
                </td>
                <td style="width:10px">
                </td>                
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <div style="width: 750px">
        <table id="tPreview" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mPreview" Text="PREVIEW"/>
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Rehab Assessment" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mRehabAssessmentPlan" Text="Rehab Assessment Plan" Selected="true" PostBack="false"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mBulkUpload" Text="Bulk Upload" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mWincapBulkUpload" Text="Wincan (Lateral) Bulk Upload" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mM1M2ReportByClient" Text="M1 &amp; M2 Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOpenedAndBrushed" Text="Opened And Brushed Report" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>                      
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Order by -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">            
            <tr>
                <td style="width: 10px">
                </td>
                <td style="width: 130px">
                    <asp:Label ID="lblOrder" runat="server" SkinID="Label" Text="Order Sections By" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 90px">
                </td>
                <td style="width: 510px">
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrder" runat="server" SkinID="DropDownList" Width="120px">
                        <asp:ListItem>Default</asp:ListItem>
                        <asp:ListItem>Per selection</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnOrder" runat="server" SkinID="Button" Text="Order" Width="80px" OnClick="btnOrder_Click" EnableViewState="False" /></td>
                <td></td>                        
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <!-- Page element : No results bar -->
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 10px">
                </td>
                <td style="width: 730px" class="Background_NavigatorsNoResults">
                    <asp:Label ID="lblNoResults" runat="server" Text="No results for your query"></asp:Label>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
        </table>
        <!-- Page element: Grid results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 10px">
                </td>
                <td style="width: 730px">
                    <asp:GridView ID="grdLiningPlan" runat="server" AutoGenerateColumns="False" PageSize="1"
                        Width="100%" GridLines="None" ShowHeader="False" AllowSorting="True" OnSorting="grdLiningPlan_Sorting"
                        EnableViewState="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <!-- Table element : 5 columns - Section row -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%"  class="Background_ViewGrid_Table">
                                        <tr>
                                            <td style="width: 100%" class="Background_ViewGrid_Header">
                                                <!-- Table element: 5 columns - Header data -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">
                                                    <tr>
                                                        <td style="width: 110px">
                                                            <asp:Label ID="lblHeader" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Order"></asp:Label>
                                                        </td>
                                                        <td style="width: 450px" colspan="4">
                                                            <asp:Label ID="lblHeader2" runat="server" EnableViewState="False" SkinID="ViewGridHeader"                                                                Text="Section available for Rehab Assessment"></asp:Label>
                                                        </td>
                                                        <td style="width: 170px" colspan="2">
                                                            <asp:Label ID="lblHeader3" runat="server" EnableViewState="False" SkinID="ViewGridHeader"
                                                                Text="Setup"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Background_ViewGrid_Td">
                                                <!-- Table element: 5 columns - LiningPlan fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 110px; vertical-align: middle; text-align: center;">
                                                            <asp:DropDownList ID="ddlSelected" runat="server" Width="70px" SkinID="DropDownList"
                                                                SelectedValue='<%# Eval("Selected") %>'>
                                                                <asp:ListItem Selected="True" Value="9">(None)</asp:ListItem>
                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                                <asp:ListItem Value="6">6</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>                                        
                                                        <td style="width: 1px" class="ViewGrid_Separator">
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>
                                                        <td style="width: 430; vertical-align: top">
                                                            <!-- Table element: 3 columns - Section data -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 430px">
                                                                <tr>
                                                                    <td style="width: 107px; height: 15px">
                                                                        <asp:HiddenField ID="hdfAssetId" runat="server" Value='<%# Eval("AssetID") %>' />
                                                                    </td>
                                                                    <td style="width: 107px">
                                                                        <asp:HiddenField ID="hdfWorkId" runat="server" Value='<%# Eval("WorkID") %>' />
                                                                    </td>
                                                                    <td style="width: 107px">
                                                                        <asp:HiddenField ID="hdfSectionID" runat="server" EnableViewState="false" Value='<%# Eval("SectionID") %>' />
                                                                    </td>
                                                                    <td style="width: 109px">
                                                                        <asp:HiddenField ID="hdfCompanyId" runat="server" Value='<%# Eval("COMPANY_ID") %>' />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSectionId" runat="server" Text="Section ID" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxFlowOrderId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="97px" Text='<%# Eval("FlowOrderID") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblStreet" runat="server" Text="Street" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="lblSubArea" runat="server" Text="Sub Area" SkinID="Label"
                                                                            EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="tbxStreet" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="204px" Text='<%# Eval("Street") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="tbxSubArea" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="204px" Text='<%# Eval("SubArea") %>' EnableViewState="False"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblUSMH" runat="server" Text="USMH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDSMH" runat="server" Text="DSMH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxUSMH" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="97px" Text='<%# Eval("USMHDescription") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDSMH" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="97px" Text='<%# Eval("DSMHDescription") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 20px">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>                                        
                                                        <td style="width: 1px" class="ViewGrid_Separator">
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>
                                                        <td style="width: 170px; vertical-align: top">
                                                            <!-- Table element: 2 columns - Setup data -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 170px">
                                                                <tr>
                                                                    <td style="width: 90px; height: 15px">
                                                                    </td>
                                                                    <td style="width: 80px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblDate_" runat="server" Text="Date" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <telerik:RadDatePicker ID="tkrdpDate_" runat="server" Width="150px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("Date_") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                        </telerik:RadDatePicker>
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
                                                                        <asp:Label ID="lblFlusherTruck" runat="server" Text="Flusher Truck" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblFlusherMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlFlusherTruck" runat="server" Width="80px" DataSourceID="odsFlusherUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Flusher") %>'>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlFlusherMN" runat="server" SkinID="DropDownList" Width="60px"
                                                                            SelectedValue='<%# Eval("FlusherMN") %>'>
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>USMH</asp:ListItem>
                                                                            <asp:ListItem>DSMH</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblVideoTruck" runat="server" Text="Video Truck" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblVideoMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlVideoTruck" runat="server" Width="80px" DataSourceID="odsVideoTruckUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Video") %>'>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlVideoMN" runat="server" SkinID="DropDownList" Width="60px"
                                                                            SelectedValue='<%# Eval("VideoMN") %>'>
                                                                            <asp:ListItem></asp:ListItem>
                                                                            <asp:ListItem>USMH</asp:ListItem>
                                                                            <asp:ListItem>DSMH</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 20px">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Table element : Space inter rows -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 10px">
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
        
        <!-- Page element : Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsFlusherUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter Name="isWithUnitCode" Type="Boolean" DefaultValue="true" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsVideoTruckUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter Name="isWithUnitCode" Type="Boolean" DefaultValue="true" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                 
                </td>
            </tr>
        </table>
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
        
    <!-- Table element : Toolbar -->
    <div style="width: 750px">
        <table id="tbFooterToolbar" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="ASPxMenu_Background">
            <tr>
                <td style="width: 10px; height: 10px">
                </td>
                <td>
                </td>
                <td style="width: 10px">
                </td>
            </tr>            
            <tr>
                <td>
                </td>
                <td>
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mPreview" Text="PREVIEW" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 10px">
                </td>
                <td>
                </td>
                <td style="width: 10px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>