﻿<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mForm8.Master" AutoEventWireup="true" CodeBehind="bondingCompanies_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.BondingCompanies.bondingCompanies_navigator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Bonding Companies Setup" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="BondingCompanies" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddBondingCompanies" Text="Add Bonding Companies"></telerik:RadPanelItem>                                    
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save" />
                        </Items>
                    </telerik:RadMenu>
                    <asp:Label ID="lblMissingData" runat="server" SkinID="LabelError" Text=""></asp:Label>
                </td>                
                <td style=" width:10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Search &  Sort Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td>
                    <asp:Label ID="lblTitleGeneral" runat="server" SkinID="LabelTitle1" Text="Bonding Companies"
                        EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        
        
        <!-- Page element : No results bar -->
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
            <tr>
                <td>
                    <asp:Label ID="lblNoResults" runat="server" Text="No bonding companies registered."></asp:Label>
                </td>
            </tr>
        </table>
      
      
       
       <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Panel ID="pnlCompaniesSetup" runat="server" Height="270px" Width="350px" ScrollBars="Auto">
                        <asp:UpdatePanel id="upnlCompaniesSetup" runat="server">
                            <contenttemplate>                                
                                    
                                <asp:GridView ID="grdCompaniesSetup" runat="server" SkinID="GridView" Width="100%" OnRowDeleting="grdCompaniesSetup_RowDeleting"
                                    DataSourceID="odsCompaniesSetup" ShowFooter="False" 
                                    AutoGenerateColumns="False" DataKeyNames="COMPANIES_ID, Date" OnRowDataBound="grdCompaniesSetup_RowDataBound">
                                    
                                    
                                    <Columns>
                                        <asp:TemplateField Visible="False" HeaderText="No">                                                                        
                                            <ItemStyle HorizontalAlign="Center" />                                                                                      
                                            <ItemTemplate>
                                                <asp:Label ID="lblCOMPANIES_IDId" runat="server"  SkinID="Label" Text='<%# Eval("COMPANIES_ID") %>' Width="30px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                                                
                                                                                
                                                                                
                                        <asp:TemplateField HeaderText="Companies">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            <HeaderStyle Width="260px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompanyName" runat="server" SkinID="Label" Text='<%# Eval("Name") %>'></asp:Label>
                                             </ItemTemplate>                                           
                                        </asp:TemplateField>
                                        
                                        
                                        <asp:TemplateField>
                                            <HeaderStyle Width="40px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                                                       
                                                    <td style="width: 50%">
                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"
                                                            CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this bonding company?");'>
                                                        </asp:ImageButton>
                                                    </td>                                                    
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>                                            
                            </contenttemplate>
                        </asp:UpdatePanel>
                                                
                    </asp:Panel>
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
                    <asp:ObjectDataSource ID="odsCompaniesSetup" runat="server"
                        SelectMethod="GetCompaniesSetupNew" FilterExpression="(Deleted = 0)" 
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.BondingCompanies.bondingCompanies_navigator"
                        DeleteMethod="DummyCompaniesSetupNew" InsertMethod="DummyCompaniesSetupNew" UpdateMethod="DummyCompaniesSetupNew" 
                        OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="COMPANIES_ID" Type="Int32" />
                            <asp:Parameter Name="Date" Type="DateTime" />
                        </DeleteParameters>                       
                        <InsertParameters>
                            <asp:Parameter Name="COMPANIES_ID" Type="Int32" />
                            <asp:Parameter Name="Date" Type="DateTime" />
                        </InsertParameters>
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
</asp:Content>




<asp:Content ID="Conten5" ContentPlaceHolderID="FooterPlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">
                        <items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save" />
                        </items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="FooterSpacePlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Page element : Footer separation -->
        <table id="Table2" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
