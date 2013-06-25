<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="materials_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_edit"  Title="LFS Live"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td style="width: 740px">
                    <asp:Label ID="lblTitle" runat="server" Text="Materials Information" SkinID="LabelPageTitle1"></asp:Label>
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
                    <asp:Label ID="lblTitleMaterials" runat="server" Text="Materials:" SkinID="LabelPageTitle2"></asp:Label>                    
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
                            <telerik:RadPanelItem Expanded="True" Text="Materials" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddMaterials" Text="Add Materials"></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mMaterialByProcessReport" Text="Materials by Process Report" ></telerik:RadPanelItem>
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
        <!-- Table element: 1 columns - Maerial Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblMaterialDetails" runat="server" SkinID="LabelTitle1" Text="Basic Information" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        <!-- Table element: 6 columns - Material Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px; vertical-align: top;">
                    <asp:Label ID="lblProcess" runat="server" EnableViewState="False" SkinID="Label" Text="Process"></asp:Label>
                </td>
                <td style="width: 125px; vertical-align: top;">
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="False" SkinID="Label" Text="Description"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td rowspan="14">
                    <asp:Panel ID="pnlPointRepairs" runat="server" Width="100%">
                        <table cellpadding="0" cellspacing="0" style="width: 250px">
                            <tr>
                                <td style="width: 125px">
                                    <asp:Label ID="lblPrSize" runat="server" EnableViewState="False" SkinID="Label" Text="Size"></asp:Label>
                                </td>
                                <td style="width: 125px">
                                    <asp:Label ID="lblPrLength" runat="server" EnableViewState="False" SkinID="Label" Text="Length"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPrSize" runat="server" DataMember="DefaultView" DataSourceID="odsSizeList"
                                        DataTextField="Size_" DataValueField="Size_" SkinID="DropDownList" Style="width: 115px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPrLength" runat="server" DataMember="DefaultView" DataSourceID="odsLengthList"
                                        DataTextField="Length" DataValueField="Length" SkinID="DropDownList" Style="width: 115px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CustomValidator ID="cvPRSizeEmpty" runat="server" ControlToValidate="ddlPrSize"
                                        Display="Dynamic" ErrorMessage="Please select a size." OnServerValidate="cvSizeEmpty_ServerValidate"
                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="generalInformation"></asp:CustomValidator>
                                </td>
                                <td>
                                    <asp:CustomValidator ID="cvPRLengthEmpty" runat="server" ControlToValidate="ddlPrLength"
                                        Display="Dynamic" ErrorMessage="Please select a length." OnServerValidate="cvJLSizeEmpty_ServerValidate"
                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="generalInformation"></asp:CustomValidator>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlFullLengthLining" runat="server" Width="100%">
                        <table cellpadding="0" cellspacing="0" style="width: 250px">
                            <tr>
                                <td style="width: 125px">
                                    <asp:Label ID="lblSize" runat="server" EnableViewState="False" SkinID="Label" Text="Size"></asp:Label>
                                </td>
                                <td style="width: 125px">
                                    <asp:Label ID="lblThickness" runat="server" EnableViewState="False" SkinID="Label" Text="Thickness"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbxSize" runat="server" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlThickness" runat="server" DataSourceID="odsThicknessList"
                                        DataTextField="Thickness" DataValueField="Thickness" SkinID="DropDownListLookup"
                                        Width="115px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CustomValidator ID="cvSize" runat="server" ControlToValidate="tbxSize" Display="Dynamic"
                                        ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                        OnServerValidate="cvSize_ServerValidate" SkinID="Validator" ValidationGroup="generalInformation"></asp:CustomValidator>
                                    <asp:CustomValidator ID="cvSizeEmpty" runat="server" ControlToValidate="tbxSize"
                                        Display="Dynamic" ErrorMessage="Please enter a size." OnServerValidate="cvSizeEmpty_ServerValidate"
                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="generalInformation"></asp:CustomValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlJunctionLiner" runat="server" Width="100%">
                        <table cellpadding="0" cellspacing="0" style="width: 250px">
                            <tr>
                                <td style="width: 125px">
                                    <asp:Label ID="lblJLDescription" runat="server" EnableViewState="False" SkinID="Label" Text="New Description"></asp:Label>
                                </td>
                                <td style="width: 125px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RadioButton ID="rbtnMiscSupplies" runat="server" GroupName="JunctionLiner" SkinID="RadioButton" Text="Lateral / Misc Supplies" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 7px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RadioButton ID="rbtnCleanoutMaterial" runat="server" GroupName="JunctionLiner"
                                        SkinID="RadioButton" Text="Lateral / Cleanout Material" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 7px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RadioButton ID="rbtnBackfillCleanout" runat="server" GroupName="JunctionLiner"
                                        SkinID="RadioButton" Text="Lateral / Backfill - Cleanout" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 7px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 7px">
                                    <asp:RadioButton ID="rbtnRestorationCrowleCap" runat="server" GroupName="JunctionLiner"
                                        SkinID="RadioButton" Text="Lateral / Restoration &amp; Crowle Cap" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 7px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RadioButton ID="rbtnOther" runat="server" Checked="True" GroupName="JunctionLiner"
                                        SkinID="RadioButton" Text="Auto Generate New Description" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 7px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblJLSize" runat="server" EnableViewState="False" SkinID="Label" Text="Size"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbxJLSize" runat="server" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CustomValidator ID="cvJLSize" runat="server" ControlToValidate="tbxJLSize" Display="Dynamic"
                                        ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                        OnServerValidate="cvJLSize_ServerValidate" SkinID="Validator" ValidationGroup="generalInformation"></asp:CustomValidator>
                                    <asp:CustomValidator ID="cvJLSizeEmpty" runat="server" ControlToValidate="tbxJLSize"
                                        Display="Dynamic" ErrorMessage="Please enter a size." OnServerValidate="cvJLSizeEmpty_ServerValidate"
                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="generalInformation"></asp:CustomValidator>
                                    <asp:CustomValidator ID="cvJLSizeAutoGenerate" runat="server" ControlToValidate="tbxJLSize"
                                        Display="Dynamic" ErrorMessage="Please delete the size." OnServerValidate="cvJLSizeAutoGenerate_ServerValidate"
                                        SkinID="Validator" ValidationGroup="generalInformation"></asp:CustomValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td style="width: 125px; vertical-align: top;">
                    <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" Text="State"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <asp:TextBox ID="tbxProcess" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td colspan="2" style="vertical-align: top;">
                    <asp:TextBox ID="tbxDescription" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                        Style="width: 240px"></asp:TextBox>
                </td>
                <td style="vertical-align: top;">
                    <asp:TextBox ID="tbxState" runat="server" ReadOnly="True"
                        SkinID="TextBoxSpecialWhite" Style="width: 115px"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="extraRow1">
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow2">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow3">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow4">
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow5">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow6">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow7">
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow8">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow9">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow10">
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow11">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr runat="server" id="extraRow12">
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
        <!-- Table element: 6 columns - Employees Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblDetailedInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information"
                        EnableViewState="False"></asp:Label>
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
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" ActiveTabIndex="0"
                        CssClass="ajax_tabcontainer" Height="640px">
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General" OnClientClick="tpCostDataClientClick">
                            <HeaderTemplate>
                                Costs
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 4 columns  -->
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
                                                        <asp:GridView ID="grdCosts" runat="server" AllowPaging="True" ShowFooter="True" OnRowCommand="grdCosts_RowCommand" OnRowDataBound="grdCosts_RowDataBound"
                                                            OnRowUpdating="grdCosts_RowUpdating" OnRowDeleting="grdCosts_RowDeleting" AutoGenerateColumns="False"
                                                            DataKeyNames="CostID" DataMember="DefaultView" DataSourceID="odsCosts" OnDataBound="grdCosts_DataBound"
                                                            PageSize="13" SkinID="GridViewInTabs" Width="450px" OnRowEditing="grdCosts_RowEditing">
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <HeaderStyle Width="30px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" AutoPostBack="True" OnCheckedChanged="cbxSelectedCost_CheckedChanged"
                                                                            Width="25px" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="100px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" SkinID="Label" Text='<%# Bind("Date", "{0:d}") %>'
                                                                            Style="width: 100px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <telerik:RadDatePicker ID="tkrdpDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                        DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date") %>' Calendar-ShowRowHeaders="false"
                                                                                        Calendar-DayNameFormat="Short">
                                                                                    </telerik:RadDatePicker>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDateEdit" runat="server" ControlToValidate="tkrdpDateEdit" InitialValue=""
                                                                                        Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="EditCost">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CustomValidator ID="cvEditDate" runat="server" SkinID="Validator" Display="Dynamic"
                                                                                        ValidationGroup="EditCost" ControlToValidate="tkrdpDateEdit" ErrorMessage="You cannot add cost in that date."
                                                                                        OnServerValidate="cvEditDate_ServerValidate" ValidateEmptyText="True">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <telerik:RadDatePicker ID="tkrdpDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                        DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date") %>' Calendar-ShowRowHeaders="false"
                                                                                        Calendar-DayNameFormat="Short">
                                                                                    </telerik:RadDatePicker>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvDateNew" runat="server" ControlToValidate="tkrdpDateNew"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="AddCost">
                                                                                    </asp:RequiredFieldValidator>                                                                                    
                                                                                    <asp:CustomValidator ID="cvAddDate" runat="server" SkinID="Validator" Display="Dynamic"
                                                                                        ValidationGroup="AddCost" ControlToValidate="tkrdpDateNew" ErrorMessage="You cannot add cost in that date."
                                                                                        OnServerValidate="cvAddDate_ServerValidate" ValidateEmptyText="True">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <HeaderStyle Width="70px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitOfMeasurement" runat="server" SkinID="Label" Text='<%# Bind("UnitOfMeasurement") %>'
                                                                            Style="width: 70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>                                                                        
                                                                        <asp:DropDownList ID="ddlUnitOfMeasurementMaterialsEdit" runat="server" 
                                                                            DataSourceID="odsUnitsOfMeasurementMaterials" DataTextField="Description" 
                                                                            DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                            Width="70px">
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlUnitOfMeasurementMaterialsNew" runat="server" 
                                                                            DataSourceID="odsUnitsOfMeasurementMaterials" DataTextField="Description" 
                                                                            DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                            Width="70px">
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (CAD)">
                                                                    <HeaderStyle Width="80px" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("CostCad"),2) %>'
                                                                            Style="width: 80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxCostCadEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("CostCad"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvCostCadEdit" runat="server" ControlToValidate="tbxCostCadEdit"
                                                                                        ValidationGroup="EditCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvCostCadEdit" runat="server" ControlToValidate="tbxCostCadEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxCostCadNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvCostCadNew" runat="server" ControlToValidate="tbxCostCadNew"
                                                                                        ValidationGroup="AddCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvCostCadNew" runat="server" ControlToValidate="tbxCostCadNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (USD)">
                                                                    <HeaderStyle Width="80px" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("CostUsd"),2) %>'
                                                                            Style="width: 80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxCostUsdEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("CostUsd"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvCostUsdEdit" runat="server" ControlToValidate="tbxCostUsdEdit"
                                                                                        ValidationGroup="EditCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvCostUsdEdit" runat="server" ControlToValidate="tbxCostUsdEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxCostUsdNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvCostUsdNew" runat="server" ControlToValidate="tbxCostUsdNew"
                                                                                        ValidationGroup="AddCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvCostUsdNew" runat="server" ControlToValidate="tbxCostUsdNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="CostID" Visible="false">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostID" runat="server" SkinID="Label" Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCostIDEdit" runat="server" SkinID="Label" Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <%--Buttons--%>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                                            CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                                            CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                            CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                            CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                            CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                            ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                        </asp:ImageButton>
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
                                                        <asp:GridView ID="grdCostsExceptions" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            DataKeyNames="CostID,RefID" DataMember="DefaultView" DataSourceID="odsCostsExceptions" OnRowEditing="grdCostsExceptions_RowEditing"
                                                            ShowFooter="True" OnRowCommand="grdCostsExceptions_RowCommand" OnRowUpdating="grdCostsExceptions_RowUpdating"
                                                            OnRowDeleting="grdCostsExceptions_RowDeleting" OnDataBound="grdCostsExceptions_DataBound"
                                                            OnRowDataBound="grdCostsExceptions_RowDataBound" PageSize="13" SkinID="GridViewInTabs">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Type of Work.Function">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionWorkFunction" runat="server" SkinID="Label" Style="width: 160px"
                                                                            Text='<%# Bind("WorkFunction") %>' Width="160px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList Style="width: 160px" ID="ddlExceptionWorkFunctionEdit" runat="server"
                                                                                        SkinID="DropDownList" DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat"
                                                                                        DataValueField="WorkFunctionConcat">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionWorkFunctionEdit" runat="server" ControlToValidate="ddlExceptionWorkFunctionEdit"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a type of work.Function." SkinID="Validator" InitialValue="(Select)"
                                                                                        ValidationGroup="EditCostException">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList Style="width: 160px" ID="ddlExceptionWorkFunctionNew" runat="server"
                                                                                        SkinID="DropDownList" DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat"
                                                                                        DataValueField="WorkFunctionConcat">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionWorkFunctionNew" runat="server" ControlToValidate="ddlExceptionWorkFunctionNew"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a type of work.Function." SkinID="Validator" InitialValue="(Select)"
                                                                                        ValidationGroup="AddCostException">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Width="160px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionUnitOfMeasurement" runat="server" SkinID="Label" Style="width: 70px"
                                                                            Text='<%# Bind("UnitOfMeasurement") %>' Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>                                                                       
                                                                        <asp:DropDownList ID="ddlExceptionUnitOfMeasurementMaterialsEdit" runat="server" 
                                                                            DataSourceID="odsUnitsOfMeasurementMaterials" DataTextField="Description" 
                                                                            DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                            Width="70px">
                                                                        </asp:DropDownList>    
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>                                                                        
                                                                        <asp:DropDownList ID="ddlExceptionUnitOfMeasurementMaterialsNew" runat="server" 
                                                                            DataSourceID="odsUnitsOfMeasurementMaterials" DataTextField="Description" 
                                                                            DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                            Width="70px">
                                                                        </asp:DropDownList>    
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Width="70px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (CAD)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostCad" runat="server" SkinID="Label" Style="width: 80px"
                                                                            Text='<%# GetRound(Eval("CostCad"),2) %>' Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxExceptionCostCadEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("CostCad"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionCostCadEdit" runat="server" ControlToValidate="tbxExceptionCostCadEdit"
                                                                                        ValidationGroup="EditCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionCostCadEdit" runat="server" ControlToValidate="tbxExceptionCostCadEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxExceptionCostCadNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionCostCadNew" runat="server" ControlToValidate="tbxExceptionCostCadNew"
                                                                                        ValidationGroup="AddCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionCostCadNew" runat="server" ControlToValidate="tbxExceptionCostCadNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle Width="80px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost (USD)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostUSD" runat="server" SkinID="Label" Style="width: 80px"
                                                                            Text='<%# GetRound(Eval("CostUsd"),2) %>' Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxExceptionCostUsdEdit" runat="server" SkinID="TextBox"
                                                                                        Text='<%# GetRound(Eval("CostUsd"),2) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionCostUsdEdit" runat="server" ControlToValidate="tbxExceptionCostUsdEdit"
                                                                                        ValidationGroup="EditCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionCostUsdEdit" runat="server" ControlToValidate="tbxExceptionCostUsdEdit"
                                                                                        Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox Style="width: 80px" ID="tbxExceptionCostUsdNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvExceptionCostUsdNew" runat="server" ControlToValidate="tbxExceptionCostUsdNew"
                                                                                        ValidationGroup="AddCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                        SkinID="Validator">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="cvExceptionCostUsdNew" runat="server" ControlToValidate="tbxExceptionCostUsdNew"
                                                                                        Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle Width="80px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="CostID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostID" runat="server" SkinID="Label" Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostIDEdit" runat="server" SkinID="Label" Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionRefID" runat="server" SkinID="Label" Text='<%# Bind("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblExceptionRefIDEdit" runat="server" SkinID="Label" Text='<%# Bind("RefID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Work_" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionWork_" runat="server" SkinID="Label" Text='<%# Bind("Work_") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblExceptionWork_Edit" runat="server" SkinID="Label" Text='<%# Bind("Work_") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Function_" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionFunction_" runat="server" SkinID="Label" Text='<%# Bind("Function_") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblExceptionFunction_Edit" runat="server" SkinID="Label" Text='<%# Bind("Function_") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                <%--Buttons--%>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                                            CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                                            CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                            CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                            CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                            CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this exception?");'
                                                                                            ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                        </asp:ImageButton>
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
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="tpNotesData" runat="server" HeaderText="Notes" OnClientClick="tpNotesDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
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
                                                <asp:UpdatePanel ID="upnlNotes" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px"
                                                            DataSourceID="odsNotes" OnRowUpdating="grdNotes_RowUpdating" OnRowEditing="grdNotes_RowEditing"
                                                            OnRowDeleting="grdNotes_RowDeleting" OnRowCommand="grdNotes_RowCommand" OnDataBound="grdNotes_DataBound"
                                                            DataKeyNames="MaterialID,RefID" AllowPaging="True" AutoGenerateColumns="False"
                                                            ShowFooter="True" PageSize="5">
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="MaterialID" Visible="False" HeaderText="ServiceID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblMaterialID" runat="server" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMaterialID" runat="server" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="Subject" HeaderText="Information">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w76"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w77"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectEdit" __designer:wfdid="w78"></asp:RequiredFieldValidator>
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
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteDateEdit" runat="server" SkinID="Label" Text="Date" EnableViewState="False"
                                                                                            __designer:wfdid="w79"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False" __designer:wfdid="w80"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDateEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w81"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' ReadOnly="True" __designer:wfdid="w82"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w83"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w84"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectNew" __designer:wfdid="w85"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w70"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" ReadOnly="True" __designer:wfdid="w71"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px">
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
                                                                                        <asp:Label ID="lblNoteDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"
                                                                                            __designer:wfdid="w72"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False" __designer:wfdid="w73"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDate" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' ReadOnly="True" __designer:wfdid="w74"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' ReadOnly="True" __designer:wfdid="w75"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="Notes" HeaderText="Notes">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 160px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteEdit" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w64"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" TextMode="MultiLine" Rows="4"
                                                                                            __designer:wfdid="w65"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteEdit" __designer:wfdid="w66"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 2 columns - Notes  information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w67"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" Rows="1" __designer:wfdid="w68"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a note"
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteNew" __designer:wfdid="w69"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w62"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" ReadOnly="True" TextMode="MultiLine"
                                                                                            Rows="4" __designer:wfdid="w63"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                                            CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                                            CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                            CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                            CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                            CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this note?");'
                                                                                            ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                        </asp:ImageButton>
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
                                </div>
                            </ContentTemplate>
                            <HeaderTemplate>
                                Notes
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
                    <asp:ObjectDataSource ID="odsCosts" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCostsNew" TypeName="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_edit"
                        DeleteMethod="DummyCostsNew" InsertMethod="DummyCostsNew" UpdateMethod="DummyCostsNew">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCostsExceptions" runat="server" SelectMethod="GetCostsExceptionsNew"
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_edit" DeleteMethod="DummyCostsExceptionsNew"
                        InsertMethod="DummyCostsExceptionsNew" UpdateMethod="DummyCostsExceptionsNew"
                        FilterExpression="Deleted=0"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsWorkFunctionConcat" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTimeWorkFunctionConcatList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workFunctionConcat" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_edit"
                        DeleteMethod="DummyNotesNew" InsertMethod="DummyNotesNew" UpdateMethod="DummyNotesNew">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsThicknessList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Assets.LfsAssetSewerSectionThicknessList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="thickness" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSizeList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkPointRepairsRepairPointSizeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="size_" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsLengthList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkPointRepairsRepairPointLengthList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="length" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementMaterials" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Materials" Name="module" Type="String" />
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
                    <asp:HiddenField ID="hdfCurrentMaterialId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfResourceType" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfProcess" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
