<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="units_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_summary" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Vehicle Information" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuUnits" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Units" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddUnit" Text="Add Unit"></telerik:RadPanelItem>
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
                            
                            <telerik:RadMenuItem Value="mAddServiceRequest" Text="ADD SERVICE REQUEST" />
                            
                            <telerik:RadMenuItem Value="mDispose" Text="DISPOSE" />
                            
                            <telerik:RadMenuItem Value="mActivate" Text="ACTIVATE" />
                            
                            <telerik:RadMenuItem Value="mArchive" Text="ARCHIVE" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
                <td align="right">
                     <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;" >                       
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />
                            
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td style=" width:10px;">
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
                <td>
                    <asp:Label ID="lblBasicInformation" runat="server" SkinID="LabelTitle1" Text="Basic Information" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 4 columns - Unit Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 185px">
                </td>
                <td style="width: 185px">
                </td>
                <td style="width: 185px">
                </td>
                <td style="width: 185px">
                     <asp:TextBox ID="tbxUnitState" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxSpecialWhite" Style="width: 175px"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td style="height: 7px" colspan="4">
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCode" runat="server" EnableViewState="True" SkinID="Label" Text="Code"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="True" SkinID="Label" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblVinSn" runat="server" EnableViewState="True" SkinID="Label" Text="VIN/SN"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxCode" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 175px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxDescription" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 360px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxVinSn" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 175px"></asp:TextBox>
                </td>
            </tr>            
            <tr>
                <td style="height: 7px" colspan="4">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblManufacturer" SkinID="Label" Text="Manufacturer"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblModel" SkinID="Label" Text="Model"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblYear" SkinID="Label" Text="Year"></asp:Label>                                            
                </td>
                <td>
                    <asp:Label runat="server" ID="lblIsTowable" SkinID="Label" Text="Is Towable?"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxManufacturer" runat="server" SkinID="TextBoxReadOnly" Style="width: 175px" ReadOnly="true"></asp:TextBox>                    
                </td> 
                <td>
                    <asp:TextBox ID="tbxModel" runat="server" Style="width: 175px" SkinID="TextboxReadOnly" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxYear" runat="server" Style="width: 175px" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="cbxIsTowable" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="4">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblInsuranceClass" SkinID="Label" Text="Insurance Class"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblRyderSpecified" SkinID="Label" Text="Ryder Specified" Visible="false"></asp:Label>
                </td>
                <td>                                                              
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxInsuranceClass" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 175px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxRyderSpecified" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 175px" Visible="false"></asp:TextBox>
                </td>
                <td>                   
                </td>
                <td>
                </td>
            </tr>
        </table>
        
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
        
        <!-- Table element: 6 columns - Detailed information title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblDetailedInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 1 columns - Tab Control -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>                
                 
                    <!-- Page element : Tab control -->
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" 
                        ActiveTabIndex="1" CssClass="ajax_tabcontainer">
        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General" OnClientClick="tpGeneralDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 10px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblCategory" runat="server" Text="Category" SkinID="Label"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblCompanyLevel" runat="server" Text="Working Location" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Panel ID="pnlCategories" Width="344px" Height="200px" runat="server" SkinID="PanelReadOnly">
                                                    <asp:TreeView ID="tvCategoriesRoot" runat="server" SkinID="SimpleTreeView" onclick="return cbxTreeViewClick(event);">
                                                    </asp:TreeView>
                                                </asp:Panel>
                                            </td>
                                            <td colspan="2">
                                                <asp:Panel ID="pnlCompanyLevels" Width="344px" Height="200px" runat="server" SkinID="PanelReadOnly">
                                                    <asp:TreeView ID="tvCompanyLevelsRoot" runat="server" SkinID="SimpleTreeView" onclick="return cbxTreeViewClick(event);">                                                    
                                                    </asp:TreeView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    
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
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAcquisitionDate" runat="server" SkinID="Label" Text="Acquisition Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPurchasePrice" runat="server" SkinID="Label" Text="Purchase Price"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxAcquisitionDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPurchasePrice" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
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
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblScrapDate" runat="server" SkinID="Label" Text="Scrap Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSaleProceeds" runat="server" SkinID="Label" Text="Sale Proceeds"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxScrapDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxSaleProceeds" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
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
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDispositionDate" runat="server" SkinID="Label" Text="Disposition Date"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblDispositionReason" runat="server" SkinID="Label" Text="Disposition Reason"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxDispositionDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxDispositionReason" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 344px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>                                                                       
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpPlateData" runat="server" HeaderText="Plate" OnClientClick="tpPlateDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 10px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLicenseCountry" runat="server" Text="License Country" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLicenseState" runat="server" Text="License State" SkinID="Label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxLicenseCountry" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxLicenseState" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblLicensePlateNumber" runat="server" Text="License Plate Number" SkinID="Label"></asp:Label>
                                            </td>                                            
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxLicensePlateNumber" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 344px"></asp:TextBox>
                                            </td>                                            
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpTechnical" runat="server" HeaderText="Technical" OnClientClick="tpTechnicalClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 10px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblActualWeight" runat="server" Text="Actual Weight" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRegisteredWeight" runat="server" Text="Registered Weight" SkinID="Label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxActualWeight" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxRegisteredWeight" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                    
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
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTireSizeFront" runat="server" Text="Tire Size Front" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTireSizeBack" runat="server" Text="Tire Size Back" SkinID="Label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxTireSizeFront" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxTireSizeBack" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                        
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
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNumberOfAxes" runat="server" Text="Number Of Axes" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFuelType" runat="server" Text="Fuel Type" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBeginningOdometer" runat="server" Text="Beginning Odometer" SkinID="Label"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxNumberOfAxes" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxFuelType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxBeginningOdometer" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblIsReeferEquipped" runat="server" Text="Is Reefer Equipped?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblIsPtoEquipped" runat="server" Text="Is PTO Equipped?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxIsReeferEquipped" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxIsPtoEquipped" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpOwnership" runat="server" HeaderText="Ownership" OnClientClick="tpOwnershipClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 10px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblOwnerType" runat="server" Text="Owner Type" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOwnerCountry" runat="server" Text="Owner Country" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOwnerState" runat="server" Text="Owner State" SkinID="Label"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxOwnerType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxOwnerCountry" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxOwnerState" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblOwnerName" runat="server" Text="Owner Name" SkinID="Label"></asp:Label>
                                            </td>                                            
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxOwnerName" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 521px"></asp:TextBox>
                                            </td>                                            
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblOwnerContact" runat="server" Text="Contact Info" SkinID="Label"></asp:Label>
                                            </td>                                            
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxOwnerContact" runat="server" SkinID="TextBoxReadOnly" Rows="4" ReadOnly="True" TextMode="MultiLine" Style="width: 521px"></asp:TextBox>
                                            </td>                                            
                                            <td></td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpChecklist" runat="server" HeaderText="Checklist" OnClientClick="tpChecklistClientClick">
                            <ContentTemplate>
                               <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 10px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:UpdatePanel id="upnlChecklistRules" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdChecklistRulesInformation" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="13" SkinID="GridViewInTabs" Width="700px" AllowSorting="true" 
                                                            OnDataBound="grdChecklistRulesInformation_DataBound" DataSourceID="odsChecklistRulesInformation" DataKeyNames="RuleID" OnPageIndexChanging="grdChecklistRulesInformation_PageIndexChanging" 
                                                            DataMember="DefaultView" >
                                                            <Columns>
                                                                <asp:BoundField ReadOnly="True" DataField="RuleID" Visible="False" SortExpression="RuleID" HeaderText="RuleID"></asp:BoundField>
                                                                
                                                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                                    <HeaderStyle Width="180px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblColumn" runat="server" Width="180px" Style="width: 180px" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Frequency" SortExpression="Frequency">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFrequency" runat="server" Width="120px" Style="width: 120px" SkinID="Label" Text='<%# Bind("Frequency") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Last Service" SortExpression="LastService">
                                                                    <HeaderStyle Width="135px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLastService" Width="135px" Style="width: 135px" runat="server" SkinID="Label" Text='<%# Bind("LastService", "{0:d}") %>'></asp:Label>                                                                
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Next Due" SortExpression="NextDue">
                                                                    <HeaderStyle Width="135px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNextDue" Width="135px" Style="width: 135px" runat="server" SkinID="Label" Text='<%# Bind("NextDue", "{0:d}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Done" SortExpression="Done">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxDone" runat="server" Checked='<%# Eval("Done") %>' onclick="return cbxClick();" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblState" Width="80px" Style="width: 80px" runat="server" SkinID="Label" Text='<%# Bind("State") %>'></asp:Label>
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
                                                <asp:UpdatePanel id="upnlComments" runat="server">
                                                    <contenttemplate>
                                                        <asp:Button id="btnChecklist" onclick="btnChecklistOnClick" runat="server" SkinID="Button" Text="Update" EnableViewState="True" Width="80px"></asp:Button> 
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:ObjectDataSource ID="odsChecklistRulesInformation" runat="server" SelectMethod="GetChecklistRulesInformation"
                                                                TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_summary"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>    
                                            </td>
                                        </tr>                     
                                    </table>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpService" runat="server" HeaderText="Services" OnClientClick="tpServiceClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 10px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:UpdatePanel ID="upnlServices" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdServices" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="13" AllowSorting="True" SkinID="GridViewInTabs" Width="700px" 
                                                            OnDataBound="grdServices_DataBound" DataSourceID="odsServices" DataKeyNames="ServiceID" OnPageIndexChanging="grdServices_PageIndexChanging" DataMember="DefaultView" >
                                                            <Columns>
                                                                <asp:BoundField ReadOnly="True" DataField="ServiceID" Visible="False" SortExpression="ServiceID" HeaderText="ServiceID"></asp:BoundField>
                                                                
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelectedService" runat="server" Checked='<%# Eval("Selected") %>' onclick="return cbxSelectedClick(this);" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Service Number" SortExpression="ServiceID">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="100px" ></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNumber" runat="server" Width="100px" SkinID="Label" Style="width: 100px" Text='<%# Bind("Number") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Date" SortExpression="DateTime_">
                                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" Width="150px" SkinID="Label" Style="width: 150px" Text='<%# Bind("DateTime_") %>'></asp:Label>                                                                
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                                    <HeaderStyle Width="270px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Width="270px" SkinID="Label" Style="width: 270px" Text='<%# Bind("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                        
                                                                                                                       
                                                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblState" runat="server" Width="150px" SkinID="Label" Style="width: 150px" Text='<%# Bind("State") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="ServiceID" Visible="false">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblServiceID" runat="server" SkinID="Label" Text='<%# Bind("ServiceID") %>'></asp:Label>
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
                                                <asp:Button id="btnOpenService" onclick="btnOpenServiceOnClick" runat="server" SkinID="Button" Text="Open" EnableViewState="True" Width="80px"></asp:Button>                                                     
                                            </td>
                                            <td colspan="3"></td>
                                        </tr>    
                                        <tr>
                                            <td colspan="4">
                                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:ObjectDataSource ID="odsServices" runat="server" SelectMethod="GetServicesInformation"
                                                                TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_summary"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>    
                                            </td>
                                        </tr>                     
                                    </table>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpInspection" runat="server" HeaderText="Inspections" OnClientClick="tpInspectionClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 142px; height: 10px;">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                        </tr>              
                                        <tr>
                                            <td colspan="5">                                 
                                                <!-- Page element: 1 column - Grid Inspections -->
                                                <asp:GridView id="grdInspections" runat="server" SkinID="GridViewInTabs" PageSize="2" 
                                                DataSourceID="odsInspections" OnDataBound="grdInspections_DataBound"                                                
                                                AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="InspectionID" width="700px" >
                                                <Columns> 
                                                                                                    
                                                    <asp:TemplateField HeaderText="InspectionID" SortExpression="InspectionID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectionId" runat="server" Text='<%# Eval("InspectionID") %>'></asp:Label>
                                                        </ItemTemplate>                                                        
                                                    </asp:TemplateField>
                                                                                                   
                                                    <asp:TemplateField HeaderText="Inspections" SortExpression="InspectionID">
                                                        <HeaderStyle Width="660px" />                                                        
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 660px">
                                                                <tr>
                                                                    <td style="width: 10px; height: 10px"></td>
                                                                    <td style="width: 107px"></td>
                                                                    <td style="width: 107px"></td>
                                                                    <td style="width: 107px"></td>
                                                                    <td style="width: 107px"></td>
                                                                    <td style="width: 107px"></td>
                                                                    <td style="width: 107px"></td>
                                                                    <td style="width: 8px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:Label ID="lblInspectionDate" runat="server" Text="Inspection Date" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCountry" runat="server" Text="Country" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblState" runat="server" Text="State" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label id="lblType" runat="server" Text="Type" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblResult" runat="server" Text="Result" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblRepairCost" runat="server" Text="Repair Cost" SkinID="Label"></asp:Label>
                                                                    </td>                                                                    
                                                                    <td></td>
                                                                </tr>    
                                                                <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxInspectionDate" runat="server" Width="97px" Text='<%# Eval("Date_", "{0:d}") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxCountry" runat="server" Width="97px" Text='<%# GetCountry(Eval("Country")) %>' SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxState" runat="server" Width="97px" Text='<%# GetState(Eval("State")) %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxType" runat="server" Width="97px" Text='<%# Eval("Type") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxResult" runat="server" Width="97px" Text='<%# Eval("Result") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxRepairCost" runat="server" Width="97px" Text='<%# Eval("Cost", "{0:f2}") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                    </td>                                                                    
                                                                    <td></td>
                                                                </tr>                                                       
                                                                <tr>
                                                                    <td style="height:7px"></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>                                                                
                                                                <tr>
                                                                    <td></td>
                                                                    <td colspan="6">
                                                                        <asp:Label ID="lblNotes" runat="server" Text="Notes" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td colspan="6">
                                                                        <asp:TextBox ID="tbxNotes" runat="server" EnableViewState="True" ReadOnly="True"
                                                                        Rows="4" SkinID="TextBoxReadOnly" Style="width: 632px" Text='<%# Eval("Notes") %>'  TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height:7px"></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>                                                                
                                                                <tr>
                                                                    <td></td>
                                                                    <td colspan="6">
                                                                        <asp:Label ID="lblInspectedBy" runat="server" Text="Inspected By" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td colspan="6">
                                                                        <asp:TextBox ID="tbxInspectedBy" runat="server" EnableViewState="True" ReadOnly="True"
                                                                        SkinID="TextBoxReadOnly" Style="width: 632px" Text='<%# Eval("InspectedBy") %>' ></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>                                                                
                                                                <tr>
                                                                    <td style="height: 30px"></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>                                                                
                                                            </table>                                                        
                                                        </ItemTemplate>                                                        
                                                    </asp:TemplateField>
                                                    
                                                   </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    
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
                                    
                                    <!-- Table element: 1 columns - Qualification information title -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblQualificationInformation" runat="server" SkinID="LabelTitle1" Text="Qualification Information"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                     <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblQualifiedDate" runat="server" SkinID="Label" Text="Qualified Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNotQualifiedDate" runat="server" SkinID="Label" Text="Not Qualified Date"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxQualifiedDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxNotQualifiedDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td> 
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblIfNotQualifiedExplain" runat="server" SkinID="Label" Text="If Not Qualified Explain"></asp:Label>
                                            </td>
                                            <td>                                                
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>  
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxIfNotQualifiedExplain" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Rows="4" TextMode="MultiLine" Style="width: 700px"></asp:TextBox>
                                            </td>  
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpCosts" runat="server" HeaderText="Costs" OnClientClick="tpCostsClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 1 column  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 700px; height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCostHistory" runat="server" SkinID="Label" Text="Cost History"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upCosts" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdCosts" runat="server" AllowPaging="True" 
                                                            AutoGenerateColumns="False" DataKeyNames="CostID" DataMember="DefaultView" 
                                                            DataSourceID="odsCosts" OnDataBound="grdCosts_DataBound" PageSize="13" 
                                                            SkinID="GridViewInTabs" Width="450px">
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <HeaderStyle Width="30px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" AutoPostBack="True"
                                                                            OnCheckedChanged="cbxSelectedCost_CheckedChanged" Width="25px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <HeaderStyle Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("Date", "{0:d}") %>' Width="100px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <HeaderStyle Width="70px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("UnitOfMeasurement") %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (CAD)">
                                                                    <HeaderStyle Width="80px" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostCad" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("CostCad"),2) %>' Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (USD)">
                                                                    <HeaderStyle Width="80px" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostUsd" runat="server" SkinID="Label" 
                                                                            Text='<%# GetRound(Eval("CostUsd"),2) %>' Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="CostID" Visible="false">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCostExceptions" runat="server" SkinID="Label" Text="Cost Exceptions"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upCostsExceptions" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdCostsExceptions" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CostID,RefID" 
                                                            DataMember="DefaultView" DataSourceID="odsCostsExceptions" OnDataBound="grdCostsExceptions_DataBound" PageSize="13" SkinID="GridViewInTabs">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Type of Work">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionWork" runat="server" SkinID="Label" 
                                                                            Style="width: 200px" Text='<%# Bind("Work_") %>' Width="200px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                            Style="width: 90px" Text='<%# Bind("UnitOfMeasurement") %>' Width="90px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Width="90px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (CAD)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostCad" runat="server" SkinID="Label" 
                                                                            Style="width: 75px" Text='<%# GetRound(Eval("CostCad"),2) %>' Width="75px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle Width="75px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (USD)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostUSD" runat="server" SkinID="Label" 
                                                                            Style="width: 75px" Text='<%# GetRound(Eval("CostUsd"),2) %>' Width="75px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle Width="75px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="CostID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="0px" />                                                                    
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionRefID" runat="server" SkinID="Label" 
                                                                            Text='<%# Bind("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 30px">
                                                <asp:ObjectDataSource ID="odsCosts" runat="server" SelectMethod="GetCostsNew" filterexpression="Deleted=0" 
                                                    TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_summary">
                                                </asp:ObjectDataSource>
                                                <asp:ObjectDataSource ID="odsCostsExceptions" runat="server" SelectMethod="GetCostsExceptionsNew" filterexpression="Deleted=0"
                                                    TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_summary">
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpNotesData" runat="server" HeaderText="Notes &amp; Attachments" OnClientClick="tpNotesDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 730px; overflow-y: auto;">
                                    <!-- Table element: 5 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 142px; height: 10px;">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="5" colspan="5">
                                                <asp:GridView id="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px" 
                                                DataSourceID="odsNotes" DataKeyNames="UnitID,RefID" AllowPaging="True" 
                                                AutoGenerateColumns="False" OnRowDataBound="grdNotes_RowDataBound" OnRowCommand="grdNotes_RowCommand"
                                                PageSize="5" OnDataBound="grdNotes_DataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="UnitID" SortExpression="UnitID" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:Label id="lblUnitID" runat="server" Text='<%# Eval("UnitID") %>'></asp:Label> 
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label id="lblUnitID" runat="server" Text='<%# Eval("UnitID") %>'></asp:Label>                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                   
                                                                                                            
                                                        <asp:TemplateField HeaderText="RefID" SortExpression="RefID" Visible="False">
                                                            <EditItemTemplate>
                                                                <asp:Label id="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label> 
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label id="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField  Visible="False" HeaderText="FileName" >                                                            
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblFileNameEdit" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                                
                                                        
                                                        <asp:TemplateField  Visible="False" HeaderText="LIBRARY_FILES_ID" >                                                            
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblLibraryFileIdEdit" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLibraryFileId" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Information" SortExpression="Subject">
                                                            <ItemTemplate>
                                                            
                                                                <!-- Page element : 3 columns - Notes Information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 10px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 155px;">
                                                                        </td>
                                                                        <td style="width: 155px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteSubject" runat="server" EnableViewState="False" SkinID="Label" Text="Subject"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="tbxNoteSubject" runat="server" EnableViewState="True" ReadOnly="True" Text='<%# Eval("Subject") %>'
                                                                                SkinID="TextBoxReadOnly" Style="width: 300px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>                                                                    
                                                                    <tr>
                                                                        <td style="height: 7px" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteDate" runat="server" EnableViewState="False" SkinID="Label" Text="Date"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteCreatedBy" runat="server" EnableViewState="False" SkinID="Label" Text="Created By"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteDate" runat="server" EnableViewState="True" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 145px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteCreatedBy" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 145px" Text='<%# GetNoteCreatedBy(Eval("UserID")) %>'></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 10px" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="320px"></HeaderStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField SortExpression="NoteAttachment" HeaderText="Note &amp; Attachment">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Width="310px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <!-- Page element : 3 columns - Notes and attachment information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 10px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 210px;">
                                                                        </td>
                                                                        <td style="width: 90px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="True"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="tbxNoteNote" runat="server" EnableViewState="True" ReadOnly="True" Text='<%# Eval("Note") %>'
                                                                                Rows="4" SkinID="TextBoxReadOnly" Style="width: 290px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 7px" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                ReadOnly="true" Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="200px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("RefID") %>'
                                                                                runat="server" SkinID="Button" Text="Download" Width="80px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 10px" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>                                                       
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>                                                       
                                                            <ItemTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 50%">
                                                                            </td>
                                                                            <td style="width: 50%">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>                                                            
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>                                            
                                            </td>
                                        </tr>
                                    </table>
                                    
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
                                    
                                    <!-- Page element: Section title - Resource Centre -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblResourceCentre" runat="server" SkinID="LabelTitle1" Text="Resource Centre" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 1 column - Resource Centre -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
                                        <tr>
                                            <td style="width: 600px">
                                                <asp:Label ID="lblCategoryAssociated" runat="server" Text="Associated Category" SkinID="Label" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxCategoryAssocited" Width="590px" ReadOnly="True" runat="server" SkinID="TextBoxReadOnly" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 1 column - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                            <HeaderTemplate>
                                Notes &amp; Attachments
                            </HeaderTemplate>
                        </cc1:TabPanel>
                        
                    </cc1:TabContainer>
                </td>
            </tr>
        </table>
        
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
                    <asp:ObjectDataSource ID="odsInspections" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetInspectionsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_summary">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_summary">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
                        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfUnitId" runat="server" />
                    <asp:HiddenField ID="hdfUnitType" runat="server" />
                    <asp:HiddenField ID="hdfUnitState" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>