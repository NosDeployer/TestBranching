<%@ Page Language="C#" MasterPageFile="./../../mForm8.master" AutoEventWireup="true" CodeBehind="pr_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Point Repairs Summary" SkinID="LabelPageTitle1"></asp:Label>
                </td>
                <td style="width: 70px">
                </td>
                <td style="width: 10px">
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
                <td>
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" Width="70px" SkinID="ButtonPageTitle" EnableViewState="True" OnClick="btnChange_Click" />
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
                    <asp:Label ID="lblMissingData" runat="server" SkinID="LabelError" Text=""></asp:Label>
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
        <!-- Table element: 1 columns - Section Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblSectionDetails" runat="server" SkinID="LabelTitle1" Text="Section Details" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Section Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblSectionId" runat="server" EnableViewState="True" SkinID="Label" Text="ID (Section)"></asp:Label>
                </td>
                <td style="width: 125px">                   
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxFlowOrderId" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblStreet" runat="server" EnableViewState="True" SkinID="Label" Text="Street"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblUSMH" runat="server" EnableViewState="True" SkinID="Label" Text="USMH"></asp:Label>&nbsp;
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">USMH and DSMH must be different.</b><span class="hint"></span>                                  
		            </a>
                </td>
                <td>
                    <asp:Label ID="lblUSMHMN" runat="server" EnableViewState="True" SkinID="Label" Text="USMH Address"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDSMH" runat="server" EnableViewState="True" SkinID="Label" Text="DSMH"></asp:Label>&nbsp;
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">DSMH and USMH must be different.</b><span class="hint"></span>                                
		            </a>
                </td>
                <td>
                    <asp:Label ID="lblDSMHMN" runat="server" EnableViewState="True" SkinID="Label" Text="DSMH Address"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 240px"></asp:TextBox>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>              
                    <cc1:AutoCompleteExtender ID="aceUsmh" runat="server" UseContextKey="true" CompletionSetCount="12"
                        MinimumPrefixLength="2" ServiceMethod="GetMHList" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                        TargetControlID="tbxUSMH" SkinID="AutoCompleteExtender">
                    </cc1:AutoCompleteExtender>
                </td>
                <td>
                    <asp:TextBox ID="tbxUSMHMN" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="aceDsmh" runat="server" UseContextKey="true" CompletionSetCount="12"
                        MinimumPrefixLength="2" ServiceMethod="GetMHList" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                        TargetControlID="tbxDSMH" SkinID="AutoCompleteExtender">
                    </cc1:AutoCompleteExtender>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMHMN" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:CompareValidator ID="cvUsmhDsmh" runat="server" ControlToCompare="tbxDSMH" ControlToValidate="tbxUSMH" Display="Dynamic" 
                        ErrorMessage="CompareValidator" Operator="NotEqual" SkinID="Validator" ValidationGroup="generalData">USMH and DSMH must be different.
                    </asp:CompareValidator>
                </td>
                <td>
                </td>
                <td>
                    <asp:CompareValidator ID="cvDsmhUsmh" runat="server" ControlToCompare="tbxUSMH" ControlToValidate="tbxDSMH" Display="Dynamic" 
                        ErrorMessage="CompareValidator" Operator="NotEqual" SkinID="Validator" ValidationGroup="generalData">DSMH and USMH must be different.
                    </asp:CompareValidator>
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
        
        <!-- Table element: 6 columns - Section Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblMapSize" runat="server" EnableViewState="True" SkinID="Label" Text="Map Size"></asp:Label>&nbsp;
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		            </a>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblConfirmedSize" runat="server" EnableViewState="True" SkinID="Label" Text="Confirmed Size"></asp:Label>&nbsp;
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		            </a>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblMapLength" runat="server" EnableViewState="True" SkinID="Label" Text="Map Length"></asp:Label>&nbsp;
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		            </a>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblSteelTapeLength" runat="server" EnableViewState="True" SkinID="LabelSmall" Text="Steel Tape Length"></asp:Label>&nbsp;
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
	                </a>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblVideoLength" runat="server" EnableViewState="True" SkinID="Label" Text="Video Length"></asp:Label>
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                    </a>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblLaterals" runat="server" EnableViewState="True" SkinID="Label" Text="Laterals"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxMapSize" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>      
                </td>
                <td>
                    <asp:TextBox ID="tbxConfirmedSize" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>                     
                </td>
                <td>
                    <asp:TextBox ID="tbxMapLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxSteelTapeLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxVideoLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxLaterals" runat="server" EnableViewState="True" SkinID="TextBoxReadOnly" ReadOnly="True" style="width: 115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvMapSize" runat="server" ControlToValidate="tbxMapSize" Display="Dynamic" 
                        ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvMapSize_ServerValidate" SkinID="Validator" ValidationGroup="generalData">
                    </asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvSize" runat="server" ControlToValidate="tbxConfirmedSize" Display="Dynamic"
                        ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                        OnServerValidate="cvSize_ServerValidate" SkinID="Validator" ValidationGroup="generalData">
                    </asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvMapLength" runat="server" ControlToValidate="tbxMapLength" Display="Dynamic" 
                        ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvMapLength_ServerValidate" SkinID="Validator" ValidationGroup="generalData">
                    </asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvSteelTapeThroughSewer" runat="server" ControlToValidate="tbxSteelTapeLength" Display="Dynamic"
                        ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvSteelTapeThroughSewer_ServerValidate" SkinID="Validator" ValidationGroup="generalData">
                    </asp:CustomValidator>                                                
                </td>
                <td>
                    <asp:CustomValidator ID="cvVideoLength" runat="server" ControlToValidate="tbxVideoLength"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvVideoLength_ServerValidate" SkinID="Validator" ValidationGroup="generalData"></asp:CustomValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLiveLaterals" runat="server" EnableViewState="True" SkinID="Label" Text="Live Laterals"></asp:Label>
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
                    <asp:TextBox style="width: 115px" id="tbxLiveLaterals" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
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
        
        <!-- Table element: 6 columns - Point Repairs Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblPointRepairsDetails" runat="server" SkinID="LabelTitle1" Text="Point Repairs Details" EnableViewState="True"></asp:Label>
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
                <td style="width: 100%">
                    <!-- Page element : Tab control -->
                    
                    <cc1:TabContainer ID="tcPrDetails" runat="server" Width="730px" ActiveTabIndex="1" CssClass="ajax_tabcontainer">
                        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General Data" OnClientClick="tpGeneralDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px; height: 530px; overflow-y: auto;">
                                
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralDataClientId" runat="server" EnableViewState="True" SkinID="Label" Text="Client ID"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataSubArea" runat="server" EnableViewState="True" SkinID="Label" Text="Sub Area"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblGeneralDataMeasurementsTakenBy" runat="server" EnableViewState="True" SkinID="Label" Text="Measurements Taken By"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataClientId" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataSubArea" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxGeneralDataMeasurementsTakenBy" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 226px"></asp:TextBox>
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
                                    
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 708px;">
                                        <tr>
                                            <td style="width: 118px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralDataPreFlushDate" runat="server" EnableViewState="True" SkinID="Label" Text="Pre-Flush Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataPreVideoDate" runat="server" EnableViewState="True" SkinID="Label" Text="Pre-Video Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataP1Date" runat="server" EnableViewState="True" SkinID="Label" Text="P1 Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataRepairConfirmationDate" runat="server" EnableViewState="True" SkinID="LabelSmall" Text="Repair Confirmation Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataTrafficControl" runat="server" EnableViewState="True" SkinID="Label" Text="Traffic Control"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataMaterial" runat="server" EnableViewState="True" SkinID="Label" Text="Material"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDataPreFlushDate" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDataPreVideoDate" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDataP1Date" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDataRepairConfirmationDate" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlGeneralDataTrafficControl" runat="server" DataSourceID="odsTrafficControl" DataTextField="TrafficControl" DataValueField="TrafficControl" SkinID="DropDownListLookup"
                                                    Style="width: 108px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList style="width: 108px" ID="ddlGeneralDataMaterial" runat="server" SkinID="DropDownList" DataSourceID="odsMaterialType" DataValueField="MaterialType" DataTextField="MaterialType">
                                                </asp:DropDownList>
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
                                                <asp:Label ID="lblGeneralDataBypassRequired" runat="server" EnableViewState="True" SkinID="Label" Text="Bypass Required?"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataCXIsRemoved" runat="server" EnableViewState="True" SkinID="Label" Text="CXI's Removed"></asp:Label>
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use an integer number.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblGeneralDataRoboticDistances" runat="server" EnableViewState="True" SkinID="Label" Text="Robotic Distances"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		                                        </a>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataBypassRequired" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataCXIsRemoved" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataRoboticDistances" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 108px"></asp:TextBox> 
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
                                                <asp:CompareValidator ID="cvGeneralDataCXIsRemoved" Width="108px" runat="server" ControlToValidate="tbxGeneralDataCXIsRemoved" Display="Dynamic" 
                                                    ErrorMessage="Invalid format. (Please use an integer number)" Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="generalData">
                                                </asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvGeneralDataRoboticDistances" Width="108px" runat="server" ControlToValidate="tbxGeneralDataRoboticDistances" Display="Dynamic" 
                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                    OnServerValidate="cvGeneralDataRoboticDistances_ServerValidate" SkinID="Validator" ValidationGroup="generalData">
                                                </asp:CustomValidator>
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
                                    
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralDataProposedLiningDate" runat="server" EnableViewState="True" SkinID="LabelSmall" Text="Proposed Lining Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataDeadlineLiningDate" runat="server" EnableViewState="True" SkinID="LabelSmall" Text="Deadline Lining Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataFinalVideo" runat="server" EnableViewState="True" SkinID="Label" Text="Final Video"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDataProposedLiningDate" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDataDeadlineLiningDate" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDataFinalVideo" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
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
                                    
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralDataEstimatedJoints" runat="server" EnableViewState="True" SkinID="LabelSmall" Text="Estimated # Joints"></asp:Label>
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use an integer number.</b><span class="hint"></span>                                                                                                
		                                        </a>
                                            </td>
                                            <td style="width: 236px">
                                                <asp:Label ID="lblGeneralDataJointsTestSealed" runat="server" EnableViewState="True" SkinID="LabelSmall" Text="# Joints Test/Sealed"></asp:Label>
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use an integer number.</b><span class="hint"></span>                                
	                                            </a>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataEstimatedJoints" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 108px"></asp:TextBox> 
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataJointsTestSealed" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
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
                                                <asp:CompareValidator ID="cvGeneralDataEstimatedJoints" runat="server" ControlToValidate="tbxGeneralDataEstimatedJoints" Display="Dynamic" 
                                                    ErrorMessage="Invalid format. (Please use an integer number)" Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="generalData">
                                                </asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvGeneralDataJointsTestSealed" runat="server" ControlToValidate="tbxGeneralDataJointsTestSealed" Display="Dynamic" 
                                                    ErrorMessage="Invalid format. (Please use an integer number)" Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="generalData">
                                                </asp:CompareValidator>
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
                                    
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralDataIssueIdentified" runat="server" EnableViewState="True" SkinID="Label" Text="Issue Identified?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataLfsIssue" runat="server" EnableViewState="True" SkinID="Label" Text="LFS Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataClientIssue" runat="server" EnableViewState="True" SkinID="Label" Text="Client Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataSalesIssue" runat="server" EnableViewState="True" SkinID="Label" Text="Sales Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataIssueGivenToClient" runat="server" EnableViewState="True" SkinID="LabelSmall" Text="Issue Given To Client?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataIssueInvestigation" runat="server" EnableViewState="True" SkinID="Label" Text="Issue Investigation?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataIssueIdentified" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataLfsIssue" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataClientIssue" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataSalesIssue" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataIssueGivenToClient" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataIssueInvestigation" runat="server" SkinID="CheckBox" />
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
                                                <asp:Label ID="lblGeneralDataIssueResolved" runat="server" EnableViewState="True" SkinID="Label" Text="Issue Resolved?"></asp:Label>
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
                                                <asp:CheckBox ID="ckbxGeneralDataIssueResolved" runat="server" SkinID="CheckBox" />
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
                        </cc1:TabPanel>

                
        
                        <cc1:TabPanel ID="tpRepairsData" runat="server" HeaderText="Repairs" OnClientClick="tpRepairsDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px;">
                                
                                    <!-- Page element: Filter by -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">            
                                        <tr>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblOrder" runat="server" SkinID="Label" Text="Filter Repairs By" EnableViewState="False"></asp:Label>
                                            </td>
                                            <td style="width: 90px">
                                            </td>
                                            <td style="width: 510px">
                                            </td>
                                            <td style="width: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                            <td style="height: 7px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlFilter" runat="server" SkinID="DropDownListLookup" AutoPostBack="True" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged" Width="220px">
                                                    <asp:ListItem Value="(All)" Text="(All)" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="Robotic Reaming" Text="Robotic Reaming"></asp:ListItem>
                                                    <asp:ListItem Value="Point Lining" Text="Point Lining"></asp:ListItem>
                                                    <asp:ListItem Value="Grouting" Text="Grouting"></asp:ListItem>
                                                </asp:DropDownList>
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
                                        </tr>
                                    </table>
                                    <!-- Table element: 1 column  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel id="upnlRepairs" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdRepairs" runat="server" SkinID="GridViewInTabs" Width="700px" AutoGenerateColumns="False" 
                                                            ShowFooter="True" DataSourceID="odsRepairs" DataKeyNames="WorkID, RepairPointID" OnDataBound="grdRepairs_DataBound" 
                                                            OnRowDataBound="grdRepairs_RowDataBound" OnRowCommand="grdRepairs_RowCommand" OnRowDeleting="grdRepairs_RowDeleting" 
                                                            OnRowUpdating="grdRepairs_RowUpdating" OnRowEditing="grdRepairs_RowEditing">
                                                            <Columns>
                                                            
                                                                <asp:TemplateField HeaderText="WorkID" SortExpression="WorkID" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblWorkID" runat="server" Text='<%# Eval("WorkID") %>'></asp:Label> 
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWorkID" runat="server" Text='<%# Eval("WorkID") %>'></asp:Label>                 
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                
                                                                
                                                                <asp:TemplateField HeaderText="RepairPointID" SortExpression="RepairPointID" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRepairPointID" runat="server" Text='<%# Eval("RepairPointID") %>'></asp:Label> 
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRepairPointID" runat="server" Text='<%# Eval("RepairPointID") %>'></asp:Label>                 
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                
                                                                
                                                                <asp:TemplateField HeaderText="Type" SortExpression="Type" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRepairType" runat="server" Text='<%# Eval("Type") %>'></asp:Label> 
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRepairType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>                 
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                
                                                            
                                                                <asp:TemplateField HeaderText="Repair">
                                                                    <HeaderStyle Width="645px"></HeaderStyle>
                                                                    
                                                                    <ItemTemplate>                                                            
                                                                        <asp:PlaceHolder ID="phRoboticReaming" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Robotic Reaming") %>'>                                                                
                                                                            <!-- Page element : 6 columns - Repair Information -->                                                                    
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                    
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblRmRepairPointId" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmReamDistance" runat="server" Text="Ream Distance" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmDefectQualifier" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmDefectDetails" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmReamDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReamDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectDetails") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>                                                                                    
                                                                                </tr>                                                                        
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmReamDate" runat="server" Text="Ream Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                                   
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmReinstateDate" runat="server" SkinID="Label" Text="Reinstate Date" EnableViewState="true"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmReamDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReamDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxRmExtraRepair" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxRmCancelled" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Approval") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmReinstateDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReinstateDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>                                                                                        
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
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblRmComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxRmComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
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
                                                                        </asp:PlaceHolder>
                                                                        
                                                                        <asp:PlaceHolder ID="phPointLining" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Point Lining") %>'>
                                                                            <!-- Page element : 6 columns - Repair Information -->
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblPlRepairPointID" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlLinerDistance" runat="server" Text="Liner Distance" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlDefectQualifier" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlDefectDetails" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlLinerDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("LinerDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectDetails") %>' EnableViewState="True"></asp:TextBox>
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
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlDirection" runat="server" Text="Direction" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlReinstates" runat="server" Text="Reinstates" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlLtmh" runat="server" SkinID="Label" Text="LT @ MH" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlVtmh" runat="server" SkinID="Label" Text="VT @ MH" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlDistance" runat="server" SkinID="Label" Text="Distance" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlDirection" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Direction") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlReinstates" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Reinstates") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlLtmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("LTMH") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlVtmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("VTMH") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Distance") %>' EnableViewState="True"></asp:TextBox>
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
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlSize" runat="server" SkinID="Label" Text="Size" EnableViewState="True"></asp:Label>                                                                              
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlLength" runat="server" SkinID="Label" Text="Length" EnableViewState="True"></asp:Label>                                                                              
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlInstallDate" runat="server" SkinID="Label" Text="Install Date" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlMhShot" runat="server" SkinID="Label" Text="MH Shot?" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlSize" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Size_") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlLength" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Length") %>' EnableViewState="True"></asp:TextBox>    
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlInstallDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("InstallDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlMhShot" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("MHShot") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxPlExtraRepair" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True"/>
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
                                                                                    </td>
                                                                                    <td>
                                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlReinstateDate" runat="server" Text="Reinstate Date" SkinID="Label" EnableViewState="True"></asp:Label>
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
                                                                                        <asp:CheckBox ID="cbxPlCancelled" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Approval") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlReinstateDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReinstateDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>                                                                                        
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
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblPlComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxPlComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
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
                                                                        </asp:PlaceHolder>
                                                                        
                                                                        <asp:PlaceHolder ID="phGrouting" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Grouting") %>'>                                                                
                                                                            <!-- Page element : 6 columns - Repair Information -->
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblGtRepairPointId" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtGroutDistance" runat="server" Text="Grout Distance" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px"> 
                                                                                        <asp:Label ID="lblGtDefectQualifier" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px"> 
                                                                                        <asp:Label ID="lblGtDefectDetails" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                            
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtGroutDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("GroutDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectDetails") %>' EnableViewState="True"></asp:TextBox>
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
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtGroutDate" runat="server" Text="Grout Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                        
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtReinstateDate" runat="server" SkinID="Label" Text="Reinstate Date" EnableViewState="True"></asp:Label>                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtGroutDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("GroutDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxGtExtraRepair" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxGtCancelled" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Approval") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtReinstateDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReinstateDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
                                                                                        
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
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblGtComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxGtComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
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
                                                                        </asp:PlaceHolder>                                                                
                                                                    </ItemTemplate>
                                                                    
                                                                    <EditItemTemplate>
                                                                        <asp:PlaceHolder ID="phRoboticReamingEdit" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Robotic Reaming") %>'>
                                                                            <!-- Page element : 6 columns - Repair Information -->                                                                    
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                    
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblRmRepairPointIdEdit" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmRepairTypeEdit" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmReamDistanceEdit" runat="server" Text="Ream Distance" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmDefectQualifierEdit" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmDefectDetailsEdit" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmRepairPointIdEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmRepairTypeEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmReamDistanceEdit" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("ReamDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlRmDefectQualifierEdit" runat="server" SkinID="DropDownList" Width="119px" >
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Light" Text="Light"></asp:ListItem>
                                                                                            <asp:ListItem Value="Moderate" Text="Moderate"></asp:ListItem>
                                                                                            <asp:ListItem Value="Heavy" Text="Heavy"></asp:ListItem>                                                                                           
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlRmDefectDetailsEdit" runat="server" SkinID="DropDownList" Width="119px" >
                                                                                            <asp:ListItem Value="(Select a defect details)" Text="(Select a defect details)"></asp:ListItem>
                                                                                            <asp:ListItem Value="Grease" Text="Grease"></asp:ListItem>
                                                                                            <asp:ListItem Value="Roots" Text="Roots"></asp:ListItem>
                                                                                            <asp:ListItem Value="Calcite" Text="Calcite"></asp:ListItem>
                                                                                            <asp:ListItem Value="Debris" Text="Debris"></asp:ListItem>
                                                                                            <asp:ListItem Value="CXI" Text="CXI"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvRmReamDistanceEdit" runat="server" SkinID="Validator" Width="119px" 
                                                                                            OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataEdit"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxRmReamDistanceEdit">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvRmDefectDetailsEdit" runat="server" SkinID="Validator" Width="119px" ControlToValidate="ddlRmDefectDetailsEdit" InitialValue="(Select a defect details)"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a defect details." ValidationGroup="repairsDataEdit">
                                                                                        </asp:RequiredFieldValidator>
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
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmReamDateEdit" runat="server" Text="Ream Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmApprovalEdit" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmReinstateDateEdit" runat="server" SkinID="Label" Text="Reinstate Date" EnableViewState="true"></asp:Label>                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>                                                                                
                                                                                        <telerik:RadDatePicker ID="tkrdpRmReamDateEdit" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("ReamDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxRmExtraRepairEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxRmCancelledEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                         <asp:DropDownList ID="ddlRmApprovalEdit" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Approval") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                                                                                            <asp:ListItem Value="Not Approved" Text="Not Approved"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpRmReinstateDateEdit" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("ReinstateDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
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
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblRmCommentsEdit" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxRmCommentsEdit" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
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
                                                                        </asp:PlaceHolder>
                                                                                                                                        
                                                                        <asp:PlaceHolder ID="phPointLiningEdit" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Point Lining") %>'>
                                                                            <!-- Page element : 6 columns - Repair Information -->
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblPlRepairPointIdEdit" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlRepairTypeEdit" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlLinerDistanceEdit" runat="server" Text="Liner Distance" SkinID="LabelSmall" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlDefectQualifierEdit" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlDefectDetailsEdit" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlRepairPointIdEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlRepairTypeEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlLinerDistanceEdit" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("LinerDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlDefectQualifierEdit" runat="server" SkinID="DropDownList" Width="119px">
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Longitudinal" Text="Longitudinal"></asp:ListItem>
                                                                                            <asp:ListItem Value="Circumferential" Text="Circumferential"></asp:ListItem>
                                                                                            <asp:ListItem Value="Spiral" Text="Spiral"></asp:ListItem>
                                                                                            <asp:ListItem Value="Multiple" Text="Multiple"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlDefectDetailsEdit" runat="server" SkinID="DropDownList" Width="119px" >
                                                                                            <asp:ListItem Value="(Select a defect details)" Text="(Select a defect details)"></asp:ListItem>
                                                                                            <asp:ListItem Value="Break" Text="Break"></asp:ListItem>
                                                                                            <asp:ListItem Value="Fracture" Text="Fracture"></asp:ListItem>
                                                                                            <asp:ListItem Value="Crack" Text="Crack"></asp:ListItem>
                                                                                            <asp:ListItem Value="Offset" Text="Offset"></asp:ListItem>
                                                                                            <asp:ListItem Value="Roots" Text="Roots"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvPlLinerDistanceEdit" runat="server" SkinID="Validator" Width="119px" 
                                                                                            OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataEdit"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxPlLinerDistanceEdit">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvPlDefectDetailsEdit" runat="server" SkinID="Validator" Width="119px" ControlToValidate="ddlPlDefectDetailsEdit" InitialValue="(Select a defect details)"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a defect details." ValidationGroup="repairsDataEdit">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </td>                                                                      
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlDirectionEdit" runat="server" Text="Direction" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlReinstatesEdit" runat="server" Text="Reinstates" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use an integer number or leave the field empty.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlLtmhEdit" runat="server" SkinID="Label" Text="LT @ MH" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlVtmhEdit" runat="server" SkinID="Label" Text="VT @ MH" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlDistanceEdit" runat="server" SkinID="LabelSmall" Text="Distance" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlDirectionEdit" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Direction") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="DS PULL IN" Text="DS PULL IN"></asp:ListItem>
                                                                                            <asp:ListItem Value="DS PUSH IN" Text="DS PUSH IN"></asp:ListItem>
                                                                                            <asp:ListItem Value="US PULL IN" Text="US PULL IN"></asp:ListItem>
                                                                                            <asp:ListItem Value="US PUSH IN" Text="US PUSH IN"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlReinstatesEdit" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("Reinstates") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:HiddenField ID="hdfPlLtmhEdit" runat="server" Value='<%# Eval("LTMH") %>'></asp:HiddenField>
                                                                                        <asp:DropDownList ID="ddlPlLtmhEdit" runat="server" SkinID="DropDownList" Width="119px" ></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:HiddenField ID="hdfPlVtmhEdit" runat="server" Value='<%# Eval("VTMH") %>'></asp:HiddenField>
                                                                                        <asp:DropDownList ID="ddlPlVtmhEdit" runat="server" SkinID="DropDownList" Width="119px" Enabled="false"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlDistanceEdit" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("Distance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvPlReinstatesEdit" runat="server" ControlToValidate="tbxPlReinstatesEdit"
                                                                                            Display="Dynamic" ErrorMessage="Invalid data. (Please use an integer number or leave the field empty)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="repairsDataEdit">
                                                                                        </asp:CompareValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvPlDistanceEdit" runat="server" SkinID="Validator" Width="119px" OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataEdit"
                                                                                            ErrorMessage="Invalid format. (Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxPlDistanceEdit">
                                                                                        </asp:CustomValidator>
                                                                                    </td>                                                                       
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlSizeEdit" runat="server" SkinID="Label" Text="Size" EnableViewState="True"></asp:Label>                                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlLengthEdit" runat="server" SkinID="Label" Text="Length" EnableViewState="True"></asp:Label>                                                                                                                                                                            
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlInstallDateEdit" runat="server" SkinID="Label" Text="Install Date" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlMhShotEdit" runat="server" SkinID="Label" Text="MH Shot?" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>                                                                                        
                                                                                        <asp:DropDownList ID="ddlPlSize_Edit" runat="server" DataMember="DefaultView"
                                                                                            DataSourceID="odsSizeList" DataTextField="Size_" DataValueField="Size_"
                                                                                            SkinID="DropDownList" Style="width: 119px">
                                                                                        </asp:DropDownList>                                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlLengthEdit" runat="server" DataMember="DefaultView"
                                                                                            DataSourceID="odsLengthList" DataTextField="Length" DataValueField="Length"
                                                                                            SkinID="DropDownList" Style="width: 119px">
                                                                                        </asp:DropDownList>   
                                                                                    </td>
                                                                                    <td>                                                                               
                                                                                        <telerik:RadDatePicker ID="tkrdpPlInstallDateEdit" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("InstallDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlMhShotEdit" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("MHShot") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="DS MH SHOT" Text="DS MH SHOT"></asp:ListItem>
                                                                                            <asp:ListItem Value="US MH SHOT" Text="US MH SHOT"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxPlExtraRepairEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True"/>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlApprovalEdit" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlReinstateDateEdit" runat="server" Text="Reinstate Date" SkinID="Label" EnableViewState="True"></asp:Label>
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
                                                                                        <asp:CheckBox ID="cbxPlCancelledEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlAprovalEdit" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Approval") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                                                                                            <asp:ListItem Value="Not Approved" Text="Not Approved"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpPlReinstateDateEdit" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("ReinstateDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblPlCommentsEdit" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxPlCommentsEdit" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>                                                                
                                                                        </asp:PlaceHolder>
                                                                        
                                                                        <asp:PlaceHolder ID="phGroutingEdit" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Grouting") %>'>
                                                                            <!-- Page element : 6 columns - Repair Information -->
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblGtRepairPointIdEdit" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtRepairTypeEdit" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtGroutDistanceEdit" runat="server" Text="Grout Distance" SkinID="LabelSmall" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                 
		                                                                                </a>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtDefectQualifierEdit" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtDefectDetailsEdit" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtRepairPointIdEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtRepairTypeEdit" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtGroutDistanceEdit" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("GroutDistance") %>' EnableViewState="True"></asp:TextBox> 
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlGtDefectQualifierEdit" runat="server" SkinID="DropDownList" Width="119px">
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Infiltration" Text="Infiltration"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlGtDefectDetailsEdit" runat="server" SkinID="DropDownList" Width="119px" >
                                                                                            <asp:ListItem Value="(Select a defect details)" Text="(Select a defect details)"></asp:ListItem>
                                                                                            <asp:ListItem Value="Seeper" Text="Seeper"></asp:ListItem>
                                                                                            <asp:ListItem Value="Dripper" Text="Dripper"></asp:ListItem>
                                                                                            <asp:ListItem Value="Runner" Text="Runner"></asp:ListItem>
                                                                                            <asp:ListItem Value="Gusher" Text="Gusher"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvGtGroutDistanceEdit" runat="server" SkinID="Validator" Width="119px" OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataEdit"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxGtGroutDistanceEdit">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvGtDefectDetailsEdit" runat="server" SkinID="Validator" Width="119px" ControlToValidate="ddlGtDefectDetailsEdit" InitialValue="(Select a defect details)"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a defect details." ValidationGroup="repairsDataEdit">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtGroutDateEdit" runat="server" Text="Grout Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtApprovalEdit" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpGtGroutDateEdit" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("GroutDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxGtExtraRepairEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxGtCancelledEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlGtApprovalEdit" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Approval") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                                                                                            <asp:ListItem Value="Not Approved" Text="Not Approved"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblGtCommentsEdit" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                   <td colspan="5">
                                                                                        <asp:TextBox ID="tbxGtCommentsEdit" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:PlaceHolder>
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 6 columns - Repair Information -->                                                                                                                                        
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 10px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 129px;">
                                                                                    <asp:Label ID="lblRepairTypeNew" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 129px;">
                                                                                </td>
                                                                                <td style="width: 129px;">
                                                                                </td>
                                                                                <td style="width: 129px;">
                                                                                </td>
                                                                                <td style="width: 129px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlRepairTypeNew" runat="server" SkinID="DropDownList" Width="119px" AutoPostBack="True" OnSelectedIndexChanged="ddlRepairTypeNew_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="Robotic Reaming" Text="Robotic Reaming"></asp:ListItem>
                                                                                        <asp:ListItem Value="Point Lining" Text="Point Lining"></asp:ListItem>
                                                                                        <asp:ListItem Value="Grouting" Text="Grouting"></asp:ListItem>
                                                                                    </asp:DropDownList>
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
                                                                                <td style="height: 7px" colspan="6">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                                                                                        
                                                                        <asp:Panel ID="pnlRoboticReamingNew" runat="server" Width="100%">
                                                                            <!-- Page element : 6 columns - Repair Information -->                                                                    
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                    
                                                                                <tr>
                                                                                    <td style="width: 10px;">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblRmRepairPointIdNew" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmRepairTypeNew" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmReamDistanceNew" runat="server" Text="Ream Distance" SkinID="LabelSmall" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmDefectQualifierNew" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblRmDefectDetailsNew" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmRepairPointIdNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmRepairTypeNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text="Robotic Reaming" EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRmReamDistanceNew" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("ReamDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlRmDefectQualifierNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("DefectQualifier") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Light" Text="Light"></asp:ListItem>
                                                                                            <asp:ListItem Value="Moderate" Text="Moderate"></asp:ListItem>
                                                                                            <asp:ListItem Value="Heavy" Text="Heavy"></asp:ListItem>                                                                                            
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlRmDefectDetailsNew" runat="server" SkinID="DropDownList" Width="119px">
                                                                                            <asp:ListItem Value="(Select a defect details)" Text="(Select a defect details)"></asp:ListItem>
                                                                                            <asp:ListItem Value="Grease" Text="Grease"></asp:ListItem>
                                                                                            <asp:ListItem Value="Roots" Text="Roots"></asp:ListItem>
                                                                                            <asp:ListItem Value="Calcite" Text="Calcite"></asp:ListItem>
                                                                                            <asp:ListItem Value="Debris" Text="Debris"></asp:ListItem>
                                                                                            <asp:ListItem Value="CXI" Text="CXI"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvRmReamDistanceNew" runat="server" SkinID="Validator" Width="119px" OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataAdd"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxRmReamDistanceNew">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvRmDefectDetailsNew" runat="server" SkinID="Validator" Width="119px" ControlToValidate="ddlRmDefectDetailsNew" InitialValue="(Select a defect details)"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a defect details." ValidationGroup="repairsDataAdd">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmReamDateNew" runat="server" Text="Ream Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmApprovalNew" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRmReinstateDateNew" runat="server" SkinID="Label" Text="Reinstate Date" EnableViewState="true"></asp:Label>                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpRmReamDateNew" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("ReamDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxRmExtraRepairNew" runat="server" SkinID="CheckBox" Text="Extra Repair" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxRmCancelledNew" runat="server" SkinID="CheckBox" Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                         <asp:DropDownList ID="ddlRmApprovalNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Approval") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                                                                                            <asp:ListItem Value="Not Approved" Text="Not Approved"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpRmReinstateDateNew" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("ReinstateDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblRmCommentsNew" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxRmCommentsNew" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        
                                                                        <asp:Panel ID="pnlPointLiningNew" runat="server" Visible="false" Width="100%">
                                                                            <!-- Page element : 6 columns - Repair Information -->
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 10px;">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblPlRepairPointIdNew" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlRepairTypeNew" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlLinerDistanceNew" runat="server" Text="Liner Distance" SkinID="LabelSmall" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                 
		                                                                                </a>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlDefectQualifierNew" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblPlDefectDetailsNew" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlRepairPointIdNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlRepairTypeNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text="Point Lining" EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlLinerDistanceNew" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("LinerDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlDefectQualifierNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("DefectQualifier") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Longitudinal" Text="Longitudinal"></asp:ListItem>
                                                                                            <asp:ListItem Value="Circumferential" Text="Circumferential"></asp:ListItem>
                                                                                            <asp:ListItem Value="Spiral" Text="Spiral"></asp:ListItem>
                                                                                            <asp:ListItem Value="Multiple" Text="Multiple"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlDefectDetailsNew" runat="server" SkinID="DropDownList" Width="119px">
                                                                                            <asp:ListItem Value="(Select a defect details)" Text="(Select a defect details)"></asp:ListItem>
                                                                                            <asp:ListItem Value="Break" Text="Break"></asp:ListItem>
                                                                                            <asp:ListItem Value="Fracture" Text="Fracture"></asp:ListItem>
                                                                                            <asp:ListItem Value="Crack" Text="Crack"></asp:ListItem>
                                                                                            <asp:ListItem Value="Offset" Text="Offset"></asp:ListItem>
                                                                                            <asp:ListItem Value="Roots" Text="Roots"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvPlLinerDistanceNew" runat="server" SkinID="Validator" Width="119px" OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataAdd"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxPlLinerDistanceNew">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvPlDefectDetailsNew" runat="server" SkinID="Validator" Width="119px" ControlToValidate="ddlPlDefectDetailsNew" InitialValue="(Select a defect details)"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a defect details." ValidationGroup="repairsDataAdd">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </td>                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlDirectionNew" runat="server" Text="Direction" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlReinstatesNew" runat="server" Text="Reinstates" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use an integer number or leave the field empty.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlLtmhNew" runat="server" SkinID="Label" Text="LT @ MH" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlVtmhNew" runat="server" SkinID="Label" Text="VT @ MH" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlDistanceNew" runat="server" SkinID="LabelSmall" Text="Distance" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlDirectionNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Direction") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="DS PULL IN" Text="DS PULL IN"></asp:ListItem>
                                                                                            <asp:ListItem Value="DS PUSH IN" Text="DS PUSH IN"></asp:ListItem>
                                                                                            <asp:ListItem Value="US PULL IN" Text="US PULL IN"></asp:ListItem>
                                                                                            <asp:ListItem Value="US PUSH IN" Text="US PUSH IN"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="tbxPlReinstatesNew" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("Reinstates") %>' EnableViewState="True"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>                                                                                   
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlLtmhNew" runat="server" SkinID="DropDownList" Width="119px"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlVtmhNew" runat="server" SkinID="DropDownList" Width="119px" Enabled="false"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxPlDistanceNew" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("Distance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvPlReinstatesNew" runat="server" ControlToValidate="tbxPlReinstatesNew"
                                                                                            Display="Dynamic" ErrorMessage="Invalid data. (Please use an integer number or leave the field empty)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="repairsDataAdd">
                                                                                        </asp:CompareValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvPlDistanceNew" runat="server" SkinID="Validator" Width="119px" OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataAdd"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxPlDistanceNew">
                                                                                        </asp:CustomValidator>
                                                                                    </td>                                                                     
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlSizeNew" runat="server" SkinID="Label" Text="Size" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlLengthNew" runat="server" SkinID="Label" Text="Length" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlInstallDateNew" runat="server" SkinID="Label" Text="Install Date" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlMhShotNew" runat="server" SkinID="Label" Text="MH Shot?" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlSize_New" runat="server" DataMember="DefaultView"
                                                                                            DataSourceID="odsSizeList" DataTextField="Size_" DataValueField="Size_"
                                                                                            SkinID="DropDownList" Style="width: 119px"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlLengthNew" runat="server" DataMember="DefaultView"
                                                                                            DataSourceID="odsLengthList" DataTextField="Length" DataValueField="Length"
                                                                                            SkinID="DropDownList" Style="width: 119px"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpPlInstallDateNew" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("InstallDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlMhShotNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("MHShot") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="DS MH SHOT" Text="DS MH SHOT"></asp:ListItem>
                                                                                            <asp:ListItem Value="US MH SHOT" Text="US MH SHOT"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxPlExtraRepairNew" runat="server" SkinID="CheckBox" Text="Extra Repair" EnableViewState="True"/>
                                                                                    </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>                                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlApprovalNew" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPlReinstateDateNew" runat="server" Text="Reinstate Date" SkinID="Label" EnableViewState="True"></asp:Label>                                                                                        
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
                                                                                        <asp:CheckBox ID="cbxPlCancelledNew" runat="server" SkinID="CheckBox" Text="Cancelled" EnableViewState="True" />
                                                                                    </td>                                                                        
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPlAprovalNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Approval") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                                                                                            <asp:ListItem Value="Not Approved" Text="Not Approved"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpPlReinstateDateNew" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("ReinstateDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblPlCommentsNew" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxPlCommentsNew" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>                                                                
                                                                        </asp:Panel>
                                                                        
                                                                        <asp:Panel ID="pnlGroutingNew" runat="server" Visible="false" Width="100%">                                               
                                                                            <!-- Page element : 6 columns - Repair Information -->
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 10px;">
                                                                                    </td>
                                                                                    <td style="width: 129px;">
                                                                                        <asp:Label ID="lblGtRepairPointIdNew" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtRepairTypeNew" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                   <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtGroutDistanceNew" runat="server" Text="Grout Distance" SkinID="LabelSmall" EnableViewState="True"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>                                
		                                                                                </a>
                                                                                    </td>                                                                                    
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtDefectQualifierNew" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <asp:Label ID="lblGtDefectDetailsNew" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtRepairPointIdNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtRepairTypeNew" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text="Grouting" EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxGtGroutDistanceNew" runat="server" SkinID="TextBox" Width="119px" Text='<%# Eval("GroutDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlGtDefectQualifierNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("DefectQualifier") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Infiltration" Text="Infiltration"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlGtDefectDetailsNew" runat="server" SkinID="DropDownList" Width="119px">
                                                                                            <asp:ListItem Value="(Select a defect details)" Text="(Select a defect details)"></asp:ListItem>
                                                                                            <asp:ListItem Value="Seeper" Text="Seeper"></asp:ListItem>
                                                                                            <asp:ListItem Value="Dripper" Text="Dripper"></asp:ListItem>
                                                                                            <asp:ListItem Value="Runner" Text="Runner"></asp:ListItem>
                                                                                            <asp:ListItem Value="Gusher" Text="Gusher"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvGtGroutDistanceNew" runat="server" SkinID="Validator" Width="119px" OnServerValidate="cvDistance_ServerValidate" ValidationGroup="repairsDataAdd"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" ControlToValidate="tbxGtGroutDistanceNew">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvGtDefectDetailsNew" runat="server" SkinID="Validator" Width="119px" ControlToValidate="ddlGtDefectDetailsNew" InitialValue="(Select a defect details)"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a defect details." ValidationGroup="repairsDataAdd">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtGroutDateNew" runat="server" Text="Grout Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtApprovalNew" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                                    </td>                                                                        
                                                                                    <td>
                                                                                        <asp:Label ID="lblGtReinstateDateNew" runat="server" Text="Reinstate Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpGtGroutDateNew" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("GroutDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxGtExtraRepairNew" runat="server" SkinID="CheckBox" Text="Extra Repair" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxGtCancelledNew" runat="server" SkinID="CheckBox" Text="Cancelled" EnableViewState="True" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlGtApprovalNew" runat="server" SkinID="DropDownList" Width="119px" SelectedValue='<%# Eval("Approval") %>'>
                                                                                            <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                                                                                            <asp:ListItem Value="Not Approved" Text="Not Approved"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpGtReinstateDateNew" runat="server" Width="119px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("ReinstateDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblGtCommentsNew" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxGtCommentsNew" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBox" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                                    <td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="6">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                

                                                                <asp:TemplateField>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" ToolTip="Accept" runat="server" SkinID="GridView_Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png" CommandName="Update"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" ToolTip="Cancel" runat="server" SkinID="GridView_Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png" CommandName="Cancel"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" ToolTip="Add" runat="server" SkinID="GridView_Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png" CommandName="Add"></asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>                                                            
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" ToolTip="Edit" runat="server" SkinID="GridView_Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png" CommandName="Edit"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" ToolTip="Delete" runat="server" SkinID="GridView_Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this repair?");'></asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>                                                            
                                                                    </ItemTemplate>                                                           
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 1 column - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
        
        
        
                        <cc1:TabPanel ID="tpComments" runat="server" HeaderText="Comments" OnClientClick="tpCommentsDataClientClick">
                            <ContentTemplate>
                               <div style="width: 710px;">
                                
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
                                                <asp:UpdatePanel id="upnlComments" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView id="grdComments" runat="server" SkinID="GridViewInTabs" Width="700px" AutoGenerateColumns="False" ShowFooter="True" 
                                                            DataSourceID="odsComments" DataKeyNames="WorkID, RefID"   OnRowEditing="grdComments_RowEditing"                                                    
                                                            OnRowDeleting="grdComments_RowDeleting" OnRowUpdating="grdComments_RowUpdating" 
                                                            OnRowCommand="grdComments_RowCommand" OnDataBound="grdComments_DataBound">
                                                            
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="WorkID" SortExpression="WorkID" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblWorkID" runat="server" Text='<%# Eval("WorkID") %>'></asp:Label> 
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWorkID" runat="server" Text='<%# Eval("WorkID") %>'></asp:Label>                 
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                
                                                                
                                                                <asp:TemplateField HeaderText="RefID" SortExpression="RefID" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label> 
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>                 
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                
                                                                
                                                                <asp:TemplateField HeaderText="Information" SortExpression="Subject">
                                                                    <EditItemTemplate>
                                                                    
                                                                        <!-- Page element : 2 columns - Comments Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 160px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 160px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCommentSubjectEdit" runat="server" EnableViewState="True" SkinID="Label" Text="Subject"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="tbxCommentSubjectEdit" runat="server" EnableViewState="True" SkinID="TextBox" Text='<%# Eval("Subject") %>' Style="width: 310px" ></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvCommentSubjectEdit" runat="server" ControlToValidate="tbxCommentSubjectEdit" Display="Dynamic" 
                                                                                        EnableViewState="True" ErrorMessage="Please provide a subject." SkinID="Validator" ValidationGroup="commentsDataEdit">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCommentDateEdit" runat="server" EnableViewState="True" SkinID="Label" Text="Date"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblCommentCreatedByEdit" runat="server" EnableViewState="True" SkinID="Label" Text="Created By"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxCommentDateEdit" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxCommentCreatedByEdit" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# GetCommentCreatedBy(Eval("UserID")) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                        
                                                                    <FooterTemplate>
                                            
                                                                        <!-- Page element : 2 columns - Comments Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 160px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 160px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblCommentSubjectNew" runat="server" EnableViewState="True" SkinID="Label" Text="Subject"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="tbxCommentSubjectNew" runat="server" EnableViewState="True" SkinID="TextBox" Text='<%# Eval("Subject") %>' Style="width: 310px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:RequiredFieldValidator ID="rfvCommentSubjectNew" runat="server" ControlToValidate="tbxCommentSubjectNew" Display="Dynamic" 
                                                                                        EnableViewState="True" ErrorMessage="Please provide a subject." SkinID="Validator" ValidationGroup="commentsDataAdd">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 12px" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>
                                                                    
                                                                        <HeaderStyle Width="320px"></HeaderStyle>
                                                                        
                                                                        <!-- Page element : 2 columns - Comments Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 160px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 160px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblCommentSubject" runat="server" EnableViewState="True" SkinID="Label" Text="Subject"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="tbxCommentSubject" runat="server" EnableViewState="True" ReadOnly="True" Text='<%# Eval("Subject") %>' SkinID="TextBoxReadOnly" Style="width: 310px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>                                                                    
                                                                            <tr>
                                                                                <td style="height: 7px" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblCommentDate" runat="server" EnableViewState="True" SkinID="Label" Text="Date"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblCommentCreatedBy" runat="server" EnableViewState="True" SkinID="Label" Text="Created By"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxCommentDate" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxCommentCreatedBy" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# GetCommentCreatedBy(Eval("UserID")) %>'></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>                                                            
                                                                </asp:TemplateField>



                                                                <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
                                                                    <EditItemTemplate>
                                            
                                                                        <!-- Page element : 2 columns - Comments information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 160px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 160px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblCommentCommentEdit" runat="server" EnableViewState="True" SkinID="Label" Text="Comment"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="tbxCommentCommentEdit" runat="server" EnableViewState="True" Rows="4" Text='<%# Eval("Comment") %>' SkinID="TextBox" Style="width: 310px" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:RequiredFieldValidator ID="rfvCommentCommentEdit" runat="server" ControlToValidate="tbxCommentCommentEdit" Display="Dynamic" 
                                                                                        EnableViewState="True" ErrorMessage="Please provide a comment." SkinID="Validator" ValidationGroup="commentsDataEdit">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                    
                                                                        <HeaderStyle Width="320px"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            
                                                                        <!-- Page element : 2 columns - Comments information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 160px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 160px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblCommentCommentNew" runat="server" EnableViewState="True" SkinID="Label" Text="Comment"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="tbxCommentCommentNew" runat="server" EnableViewState="True" Rows="1" Text='<%# Eval("Comment") %>' SkinID="TextBox" Style="width: 310px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:RequiredFieldValidator ID="rfvCommentCommentNew" runat="server" ControlToValidate="tbxCommentCommentNew" Display="Dynamic" 
                                                                                        EnableViewState="True" ErrorMessage="Please provide a comment." SkinID="Validator" ValidationGroup="commentsDataAdd">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 12px" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                           
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>
                                            
                                                                        <!-- Page element : 2 columns - Comments information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 160px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 160px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblCommentComment" runat="server" EnableViewState="True" SkinID="Label" Text="Comment"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="tbxCommentComment" runat="server" EnableViewState="True" ReadOnly="True" Text='<%# Eval("Comment") %>' Rows="4" SkinID="TextBoxReadOnly" Style="width: 310px" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 10px">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>                                                            
                                                                </asp:TemplateField>



                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" ToolTip="Accept" runat="server" SkinID="GridView_Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png" CommandName="Update"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" ToolTip="Cancel" runat="server" SkinID="GridView_Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png" CommandName="Cancel"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" ToolTip="Add" runat="server" SkinID="GridView_Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png" CommandName="Add"></asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>                                                           
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" ToolTip="Edit" runat="server" SkinID="GridView_Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png" CommandName="Edit"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" ToolTip="Delete" runat="server" SkinID="GridView_Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this comment?");'></asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>                                                                
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </contenttemplate>
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
                    <asp:ObjectDataSource ID="odsRepairs" runat="server" SelectMethod="GetRepairsNew"
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_edit" DeleteMethod="DummyRepairsNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyRepairsNew" InsertMethod="DummyRepairsNew">                        
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsComments" runat="server" SelectMethod="GetCommentsNew"
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_edit" DeleteMethod="DummyCommentsNew" 
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyCommentsNew" InsertMethod="DummyCommentsNew">                        
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
                    
                    <asp:ObjectDataSource ID="odsTrafficControl" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningM1TrafficControlList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="trafficControl" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterialType" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.MaterialTypeList">
                        <SelectParameters>
                            <asp:Parameter Name="materialType" Type="String" />
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
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfAssetId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfWorkIdFll" runat="server" />
                    <asp:HiddenField ID="hdfWorkIdRa" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfSectionId" runat="server" />
                    <asp:HiddenField ID="hdfFlowOrderId" runat="server" />
                    <asp:HiddenField ID="hdfUSMH" runat="server" />
                    <asp:HiddenField ID="hdfDSMH" runat="server" />
                    <asp:HiddenField ID="hdfErrorFieldList" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="FooterPlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmFooter" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
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



<asp:Content ID="Content6" ContentPlaceHolderID="FooterSpacePlaceHolder" runat="server">
    <div style="width: 750px">
        <!-- Page element : Footer separation -->
        <table id="Table2" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>