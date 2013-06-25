<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="pr_lining_plan.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_lining_plan" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Lining Plan" SkinID="LabelPageTitle1"></asp:Label>
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
                            <telerik:RadMenuItem Value="mPreview" Text="PREVIEW" />
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
                            <telerik:RadPanelItem Expanded="True" Text="Point Repairs" PostBack="false">
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
                                    <telerik:RadPanelItem runat="server" Value="mPointRepairsPlan" Text="Lining Plan" Selected="true" PostBack="false"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mOverviewReport" Text="Overview Report" ></telerik:RadPanelItem>
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
                    <asp:Label ID="lblOrder" runat="server" SkinID="Label" Text="Order Repairs By" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 130px">
                    <asp:Label ID="lblFilter" runat="server" SkinID="Label" Text="Filter By" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 110px">
                </td>
                <td style="width: 360px">
                </td>
                <td style="width: 10px">
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
                    <asp:DropDownList ID="ddlFilter" runat="server" SkinID="DropDownList" Width="120px">
                        <asp:ListItem Value="(All)" Text="(All)" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Robotic Reaming" Text="Robotic Reaming"></asp:ListItem>
                        <asp:ListItem Value="Point Lining" Text="Point Lining"></asp:ListItem>
                        <asp:ListItem Value="Grouting" Text="Grouting"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnOrder" runat="server" SkinID="Button" Text="Order and Filter" Width="100px" OnClick="btnOrder_Click" EnableViewState="False" />
                </td>
                <td>
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
                    <asp:GridView ID="grdLiningPlan" runat="server" AutoGenerateColumns="False" PageSize="1" Width="100%" GridLines="None" ShowHeader="False" AllowSorting="True" OnRowDataBound="grdLiningPlan_RowDataBound" OnSorting="grdLiningPlan_Sorting" EnableViewState="False">
                        <Columns>
                            <asp:TemplateField>                               
                                <ItemTemplate>                                
                                    <!-- Table element : 5 columns - Repair row -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_ViewGrid_Table">                                    
                                        <tr>
                                            <td style="width: 100%" class="Background_ViewGrid_Header">
                                                <!-- Table element: 5 columns - Header data -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">
                                                    <tr>
                                                        <td style="width: 110px">
                                                            <asp:Label ID="lblHeader" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Order"></asp:Label>
                                                            <asp:HiddenField ID="hdfWorkID" runat="server" Value='<%# Eval("WorkID") %>' />
                                                            <asp:HiddenField ID="hdfRepairPointId" runat="server" EnableViewState="false" Value='<%# Eval("RepairPointID") %>' />
                                                        </td>
                                                        <td style="width: 530px" colspan="5">
                                                            <asp:Label ID="lblHeader2" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Repair available for Lining Plan"></asp:Label>
                                                        </td>
                                                        <td style="width: 90px"> 
                                                            <asp:Label ID="lblHeader3" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Setup"></asp:Label>
                                                        </td>
                                                    </tr>                                                    
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Background_ViewGrid_Td">
                                                <!-- Table element: 3 columns - Lining Plan fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                                                
                                                    <tr>
                                                        <td style="width: 110px; vertical-align: middle; text-align: center;">
                                                            <asp:DropDownList ID="ddlSelected" runat="server" Width="70px" SkinID="DropDownList" SelectedValue='<%# Eval("Selected") %>'>
                                                                <asp:ListItem Selected="True" Value="9">(None)</asp:ListItem>
                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                                <asp:ListItem Value="6">6</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 12px;" class="Background_ViewGrid_Td">
                                                        </td>                                        
                                                        <td style="width: 1px;" class="ViewGrid_Separator">
                                                        </td>
                                                        <td style="width: 12px;" class="Background_ViewGrid_Td">                                                                                                                                
                                                        </td>                                                                                                              
                                                        <td style="width: 510px; vertical-align: top">
                                                        
                                                            <!-- Table element: 5 columns - RM Section data -->
                                                                                                                        
                                                            <asp:PlaceHolder ID="phRoboticReaming" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Robotic Reaming") %>'>                                                                
                                                                <!-- Page element : 5 columns - Repair Information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 102px; height: 15px;"></td>
                                                                        <td style="width: 102px;"></td>
                                                                        <td style="width: 102px;"></td>
                                                                        <td style="width: 102px;"></td>
                                                                        <td style="width: 102px;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblRmSectionId" runat="server" Text="Section ID" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblRmRepairPointId" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblRmRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                       <td>
                                                                            <asp:Label ID="lblRmReamDistance" runat="server" Text="Ream Distance" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblRmDefectQualifier" runat="server" Text="Defect Qualifier" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmFlowOrderId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("FlowOrderID") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("RepairPointID") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Type") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmReamDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("ReamDistance") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="False"></asp:TextBox>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblRmDefectDetails" runat="server" Text="Defect Details" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblRmReamDate" runat="server" Text="Ream Date" SkinID="Label" EnableViewState="false"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblRmApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("DefectDetails") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmReamDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("ReamDate", "{0:d}") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBox ID="cbxRmExtraRepair" runat="server" SkinID="CheckBoxSmall" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="False" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBox ID="cbxRmCancelled" runat="server" SkinID="CheckBoxSmall" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="False" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxRmApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Approval") %>' EnableViewState="False"></asp:TextBox>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <asp:Label ID="lblRmComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                       <td colspan="5">
                                                                            <asp:TextBox ID="tbxRmComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="500px" Text='<%# Eval("Comments") %>' EnableViewState="False"></asp:TextBox>
                                                                        <td>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:PlaceHolder>
                                                            
                                                            <asp:PlaceHolder ID="phPointLining" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Point Lining") %>'>                                                               
                                                                <!-- Page element : 5 columns - Repair Information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 102px; height: 15px"></td>
                                                                        <td style="width: 102px"></td>
                                                                        <td style="width: 102px"></td>
                                                                        <td style="width: 102px;"></td>
                                                                        <td style="width: 102px;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblPlSectionID" runat="server" Text="Section ID" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlRepairPointID" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                       <td>
                                                                            <asp:Label ID="lblPlLinerDistance" runat="server" Text="Liner Distance" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlDefectQualifier" runat="server" Text="Defect Qualifier" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlFlowOrderId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("FlowOrderID") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("RepairPointID") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Type") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlLinerDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("LinerDistance") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="False"></asp:TextBox>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblPlDefectDetails" runat="server" Text="Defect Details" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlDirection" runat="server" Text="Direction" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlReinstates" runat="server" Text="Reinstates" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlLtmh" runat="server" SkinID="Label" Text="LT @ MH" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlVtmh" runat="server" SkinID="Label" Text="VT @ MH" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("DefectDetails") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlDirection" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Direction") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlReinstates" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Reinstates") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlLtmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("LTMH") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlVtmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("VTMH") %>' EnableViewState="False"></asp:TextBox>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblPlDistance" runat="server" SkinID="Label" Text="Distance" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlSize" runat="server" SkinID="Label" Text="Size" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlInstallDate" runat="server" SkinID="Label" Text="Install Date" EnableViewState="false"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlMhShot" runat="server" SkinID="Label" Text="MH Shot?" EnableViewState="false"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Distance") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlSize" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Size_") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlInstallDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("InstallDate", "{0:d}") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlMhShot" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("MHShot") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBox ID="cbxPlExtraRepair" runat="server" SkinID="CheckBoxSmall" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="False"/>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPlApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="false"></asp:Label>
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
                                                                            <asp:CheckBox ID="cbxPlCancelled" runat="server" SkinID="CheckBoxSmall" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="False" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPlApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Approval") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <asp:Label ID="lblPlComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                       <td colspan="5">
                                                                            <asp:TextBox ID="tbxPlComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="500px" Text='<%# Eval("Comments") %>' EnableViewState="False"></asp:TextBox>
                                                                        <td>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                                
                                                            </asp:PlaceHolder>
                                                            
                                                            <asp:PlaceHolder ID="phGrouting" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Grouting") %>'> 
                                                                <!-- Page element : 5 columns - Repair Information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 102px; height: 15px"></td>
                                                                        <td style="width: 102px"></td>
                                                                        <td style="width: 102px"></td>
                                                                        <td style="width: 102px;"></td>
                                                                        <td style="width: 102px;"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblGtSectionID" runat="server" Text="Section ID" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGtRepairPointId" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGtRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGtGroutDistance" runat="server" Text="Grout Distance" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td> 
                                                                            <asp:Label ID="lblGtDefectQualifier" runat="server" Text="Defect Qualifier" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>                                                                       
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtSectionID" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("FlowOrderID") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("RepairPointID") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Type") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtGroutDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("GroutDistance") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="True"></asp:TextBox>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td> 
                                                                            <asp:Label ID="lblGtDefectDetails" runat="server" Text="Defect Details" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGtGroutDate" runat="server" Text="Grout Date" SkinID="Label" EnableViewState="false"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGtApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("DefectDetails") %>' EnableViewState="True"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtGroutDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("GroutDate", "{0:d}") %>' EnableViewState="False"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBox ID="cbxGtExtraRepair" runat="server" SkinID="CheckBoxSmall" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="False" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBox ID="cbxGtCancelled" runat="server" SkinID="CheckBoxSmall" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="False" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxGtApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="92px" Text='<%# Eval("Approval") %>' EnableViewState="False"></asp:TextBox>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <asp:Label ID="lblGtComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                       <td colspan="5">
                                                                            <asp:TextBox ID="tbxGtComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="500px" Text='<%# Eval("Comments") %>' EnableViewState="False"></asp:TextBox>
                                                                        <td>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:PlaceHolder>                                 
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>                                        
                                                        <td style="width: 1px" class="ViewGrid_Separator">
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>
                                                        <td style="width: 90px; vertical-align: top">
                                                            <!-- Table element: 2 columns - Setup data -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 90px">
                                                                <tr>
                                                                    <td style="width: 90px; height: 15px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblDate_" runat="server" Text="Date" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDate_" runat="server" SkinID="TextBox" Width="80px" Text='<%# Eval("Date_", "{0:d}") %>' EnableViewState="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CompareValidator ID="cvDate_" runat="server" ControlToValidate="tbxDate_" Display="Dynamic" SkinID="Validator" ErrorMessage="Invalid date (use MM/DD/YYYY format)" 
                                                                            Operator="DataTypeCheck" Type="Date" EnableViewState="False">
                                                                        </asp:CompareValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblVideoTruck" runat="server" Text="Video Truck" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        <asp:Label ID="lblVideoMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlVideoTruck" runat="server" Width="80px" DataSourceID="odsVideoTruckUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Video") %>'>
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hdfVideoMN" runat="server" Value='<%# Eval("VideoMN") %>' />
                                                                        <asp:DropDownList ID="ddlVideoMN" runat="server" SkinID="DropDownList" Visible="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblLinerTruck" runat="server" Text="Liner Truck" SkinID="Label" EnableViewState="False"></asp:Label>
                                                                        <asp:Label ID="lblLinerMN" runat="server" Text="@MH" SkinID="Label" EnableViewState="False" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlLinerTruck" runat="server" Width="80px" DataSourceID="odsLinerTruckUnits"
                                                                            DataValueField="UnitCode" DataTextField="UnitCode" SkinID="DropDownList" SelectedValue='<%# Eval("Liner") %>' >
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hdfLinerMN" runat="server" Value='<%# Eval("LinerMN") %>' />
                                                                        <asp:DropDownList ID="ddlLinerMN" runat="server" SkinID="DropDownList" Visible="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 20px">
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
        
        <!-- Page element : Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsVideoTruckUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="" Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter Name="isWithUnitCode" Type="Boolean" DefaultValue="true" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsLinerTruckUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="" Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter Name="isWithUnitCode" Type="Boolean" DefaultValue="true" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
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