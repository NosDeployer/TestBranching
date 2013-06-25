<%@ Page Language="C#" MasterPageFile="../../mForm8.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ra_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.RehabAssessment.ra_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">            
    <!-- CONTENT -->
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Rehab Assessment Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" Width="70px" SkinID="ButtonPageTitle" EnableViewState="True" OnClick="btnChange_Click"/>
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
                            <telerik:RadPanelItem Expanded="True" Text="Rehab Assessment" PostBack="false">
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
                                    <telerik:RadPanelItem runat="server" Value="mRehabAssessmentPlan" Text="Rehab Assessment Plan"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mM1M2ReportByClient" Text="M1 &amp; M2 Report" ></telerik:RadPanelItem>
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
                    <asp:Label ID="lblOldCwpId" runat="server" EnableViewState="True" SkinID="Label" Text="Old CWP ID (Section)"></asp:Label>
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
                    <asp:TextBox ID="tbxOldCwpId" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:Label ID="lblDSMH" runat="server" EnableViewState="True" SkinID="Label" Text="DSMH"></asp:Label>&nbsp;
                    <a href="#" class="hint">
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">DSMH and USMH must be different.</b><span class="hint"></span>
                    </a>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 240px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 105px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="aceUsmh" runat="server" UseContextKey="true" CompletionSetCount="12"
                        MinimumPrefixLength="2" ServiceMethod="GetMHList" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                        TargetControlID="tbxUSMH" SkinID="AutoCompleteExtender">
                    </cc1:AutoCompleteExtender>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 105px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="aceDsmh" runat="server" UseContextKey="true" CompletionSetCount="12"
                        MinimumPrefixLength="2" ServiceMethod="GetMHList" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                        TargetControlID="tbxDSMH" SkinID="AutoCompleteExtender">
                    </cc1:AutoCompleteExtender>
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
                    <asp:CompareValidator ID="cvUsmhDsmh" runat="server" ControlToCompare="tbxDSMH" ControlToValidate="tbxUSMH"
                        Display="Dynamic" ErrorMessage="CompareValidator" Operator="NotEqual" SkinID="Validator"
                        ValidationGroup="raData">USMH and DSMH must be different.</asp:CompareValidator>
                </td>
                <td>
                    <asp:CompareValidator ID="cvDsmhUsmh" runat="server" ControlToCompare="tbxUSMH" ControlToValidate="tbxDSMH"
                        Display="Dynamic" ErrorMessage="CompareValidator" Operator="NotEqual" SkinID="Validator"
                        ValidationGroup="raData">DSMH and USMH must be different.</asp:CompareValidator>
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
        
        <!-- Table element: 6 columns - Section Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px; vertical-align: bottom;">
                    <asp:Label ID="lblMapSize" runat="server" EnableViewState="True" SkinID="Label" Text="Map Size"></asp:Label>&nbsp;
                    <a href="#" class="hint" >
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
                    <asp:Label ID="lblThickness" runat="server" SkinID="Label" Text="Thickness"></asp:Label>
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
                    <asp:Label ID="lblVideoLength" runat="server" EnableViewState="True" SkinID="Label" Text="Video Length"></asp:Label>&nbsp;
                    <a href="#" class="hint">                                    
                        <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                        <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                    </a>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxMapSize" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxConfirmedSize" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px" onkeyup="SetValueInThickness();"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlThickness" runat="server" DataMember="DefaultView" 
                        DataSourceID="odsThicknessList" DataTextField="Thickness" DataValueField="Thickness" 
                        SkinID="DropDownList" Style="width: 115px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbxMapLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxSteelTapeLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px" onkeyup="MakeM1LengthSame();"></asp:TextBox >
                </td>
                <td>
                    <asp:TextBox ID="tbxVideoLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px" OnTextChanged="tbxVideoLength_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvMapSize" runat="server" ControlToValidate="tbxMapSize"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvMapSize_ServerValidate" SkinID="Validator" 
                        ValidationGroup="raData"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvSize" runat="server" ControlToValidate="tbxConfirmedSize" Display="Dynamic"
                        ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvConfirmedSize_ServerValidate" SkinID="Validator"
                        ValidationGroup="raData"></asp:CustomValidator>
                </td>
                <td>
                </td>
                <td>
                    <asp:CustomValidator ID="cvMapLength" runat="server" ControlToValidate="tbxMapLength"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvMapLength_ServerValidate" SkinID="Validator" 
                        ValidationGroup="raData"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvSteelTapeLengthHeader" runat="server" ControlToValidate="tbxSteelTapeLength"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvSteelTapeLengthHeader_ServerValidate" SkinID="Validator" 
                        ValidationGroup="raData">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="cvSteelHeader" runat="server" ControlToValidate="tbxSteelTapeLength" Display="Dynamic" ErrorMessage="Please provide a greater length."
                        OnServerValidate="cvValidLength_ServerValidate" SkinID="Validator" 
                        ValidationGroup="raData">
                    </asp:CustomValidator>
                </td>
                <td>
                     <asp:CustomValidator ID="cvVideoDistance" runat="server" ControlToValidate="tbxVideoLength"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvVideoDistance_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLaterals" runat="server" EnableViewState="True" SkinID="Label" Text="Laterals"></asp:Label>
                </td>
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
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlTotalLaterals" runat="server">
                        <contenttemplate>
                            <asp:TextBox style="WIDTH: 115px" id="tbxLaterals" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox> 
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel id="upnlLiveLaterals" runat="server">
                        <contenttemplate>
                            <asp:TextBox style="WIDTH: 115px" id="tbxLiveLaterals" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                        </contenttemplate>
                    </asp:UpdatePanel>
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
        
        <!-- Table element: 6 columns - Rehab Assessment Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblRehabAssessmentDetails" runat="server" SkinID="LabelTitle1" Text="Rehab Assessment Details" EnableViewState="True"></asp:Label>
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
                    <cc1:TabContainer ID="tcRaDetails" Width="730px" runat="server" ActiveTabIndex="2" CssClass="ajax_tabcontainer">
                        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General Data" OnClientClick="tpGeneralDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px; height: 220px; overflow-y: auto;">
                                
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
                                                <asp:Label ID="lblGeneralClientId" runat="server" SkinID="Label" Text="Client ID"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralSubArea" runat="server" SkinID="Label" Text="Sub Area"></asp:Label>
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
                                                <asp:TextBox ID="tbxGeneralClientId" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralSubArea" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralPreFlushDate" runat="server" SkinID="Label" Text="Pre-Flush Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralPreVideoDate" runat="server" SkinID="Label" Text="Pre-Video Date"></asp:Label>
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
                                                <telerik:RadDatePicker ID="tkrdpGeneralPreFlushDate" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralPreVideoDate" runat="server" Width="108px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
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
                                            <td style="height: 30px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpPrepData" runat="server" HeaderText="Prep Data" OnClientClick="tpPrepDataClientClick">
                            <HeaderTemplate>
                                Prep Data
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div style="width: 710px; height: 220px; overflow-y: auto;">
                                
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
                                                <asp:Label ID="lblPrepDataP1Completed" runat="server" EnableViewState="false" SkinID="Label" Text="P1 Completed"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPrepDataP1Date" runat="server" SkinID="Label" Text="P1 Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPrepDataRoboticPrepCompleted" runat="server" SkinID="Label" Text="Section Robotic Prep"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPrepDataRoboticPrepCompletedDate" runat="server" SkinID="Label" Text="Robotic Prep Completed Date"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxPrepDataP1Completed" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpPrepDataP1Date" runat="server" Width="108px" 
                                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">                                                    
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxPrepDataRoboticPrepCompleted" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td> 
                                                <telerik:RadDatePicker ID="tkrdpPrepDataRoboticPrepCompletedDate" runat="server" Width="108px" 
                                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>                                                               
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
                                                <asp:CustomValidator ID="cvRoboticPrepCompletedDate" runat="server" 
                                                    ControlToValidate="tkrdpPrepDataRoboticPrepCompletedDate" Display="Dynamic" 
                                                    ErrorMessage="Robotic Prep Completed is not checked, please delete this date." 
                                                    OnServerValidate="cvRoboticPrepCompletedDate_ServerValidate" SkinID="Validator" 
                                                    ValidationGroup="raData"></asp:CustomValidator>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
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
                                            <td style="width: 236px;">
                                                <asp:Label ID="lblPrepDataCXIsRemoved" runat="server" SkinID="Label" Text="CXI’s Removed"></asp:Label>&nbsp;
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
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxPrepDataCXIsRemoved" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>                                             
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
                                                <asp:CompareValidator ID="cvPrepDataCxisRemoved" runat="server" ControlToValidate="tbxPrepDataCXIsRemoved"
                                                    Display="Dynamic" ErrorMessage="Invalid format. (Please use an integer number)"
                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="raData"></asp:CompareValidator>
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
                                            <td style="height: 30px" colspan="5">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpM1Data" runat="server" HeaderText="M1 Data" OnClientClick="tpM1DataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px">
                                
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
                                                <asp:Label ID="lblM1DataM1Date" runat="server" SkinID="Label" Text="M1 Date"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblM1DataMeasurementsTakenBy" runat="server" SkinID="Label" Text="Measurements Taken By"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpM1DataM1Date" runat="server" Width="108px" 
                                                    SkinID="RadDatePicker" Culture="English (United States)"> 
                                                    <Calendar DayNameFormat="Short" ShowRowHeaders="False" 
                                                        UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                        ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" Width="">
                                                    </DateInput>
                                                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM1DataMeasurementsTakenBy" runat="server" SkinID="TextBox" Style="width: 226px"></asp:TextBox>
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
                                            <td colspan="2">
                                                <asp:Label ID="lblM1DataMaterial" runat="server" SkinID="Label" Text="Material"></asp:Label>
                                            </td>
                                            <td style="width: 236px">
                                                <asp:Label ID="lblM1DataSteelTapeThroughSewer" runat="server" SkinID="Label" Text="Steel Tape Through Sewer"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:DropDownList style="width: 226px" ID="ddlM1DataMaterial" runat="server" SkinID="DropDownList" DataSourceID="odsMaterialType" DataValueField="MaterialType" DataTextField="MaterialType">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox style="width: 108px" ID="tbxM1DataSteelTapeThroughSewer" runat="server" onkeyup="MakeLengthSame();" SkinID="TextBox"></asp:TextBox>                                                       
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvSteelTapeThroughSewer" runat="server" ControlToValidate="tbxM1DataSteelTapeThroughSewer" Display="Dynamic"
                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                    OnServerValidate="cvSteelTapeThroughSewer_ServerValidate" SkinID="Validator" 
                                                    ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvSteel" runat="server" ControlToValidate="tbxM1DataSteelTapeThroughSewer"
                                                    Display="Dynamic" ErrorMessage="Please provide a greater length." OnServerValidate="cvValidLength_ServerValidate"
                                                    SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
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
                                                <asp:Label ID="lblM1DataUsmhAddress" runat="server" SkinID="Label" Text="USMH Address"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataUsmhDepth" runat="server" SkinID="Label" Text="USMH Depth"></asp:Label>
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
                                                <asp:TextBox ID="tbxM1DataUsmhAddress" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhDepth" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
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
                                                <asp:CustomValidator ID="cvUsmhAddress" runat="server" ControlToValidate="tbxM1DataUsmhAddress"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhDepth" runat="server" ControlToValidate="tbxM1DataUsmhDepth"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
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
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth12" runat="server" SkinID="Label" Text="USMH Mouth 12:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth1" runat="server" SkinID="Label" Text="USMH Mouth 1:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth2" runat="server" SkinID="Label" Text="USMH Mouth 2:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth3" runat="server" SkinID="Label" Text="USMH Mouth 3:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth4" runat="server" SkinID="Label" Text="USMH Mouth 4:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth5" runat="server" SkinID="Label" Text="USMH Mouth 5:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth12" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox> 
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth1" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth2" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth3" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox> 
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth4" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth5" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth12" runat="server" ControlToValidate="tbxM1DataUsmhMouth12"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvUsmhMouth12Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth12" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth1" runat="server" ControlToValidate="tbxM1DataUsmhMouth1"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                    <asp:CustomValidator ID="cvUsmhMouth1Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth1" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth2" runat="server" ControlToValidate="tbxM1DataUsmhMouth2"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                    <asp:CustomValidator ID="cvUsmhMouth2Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth2" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth3" runat="server" ControlToValidate="tbxM1DataUsmhMouth3"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                    <asp:CustomValidator ID="cvUsmhMouth3Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth3" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth4" runat="server" ControlToValidate="tbxM1DataUsmhMouth4"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                    <asp:CustomValidator ID="cvUsmhMouth4Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth4" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth5" runat="server" ControlToValidate="tbxM1DataUsmhMouth5"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                    <asp:CustomValidator ID="cvUsmhMouth5Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth5" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
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
                                                <asp:Label ID="lblM1DataDsmhAddress" runat="server" SkinID="Label" Text="DSMH Address"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataDsmhdepth" runat="server" SkinID="Label" Text="DSMH Depth"></asp:Label>
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
                                                <asp:TextBox ID="tbxM1DataDsmhAddress" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhDepth" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
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
                                                <asp:CustomValidator ID="cvDsmhAddress" runat="server" ControlToValidate="tbxM1DataDsmhAddress"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhDepth" runat="server" ControlToValidate="tbxM1DataDsmhDepth"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
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
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth12" runat="server" SkinID="Label" Text="DSMH Mouth 12:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth1" runat="server" SkinID="Label" Text="DSMH Mouth 1:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth2" runat="server" SkinID="Label" Text="DSMH Mouth 2:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth3" runat="server" SkinID="Label" Text="DSMH Mouth 3:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth4" runat="server" SkinID="Label" Text="DSMH Mouth 4:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth5" runat="server" SkinID="Label" Text="DSMH Mouth 5:00"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm format.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth12" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth1" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth2" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth3" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth4" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth5" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth12" runat="server" ControlToValidate="tbxM1DataDsmhMouth12"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth12Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth12" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth1" runat="server" ControlToValidate="tbxM1DataDsmhMouth1"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth1Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth1" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth2" runat="server" ControlToValidate="tbxM1DataDsmhMouth2"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth2Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth2" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth3" runat="server" ControlToValidate="tbxM1DataDsmhMouth3"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth3Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth3" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth4" runat="server" ControlToValidate="tbxM1DataDsmhMouth4"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth4Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth4" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth5" runat="server" ControlToValidate="tbxM1DataDsmhMouth5"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth5Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="raData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth5" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
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
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataTrafficControl" runat="server" SkinID="Label" Text="Traffic Control"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataSiteDetails" runat="server" SkinID="Label" Text="Site Details"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataAccessType" runat="server" SkinID="Label" Text="Access Type"></asp:Label>
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
                                                <asp:DropDownList ID="ddlM1DataTrafficControl" runat="server" DataSourceID="odsTrafficControl"
                                                    DataTextField="TrafficControl" DataValueField="TrafficControl"
                                                    SkinID="DropDownListLookup" Style="width: 108px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlM1DataSiteDetails" runat="server" SkinID="DropDownListLookup" Style="width: 108px" 
                                                    DataSourceID="odsSiteDetails" DataTextField="SiteDetails" DataValueField="SiteDetails">                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlM1DataAccessType" runat="server" SkinID="DropDownListLookup" Style="width: 108px">
                                                    <asp:ListItem Text="" Value="(Select)"></asp:ListItem>
                                                    <asp:ListItem Text="Type 1 - Road" Value="Type 1 - Road"></asp:ListItem>
                                                    <asp:ListItem Text="Type 2 - Easement" Value="Type 2 - Easement"></asp:ListItem>
                                                    <asp:ListItem Text="Type 3 - Sp Easement" Value="Type 3 - Sp Easement"></asp:ListItem>
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
                                            <td>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvSiteDetails" runat="server" ControlToValidate="ddlM1DataSiteDetails"
                                                    Display="Dynamic" ErrorMessage="Please select a site detail."
                                                    OnServerValidate="cvSiteDetails_ServerValidate" SkinID="Validator" 
                                                    ValidationGroup="raM1Data"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <%--<asp:RequiredFieldValidator ID="rfvM1DataAccessType" runat="server" SkinID="Validator" 
                                                    ValidationGroup="raM1Data" ErrorMessage="Please select an access type." Display="Dynamic" 
                                                    ControlToValidate="ddlM1DataAccessType" InitialValue="(Select)"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM1DataPipeSizeChange" runat="server" SkinID="Label" Text="Pipe Size Change?"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataStandardBypass" runat="server" SkinID="Label" Text="Standard Bypass?"></asp:Label>
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
                                                <asp:CheckBox ID="ckbxM1DataPipeSizeChange" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxM1DataStandardBypass" runat="server" SkinID="CheckBox" />
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
                                            <td colspan="6" style="height: 7px">
                                            </td>
                                        </tr>                                       
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblM1DataStandardBypassComments" runat="server" SkinID="Label" Text="Standard Bypass Comments"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxM1DataStandardBypassComments" runat="server" SkinID="TextBoxMemo" Style="width: 698px" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblM1DataTrafficControlDetails" runat="server" SkinID="Label" Text="Traffic Control Details"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxM1DataTrafficControlDetails" runat="server" SkinID="TextBoxMemo" Style="width: 698px" Rows="4" TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:Label ID="lblM1DataMeasurementType" runat="server" SkinID="Label" Text="Measurement Type"></asp:Label>
                                            </td>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataMeasuredFromMH" runat="server" SkinID="LabelSmall" Text="Measured From MH"></asp:Label>
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlM1DataMeasurementType" runat="server" DataSourceID="odsMeasurementType"
                                                    DataTextField="MeasurementType" DataValueField="MeasurementType"
                                                    SkinID="DropDownListLookup" Style="width: 108px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlM1DataMeasuredFromMh" runat="server" SkinID="DropDownList" Style="width: 108px">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="USMH">USMH</asp:ListItem>
                                                    <asp:ListItem Value="DSMH">DSMH</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="tbxM1DataMeasuredFromMh" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                            <td colspan="6" style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataVideoDoneFromMH" runat="server" SkinID="LabelSmall" Text="Video Done From MH"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataToMH" runat="server" SkinID="Label" Text="To MH"></asp:Label>
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
                                                <asp:UpdatePanel ID="uplM1DataVideoDoneFromMh" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlM1DataVideoDoneFromMh" runat="server" SkinID="DropDownList"
                                                            Style="width: 108px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlM1DataVideoDoneFromMh_SelectedIndexChanged">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem Value="USMH">USMH</asp:ListItem>
                                                            <asp:ListItem Value="DSMH">DSMH</asp:ListItem>
                                                        </asp:DropDownList>
                                                       
                                                        <asp:TextBox ID="tbxM1DataVideoDoneFromMh" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                            Style="width: 108px" AutoPostBack="True"></asp:TextBox>
                                                     </ContentTemplate>
                                               </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upl1DataVideoDoneToMh" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlM1DataVideoDoneToMh" runat="server" SkinID="DropDownList"
                                                            Style="width: 108px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlM1DataVideoDoneToMh_SelectedIndexChanged" >
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem Value="USMH">USMH</asp:ListItem>
                                                            <asp:ListItem Value="DSMH">DSMH</asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                        <asp:TextBox ID="tbxM1DataVideoDoneToMh" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                            Style="width: 108px" AutoPostBack="True"></asp:TextBox>
                                                     </ContentTemplate>                                            
                                               </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="uplClearButton" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnClear" OnClick="btnClearOnClick" runat="server" SkinID="Button"
                                                            Text="Clear" Width="80px"></asp:Button>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
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
                                    
                                    <!-- Table element: 1 columns  - Lateral Measurement Info Title -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLateralMeasurementInfo" runat="server" SkinID="LabelTitle2" Text="Lateral Measurement Info"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height:10px">
                                            </td>
                                        </tr>
                                    </table>
                                                                    
                                    <!-- Table element: 1 columns  - Lateral Measurement Info Section -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upnlLaterals" runat="server">
                                                    <ContentTemplate>
                                                        <!-- Page element: 1 column - Grid Laterals -->
                                                        <asp:GridView ID="grdLaterals" runat="server" SkinID="GridViewInTabs" Width="710px" 
                                                        DataSourceID="odsLaterals" ShowFooter="True" OnDataBound="grdLaterals_DataBound" 
                                                        OnRowCommand="grdLaterals_RowCommand" OnRowDataBound="grdLaterals_RowDataBound"
                                                        OnRowUpdating="grdLaterals_RowUpdating" OnRowDeleting="grdLaterals_RowDeleting" 
                                                        AutoGenerateColumns="False" DataKeyNames="Lateral" OnRowEditing="grdLaterals_RowEditing">
                                                            <Columns>
                                                            
                                                                <asp:TemplateField HeaderText="Lateral" SortExpression="Lateral" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblLateral" runat="server" Text='<%# Eval("Lateral") %>'></asp:Label> 
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLateral" runat="server" Text='<%# Eval("Lateral") %>'></asp:Label> 
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Laterals" SortExpression="LateralID">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 8 columns - Lateral Data -->
                                                                        <table style="width: 570px" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 12px">
                                                                                    </td>
                                                                                    <td style="width: 91px">
                                                                                    </td>
                                                                                    <td style="width: 91px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLateralIdEdit" runat="server" SkinID="Label" Text="Lateral ID"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblClientInspectionNoEdit" runat="server" SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                                                    </td>
                                                                                    <td><asp:Label ID="lblClientLateralIdEdit" runat="server" SkinID="Label" Text="Client Lateral ID"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblMnEdit" runat="server" SkinID="Label" Text="MN#"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblContractYearEdit" runat="server" SkinID="Label" Text="Contract Year"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxLateralIdEdit" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("LateralID") %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientInspectionNoEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ClientInspectionNo") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientLateralIdEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ClientLateralID") %>' Width="82px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="tbxMnEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Mn") %>' Width="174px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxContractYearEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ContractYear") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:Label ID="lblClockPositionEdit" runat="server" SkinID="Label" Text="Clock Position"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSizeEdit" runat="server" SkinID="Label" Text="Size"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <table style="width: 92px" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 42px">
                                                                                                        <asp:Label ID="lblMaterialEdit" runat="server" SkinID="LabelSmall" Text="Material"></asp:Label>
                                                                                                    </td>
                                                                                                    <%--<td style="width: 50px">
                                                                                                        <asp:Button ID="btnMaterial" runat="server" SkinID="Button" Text="Update" EnableViewState="True" Width="45px"></asp:Button>
                                                                                                    </td>--%>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblConnectionTypeEdit" runat="server" SkinID="Label" Text="ConnectionType"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblJLFlangeTypeEdit" runat="server" SkinID="Label" Text="JL Flange Type"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" class="helpHint" alt="Help"  />
                                                                                            <b class="hint">Only used when Junction Lining Lateral</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLiveEdit" runat="server" SkinID="Label" Text="Live"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClockPositionEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ClockPosition") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxSizeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Size_") %>' Width="82px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList style="width: 82px" ID="ddlMaterialEdit" runat="server" SkinID="DropDownList" DataSourceID="odsMaterialType" DataValueField="MaterialType" DataTextField="MaterialType">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlConnectionTypeEdit" runat="server" SkinID="DropDownList" Style="width: 82px">
                                                                                            <asp:ListItem></asp:ListItem>
                                                                                            <asp:ListItem Value="Fact. Tee">Fact. Tee</asp:ListItem>
                                                                                            <asp:ListItem Value="Fact. Wye">Fact. Wye</asp:ListItem>
                                                                                            <asp:ListItem Value="H. Tee">H. Tee</asp:ListItem>
                                                                                            <asp:ListItem Value="H. Wye">H. Wye</asp:ListItem>
                                                                                            <asp:ListItem Value="S. Tee">S. Tee</asp:ListItem>
                                                                                            <asp:ListItem Value="S. Wye">S. Wye</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlFlangeEdit" runat="server" DataSourceID="odsFlange" DataTextField="Flange" DataValueField="Flange" 
                                                                                            SelectedValue='<%# GetFlange(Eval("Flange")) %>' SkinID="DropDownList" Width="82px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxJlLive" runat="server" SkinID="TextBoxReadOnly" Text="Live" Width="82px" ReadOnly="True"></asp:TextBox> 
                                                                                        <asp:DropDownList style="width: 82px" ID="ddlLiveEdit" runat="server" SkinID="DropDownListLookup" DataSourceID="odsLive" DataValueField="State" DataTextField="State">
                                                                                        </asp:DropDownList>
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
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvStateEdit" runat="server" SkinID="Validator" EnableViewState="True" 
                                                                                            ValidationGroup="AddLateralsUpdateSpecial" ErrorMessage="Please select a state." Display="Dynamic" 
                                                                                            ControlToValidate="ddlLiveEdit" InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblVideoDistanceEdit" runat="server" SkinID="LabelSmall" Text="Video Distance"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDistanceToCentreEdit" runat="server" SkinID="LabelSmall" Text="Distance To Centre"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblReverseSetupEdit" runat="server" SkinID="Label" Text="Reverse Setup"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTimeOpenedEdit" runat="server" SkinID="Label" Text="Opened"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblReinstateEdit" runat="server" SkinID="Label" Text="Brushed"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblV1InspectionEdit" runat="server" SkinID="Label" Text="V1 Inspection"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxVideoDistanceEdit" runat="server" SkinID="TextBox" Text='<%# GetDistance(Eval("VideoDistance")) %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxDistanceToCentreEdit" runat="server" SkinID="TextBox" Text='<%# GetDistance(Eval("DistanceToCentre")) %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxReverseSetupEdit" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("ReverseSetup")) %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxTimeOpenedEdit" runat="server" SkinID="TextBox" Text='<%# Eval("TimeOpened") %>' Width="82px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpReinstateEdit" runat="server" Width="82px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("Reinstate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpV1InspectionEdit" runat="server" Width="82px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("V1Inspection", "{0:d}") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>                                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator  ID="cvVideoDistance" runat="server" SkinID="Validator" ValidationGroup="AddLateralsUpdate" 
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                            Display="Dynamic" ControlToValidate="tbxVideoDistanceEdit" OnServerValidate="cvDistance_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvVideoDistanceRequiredEdit" runat="server" SkinID="Validator" ValidationGroup="AddLateralsUpdate" 
                                                                                            ErrorMessage="Please enter video distance." Display="Dynamic" ValidateEmptyText="true" 
                                                                                            ControlToValidate="tbxVideoDistanceEdit" OnServerValidate="cvVideoDistanceRequiredEdit_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvDistanceToCentre" runat="server" SkinID="Validator" ValidationGroup="AddLateralsUpdate" 
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic" 
                                                                                            ControlToValidate="tbxDistanceToCentreEdit" OnServerValidate="cvDistance_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvDistanceToCentreRequiredEdit" runat="server" SkinID="Validator" ValidationGroup="AddLateralsUpdate" 
                                                                                            ErrorMessage="Please enter distance to centre." Display="Dynamic" ValidateEmptyText="true"
                                                                                            ControlToValidate="tbxDistanceToCentreEdit" OnServerValidate="cvDistanceToCentreRequiredEdit_ServerValidate">
                                                                                        </asp:CustomValidator>
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
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr> 
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRequiresRoboticPrepEdit" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRequiresRoboticPrepDateEdit" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep Date"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblHoldClientIssueEdit" runat="server" SkinID="LabelSmall" Text="Hold - Client Issue"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblHoldLFSIssueEdit" runat="server" SkinID="LabelSmall" Text="Hold - LFS Issue"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDyeTestReqEdit" runat="server" SkinID="LabelSmall" Text="Dye Test Req'd"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDyeTestCompleteEdit" runat="server" SkinID="LabelSmall" Text="Dye Test Complete"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxRequiresRoboticPrepEdit" runat="server" Checked='<%# Eval("RequiresRoboticPrep") %>' SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpRequiresRoboticPrepDateEdit" runat="server" 
                                                                                            Calendar-DayNameFormat="Short" Calendar-ShowRowHeaders="false" 
                                                                                            DbSelectedDate='<%# Eval("RequiresRoboticPrepDate") %>' SkinID="RadDatePicker" Width="82px">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxHoldClientIssueEdit" runat="server" Checked='<%# Eval("HoldClientIssue") %>' SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxHoldLFSIssueEdit" runat="server" Checked='<%# Eval("HoldLFSIssue") %>' SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxDyeTestReqEdit" runat="server" Checked='<%# Eval("DyeTestReq") %>' SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpDyeTestCompleteEdit" runat="server" 
                                                                                            Calendar-DayNameFormat="Short" Calendar-ShowRowHeaders="false" 
                                                                                            DbSelectedDate='<%# Eval("DyeTestComplete") %>' SkinID="RadDatePicker" Width="82px">
                                                                                        </telerik:RadDatePicker>
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
                                                                                        <asp:CustomValidator ID="cvRequiresRoboticPrepDate" runat="server" 
                                                                                            ControlToValidate="tkrdpRequiresRoboticPrepDateEdit" Display="Dynamic" 
                                                                                            ErrorMessage="Requires Robotic Prep is not checked, please delete this date." 
                                                                                            OnServerValidate="cvRequiresRoboticPrepDate_ServerValidate" SkinID="Validator" 
                                                                                            ValidationGroup="AddLateralsUpdate"></asp:CustomValidator>
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
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblCommentsEdit" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxCommentsEdit" runat="server" SkinID="TextBoxMemo" Text='<%# Eval("Comments") %>' EnableViewState="True" Width="540px" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 30px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 6 columns - New Lateral Data -->
                                                                        <table style="width: 570px" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 12px">
                                                                                    </td>
                                                                                    <td style="width: 91px">
                                                                                    </td>
                                                                                    <td style="width: 91px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewLateralId" runat="server" SkinID="Label" Text="Lateral ID"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewClientInspectionNo" runat="server" SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewClientLateralId" runat="server" SkinID="Label" Text="Client Lateral ID"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblNewMn" runat="server" SkinID="Label" Text="MN#"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewContractYear" runat="server" SkinID="Label" Text="Contract Year"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewLateralId" runat="server" SkinID="TextBoxReadOnly" Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewClientInspectionNo" runat="server" SkinID="TextBox" Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewClientLateralId" runat="server" SkinID="TextBox" Width="82px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="tbxNewMn" runat="server" SkinID="TextBox" Width="174px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewContractYear" runat="server" SkinID="TextBoxReadOnly" Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvLateralId" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd" ErrorMessage="Error" Display="Dynamic" 
                                                                                            ControlToValidate="tbxNewLateralId" OnServerValidate="cvLateralId_ServerValidate">
                                                                                        </asp:CustomValidator>
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
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewVideoDistance" runat="server" SkinID="LabelSmall" Text="Video Distance"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                             <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewClockPosition" runat="server" SkinID="Label" Text="Clock Position"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewSize" runat="server" SkinID="Label" Text="Size"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewMaterial" runat="server" SkinID="Label" Text="Material"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewConnectionType" runat="server" SkinID="Label" Text="Connection Type"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewLive" runat="server" SkinID="Label" Text="Live"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewVideoDistance" runat="server" SkinID="TextBox" Text='<%# Eval("VideoDistance") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewClockPosition" runat="server" SkinID="TextBox" Text='<%# Eval("ClockPosition") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewSize" runat="server" SkinID="TextBox" Width="82px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList style="width: 82px" ID="ddlNewMaterial" runat="server" SkinID="DropDownList" DataSourceID="odsMaterialType" DataValueField="MaterialType" DataTextField="MaterialType"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlNewConnectionType" runat="server" SkinID="DropDownListLookup" Style="width: 82px">
                                                                                            <asp:ListItem></asp:ListItem>
                                                                                            <asp:ListItem Value="Fact. Tee">Fact. Tee</asp:ListItem>
                                                                                            <asp:ListItem Value="Fact. Wye">Fact. Wye</asp:ListItem>
                                                                                            <asp:ListItem Value="H. Tee">H. Tee</asp:ListItem>
                                                                                            <asp:ListItem Value="H. Wye">H. Wye</asp:ListItem>
                                                                                            <asp:ListItem Value="S. Tee">S. Tee</asp:ListItem>
                                                                                            <asp:ListItem Value="S. Wye">S. Wye</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList style="width: 82px" ID="ddlNewLive" runat="server" SkinID="DropDownListLookup" DataSourceID="odsLive" DataValueField="State" DataTextField="State"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvNewVideoDistance" runat="server" SkinID="Validator"
                                                                                            ValidationGroup="AddLateralsAdd" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                            Display="Dynamic" ControlToValidate="tbxNewVideoDistance" OnServerValidate="cvDistance_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvNewVideoDistanceRequired" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd" 
                                                                                            ErrorMessage="Please enter video distance." Display="Dynamic" ValidateEmptyText="true"
                                                                                            ControlToValidate="tbxNewVideoDistance" OnServerValidate="cvNewVideoDistanceRequired_ServerValidate">
                                                                                        </asp:CustomValidator>
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
                                                                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" SkinID="Validator" EnableViewState="True" 
                                                                                            ValidationGroup="AddLateralsAdd" ErrorMessage="Please select a state." Display="Dynamic" 
                                                                                            ControlToValidate="ddlNewLive" InitialValue="(Select)">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewDistanceToCentre" runat="server" SkinID="LabelSmall" Text="Distance To Centre"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                             <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td colspan="4">
                                                                                        <asp:Label ID="lblNewComments" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewV1Inspection" runat="server" SkinID="Label" Text="V1 Inspection"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewDistanceToCentre" runat="server" SkinID="TextBox" Text='<%# Eval("DistanceToCentre") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="4">
                                                                                        <asp:TextBox ID="tbxNewComments" runat="server" SkinID="TextBoxMemo" Text='<%# Eval("Comments") %>' EnableViewState="True" Width="357px" Rows="1"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpNewV1Inspection" runat="server" Width="82px" SkinID="RadDatePicker" DbSelectedDate='<%# Eval("V1Inspection", "{0:d}") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvNewDistanceToCentre" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd" 
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" Display="Dynamic"
                                                                                            ControlToValidate="tbxNewDistanceToCentre" OnServerValidate="cvDistance_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvNewDistanceToCentreRequired" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd" 
                                                                                            ErrorMessage="Please enter distance to centre." Display="Dynamic" ValidateEmptyText="true"
                                                                                            ControlToValidate="tbxNewDistanceToCentre" OnServerValidate="cvNewDistanceToCentreRequired_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td colspan="7">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="6">
                                                                                        <asp:CustomValidator ID="cvMeasuredFromMH" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd" 
                                                                                            ErrorMessage="Measured From MH is not defined yet, please define it before adding laterals." EnableViewState="True"
                                                                                            Display="Dynamic" ControlToValidate="ddlNewLive" OnServerValidate="cvMeasuredFromMH_ServerValidate">
                                                                                        </asp:CustomValidator> 
                                                                                        <asp:CustomValidator ID="cvLateralsMaxNumber" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd" 
                                                                                            ErrorMessage="The maximum laterals amount was reached, no more laterals can be added." Display="Dynamic" EnableViewState="True"
                                                                                            OnServerValidate="cvLateralsMaxNumber_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr> 
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRequiresRoboticPrepNew" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRequiresRoboticPrepDateNew" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep Date"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblHoldClientIssueNew" runat="server" SkinID="LabelSmall" Text="Hold - Client Issue"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblHoldLFSIssueNew" runat="server" SkinID="LabelSmall" Text="Hold - LFS Issue"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDyeTestReqNew" runat="server" SkinID="LabelSmall" Text="Dye Test Req'd"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDyeTestCompleteNew" runat="server" SkinID="LabelSmall" Text="Dye Test Complete"></asp:Label>
                                                                                    </td>
                                                                                    <td> </td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxRequiresRoboticPrepNew" runat="server" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpRequiresRoboticPrepDateNew" runat="server" 
                                                                                            Calendar-DayNameFormat="Short" Calendar-ShowRowHeaders="false" 
                                                                                             SkinID="RadDatePicker" Width="82px">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxHoldClientIssueNew" runat="server" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxHoldLFSIssueNew" runat="server" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxDyeTestReqNew" runat="server" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpDyeTestCompleteNew" runat="server" 
                                                                                            Calendar-DayNameFormat="Short" Calendar-ShowRowHeaders="false" 
                                                                                             SkinID="RadDatePicker" Width="82px">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td></td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvRequiresRoboticPrepDateNew" runat="server" 
                                                                                            ControlToValidate="tkrdpRequiresRoboticPrepDateNew" Display="Dynamic" 
                                                                                            ErrorMessage="Requires Robotic Prep is not checked, please delete this date." 
                                                                                            OnServerValidate="cvRequiresRoboticPrepDateNew_ServerValidate" SkinID="Validator" 
                                                                                            ValidationGroup="AddLateralsAdd"></asp:CustomValidator>
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
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr> 
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblJLFlangeTypeNew" runat="server" SkinID="Label" Text="JL Flange Type"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" class="helpHint" alt="Help"  />
                                                                                            <b class="hint">Only used when Junction Lining Lateral</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlFlangeNew" runat="server" DataSourceID="odsFlange"
                                                                                            DataTextField="Flange" DataValueField="Flange" SkinID="DropDownList" Width="82px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>
                                                                        <table style="width: 570px" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 91px">
                                                                                    </td>
                                                                                    <td style="width: 91px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 92px">
                                                                                    </td>
                                                                                    <td style="width: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLateralId" runat="server" SkinID="Label" Text="Lateral ID"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblClientInspectionNo" runat="server" SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblClientLateralId" runat="server" SkinID="Label" Text="Client Lateral ID"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblMn" runat="server" SkinID="Label" Text="MN#"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblContractYear" runat="server" SkinID="Label" Text="Contract Year"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxLateralId" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("LateralID") %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientInspectionNo" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientInspectionNo") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientLateralId" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientLateralID") %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="tbxMn" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Mn") %>' Width="174px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxContractYear" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("ContractYear") %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:Label ID="lblClockPosition" runat="server" SkinID="Label" Text="Clock Position"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSize" runat="server" SkinID="Label" Text="Size"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMaterial" runat="server" SkinID="Label" Text="Material"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblConnectionType" runat="server" SkinID="Label" Text="Connection Type"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblJLFlangeType" runat="server" SkinID="Label" Text="JL Flange Type"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLive" runat="server" SkinID="Label" Text="Live"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClockPosition" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("ClockPosition") %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxSize" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Size_") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxMaterial" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("MaterialType") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxConnectionType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("ConnectionType") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxJLFlangeType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Flange") %>' Width="82px" ReadOnly="True"></asp:TextBox>                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxLive" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Live") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblVideoDistance" runat="server" SkinID="Label" Text="Video Distance"></asp:Label>
                                                                                    </td>                                                                             
                                                                                    <td>
                                                                                        <asp:Label ID="lblDistanceToCentre" runat="server" SkinID="LabelSmall" Text="Distance To Centre"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblReverseSetup" runat="server" SkinID="Label" Text="Reverse Setup"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTimeOpened" runat="server" SkinID="Label" Text="Opened"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblReinstate" runat="server" SkinID="Label" Text="Brushed"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblV1Inspection" runat="server" SkinID="Label" Text="V1 Inspection"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>   
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxVideoDistance" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("VideoDistance")) %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>                                                                                
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxDistanceToCentre" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("DistanceToCentre")) %>' Width="81px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>                                                                                        
                                                                                    <td>
                                                                                        <asp:UpdatePanel ID="upnlLateralReverseSetup" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:TextBox ID="tbxReverseSetup" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("ReverseSetup")) %>' Width="81px" ReadOnly="True"></asp:TextBox> 
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxTimeOpened" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("TimeOpened") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxReinstate" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Reinstate", "{0:d}") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxV1Inspection" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("V1Inspection", "{0:d}") %>' Width="82px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>                                                                                
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRequiresRoboticPrep" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRequiresRoboticPrepDate" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep Date"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblHoldClientIssue" runat="server" SkinID="LabelSmall" Text="Hold - Client Issue"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblHoldLFSIssue" runat="server" SkinID="LabelSmall" Text="Hold - LFS Issue"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDyeTestReq" runat="server" SkinID="LabelSmall" Text="Dye Test Req'd"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDyeTestComplete" runat="server" SkinID="LabelSmall" Text="Dye Test Complete"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxRequiresRoboticPrep" runat="server" Checked='<%# Eval("RequiresRoboticPrep") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRequiresRoboticPrepDate" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("RequiresRoboticPrepDate", "{0:d}") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxHoldClientIssue" runat="server" Checked='<%# Eval("HoldClientIssue") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxHoldLFSIssue" runat="server" Checked='<%# Eval("HoldLFSIssue") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="ckbxDyeTestReq" runat="server" Checked='<%# Eval("DyeTestReq") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxDyeTestComplete" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("DyeTestComplete", "{0:d}") %>' Width="81px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxComments" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Comments") %>' EnableViewState="True" Width="540px" ReadOnly="True" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>                                                                                
                                                                                <tr>
                                                                                    <td style="height: 30px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="570px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Line lateral?">                                                                
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="cbxJlEdit" runat="server" Checked='<%# Eval("LineLateral") %>' SkinID="CheckBox" />
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center">
                                                                                    <asp:CheckBox ID="cbxNewJl" runat="server"  SkinID="CheckBox" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                           
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxJl" runat="server" Checked='<%# Eval("LineLateral") %>' Enabled="false" SkinID="CheckBox" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="" SortExpression="InProject">                                                                
                                                                    <EditItemTemplate>
<%--                                                                        <asp:CheckBox ID="cbxInProject" runat="server" Checked='<%# Eval("InProject") %>' Enabled="false" SkinID="CheckBox" />
--%>                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center">
                                                                                    <%--<asp:CheckBox ID="cbxInProject" runat="server" SkinID="CheckBox" Enabled="false" Checked="true" />--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                           
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <%--<asp:CheckBox ID="cbxInProjectI" runat="server" Checked='<%# Eval("InProject") %>' Enabled="false" SkinID="CheckBox" />--%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png"
                                                                                            CommandName="Update"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png"
                                                                                            CommandName="Cancel"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png" CommandName="Add"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"
                                                                                            CommandName="Edit"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"
                                                                                            CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this lateral?");'>
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>                                                            
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView> 
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>                
                                            </td>
                                        </tr>
                                    </table>
                                    
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
                        
                        
                        
                        <cc1:TabPanel ID="tpComments" runat="server" HeaderText="Comments" OnClientClick="tpCommentDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 220px; overflow-y: auto;">
                                    <!-- Table element: 6 columns  -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 148px">
                                            </td>
                                            <td style="width: 90px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblCommentsDataComments" runat="server" EnableViewState="True" SkinID="Label" Text="Comments Summary"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlComments" runat="server">
                                                    <contenttemplate>
                                                        <asp:Button id="btnComments" onclick="btnCommentsOnClick" runat="server" SkinID="Button" Text="Update" EnableViewState="True" Width="80px" __designer:wfdid="w15"></asp:Button> 
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxCommentsDataComments" runat="server" Rows="20" SkinID="TextBoxMemo" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
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
                    <asp:ObjectDataSource ID="odsTrafficControl" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningM1TrafficControlList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="trafficControl" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSiteDetails" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningM1SiteDetailsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="siteDetails" Type="String" />
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
                    <asp:ObjectDataSource ID="odsLive" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.LateralStateList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="state" Type="String" />
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
                    <asp:ObjectDataSource ID="odsLaterals" runat="server" SelectMethod="GetLateralDetails"
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.RehabAssessment.ra_edit" DeleteMethod="DummyRaAddLateralsNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyRaAddLateralsNew" InsertMethod="DummyRaAddLateralsNew"
                        OldValuesParameterFormatString="original_{0}">     
                        <DeleteParameters>
                            <asp:Parameter Name="Lateral" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Lateral" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Lateral" Type="Int32" />
                        </InsertParameters>                  
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsMeasurementType" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningM1MeasurementTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="measurementType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsThicknessList" runat="server" CacheDuration="120" 
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.CWP.Assets.LfsAssetSewerSectionThicknessList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="thickness" Type="String" />
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
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfSectionId" runat="server" />
                    <asp:HiddenField ID="hdfFlowOrderId" runat="server" />   
                    <asp:HiddenField ID="hdfWorkIdJl" runat="server" />   
                    <asp:HiddenField ID="hdfErrorFieldList" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Conten5" ContentPlaceHolderID="FooterPlaceHolder" runat="server">
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