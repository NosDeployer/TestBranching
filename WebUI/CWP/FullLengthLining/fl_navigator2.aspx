<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" Codebehind="fl_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_navigator2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Full Length Lining" SkinID="LabelPageTitle1"></asp:Label>
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
                            <telerik:RadPanelItem Expanded="True" Text="Full Length Lining" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mBulkUpload" Text="Bulk Upload" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mWincapBulkUpload" Text="Wincan (Lateral) Bulk Upload" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mResinsSetup" Text="Resins Setup" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCatalystSetup" Text="Catalyst Setup" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mCXIRemovedReport" Text="CXI Removed Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mReadyForLining" Text="Ready For Lining" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mToBePrepped" Text="To Be Prepped" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mToBeLined" Text="To Be Lined" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mLiningCompleted" Text="Lining Completed" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOverviewReport" Text="Overview Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mAllOutstandingIssues" Text="All Outstanding Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingClientIssues" Text="Outstanding Client Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingLFSIssues" Text="Outstanding LFS Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingInvestigationIssues" Text="Outstanding Investigation Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingSalesIssues" Text="Outstanding Sales Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mClientInvestigationIssuesCityCopy" Text="Client / Investigation Issues - City Copy" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mM1M2ReportByClient" Text="M1 &amp; M2 Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mWorkAhead" Text="Work Ahead %'s And $'s" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mReinstate" Text="Reinstate Report" ></telerik:RadPanelItem>      
                                    <telerik:RadPanelItem runat="server" Value="mWetOut" Text="Wetout Sheet" ></telerik:RadPanelItem>      
                                    <telerik:RadPanelItem runat="server" Value="mInversion" Text="Inversion Sheet" ></telerik:RadPanelItem>
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
        <!-- Page element: Search &  Sort Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td>
                    <asp:Label ID="lblSearchAndSort" runat="server" SkinID="LabelTitle1" Text="Search & Sort" EnableViewState="False"></asp:Label>
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
                    <asp:CheckBox ID="cbxOldCWPID" runat="server" SkinID="CheckBoxSmall" Text="Old CWP ID" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxSubArea" runat="server" SkinID="CheckBoxSmall" Text="Sub Area" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxStreet" runat="server" SkinID="CheckBoxSmall" Checked="True" Text="Street" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxUsmh" runat="server" SkinID="CheckBoxSmall" Text="USMH" Checked="True" EnableViewState="false" />
                </td>
                <td style="width: 125px">
                    <asp:CheckBox ID="cbxDSMH" runat="server" SkinID="CheckBoxSmall" Text="DSMH" Checked="True" EnableViewState="False" />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxProposedLiningDate" runat="server" SkinID="CheckBoxSmall" Text="Proposed Lining Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDeadlineLiningDate" runat="server" SkinID="CheckBoxSmall" Text="Deadline Lining Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxP1Date" runat="server" SkinID="CheckBoxSmall" Text="P1 Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxM1Date" runat="server" SkinID="CheckBoxSmall" Text="M1 Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxM2Date" runat="server" SkinID="CheckBoxSmall" Text="M2 Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxInstallDate" runat="server" SkinID="CheckBoxSmall" Text="Install Date" EnableViewState="False" />
                </td>                               
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxFinalVideoDate" runat="server" SkinID="CheckBoxSmall" Text="Final Video Date" EnableViewState="False" />
                </td> 
                <td>
                    <asp:CheckBox ID="cbxConfirmedSize" runat="server" SkinID="CheckBoxSmall" Text="Confirmed Size" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxActualLength" runat="server" SkinID="CheckBoxSmall" Text="Actual Length" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxComments" runat="server" SkinID="CheckBoxSmall" Text="Comments" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMapSize" runat="server" SkinID="CheckBoxSmall" Text="Map Size" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMapLength" runat="server" SkinID="CheckBoxSmall" Text="Map Length" EnableViewState="False" />
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
                    <asp:CheckBox ID="cbxClientID" runat="server" SkinID="CheckBoxSmall" Text="Client ID" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxPreFlushDate" runat="server" SkinID="CheckBoxSmall" Text="Pre-Flush Date" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxPreVideoDate" runat="server" SkinID="CheckBoxSmall" Text="Pre-Video Date" EnableViewState="False" />
                </td>
                                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbxIssueIdentified" runat="server" SkinID="CheckBoxSmall" Text="Issue Identified?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxLFSIssue" runat="server" SkinID="CheckBoxSmall" Text="LFS Issue?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxClientIssue" runat="server" SkinID="CheckBoxSmall" Text="Client Issue?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxSalesIssue" runat="server" SkinID="CheckBoxSmall" Text="Sales Issue?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxIssueGivenToClient" runat="server" SkinID="CheckBoxSmall" Text="Issue Given To Client?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxIssueInvestigation" runat="server" SkinID="CheckBoxSmall" Text="Issue Investigation?" EnableViewState="False" />
                </td>
                                
            </tr>
            <tr>
                <td>                    
                    <asp:CheckBox ID="cbxIssueResolved" runat="server" SkinID="CheckBoxSmall" Text="Issue Resolved?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCXIsRemoved" runat="server" SkinID="CheckBoxSmall" Text="CXI's Removed" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMaterial" runat="server" SkinID="CheckBoxSmall" Text="Material" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxUSMHAddress" runat="server" SkinID="CheckBoxSmall" Text="USMH Address" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxUSMHDepth" runat="server" SkinID="CheckBoxSmall" Text="USMH Depth" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxUSMHMouth12" runat="server" SkinID="CheckBoxSmall" Text="USMH Mouth 12:00" EnableViewState="False" />
                </td>                
            </tr>
            <tr>
                <td>                    
                    <asp:CheckBox ID="cbxUSMHMouth1" runat="server" SkinID="CheckBoxSmall" Text="USMH Mouth 1:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxUSMHMouth2" runat="server" SkinID="CheckBoxSmall" Text="USMH Mouth 2:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxUSMHMouth3" runat="server" SkinID="CheckBoxSmall" Text="USMH Mouth 3:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxUSMHMouth4" runat="server" SkinID="CheckBoxSmall" Text="USMH Mouth 4:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxUSMHMouth5" runat="server" SkinID="CheckBoxSmall" Text="USMH Mouth 5:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDSMHAddress" runat="server" SkinID="CheckBoxSmall" Text="DSMH Address" EnableViewState="False" />
                </td>                
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxDSMHDepth" runat="server" SkinID="CheckBoxSmall" Text="DSMH Depth" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDSMHMouth12" runat="server" SkinID="CheckBoxSmall" Text="DSMH Mouth 12:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDSMHMouth1" runat="server" SkinID="CheckBoxSmall" Text="DSMH Mouth 1:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDSMHMouth2" runat="server" SkinID="CheckBoxSmall" Text="DSMH Mouth 2:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDSMHMouth3" runat="server" SkinID="CheckBoxSmall" Text="DSMH Mouth 3:00" EnableViewState="False" />
                </td>  
                <td>                    
                    <asp:CheckBox ID="cbxDSMHMouth4" runat="server" SkinID="CheckBoxSmall" Text="DSMH Mouth 4:00" EnableViewState="False" />
                </td>              
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxDSMHMouth5" runat="server" SkinID="CheckBoxSmall" Text="DSMH Mouth 5:00" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxTrafficControl" runat="server" SkinID="CheckBoxSmall" Text="Traffic Control" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxSiteDetails" runat="server" SkinID="CheckBoxSmall" Text="Site Details" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxPipeSizeChange" runat="server" SkinID="CheckBoxSmall" Text="Pipe Size Change?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxStandardBypass" runat="server" SkinID="CheckBoxSmall" Text="Standard Bypass?" EnableViewState="False" />
                </td> 
                <td>                    
                    <asp:CheckBox ID="cbxStandardBypassComments" runat="server" SkinID="CheckBoxSmall" Text="Standard Bypass Comments" EnableViewState="False" />
                </td>               
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxTrafficControlDetails" runat="server" SkinID="CheckBoxSmall" Text="Traffic Control Details" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMeasurementType" runat="server" SkinID="CheckBoxSmall" Text="Measurement Type" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxMeasuredFromMH" runat="server" SkinID="CheckBoxSmall" Text="Measured From MH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxVideoDoneFromMH" runat="server" SkinID="CheckBoxSmall" Text="Video Done From MH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxVideoDoneToMH" runat="server" SkinID="CheckBoxSmall" Text="Video Done To MH" EnableViewState="False" />
                </td>  
                <td>                    
                    <asp:CheckBox ID="cbxM1MeasurementsTakenBy" runat="server" SkinID="CheckBoxSmall" Text="M1 Measurements Taken By" EnableViewState="False" />
                </td>              
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxM2MeasurementsTakenBy" runat="server" SkinID="CheckBoxSmall" Text="M2 Measurements Taken By" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDropPipe" runat="server" SkinID="CheckBoxSmall" Text="Drop Pipe" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxDropPipeInvertDepth" runat="server" SkinID="CheckBoxSmall" Text="Drop Pipe Invert Depth" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxCappedLaterals" runat="server" SkinID="CheckBoxSmall" Text="Capped Laterals" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxLineWidthID" runat="server" SkinID="CheckBoxSmall" Text="Line Width ID#" EnableViewState="False" />
                </td> 
                <td>                    
                    <asp:CheckBox ID="cbxHydrantAddress" runat="server" SkinID="CheckBoxSmall" Text="Hydrant Address" EnableViewState="False" />
                </td>               
            </tr>
            <tr>                
                <td>
                    <asp:CheckBox ID="cbxHydrantDistanceToInversionMH" runat="server" SkinID="CheckBoxSmall" Text="Hydrant Distance To Inversion MH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxHydroWireWithin10FtOfInversionMH" runat="server" SkinID="CheckBoxSmall" Text="Hydro Wire Within 10 Ft Of Inversion MH" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxSurfaceGrade" runat="server" SkinID="CheckBoxSmall" Text="Surface Grade" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxHydroPulley" runat="server" SkinID="CheckBoxSmall" Text="Hydro Pulley?" EnableViewState="False" />
                </td>
                <td>
                    <asp:CheckBox ID="cbxFridgeCart" runat="server" SkinID="CheckBoxSmall" Text="Fridge Cart?" EnableViewState="False" />
                </td>  
                <td>                    
                    <asp:CheckBox ID="cbx2InchPump" runat="server" SkinID="CheckBoxSmall" Text="2 Inch Pump?" EnableViewState="False" />
                </td>              
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
                        <asp:UpdatePanel id="upnlViews" runat="server">
                            <contenttemplate>
                                <asp:DropDownList style="WIDTH: 540px" id="ddlView" runat="server" SkinID="DropDownListLookup">
                                </asp:DropDownList> 
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60px" class="Background_SearchAndSort">
                            <tr>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button  ID="btnViewAdd" runat="server" style="width: 16px; height:16px" ToolTip="Add View" OnClientClick="return btnViewAddClick();" EnableViewState="False" SkinID="ViewAddButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewEdit" runat="server" style="width: 16px; height:16px" ToolTip="Edit View" OnClientClick="return btnViewEditClick();" EnableViewState="False" SkinID="ViewEditButton" /></td>
                                <td style="width: 6px"></td>
                                <td style="width: 16px; text-align: center">
                                    <asp:Button ID="btnViewDelete" runat="server" style="width: 16px; height:16px" ToolTip="Delete View" OnClientClick="return btnViewDeleteClick();" EnableViewState="False" OnClick="btnViewDelete_Click" SkinID="ViewDeleteButton" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnGo" runat="server" SkinID="Button" Text="Go" Style="width: 80px"
                            EnableViewState="False" OnClick="btnGo_Click" OnClientClick="return btnGoClick();" /></td>
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
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label></td>
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
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one section." Display="Dynamic" SkinID="Validator"></asp:CustomValidator></td>
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
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label" Text="Total Rows"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">                    
                    <asp:Panel ID="pnlGrid" runat="server" Width="625px" Height="200px" ScrollBars="Auto">
                        <asp:GridView ID="grdFLNavigator" runat="server" AutoGenerateColumns="False" DataKeyNames="AssetID"
                            SkinID="GridView">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                            Checked='<%# Bind("Selected") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="AssetID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssetID" runat="server" Style="width: 100px" Text='<%# Bind("AssetID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 2--%>
                                <asp:TemplateField HeaderText="ID (Section)">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblFlowOrderID" runat="server" Style="width: 100px" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 3--%>
                                <asp:TemplateField HeaderText="Old CWP ID">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblOldCWPID" runat="server" Style="width: 100px" Text='<%# Bind("OriginalSectionID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 4--%>
                                <asp:TemplateField HeaderText="Sub Area">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubArea" runat="server" Style="width: 150px" Text='<%# Bind("SubArea") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 5--%>
                                <asp:TemplateField HeaderText="Street">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStreet" runat="server" Style="width: 150px" Text='<%# Bind("Street") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 6--%>
                                <asp:TemplateField HeaderText="USMH">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMH" runat="server" Style="width: 100px" Text='<%# Bind("USMHDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 7--%>
                                <asp:TemplateField HeaderText="DSMH">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMH" runat="server" Style="width: 100px" Text='<%# Bind("DSMHDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 8--%>
                                <asp:TemplateField HeaderText="Proposed Lining Date">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblProposedLiningDate" runat="server" Style="width: 100px" Text='<%# Bind("ProposedLiningDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 9--%>
                                <asp:TemplateField HeaderText="Deadline Lining Date">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeadlineLiningDate" runat="server" Style="width: 100px" Text='<%# Bind("DeadlineLiningDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 10--%>
                                <asp:TemplateField HeaderText="P1 Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblP1Date" runat="server" Width="100px" Text='<%# Bind("P1Date", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                
                                <%--Column 11--%>
                                <asp:TemplateField HeaderText="M1 Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblM1Date" runat="server" Width="100px" Text='<%# Bind("M1Date", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 12--%>
                                <asp:TemplateField HeaderText="M2 Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblM2Date" runat="server" Width="100px" Text='<%# Bind("M2Date", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 13--%>
                                <asp:TemplateField HeaderText="Install Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstallDate" runat="server" Width="100px" Text='<%# Bind("InstallDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 14--%>
                                <asp:TemplateField HeaderText="Final Video Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFinalVideoDate" runat="server" Width="100px" Text='<%# Bind("FinalVideoDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 15--%>
                                <asp:TemplateField HeaderText="Confirmed Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSize_" runat="server" Width="100px" Text='<%# Bind("Size_") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 16--%>
                                <asp:TemplateField HeaderText="Actual Length">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLength" runat="server" Width="100px" Text='<%# Bind("Length") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 17--%>
                                <asp:TemplateField HeaderText="Thickness">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblThickness" runat="server" Width="80px" Text='<%# Bind("Thickness") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 18--%>
                                <asp:TemplateField HeaderText="Comments">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComments" runat="server" Width="250px" Text='<%# Bind("Comments") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 19--%>
                                <asp:TemplateField HeaderText="Map Size">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblMapSize" runat="server" Style="width: 100px" Text='<%# Bind("MapSize") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 20--%>
                                <asp:TemplateField HeaderText="Map Length">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblMapLength" runat="server" Style="width: 100px" Text='<%# Bind("MapLength") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                
                                <%--Column 21--%>
                                <asp:TemplateField HeaderText="Video Length">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVideoLength" runat="server" Width="100px" Text='<%# Bind("VideoLength") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 22--%>
                                <asp:TemplateField HeaderText="Laterals">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLaterals" runat="server" Width="100px" Text='<%# Bind("Laterals") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 23--%>
                                <asp:TemplateField HeaderText="Live Laterals">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLiveLaterals" runat="server" Width="100px" Text='<%# Bind("LiveLaterals") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 24--%>
                                <asp:TemplateField HeaderText="Client ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientID" runat="server" Width="100px" Text='<%# Bind("ClientID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                
                                <%--Column 25--%>
                                <asp:TemplateField HeaderText="Pre-Flush Date">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreFlushDate" runat="server" Style="width: 100px" Text='<%# Bind("PreFlushDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 26--%>
                                <asp:TemplateField HeaderText="Pre-Video Date">
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreVideoDate" runat="server" Style="width: 100px" Text='<%# Bind("PreVideoDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 27--%>
                                <asp:TemplateField HeaderText="Issue Identified?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIssueIdentified" runat="server" Checked='<%# Bind("IssueIdentified") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 28--%>
                                <asp:TemplateField HeaderText="LFS Issue?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIssueLFS" runat="server" Checked='<%# Bind("IssueLFS") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 29--%>
                                <asp:TemplateField HeaderText="Client Issue?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIssueClient" runat="server" Checked='<%# Bind("IssueClient") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 30--%>
                                <asp:TemplateField HeaderText="Sales Issue?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIssueSales" runat="server" Checked='<%# Bind("IssueSales") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 31--%>
                                <asp:TemplateField HeaderText="Issue Given To Client?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIssueGivenToClient" runat="server" Checked='<%# Bind("IssueGivenToClient") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 32--%>
                                <asp:TemplateField HeaderText="Issue Investigation?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIssueInvestigation" runat="server" Checked='<%# Bind("IssueInvestigation") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 33--%>
                                <asp:TemplateField HeaderText="Issue Resolved?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxIssueResolved" runat="server" Checked='<%# Bind("IssueResolved") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 34--%>
                                <asp:TemplateField HeaderText="CXI's Removed">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCXIsRemoved" runat="server" Width="100px" Text='<%# Bind("CXIsRemoved") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 35--%>
                                <asp:TemplateField HeaderText="Material">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialType" runat="server" Width="100px" Text='<%# Bind("MaterialType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 36--%>
                                <asp:TemplateField HeaderText="USMH Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHAddress" runat="server" Width="100px" Text='<%# Bind("USMHAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 37--%>
                                <asp:TemplateField HeaderText="USMH Depth">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHDepth" runat="server" Width="100px" Text='<%# Bind("USMHDepth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 38--%>
                                <asp:TemplateField HeaderText="USMH Mouth 12:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth12" runat="server" Width="100px" Text='<%# Bind("USMHMouth12") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 39--%>
                                <asp:TemplateField HeaderText="USMH Mouth 1:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth1" runat="server" Width="100px" Text='<%# Bind("USMHMouth1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 40--%>
                                <asp:TemplateField HeaderText="USMH Mouth 2:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth2" runat="server" Width="100px" Text='<%# Bind("USMHMouth2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 41--%>
                                <asp:TemplateField HeaderText="USMH Mouth 3:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth3" runat="server" Width="100px" Text='<%# Bind("USMHMouth3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 42--%>
                                <asp:TemplateField HeaderText="USMH Mouth 4:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth4" runat="server" Width="100px" Text='<%# Bind("USMHMouth4") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 43--%>
                                <asp:TemplateField HeaderText="USMH Mouth 5:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSMHMouth5" runat="server" Width="100px" Text='<%# Bind("USMHMouth5") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 44--%>
                                <asp:TemplateField HeaderText="DSMH Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHAddress" runat="server" Width="100px" Text='<%# Bind("DSMHAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 45--%>
                                <asp:TemplateField HeaderText="DSMH Depth">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHDepth" runat="server" Width="100px" Text='<%# Bind("DSMHDepth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 46--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 12:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth12" runat="server" Width="100px" Text='<%# Bind("DSMHMouth12") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 47--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 1:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth1" runat="server" Width="100px" Text='<%# Bind("DSMHMouth1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 48--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 2:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth2" runat="server" Width="100px" Text='<%# Bind("DSMHMouth2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 49--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 3:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth3" runat="server" Width="100px" Text='<%# Bind("DSMHMouth3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 50--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 4:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth4" runat="server" Width="100px" Text='<%# Bind("DSMHMouth4") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 51--%>
                                <asp:TemplateField HeaderText="DSMH Mouth 5:00">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDSMHMouth5" runat="server" Width="100px" Text='<%# Bind("DSMHMouth5") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 52--%>
                                <asp:TemplateField HeaderText="Traffic Control">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrafficControl" runat="server" Width="100px" Text='<%# Bind("TrafficControl") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 53--%>
                                <asp:TemplateField HeaderText="Site Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSiteDetails" runat="server" Width="100px" Text='<%# Bind("SiteDetails") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 54--%>
                                <asp:TemplateField HeaderText="Pipe Size Change?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxPipeSizeChange" runat="server" Checked='<%# Bind("PipeSizeChange") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 55--%>
                                <asp:TemplateField HeaderText="Standard Bypass?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxStandardBypass" runat="server" Checked='<%# Bind("StandardBypass") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 56--%>
                                <asp:TemplateField HeaderText="Standard Bypass Comments">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStandardBypassComments" runat="server" Width="100px" Text='<%# Bind("StandardBypassComments") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 57--%>
                                <asp:TemplateField HeaderText="Traffic Control Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrafficControlDetails" runat="server" Width="100px" Text='<%# Bind("TrafficControlDetails") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 58--%>
                                <asp:TemplateField HeaderText="Measurement Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeasurementType" runat="server" Width="100px" Text='<%# Bind("MeasurementType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 59--%>
                                <asp:TemplateField HeaderText="Measured From MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeasurementFromMH" runat="server" Width="100px" Text='<%# Bind("MeasurementFromMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 60--%>
                                <asp:TemplateField HeaderText="Video Done From MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVideoDoneFromMH" runat="server" Width="100px" Text='<%# Bind("VideoDoneFromMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 61--%>
                                <asp:TemplateField HeaderText="Video Done To MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVideoDoneToMH" runat="server" Width="100px" Text='<%# Bind("VideoDoneToMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 62--%>
                                <asp:TemplateField HeaderText="M1 Measurements Taken By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblM1MeasurementTakenBy" runat="server" Width="100px" Text='<%# Bind("M1MeasurementTakenBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 63--%>
                                <asp:TemplateField HeaderText="M2 Measurements Taken By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblM2MeasurementTakenBy" runat="server" Width="100px" Text='<%# Bind("M2MeasurementTakenBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                                                              
                                <%--Column 64--%>
                                <asp:TemplateField HeaderText="Drop Pipe">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxDropPipe" runat="server" Checked='<%# Bind("DropPipe") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 65--%>
                                <asp:TemplateField HeaderText="Drop Pipe Invert Depth">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDropPipeInvertDepth" runat="server" Width="100px" Text='<%# Bind("DropPipeInvertDepth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <%--Column 66--%>
                                <asp:TemplateField HeaderText="Capped Laterals">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCappedLaterals" runat="server" Width="100px" Text='<%# Bind("CappedLaterals") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 67--%>
                                <asp:TemplateField HeaderText="Line Width ID#">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLineWithID" runat="server" Width="100px" Text='<%# Bind("LineWithID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 68--%>
                                <asp:TemplateField HeaderText="Hydrant Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHydrantAddress" runat="server" Width="100px" Text='<%# Bind("HydrantAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 69--%>
                                <asp:TemplateField HeaderText="Hydrant Distance to inversion MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistanceToInversionMH" runat="server" Width="100px" Text='<%# Bind("DistanceToInversionMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 70--%>
                                <asp:TemplateField HeaderText="Hydro Wire Within 10 Ft Of Inversion MH">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHydroWireWithin10FtOfInversionMH" runat="server" Width="100px" Text='<%# Bind("HydroWireWithin10FtOfInversionMH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 71--%>
                                <asp:TemplateField HeaderText="Surface Grade">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSurfaceGrade" runat="server" Width="100px" Text='<%# Bind("SurfaceGrade") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 72--%>
                                <asp:TemplateField HeaderText="Hydro Pulley?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxHydroPulley" runat="server" Checked='<%# Bind("HydroPulley") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 73--%>
                                <asp:TemplateField HeaderText="Fridge Cart?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxFridgeCart" runat="server" Checked='<%# Bind("FridgeCart") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 74--%>
                                <asp:TemplateField HeaderText="2&quot; Pump?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxTwoPump" runat="server" Checked='<%# Bind("TwoPump") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 75--%>
                                <asp:TemplateField HeaderText="6&quot; Bypass?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSixBypass" runat="server" Checked='<%# Bind("SixBypass") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <%--Column 76--%>
                                <asp:TemplateField HeaderText="Scaffolding?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxScaffolding" runat="server" Checked='<%# Bind("Scaffolding") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 77--%>
                                <asp:TemplateField HeaderText="Winch Extention?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxWinchExtention" runat="server" Checked='<%# Bind("WinchExtention") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 78--%>
                                <asp:TemplateField HeaderText="Extra Generator?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxExtraGenerator" runat="server" Checked='<%# Bind("ExtraGenerator") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 79--%>
                                <asp:TemplateField HeaderText="Grey Cable Extension?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxGreyCableExtension" runat="server" Checked='<%# Bind("GreyCableExtension") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 80--%>
                                <asp:TemplateField HeaderText="Easement Mats?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxEasementMats" runat="server" Checked='<%# Bind("EasementMats") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 81--%>
                                <asp:TemplateField HeaderText="Ramps Required?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxRampRequired" runat="server" Checked='<%# Bind("RampRequired") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 82--%>
                                <asp:TemplateField HeaderText="Camera Skid?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxCameraSkid" runat="server" Checked='<%# Bind("CameraSkid") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 83--%>
                                <asp:TemplateField HeaderText="Section Robotic Prep">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxRoboticPrepCompleted" runat="server" Checked='<%# Bind("RoboticPrepCompleted") %>' onclick="return cbxClick();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Column 84--%>
                                <asp:TemplateField HeaderText="Robotic Prep Completed Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoboticPrepCompletedDate" runat="server" Width="100px" Text='<%# Bind("RoboticPrepCompletedDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%--Not visible columns--%>
                                <asp:TemplateField HeaderText="ID (Section)" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSectionID" runat="server" Style="width: 100px" Text='<%# Bind("SectionID") %>'></asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                               
                               <%--Column 86--%>        
                            <asp:TemplateField HeaderText="Lateral">
                                <ItemTemplate>
                                    <asp:Label ID="lblLateralsSummary" runat="server" Width="250px" Text='<%# Bind("LateralsSummary") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>                    
                </td>
                <td style="vertical-align: top">
                    <!-- Table element: 1 column -->
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                        <!-- Page element : Buttons -->
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                Style="width: 80px" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                    Style="width: 80px" OnClick="btnEdit_Click" />
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
                                <asp:Button ID="btnPrintLateralLocationSheet" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Lat Loc Sheet" Style="width: 80px" OnClick="btnPrintLateralLocationSheet_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                    Text="Delete" Style="width: 80px" OnClick="btnDelete_Click" />
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
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor" 
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Full Length Lining" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsViewForDisplayList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Full Length Lining" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsViewForDisplayList2" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Full Length Lining" Name="workType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                            <asp:Parameter Name="conditionId" Type="Int32" DefaultValue="-1" />
                            <asp:Parameter Name="name" Type="String" DefaultValue="" />
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