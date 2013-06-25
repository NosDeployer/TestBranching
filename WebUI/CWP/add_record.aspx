<%@ Page Language="c#" Codebehind="add_record.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.add_record" %>
   
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>LFS Combined Work Program</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="C#" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <link href="./../common/images/lfcss.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form method="post" runat="server">
        <!-- .. Script Manager -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 10px">                    
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
        </table>
    
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    &nbsp;</td>
                <!-- PAGE -->
                <td valign="top" style="width:800px">
                    <div>
                        <!-- Page element: Header -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td style="width:700px; height:50px"  background="./../common/images/im_header1.gif" >
                                    &nbsp;</td>
                                <td style="width:100px; height:50px" background="./../common/images/im_header2.gif">
                                </td>
                                <td style="width:100px; height:50px" background="./../common/images/im_header3.gif" >
                                    <table style="height:50px" cellspacing="0" cellpadding="0" width="100" border="0">
                                        <tr>
                                            <td style="width:85px;height:4px">
                                            </td>
                                            <td style="width:15px;" rowspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width:85px; height:23px">
                                                <asp:LinkButton ID="lkbtnSignOut" TabIndex="100" runat="server" CausesValidation="False"
                                                    CssClass="tMainLink" OnClick="lkbtnSignOut_Click">Sign out</asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width:85px; height:23px">
                                                <asp:LinkButton ID="lkbtnMenu" TabIndex="100" runat="server" CausesValidation="False"
                                                    CssClass="tMainLinkOrange" OnClick="lkbtnMenu_Click">Menu</asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        
                        <!-- Page element: Header buttons -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td style="width:700px; height:28px" background="./../common/images/im_header4.gif" >
                                    &nbsp;</td>
                                <td valign="middle" align="left" style="width:100px; height:28px" background="./../common/images/im_header5.gif">
                                    <asp:Button ID="btnOK1" TabIndex="52" runat="server" CssClass="tButtonOkCancel" Text="OK"
                                        EnableViewState="False" Width="90px" Height="22px" OnClick="btnOK_Click"></asp:Button></td>
                                <td valign="middle" align="left" style="width:100px; height:28px" background="./../common/images/im_header6.gif">
                                    <asp:Button ID="btnCancel1" TabIndex="53" runat="server" CausesValidation="False"
                                        CssClass="tButtonOkCancel" Text="Cancel" Width="90px" Height="22px" OnClick="btnCancel_Click">
                                    </asp:Button></td>
                            </tr>
                        </table>
                        <br/>
                        
                        <!-- Page element: Title with horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td>
                                    <div class="tTitle" style="width: 496px; position: relative; height: 19px">
                                        Add New Record&nbsp;</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="height:5px;width:900px" cellspacing="0" cellpadding="0"  border="0">
                                        <tr>
                                            <td>
                                                <img height="5" src="./../common/images/im_backrowblue.gif" width="900"/></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        
                        <!-- Page element: 6Columns -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr style="height:5px">
                                <td style="width:17%; height:5px">
                                </td>
                                <td style="width:17%; height:5px">
                                </td>
                                <td style="width:17%; height:5px">
                                </td>
                                <td style="width:17%; height:5px">
                                </td>
                                <td style="width:17%; height:5px">
                                </td>
                                <td style="width:17%; height:5px">
                                </td>
                            </tr>
                            <tr style="height:16px">
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        ID#</div>
                                </td>
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 16px">
                                        Client</div>
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        Client ID#</div>
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxRecordID" TabIndex="1" runat="server" CssClass="tTextField" Width="100px"></asp:TextBox></td>
                                <td style="width:17%" colspan="2">
                                    <asp:DropDownList ID="ddlCOMPANIES_ID" TabIndex="2" runat="server" CssClass="tTextField"
                                        Width="255px">
                                    </asp:DropDownList></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxClientID" TabIndex="3" runat="server" CssClass="tTextField" Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvRecordID1" runat="server" EnableViewState="False"
                                        Height="16px" Font-Size="Smaller" ErrorMessage="ID# already in use, type another please."
                                        Display="Dynamic" ControlToValidate="tbxRecordID" ValidationGroup="addRecord"></asp:CustomValidator>
                                    <asp:CustomValidator ID="cvRecordID2" runat="server" Height="16px"
                                        EnableViewState="False" ControlToValidate="tbxRecordID" Display="Dynamic" ErrorMessage="ID# archived, type another please."
                                        Font-Size="Smaller" ValidationGroup="addRecord"></asp:CustomValidator>
                                    <asp:RequiredFieldValidator ID="rfvRecordID" runat="server" EnableViewState="False"
                                        ControlToValidate="tbxRecordID" Display="Dynamic" ErrorMessage="Type an ID#."
                                        Font-Size="Smaller" ValidationGroup="addRecord"></asp:RequiredFieldValidator></td>
                                <td style="width:17%" colspan="2">
                                    <asp:CustomValidator ID="cvCOMPANIES_ID" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Select a client." Display="Dynamic" ControlToValidate="ddlCOMPANIES_ID" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:16%">
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr style="height:3px">
                                <td style="width:17%;height:3">
                                    &nbsp;</td>
                                <td style="width:17%;height:3">
                                    &nbsp;</td>
                                <td style="width:17%;height:3">
                                    &nbsp;</td>
                                <td style="width:16%;height:3">
                                    &nbsp;</td>
                                <td style="width:17%;height:3">
                                    <asp:CheckBox ID="cbxFullLengthLining" TabIndex="8" runat="server" CssClass="tLabel"
                                        Text="Full Length Lining?" Height="16px"></asp:CheckBox></td>
                                <td style="width:16%;height:3">
                                    &nbsp;</td>
                            </tr>
                            <tr style="height:16">
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        Sub Area</div>
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        City</div>
                                </td>
                                <td style="width:16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        Prov/State</div>
                                </td>
                                <td style="width:17%">
                                    <asp:CheckBox ID="cbxPointLining" TabIndex="9" runat="server" CssClass="tLabel" Text="Point Lining?"
                                        Width="96px" Height="16px"></asp:CheckBox></td>
                                <td style="width:16%">
                                    <asp:CheckBox ID="cbxSubcontractorLining" TabIndex="13" runat="server" CssClass="tLabel"
                                        Text="Subcontractor Lining?" Width="148px" Height="16px"></asp:CheckBox></td>
                            </tr>
                            <tr>
                                <td style="width:17%" colspan="2">
                                    <asp:TextBox ID="tbxSubArea" TabIndex="4" runat="server" CssClass="tTextField" Width="261"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxCity" runat="server" CssClass="tTextField" TabIndex="4" Width="100px"></asp:TextBox></td>
                                <td style="width:16%">
                                    <asp:TextBox ID="tbxProvState" runat="server" CssClass="tTextField" TabIndex="4"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:CheckBox ID="cbxLateralLining" TabIndex="10" runat="server" CssClass="tLabel"
                                        Text="Lateral Lining?" Width="112px"></asp:CheckBox></td>
                                <td style="width:16%">
                                    <asp:CheckBox ID="cbxOutOfScopeInArea" TabIndex="14" runat="server" CssClass="tLabel"
                                        Text="Out Of Scope / In Area" Width="152px" Height="16px"></asp:CheckBox></td>
                            </tr>
                            <tr style="height:16px">
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        Street</div>
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        USMH</div>
                                </td>
                                <td style="width:16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        DSMH</div>
                                </td>
                                <td style="width:17%">
                                    <asp:CheckBox ID="cbxJLiner" TabIndex="11" runat="server" CssClass="tLabel" Text="J-Liner?"
                                        Height="16px"></asp:CheckBox></td>
                                <td style="width:16%">
                                    <asp:CheckBox ID="cbxRehabAssessment" TabIndex="15" runat="server" CssClass="tLabel"
                                        Text="Rehab Assessment?" Height="16px"></asp:CheckBox></td>
                            </tr>
                            <tr>
                                <td style="width:17%" colspan="2">
                                    <asp:TextBox ID="tbxStreet" TabIndex="5" runat="server" CssClass="tTextField" Width="261"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxUSMH" TabIndex="6" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:16%">
                                    <asp:TextBox ID="tbxDSMH" TabIndex="7" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:CheckBox ID="cbxGrouting" TabIndex="12" runat="server" CssClass="tLabel" Text="Grouting?"
                                        Height="16px"></asp:CheckBox></td>
                                <td style="width:16%">
                                    <asp:CheckBox ID="cbxFullLengthPointLiner" TabIndex="16" runat="server" CssClass="tLabel"
                                        Text="Full Length Point Liner?" Width="155px" Height="16px"></asp:CheckBox></td>
                            </tr>
                        </table>
                        <br/>
                        <br/>
                        <!-- Data element: Horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td>
                                    <hr style="width:100%" color="#c8dbed" size="2"/>
                                </td>
                            </tr>
                        </table>
                        <!-- Page element: 6Columns -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr style="height:16">
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        Map Size</div>
                                </td>
                                <td style="width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        Confirmed Size</div>
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxSize_" TabIndex="17" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxConfirmedSize" TabIndex="18" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td style="width:17%">
                                </td>
                                <td style="width:17%">
                                    <asp:RegularExpressionValidator ID="revConfirmedSize" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" ErrorMessage="Invalid data." Display="Dynamic" ControlToValidate="tbxConfirmedSize"
                                        ValidationExpression="\d*" ValidationGroup="addRecord"></asp:RegularExpressionValidator></td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr style="height:16px">
                                <td style="height: 1px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 2px">
                                        Scaled Length</div>
                                </td>
                                <td style="height: 1px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        Actual Length</div>
                                </td>
                                <td style="height: 1px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 6px">
                                        Live Lats</div>
                                </td>
                                <td style="height: 1px; width:16%">
                                    <div class="tLabel" style="display: inline; width: 108px; height: 14px">
                                        Estimated # Joints</div>
                                </td>
                                <td style="height: 1px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        CXI's Removed</div>
                                </td>
                                <td style="height: 1px; width:16%">
                                    <asp:Label ID="lblInstallRate" runat="server" CssClass="tLabel">Install Rate</asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 22px; width:17%">
                                    <asp:TextBox ID="tbxScaledLength" TabIndex="19" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="height: 22px; width:17%">
                                    <asp:TextBox ID="tbxActualLength" TabIndex="20" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="height: 22px; width:17%">
                                    <asp:TextBox ID="tbxLiveLats" TabIndex="21" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="height: 22px; width:16%">
                                    <asp:TextBox ID="tbxEstimatedJoints" TabIndex="22" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="height: 22px; width:17%">
                                    <asp:TextBox ID="tbxCXIsRemoved" TabIndex="23" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="height: 22px; width:16%">
                                    <asp:TextBox ID="tbxInstallRate" TabIndex="24" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr valign="top">
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvScaledLength" runat="server" ControlToValidate="tbxScaledLength"
                                        Display="Dynamic" ErrorMessage="Invalid data." Font-Size="Smaller" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvActualLength" runat="server" Font-Size="Smaller"
                                        ErrorMessage="Invalid data." Display="Dynamic" ControlToValidate="tbxActualLength" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                    <asp:RegularExpressionValidator ID="revLiveLats" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" ErrorMessage="Invalid data." Display="Dynamic" ControlToValidate="tbxLiveLats"
                                        ValidationExpression="\d*(\.\d+)?" ValidationGroup="addRecord"></asp:RegularExpressionValidator></td>
                                <td style="width:16%">
                                    <asp:RegularExpressionValidator ID="revEstimatedJoints" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" ErrorMessage="Invalid data." Display="Dynamic" ControlToValidate="tbxEstimatedJoints"
                                        ValidationExpression="\d*" ValidationGroup="addRecord"></asp:RegularExpressionValidator></td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                    <asp:RegularExpressionValidator ID="revInstallRate" runat="server" EnableViewState="False" Font-Size="Smaller" ErrorMessage="Invalid data." Display="Dynamic"
                                        ControlToValidate="tbxInstallRate" ValidationExpression="\d*(\.\d+)?" ValidationGroup="addRecord"></asp:RegularExpressionValidator></td>
                            </tr>
                        </table>
                        <br/>
                        <br/>
                        
                        <!-- Data element: Horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td>
                                    <hr style="width:100%" color="#c8dbed" size="2"/>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        
                        <!-- Page element: 6Columns -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr style="height:16px">
                                <td style="height: 8px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        Pre-Flush Date</div>
                                </td>
                                <td style="height: 8px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        Pre-Video Date</div>
                                </td>
                                <td style="height: 8px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 132px; height: 10px">
                                        Proposed Lining Date</div>
                                </td>
                                <td style="height: 8px; width:16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 7px">
                                        Deadline Date</div>
                                </td>
                                <td style="height: 8px; width:17%">
                                </td>
                                <td style="height: 8px; width:16%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxPreFlushDate" TabIndex="25" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxPreVideoDate" TabIndex="26" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxProposedLiningDate" TabIndex="27" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:16%">
                                    <asp:TextBox ID="tbxDeadlineDate" TabIndex="28" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvPreFlushDate" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxPreFlushDate" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvPreVideoDate" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxPreVideoDate" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvProposedLiningDate" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxProposedLiningDate" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:16%">
                                    <asp:CustomValidator ID="cvDeadlineDate" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxDeadlineDate" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                </td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr style="height:16">
                                <td style="height: 19px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        P1 Date</div>
                                </td>
                                <td style="height: 19px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        M1 Date</div>
                                </td>
                                <td style="height: 19px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        M2 Date</div>
                                </td>
                                <td style="height: 19px; width:16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        Install Date</div>
                                </td>
                                <td style="height: 19px; width:17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 6px">
                                        Final Video</div>
                                </td>
                                <td style="height: 19px; width:16%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxP1Date" TabIndex="29" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxM1Date" TabIndex="30" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxM2Date" TabIndex="31" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:16%">
                                    <asp:TextBox ID="tbxInstallDate" TabIndex="32" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:17%">
                                    <asp:TextBox ID="tbxFinalVideo" TabIndex="33" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px"></asp:TextBox></td>
                                <td style="width:16%">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvP1Date" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxP1Date" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvM1Date" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxM1Date" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvM2Date" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxM2Date" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:16%">
                                    <asp:CustomValidator ID="cvInstallDate" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxInstallDate" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:17%">
                                    <asp:CustomValidator ID="cvFinalVideo" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" Display="Dynamic" ControlToValidate="tbxFinalVideo" ValidationGroup="addRecord"></asp:CustomValidator></td>
                                <td style="width:16%">
                                </td>
                            </tr>
                        </table>
                        <br/>
                        <br/>
                        
                        <!-- Data element: Horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td>
                                    <hr style="width:100%" color="#c8dbed" size="2"/>
                                </td>
                            </tr>
                        </table>
                        
                        <!-- Page element: Custom -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td valign="top" style="width:34%">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td style="width:30%" colspan="2">
                                                <asp:CheckBox ID="cbxIssueIdentified" TabIndex="34" runat="server" CssClass="tLabel"
                                                    Text="Issue Identified?" Width="120px"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%">
                                                &nbsp;</td>
                                            <td style="width:70%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%">
                                            </td>
                                            <td style="width:70%">
                                                <asp:CheckBox ID="cbxLFSIssue" TabIndex="35" runat="server" CssClass="tLabel" Text="LFS Issue?"
                                                    Width="150px"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%">
                                            </td>
                                            <td style="width:70%">
                                                <asp:CheckBox ID="cbxClientIssue" TabIndex="36" runat="server" CssClass="tLabel"
                                                    Text="Client Issue?" Width="150px"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%">
                                            </td>
                                            <td style="width:70%">
                                                <asp:CheckBox ID="cbxSalesIssue" TabIndex="37" runat="server" CssClass="tLabel" Text="Sales Issue?"
                                                    Width="150px"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%">
                                            </td>
                                            <td style="width:70%">
                                                <asp:CheckBox ID="cbxInvestigationIssue" TabIndex="38" runat="server" CssClass="tLabel"
                                                    Text="Investigation Issue?" Width="136px"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%">
                                            </td>
                                            <td style="width:70%">
                                                <asp:CheckBox ID="cbxIssueGivenToBayCity" TabIndex="39" runat="server" CssClass="tLabel"
                                                    Text="Issue Given To Client?" Width="160px"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%">
                                            </td>
                                            <td style="width:70%">
                                                <asp:CheckBox ID="cbxIssueResolved" TabIndex="40" runat="server" CssClass="tLabel"
                                                    Text="Issue Resolved?" Width="150px"></asp:CheckBox></td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                </td>
                                <td valign="top" style="width:66%">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td style="width: 580px">
                                                <div class="tLabel" style="display: inline; width: 216px; height: 19px">
                                                    Point Repair / Grout / Lateral Details</div>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 580px">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 580px">
                                                <asp:UpdatePanel id="upnlPointRepairs" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdPointRepairs" runat="server" SkinID="GridView" Width="580px"
                                                        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID,RefID,COMPANY_ID" DataSourceID="odsPointRepairs"
                                                        OnDataBound="grdPointRepairs_DataBound" OnRowDataBound="grdPointRepairs_RowDataBound" 
                                                        OnRowUpdating="grdPointRepairs_RowUpdating" OnRowCommand="grdPointRepairs_RowCommand"
                                                        PageSize="5" ShowFooter="True" OnRowDeleting="grdPointRepairs_RowDeleting">
                                                            <Columns>                                                        
                                                                <asp:TemplateField HeaderText="ID" Visible ="False">
                                                                    <EditItemTemplate>                                                                        
                                                                        <asp:Label ID="lblId" runat="server" SkinID="Label" Text='<%# Eval("ID") %>'></asp:Label>                                                                                
                                                                    </EditItemTemplate>  
                                                                                                                              
                                                                    <ItemTemplate>                
                                                                        <asp:Label ID="lblId" runat="server" SkinID="Label" Text='<%# Eval("ID") %>'></asp:Label>                                                                               
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="RefID" Visible ="False">
                                                                    <EditItemTemplate>                                           
                                                                        <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                    </EditItemTemplate>                                                
                                                                                
                                                                    <ItemTemplate>                                                                     
                                                                         <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                    </ItemTemplate>                                                                    
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="DetailID" Visible ="False">
                                                                    <EditItemTemplate>                                                                        
                                                                        <asp:Label ID="lblDetailId" runat="server" SkinID="Label" Text='<%# Eval("DetailID") %>'></asp:Label>                                                                               
                                                                    </EditItemTemplate>                                                            
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblDetailId" runat="server" SkinID="Label" Text='<%# Eval("DetailID") %>'></asp:Label>                                                                                
                                                                    </ItemTemplate>                                                                    
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="COMPANY_ID" Visible ="False">
                                                                    <EditItemTemplate>                                                                        
                                                                        <asp:Label ID="lblCOMPANY_ID" runat="server" SkinID="Label" Text='<%# Eval("COMPANY_ID") %>'></asp:Label>                                                                                
                                                                    </EditItemTemplate>                                                            
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblCOMPANY_ID" runat="server" SkinID="Label" Text='<%# Eval("COMPANY_ID") %>'></asp:Label>                                                                                
                                                                    </ItemTemplate>                                                                    
                                                                </asp:TemplateField>                                   
                                                                    
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                            
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                                                                            
                                                                <asp:TemplateField HeaderText="Distance">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxDistanceEdit" runat="server" Text='<%# Eval("Distance") %>' Width="88px"
                                                                                        SkinID="TextBox"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDistanceFooter" runat="server"  Width="88px"
                                                                                        SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDistance" runat="server" SkinID="Label" Text='<%# Eval("Distance") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="88px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Size">
                                                                    <EditItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxRepairSizeEdit" runat="server" Text='<%# Eval("RepairSize") %>' Width="88px"
                                                                                        SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxRepairSizeFooter" runat="server"  Width="88px"
                                                                                        SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblRepairSize" runat="server" Text='<%# Eval("RepairSize") %>' SkinID="Label"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="88px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Reinstates">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxReinstatesEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Reinstates", "{0:n0}") %>'
                                                                                            Width="88px"></asp:TextBox>                                                                                                                                                                </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvReinstateEdit" runat="server" ControlToValidate="tbxReinstatesEdit"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="repairsEdit"></asp:CompareValidator></td>
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
                                                                                        <asp:TextBox ID="tbxReinstatesFooter" runat="server" SkinID="TextBox" Width="88px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvReinstateFooter" runat="server" ControlToValidate="tbxReinstatesFooter"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Integer" ValidationGroup="repairsFooter"></asp:CompareValidator></td>
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
                                                                                    <td>
                                                                                        <asp:Label ID="lblReinstates" runat="server" SkinID="Label" Text='<%# Eval("Reinstates", "{0:n0}") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="88px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Installed">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpInstallDateEdit" runat="server" Width="88px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
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
                                                                                        <telerik:RadDatePicker ID="tkrdpInstallDateFooter" runat="server" Width="88px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
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
                                                                                    <td>
                                                                                        <asp:Label ID="lblInstallDate" runat="server" SkinID="Label" Text='<%# Eval("InstallDate", "{0:d}") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="88px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Cost">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:TextBox ID="tbxCostEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Cost", "{0:n2}") %>'
                                                                                            Width="88px" ></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:CompareValidator ID="cvCostEdit" runat="server" ControlToValidate="tbxCostEdit"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="repairsEdit"></asp:CompareValidator></td>
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
                                                                                    <td align="right">
                                                                                        <asp:TextBox ID="tbxCostFooter" runat="server" SkinID="TextBox" Width="88px" ></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:CompareValidator ID="cvCostFooter" runat="server" ControlToValidate="tbxCostFooter"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="repairsFooter"></asp:CompareValidator></td>
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
                                                                                    <td align="right">
                                                                                        <asp:Label ID="lblCost" runat="server" SkinID="Label" Text='<%# Eval("Cost", "{0:n2}") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="88px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                                                                      
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" OnClientClick='return confirm("Are you sure you want to delete?");'>
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>                                                                                              
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMaxNumber" runat="server" SkinID="LabelError" Text="The maximum laterals amount was reached, no more laterals can be added."></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <!-- Page element: Custom -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td style="height:16px">
                                    <div class="tLabel" style="display: inline; width: 88px; height: 6px">
                                        Comments</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbxComments" TabIndex="44" runat="server" CssClass="tTextField"
                                        Width="891px" Height="85px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                        <br/>
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td style="height:16px">
                                    <div class="tLabel" style="display: inline; width: 88px; height: 6px">
                                        History</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbxHistory" TabIndex="45" runat="server" CssClass="tTextField" Width="891px"
                                        Height="85px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                        <br/>
                        <br/>
                    </div>
                </td>
                <!-- ENDPAGE -->
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
        
        <!-- Page element: Data objects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsPointRepairs" runat="server" 
                     SelectMethod="GetPointRepairsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.add_record" 
                     DeleteMethod="DummyPointRepairsNew" FilterExpression="(Deleted = 0)" 
                     UpdateMethod="DummyPointRepairsNew">
                        <DeleteParameters>
                            <asp:Parameter Name="ID"/>  
                            <asp:Parameter Name="RefID" Type="Int32" />                            
                            <asp:Parameter Name="COMPANY_ID" Type="Int32" /> 
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ID"  />  
                            <asp:Parameter Name="RefID" Type="Int32" />  
                            <asp:Parameter Name="COMPANY_ID" Type="Int32" /> 
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>               
       
        <!-- Page element:  refresh iFrame-->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <iframe id="iframe1" frameborder="0" height="0" width="0" src="./../refresh_iframe.aspx">
                        Your web browser don't accept iFrame tag. Contact with your Administrator. </iframe>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

