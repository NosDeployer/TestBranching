<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="revenue_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Revenue.revenue_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td style="width: 740px">
                    <asp:Label ID="lblTitle" runat="server" Text="Revenue Information" SkinID="LabelPageTitle1"></asp:Label>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleRevenue" runat="server" Text="Revenue:" SkinID="LabelPageTitle2"></asp:Label>                    
                </td>
                <td>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Revenues" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddRevenue" Text="Add Revenue"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mPersonalAgencies" Text="Personnel Agencies" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mVacationsSetup" Text="Vacations Setup" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCostingSetup" Text="Job Costing Factors" ></telerik:RadPanelItem>
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;">  
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />
                            
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
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
        <!-- Table element: 1 columns - Revenue Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblRevenueDetails" runat="server" SkinID="LabelTitle1" Text="Basic Information"
                        EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Revenue Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblClient" runat="server" EnableViewState="False" SkinID="Label" Text="Client"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblProject" runat="server" EnableViewState="False" SkinID="Label" Text="Project"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxClient" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxProject" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" EnableViewState="False" SkinID="Label" Text="Date"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRevenue" runat="server" EnableViewState="False" SkinID="Label" Text="Revenue"></asp:Label>
                </td>
                <td>
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
                   <asp:UpdatePanel ID="upnlDate" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <telerik:RadDatePicker ID="tkrdpDate" runat="server"
                                Width="115px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                            </telerik:RadDatePicker>
                       </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlRevenue" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxRevenue" runat="server" SkinID="TextBoxRight" Style="width: 115px"></asp:TextBox>
                        </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
                <td>                    
                </td>
                <td>                   
                </td>
                <td>                   
                </td>
                <td>
                </td>                
            </tr>
            <tr>
                <td >
                    <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="tkrdpDate"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a Date." 
                        InitialValue="" SkinID="Validator">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvRevenue" runat="server" ControlToValidate="tbxRevenue"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a Revenue."
                        InitialValue="" SkinID="Validator">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvRevenue" runat="server" ControlToValidate="tbxRevenue"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.YY)"
                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ></asp:CompareValidator>
                    
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblComments" runat="server" EnableViewState="False" SkinID="Label" Text="Comments"></asp:Label>
                </td>
                <td>
                </td>
                <td>
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
                    <asp:TextBox ID="tbxComments" runat="server" SkinID="TextBox" Style="width: 490px" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>                
                <td>                    
                </td>
                <td>
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
                    <asp:ObjectDataSource ID="odsClient" runat="server" SelectMethod="LoadAndAddItemByCountryId"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsProject" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
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
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />                    
                    <asp:HiddenField ID="hdfCurrentRefId" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>