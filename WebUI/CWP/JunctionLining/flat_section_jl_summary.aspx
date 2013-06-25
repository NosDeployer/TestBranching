<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="flat_section_jl_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.flat_section_jl_summary" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 750px;">
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
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" SkinID="ButtonPageTitle" EnableViewState="False" OnClick="btnChange_Click" />
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mBulkDateUpdate" Text="BULK FIELD UPDATE" />
                                                          
                            <telerik:RadMenuItem Value="mViewWorks" Text="WORKS">
                                <items>
                                    <telerik:RadMenuItem Value="mRehabAssessment" Text="REHAB ASSESSMENT" />
                                    <telerik:RadMenuItem Value="mFullLenghtLining" Text="FULL LENGTH LINING" />  
                                    <telerik:RadMenuItem Value="mPointRepairs" Text="POINT REPAIRS" />
                                </items>
                            </telerik:RadMenuItem>
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
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
                    <asp:GridView ID="grdvJl" runat="server" AutoGenerateColumns="False" GridLines="None"
                        PageSize="1" Width="100%" DataKeyNames="AssetID" DataSourceID="odsFlatSectionJl"
                        ShowHeader="False" OnRowDataBound="grdvJl_RowDataBound" EnableViewState="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <!-- Table element : 3 columns - Jliner row -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_ViewGrid_Table">
                                        <tr>
                                            <td colspan="5" class="Background_ViewGrid_Header" align="center">
                                                <asp:Label ID="lblTitle" runat="server" EnableViewState="False" SkinID="ViewGridHeader"
                                                    Text="Lateral - Junction Lining"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; vertical-align: middle; text-align: center;" class="Background_ViewGrid_Td">
                                                <asp:CheckBox ID="cbxSelected" runat="server" SkinID="CheckBox" Checked='<%# Eval("Selected") %>'
                                                    EnableViewState="False" />
                                            </td>
                                            <td style="width: 12px" class="Background_ViewGrid_Td">
                                            </td>
                                            <td style="width: 1px" class="ViewGrid_Separator">
                                            </td>
                                            <td style="width: 12px" class="Background_ViewGrid_Td">
                                            </td>
                                            <td class="Background_ViewGrid_Td">
                                                <!-- Table element : 5 columns - Jliner fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 700px">
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
                                                            <asp:Label ID="lblLateralId" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="ID"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblClientLateralId" runat="server" EnableViewState="false" SkinID="Label"
                                                                Text="Client Lateral ID"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblHamiltonInspectionNumber" runat="server" EnableViewState="False"
                                                                SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxLateralId" runat="server" SkinID="TextBoxReadOnly" Width="130px"
                                                                ReadOnly="True" Text='<%# Eval("LateralID") %>' EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxClientLateralId" runat="server" SkinID="TextBoxReadOnly" Width="130px"
                                                                Text='<%# Eval("ClientLateralID") %>' ReadOnly="true" EnableViewState="false">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxHamiltonInspectionNumber" runat="server" SkinID="TextBoxReadOnly"
                                                                Width="130px" Text='<%# Eval("HamiltonInspectionNumber") %>' ReadOnly="true"
                                                                EnableViewState="false">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxStreet" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                                Text='<%# Eval("Street") %>' Width="270px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblAddress" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="MN#"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueDigRequiredPriorToLining" runat="server" 
                                                                EnableViewState="False" SkinID="LabelSmall" Text="Dig Req'd Prior To Lining"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueDigRequiredPriorToLiningCompleted" runat="server" 
                                                                EnableViewState="False" SkinID="LabelSmall" 
                                                                Text="Dig Req'd Prior To Lining Completed"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueDigRequiredAfterLining" runat="server" 
                                                                EnableViewState="False" SkinID="LabelSmall" Text="Dig Req'd After Lining"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueDigRequiredAfterLiningCompleted" runat="server" 
                                                                EnableViewState="False" SkinID="LabelSmall" 
                                                                Text="Dig Req'd After Lining Completed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxAddress" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                                Text='<%# Eval("Address") %>' Width="130px" EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="cbxDigRequiredPriorToLining" runat="server" 
                                                                Checked='<%# Eval("DigRequiredPriorToLining") %>' EnableViewState="False" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDigRequiredPriorToLiningCompleted" runat="server" 
                                                                EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("DigRequiredPriorToLiningCompleted", "{0:d}")  %>' Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="cbxDigRequiredAfterLining" runat="server" 
                                                                Checked='<%# Eval("DigRequiredAfterLining") %>' EnableViewState="False" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDigRequiredAfterLiningCompleted" runat="server" 
                                                                EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("DigRequiredAfterLiningCompleted", "{0:d}") %>' Width="130px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblIssueOutOfScope" runat="server" EnableViewState="False" 
                                                                SkinID="LabelSmall" Text="Out Of Scope"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueHoldClienIssue" runat="server" EnableViewState="False" 
                                                                SkinID="LabelSmall" Text="Hold - Client Issue"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueHoldClienIssueResolved" runat="server" 
                                                                EnableViewState="False" SkinID="LabelSmall" Text="Hold - Client Issue Resolved"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueHoldLFSIssue" runat="server" EnableViewState="False" 
                                                                SkinID="LabelSmall" Text="Hold - LFS Issue"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueHoldLFSIssueResolved" runat="server" 
                                                                EnableViewState="False" SkinID="LabelSmall" Text="Hold - LFS Issue Resolved"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="cbxOutOfScope" runat="server" 
                                                                Checked='<%# Eval("OutOfScope") %>' EnableViewState="False" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="cbxHoldClienIssue" runat="server" 
                                                                Checked='<%# Eval("HoldClientIssue") %>' EnableViewState="False" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxHoldClienIssueResolved" runat="server" 
                                                                EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("HoldClientIssueResolved", "{0:d}") %>' Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="cbxLFSIssue" runat="server" 
                                                                Checked='<%# Eval("HoldLFSIssue") %>' EnableViewState="False" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxHoldLFSIssueResolved" runat="server" 
                                                                EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("HoldLFSIssueResolved", "{0:d}") %>' Width="130px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRequiresRoboticPrep" runat="server" EnableViewState="False" 
                                                                SkinID="LabelSmall" Text="Requires Robotic Prep"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblIssueRequiresRoboticPrepCompleted" runat="server" 
                                                                EnableViewState="False" SkinID="LabelSmall" 
                                                                Text="Requires Robotic Prep Completed"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUSMH" runat="server" EnableViewState="false" SkinID="Label" 
                                                                Text="USMH"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDSMH" runat="server" EnableViewState="false" SkinID="Label" 
                                                                Text="DSMH"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblVideoInspection" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="V1 Inspection"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="cbxRequiresRoboticPrep" runat="server" 
                                                                Checked='<%# Eval("LateralRequiresRoboticPrep") %>' EnableViewState="False" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxRequiresRoboticPrepCompleted" runat="server" 
                                                                EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("LateralRequiresRoboticPrepCompleted", "{0:d}") %>' 
                                                                Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="False" 
                                                                ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("USMHDescription") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="False" 
                                                                ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("DSMHDescription") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxVideoInspection" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("VideoInspection", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblVideoLengthToPropertyLine" runat="server" 
                                                                EnableViewState="false" SkinID="Label" Text="Video Length To PL"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDepthOfLocated" runat="server" SkinID="Label" 
                                                                Text="Depth Of Pipe"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPipeLocated" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Pipe Located"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblServicesLocated" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Services Located"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPrepType" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Prep Type"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxVideoLengthToPropertyLine" runat="server" 
                                                                EnableViewState="false" ReadOnly="true" SkinID="Textboxreadonly" 
                                                                Text='<%# GetDistance(Eval("VideoLengthToPropertyLine")) %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDepthOfLocated" runat="server" EnableViewState="false" 
                                                                ReadOnly="true" SkinID="TextBoxReadOnly" 
                                                                Text='<%# GetDistance(Eval("DepthOfLocated")) %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxPipeLocated" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("PipeLocated", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxServicesLocated" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("ServicesLocated", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxPrepType" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("PrepType") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCoPitLocation" runat="server" EnableViewState="false" 
                                                                SkinID="Label" Text="CO/Pit Location"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCoInstalled" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="C/O Installed"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBackfilledConcrete" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Backfilled Concrete"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBackfilledSoil" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Backfilled Soil"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblGrouted" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Grouted"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxCoPitLocation" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("CoPitLocation") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxCoInstalled" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("CoInstalled", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxBackfilledConcrete" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("BackfilledConcrete", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxBackfilledSoil" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("BackfilledSoil", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxGrouted" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Grouted", "{0:d}") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCored" runat="server" EnableViewState="False" SkinID="Label" 
                                                                Text="Cored"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPrepped" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Prepped"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPreVideo" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Pre-Video"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMeasured" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Measured"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblConnectionType" runat="server" EnableViewState="false" 
                                                                SkinID="Label" Text="Connection Type"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxCored" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Cored", "{0:d}") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxPrepped" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Prepped", "{0:d}") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxPreVideo" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("PreVideo", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxMeasured" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("Measured", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxConnectionType" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ConnectionType") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblLinerType" runat="server" EnableViewState="false" 
                                                                SkinID="Label" Text="Liner Type"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblFlange" runat="server" EnableViewState="false" SkinID="Label" 
                                                                Text="Flange"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblGasket" runat="server" EnableViewState="false" SkinID="Label" 
                                                                Text="Gasket"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblMainSize" runat="server" EnableViewState="false" 
                                                                SkinID="Label" Text="Main size"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLinerSize" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Liner Size"></asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxLinerType" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("LinerType") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxFlange" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Flange") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxGasket" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Gasket") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxMainSize" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("MainSize") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxLinerSize" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("LinerSize") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblNoticeDelivered" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Notice Delivered"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInProcess" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Liner In Process"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInStock" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Liner In Stock"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDelivered" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Liner Delivered"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLinerInstalled" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Liner Installed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxNoticeDelivered" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("NoticeDelivered", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInProcess" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("InProcess", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInStock" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("InStock", "{0:d}") %>' 
                                                                Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDelivered" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("Delivered", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxLinerInstalled" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("LinerInstalled", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblFinalVideo" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Final Video"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDistanceFromUSMH" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Dist. From USMH"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDistanceFromDSMH" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Dist. From DSMH"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCoCutDown" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="C/O Cut Down?"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblFinalRestoration" runat="server" EnableViewState="false" 
                                                                SkinID="Label" Text="Final Restoration"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxFinalVideo" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("FinalVideo", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDistanceFromUSMH" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# GetDistance(Eval("DistanceFromUSMH")) %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDistanceFromDSMH" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# GetDistance(Eval("DistanceFromDSMH")) %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxCoCutDown" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("CoCutDown", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxFinalRestoration" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" 
                                                                Text='<%# Eval("FinalRestoration", "{0:d}") %>' Width="130px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>                                                        
                                                        <td>
                                                             <asp:Label ID="lblDyeTestReq" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Dye Test Req'd"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDyeTestComplete" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Dye Test Complete"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBuildRebuild" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Build / Rebuild #"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCost" runat="server" EnableViewState="False" SkinID="Label" Text="Cost" 
                                                                Visible='<%# Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]) %>'></asp:Label>
                                                        </td>                                                       
                                                        <td>
                                                            <asp:Label ID="lblContractYear" runat="server" EnableViewState="False" 
                                                                SkinID="Label" Text="Contract Year"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>                                                        
                                                        <td>
                                                             <asp:CheckBox ID="ckbxDyeTestRepar" runat="server" 
                                                                Checked='<%# Eval("DyeTestReq") %>' EnableViewState="False" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDyeTestComplete" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("DyeTestComplete", "{0:d}") %>' 
                                                                Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxBuildRebuild" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("BuildRebuild") %>' 
                                                                Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxCost" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Cost", "{0:f2}") %>' 
                                                                Visible='<%# Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]) %>' 
                                                                Width="130px">                                                                
                                                            </asp:TextBox>
                                                        </td>                                                        
                                                        <td>
                                                            <asp:TextBox ID="tbxContractYear" runat="server" EnableViewState="False" 
                                                                ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ContractYear") %>' 
                                                                Width="130px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="5">
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                                <!-- Table element : 2 columns - Jliner comments and history -->
                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 690px">
                                                    <tr>
                                                        <td style="width: 50%">
                                                            <asp:Label ID="Label2" runat="server" EnableViewState="False" SkinID="Label" Text="Comments"></asp:Label>
                                                        </td>
                                                        <td align="right" style="width: 50%">
                                                            <asp:Button ID="btnComments" runat="server" SkinID="Button" Text="Edit" Width="80px"
                                                                EnableViewState="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxComments" runat="server" Height="100px" SkinID="TextBoxReadOnly"
                                                                TextMode="MultiLine" Width="690px" Text='<%# Eval("Comments") %>' ReadOnly="True"
                                                                EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50%;">
                                                            <asp:Label ID="lblHistory" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="History"></asp:Label>
                                                        </td>
                                                        <td align="right" colspan="1" style="width: 50%">
                                                            <asp:Button ID="btnHistory" runat="server" SkinID="Button" Text="Edit" Width="80px"
                                                                EnableViewState="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 46px">
                                                            <asp:TextBox ID="tbxHistory" runat="server" Height="100px" SkinID="TextBoxReadOnly"
                                                                TextMode="MultiLine" Width="690px" Text='<%# Eval("History") %>' ReadOnly="True"
                                                                EnableViewState="False">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:HiddenField ID="hdfAssetID" runat="server" EnableViewState="false" Value='<%# Eval("AssetID") %>' />
                                                            <asp:HiddenField ID="hdfWorkID" runat="server" EnableViewState="false" Value='<%# Eval("WorkID") %>' />
                                                            <asp:HiddenField ID="hdfSection_" runat="server" Value='<%# Eval("Section_") %>' />
                                                            <asp:HiddenField ID="hdfLateralDescription" runat="server" EnableViewState="false" Value='<%# Eval("LateralDescription") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="2">
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Table element : Space inter rows -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsFlatSectionJl" runat="server" SelectMethod="GetDataSet"
                        TypeName="LiquiForce.LFSLive.DA.CWP.JunctionLining.FlatSectionJlGateway">
                        <SelectParameters>
                            <asp:SessionParameter Name="flatSectionJlTDS" SessionField="flatSectionJlTDS" Type="Object" />
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
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
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
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mBulkDateUpdate" Text="BULK FIELD UPDATE" />
                                                          
                            <telerik:RadMenuItem Value="mViewWorks" Text="WORKS">
                                <items>
                                    <telerik:RadMenuItem Value="mRehabAssessment" Text="REHAB ASSESSMENT" />
                                    <telerik:RadMenuItem Value="mFullLenghtLining" Text="FULL LENGTH LINING" />  
                                    <telerik:RadMenuItem Value="mPointRepairs" Text="POINT REPAIRS" />
                                </items>
                            </telerik:RadMenuItem>
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>