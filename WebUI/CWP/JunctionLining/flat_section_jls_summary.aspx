<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="flat_section_jls_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.flat_section_jls_summary" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Section Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                <td style="width: 10px;">                
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                                                          
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



<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
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



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 10px">
                </td>
                <td>
                    <asp:GridView ID="grdvJls" runat="server" AutoGenerateColumns="False" GridLines="None"
                        DataSourceID="odsFlatSectionJls" EnableViewState="False" PageSize="1" Width="100%" ShowHeader="False" DataKeyNames="WorkID">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <!-- Table element : 3 columns - Jliner row -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%"  class="Background_ViewGrid_Table">
                                        <tr>
                                            <td colspan="9" class="Background_ViewGrid_Header">
                                                <asp:Label ID="lblTitle" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Section - Junction Lining"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; vertical-align: middle; text-align: center;" class="Background_ViewGrid_Td">
                                                <asp:CheckBox ID="cbxSelected" runat="server" SkinID="CheckBox" Checked='<%# Eval("Selected") %>'/>
                                            </td>
                                            <td style="width: 12px" class="Background_ViewGrid_Td">
                                            </td>                                        
                                            <td style="width: 1px" class="ViewGrid_Separator">
                                            </td>
                                            <td style="width: 12px" class="Background_ViewGrid_Td">
                                            </td>
                                            <td style="width: 210px; vertical-align: top"class="Background_ViewGrid_Td">
                                                <!-- Table element : 2 columns - Fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
                                                    <tr>
                                                        <td style="width: 105px; height: 10px">
                                                        </td>
                                                        <td style="width: 105px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSectionId" runat="server" EnableViewState="False" SkinID="Label" Text="ID (Section)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOldCwpId" runat="server" EnableViewState="False" SkinID="Label" Text="Old CWP ID"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxFlowOrderId" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("FlowOrderID") %>' style="width: 95px">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxOldCwpId" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("OriginalSectionID") %>' Style="width: 95px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Street") %>' style="width: 200px">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="USMH"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="False" ReadOnly="True"
                                                                SkinID="TextBoxReadOnly" Text='<%# Eval("USMHID") %>' style="width: 95px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="False" ReadOnly="True"
                                                                SkinID="TextBoxReadOnly" Text='<%# Eval("DSMHID") %>' style="width: 95px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 25px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 12px" class="Background_ViewGrid_Td">
                                            </td>                                        
                                            <td style="width: 1px" class="ViewGrid_Separator">
                                            </td>
                                            <td style="width: 12px" class="Background_ViewGrid_Td">
                                            </td>
                                            <td style="width: 465px"class="Background_ViewGrid_Td">
                                                <!-- Table element : 4 columns - Fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
                                                    <tr>
                                                        <td style="width: 116px; height: 10px">
                                                        </td>
                                                        <td style="width: 116px">
                                                        </td>
                                                        <td style="width: 116px">
                                                        </td>
                                                        <td style="width: 117px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSubArea" runat="server" SkinID="Label" Text="Sub Area"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="LblSize_" runat="server" SkinID="Label" Text="Size"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLength" runat="server" SkinID="Label" Text="Length"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxSubArea" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("SubArea") %>' style="width: 222px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxSize_" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Size_") %>' style="width: 106px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxLength" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Length") %>' style="width: 106px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblTrafficControl" runat="server" SkinID="Label" Text="Traffic Control"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStandardBypass" runat="server" SkinID="Label" Text="Standard Bypass?"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxTrafficControl" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("TrafficControl") %>' style="width: 106px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="cbxStandardBypass" runat="server" onclick="return cbxClick();" SkinID="CheckBox" Checked='<%# Eval("StandardBypass") %>' />
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblTrafficControlDetails" runat="server" SkinID="Label" Text="Traffic Control Details"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblStandardBypassComments" runat="server" SkinID="Label" Text="Standard Bypass Comments"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxTrafficControlDetails" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 222px" Rows="2" TextMode="MultiLine" Text='<%# Eval("TrafficControlDetails") %>'></asp:TextBox>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxStandardBypassComments" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 222px" Rows="2" TextMode="MultiLine" Text='<%# Eval("StandardBypassComments") %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="height: 25px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <asp:HiddenField ID="hdfWorkID" runat="server" EnableViewState="false" Value='<%# Eval("WorkID") %>' />
                                                <asp:HiddenField ID="hdfAssetID" runat="server" EnableViewState="false" Value='<%# Eval("AssetID") %>' />
                                                <asp:HiddenField ID="hdfSectionID" runat="server" EnableViewState="false" Value='<%# Eval("SectionID") %>' />
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
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsFlatSectionJls" runat="server" SelectMethod="GetDataSet" TypeName="LiquiForce.LFSLive.DA.CWP.JunctionLining.FlatSectionJlsGateway">
                        <SelectParameters>
                            <asp:SessionParameter Name="flatSectionJlsTDS" SessionField="flatSectionJlsTDS" Type="Object" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
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
                </td>
            </tr>
        </table>
        <!-- Table element : Toolbar (Footer)-->
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
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                                                          
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
