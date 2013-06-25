<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" Codebehind="linning_plan.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.linning_plan" Title="LFS Live"  %>
    
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblPageTitle1" runat="server" Text="Lining Plan" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>   



<asp:Content ID="Content5" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuCurrentClient" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Current Client" PostBack="false">
                                <Items>                                   
                                    <telerik:RadPanelItem runat="server" Value="mCurrentClient" Text="Current Client" PostBack="false">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxCurrentClient" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>     
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mChange" Text="Change" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuLaterals" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Laterals" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAdd" Text="Add"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <hr style="color: #2f82c7; height: 1px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mLiningPlan" Text="Lining Plan" Selected="true" PostBack="false"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mLateralsOverviewReport" Text="Laterals Overview Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mLinersToBuildReport" Text="Liners To Build Report" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>
</asp:Content> 


    
<asp:Content ID="Content1" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR-->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mPreview" Text="PREVIEW" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>    



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        
        <!-- Page element: Order by -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 130px">
                    <asp:Label ID="lblOrder" runat="server" SkinID="Label" Text="Order Sections By" EnableViewState="False"></asp:Label>
                </td>
                <td>
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
                    <asp:DropDownList ID="ddlOrder" runat="server" SkinID="DropDownList" Width="120px">
                        <asp:ListItem>Default</asp:ListItem>
                        <asp:ListItem>Per selection</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnOrder" runat="server" SkinID="Button" Text="Order" Width="80px"
                        OnClick="btnOrder_Click" EnableViewState="False" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
        </table>
        <!-- Page element: No results bar -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <div>
                        <asp:Panel ID="pNoResults" runat="server">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 750px; height: 28px">
                                <tr>
                                    <td style="background-color: #C8DBED; vertical-align: middle">
                                        <asp:Label ID="lblNoResults" runat="server" SkinID="Error" Text="Sections not found for Lining Plan"
                                            EnableViewState="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>
        <!-- Page element: Grid results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="grdLinningPlan" runat="server" AutoGenerateColumns="False" PageSize="1"
                        Width="100%" GridLines="None" ShowHeader="False" AllowSorting="True" OnSorting="grdLinningPlan_Sorting"
                        EnableViewState="False" OnRowDataBound="grdLinningPlan_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <!-- Table element : 5 columns - Section row -->
                                    <table border="0" cellpadding="0" cellspacing="0" class="Background_ViewGrid_Table">
                                        <tr>
                                            <td style=" width: 100%">
                                                <!-- Table element: 5 columns - Header data -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">
                                                    <tr>
                                                        <td style="width: 110px"  class="Background_ViewGrid_Header">
                                                            <asp:Label ID="lblHeader" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Order"></asp:Label>
                                                        </td>
                                                        <td style="width: 450px" colspan="2" class="Background_ViewGrid_Header">
                                                            <asp:Label ID="lblHeader2" runat="server" EnableViewState="False" SkinID="ViewGridHeader"
                                                                Text="Section available for Lining Plan"></asp:Label>
                                                        </td>
                                                        <td style="width: 190px" colspan="2"  class="Background_ViewGrid_Header">
                                                            <asp:Label ID="lblHeader3" runat="server" EnableViewState="False" SkinID="ViewGridHeader"
                                                                Text="Setup"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <!-- Table element: 5 columns - LinningPlan fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_ViewGrid_Table">
                                                    <tr>
                                                        <td style="width: 110px; border-right: #c8dbed thin solid; vertical-align: middle;
                                                            text-align: center;" class="Background_ViewGrid_Td">
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
                                                        <td style="width: 20px" class="Background_ViewGrid_Td">
                                                        </td>
                                                        <td style="width: 430; border-right: #c8dbed thin solid; vertical-align: top" class="Background_ViewGrid_Td">
                                                            <!-- Table element: 3 columns - Section data -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 430px" >
                                                                <tr>
                                                                    <td style="width: 140px; height: 15px" class="Background_ViewGrid_Td">
                                                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Eval("ID") %>' />
                                                                    </td>
                                                                    <td style="width: 140px" class="Background_ViewGrid_Td">
                                                                        <asp:HiddenField ID="hdfCompanyId" runat="server" Value='<%# Eval("COMPANY_ID") %>' />
                                                                    </td>
                                                                    <td style="width: 150px" class="Background_ViewGrid_Td">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblId" runat="server" Text="Section ID" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblIssue" runat="server" EnableViewState="False" SkinID="Label" Text="Issue With Laterals?"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxRecordId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("RecordID") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxIssue" runat="server" EnableViewState="False" ReadOnly="true"
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("IssueWithLaterals") %>' Width="130px"></asp:TextBox></td>
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
                                                                        <asp:Label ID="lblStreet" runat="server" Text="Street" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblConfirmedSize" runat="server" Text="Confirmed Size" SkinID="Label"
                                                                            EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="tbxStreet" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="270px" Text='<%# Eval("Street") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxConfirmedSize" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("ConfirmedSize") %>' EnableViewState="False"></asp:TextBox></td>
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
                                                                        <asp:Label ID="lblBypassRequired" runat="server" Text="Bypass" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDegreeOfTrafficControl" runat="server" Text="Traffic Control" SkinID="Label"
                                                                            EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNumLats" runat="server" Text="Laterals" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxBypassRequired" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# GetBooleanValue(Eval("BypassRequired")) %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDegreeOfTraficcControl" runat="server" SkinID="TextBoxReadOnly"
                                                                            ReadOnly="true" Width="130px" Text='<%# Eval("DegreeOfTrafficControl") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxNumLats" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("NumLats") %>' EnableViewState="False"></asp:TextBox></td>
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
                                                                        <asp:Label ID="lblAllMeasured" runat="server" Text="All Measured?" SkinID="Label"
                                                                            EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNotMeasuredYet" runat="server" Text="Not Measured Yet" SkinID="Label"
                                                                            EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNotDeliveredYet" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Not Delivered Yet"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxAllMeasured" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# GetBooleanValue(Eval("AllMeasured")) %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxNotMeasuredYet" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("NotMeasuredYet") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxNotDeliveredYet" runat="server" EnableViewState="False" ReadOnly="true"
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("NotDeliveredYet") %>' Width="130px"></asp:TextBox></td>
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
                                                                        <asp:Label ID="lblNotLinedYet" runat="server" Text="Not Lined Yet" SkinID="Label"
                                                                            EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        &nbsp;<asp:Label ID="lblActualLength" runat="server" Text="Actual Length" SkinID="Label"
                                                                            EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblUSMH" runat="server" Text="USMH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxNotLinedYet" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("NotLinedYet") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxActualLength" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("ActualLength") %>' EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxUSMH" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("USMH") %>' EnableViewState="False"></asp:TextBox></td>
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
                                                                        <asp:Label ID="lblDSMH" runat="server" Text="DSMH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDSMH" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                            Width="130px" Text='<%# Eval("DSMH") %>' EnableViewState="False"></asp:TextBox></td>
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
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 20px"  class="Background_ViewGrid_Td">
                                                        </td>
                                                        <td style="width: 170px; vertical-align: top"  class="Background_ViewGrid_Td">
                                                            <!-- Table element: 2 columns - Setup data -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 170px" >
                                                                <tr>
                                                                    <td style="width: 90px; height: 15px" class="Background_ViewGrid_Td">
                                                                    </td>
                                                                    <td style="width: 80px" class="Background_ViewGrid_Td">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblDate_" runat="server" Text="Date" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDate_" runat="server" SkinID="TextBox" Width="80px" Text='<%# Eval("Date_", "{0:d}") %>'
                                                                            EnableViewState="False"></asp:TextBox></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CompareValidator ID="cvDate_" runat="server" ControlToValidate="tbxDate_" Display="Dynamic"
                                                                            SkinID="Validator" ErrorMessage="Invalid date (use MM/DD/YYYY format)" Operator="DataTypeCheck"
                                                                            Type="Date" EnableViewState="False"></asp:CompareValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblFlusher" runat="server" Text="Flusher Truck" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblFlusherMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlFlusher" runat="server" Width="80px" DataSourceID="odsFlusherUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Flusher") %>'>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                       <asp:DropDownList ID="ddlFlusherMN" runat="server" SkinID="DropDownList" Width="60px"
                                                                             DataTextField="MH" DataValueField="MH">                                                                            
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
                                                                        <asp:Label ID="lblLiner" runat="server" Text="Liner Truck" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLinerMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlLiner" runat="server" Width="80px" DataSourceID="odsLinerTruckUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Liner") %>'>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlLinerMN" runat="server" SkinID="DropDownList" Width="60px"
                                                                             DataTextField="MH" DataValueField="MHType">
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
                                                                        <asp:Label ID="lblRotator" runat="server" Text="Rotator Truck" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblRotatorMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlRotator" runat="server" Width="80px" DataSourceID="odsRotatorTruckUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Rotator") %>'>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlRotatorMN" runat="server" SkinID="DropDownList" Width="60px"
                                                                            DataTextField="MH" DataValueField="MH">
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
                                                                        <asp:Label ID="lblCompressor" runat="server" Text="Compressor" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCompressorMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCompressor" runat="server" Width="80px" DataSourceID="odsCompressorsUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Compressor") %>'>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCompressorMN" runat="server" SkinID="DropDownList" Width="60px"
                                                                            DataTextField="MH" DataValueField="MH">
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
                                            <td style="height: 35px">
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        
        <!-- Table element : Toolbar -->
        <div style="width: 750px">
            <table id="tbFooterToolbar" runat="server" border="0" cellpadding="0" cellspacing="0"
                style="width: 100%" class="ASPxMenu_Background">
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
                    <td style="height: 10px">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        
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
                    <asp:ObjectDataSource ID="odsLinerTruckUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter Name="isWithUnitCode" Type="Boolean" DefaultValue="true" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsRotatorTruckUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter Name="isWithUnitCode" Type="Boolean" DefaultValue="true" />
                        </SelectParameters>
                    </asp:ObjectDataSource> 
                    <asp:ObjectDataSource ID="odsCompressorsUnits" runat="server" CacheDuration="120" EnableCaching="True"
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
                    <asp:HiddenField ID="hdfCurrentClient" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>