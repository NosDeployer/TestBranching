<%@ Page Language="C#" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" CodeBehind="pr_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_navigator2" Title="LFS Live" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Point Repairs" SkinID="LabelPageTitle1"></asp:Label>
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



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Point Repairs" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mPointRepairsPlan" Text="Lining Plan"></telerik:RadPanelItem>
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



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Search &  Sort Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td>
                    <asp:Label ID="lblSearchAndSort" runat="server" SkinID="LabelTitle1" Text="Search & Sort" EnableViewState="False">
                    </asp:Label>
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
                    <asp:CheckBox ID="cbxIdSection" onclick="return cbxClick();" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="ID (Section)" EnableViewState="False" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxIdRepair" runat="server" SkinID="CheckBoxSmall" Text="ID (Repair)" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxSubArea" runat="server" SkinID="CheckBoxSmall" Text="Sub Area" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxStreet" runat="server" SkinID="CheckBoxSmall" Checked="True" Text="Street" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxUsmh" runat="server" SkinID="CheckBoxSmall" Checked="True" Text="USMH" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxUsmhAddress" runat="server" SkinID="CheckBoxSmall" Text="USMH Address" EnableViewState="False" />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxDsmh" runat="server" Checked="True" SkinID="CheckBoxSmall" Text="DSMH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDsmhAddress" runat="server" SkinID="CheckBoxSmall" Text="DSMH Address" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMapSize" runat="server" SkinID="CheckBoxSmall" Text="Map Size" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxConfirmedSize" runat="server" SkinID="CheckBoxSmall" Text="Confirmed Size" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMapLength" runat="server" SkinID="CheckBoxSmall" Text="Map Length" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxSteelTapeLength" runat="server" SkinID="CheckBoxSmall" Text="Steel Tape Length" EnableViewState="False" />
                </td>                               
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxVideoLength" runat="server" SkinID="CheckBoxSmall" Text="Video Length" EnableViewState="False" />
                </td> 
                <td>
                    <asp:CheckBox ID="cbxLaterals" runat="server" SkinID="CheckBoxSmall" Text="Laterals" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxLiveLaterals" runat="server" SkinID="CheckBoxSmall" Text="Live Laterals" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxClientId" runat="server" SkinID="CheckBoxSmall" Text="Client ID" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMeasurementsTakenBy" runat="server" SkinID="CheckBoxSmall" Text="Measurements Taken By" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxPreFlushDate" runat="server" SkinID="CheckBoxSmall" Text="Pre-Flush Date" EnableViewState="False" />
                </td>
                                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxPreVideoDate" runat="server" SkinID="CheckBoxSmall" Text="Pre-Video Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxP1Date" runat="server" SkinID="CheckBoxSmall" Text="P1 Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxRepairConfirmationDate" runat="server" SkinID="CheckBoxSmall" Text="Repair Confirmation Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxTrafficControl" runat="server" SkinID="CheckBoxSmall" Text="Traffic Control" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMaterial" runat="server" SkinID="CheckBoxSmall" Text="Material" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxBypassRequired" runat="server" SkinID="CheckBoxSmall" Text="Bypass Required?" EnableViewState="False" />
                </td>
                                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxRoboticPrepRequired" runat="server" SkinID="CheckBoxSmall" Text="Robotic Prep Required?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCXIsRemoved" runat="server" SkinID="CheckBoxSmall" Text="CXI's Removed" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxRoboticDistances" runat="server" SkinID="CheckBoxSmall" Text="Robotic Distances" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxProposedLiningDate" runat="server" SkinID="CheckBoxSmall" Text="Proposed Lining Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDeadlineLiningDate" runat="server" SkinID="CheckBoxSmall" Text="Deadline Lining Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxGroutDate" runat="server" SkinID="CheckBoxSmall" Text="Grout Date" EnableViewState="False" />
                </td>
                                
            </tr>
            <tr>
                <td>                    
                    <asp:CheckBox ID="cbxFinalVideo" runat="server" SkinID="CheckBoxSmall" Text="Final Video" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxEstimatedJoints" runat="server" SkinID="CheckBoxSmall" Text="Estimated Joints" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxJointsTestSealed" runat="server" SkinID="CheckBoxSmall" Text="Joints Test Sealed" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxIssueIdentified" runat="server" SkinID="CheckBoxSmall" Text="Issue Identified?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxLFSIssue" runat="server" SkinID="CheckBoxSmall" Text="LFS Issue?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxClientIssue" runat="server" SkinID="CheckBoxSmall" Text="Client Issue?" EnableViewState="False" />
                </td>                
            </tr>
            <tr>
                <td>                    
                    <asp:CheckBox ID="cbxSalesIssue" runat="server" SkinID="CheckBoxSmall" Text="Sales Issue?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxIssueGivenToClient" runat="server" SkinID="CheckBoxSmall" Text="Issue Given To Client?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxIssueInvestigation" runat="server" SkinID="CheckBoxSmall" Text="Issue Investigation?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxIssueResolved" runat="server" SkinID="CheckBoxSmall" Text="Issue Resolved?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxComments" runat="server" SkinID="CheckBoxSmall" Text="Comments" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxRepairType" runat="server" SkinID="CheckBoxSmall" Text="Repair Type" EnableViewState="False"  />
                </td>                
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxDefectQualifier" runat="server" SkinID="CheckBoxSmall" Text="Defect Qualifier" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDefectDetails" runat="server" SkinID="CheckBoxSmall" Text="Defect Details" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxExtraRepair" runat="server" SkinID="CheckBoxSmall" Text="Extra Repair" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCancelled" runat="server" SkinID="CheckBoxSmall" Text="Cancelled" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxApproval" runat="server" SkinID="CheckBoxSmall" Text="Approval" EnableViewState="False" />
                </td>  
                <td>                    
                    <asp:CheckBox ID="cbxRepairComments" runat="server" SkinID="CheckBoxSmall" Text="Repair Comments" EnableViewState="False" />
                </td>              
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxReamDistance" runat="server" SkinID="CheckBoxSmall" Text="Ream Distance" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxReamDate" runat="server" SkinID="CheckBoxSmall" Text="ReamDate" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxLinerDistance" runat="server" SkinID="CheckBoxSmall" Text="Liner Distance" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDirection" runat="server" SkinID="CheckBoxSmall" Text="Direction" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxReinstates" runat="server" SkinID="CheckBoxSmall" Text="Reinstates" EnableViewState="False" />
                </td> 
                <td>                    
                    <asp:CheckBox ID="cbxLtMh" runat="server" SkinID="CheckBoxSmall" Text="LT @ MH" EnableViewState="False" />
                </td>               
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxVtMh" runat="server" SkinID="CheckBoxSmall" Text="VT @ MH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDistance" runat="server" SkinID="CheckBoxSmall" Text="Distance" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxRepairSize" runat="server" SkinID="CheckBoxSmall" Text="Repair Size" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxRepairLength" runat="server" SkinID="CheckBoxSmall" Text="Repair Length" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxInstallDate" runat="server" SkinID="CheckBoxSmall" Text="Install Date" EnableViewState="False" />
                </td>  
                <td>                    
                    <asp:CheckBox ID="cbxMhShot" runat="server" SkinID="CheckBoxSmall" Text="MH Shot?" EnableViewState="False" />
                </td>              
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxGroutDistance" runat="server" SkinID="CheckBoxSmall" Text="Grout Distance" EnableViewState="False" />
                </td>
                <td> </td>
                <td></td>
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
                    <td style="width: 155px">
                        <asp:Label ID="lblCondition1" runat="server" EnableViewState="False" SkinID="Label" Text="Condition 1"></asp:Label>
                    </td>
                    <td style="width: 180px">
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 115px">
                    </td>
                    <td style="width: 115px">
                    </td>
                    <td style="width: 115px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 145px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
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
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 405px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
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
                    <td>
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
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition2" runat="server" SkinID="DropDownList" Style="width: 145px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList2" DataTextField="Name" DataValueField="ConditionID">
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
                        <asp:TextBox ID="tbxCondition2" runat="server" Style="width: 405px" SkinID="TextBox" EnableViewState="False"></asp:TextBox>
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
                    <td>
                    </td>
                </tr>
            </table>
                                   
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 155px">
                        <asp:Label ID="lblSubArea" runat="server" EnableViewState="false" SkinID="Label" Text="Sub Area"></asp:Label>
                    </td>
                    <td style="width: 180px">
                        <asp:Label ID="lblSortBy" runat="server" EnableViewState="False" SkinID="Label" Text="Sort By"></asp:Label>
                     </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 115px">
                    </td>
                    <td style="width: 105px">
                    </td>
                    
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSubArea" runat="server" SkinID="DropDownList" Width="145px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSortBy" runat="server" SkinID="DropDownList" Style="width: 170px" EnableViewState="False" DataSourceID="odsSortByList" DataTextField="Name" DataValueField="SortID">
                        </asp:DropDownList>
                    </td>
                    <td colspan="3">
                    </td>                    
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px" OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px"> 
                    </td>
                    <td>                        
                    </td>
                    <td>
                    </td>
                    <td>
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
                    <td>
                        <asp:Label ID="lblView" runat="server" SkinID="Label" Text="View" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlView" runat="server" SkinID="DropDownListLookup" Style="width: 540px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60px" class="Background_SearchAndSort">
                            <tr>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button  ID="btnViewAdd" runat="server" style="width: 16px; height:16px" ToolTip="Add View" OnClientClick="return btnViewAddClick();" EnableViewState="False" SkinID="ViewAddButton" />
                                </td>
                                <td style="width: 6px">
                                </td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewEdit" runat="server" style="width: 16px; height:16px" ToolTip="Edit View" OnClientClick="return btnViewEditClick();" EnableViewState="False" SkinID="ViewEditButton" />
                                </td>
                                <td style="width: 6px">
                                </td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewDelete" runat="server" style="width: 16px; height:16px" ToolTip="Delete View" OnClientClick="return btnViewDeleteClick();" EnableViewState="False" OnClick="btnViewDelete_Click" SkinID="ViewDeleteButton" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style=" text-align: center">
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
        
       <!-- Page element: Section title - Results-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one section." Display="Dynamic" SkinID="Validator">
                    </asp:CustomValidator>
                </td>
                <td style="width: 125px">
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
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label" Text="Total Rows"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <div runat="server" id="dvGrid" style="overflow-x:auto; overflow-y:hidden; Width:625px">
                    <asp:GridView ID="grdPrNavigator" runat="server" AutoGenerateColumns="False" DataKeyNames="AssetID" SkinID="GridView" AllowSorting="True" OnSorting="grdPrNavigator_Sorting">
                        <Columns>
                        
                            <%--Column 0--%>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server" 
                                        Checked='<%# Bind("Selected") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 1--%>
                            <asp:TemplateField HeaderText="AssetID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssetID_" runat="server" Style="width: 100px" Text='<%# Bind("AssetID_") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 2--%>
                            <asp:TemplateField HeaderText="ID (Section)" SortExpression="FlowOrderID">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblFlowOrderID" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 3--%>
                            <asp:TemplateField HeaderText="Sub Area" SortExpression="SubArea">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubArea" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("SubArea") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 4--%>
                            <asp:TemplateField HeaderText="Street" SortExpression="Street">
                                <ItemTemplate>
                                    <asp:Label ID="lblStreet" runat="server" Width="200px" Style="width: 200px" Text='<%# Bind("Street") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 5--%>
                            <asp:TemplateField HeaderText="USMH" SortExpression="USMHDescription">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblUSMH" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("USMHDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 6--%>
                            <asp:TemplateField HeaderText="USMH Address" SortExpression="USMHDAddress">
                                <ItemTemplate>
                                    <asp:Label ID="lblUSMHAddress" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("USMHAddress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 7--%>
                            <asp:TemplateField HeaderText="DSMH" SortExpression="DSMHDescription">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblDSMH" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("DSMHDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 8--%>
                            <asp:TemplateField HeaderText="DSMH Address" SortExpression="DSMHAddress">
                                <ItemTemplate>
                                    <asp:Label ID="lblDSMHAddress" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("DSMHAddress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 9--%>
                            <asp:TemplateField HeaderText="Map Size" SortExpression="MapSize">
                                <ItemTemplate>
                                    <asp:Label ID="lblMapSize" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("MapSize") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 10--%>
                            <asp:TemplateField HeaderText="Confirmed Size" SortExpression="Size_">
                                <ItemTemplate>
                                    <asp:Label ID="lblSize_" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("Size_") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 11--%>
                            <asp:TemplateField HeaderText="Map Length" SortExpression="">
                                <ItemTemplate>
                                    <asp:Label ID="lblMapLength" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("MapLength") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 12--%>
                            <asp:TemplateField HeaderText="Steel Tape Length" SortExpression="Length">
                                <ItemTemplate>
                                    <asp:Label ID="lblLength" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("Length") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 13--%>
                            <asp:TemplateField HeaderText="Video Length" SortExpression="VideoLength">
                                <ItemTemplate>
                                    <asp:Label ID="lblVideoLength" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("VideoLength") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 14--%>
                            <asp:TemplateField HeaderText="Laterals" SortExpression="Laterals">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblLaterals" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("Laterals") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 15--%>
                            <asp:TemplateField HeaderText="Live Laterals" SortExpression="LiveLaterals">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblLiveLaterals" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("LiveLaterals") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 16--%>
                            <asp:TemplateField HeaderText="Client ID" SortExpression="ClientID">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientID" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("ClientID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 17--%>
                            <asp:TemplateField HeaderText="Measurements Taken By" SortExpression="MeasurementTakenBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblMeasurementTakenBy" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("MeasurementTakenBy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 18--%>
                            <asp:TemplateField HeaderText="Pre-Flush Date" SortExpression="PreFlushDate">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblPreFlushDate" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("PreFlushDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 19--%>
                            <asp:TemplateField HeaderText="Pre-Video Date" SortExpression="PreVideoDate">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblPreVideoDate" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("PreVideoDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 20--%>
                            <asp:TemplateField HeaderText="P1 Date" SortExpression="P1Date">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblP1Date" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("P1Date", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 21--%>
                            <asp:TemplateField HeaderText="Repair Confirmation Date" SortExpression="RepairConfirmationDate">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblRepairConfirmationDate" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("RepairConfirmationDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 22--%>
                            <asp:TemplateField HeaderText="Traffic Control" SortExpression="TrafficControl">
                                <ItemTemplate>
                                    <asp:Label ID="lblTrafficControl" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("TrafficControl") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 23--%>
                            <asp:TemplateField HeaderText="Material" SortExpression="MaterialType">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaterialType" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("MaterialType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 24--%>
                            <asp:TemplateField HeaderText="Bypass Required?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxBypassRequired" runat="server" Checked='<%# Bind("BypassRequired") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 25--%>
                            <asp:TemplateField HeaderText="Robotic Prep Required?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxRoboticPrepRequired" runat="server" Checked='<%# Bind("RoboticPrepRequired") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 26--%>
                            <asp:TemplateField HeaderText="CXI's Removed" SortExpression="CXIsRemoved">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblCXIsRemoved" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("CXIsRemoved") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 27--%>
                            <asp:TemplateField HeaderText="Robotic Distances" SortExpression="RoboticDistances">
                                <ItemTemplate>
                                    <asp:Label ID="lblRoboticDistances" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("RoboticDistances") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                         
                                                       
                            <%--Column 28--%>
                            <asp:TemplateField HeaderText="Proposed Lining Date" SortExpression="ProposedLiningDate">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProposedLiningDate" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("ProposedLiningDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 29--%>
                            <asp:TemplateField HeaderText="Deadline Lining Date" SortExpression="DeadlineLiningDate">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDeadlineLiningDate" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("DeadlineLiningDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 30--%>
                            <asp:TemplateField HeaderText="Final Video" SortExpression="FinalVideoDate">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblFinalVideoDate" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("FinalVideoDate", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 31--%>
                            <asp:TemplateField HeaderText="Estimated Joints" SortExpression="EstimatedJoints">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblEstimatedJoints" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("EstimatedJoints") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 32--%>
                            <asp:TemplateField HeaderText="Joints Test Sealed" SortExpression="JointsTestSealed">
                                <ItemStyle HorizontalAlign="Center" />                            
                                <ItemTemplate>
                                    <asp:Label ID="lblJointsTestSealed" runat="server" Width="100px" Style="width: 100px" Text='<%# Bind("JointsTestSealed") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 33--%>
                            <asp:TemplateField HeaderText="Issue Identified?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxIssueIdentified" runat="server" Checked='<%# Bind("IssueIdentified") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 34--%>
                            <asp:TemplateField HeaderText="LFS Issue?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxIssueLFS" runat="server" Checked='<%# Bind("IssueLFS") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 35--%>
                            <asp:TemplateField HeaderText="Client Issue?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxIssueClient" runat="server" Checked='<%# Bind("IssueClient") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 36--%>
                            <asp:TemplateField HeaderText="Sales Issue?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxIssueSales" runat="server" Checked='<%# Bind("IssueSales") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 37--%>
                            <asp:TemplateField HeaderText="Issue Given To Client?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxIssueGivenToClient" runat="server" Checked='<%# Bind("IssueGivenToClient") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 38--%>
                            <asp:TemplateField HeaderText="Issue Investigation?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxIssueInvestigation" runat="server" Checked='<%# Bind("IssueInvestigation") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 39--%>
                            <asp:TemplateField HeaderText="Issue Resolved?">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxIssueResolved" runat="server" Checked='<%# Bind("IssueResolved") %>' onclick="return cbxClick();" />
                                </ItemTemplate>
                            </asp:TemplateField>                            
                                                
                            <%--Column 40--%>        
                            <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Width="250px" Style="width: 250px" Text='<%# Bind("Comments") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Column 41--%>        
                            <asp:TemplateField HeaderText="Repair">
                                <ItemTemplate>
                                    <asp:Label ID="lblRePairData" runat="server" Width="250px" Style="width: 250px" Text='<%# Bind("RepairPointID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--Not visible columns--%>
                            <asp:TemplateField HeaderText="ID (Section)" Visible ="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblSectionID" runat="server" Style="width: 100px" Text='<%# Bind("SectionID") %>'></asp:Label>
                                </ItemTemplate>
                           </asp:TemplateField>     
                           
                           <asp:TemplateField HeaderText="AssetID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssetID" runat="server" Style="width: 100px" Text='<%# Bind("AssetID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    &nbsp;
                    </div>
                </td>
                <td style="vertical-align: top">
                    <!-- Table element: 1 column -->
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                        <!-- Page element : Buttons -->
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open" Style="width: 80px" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit" Style="width: 80px" OnClick="btnEdit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnExportList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" EnableViewState="False" 
                                SkinID="ButtonRedText" Text="Delete" Style="width: 80px" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 60px">
                </td>
                <td>
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
                            <asp:Parameter DefaultValue="Point Repairs" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                    
                    
                    <asp:ObjectDataSource ID="odsViewForDisplayList2" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewConditionList">
                        <SelectParameters>
                           <asp:Parameter DefaultValue="Point Repairs" Name="workType" Type="String" />
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
                            <asp:Parameter DefaultValue="Point Repairs" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="inFor" Type="Boolean" />
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
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfSelectedViewId" runat="server" />
                    <asp:HiddenField ID="hdfBtnOrigin" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>