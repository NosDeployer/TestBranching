<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="flat_section_jl_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.flat_section_jl_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Junction Lining Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" SkinID="ButtonPageTitle" EnableViewState="True" OnClick="btnChange_Click" />
                </td>
                <td style="width: 10px;">
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuJunctionLining" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Junction Lining" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearchS" Text="Search Sections" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search Junction Lining" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mLiningPlan" Text="Lining Plan"></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuJunctionLiningTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
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
                    <telerik:RadPanelBar id="tkrpbLeftMenuJunctionLiningReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mLateralsOverviewReport" Text="Laterals Overview Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mLinersToBuildReport" Text="Liners To Build Reports" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar2_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mM1M2ReportByClient" Text="M1 &amp; M2 Report"></telerik:RadPanelItem>
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
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: 1 column - Grid Jliner -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 10px">
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlJl" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdvJl" runat="server" EnableViewState="false" Width="100%" OnRowDataBound="grdvJl_RowDataBound"
                                OnRowCreated="grdvJl_RowCreated" OnRowCommand="grdvJl_RowCommand" ShowHeader="False"
                                DataKeyNames="AssetID" PageSize="1" GridLines="None" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <!-- Table element : 3 columns - Jl row -->
                                            <table style="width: 100%" class="Background_ViewGrid_Table" cellspacing="0" cellpadding="0"
                                                border="0">
                                                <tr>
                                                    <td class="Background_ViewGrid_Header" align="center" colspan="2">
                                                        <asp:Label ID="lblTitleGrid" runat="server" SkinID="ViewGridHeader" Text="Lateral - Junction Lining"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25px" class="Background_ViewGrid_Td">
                                                    </td>
                                                    <td class="Background_ViewGrid_Td">
                                                        <!-- Table element : 5 columns - Jliner fields -->
                                                        <table style="width: 700px" cellspacing="0" cellpadding="0" border="0">
                                                            <tr>
                                                                <td style="width: 20%">
                                                                </td>
                                                                <td style="width: 20%">
                                                                </td>
                                                                <td style="width: 20%">
                                                                </td>
                                                                <td style="width: 20%">
                                                                </td>
                                                                <td style="width: 20%">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblLateralId" runat="server" SkinID="Label" Text="ID"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblClientLateralId" runat="server" SkinID="Label" Text="Client Lateral ID"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblHamiltonInspectionNumber" runat="server" SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblStreet" runat="server" SkinID="Label" Text="Street"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="tbxLateralId" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("LateralID") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxClientLateralId" runat="server" SkinID="TextBox" Text='<%# Eval("ClientLateralID") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxHamiltonInspectionNumber" runat="server" SkinID="TextBox" Text='<%# Eval("HamiltonInspectionNumber") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="tbxStreet" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Street") %>' Width="270px" ReadOnly="True">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblAddress" runat="server" SkinID="Label" Text="MN#"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueDigRequiredPriorToLining" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Dig Req'd Prior To Lining"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueDigRequiredPriorToLiningCompleted" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Dig Req'd Prior To Lining Completed"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueDigRequiredAfterLining" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Dig Req'd After Lining"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueDigRequiredAfterLiningDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Dig Req'd After Lining Completed"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="tbxAddress" runat="server" SkinID="TextBox" Text='<%# Eval("Address") %>' Width="130px"></asp:TextBox>                                                                    
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxDigRequiredPriorToLining" runat="server" Checked='<%# Eval("DigRequiredPriorToLining") %>' EnableViewState="False" SkinID="CheckBox" />
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpDigRequiredPriorToLiningCompleted" runat="server" SkinID="RadDatePicker" Width="130px"
                                                                        Calendar-DayNameFormat="Short" Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("DigRequiredPriorToLiningCompleted") %>' >
                                                                    </telerik:RadDatePicker>                                                                    
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxDigRequiredAfterLining" runat="server" Checked='<%# Eval("DigRequiredAfterLining") %>' EnableViewState="False" SkinID="CheckBox" />
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpDigRequiredAfterLiningCompleted" runat="server" Calendar-DayNameFormat="Short" SkinID="RadDatePicker" Width="130px"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("DigRequiredAfterLiningCompleted") %>' >
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvDigRequiredPriorToLiningDate" runat="server" ControlToValidate="tkrdpDigRequiredPriorToLiningCompleted"
                                                                        Display="Dynamic" ErrorMessage="Dig Required Prior To Lining is not checked, please delete this date."
                                                                        OnServerValidate="cvDigRequiredPriorToLiningDate_ServerValidate" SkinID="Validator">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvDigRequiredAfterLiningDate" runat="server" ControlToValidate="tkrdpDigRequiredAfterLiningCompleted"
                                                                        Display="Dynamic" ErrorMessage="Dig Required After Lining is not checked, please delete this date."
                                                                        OnServerValidate="cvDigRequiredAfterLiningDate_ServerValidate" SkinID="Validator">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblIssueOutOfScope" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Out Of Scope"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueHoldClientIssue" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Hold - Client Issue"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueHoldClientIssueResolved" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Hold - Client Issue Resolved"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueHoldLFSIssue" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Hold - LFS Issue"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueHoldLFSIssueResolved" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Hold - LFS Issue Resolved"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxOutOfScope" runat="server" Checked='<%# Eval("OutOfScope") %>' EnableViewState="False" SkinID="CheckBox" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxHoldClientIssue" runat="server" Checked='<%# Eval("HoldClientIssue") %>' EnableViewState="False" SkinID="CheckBox" />
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpHoldClientIssueResolved" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("HoldClientIssueResolved") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxHoldLFSIssue" runat="server" Checked='<%# Eval("HoldLFSIssue") %>' EnableViewState="False" SkinID="CheckBox" />
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpHoldLFSIssueResolved" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("HoldLFSIssueResolved") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvHoldClientIssueDate" runat="server" ControlToValidate="tkrdpHoldClientIssueResolved"
                                                                        Display="Dynamic" ErrorMessage="Hold - Client Issue is not checked, please delete this date."
                                                                        OnServerValidate="cvHoldClientIssueDate_ServerValidate" SkinID="Validator"></asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvHoldLFSIssueDate" runat="server" ControlToValidate="tkrdpHoldLFSIssueResolved"
                                                                        Display="Dynamic" ErrorMessage="Hold - LFS Issue is not checked, please delete this date."
                                                                        OnServerValidate="cvHoldLFSIssueDate_ServerValidate" SkinID="Validator"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblIssueRequiresRoboticPrep" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Requires Robotic Prep"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblIssueRequiresRoboticPrepCompleted" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Requires Robotic Prep Completed"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblUSMH" runat="server" SkinID="Label" Text="USMH"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDSMH" runat="server" SkinID="Label" Text="DSMH"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblVideoInspection" runat="server" SkinID="Label" Text="V1 Inspection"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxRequiresRoboticPrep" runat="server" Checked='<%# Eval("LateralRequiresRoboticPrep") %>'
                                                                        EnableViewState="False" SkinID="CheckBox" />
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpRequiresRoboticPrepCompleted" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("LateralRequiresRoboticPrepCompleted") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxUSMH" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                        Text='<%# Eval("USMHDescription") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxDSMH" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                        Text='<%# Eval("DSMHDescription") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpVideoInspection" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("VideoInspection") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvRequiresRoboticPrep" runat="server" ControlToValidate="tkrdpRequiresRoboticPrepCompleted"
                                                                        Display="Dynamic" ErrorMessage="Requires Robotic Prep is not checked, please delete this date."
                                                                        OnServerValidate="cvRequiresRoboticPrep_ServerValidate" SkinID="Validator"></asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblVideoLengthToPropertyLine" runat="server" SkinID="Label" Text="Video Length To PL"></asp:Label>&nbsp;
                                                                    <a href="#" class="hint">
                                                                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                    </a>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDepthOfLocated" runat="server" SkinID="Label" Text="Depth Of Pipe"></asp:Label>&nbsp;
                                                                    <a href="#" class="hint">
                                                                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                    </a>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPipeLocated" runat="server" SkinID="Label" Text="Pipe Located"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblServicesLocated" runat="server" SkinID="Label" Text="Services Located"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPrepType" runat="server" EnableViewState="False" SkinID="Label" Text="Prep Type"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="tbxVideoLengthToPropertyLine" runat="server" SkinID="Textbox" Text='<%# GetDistance(Eval("VideoLengthToPropertyLine")) %>' Width="130px"></asp:TextBox>                                                                    
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxDepthOfLocated" runat="server" SkinID="Textbox" Text='<%# GetDistance(Eval("DepthOfLocated")) %>' Width="130px"></asp:TextBox>                                                                            
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpPipeLocated" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("PipeLocated") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpServicesLocated" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("ServicesLocated") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlPrepType" runat="server" SelectedValue='<%# GetPrepType(Eval("PrepType")) %>' SkinID="DropDownList" Width="130px">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="CO Req">CO Req</asp:ListItem>
                                                                        <asp:ListItem Value="PFM Req">PFM Req</asp:ListItem>
                                                                        <asp:ListItem Value="Pit Req">Pit Req</asp:ListItem>
                                                                        <asp:ListItem Value="Fact CO Req">Fact CO Req</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvVideoLengthToPropertyLine" runat="server" ControlToValidate="tbxVideoLengthToPropertyLine"
                                                                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                        OnServerValidate="cvDistance_ServerValidate" SkinID="Validator" Width="130px">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvDepthOfLocated" runat="server" ControlToValidate="tbxDepthOfLocated"
                                                                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                        OnServerValidate="cvDistance_ServerValidate" SkinID="Validator" Width="130px">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblCoPitLocation" runat="server" SkinID="Label" Text="CO/Pit Location"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCoInstalled" runat="server" SkinID="Label" Text="C/O Installed"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblBackfilledConcrete" runat="server" SkinID="Label" Text="Backfilled Concrete"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblBackfilledSoil" runat="server" SkinID="Label" Text="Backfilled Soil"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblGrouted" runat="server" SkinID="Label" Text="Grouted"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCoPitLocation" runat="server" DataMember="DefaultView" DataSourceID="odsCoPitLocation"
                                                                        DataTextField="Name" DataValueField="Name" SelectedValue='<%# GetCoPitLocationSelected(Eval("CoPitLocation")) %>'
                                                                        SkinID="DropDownList" Width="130px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpCoInstalled" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("CoInstalled") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpBackfilledConcrete" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("BackfilledConcrete") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpBackfilledSoil" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("BackfilledSoil") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpGrouted" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("Grouted") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblCored" runat="server" SkinID="Label" Text="Cored"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPrepped" runat="server" SkinID="Label" Text="Prepped"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPreVideo" runat="server" SkinID="Label" Text="Pre-Video"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblMeasured" runat="server" SkinID="Label" Text="Measured"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblConnectionType" runat="server" EnableViewState="false" SkinID="Label" Text="Connection Type"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpCored" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("Cored") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpPrepped" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("Prepped") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpPreVideo" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("PreVideo") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpMeasured" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("Measured") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlConnectionType" runat="server" __designer:wfdid="w51" SelectedValue='<%# GetConnectionType(Eval("ConnectionType")) %>'
                                                                        SkinID="DropDownList" Width="130px">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="Fact. Tee">Fact. Tee</asp:ListItem>
                                                                        <asp:ListItem Value="Fact. Wye">Fact. Wye</asp:ListItem>
                                                                        <asp:ListItem Value="H. Tee">H. Tee</asp:ListItem>
                                                                        <asp:ListItem Value="H. Wye">H. Wye</asp:ListItem>
                                                                        <asp:ListItem Value="S. Tee">S. Tee</asp:ListItem>
                                                                        <asp:ListItem Value="S. Wye">S. Wye</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblLinerType" runat="server" SkinID="Label" Text="Liner Type"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFlange" runat="server" SkinID="Label" Text="Flange"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblGasket" runat="server" SkinID="Label" Text="Gasket"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblMainSize" runat="server" SkinID="Label" Text="Main size"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblLinerSize" runat="server" SkinID="Label" Text="Liner Size"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlLinerType" runat="server" SelectedValue='<%# GetLinerType(Eval("LinerType")) %>' SkinID="DropDownList" Width="130px">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="LFM Liner">LFM Liner</asp:ListItem>
                                                                        <asp:ListItem Value="J-Liner">J-Liner</asp:ListItem>
                                                                        <asp:ListItem Value="Lat Liner">Lat Liner</asp:ListItem>
                                                                        <asp:ListItem Value="Prado Liner">Prado Liner</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlFlange" runat="server" AutoPostBack="True" DataSourceID="odsFlange"
                                                                        DataTextField="Flange" DataValueField="Flange" OnSelectedIndexChanged="ddlFlange_SelectedIndexChanged"
                                                                        SelectedValue='<%# GetFlange(Eval("Flange")) %>' SkinID="DropDownList" Width="130px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td style="width: 130px">
                                                                                <asp:DropDownList ID="ddlGasket" runat="server" __designer:wfdid="w58" SelectedValue='<%# GetGasket(DataBinder.Eval(Container.DataItem, "Gasket")) %>'
                                                                                    SkinID="DropDownList" Width="130px">
                                                                                    <asp:ListItem Value=""></asp:ListItem>
                                                                                    <asp:ListItem Value="28&quot;">28&quot;</asp:ListItem>
                                                                                    <asp:ListItem Value="30&quot;">30&quot;</asp:ListItem>
                                                                                    <asp:ListItem Value="32&quot;">32&quot;</asp:ListItem>
                                                                                    <asp:ListItem Value="12.5">12.5</asp:ListItem>
                                                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="vertical-align: middle">
                                                                                <asp:UpdateProgress ID="upGasket" runat="server" __designer:wfdid="w59" AssociatedUpdatePanelID="upnlJl">
                                                                                    <ProgressTemplate>
                                                                                        <asp:Image ID="imAjaxGasket" runat="server" __designer:wfdid="w60" SkinID="Ajax_Blue" />
                                                                                    </ProgressTemplate>
                                                                                </asp:UpdateProgress>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxMainSize" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("MainSize") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxLinerSize" runat="server" SkinID="TextBox" Text='<%# Eval("LinerSize") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblNoticeDelivered" runat="server" SkinID="Label" Text="Notice Delivered"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblInProcess" runat="server" SkinID="Label" Text="Liner In Process"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblInStock" runat="server" SkinID="Label" Text="Liner In Stock"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDelivered" runat="server" SkinID="Label" Text="Liner Delivered"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblLinerInstalled" runat="server" SkinID="Label" Text="Liner Installed"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpNoticeDelivered" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("NoticeDelivered") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpInProcess" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("InProcess") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpInStock" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("InStock") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpDelivered" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("Delivered") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpLinerInstalled" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("LinerInstalled") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFinalVideo" runat="server" SkinID="Label" Text="Final Video"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDistanceFromUSMH" runat="server" SkinID="Label" Text="Dist. From USMH"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDistanceFromDSMH" runat="server" SkinID="Label" Text="Dist. From DSMH"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCoCutDown" runat="server" SkinID="Label" Text="C/O Cut Down?"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFinalRestoration" runat="server" SkinID="Label" Text="Final Restoration"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpFinalVideo" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("FinalVideo") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxDistanceFromUSMH" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                                        Text='<%# GetDistance(Eval("DistanceFromUSMH")) %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxDistanceFromDSMH" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                                        Text='<%# GetDistance(Eval("DistanceFromDSMH")) %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpCoCutDown" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("CoCutDown") %>' SkinID="RadDatePicker"
                                                                        Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpFinalRestoration" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("FinalRestoration") %>'
                                                                        SkinID="RadDatePicker" Width="130px">
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>   
                                                                <td>
                                                                    <asp:Label ID="lblDyeTestReq" runat="server" SkinID="Label" Text="Dye Test Req'd"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDyeTestComplete" runat="server" SkinID="Label" Text="Dye Test Complete"></asp:Label>
                                                                </td>                                                             
                                                                <td>
                                                                    <asp:Label ID="lblBuildRebuild" runat="server" SkinID="Label" Text="Build / Rebuild #"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCost" runat="server" SkinID="Label" Text="Cost" Visible='<%# Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]) %>'></asp:Label>&nbsp;
                                                                    <a href="#" class="hint">
                                                                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                        <b class="hint">Please use #.## format.</b><span class="hint"></span>
                                                                    </a>
                                                                </td>                                                                
                                                                <td>
                                                                    <asp:Label ID="lblContractYear" runat="server" SkinID="Label" Text="Contract Year"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>   
                                                                <td>
                                                                    <asp:CheckBox ID="ckbxDyeTestReq" runat="server" Checked='<%# Eval("DyeTestReq") %>'
                                                                        EnableViewState="False" SkinID="CheckBox" />
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpDyeTestComplete" runat="server" Calendar-DayNameFormat="Short"
                                                                        Calendar-ShowRowHeaders="false" DbSelectedDate='<%# Eval("DyeTestComplete") %>'
                                                                        SkinID="RadDatePicker" Width="130px">                                                                                                                                               
                                                                    </telerik:RadDatePicker>
                                                                </td>                                                             
                                                                <td>
                                                                    <asp:TextBox ID="tbxBuildRebuild" runat="server" __designer:wfdid="w88" ReadOnly="True"
                                                                        SkinID="TextBoxReadOnly" Text='<%# Eval("BuildRebuild") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxCost" runat="server" __designer:wfdid="w89" SkinID="TextBox" Text='<%# Eval("Cost", "{0:f2}") %>' Visible='<%# Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]) %>' Width="130px"></asp:TextBox>                                                                            
                                                                </td>                                                                
                                                                <td>
                                                                    <asp:TextBox ID="tbxContractYear" runat="server" SkinID="TextBox" Text='<%# Eval("ContractYear") %>' Width="130px">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CompareValidator ID="cvCost" runat="server" ControlToValidate="tbxCost" Display="Dynamic"
                                                                        ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px" colspan="5">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <!-- Table element : 1 column - Jliner comments and history -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 690px">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:Label ID="lblComments" runat="server"  SkinID="Label"
                                                                            Text="Comments"></asp:Label>
                                                                    </td>
                                                                    <td align="right" style="width: 50%">
                                                                        <asp:Button ID="btnComments" runat="server" CommandName="Comments"
                                                                            SkinID="Button" Text="Edit" Width="80px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="height: 46px">
                                                                        <asp:TextBox ID="tbxComments" runat="server"  Height="100px"
                                                                            ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Comments") %>' TextMode="MultiLine"
                                                                            Width="100%">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:Label ID="lblHistory" runat="server" SkinID="Label" Text="History"></asp:Label>
                                                                    </td>
                                                                    <td align="right" colspan="1" style="width: 50%">
                                                                        <asp:Button ID="btnHistory" runat="server" CommandName="History" SkinID="Button"
                                                                            Text="Edit" Width="80px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="height: 46px">
                                                                        <asp:TextBox ID="tbxHistory" runat="server" Height="100px" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                                            Text='<%# Eval("History") %>' TextMode="MultiLine" Width="690px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:HiddenField ID="hdfAssetID" runat="server" Value='<%# Eval("AssetID") %>' />
                                                                        <asp:HiddenField ID="hdfWorkID" runat="server" Value='<%# Eval("WorkID") %>' />
                                                                        <asp:HiddenField ID="hdfSection_" runat="server" Value='<%# Eval("Section_") %>' />
                                                                        <asp:HiddenField ID="hdfSectionWorkID" runat="server" Value='<%# Eval("SectionWorkID") %>' />
                                                                        <asp:HiddenField ID="hdfLateralDescription" runat="server" Value='<%# Eval("LateralDescription") %>' />
                                                                    </td>
                                                                </tr>
                                                                <td colspan="2" style="height: 25px">
                                                                </td>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
        </table>
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <!-- Page element: Data objects -->
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsCoPitLocation" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkJunctionLiningCoPitLocationList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue=" " Name="name" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="abbreviation" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsFlange" runat="server" SelectMethod="LoadAndAddItem"
                        CacheDuration="120" EnableCaching="True" OldValuesParameterFormatString="original_{0}"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkJunctionLiningFlangeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="flange" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
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
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfBeforeUnloadOrigen" runat="server" />
                    <asp:HiddenField ID="hdfDataChanged" runat="server" />
                    <asp:HiddenField ID="hdfDataChangedMessage" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
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
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>