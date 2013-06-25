<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="checklist_rules_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules.checklist_rules_edit" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">    
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Checklist Rule Information" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Checklist Rules" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddChecklistRule" Text="Add Checklist Rule"></telerik:RadPanelItem>
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
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">       
    <div style="width: 750px">        
        <!-- Table element: 1 columns - Checklist Rule Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblChecklistRuleDetails" runat="server" SkinID="LabelTitle1" Text="Checklist Rule Details" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Checklist Rule Details Title -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>                
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblName" runat="server" EnableViewState="True" Text="Name" SkinID="Label"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblMtoDot" SkinID="Label" Text="Government Rule (Fixed Date)"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>               
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox id="tbxName" runat="server" SkinID="TextBox" Width="240px" EnableViewState="True"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="cbxMtoDot" runat="server" SkinID="CheckBox" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName" Display="Dynamic" ErrorMessage="Please provide a checklist rule name." SkinID="Validator" EnableViewState="True">
                    </asp:RequiredFieldValidator>
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
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="True" SkinID="Label" Text="Description"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td colspan="6" rowspan="4">
                    <asp:TextBox ID="tbxDescription" runat="server" Height="61px" SkinID="TextBox" TextMode="MultiLine" Width="740px" EnableViewState="True"></asp:TextBox>
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
        
        <!-- Table element: 1 columns - Checklist Rule Details 2 Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblSchedulingOptions" runat="server" SkinID="LabelTitle1" Text="Scheduling Options" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Checklist Rule Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label runat="server" ID="lblFrequency" SkinID="Label" Text="Frequency"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:TextBox id="tbxFrecuency" runat="server" SkinID="TextBoxReadOnly" Width="240px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>            
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblGenerateServiceRequest" Text="Generate Service Request?" runat="server" SkinID="Label" ></asp:Label>
                </td>
            </tr>     
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" width="0" style="width: 120px">
                        <tr>
                            <td style=" width: 50px;">
                                <asp:TextBox runat="server" ID="tbxServicesRequestDaysBefore" SkinID="textbox" Width="40px"></asp:TextBox>
                            </td>
                            <td style=" width: 70px;">
                                <asp:Label runat="server" ID="lblServicesRequestDaysBefore" SkinID="Label" Text="days before"></asp:Label>
                            </td>
                        </tr>
                    </table>                                            
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
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" width="0" style="width: 120px">
                        <tr>
                            <td style=" width: 120px;">
                                <asp:CustomValidator ID="cvServicesRequestDaysBefore" runat="server" ControlToValidate="tbxServicesRequestDaysBefore" Display="Dynamic" OnServerValidate="cvServicesRequestDaysBefore_ServerValidate" SkinID="Validator" ValidateEmptyText="true">
                                </asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
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
        
        <!-- Table element: 1 columns - Checklist Rule Details 3 Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblAppliedOptions" runat="server" SkinID="LabelTitle1" Text="Applied Options" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Checklist Rule Details 3 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label runat="server" ID="lblCategory" SkinID="Label" Text="Category"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label runat="server" ID="lblCompanyLevel" SkinID="Label" Text="Working Location"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>            
            <tr>
                <td colspan="3">
                    <asp:Panel ID="pnlCategories" Width="365px" Height="300px" runat="server" SkinID="Panel">
                        <asp:UpdatePanel ID="upnlCategoriesRoot" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:TreeView ID="tvCategoriesRoot" runat="server" SkinID="SimpleTreeView"
                                 onclick="return OnTreeClick(event);" autopostback="true" 
                                    OnTreeNodeCheckChanged="tvCategoriesRoot_TreeNodeCheckChanged"   >
                                </asp:TreeView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td colspan="3">
                    <asp:Panel ID="pnlCompanyLevels" Width="365px" Height="300px" runat="server" SkinID="PanelReadOnly">
                        <asp:TreeView ID="tvCompanyLevelsRoot" runat="server" SkinID="SimpleTreeView" onclick="return cbxTreeViewClick(event);">
                        </asp:TreeView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:CustomValidator ID="cvCategories" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one category."
                    OnServerValidate="cvCategories_ServerValidate"></asp:CustomValidator>
                </td>
                <td colspan="3">
                    <asp:CustomValidator ID="cvCompanyLevels" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one company level."
                    OnServerValidate="cvCompanyLevels_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label runat="server" ID="lblUnits" SkinID="Label" Text="Units"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel ID="upnlUnits" runat="server">
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="365px">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlUnits" runat="server" Height="265px" SkinID="Panel" Width="365px">
                                                <asp:CheckBoxList ID="cbxlUnitsSelected" runat="server"  
                                                    SkinID="CheckBoxListWithoutBorder" >
                                                </asp:CheckBoxList>
                                            </asp:Panel>
                                        </td>
                                        <td style="VERTICAL-ALIGN: middle">
                                            <asp:UpdateProgress ID="upUnits" runat="server" 
                                                AssociatedUpdatePanelID="upnlUnits">
                                                <progresstemplate>
                                                    <img height="16" src="../../common/images/ajax1.gif" width="16" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label runat="server" ID="lblTotalUnits" SkinID="Label" Text="Units"></asp:Label>
                </td>                                      
            </tr>
            <tr>
                <td colspan="6">
                    <asp:CustomValidator ID="cvUnits" runat="server" SkinID="Validator" 
                        Display="Dynamic" ErrorMessage="You must select at least one unit."
                    OnServerValidate="cvUnits_ServerValidate"></asp:CustomValidator>
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
                    <asp:ObjectDataSource ID="odsFrequency" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.RuleFrecuencyList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a frequency)" Name="frequency" Type="String" />
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
                    <asp:HiddenField ID="hdfRuleId" runat="server" />
                    <asp:HiddenField ID="hdfCheckUnitsFlag" runat="server" />
                </td>
            </tr>
        </table>
           
    </div>
</asp:Content>