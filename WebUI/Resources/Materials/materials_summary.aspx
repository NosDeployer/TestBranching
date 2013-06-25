<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="materials_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_summary" Title="LFS Live"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td style="width: 740px">
                    <asp:Label ID="lblTitle" runat="server" Text="Materials Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                    <asp:Label ID="lblTitleMaterial" runat="server" Text="Material:" SkinID="LabelPageTitle2"></asp:Label>                    
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" >                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mChangeState" Text="CHANGE STATE" />
                            
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
        <!-- Table element: 1 columns - Material Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblMaterialDetails" runat="server" SkinID="LabelTitle1" Text="Material Details" EnableViewState="False"></asp:Label>
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
                <td style="width: 125px">
                    <asp:Label ID="lblProcess" runat="server" EnableViewState="False" SkinID="Label" Text="Process"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="False" SkinID="Label" Text="Description"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblSize" runat="server" EnableViewState="False" SkinID="Label" Text="Size"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblThicknessLength" runat="server" EnableViewState="False" SkinID="Label" Text="Thickness"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" Text="State"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxProcess" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxDescription" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxSize" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxThicknessLength" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxState" runat="server" ReadOnly="True" SkinID="TextBoxSpecialWhite" Style="width: 115px">
                    </asp:TextBox>
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
        
        <!-- Table element: 6 columns - Costs Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblCostInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="False"></asp:Label>
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
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" ActiveTabIndex="0" CssClass="ajax_tabcontainer" Height="640px">
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="Costs" OnClientClick="tpCostDataClientClick">
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
                                                        <asp:GridView ID="grdCosts" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                                                            DataKeyNames="CostID" DataMember="DefaultView" DataSourceID="odsCosts" OnDataBound="grdCosts_DataBound"
                                                            PageSize="13" SkinID="GridViewInTabs" Width="450px">
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <HeaderStyle Width="30px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" AutoPostBack="True" OnCheckedChanged="cbxSelectedCost_CheckedChanged"
                                                                            Width="25px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <HeaderStyle Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" SkinID="Label" Text='<%# Bind("Date", "{0:d}") %>'
                                                                            Width="100px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <HeaderStyle Width="70px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitOfMeasurement" runat="server" SkinID="Label" Text='<%# Bind("UnitOfMeasurement") %>'
                                                                            Width="70px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cost (CAD)">
                                                                    <HeaderStyle Width="80px" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("CostCad"),2) %>'
                                                                            Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cost (USD)">
                                                                    <HeaderStyle Width="80px" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("CostUsd"),2) %>'
                                                                            Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CostID" Visible="false">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCostID" runat="server" SkinID="Label" Text='<%# Bind("CostID") %>'></asp:Label>
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
                                                            DataKeyNames="CostID,RefID" DataMember="DefaultView" DataSourceID="odsCostsExceptions"
                                                            OnDataBound="grdCostsExceptions_DataBound" PageSize="13" SkinID="GridViewInTabs">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Type of Work.Function">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionWorkFunction" runat="server" SkinID="Label" Style="width: 200px"
                                                                            Text='<%# Bind("WorkFunction") %>' Width="200px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Width="200px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit of Measurement">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionUnitOfMeasurement" runat="server" SkinID="Label" Style="width: 90px"
                                                                            Text='<%# Bind("UnitOfMeasurement") %>' Width="90px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <HeaderStyle Width="90px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cost (CAD)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostCad" runat="server" SkinID="Label" Style="width: 75px"
                                                                            Text='<%# GetRound(Eval("CostCad"),2) %>' Width="75px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle Width="75px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cost (USD)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostUSD" runat="server" SkinID="Label" Style="width: 75px"
                                                                            Text='<%# GetRound(Eval("CostUsd"),2) %>' Width="75px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle Width="75px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CostID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionCostID" runat="server" SkinID="Label" Text='<%# Bind("CostID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionRefID" runat="server" SkinID="Label" Text='<%# Bind("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Work_" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionWork_" runat="server" SkinID="Label" Text='<%# Bind("Work_") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="0px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Function_" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExceptionFunction_" runat="server" SkinID="Label" Text='<%# Bind("Function_") %>'></asp:Label>
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
                                                    TypeName="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_summary">
                                                </asp:ObjectDataSource>
                                                <asp:ObjectDataSource ID="odsCostsExceptions" runat="server" SelectMethod="GetCostsExceptionsNew" filterexpression="Deleted=0"
                                                    TypeName="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_summary">
                                                </asp:ObjectDataSource>
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
                                                            DataSourceID="odsNotes" OnDataBound="grdNotes_DataBound" DataKeyNames="MaterialID, RefID"
                                                            AllowPaging="True" AutoGenerateColumns="False" PageSize="5">
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="MaterialID" Visible="False" HeaderText="MaterialID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMaterialID" runat="server" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="Subject" HeaderText="Information">
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
                                                                                        <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" ReadOnly="True"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblNoteDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDate" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                                                            EnableViewState="True" Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' ReadOnly="True"></asp:TextBox>
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
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
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
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_summary">
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