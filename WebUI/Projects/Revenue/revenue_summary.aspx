<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Revenue.revenue_summary" Title="LFS Live"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td style="width: 740px">
                    <asp:Label ID="lblTitle" runat="server" Text="Revenue Summary" SkinID="LabelPageTitle1"></asp:Label>
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
        <!-- Table element: 1 columns - Revenue Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblRevenueDetails" runat="server" SkinID="LabelTitle1" Text="Revenue Details"></asp:Label>
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
                    <asp:TextBox ID="tbxDate" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxRevenue" runat="server" ReadOnly="True" SkinID="TextBoxRightReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:TextBox ID="tbxComments" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 490px" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>                
                <td>                    
                </td>
                <td>
                </td>
            </tr>
        </table>                      
        
        <!-- Table element: 6 columns - Bottom space -->
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