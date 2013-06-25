<%@ Page Language="C#" MasterPageFile="../../mForm8.master" AutoEventWireup="true" CodeBehind="fl_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <script language="javascript" type="text/javascript">
 
        function cbxSelectedClick(evt){
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var parentTagName = "table"
            var parent = src.parentNode;
			
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            			
            var allSelect = true;
            
            var childChkBoxes = parent.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;

            if (src.id != "ctl00_ContentPlaceHolder_tcFlDetails_tpWetOut_cbxlSectionId_0" && src.id != "ctl00_ContentPlaceHolder_tcFlDetails_tpInversionCure_cbxlInversionDataSectionId_0") {
			
				for (i = 1; i < childChkBoxCount; i++) {
					if (childChkBoxes[i].type == "checkbox") {
						if (childChkBoxes[i].checked != true) 
							allSelect = false;
					}
				}
				
				if (allSelect == true) {
					childChkBoxes[0].checked = true;
				}
				else {
					childChkBoxes[0].checked = false;
				}
			}
			else	
			{
				if (childChkBoxes[0].checked == true) {
					for (i = 1; i < childChkBoxCount; i++) {
						if (childChkBoxes[i].type == "checkbox") {
						
							childChkBoxes[i].checked = true;
						}
					}
				}
				else	
				{
					for (i = 1; i < childChkBoxCount; i++) {
						if (childChkBoxes[i].type == "checkbox") {
						
							childChkBoxes[i].checked = false;
						}
					}
				}
			}

			return true;
        }
    </script>

    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Full Length Lining Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                <td style="width: 10px">
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
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
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
                    <asp:TextBox ID="tbxFlowSectionId" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>  
                    <cc1:AutoCompleteExtender ID="aceUsmh" runat="server" UseContextKey="true" CompletionSetCount="12"
                        MinimumPrefixLength="2" ServiceMethod="GetMHList" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                        TargetControlID="tbxUSMH" SkinID="AutoCompleteExtender">
                    </cc1:AutoCompleteExtender>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
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
                        ValidationGroup="flData">USMH and DSMH must be different.</asp:CompareValidator>
                    <asp:RegularExpressionValidator ID="regexpUSMH" runat="server" Display="Dynamic" SkinID="Validator" ValidationGroup="flData" ErrorMessage="Please use a valid string: a-z A-Z 0-9 - _ ' ," ControlToValidate="tbxUSMH" ValidationExpression="^[-a-zA-Z0-9',._\s]{0,50}$" />
                </td>
                <td>
                    <asp:CompareValidator ID="cvDsmhUsmh" runat="server" ControlToCompare="tbxUSMH" ControlToValidate="tbxDSMH"
                        Display="Dynamic" ErrorMessage="CompareValidator" Operator="NotEqual" SkinID="Validator"
                        ValidationGroup="flData">DSMH and USMH must be different.</asp:CompareValidator>
                    <asp:RegularExpressionValidator ID="regexpDSMH" runat="server" Display="Dynamic" SkinID="Validator" ValidationGroup="flData" ErrorMessage="Please use a valid string: a-z A-Z 0-9 - _ ' ," ControlToValidate="tbxDSMH" ValidationExpression="^[-a-zA-Z0-9',._\s]{0,50}$" />
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
                    <asp:TextBox ID="tbxMapSize" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 95px"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlConfirmedSize" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxConfirmedSize" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px" onkeyup="SetValueInThickness();"></asp:TextBox>                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlThickness" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlThickness" runat="server" DataMember="DefaultView" AutoPostBack="true" 
                                DataSourceID="odsThicknessList" DataTextField="Thickness" DataValueField="Thickness" 
                                SkinID="DropDownList" Style="width: 115px" OnSelectedIndexChanged="ddlThickness_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate> 
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:TextBox ID="tbxMapLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlSteelTapeLength" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tbxSteelTapeLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px" onkeyup="MakeM1LengthSame();" AutoPostBack="true"></asp:TextBox>                            
                        </ContentTemplate> 
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:TextBox ID="tbxVideoLength" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 115px" OnTextChanged="tbxVideoLength_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvMapSize" runat="server" ControlToValidate="tbxMapSize"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvMapSize_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvSize" runat="server" ControlToValidate="tbxConfirmedSize"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvConfirmedSize_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                </td>
                <td>
                    
                    <asp:RequiredFieldValidator ID="rfvWetOutDataTubeThickness" runat="server" 
                        SkinID="Validator" ValidationGroup="flWetOutData" ErrorMessage="Please select a thickness."
                        Display="Dynamic" ControlToValidate="ddlThickness" 
                        InitialValue=""></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvMapLength" runat="server" ControlToValidate="tbxMapLength"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvMapLength_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvSteelTapeLengthHeader" runat="server" ControlToValidate="tbxSteelTapeLength"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvSteelTapeLengthHeader_ServerValidate" SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvSteelHeader" runat="server" ControlToValidate="tbxSteelTapeLength"
                        Display="Dynamic" ErrorMessage="Please provide a greater length." OnServerValidate="cvValidLength_ServerValidate"
                        SkinID="Validator" ValidationGroup="raData"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvVideoDistance" runat="server" ControlToValidate="tbxVideoLength"
                        Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                        OnServerValidate="cvVideoDistance_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
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
                    <asp:UpdatePanel ID="upnlTotalLaterals" runat="server">
                        <ContentTemplate>
                            <asp:TextBox Style="width: 115px" ID="tbxLaterals" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" ></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlLiveLaterals" runat="server">
                        <ContentTemplate>
                            <asp:TextBox Style="width: 115px" ID="tbxLiveLaterals" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" ></asp:TextBox>
                        </ContentTemplate>
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
        
        <!-- Table element: 6 columns - Full Length Lining Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblFullLengthLiningDetails" runat="server" SkinID="LabelTitle1" Text="Full Length Lining Details" EnableViewState="True"></asp:Label>
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
                    <cc1:TabContainer ID="tcFlDetails" runat="server" Width="730px" 
                        ActiveTabIndex="6" CssClass="ajax_tabcontainer">
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General Data" OnClientClick="tpGeneralDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
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
                                                <telerik:RadDatePicker ID="tkrdpGeneralPreFlushDate" runat="server" Width="108px"
                                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="tkrdpGeneralPreFlushDateReadOnly" runat="server" SkinID="RadDatePicker"
                                                    Width="108px" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short"
                                                    DateInput-ReadOnly="true" Calendar-EnableNavigation="False" Calendar-EnableMonthYearFastNavigation="false"
                                                    Calendar-PresentationType="Preview" Calendar-Enabled="false">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralPreVideoDate" runat="server" Width="108px"
                                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                                <telerik:RadDatePicker ID="tkrdpGeneralPreVideoDateReadOnly" runat="server" SkinID="RadDatePicker"
                                                    Width="108px" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short"
                                                    DateInput-ReadOnly="true" Calendar-EnableNavigation="False" Calendar-EnableMonthYearFastNavigation="false"
                                                    Calendar-PresentationType="Preview" Calendar-Enabled="false">
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
                                                <asp:Label ID="lblGeneralProposedLiningDate" runat="server" SkinID="LabelSmall" Text="Proposed Lining Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDeadlineLiningDate" runat="server" SkinID="LabelSmall" Text="Deadline Lining Date"></asp:Label>
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
                                                <telerik:RadDatePicker ID="tkrdpGeneralProposedLiningDate" runat="server" Width="108px"
                                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="tkrdpGeneralDeadlineLiningDate" runat="server" Width="108px"
                                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
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
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralP1Date" runat="server" SkinID="Label" Text="P1 Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralM1Date" runat="server" SkinID="Label" Text="M1 Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralM2Date" runat="server" SkinID="Label" Text="M2 Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralInstallDate" runat="server" SkinID="Label" Text="Install Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralFinalVideo" runat="server" SkinID="Label" Text="Final Video"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>                                                
                                                <asp:UpdatePanel ID="upnlGeneralP1Date" runat="server">
                                                    <ContentTemplate>                                                           
                                                        <telerik:RadDatePicker ID="tkrdpGeneralP1Date" runat="server" SkinID="RadDatePicker" 
                                                            Width="108px" Calendar-ShowRowHeaders="false" 
                                                            Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpGeneralP1Date_SelectedDateChanged">
                                                            <dateinput autopostback="True">
                                                            </dateinput>
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x">
                                                            </calendar>
                                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                                        </telerik:RadDatePicker>                                                        
                                                     </ContentTemplate>
                                                </asp:UpdatePanel> 
                                            </td>
                                            <td>                                                
                                                <asp:UpdatePanel ID="upnlGeneralM1Date" runat="server">
                                                    <ContentTemplate>                                                           
                                                        <telerik:RadDatePicker ID="tkrdpGeneralM1Date" runat="server" SkinID="RadDatePicker" 
                                                            Width="108px" Calendar-ShowRowHeaders="false" 
                                                            Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpGeneralM1Date_SelectedDateChanged">
                                                            <dateinput autopostback="True">
                                                            </dateinput>
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x">
                                                            </calendar>
                                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                                        </telerik:RadDatePicker>                                                        
                                                     </ContentTemplate>
                                                </asp:UpdatePanel> 
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnlGeneralM2Date" runat="server">
                                                    <ContentTemplate>                                                           
                                                        <telerik:RadDatePicker ID="tkrdpGeneralM2Date" runat="server" SkinID="RadDatePicker" 
                                                            Width="108px" Calendar-ShowRowHeaders="false" 
                                                            Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpGeneralM2Date_SelectedDateChanged">
                                                            <dateinput autopostback="True">
                                                            </dateinput>
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x">
                                                            </calendar>
                                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                                        </telerik:RadDatePicker>                                                        
                                                     </ContentTemplate>
                                                </asp:UpdatePanel> 
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnlGeneralInstallDate" runat="server">
                                                    <ContentTemplate>                                                           
                                                        <telerik:RadDatePicker ID="tkrdpGeneralInstallDate" runat="server" SkinID="RadDatePicker" 
                                                            Width="108px" Calendar-ShowRowHeaders="false" 
                                                            Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdptkrdpGeneralInstallDate_SelectedDateChanged">
                                                            <dateinput autopostback="True">
                                                            </dateinput>
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x">
                                                            </calendar>
                                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                                        </telerik:RadDatePicker>                                                        
                                                     </ContentTemplate>
                                                </asp:UpdatePanel>                                                  
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnlGeneralFinalVideo" runat="server">
                                                    <ContentTemplate>                                                         
                                                        <telerik:RadDatePicker ID="tkrdpGeneralFinalVideo" runat="server" SkinID="RadDatePicker" 
                                                            Width="108px" Calendar-ShowRowHeaders="false" 
                                                            Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpGeneralFinalVideo_SelectedDateChanged">
                                                            <dateinput autopostback="True">
                                                            </dateinput>
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x">
                                                            </calendar>
                                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                                        </telerik:RadDatePicker>   
                                                     </ContentTemplate>
                                                </asp:UpdatePanel>   
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
                                                <asp:Label ID="lblGeneralIssueIdentified" runat="server" SkinID="Label" Text="Issue Identified?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralLfsIssue" runat="server" SkinID="Label" Text="LFS Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralClientIssue" runat="server" SkinID="Label" Text="Client Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralSalesIssue" runat="server" SkinID="Label" Text="Sales Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralIssueGivenToClient" runat="server" SkinID="LabelSmall" Text="Issue Given To Client?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralIssueInvestigation" runat="server" SkinID="Label" Text="Issue Investigation?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralIssueIdentified" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralLfsIssue" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralClientIssue" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralSalesIssue" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralIssueGivenToClient" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralIssueInvestigation" runat="server" SkinID="CheckBox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralIssueResolved" runat="server" SkinID="Label" Text="Issue Resolved?"></asp:Label>
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
                                                <asp:CheckBox ID="ckbxGeneralIssueResolved" runat="server" SkinID="CheckBox" />
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
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
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
                                                <asp:UpdatePanel ID="upnlPrepDataP1Date" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadDatePicker ID="tkrdpPrepDataP1Date" runat="server" SkinID="RadDatePicker"
                                                            Width="108px" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpPrepDataP1Date_SelectedDateChanged">
                                                        </telerik:RadDatePicker>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
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
                                                    ValidationGroup="flData"></asp:CustomValidator>
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Background_Separator" style="height: 2px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 6 columns  -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
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
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxPrepDataCXIsRemoved" runat="server" SkinID="TextBox" Style="width:108px"></asp:TextBox>				                                                                                
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
                                                <asp:CompareValidator ID="cvPrepDataCxisRemoved" runat="server" ControlToValidate="tbxPrepDataCXIsRemoved" Display="Dynamic" 
                                                    ErrorMessage="Invalid format. (Please use an integer number)" Operator="DataTypeCheck" 
                                                    SkinID="Validator" Type="Integer" ValidationGroup="flData"></asp:CompareValidator>
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
                                            <td style="height: 30px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpM1Data" runat="server" HeaderText="M1 Data" OnClientClick="tpM1DataClientClick">
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
                                                <asp:UpdatePanel ID="upnlM1DataM1Date" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadDatePicker ID="tkrdpM1DataM1Date" runat="server" Width="108px" 
                                                            SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpM1DataM1Date_SelectedDateChanged">
                                                        </telerik:RadDatePicker>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                
                                            </td>
                                            <td>
                                            <td>
                                            </td>
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
                                            <td>
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
                                            <td>
                                                <asp:DropDownList style="width: 226px" ID="ddlM1DataMaterial" runat="server" SkinID="DropDownList" DataSourceID="odsMaterialType" DataValueField="MaterialType" DataTextField="MaterialType">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox Style="width: 108px" ID="tbxM1DataSteelTapeThroughSewer" runat="server" SkinID="TextBox" onkeyup="MakeLengthSame();"></asp:TextBox>
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
                                                <asp:CustomValidator ID="cvDistance" runat="server" ControlToValidate="tbxM1DataSteelTapeThroughSewer"
                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                    OnServerValidate="cvSteelTapeLengthHeader_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvSteel" runat="server" ControlToValidate="tbxM1DataSteelTapeThroughSewer"
                                                    Display="Dynamic" ErrorMessage="Please provide a greater length." OnServerValidate="cvValidLength_ServerValidate"
                                                    SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
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
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhDepth" runat="server" ControlToValidate="tbxM1DataUsmhDepth"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
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
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvUsmhMouth12Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth12" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth1" runat="server" ControlToValidate="tbxM1DataUsmhMouth1"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                    <asp:CustomValidator ID="cvUsmhMouth1Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth1" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth2" runat="server" ControlToValidate="tbxM1DataUsmhMouth2"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvUsmhMouth2Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth2" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth3" runat="server" ControlToValidate="tbxM1DataUsmhMouth3"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvUsmhMouth3Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth3" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth4" runat="server" ControlToValidate="tbxM1DataUsmhMouth4"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvUsmhMouth4Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataUsmhMouth4" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvUsmhMouth5" runat="server" ControlToValidate="tbxM1DataUsmhMouth5"
                                                    Display="Dynamic" ErrorMessage="USMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoUsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvUsmhMouth5Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
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
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhDepth" runat="server" ControlToValidate="tbxM1DataDsmhDepth"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
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
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth12Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth12" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth1" runat="server" ControlToValidate="tbxM1DataDsmhMouth1"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth1Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth1" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth2" runat="server" ControlToValidate="tbxM1DataDsmhMouth2"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth2Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth2" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth3" runat="server" ControlToValidate="tbxM1DataDsmhMouth3"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth3Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth3" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth4" runat="server" ControlToValidate="tbxM1DataDsmhMouth4"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data"
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth4Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
                                                    Display="Dynamic" ControlToValidate="tbxM1DataDsmhMouth4" OnServerValidate="cvDistance2_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvDsmhMouth5" runat="server" ControlToValidate="tbxM1DataDsmhMouth5"
                                                    Display="Dynamic" ErrorMessage="DSMH is not defined, please delete this data."
                                                    OnServerValidate="cvNoDsmh_ServerValidate" SkinID="Validator" ValidationGroup="flData"></asp:CustomValidator>
                                                <asp:CustomValidator ID="cvDsmhMouth5Distance" runat="server" SkinID="Validator"
                                                    ValidationGroup="flData" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ymm)"
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
                                                <asp:Label ID="lblAccessType" runat="server" SkinID="Label" Text="Access Type"></asp:Label>
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
                                                    DataTextField="TrafficControl" DataValueField="TrafficControl" SkinID="DropDownListLookup"
                                                    Style="width: 108px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlM1DataSiteDetails" runat="server" SkinID="DropDownListLookup"
                                                    Style="width: 108px" DataSourceID="odsSiteDetails" DataTextField="SiteDetails"
                                                    DataValueField="SiteDetails">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlM1DataAccessType" runat="server" SkinID="DropDownListLookup" Style="width: 108px">
                                                    <asp:ListItem Text="(Select)" Value="(Select)"></asp:ListItem>
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
                                                    Display="Dynamic" ErrorMessage="Please select a site detail." OnServerValidate="cvSiteDetails_ServerValidate"
                                                    SkinID="Validator" ValidationGroup="flM1Data"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvM1DataAccessType" runat="server" SkinID="Validator" EnableViewState="True" 
                                                    ValidationGroup="flM1Data" ErrorMessage="Please select an access type." Display="Dynamic" 
                                                    ControlToValidate="ddlM1DataAccessType" InitialValue="(Select)"></asp:RequiredFieldValidator>
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
                                            <td style="height: 7px" colspan="6">
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
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataMeasurementType" runat="server" SkinID="Label" Text="Measurement Type"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataMeasuredFromMH" runat="server" SkinID="LabelSmall" Text="Measured From MH"></asp:Label>
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
                                                <asp:DropDownList ID="ddlM1DataMeasurementType" runat="server" DataSourceID="odsMeasurementType"
                                                    DataTextField="MeasurementType" DataValueField="MeasurementType" SkinID="DropDownListLookup"
                                                    Style="width: 108px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnlM1DataMeasuredFromMh" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlM1DataMeasuredFromMh" runat="server" SkinID="DropDownList"
                                                            Style="width: 108px" AutoPostBack="True">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem Value="USMH">USMH</asp:ListItem>
                                                            <asp:ListItem Value="DSMH">DSMH</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="tbxM1DataMeasuredFromMh" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                            Style="width: 108px"></asp:TextBox>
                                                    </ContentTemplate>
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
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM1DataVideoDoneFromMH" runat="server" SkinID="LabelSmall" Text="Video Done From MH"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataToMH" runat="server" SkinID="Label" Text="To MH"></asp:Label>
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
                                                <asp:UpdatePanel ID="upnlM1DataVideoDoneFromMh" runat="server">
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
                                                <asp:UpdatePanel ID="upnlM1DataVideoDoneToMh" runat="server">
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
                                                <asp:UpdatePanel ID="upnlClearButton" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnClear" OnClick="btnClearOnClick" runat="server" SkinID="Button"
                                                            Text="Clear" EnableViewState="True" Width="80px"></asp:Button>
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
                                            <td style="height: 10px">
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
                                                        <asp:GridView ID="grdLaterals" runat="server" SkinID="GridView" Width="710px"
                                                            DataSourceID="odsLaterals" ShowFooter="True" OnDataBound="grdLaterals_DataBound"
                                                            OnRowCreated="grdLaterals_RowCreated" OnRowCommand="grdLaterals_RowCommand" OnRowUpdating="grdLaterals_RowUpdating"
                                                            OnRowDeleting="grdLaterals_RowDeleting" OnRowDataBound="grdLaterals_RowDataBound" OnRowEditing="grdLaterals_RowEditing"
                                                            AutoGenerateColumns="False" DataKeyNames="Lateral">
                                                            <Columns>
                                                            
                                                                <asp:TemplateField SortExpression="Lateral" Visible="False" HeaderText="Lateral">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblLateral" runat="server" Text='<%# Eval("Lateral") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLateral" runat="server" Text='<%# Eval("Lateral") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField SortExpression="LateralID" HeaderText="Laterals">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 8 columns - Lateral Data -->
                                                                        <table style="width: 560px" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 12px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLateralIdEdit" runat="server" SkinID="Label" Text="Lateral ID"
                                                                                            __designer:wfdid="w30"></asp:Label>
                                                                                        .
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblClientInspectionNumberEdit" runat="server" __designer:wfdid="w31"
                                                                                            SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblClientLateralIdEdit" runat="server" SkinID="Label" Text="Client Lateral ID"
                                                                                            __designer:wfdid="w31"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblMnEdit" runat="server" SkinID="Label" Text="MN#" __designer:wfdid="w32"></asp:Label>
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
                                                                                        <asp:TextBox ID="tbxLateralIdEdit" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("LateralID") %>'
                                                                                            Width="80px" ReadOnly="True" __designer:wfdid="w33"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientInspectionNoEdit" runat="server" __designer:wfdid="w34"
                                                                                            SkinID="TextBox" Text='<%# Eval("ClientInspectionNo") %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientLateralIdEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ClientLateralID") %>'
                                                                                            Width="80px" __designer:wfdid="w34"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="tbxMnEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Mn") %>'
                                                                                            Width="170px" __designer:wfdid="w35"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblClockPositionEdit" runat="server" SkinID="Label" Text="Clock Position" __designer:wfdid="w37"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSizeEdit" runat="server" SkinID="Label" Text="Size" __designer:wfdid="w38"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMaterialEdit" runat="server" SkinID="Label" Text="Material" __designer:wfdid="w39"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblConnectionTypeEdit" runat="server" SkinID="Label" Text="ConnectionType" __designer:wfdid="w41"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblJLFlangeTypeEdit" runat="server" SkinID="Label" Text="JL Flange Type"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" class="helpHint" alt="Help"  />
                                                                                            <b class="hint">Only used when Junction Lining Lateral</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLiveEdit" runat="server" SkinID="Label" Text="Live" __designer:wfdid="w42"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClockPositionEdit" runat="server" SkinID="TextBox" Text='<%# Eval("ClockPosition") %>' Width="80px" ></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxSizeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Size_") %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList Style="width: 80px" ID="ddlMaterialEdit" runat="server" SkinID="DropDownList"
                                                                                            EnableViewState="True" DataTextField="MaterialType" DataValueField="MaterialType" DataSourceID="odsMaterialType">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList Style="width: 80px" ID="ddlConnectionTypeEdit" runat="server" SkinID="DropDownList" EnableViewState="True" >
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
                                                                                            SelectedValue='<%# GetFlange(Eval("Flange")) %>' SkinID="DropDownList" Width="80px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxJlLive" runat="server" SkinID="TextBoxReadOnly" Text="Live" Width="80px" ReadOnly="True"></asp:TextBox>
                                                                                        <asp:DropDownList Style="width: 80px" ID="ddlLiveEdit" runat="server" SkinID="DropDownListLookup"
                                                                                            EnableViewState="True"  DataTextField="State" DataValueField="State" DataSourceID="odsLive">
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
                                                                                        <asp:RequiredFieldValidator ID="rfvStateEdit" runat="server" SkinID="Validator" EnableViewState="True"
                                                                                            ValidationGroup="AddLateralsEditSpecial" ErrorMessage="Please select a state."
                                                                                            Display="Dynamic" ControlToValidate="ddlLiveEdit" InitialValue="(Select)"></asp:RequiredFieldValidator>
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
                                                                                        <asp:Label ID="lblVideoDistanceEdit" runat="server" SkinID="LabelSmall" Text="Video Distance" __designer:wfdid="w36"></asp:Label>
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDistanceToCentreEdit" runat="server" SkinID="LabelSmall" Text="Distance To Centre"></asp:Label>&nbsp;
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
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxVideoDistanceEdit" runat="server" SkinID="TextBox" Text='<%# GetDistance(Eval("VideoDistance")) %>' Width="80px" ></asp:TextBox>                            				                                                                                                                                                                
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxDistanceToCentreEdit" runat="server" SkinID="TextBox" Text='<%# GetDistance(Eval("DistanceToCentre")) %>' Width="80px" ></asp:TextBox>                            				                                                                                                                                                               
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxReverseSetupEdit" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("ReverseSetup")) %>' Width="80px" ReadOnly="True" ></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxTimeOpenedEdit" runat="server" SkinID="TextBox" Text='<%# Eval("TimeOpened") %>' Width="80px" ></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpReinstateEdit" runat="server" Width="80px" SkinID="RadDatePicker"
                                                                                            DbSelectedDate='<%# Eval("Reinstate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
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
                                                                                        <asp:CustomValidator ID="cvVideoDistance" runat="server" SkinID="Validator" ValidationGroup="AddLateralsEdit"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                            Display="Dynamic" ControlToValidate="tbxVideoDistanceEdit" OnServerValidate="cvDistance_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvVideoDistanceRequiredEdit" runat="server" SkinID="Validator"
                                                                                            ValidationGroup="AddLateralsEdit" ErrorMessage="Please enter video distance."
                                                                                            Display="Dynamic" ValidateEmptyText="true" ControlToValidate="tbxVideoDistanceEdit"
                                                                                            OnServerValidate="cvVideoDistanceRequiredEdit_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvDistanceToCentre" runat="server" SkinID="Validator" ValidationGroup="AddLateralsEdit"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                            Display="Dynamic" ControlToValidate="tbxDistanceToCentreEdit" OnServerValidate="cvDistance_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvDistanceToCentreRequiredEdit" runat="server" SkinID="Validator"
                                                                                            ValidationGroup="AddLateralsEdit" ErrorMessage="Please enter distance to centre."
                                                                                            Display="Dynamic" ValidateEmptyText="true" ControlToValidate="tbxDistanceToCentreEdit"
                                                                                            OnServerValidate="cvDistanceToCentreRequiredEdit_ServerValidate">
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
                                                                                        <telerik:RadDatePicker ID="tkrdpRequiresRoboticPrepDateEdit" runat="server" Width="80px" SkinID="RadDatePicker"
                                                                                            DbSelectedDate='<%# Eval("RequiresRoboticPrepDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
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
                                                                                        <telerik:RadDatePicker ID="tkrdpDyeTestCompleteEdit" runat="server" Width="80px" SkinID="RadDatePicker"
                                                                                            DbSelectedDate='<%# Eval("DyeTestComplete") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
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
                                                                                            ValidationGroup="AddLateralsEdit"></asp:CustomValidator>
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
                                                                                        <asp:TextBox ID="tbxCommentsEdit" runat="server" SkinID="TextBoxMemo" Text='<%# Eval("Comments") %>'
                                                                                            Width="530px"  TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px" colspan="8">
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 6 columns - New Lateral Data -->
                                                                        <table style="width: 560px" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 12px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
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
                                                                                        <asp:Label ID="lblNewClientInspectionNo" runat="server"  SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewClientLateralId" runat="server" SkinID="Label" Text="Client Lateral ID"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblNewMn" runat="server" SkinID="Label" Text="MN#"></asp:Label>
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
                                                                                        <asp:TextBox ID="tbxNewLateralId" runat="server" SkinID="TextBoxReadOnly" Width="80px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewClientInspectionNo" runat="server" SkinID="TextBox" Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewClientLateralId" runat="server" SkinID="TextBox" Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="tbxNewMn" runat="server" SkinID="TextBox" Width="170px"></asp:TextBox>
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
                                                                                        <asp:CustomValidator ID="cvLateralId" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd"
                                                                                            ErrorMessage="Error" Display="Dynamic" ControlToValidate="tbxNewLateralId" OnServerValidate="cvLateralId_ServerValidate">
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
                                                                                        <asp:Label ID="lblNewSize" runat="server" SkinID="Label" Text="Size" ></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewMaterial" runat="server" SkinID="Label" Text="Material" ></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewConnectionType" runat="server" SkinID="Label" Text="Connection Type"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNewLive" runat="server" SkinID="Label" Text="Live" ></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewVideoDistance" runat="server" SkinID="TextBox" Text='<%# Eval("VideoDistance") %>' Width="80px" ></asp:TextBox>                            
				                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewClockPosition" runat="server" SkinID="TextBox" Text='<%# Eval("ClockPosition") %>' Width="80px" ></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewSize" runat="server" SkinID="TextBox" Width="80px" __designer:wfdid="w80"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList Style="width: 80px" ID="ddlNewMaterial" runat="server" SkinID="DropDownList"
                                                                                            EnableViewState="True" DataTextField="MaterialType" DataValueField="MaterialType" DataSourceID="odsMaterialType">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList Style="width: 80px" ID="ddlNewConnectionType" runat="server" SkinID="DropDownListLookup"  EnableViewState="True" >
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
                                                                                        <asp:DropDownList Style="width: 80px" ID="ddlNewLive" runat="server" SkinID="DropDownListLookup"
                                                                                            EnableViewState="True" DataTextField="State" DataValueField="State"
                                                                                            DataSourceID="odsLive">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvNewVideoDistance" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd"
                                                                                            ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                            Display="Dynamic" ControlToValidate="tbxNewVideoDistance" OnServerValidate="cvDistance_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvNewVideoDistanceRequired" runat="server" SkinID="Validator"
                                                                                            ValidationGroup="AddLateralsAdd" ErrorMessage="Please enter video distance."
                                                                                            Display="Dynamic" ValidateEmptyText="true" ControlToValidate="tbxNewVideoDistance"
                                                                                            OnServerValidate="cvNewVideoDistanceRequired_ServerValidate">
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
                                                                                            ControlToValidate="ddlNewLive" InitialValue="(Select)"></asp:RequiredFieldValidator>
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
                                                                                        <asp:Label ID="lblNewDistanceToCentre" runat="server" SkinID="LabelSmall" Text="Distance To Centre" ></asp:Label>&nbsp;
                                                                                        <a href="#" class="hint">
                                                                                            <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                                                            <b class="hint">Please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm format.</b><span class="hint"></span>
                                                                                        </a>
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:Label ID="lblNewComments" runat="server" SkinID="Label" Text="Comments" ></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNewDistanceToCentre" runat="server" SkinID="TextBox" Text='<%# Eval("DistanceToCentre") %>' Width="80px"></asp:TextBox>                            
				                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="tbxNewComments" runat="server" SkinID="TextBoxMemo" Text='<%# Eval("Comments") %>' EnableViewState="True" Width="440px" Rows="1"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvNewDistanceToCentre" runat="server" SkinID="Validator"
                                                                                            ValidationGroup="AddLateralsAdd" ErrorMessage="Invalid format. (please use X'Y&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                            Display="Dynamic" ControlToValidate="tbxNewDistanceToCentre" OnServerValidate="cvDistance_ServerValidate" >
                                                                                        </asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvNewDistanceToCentreRequired" runat="server" SkinID="Validator"
                                                                                            ValidationGroup="AddLateralsAdd" ErrorMessage="Please enter distance to centre."
                                                                                            Display="Dynamic" ValidateEmptyText="true" ControlToValidate="tbxNewDistanceToCentre"
                                                                                            OnServerValidate="cvNewDistanceToCentreRequired_ServerValidate">
                                                                                        </asp:CustomValidator>
                                                                                    </td>
                                                                                    <td colspan="5">
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
                                                                                        <asp:CustomValidator ID="cvMeasuredFromMH" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd"
                                                                                            ErrorMessage="Measured From MH is not defined yet, please define it before adding laterals."
                                                                                            Display="Dynamic" ControlToValidate="ddlNewLive" OnServerValidate="cvMeasuredFromMH_ServerValidate"></asp:CustomValidator>
                                                                                        <asp:CustomValidator ID="cvLateralsMaxNumber" runat="server" SkinID="Validator" ValidationGroup="AddLateralsAdd"
                                                                                            ErrorMessage="The maximum laterals amount was reached, no more laterals can be added."
                                                                                            Display="Dynamic" ControlToValidate="ddlNewLive" OnServerValidate="cvLateralsMaxNumber_ServerValidate"></asp:CustomValidator>
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
                                                                                    <td></td>
                                                                                    
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
                                                                                             SkinID="RadDatePicker" Width="80px">
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
                                                                                             SkinID="RadDatePicker" Width="80px">
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
                                                                                            DataTextField="Flange" DataValueField="Flange" SkinID="DropDownList" Width="80px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    
                                                                                    <td>
                                                                                    </td>
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
                                                                    <HeaderStyle Width="560px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table style="width: 560px" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
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
                                                                                        <asp:Label ID="lblMn" runat="server"  SkinID="Label" Text="MN#"></asp:Label>
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
                                                                                        <asp:TextBox ID="tbxLateralId" runat="server"  ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("LateralID") %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientInspectionNo" runat="server"  ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientInspectionNo") %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClientLateralId" runat="server"  ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientLateralID") %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox ID="tbxMn" runat="server"  ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Mn") %>' Width="170px"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblLive" runat="server"  SkinID="Label" Text="Live"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>                                                                                    
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxClockPosition" runat="server" __designer:wfdid="w14" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClockPosition") %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxSize" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Size_") %>' Width="80px" ReadOnly="True" __designer:wfdid="w15"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxMaterial" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("MaterialType") %>' Width="80px" ReadOnly="True" __designer:wfdid="w16"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxConnectionType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("ConnectionType") %>' Width="80px" ReadOnly="True" __designer:wfdid="w17"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxJLFlangeType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Flange") %>' Width="80px" ReadOnly="True"></asp:TextBox>                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxLive" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Live") %>' Width="80px" ReadOnly="True" __designer:wfdid="w18"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblDistanceToCentre" runat="server" __designer:wfdid="w19" SkinID="LabelSmall" Text="Distance To Centre"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblReverseSetup" runat="server" __designer:wfdid="w20" SkinID="Label" Text="Reverse Setup"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTimeOpened" runat="server" __designer:wfdid="w21" SkinID="Label" Text="Opened"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblReinstate" runat="server" __designer:wfdid="w22" SkinID="Label" Text="Brushed"></asp:Label>
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
                                                                                        <asp:TextBox ID="tbxVideoDistance" runat="server" __designer:wfdid="w13" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("VideoDistance")) %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxDistanceToCentre" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("DistanceToCentre")) %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:UpdatePanel ID="upnlLateralReverseSetup" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:TextBox ID="tbxReverseSetup" runat="server"  ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("ReverseSetup")) %>' Width="80px"></asp:TextBox>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxTimeOpened" runat="server"  ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("TimeOpened") %>' Width="80px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxReinstate" runat="server"  ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Reinstate", "{0:d}") %>' Width="80px"></asp:TextBox>
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
                                                                                        <asp:CheckBox ID="ckbxRequiresRoboticPrep" runat="server" onclick="return cbxClick();" SkinID="CheckBox" Checked='<%# Eval("RequiresRoboticPrep") %>' />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRequiresRoboticPrepDate" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("RequiresRoboticPrepDate", "{0:d}") %>' Width="80px"></asp:TextBox>
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
                                                                                        <asp:TextBox ID="tbxDyeTestComplete" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("dyeTestComplete", "{0:d}") %>' Width="80px"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblComments" runat="server"  SkinID="Label" Text="Comments"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxComments" runat="server" ReadOnly="True"
                                                                                            Rows="4" SkinID="TextBoxReadOnly" Text='<%# Eval("Comments") %>' TextMode="MultiLine"
                                                                                            Width="530px"></asp:TextBox>
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
                                                                
                                                                <asp:TemplateField SortExpression="InProject" HeaderText="In Project">
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="cbxInProject" runat="server" SkinID="CheckBox" __designer:wfdid="w2" Checked='<%# Eval("InProject") %>'></asp:CheckBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align: center">
                                                                                        <asp:CheckBox ID="cbxInProject" runat="server" SkinID="CheckBox" __designer:wfdid="w3" Enabled="false" Checked="true"></asp:CheckBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxInProjectI" runat="server" SkinID="CheckBox" __designer:wfdid="w1" Enabled="false" Checked='<%# Eval("InProject") %>'></asp:CheckBox>
                                                                    </ItemTemplate>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"
                                                                                            CommandName="Add"></asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
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
                                            <td style="height: 30px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpM2Data" runat="server" HeaderText="M2 Data" OnClientClick="tpM2DataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
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
                                                <asp:Label ID="lblM2DataM2Date" runat="server" SkinID="Label" Text="M2 Date"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblM2DataMeasurementsTakenBy" runat="server" SkinID="Label" Text="Measurements Taken By"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="upnlM2DataM2Date" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadDatePicker ID="tkrdpM2DataM2Date" runat="server" Width="108px" 
                                                            SkinID="RadDatePicker" Culture="English (United States)" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpM2DataM2Date_SelectedDateChanged">
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x">
                                                            </calendar>
                                                            <dateinput labelcssclass="" width="">
                                                            </dateinput>
                                                            <datepopupbutton cssclass="" hoverimageurl="" imageurl="">
                                                            </datepopupbutton>
                                                        </telerik:RadDatePicker>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM2DataMeasurementsTakenBy" runat="server" SkinID="TextBox" Style="width: 226px"></asp:TextBox>
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
                                                <asp:Label ID="lblM2DataDropPipe" runat="server" SkinID="Label" Text="Drop Pipe"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM2DataDropPipeInvertDepth" runat="server" SkinID="LabelSmall" Text="Drop Pipe Invert Depth"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM2DataCappedLaterals" runat="server" SkinID="Label" Text="Capped Laterals"></asp:Label>&nbsp;
                                                <a href="#" class="hint">
                                                    <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif" alt="Help" class="helpHint" />
                                                    <b class="hint">Please use an integer number.</b><span class="hint"></span>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxM2DataDropPipe" runat="server" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataDropPipeInvertdepth" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataCappedLaterals" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
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
                                                <asp:CompareValidator ID="cvM2DataCappedLaterals" runat="server" ControlToValidate="tbxM2DataCappedLaterals"
                                                    Display="Dynamic" ErrorMessage="Invalid format. (Please use an integer number)"
                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="flData"></asp:CompareValidator>
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
                                                <asp:Label ID="lblM2DataLineWidthId" runat="server" SkinID="Label" Text="Line Width ID#"></asp:Label>
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
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM2DataLineWidthId" runat="server" SkinID="TextBox" Style="width: 226px"></asp:TextBox>
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
                                                <asp:Label ID="lblM2DataHydrantAddress" runat="server" SkinID="Label" Text="Hydrant Address"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM2DataDistanceToInversionMH" runat="server" SkinID="Label" Text="Hydrant Distance to inversion MH"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM2DataHydroWireWithin10FtOfInversionMH" runat="server" SkinID="LabelSmall" Text="Hydro Wire Within 10 Ft Of Inversion MH"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxM2DataHydrantAddress" runat="server" SkinID="TextBox" Style="width: 462px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataDistanceToInversionMH" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlM2DataHydroWireWithin10FtOfInversionMh" runat="server" SkinID="DropDownList"
                                                    Style="width: 108px">
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSurfaceGrade" runat="server" SkinID="Label" Text="Surface Grade"></asp:Label>
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
                                                <asp:DropDownList ID="ddlM2DataSurfaceGrade" runat="server" SkinID="DropDownListLookup"
                                                    Style="width: 108px" DataSourceID="odsSurfaceGrade" DataTextField="SurfaceGrade"
                                                    DataValueField="SurfaceGrade">
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CustomValidator ID="cvSurfaceGrade" runat="server" ControlToValidate="ddlM2DataSurfaceGrade"
                                                    Display="Dynamic" ErrorMessage="Please select a surface grade." OnServerValidate="cvSurfaceGrade_ServerValidate"
                                                    SkinID="Validator" ValidationGroup="flM2Data"></asp:CustomValidator>
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
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblM2DataExtraEquipmentNeeded" runat="server" SkinID="LabelTitle2" Text="Extra Equipment Needed"></asp:Label>
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
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataHydroPulley" runat="server" SkinID="CheckBox" Text="Hydro Pulley?" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataFridgeCart" runat="server" SkinID="CheckBox" Text="Fridge Cart?" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataTwoPump" runat="server" SkinID="CheckBox" Text='2" Pump?' />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataSixBypass" runat="server" SkinID="CheckBox" Text='6" Bypass?' />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataScaffolding" runat="server" SkinID="CheckBox" Text="Scaffolding?" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataWinchExtension" runat="server" SkinID="CheckBox" Text="Winch Extension?" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataExtraGenerator" runat="server" SkinID="CheckBox" Text="Extra Generator?" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataGreyCableExtension" runat="server" SkinID="CheckBox" Text="Grey Cable Extension?" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataEasementMats" runat="server" SkinID="CheckBox" Text="Easement Mats?" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataRampsRequired" runat="server" SkinID="CheckBox" Text="Ramps Required?" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataCameraSkid" runat="server" SkinID="CheckBox" Text="Camera Skid?" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpWetOut" runat="server" HeaderText="Wet Out" OnClientClick="tpWetOutClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 6 columns Setup information -->
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
                                            <td colspan="6">
                                                <asp:Label ID="lblWetOutDataIncludeWetOutInformation" runat="server" SkinID="Label" Text="Include Wet Out - Inversion Information"></asp:Label>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:UpdatePanel ID="upnlWetOutDataIncludeWetOutInformation" runat="server">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ckbxWetOutDataIncludeWetOutInformation" runat="server" SkinID="CheckBox" 
                                                        OnCheckedChanged="WetOutDataInversionVisibleInformation_OnCheckedChanged" AutoPostBack="true" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <asp:UpdatePanel ID="upnlVisibleInformation" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="pnlVisibleInformation" runat="server" Width="100%">                                                                           
                                                <!-- Table element: 6 columns Setup information -->
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>                                        
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataSetup" runat="server" SkinID="LabelTitle2" Text="Setup"></asp:Label>
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
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>                                                
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataLinerTube" runat="server" SkinID="Label" Text="Liner Tube"></asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:Label ID="lblWetOutDataResin" runat="server" SkinID="Label" Text="Resin"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataExcessResin" runat="server" SkinID="Label" Text="Excess Resin (%)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">See ASTM F1216. The excess resin is for the tube. Default value 0%</b><span class="hint"></span>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataPoundsDrums" runat="server" SkinID="Label" Text="Pounds & Drums"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlWetOutDataLinerTube" runat="server" DataMember="DefaultView"
                                                                DataSourceID="odsLinerTube" DataTextField="LinerTube" DataValueField="LinerTube"
                                                                SkinID="DropDownList" Style="width: 108px">
                                                            </asp:DropDownList>                                                            
                                                        </td>
                                                        <td colspan="3">                                                        
                                                            <asp:DropDownList ID="ddlWetOutDataResins" runat="server" DataMember="DefaultView"
                                                                DataSourceID="odsResins" DataTextField="Resin" DataValueField="ResinID" SkinID="DropDownList"
                                                                Style="width: 344px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>                                                         
                                                            <asp:TextBox ID="tbxWetOutDataExcessResin" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                               
                                                        </td>
                                                        <td>                                                           
                                                            <asp:DropDownList ID="ddlWetOutDataPoundsDrums" runat="server" DataMember="DefaultView"
                                                                SkinID="DropDownListLookupBlueText" Style="width: 108px">
                                                                <asp:ListItem Value="(Select)">(Select)</asp:ListItem>
                                                                <asp:ListItem Value="Pounds & Drums">Pounds & Drums</asp:ListItem>
                                                                <asp:ListItem Value="Pounds Only">Pounds Only</asp:ListItem>
                                                            </asp:DropDownList>                                                                
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataLinerTube" runat="server" 
                                                                SkinID="Validator" ValidationGroup="flWetOutData" ErrorMessage="Please select a liner tube."
                                                                Display="Dynamic" ControlToValidate="ddlWetOutDataLinerTube" 
                                                                InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataResins" runat="server" 
                                                                SkinID="Validator" ValidationGroup="flWetOutData" ErrorMessage="Please select a resin."
                                                                Display="Dynamic" ControlToValidate="ddlWetOutDataResins" 
                                                                InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataExcessResin" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the excess of resin"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataExcessResin"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cvWetOutDataExcessResin" runat="server" ControlToValidate="tbxWetOutDataExcessResin"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XX.X)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataPoundsDrums" runat="server" 
                                                                SkinID="Validator" ValidationGroup="flWetOutData" ErrorMessage="Please select an item."
                                                                Display="Dynamic" ControlToValidate="ddlWetOutDataPoundsDrums" 
                                                                InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataDrumDiameter" runat="server" SkinID="Label" Text="Drum Diameter"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format. Default Value 22.5inch</b><span class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataHoistMaximumHeight" runat="server" SkinID="Label" Text="Hoist Maximum Height (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Maximum height for hoist or scaffold. Please use X.Y format.  Default Value 24ft</b><span class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataHoistMinimumHeight" runat="server" SkinID="Label" Text="Hoist Minimum Height (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Minimum height for hoist or scaffold. Please use X.Y format.  Default Value 5ft</b><span class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataDownDropTubeLength" runat="server" SkinID="Label" Text="Down (Drop) Tube Length (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">For when using drop/down tube. Please use X.Y format.  Default Value 19ft</b><span class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataPumpHeightAboveGround" runat="server" SkinID="Label"
                                                                Text="Pump Height Above Ground (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 6ft</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeResinToFeltFactor" runat="server" SkinID="Label"
                                                                Text="Tube Resin to Felt Factor (%)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Consult tube manufacturer for recommended value. Typically 86-88%. Please use X format.  Default Value 87%</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataDrumDiameter" runat="server" SkinID="TextBoxBlueText" Style="width: 108px" ></asp:TextBox>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataHoistMaximumHeight" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>                                                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataHoistMinimumHeight" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataDownDropTubeLength" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataPumpHeightAboveGround" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>                                                                
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataTubeResinToFeltFactor" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataDrumDiameter" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the drum diameter"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataDrumDiameter"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataDrumDiameter" runat="server" ControlToValidate="tbxWetOutDataDrumDiameter"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataHoistMaximumHeight" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the hoist max height"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataHoistMaximumHeight"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataHoistMaximumHeight" runat="server" ControlToValidate="tbxWetOutDataHoistMaximumHeight"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataHoistMinimumHeight" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the hoist min height"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataHoistMinimumHeight"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataHoistMinimumHeight" runat="server" ControlToValidate="tbxWetOutDataHoistMinimumHeight"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataDownDropTubeLength" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the down drop tube lenght"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataDownDropTubeLength"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataDownDropTubeLength" runat="server" ControlToValidate="tbxWetOutDataDownDropTubeLength"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataPumpHeightAboveGround" runat="server"
                                                                SkinID="Validator" EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the pump height above ground"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataPumpHeightAboveGround"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataPumpHeightAboveGround" runat="server" ControlToValidate="tbxWetOutDataPumpHeightAboveGround"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataTubeResinToFeltFactor" runat="server"
                                                                SkinID="Validator" EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the tube resin to felt factor"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataTubeResinToFeltFactor"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cvWetOutDataTubeResinToFeltFactor" runat="server" ControlToValidate="tbxWetOutDataTubeResinToFeltFactor"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="flWetOutData"></asp:CompareValidator>
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
                                                
                                                <!-- Table element: 6 columns Wet Out Sheet information -->
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataWetOutSheet" runat="server" SkinID="LabelTitle2" Text="Wet Out Sheet"></asp:Label>
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
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataDateOfSheet" runat="server" SkinID="Label" Text="Date Of Sheet"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblWetOutDataMadeBy" runat="server" SkinID="Label" Text="Made By"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataRunDetails" runat="server" SkinID="Label" Text="Run Details"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align:top; height:50px">
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataDateOfSheet" runat="server" SkinID="TextBoxReadOnly"
                                                                Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel ID="upnlWetOutDataMadeBy" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlWetOutDataMadeBy" runat="server" DataMember="DefaultView"
                                                                        DataSourceID="odsEmployees" DataTextField="FullName" DataValueField="EmployeeID"
                                                                        SkinID="DropDownList" Style="width: 226px" AutoPostBack="true" OnSelectedIndexChanged="ddlWetOutDataMadeBy_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlSectionId" Width="108px" Height="50px" runat="server" SkinID="Panel">
                                                                <asp:UpdatePanel ID="pnlCbxlSectionId" runat="server">
                                                                    <ContentTemplate>
                                                                       <asp:CheckBoxList ID="cbxlSectionId" runat="server" SkinID="CheckBoxListWithoutBorder" EnableViewState="true"
                                                                              onclick="return cbxSelectedClick(event);">
                                                                       </asp:CheckBoxList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>                                                                           
                                                             </asp:Panel>                                                                                                         
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel ID="upnlWetOutDataRunDetails2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlWetOutDataRunDetails2" runat="server" DataMember="DefaultView"
                                                                        SkinID="DropDownList" Style="width: 108px" AutoPostBack="true" OnSelectedIndexChanged="ddlWetOutDataRunDetails2_SelectedIndexChanged">
                                                                        <asp:ListItem Value="(Select)">(Select)</asp:ListItem>
                                                                        <asp:ListItem Value="Upstream Inversion">Upstream Inversion</asp:ListItem>
                                                                        <asp:ListItem Value="Downstream Inversion">Downstream Inversion</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataMadeBy" runat="server" 
                                                                SkinID="Validator" ValidationGroup="flWetOutData" ErrorMessage="Please select a team member."
                                                                Display="Dynamic" ControlToValidate="ddlWetOutDataMadeBy" 
                                                                InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataRunDetails2" runat="server" 
                                                                SkinID="Validator" ValidationGroup="flWetOutData" ErrorMessage="Please select an item."
                                                                Display="Dynamic" ControlToValidate="ddlWetOutDataRunDetails2" 
                                                                InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataWetOutDate" runat="server" SkinID="Label" Text="Wet Out Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataInstallDate" runat="server" SkinID="Label" Text="Install Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeThickness" runat="server" SkinID="Label" Text="Tube Thickness"></asp:Label>
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
                                                            <telerik:RadDatePicker ID="tkrdpWetOutDataWetOutDate" runat="server" SkinID="RadDatePicker"
                                                                Width="108px" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                            </telerik:RadDatePicker>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataInstallDate" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataInstallDate" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>                                                                       
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTubeThickness" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTubeThickness" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>                                                                                                                        
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
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataWetOutDate" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the wet out date"
                                                                Display="Dynamic" ControlToValidate="tkrdpWetOutDataWetOutDate"></asp:RequiredFieldValidator>
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
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataLengthToLine" runat="server" SkinID="Label" Text="Length To Line (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataPlusExtra" runat="server" SkinID="Label" Text="Plus Extra (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please X.Y format. Default value 3ft</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataForTurnOffset" runat="server" SkinID="LabelSmall" Text="For Turn/Offset (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please X.Y format. Default value 0ft</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataLengthtToWetOut" runat="server" SkinID="LabelSmall" Text="Lengtht to Wet Out (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataLengthToLine" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataLengthToLine" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataPlusExtra" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataForTurnOffset" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataLengthtToWetOut" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataLengthtToWetOut" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px" EnableViewState="true"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataPlusExtra" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide plus extra"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataPlusExtra"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataPlusExtra" runat="server" ControlToValidate="tbxWetOutDataPlusExtra"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataForTurnOffset" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the turn/offset"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataForTurnOffset"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataForTurnOffset" runat="server" ControlToValidate="tbxWetOutDataForTurnOffset"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
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
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlWetOutDataResinGray" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblWetOutDataResinGray" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlWetOutDataDrumContainsGray" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblWetOutDataDrumContainsGray" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlWetOutDataLinerTubeGray" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblWetOutDataLinerTubeGray" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeMaxColdHead" runat="server" SkinID="LabelSmall" Text="Tube Max Cold Head (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeMaxColdHeadPsi" runat="server" SkinID="LabelSmall" Text="Tube Max Cold Head (psi)"></asp:Label>                                            
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeMaxHotHead" runat="server" SkinID="LabelSmall" Text="Tube Max Hot Head (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeMaxHotHeadPsi" runat="server" SkinID="LabelSmall" Text="Tube Max Hot Head (psi)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeIdealHead" runat="server" SkinID="LabelSmall" Text="Tube Ideal Head (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeIdealHeadPsi" runat="server" SkinID="LabelSmall" Text="Tube Ideal Head (psi)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTubeMaxColdHead" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxColdHead" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>    
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTubeMaxColdHeadPSI" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxColdHeadPSI" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>  
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTubeMaxHotHead" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxHotHead" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>         
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTubeMaxHotHeadPSI" runat="server">
                                                                <ContentTemplate> 
                                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxHotHeadPSI" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>      
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTubeIdealHead" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTubeIdealHead" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>  
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTubeIdealHeadPSI" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTubeIdealHeadPSI" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlWetOutDataLbDrumsGrey" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblWetOutDataLbDrumsGrey" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataNetResinForTube" runat="server" SkinID="Label" Text="Net Resin For Tube (lbs)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataNetResinForTubeUsgals" runat="server" SkinID="Label" Text="Net Resin For Tube (usgals)"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataNetResinForTubLbsFt" runat="server" SkinID="Label" Text="Net Resin For Tube (lbs/ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataNetResinForTubUsgFt" runat="server" SkinID="Label" Text="Net Resin For Tube (usg/ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataNetResinForTube" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTube" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataNetResinForTubeUsgals" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeUsgals" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataNetResinForTubeDrumsIns" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeDrumsIns" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataNetResinForTubeLbsFt" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeLbsFt" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataNetResinForTubeUsgFt" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeUsgFt" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlWetOutDataNetResinGrey" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblWetOutDataNetResinGrey" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
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
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataExtraResinForMix" runat="server" SkinID="LabelSmall" Text="Extra Resin For Mix (%)"></asp:Label>
                                                             <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Default value 0%</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataExtraLbsForMix" runat="server" SkinID="Label" Text="Extra Lbs For Mix (lbs)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTotalMixQuantity" runat="server" SkinID="Label" Text="Total Mix Quantity (lbs)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTotalMixQuantityUsgals" runat="server" SkinID="Label" Text="Total Mix Quantity (usgals)"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataExtraResinForMix" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataExtraLbsForMix" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataExtraLbsForMix" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTotalMixQuantity" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTotalMixQuantity" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTotalMixQuantityUsgals" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTotalMixQuantityUsgals" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTotalMixQuantityDrumsIns" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTotalMixQuantityDrumsIns" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvtbxWetOutDataExtraResinForMix" runat="server"
                                                                SkinID="Validator" EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the extra resin for mix"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataExtraResinForMix"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cvWetOutDataExtraResinForMix" runat="server" ControlToValidate="tbxWetOutDataExtraResinForMix"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="flWetOutData"></asp:CompareValidator>
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
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblCatalysts" runat="server" SkinID="LabelBold" Text="Catalysts"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblNote" runat="server" SkinID="Label" Text="Please calculate this wet out sheet before you enter catalyst information on this grid"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Panel ID="pnlCatalysts" runat="server" Height="180px" Width="100%" ScrollBars="Auto">
                                                                <asp:UpdatePanel id="upnlCatalysts" runat="server">
                                                                    <contenttemplate>
                                                                        <!-- Page element: 1 column - Grid Catalyst -->
                                                                        <asp:GridView ID="grdCatalysts" runat="server" SkinID="GridView" Width="630px" AutoGenerateColumns="False"
                                                                            AllowPaging="True" PageSize="5" ShowFooter="True" OnDataBound="grdCatalysts_DataBound"
                                                                            OnRowCommand="grdCatalysts_RowCommand" OnRowUpdating="grdCatalysts_RowUpdating" OnRowEditing="grdCatalysts_RowEditing"
                                                                            OnRowDeleting="grdCatalysts_RowDeleting" DataKeyNames="WorkID, RefID" DataSourceID="odsCatalysts">
                                                                            <Columns>
                                                                                                                                                
                                                                                <asp:TemplateField Visible="False" HeaderText="No">                                                                        
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblWorkIdEdit" runat="server" SkinID="Label" Text='<%# Eval("WorkID") %>' Width="30px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblWorkIdFooter" runat="server" SkinID="Label" Text='<%# Eval("WorkID") %>' Width="30px"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblCWorkId" runat="server"  SkinID="Label" Text='<%# Eval("WorkID") %>' Width="30px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <asp:TemplateField Visible="False" HeaderText="No">                                                                        
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblRefIdEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>' Width="30px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblRefIdFooter" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>' Width="30px"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblCRefId" runat="server"  SkinID="Label" Text='<%# Eval("RefID") %>' Width="30px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                
                                                                                <asp:TemplateField  Visible="True" HeaderText="Catalyst">
                                                                                    <HeaderStyle Width="200px"></HeaderStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Eval("Name") %>' Width="190px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    
                                                                                    <EditItemTemplate>                                                                    
                                                                                        <asp:Label ID="lblNameEdit" runat="server" SkinID="Label" Text='<%# Eval("Name") %>' Width="190px"></asp:Label>
                                                                                        <asp:Label ID="lblCatalystIdEdit" runat="server" SkinID="Label" Text='<%# Eval("CatalystID") %>' Width="190px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    
                                                                                    <FooterTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:UpdatePanel ID="upnlNameFooter" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:DropDownList ID="ddlNameFooter" runat="server" DataMember="DefaultView"
                                                                                                                DataSourceID="odsCatalystsName" DataTextField="Name" DataValueField="CatalystID"
                                                                                                                SkinID="DropDownList" Style="width: 190px" AutoPostBack="true" OnSelectedIndexChanged="ddlNameFooter_SelectedIndexChanged"></asp:DropDownList>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RequiredFieldValidator ID="rfvNameFooter" runat="server" SkinID="Validator"
                                                                                                        EnableViewState="False" ValidationGroup="catalystDataFooter" ErrorMessage="Please select a catalyst"
                                                                                                        Display="Dynamic" ControlToValidate="ddlNameFooter"></asp:RequiredFieldValidator>
                                                                                               </td>
                                                                                            </tr>                                                                      
                                                                                        </table>                                                                                                                                               
                                                                                    </FooterTemplate>
                                                                                    
                                                                                </asp:TemplateField>
                                                                                                                                                                                                             
                                                                                <asp:TemplateField  Visible="True" HeaderText="% by Weight ">
                                                                                    <HeaderStyle Width="70px"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <EditItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td>       
                                                                                                    <asp:UpdatePanel ID="upnlPercentageByWeightEdit" runat="server">
                                                                                                        <ContentTemplate>                                                                                          
                                                                                                             <asp:TextBox ID="tbxPercentageByWeightEdit" runat="server" SkinID="TextBox" Width="60px" 
                                                                                                              Text='<%# GetRound(Eval("PercentageByWeight"),2) %>' AutoPostBack="true" OnTextChanged="tbxPercentageByWeightEdit_TextChanged"></asp:TextBox>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>                                                                                    
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RequiredFieldValidator ID="rfvPercentageByWeightEdit" runat="server" SkinID="Validator"
                                                                                                        EnableViewState="False" ValidationGroup="catalystDataEdit" ErrorMessage="Please provide the % by Weight"
                                                                                                        Display="Dynamic" ControlToValidate="tbxPercentageByWeightEdit"></asp:RequiredFieldValidator>                                                                                                
                                                                                                    <asp:CompareValidator ID="cvPercentageByWeightEdit" runat="server" ControlToValidate="tbxPercentageByWeightEdit"
                                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="catalystDataEdit"></asp:CompareValidator>
                                                                                                </td>
                                                                                            </tr>                                                                      
                                                                                        </table>                                                                         
                                                                                    </EditItemTemplate>
                                                                                    
                                                                                    <FooterTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:UpdatePanel ID="upnlPercentageByWeightFooter" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox ID="tbxPercentageByWeightFooter" runat="server" SkinID="TextBox"  Width="60px"></asp:TextBox>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>                                                                                                
                                                                                                   <asp:CustomValidator ID="cvPercentageByWeightFooter" runat="server" ControlToValidate="tbxPercentageByWeightFooter"
                                                                                                        Display="Dynamic" ErrorMessage="Please provide the % by Weight"
                                                                                                        OnServerValidate="cvPercentageByWeightFooter_ServerValidate" SkinID="Validator" ValidationGroup="catalystDataFooter"></asp:CustomValidator>
                                                                                                    <asp:CompareValidator ID="cpvPercentageByWeightFooter" runat="server" ControlToValidate="tbxPercentageByWeightFooter"
                                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="catalystDataFooter"></asp:CompareValidator>
                                                                                               </td>
                                                                                            </tr>                                                                      
                                                                                        </table>                                                                        
                                                                                    </FooterTemplate>
                                                                                    
                                                                                    <ItemTemplate>                                                                        
                                                                                        <asp:Label ID="lblPercentageByWeight" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PercentageByWeight"),2) %>' Width="60px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField> 
                                                                                                                                                           
                                                                                
                                                                                 <asp:TemplateField  Visible="True" HeaderText="Lbs For Mix Quantity">
                                                                                    <HeaderStyle Width="70px"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <EditItemTemplate>
                                                                                        <asp:UpdatePanel ID="upnlLbsForMixQuantityEdit" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:Label ID="lblLbsForMixQuantityEdit" runat="server" SkinID="Label" Text='<%# GetRound(Eval("LbsForMixQuantity"),2) %>' Width="60px"></asp:Label>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </EditItemTemplate>
                                                                                    
                                                                                    <FooterTemplate>                                                                                    
                                                                                        <asp:Label ID="lblLbsForMixQuantityFooter" runat="server" SkinID="Label" Width="60px"></asp:Label>                                                                       
                                                                                    </FooterTemplate>
                                                                                    
                                                                                    <ItemTemplate>                                                                        
                                                                                        <asp:Label ID="lblLbsForMixQuantity" runat="server" SkinID="Label" Text='<%# GetRound(Eval("LbsForMixQuantity"),2) %>' Width="60px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>    
                                                                                
                                                                                <asp:TemplateField  Visible="True" HeaderText="Lbs For Drum">
                                                                                    <HeaderStyle Width="250px"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <EditItemTemplate>
                                                                                        <asp:UpdatePanel ID="upnlLbsForDrumEdit" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:Label ID="lblLbsForDrumEdit" runat="server" SkinID="Label" Text='<%# Eval("LbsForDrum") %>' Width="240px"></asp:Label>                                                                        
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </EditItemTemplate>
                                                                                    
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lblLbsForDrumFooter" runat="server" SkinID="Label"  Width="240px"></asp:Label>                                                                            
                                                                                    </FooterTemplate>
                                                                                    
                                                                                    <ItemTemplate>                                                                        
                                                                                        <asp:Label ID="lblLbsForDrum" runat="server" SkinID="Label" Text='<%# Eval("LbsForDrum") %>' Width="240px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>                                                                                                                                                                                                                                                                                                                                                      
                                                                                                                                              
                                                                                <asp:TemplateField>
                                                                                    <EditItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 50%">
                                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update">
                                                                                                        </asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 50%">
                                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel">
                                                                                                        </asp:ImageButton>
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
                                                                                                        <asp:UpdatePanel ID="upnlBtnAdd" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add">
                                                                                                                </asp:ImageButton>
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <HeaderStyle Width="40px"></HeaderStyle>
                                                                                    <ItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 50%">
                                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit">
                                                                                                        </asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 50%">
                                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                                            OnClientClick='return confirm("Are you sure you want to delete this catalyst?");'>
                                                                                                        </asp:ImageButton>
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
                                                            </asp:Panel>
                                                        </td>                                        
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ObjectDataSource ID="odsCatalysts" runat="server" FilterExpression="(Deleted = 0)"
                                                                            SelectMethod="GetCatalystsNew" 
                                                                            TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_edit"
                                                                            DeleteMethod="DummyCatalystsNew" InsertMethod="DummyCatalystsNew" UpdateMethod="DummyCatalystsNew" >
                                                                        </asp:ObjectDataSource>
                                                                        
                                                                        <asp:ObjectDataSource ID="odsCatalystsName" runat="server" CacheDuration="120" EnableCaching="True"
                                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                                                                            TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningCatalystsList">
                                                                            <SelectParameters>
                                                                                <asp:SessionParameter DefaultValue="-1" Name="catalystId" Type="Int32" />
                                                                                <asp:Parameter DefaultValue="(Select)" Name="name" Type="String" />
                                                                                <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>    
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                             <asp:UpdatePanel ID="upnlWetOutDataCatalystGrey" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblWetOutDataCatalystGrey" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                             </asp:UpdatePanel>
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
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblWetOutDataTotalTubeLengthDetermination" runat="server" SkinID="LabelBold"
                                                                Text="Total Tube Length Determination"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataInversionType" runat="server" SkinID="Label" Text="Inversion Type"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataDepthOfInversionMH" runat="server" SkinID="LabelSmall"
                                                                Text="Depth Of Inversion MH (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format. Default value 0ft</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeForColumn" runat="server" SkinID="LabelSmall" Text="Tube For Column (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format. Default value 16ft</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTubeForStartDry" runat="server" SkinID="LabelSmall" Text="Tube For Start Dry (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format. Default value 3ft</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataTotalTube" runat="server" SkinID="Label" Text="Total Tube (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataInversionType" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlWetOutDataInversionType" runat="server" SkinID="DropDownList"
                                                                        Style="width: 108px" AutoPostBack="true" OnSelectedIndexChanged="ddlWetOutDataInversionType_SelectedIndexChanged">
                                                                        <asp:ListItem Value="(Select)" Selected="True">(Select)</asp:ListItem>
                                                                        <asp:ListItem Value="Top">Top</asp:ListItem>
                                                                        <asp:ListItem Value="Bottom">Bottom</asp:ListItem>
                                                                        <asp:ListItem Value="Not Inversion">Not Inversion</asp:ListItem>
                                                                    </asp:DropDownList>          
                                                            </ContentTemplate>
                                                             </asp:UpdatePanel>                                                      
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataDepthOfInversionMH" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataDepthOfInversionMH" runat="server" SkinID="TextBoxBlueText"
                                                                        Style="width: 108px"></asp:TextBox>   
                                                                </ContentTemplate>
                                                             </asp:UpdatePanel>                                                         
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataTubeForColumn" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                               
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxWetOutDataTubeForStartDry" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                            
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataTotalTube" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataTotalTube" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataInversionType" runat="server" 
                                                                SkinID="Validator" ValidationGroup="flWetOutData" ErrorMessage="Please select an inversion."
                                                                Display="Dynamic" ControlToValidate="ddlWetOutDataInversionType" 
                                                                InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataDepthOfInversionMH" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the depth of inversion"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataDepthOfInversionMH"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataDepthOfInversionMH" runat="server" ControlToValidate="tbxWetOutDataDepthOfInversionMH"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataTubeForColumn" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the tube for column"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataTubeForColumn"></asp:RequiredFieldValidator>                 
                                                            <asp:CompareValidator ID="cvWetOutDataTubeForColumn" runat="server" ControlToValidate="tbxWetOutDataTubeForColumn"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataTubeForStartDry" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the tube for start dry"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataTubeForStartDry"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvWetOutDataTubeForStartDry" runat="server" ControlToValidate="tbxWetOutDataTubeForStartDry"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
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
                                                            <asp:Label ID="lblWetOutDataDropTubeConnects" runat="server" SkinID="Label" Text="DropTube Connects"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataAllowsHeadTo" runat="server" SkinID="Label" Text="Allows Head To (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataRollerGap" runat="server" SkinID="Label" Text="Roller Gap (mm)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 13</b><span
                                                                    class="hint"></span> </a>
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
                                                            <asp:UpdatePanel ID="upnlWetOutDataDropTubeConnects" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataDropTubeConnects" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataAllowsHeadTo" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataAllowsHeadTo" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataRollerGap" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataRollerGap" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"
                                                                        AutoPostBack="true"></asp:TextBox>
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
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvWetOutDataRollerGap" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flWetOutData" ErrorMessage="Please provide the roller gap"
                                                                Display="Dynamic" ControlToValidate="tbxWetOutDataRollerGap"></asp:RequiredFieldValidator>                                                        
                                                             <asp:CompareValidator ID="cvWetOutDataRollerGap" runat="server" ControlToValidate="tbxWetOutDataRollerGap"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flWetOutData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="text-align:center"> 
                                                            <asp:UpdatePanel ID="upnlWetOutGraphic" runat="server">
                                                                <ContentTemplate>                                           
                                                                    <asp:Panel ID="upnlGraphic" runat="server"  SkinID="FLWetOutPanel" ScrollBars="None" Width="460px" Height="93px" >
                                                                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="width: 70px"></td>                                                            
                                                                                <td style="width: 290px"></td>
                                                                                <td style="width: 100px"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>                                                            
                                                                                <td style="text-align:center">
                                                                                    <asp:Label ID="lblWetOutDataDimensionLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>                                                            
                                                                                <td style="text-align:center">
                                                                                    <asp:Label ID="lblWetOutDataTotalTubeLengthlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                    
                                                                                </td>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblWetOutDataForColumnLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 20px" colspan="3">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:right">
                                                                                    <asp:Label ID="lblWetOutDataDryFtLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>                                                            
                                                                                <td style="text-align:center">
                                                                                    <asp:Label ID="lblWetOutDataWetOutLengthlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblWetOutDataDryFtEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 20px" colspan="3">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td  style="text-align:right">
                                                                                    <asp:Label ID="lblWetOutDataTailEndlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>                                                            
                                                                                <td  style="text-align:center">
                                                                                    <asp:Label ID="lblWetOutDataRollerGapLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblWetOutDataColumnEndlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                             
                                                                    </asp:Panel>        
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>                                   
                                                        </td>                                            
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblWetOutDataHoistHeightCheck" runat="server" SkinID="LabelBold" Text="Hoist Height Check"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataHeightNeeded" runat="server" SkinID="Label" Text="Height Needed (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataAvailable" runat="server" SkinID="Label" Text="Available"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWetOutDataHoistHeight" runat="server" SkinID="Label" Text="Hoist Height?"></asp:Label>
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
                                                            <asp:UpdatePanel ID="upnlWetOutDataHeightNeeded" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataHeightNeeded" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataAvailable" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataAvailable" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>    
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataHoistHeight" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxWetOutDataHoistHeight" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlWetOutDataWarning" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblWetOutDataWarning" runat="server" SkinID="LabelError" Text="WARNING!"></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>     
                                                        </td>
                                                        <td colspan = "2">                                                    
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                <tr>
                                                                    <td  style="width: 42px">                                                                   
                                                                    </td>
                                                                    <td style="width: 106px">
                                                                        <asp:UpdatePanel ID="upnlBtnWetOutCalculate" runat="server">
                                                                            <Triggers> 
                                                                                <asp:AsyncPostBackTrigger ControlID="btnWetOutCalculate" EventName="Click"/>
                                                                            </Triggers>
                                                                            <ContentTemplate>                                                                        
                                                                                <asp:Button ID="btnWetOutCalculate" OnClick="btnWetOutCalculateOnClick" runat="server" SkinID="Button"
                                                                                Text="Calculate" EnableViewState="True" Width="80px"></asp:Button>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        
                                                                        <asp:UpdateProgress ID="upWetOutCalculate" runat="server" AssociatedUpdatePanelID="upnlBtnWetOutCalculate">
                                                                            <ProgressTemplate>
                                                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                    </td>
                                                                    <td style="width: 90px">
                                                                        <asp:Button ID="btnWetOutPrintCurrent" OnClick="btnWetOutPrintCurrentOnClick" runat="server" SkinID="Button"
                                                                        Text="Print" EnableViewState="True" Width="80px"></asp:Button>  
                                                                    </td>
                                                                </tr>
                                                            </table>                                                    
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
                                                        <td style="width: 148px">
                                                        </td>
                                                        <td style="width: 90px">
                                                        </td>
                                                    </tr>                                                
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblWetOutDataNotes" runat="server" SkinID="Label"
                                                                Text="Notes"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>                                             
                                                            <asp:Button ID="btnWetOutDataNotes" OnClick="btnWetOutDataNotesOnClick" 
                                                                runat="server" SkinID="Button" Text="Update" Width="80px"></asp:Button>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="tbxWetOutDataNotes" runat="server" ReadOnly="True" Rows="20"
                                                                SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                
                                                    <tr>
                                                        <td style="height: 30px" colspan="6">
                                                        </td>
                                                    </tr>
                                                </table>                                                                          
                                                
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpInversionCure" runat="server" HeaderText="Inversion & Cure" OnClientClick="tpInversionCureClientClick">
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
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataIncludeInversionInformation" runat="server" SkinID="Label" Text="Include Wet Out - Inversion Information"></asp:Label>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td colspan="6"> 
                                                <asp:UpdatePanel ID="upnlnversionDataIncludeInversionInformation" runat="server">
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="ckbxInversionDataIncludeInversionInformation" runat="server" SkinID="CheckBox" 
                                                        OnCheckedChanged="InversionDataInversionVisibleInformation_OnCheckedChanged" AutoPostBack="true" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:UpdatePanel ID="uplInversionDataInversionMissingData" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblInversionDataInversionMissingData" runat="server" SkinID="LabelError" Text="Please provide wet out information before calculating inversion and cure"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>  
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr> 
                                    </table>
                                                               
                                    <asp:UpdatePanel ID="upnlInversionVisibleInformation" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>                                                 
                                            <asp:Panel ID="pnlInversionVisibleInformation" runat="server" Width="100%">                                        
                                                <!-- Table element: 6 columns  -->
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblInversionTitle" runat="server" SkinID="LabelTitle2" Text="Inversion And Cure Sheet"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                </table>                                                                            
                                                
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlInversionDataSubtitle" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblInversionDataSubtitle" runat="server" SkinID="LabelTitle2" Text="For:"></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>                                                    
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>                                                                                               
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblInversionDataNote" runat="server" SkinID="Label" Text="SHEET IS THEORETICAL GUIDE. WHERE REQUIRED, FIELD ADJUST PARAMETERS TO SUIT ACTUAL CONDITIONS"></asp:Label>
                                                        </td>                                                    
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataDateOfSheet" runat="server" SkinID="Label" Text="Date Of Sheet"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblInversionDataMadeBy" runat="server" SkinID="Label" Text="Made By"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataInstalledOn" runat="server" SkinID="Label" Text="Installed On"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataRunDetails" runat="server" SkinID="Label" Text="Run Details"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr  style="vertical-align:top; height:50px">
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataDateOfSheet" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataDateOfSheet" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel ID="upnlInversionDataMadeBy" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataMadeBy" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 226px"></asp:TextBox>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>                                                    
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataInstalledOn" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataInstalledOn" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlInversionDataSectionId" Width="108px" Height="50px" runat="server" SkinID="PanelReadOnly">
                                                                <asp:UpdatePanel ID="upnlInversionDataCbxlSectionId" runat="server">
                                                                   <ContentTemplate>
                                                                        <asp:CheckBoxList ID="cbxlInversionDataSectionId" runat="server" SkinID="CheckBoxListWithoutBorderReadOnly" 
                                                                       onclick="return cbxSelectedClick(event);" Enabled="false" ></asp:CheckBoxList> 
                                                                   </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                           </asp:Panel>                                               
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataRunDetails2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataRunDetails2" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblInversionDataComment" runat="server" SkinID="Label" Text="Comment / Note"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="tbxInversionDataCommentsEdit" Style="width: 700px"  runat="server"
                                                                SkinID="TextBox" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataLinerSize" runat="server" SkinID="Label" Text="Liner Size"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataRunLength" runat="server" SkinID="Label" Text="Run Length"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataWetOutLenght" runat="server" SkinID="Label" Text="Wet Out Lenght"></asp:Label>
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
                                                            <asp:UpdatePanel ID="upnlInversionDataLinerSize" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataLinerSize" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                                
                                                        </td>
                                                        <td>
                                                             <asp:UpdatePanel ID="upnlInversionDataRunLength" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataRunLength" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataWetOutLenght" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataWetOutLenght" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlInversionDataLinerInfoGrey" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblInversionDataLinerInfoGrey" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlInversionDataHeadsGrey" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblInversionDataHeadsGrey" runat="server" SkinID="Label" Text=""></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataPipeType" runat="server" SkinID="Label" Text="Pipe Type"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataPipeCondition" runat="server" SkinID="Label" Text="Pipe Condition"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataGroundMoisture" runat="server" SkinID="Label" Text="Ground Moisture"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataBoilerSize" runat="server" SkinID="Label" Text="Boiler Size, Btu/hr"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 7.000.000</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataPumpsTotalCapacity" runat="server" SkinID="Label"
                                                                Text="Pump(s) Total Capacity (usgpm)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 300</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataLayflatSize" runat="server" SkinID="Label" Text="Layflat Size"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 4</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlInversionDataInversionPipeType" runat="server" DataMember="DefaultView"
                                                                DataSourceID="odsPipeType" DataTextField="PipeType" DataValueField="PipeType"
                                                                SkinID="DropDownList" Style="width: 108px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlInversionDataPipeCondition" runat="server" DataMember="DefaultView"
                                                                DataSourceID="odsPipeCondition" DataTextField="PipeCondition" DataValueField="PipeCondition"
                                                                SkinID="DropDownList" Style="width: 108px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>                    
                                                            <asp:DropDownList ID="ddlInversionDataGroundMoisture" runat="server" DataMember="DefaultView"
                                                                DataSourceID="odsGroundMoisture" DataTextField="GroundMoisture" DataValueField="GroundMoisture"
                                                                SkinID="DropDownList" Style="width: 108px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataBoilerSize" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                       
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataPumpsTotalCapacity" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataLayflatSize" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                     
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataInversionPipeType" runat="server" SkinID="Validator"
                                                                EnableViewState="True" ValidationGroup="flInversionData" ErrorMessage="Please select a pipe type."
                                                                Display="Dynamic" ControlToValidate="ddlInversionDataInversionPipeType" InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataPipeCondition" runat="server" SkinID="Validator"
                                                                EnableViewState="True" ValidationGroup="flInversionData" ErrorMessage="Please select a pipe condition."
                                                                Display="Dynamic" ControlToValidate="ddlInversionDataPipeCondition" InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataGroundMoisture" runat="server" SkinID="Validator"
                                                                EnableViewState="True" ValidationGroup="flInversionData" ErrorMessage="Please select a ground moisture."
                                                                Display="Dynamic" ControlToValidate="ddlInversionDataGroundMoisture" InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataBoilerSize" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the boiler size"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataBoilerSize"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataBoilerSize" runat="server" ControlToValidate="tbxInversionDataBoilerSize"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataPumpsTotalCapacity" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the pumps total capacity"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataPumpsTotalCapacity"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataPumpsTotalCapacity" runat="server" ControlToValidate="tbxInversionDataPumpsTotalCapacity"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataLayflatSize" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the layflat size"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataLayflatSize"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataLayflatSize" runat="server" ControlToValidate="tbxInversionDataLayflatSize"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataLayflatQuantityTotal" runat="server" SkinID="Label" Text="Layflat Quantity - Total"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 1</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataLayflatQuantityTotal" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataLayflatQuantityTotal" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the layflat quantity total"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataLayflatQuantityTotal"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataLayflatQuantityTotal" runat="server" ControlToValidate="tbxInversionDataLayflatQuantityTotal"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
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
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataWaterStartTempTs" runat="server" SkinID="Label" Text="Water Start Temp Ts (°F)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 45</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataTempT1" runat="server" SkinID="Label" Text="Temp T1 (°F)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 120</b><span                                                          
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataHoldAtT1For" runat="server" SkinID="Label" Text="Hold At T1 For (hr)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 0.5</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataTempT2" runat="server" SkinID="Label" Text="Temp T2 (°F)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 185</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataCookAtT2For" runat="server" SkinID="LabelSmall" Text="Cook At T2 For (hr)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 2</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataCoolDownFor" runat="server" SkinID="Label" Text="Cool Down for (hr)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 1</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataWaterStartTempTs" runat="server" SkinID="TextBoxBlueText"
                                                                Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataTempT1" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                        
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataHoldAtT1For" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataTempT2" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataCookAtT2For" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataCoolDownFor" runat="server" SkinID="TextBoxBlueText" Style="width: 108px" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataWaterStartTempTs" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the water start temp"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataWaterStartTempTs"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataWaterStartTempTs" runat="server" ControlToValidate="tbxInversionDataWaterStartTempTs"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataTempT1" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the temp t1"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataTempT1"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataTempT1" runat="server" ControlToValidate="tbxInversionDataTempT1"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataHoldAtT1For" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the hold at t1 for info"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataHoldAtT1For"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataHoldAtT1For" runat="server" ControlToValidate="tbxInversionDataHoldAtT1For"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataTempT2" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the temp t2"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataTempT2"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataTempT2" runat="server" ControlToValidate="tbxInversionDataTempT2"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataCookAtT2For" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the cook at t2 info"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataCookAtT2For"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataCookAtT2For" runat="server" ControlToValidate="tbxInversionDataCookAtT2For"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataCoolDownFor" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the cool down for info"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataCoolDownFor"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataCoolDownFor" runat="server" ControlToValidate="tbxInversionDataCoolDownFor"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataCoolToTemp" runat="server" SkinID="LabelSmall" Text="Cool To Temp, Tc (°F)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.  Default Value 85</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataDropInPipeRun" runat="server" SkinID="LabelSmall" Text="Drop In Pipe Run (ft)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Please use X.Y format.</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataPipeSlopeOf" runat="server" SkinID="LabelSmall" Text="= Pipe Slope Of (%)"></asp:Label>
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
                                                            <asp:TextBox ID="tbxInversionDataCoolToTemp" runat="server" SkinID="TextBoxBlueText" Style="width: 108px"></asp:TextBox>                                                       
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInversionDataDropInPipeRun" runat="server" SkinID="TextBox" Style="width: 108px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataPipeSlopeOf" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataPipeSlopeOf" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
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
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataCoolToTemp" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the cool to temp info"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataCoolToTemp"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataCoolToTemp" runat="server" ControlToValidate="tbxInversionDataCoolToTemp"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvInversionDataDropInPipeRun" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ValidationGroup="flInversionData" ErrorMessage="Please provide the drop in pipe run info"
                                                                Display="Dynamic" ControlToValidate="tbxInversionDataDropInPipeRun"></asp:RequiredFieldValidator>                                                        
                                                            <asp:CompareValidator ID="cvInversionDataDropInPipeRun" runat="server" ControlToValidate="tbxInversionDataDropInPipeRun"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use X.Y)"
                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="flInversionData"></asp:CompareValidator>
                                                        </td>
                                                       <tr></tr>
                                                       <tr></tr>
                                                       <tr></tr>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblInversionDataSubtitle2" runat="server" SkinID="LabelBold" Text="Aprox Time"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionData45F120F" runat="server" SkinID="Label" Text="45°F-120°F (hr)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Time to raise from Ts to T1</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataHold" runat="server" SkinID="Label" Text="Hold (hr)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionData120F185F" runat="server" SkinID="Label" Text="120°F-185°F (hr)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Time to raise from T1 to T2</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataCookTime" runat="server" SkinID="Label" Text="Cook Time (hr)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataCoolTime" runat="server" SkinID="Label" Text="Cool Time (hr)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataAproxTotal" runat="server" SkinID="Label" Text="Aprox Total (hr)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Total estimated approximate time from boiler on until cool-down complete.</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                             <asp:UpdatePanel ID="upnlInversionData45F120F" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionData45F120F" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataHold" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataHold" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionData120F185F" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionData120F185F" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>    
                                                            <asp:UpdatePanel ID="upnlInversionDataCookTime" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataCookTime" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataCoolTime" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataCoolTime" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataAproxTotal" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataAproxTotal" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                             <asp:UpdatePanel ID="upnlInversionGraphic" runat="server">
                                                                <ContentTemplate>                                           
                                                                    <asp:Panel ID="upnlInversionGraphic1" runat="server"  SkinID="FLInversionPanel" ScrollBars="None" Width="428px" Height="173px" >
                                                                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="width: 70px; height:7px"></td>                                                            
                                                                                <td style="width: 50px"></td>
                                                                                <td style="width: 156px"></td>
                                                                                <td style="width: 50px"></td>
                                                                                <td style="width: 52px"></td>
                                                                                <td style="width: 50px"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>                                                            
                                                                                <td style="text-align:left" colspan="2">
                                                                                    <asp:Label ID="lblInversionDataColumnHeadLabel" runat="server" SkinID="LabelSmall" Text="If Column Head at"></asp:Label>
                                                                                </td>                                                                    
                                                                                <td  style="text-align:right" colspan="3">
                                                                                    <asp:Label ID="lblInversionDataCorrespongingHeadAtEndLabel" runat="server" SkinID="LabelSmall" Text="Corresponding Head at End"></asp:Label>
                                                                                </td>                                                                                                                                     
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px" colspan="6">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>    
                                                                                <td></td>                                                        
                                                                                <td colspan="2">
                                                                                    <asp:Label ID="lblInversionDataMaxColdForTubeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>                                                                    
                                                                                
                                                                                <td style="text-align:right">
                                                                                    <asp:Label ID="lblInversionDataMaxColdForTubeEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>     
                                                                            <tr>
                                                                                <td style="height: 5px" colspan="6">
                                                                                </td>
                                                                            </tr>                                                           
                                                                            <tr>
                                                                                <td></td>                                                            
                                                                                <td></td>
                                                                                <td  colspan="2">
                                                                                    <asp:Label ID="lblInversionDataMaxHotForTubeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>                                                                                                                                        
                                                                                <td style="text-align:right">
                                                                                    <asp:Label ID="lblInversionDataMaxHotForTubeEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                                </td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>
                                                                                <td style="height: 5px" colspan="6">
                                                                                </td>
                                                                            </tr>                                                                   
                                                                            <tr>
                                                                                <td></td>                                                            
                                                                                <td></td>
                                                                                <td  colspan="2">
                                                                                    <asp:Label ID="lblInversionDataIdelForTubeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>                                                                                                                                       
                                                                                <td style="text-align:right">
                                                                                    <asp:Label ID="lblInversionDataIdelForTubeEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 20px" colspan="6">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblInversionDataPumpHeightLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                                </td>                                                                                                                                
                                                                                <td style="text-align:center" colspan="3">
                                                                                    <asp:Label ID="lblInversionDataLinerSizeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                                </td>                                                                    
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>                                                                                                                                
                                                                                <td style="text-align:center" colspan="3">
                                                                                    <asp:Label ID="lblInversionDataRunLengthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                                </td>                                                                    
                                                                                <td  style="text-align:right">
                                                                                    <asp:Label ID="lblInversionDataEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td  style="text-align:left">
                                                                                    <asp:Label ID="lblInversionDataDepthOfInversionMHLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                                </td>                                                            
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                        </table>                                             
                                                                    </asp:Panel>        
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>                                                
                                                        <td colspan = "2">                                                    
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                <tr>
                                                                    <td  style="width: 42px">                                                                   
                                                                    </td>
                                                                    <td style="width: 106px">
                                                                        <asp:UpdatePanel ID="upnlBtnInversionCalculate" runat="server">
                                                                            <Triggers> 
                                                                                <asp:AsyncPostBackTrigger ControlID="btnInversionCalculate" EventName="Click"/>
                                                                            </Triggers>
                                                                            <ContentTemplate>                                                                        
                                                                                <asp:Button ID="btnInversionCalculate" OnClick="btnWetOutCalculateOnClick" runat="server" SkinID="Button"
                                                                                Text="Calculate" EnableViewState="True" Width="80px"></asp:Button>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        
                                                                        <asp:UpdateProgress ID="upInversionCalculate" runat="server" AssociatedUpdatePanelID="upnlBtnInversionCalculate">
                                                                            <ProgressTemplate>
                                                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>                                                              
                                                                    </td>
                                                                    <td style="width: 90px">
                                                                        <asp:Button ID="btnInversionPrintCurrent" OnClick="btnInversionPrintCurrentOnClick" runat="server" SkinID="Button"
                                                                        Text="Print" EnableViewState="True" Width="80px"></asp:Button>  
                                                                    </td>
                                                                </tr>
                                                            </table>                                                    
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel ID="upnlInversionDataPumpingCirculationSubtitle" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblInversionDataPumpingCirculationSubtitle" runat="server" SkinID="LabelBold"
                                                                        Text="Pumping & Circulation "></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataWaterChangesPerHour" runat="server" SkinID="Label"
                                                                Text="Water Changes Per Hour"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Is the number of times in 1 hour that all the water in the liner is completely  recirculated.</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataReturnWaterVelocity" runat="server" SkinID="Label"
                                                                Text="Return Water Velocity (ft/sec)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">Is the velocity of the water returning back up the liner to the inversion column. It assumes that all the water is coming of the tail end of the layflat. (IE no leaks or holes in layflat)</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataLayflatBackPressure" runat="server" SkinID="Label"
                                                                Text="Layflat Back Pressure (psi)"></asp:Label>
                                                            <a href="#" class="hint">
                                                                <img onclick="return false;" src="./../../App_Themes/LFS2/images/question_mark.gif"
                                                                    alt="Help" style="border-style: none; border-color: #DFE7EC; width: 10px; height: 10px;" />
                                                                <b class="hint">This is the pressure needed to force the water through the layflat (IE pump back pressure needed). It assumes that all the water comes out of the tail end of the layflat (IE no holes  or leaks)</b><span
                                                                    class="hint"></span> </a>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataPumpLiftAtIdealHead" runat="server" SkinID="Label"
                                                                Text="Pump Lift At Ideal Head (ft)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataWaterToFillLinerColumn" runat="server" SkinID="Label"
                                                                Text="Water To Fill Liner & Column (usg)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInversionDataWaterPerFit" runat="server" SkinID="Label" Text="Water Per Fit (usg/ft)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataWaterChangesPerHour" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataWaterChangesPerHour" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataReturnWaterVelocity" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataReturnWaterVelocity" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataLayflatBackPressure" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataLayflatBackPressure" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataPumpLiftAtIdealHead" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataPumpLiftAtIdealHead" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataWaterToFillLinerColumn" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataWaterToFillLinerColumn" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlInversionDataWaterPerFit" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxInversionDataWaterPerFit" runat="server" SkinID="TextBoxReadOnly"
                                                                        Style="width: 108px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                                                
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblInversionDataFieldCureRecord" runat="server" SkinID="LabelTitle2" Text="Field Cure Record"></asp:Label>
                                                        </td>
                                                    </tr>                                                
                                                    <tr>
                                                        <td style="height: 10px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6"> 
                                                            <asp:Button ID="btnAddFieldCureRecords" OnClick="btnAddFieldCureRecordsOnClick" runat="server" SkinID="Button"
                                                                Text="Add Field Cure Records" EnableViewState="True" Width="226px"></asp:Button>
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
                                                
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
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
                                                        <td style="width: 118px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblInversionDataNotesAndInstallationResults" runat="server" SkinID="Label" Text="Notes And Installation Results"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:TextBox Style="width: 700px" ID="tbxInversionDataNotesAndInstallationResults" runat="server"
                                                                SkinID="TextBox" TextMode="MultiLine" Rows="5" EnableViewState="true"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                
                                                    <tr>
                                                        <td style="height: 30px" colspan="6">
                                                        </td>
                                                    </tr>
                                                </table>                                                                                                                  
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpInstallData" runat="server" HeaderText="Install Data" OnClientClick="tpInstallDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
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
                                                <asp:Label ID="lblInstallDataInstallDate" runat="server" SkinID="Label" Text="Install Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInstallDataFinalVideoDate" runat="server" SkinID="Label" Text="Final Video Date"></asp:Label>
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
                                                <asp:UpdatePanel ID="upnlInstallDataInstallDate" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadDatePicker ID="tkrdpInstallDataInstallDate" runat="server" SkinID="RadDatePicker" 
                                                            Width="108px" Calendar-ShowRowHeaders="false" 
                                                            Calendar-DayNameFormat="Short" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpInstallDataInstallDate_SelectedDateChanged">
                                                            <dateinput autopostback="True">
                                                            </dateinput>
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x">
                                                            </calendar>
                                                            <datepopupbutton hoverimageurl="" imageurl="" />
                                                        </telerik:RadDatePicker>
                                                     </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnlInstallDataFinalVideoDate" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadDatePicker ID="tkrdpInstallDataFinalVideoDate" runat="server" SkinID="RadDatePicker"
                                                            Width="108px" Culture="English (United States)" AutoPostBack="True" 
                                                            onselecteddatechanged="tkrdpInstallDataFinalVideoDate_SelectedDateChanged">
                                                            <calendar daynameformat="Short" showrowheaders="False" 
                                                            usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                            viewselectortext="x"></calendar>
                                                            <dateinput width="" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy"></dateinput>

                                                            <datepopupbutton cssclass="" hoverimageurl="" imageurl=""></datepopupbutton>
                                                        </telerik:RadDatePicker>
                                                    </ContentTemplate>
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
                                        <tr>
                                            <td style="height: 30px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpComments" runat="server" HeaderText="Comments" OnClientClick="tpCommentDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
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
                                                <asp:Label ID="lblCommentsDataComments" runat="server" EnableViewState="True" SkinID="Label"
                                                    Text="Comments Summary"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upnlComments" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnComments" OnClick="btnCommentsOnClick" runat="server" SkinID="Button"
                                                            Text="Update" EnableViewState="True" Width="80px"></asp:Button>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxCommentsDataComments" runat="server" ReadOnly="True" Rows="20"
                                                    SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
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
                    <asp:ObjectDataSource ID="odsSurfaceGrade" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningM2SurfaceGradeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="surfaceGrade" Type="String" />
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
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_edit" DeleteMethod="DummyFlAddLateralsNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyFlAddLateralsNew" InsertMethod="DummyFlAddLateralsNew"
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
                    <asp:ObjectDataSource ID="odsThicknessList" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Assets.LfsAssetSewerSectionThicknessList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="thickness" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                    
                    <asp:ObjectDataSource ID="odsLinerTube" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningWetOutLinerTubeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="linerTube" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsResins" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningResinsList">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="-1" Name="id" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select)" Name="resin" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsEmployees" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsGroundMoisture" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningInversionGroundMoistureList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="groundMoisture" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsPipeCondition" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningInversionPipeConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="pipeCondition" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsPipeType" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningInversionPipeTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="pipeType" Type="String" />
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
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfSectionId" runat="server" />
                    <asp:HiddenField ID="hdfFlowOrderId" runat="server" />
                    <asp:HiddenField ID="hdfWorkIdJl" runat="server" />
                    <asp:HiddenField ID="hdfErrorFieldList" runat="server" />
                    <asp:HiddenField ID="hdfResinId" runat="server" />
                    <asp:HiddenField ID="hdfMadeBy" runat="server" />
                    <asp:HiddenField ID="hdfRunDetails" runat="server" />
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
                        <items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </items>
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
