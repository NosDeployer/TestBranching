<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" CodeBehind="jl_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.jl_navigator" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Junction Lining" SkinID="LabelPageTitle1"></asp:Label>
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
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search Junction Lining" Selected="true" PostBack="false" ></telerik:RadPanelItem>
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



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Section title - Search & Sort-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblColumnsToDisplay" runat="server" SkinID="LabelTitle1" Text="Search & Sort" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Columns to display-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxId" onclick="return cbxClick();" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="ID" EnableViewState="False" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxOldCwpId" runat="server" SkinID="CheckBoxSmall" Text="Old CWP ID" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxClientLateralId" runat="server" SkinID="CheckBoxSmall" Text="Client Lateral ID" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxHamiltonInspectionNumber" runat="server" SkinID="CheckBoxSmall" Text="Client Insp.#" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxStreet" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="Street" EnableViewState="False" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxAddress" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="MN#" EnableViewState="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxUSMH" runat="server" SkinID="CheckBoxSmall" Text="USMH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDSMH" runat="server" SkinID="CheckBoxSmall" Text="DSMH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxVideoInspection" runat="server" SkinID="CheckBoxSmall" Text="V1 Inspection" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxVideoLengthToPropertyLine" runat="server" SkinID="CheckBoxSmall" Text="Video Length To PL" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDepthOfLocated" runat="server" SkinID="CheckBoxSmall" Text="Depth Of Pipe" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxPipeLocated" runat="server" SkinID="CheckBoxSmall" Text="Pipe Located" EnableViewState="False" />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxServicesLocated" runat="server" SkinID="CheckBoxSmall" Text="Services Located" EnableViewState="False" />
                </td>
                <%--<td>
                    <asp:CheckBox ID="cbxCoRequired" runat="server" SkinID="CheckBoxSmall" Text="C/O Req." EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxPitRequired" runat="server" SkinID="CheckBoxSmall" Text="Pit Req." EnableViewState="False" />
                </td>--%>
                <td>
                     <asp:CheckBox ID="cbxPrepType" runat="server" SkinID="CheckBoxSmall" Text="Prep Type" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCoPitLocation" runat="server" SkinID="CheckBoxSmall" Text="CO/Pit Location" EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCoInstalled" runat="server" SkinID="CheckBoxSmall" Text="C/O Installed" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxBackfilledConcrete" runat="server" SkinID="CheckBoxSmall" Text="Backfilled Con." EnableViewState="False" />
                </td> 
                <td>
                    <asp:CheckBox ID="cbxBackfilledSoil" runat="server" SkinID="CheckBoxSmall" Text="Backfilled Soil" EnableViewState="False" />
                </td>               
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxGrouted" runat="server" SkinID="CheckBoxSmall" Text="Grouted" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCored" runat="server" SkinID="CheckBoxSmall" Text="Cored" EnableViewState="False" />
                </td>          
                <td>
                    <asp:CheckBox ID="cbxPrepped" runat="server" SkinID="CheckBoxSmall" Text="Prepped" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxPreVideo" runat="server" SkinID="CheckBoxSmall" Text="Pre-Video" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMeasured" runat="server" SkinID="CheckBoxSmall" Text="Measured" EnableViewState="False" />
                </td> 
                <td>
                    <asp:CheckBox ID="cbxConnectionType" runat="server" SkinID="CheckBoxSmall" Text="Connection Type" EnableViewState="false" />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxLinerType" runat="server" SkinID="CheckBoxSmall" Text="Liner Type" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxFlange" runat="server" SkinID="CheckBoxSmall" Text="Flange" EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxGasket" runat="server" SkinID="CheckBoxSmall" Text="Gasket" EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMainSize" runat="server" SkinID="CheckBoxSmall" Text="Main Size" EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxLinerSize" runat="server" SkinID="CheckBoxSmall" Text="Liner Size" EnableViewState="false" />
                </td>
                <%--<td>
                    <asp:CheckBox ID="cbxLiningThruCo" runat="server" SkinID="CheckBoxSmall" Text="Lining Thru C/O" EnableViewState="false" />
                </td>   --%>   
                 <td>
                    <asp:CheckBox ID="cbxNoticeDelivered" runat="server" SkinID="CheckBoxSmall" Text="Notice Delivered" EnableViewState="False" />
                </td>                          
            </tr>
            <tr>               
                <td>
                    <asp:CheckBox ID="cbxInProcess" runat="server" SkinID="CheckBoxSmall" Text="In Process" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxInStock" runat="server" SkinID="CheckBoxSmall" Text="In Stock" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDelivered" runat="server" SkinID="CheckBoxSmall" Text="Delivered" EnableViewState="False" />
                </td> 
                <td>
                    <asp:CheckBox ID="cbxLinerInstalled" runat="server" SkinID="CheckBoxSmall" Text="Liner Installed" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxFinalVideo" runat="server" SkinID="CheckBoxSmall" Text="Final Video" EnableViewState="False" />
                </td> 
                <td>
                    <asp:CheckBox ID="cbxDistanceFromUSMH" runat="server" SkinID="CheckBoxSmall" Text="Dist. From USMH" EnableViewState="false" />
                </td>                                                               
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxDistanceFromDSMH" runat="server" SkinID="CheckBoxSmall" Text="Dist. From DSMH" EnableViewState="false" />
                </td>
                <%--<td>
                    <asp:CheckBox ID="cbxPostContractDigRequired" runat="server" SkinID="CheckBoxSmall" Text="Post Contract Dig?" EnableViewState="false" />
                </td>--%>
                <td>
                    <asp:CheckBox ID="cbxCoCutDown" runat="server" SkinID="CheckBoxSmall" Text="C/O Cut Down?" EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxFinalRestoration" runat="server" SkinID="CheckBoxSmall" Text="Final Restoration" EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCost" runat="server" SkinID="CheckBoxSmall" Text="Cost" EnableViewState="false" />
                </td>  
                <td>
                    <asp:CheckBox ID="cbxBuidRebuid" runat="server" SkinID="CheckBoxSmall" Text="Build / Rebuild #" EnableViewState="false" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxComments" runat="server" SkinID="CheckBoxSmall" Text="Comments" EnableViewState="False" />
                </td>                           
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxHistory" runat="server" SkinID="CheckBoxSmall" Text="History" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDigRequiredPriorToLining" runat="server" SkinID="CheckBoxSmall" Text="Dig Req'd Prior To Lining" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDigRequiredPriorToLiningCompleted" runat="server" SkinID="CheckBoxSmall" Text="Dig Req'd Prior To Lining Completed" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDigRequiredAfterLining" runat="server" SkinID="CheckBoxSmall" Text="Dig Req'd After Lining " EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDigRequiredAfterLiningCompleted" runat="server" SkinID="CheckBoxSmall" Text="Dig Req'd After Lining Completed" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxOutOfScope" runat="server" SkinID="CheckBoxSmall" Text="Out Of Scope" EnableViewState="False" />
                </td> 
            </tr>
            <tr>                           
                <td>
                    <asp:CheckBox ID="cbxHoldClientIssue" runat="server" SkinID="CheckBoxSmall" Text="Hold - Client Issue " EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxHoldClientIssueResolved" runat="server" SkinID="CheckBoxSmall" Text="Hold - Client Issue Resolved" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxHoldLFSIssue" runat="server" SkinID="CheckBoxSmall" Text="Hold - LFS Issue" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxHoldLFSIssueResolved" runat="server" SkinID="CheckBoxSmall" Text="Hold - LFS Issue Resolved" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxRequiresRoboticPrep" runat="server" SkinID="CheckBoxSmall" Text="Requires Robotic Prep" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxRequiresRoboticPrepCompleted" runat="server" SkinID="CheckBoxSmall" Text="Requires Robotic Prep Completed" EnableViewState="False" />
                </td>
            </tr>
            <tr>                           
                <td>
                    <asp:CheckBox ID="cbxDyeTestReq" runat="server" SkinID="CheckBoxSmall" Text="Dye Test Req'd" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDyeTestComplete" runat="server" SkinID="CheckBoxSmall" Text="Dye Test Complete" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxContractYear" runat="server" SkinID="CheckBoxSmall" Text="Contract Year" EnableViewState="False" />
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="6" height="7px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Search & Sort components , 6 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="lblCondition1" runat="server" EnableViewState="False" SkinID="Label" Text="Condition 1"></asp:Label>
                    </td>
                    <td style="width: 180px">
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 125px">
                    </td>
                    <td style="width: 125px">
                    </td>
                    <td style="width: 128px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 115px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOperator1" runat="server" EnableViewState="False" SkinID="DropDownList" Width="170px">
                            <asp:ListItem Value="=" Text="equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;&gt;" Text="not"></asp:ListItem>
                            <asp:ListItem Value="&gt;" Text="greater than"></asp:ListItem>
                            <asp:ListItem Value="'&gt;='" Text="greater than &amp; equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;" Text="less than"></asp:ListItem>
                            <asp:ListItem Value="'&lt;='" Text="less than &amp; equals to"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 435px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvInvalidOperator" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator. (use "equals to" or "not")'
                            OnServerValidate="cvInvalidOperator_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvInvalidOperatorForBoolean" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator. (use "equals to")'
                            OnServerValidate="cvInvalidOperatorForBoolean_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td colspan="4">
                        <asp:CustomValidator ID="cvForDate" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" 
                            OnServerValidate="cvForDateRange_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForBoolean" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use Y, YES, N, NO, % or leave the field empty)"
                            OnServerValidate="cvForBoolean_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForNumberCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use an integer number, % or leave the field empty)" 
                            OnServerValidate="cvForNumberCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForMoneyCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid data. (use #.## format)" 
                            OnServerValidate="cvForMoneyCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
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
                    <td style="width: 128px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCondition2" runat="server" EnableViewState="False" SkinID="Label" Text="And Condition 2"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="width: 128px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition2" runat="server" SkinID="DropDownList" Style="width: 115px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList2" DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOperator2" runat="server" EnableViewState="False" SkinID="DropDownList" Width="170px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="=" Text="equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;&gt;" Text="not"></asp:ListItem>
                            <asp:ListItem Value="&gt;" Text="greater than"></asp:ListItem>
                            <asp:ListItem Value="'&gt;='" Text="greater than &amp; equals to"></asp:ListItem>
                            <asp:ListItem Value="&lt;" Text="less than"></asp:ListItem>
                            <asp:ListItem Value="'&lt;='" Text="less than &amp; equals to"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="tbxCondition2" runat="server" Style="width: 435px" SkinID="TextBox" EnableViewState="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvDeleteOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" EnableViewState="False" ErrorMessage="Please delete the operator."
                            OnServerValidate="cvDeleteOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvInvalidOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator. (use "equals to" or "not")'
                            OnServerValidate="cvInvalidOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvSelectOperator2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" EnableViewState="False" ErrorMessage="Please select an operator." 
                            OnServerValidate="cvSelectOperator2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvInvalidOperatorForBoolean2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" EnableViewState="False" ErrorMessage='Invalid operator. (use "equals to")'
                            OnServerValidate="cvInvalidOperatorForBoolean2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td colspan="4">
                        <asp:CustomValidator ID="cvForDate2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)"
                            OnServerValidate="cvForDate2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForDateRange2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" 
                            OnServerValidate="cvForDateRange2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForBoolean2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data. (use Y, YES, N, NO, % or leave the field empty)"
                            OnServerValidate="cvForBoolean2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForNumberCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic"
                            EnableViewState="False" ErrorMessage="Invalid data. (use an integer number, % or leave the field empty)" 
                            OnServerValidate="cvForNumberCondition2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                        <asp:CustomValidator ID="cvForMoneyCondition2" runat="server" ControlToValidate="tbxCondition2" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data. (use #.## format)" 
                            OnServerValidate="cvForMoneyCondition2_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
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
                    <td style="width: 128px">
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 180px">
                        <asp:Label ID="lblSubArea" runat="server" EnableViewState="false" SkinID="Label" Text="Sub Area"></asp:Label>
                    </td>
                    <td style="width: 125px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                    </td>
                    <td style="width: 125px">
                    </td>
                    <td style="width: 97.5px">
                    </td>
                    <td style="width: 97.5px">
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSubArea" runat="server" SkinID="DropDownList" Width="170px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" DataMember="DefaultView" 
                            DataSourceID="odsSortByList" DataTextField="Name" DataValueField="SortID" 
                            EnableViewState="False" SkinID="DropDownList" Style="width: 115px">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px" OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>                
                <tr>
                    <td style="height: 15px">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: center">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <asp:Panel ID="pnlDefaultViewSearch" runat="server" Width="100%" DefaultButton="btnGo">       
            <!-- Page element: Section title - Views-->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="lblViewTitle" runat="server" SkinID="LabelTitle1" Text="Views" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
            </table>   
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblView" runat="server" SkinID="Label" Text="View" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 70px;">
                    </td>
                    <td colspan="3" style="width: 125px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:DropDownList style="width: 540px" id="ddlView" runat="server" SkinID="DropDownListLookup">
                        </asp:DropDownList> 
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60px" class="Background_SearchAndSort">
                            <tr>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button  ID="btnViewAdd" runat="server" style="width: 16px; height:16px" ToolTip="Add View" OnClientClick="return btnViewAddClick();" EnableViewState="False" SkinID="ViewAddButton" />
                                </td>
                                <td style="width: 7.5px">
                                </td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewEdit" runat="server" style="width: 16px; height:16px" ToolTip="Edit View" OnClientClick="return btnViewEditClick();" EnableViewState="False" SkinID="ViewEditButton" />
                                </td>
                                <td style="width: 7.5px">
                                </td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewDelete" runat="server" style="width: 16px; height:16px" ToolTip="Delete View" OnClientClick="return btnViewDeleteClick();" EnableViewState="False" OnClick="btnViewDelete_Click" SkinID="ViewDeleteButton" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="text-align: center">
                         <asp:Button ID="btnGo" runat="server" SkinID="Button" Text="Go" Style="width: 80px" EnableViewState="False" OnClick="btnGo_Click" OnClientClick="return btnGoClick();" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
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
        <!-- Page element : No results bar -->
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
            <tr>
                <td>
                    <asp:Label ID="lblNoResults" runat="server" Text="No results for your query"></asp:Label>
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
                    <asp:HiddenField ID="hdfSelectedViewId" runat="server" />
                    <asp:HiddenField ID="hdfBtnOrigin" runat="server" />
                </td>
            </tr>
        </table>
        
        
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                    
                    <asp:ObjectDataSource ID="odsViewForDisplayList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewConditionList">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="workType" QueryStringField="work_type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsViewForDisplayList2" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewConditionList">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="workType" QueryStringField="work_type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                            <asp:Parameter Name="conditionId" Type="Int32" DefaultValue="-1" />
                            <asp:Parameter Name="name" Type="String" DefaultValue="" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewSortList">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="workType" QueryStringField="work_type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>