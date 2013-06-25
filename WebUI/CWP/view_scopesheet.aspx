<%@ Page Language="c#" Codebehind="view_scopesheet.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.view_scopesheet" %>

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
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td>&nbsp;
				    <!-- .. Script Manager -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
				</td>
                <!-- PAGE -->
                <td valign="top" width="800">
                    <div>
                        <!-- Page element: Header -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td width="700" background="./../common/images/im_header1.gif" height="50">
                                    &nbsp;</td>
                                <td width="100" background="./../common/images/im_header2.gif" height="50">
                                </td>
                                <td width="100" background="./../common/images/im_header3.gif" height="50">
                                    <table height="50" cellspacing="0" cellpadding="0" width="100" border="0">
                                        <tr>
                                            <td width="85" height="4">
                                            </td>
                                            <td width="15" rowspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="85" height="23">
                                                <asp:LinkButton ID="lkbtnSignOut" TabIndex="100" runat="server" CssClass="tMainLink"
                                                    CausesValidation="False" OnClick="lkbtnSignOut_Click">Sign out</asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="85" height="23">
                                                <asp:LinkButton ID="lkbtnMenu" TabIndex="100" runat="server" CssClass="tMainLinkOrange"
                                                    CausesValidation="False" OnClick="lkbtnMenu_Click">Menu</asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <!-- Page element: Header buttons -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td style="width: 718px" width="718" background="./../common/images/im_header4.gif" height="28">
                                    &nbsp;</td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_header5.gif" height="28">
                                    <asp:Button ID="btnOK1" TabIndex="47" runat="server" CssClass="tButtonOkCancel" Height="22px"
                                        Width="90px" EnableViewState="False" Text="OK" OnClick="btnOK_Click"></asp:Button></td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_header6.gif" height="28">
                                    <asp:Button ID="btnCancel1" TabIndex="48" runat="server" CssClass="tButtonOkCancel"
                                        CausesValidation="False" Height="22px" Width="90px" Text="Cancel" OnClick="btnCancel_Click">
                                    </asp:Button></td>
                            </tr>
                        </table>
                        <br>
                        <!-- Page element: Title with horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td>
                                    <div class="tTitle" style="width: 496px; position: relative; height: 19px">
                                        Point Liner Scope Sheet</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table height="5" cellspacing="0" cellpadding="0" width="900" border="0">
                                        <tr>
                                            <td>
                                                <img height="5" src="./../common/images/im_backrowblue.gif" width="900"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <!-- Page element: 6Columns -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr height="5">
                                <td width="17%" height="5">
                                </td>
                                <td width="17%" height="5">
                                </td>
                                <td width="17%" height="5">
                                </td>
                                <td style="width: 122px" width="122" height="5">
                                </td>
                                <td style="width: 147px" width="147" height="5">
                                </td>
                                <td width="16%" height="5">
                                </td>
                            </tr>
                            <tr height="16">
                                <td style="height: 7px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 2px">
                                        ID#</div>
                                </td>
                                <td style="height: 7px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 14px">
                                        Client</div>
                                </td>
                                <td style="height: 7px" width="17%">
                                </td>
                                <td style="width: 122px; height: 7px" width="122">
                                </td>
                                <td style="width: 147px; height: 7px" width="147">
                                </td>
                                <td style="height: 7px" width="16%">
                                </td>
                            </tr>
                            <tr>
                                <td width="17%">
                                    <asp:TextBox ID="tbxRecordID" TabIndex="1" runat="server" CssClass="tTextField" Width="100px"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>'
                                        ReadOnly="True">
                                    </asp:TextBox></td>
                                <td width="17%" colspan="2">
                                    <asp:TextBox ID="tbxCOMPANIES_ID" TabIndex="2" runat="server" CssClass="tTextField"
                                        Width="255px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 122px" width="122">
                                </td>
                                <td style="width: 147px" width="147">
                                    <asp:CheckBox ID="cbxIssueIdentified" TabIndex="8" runat="server" CssClass="tLabel"
                                        Width="120px" Text="Issue Identified?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueIdentified") %>'>
                                    </asp:CheckBox></td>
                                <td width="16%">
                                    <asp:CheckBox ID="cbxLFSIssue" TabIndex="9" runat="server" CssClass="tLabel" Width="88px"
                                        Text="LFS Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LFSIssue") %>'>
                                    </asp:CheckBox></td>
                            </tr>
                            <tr height="3">
                                <td width="17%" height="3">
                                    &nbsp;
                                    <asp:TextBox ID="tbxID" TabIndex="200" runat="server" Width="0px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>'
                                        ReadOnly="True">
                                    </asp:TextBox></td>
                                <td width="17%" height="3">
                                    &nbsp;</td>
                                <td width="17%" height="3">
                                    &nbsp;</td>
                                <td style="width: 122px" width="122" height="3">
                                    &nbsp;</td>
                                <td style="width: 147px" width="147" height="3">
                                    &nbsp;</td>
                                <td width="16%" height="3">
                                    <asp:CheckBox ID="cbxClientIssue" TabIndex="10" runat="server" CssClass="tLabel"
                                        Width="112px" Text="Client Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ClientIssue") %>'>
                                    </asp:CheckBox></td>
                            </tr>
                            <tr height="16">
                                <td style="height: 13px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 2px">
                                        Street</div>
                                </td>
                                <td style="height: 13px" width="17%">
                                </td>
                                <td style="height: 13px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 6px">
                                        USMH</div>
                                </td>
                                <td style="width: 122px; height: 13px" width="122">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 2px">
                                        DSMH</div>
                                </td>
                                <td style="width: 147px; height: 13px" width="147">
                                </td>
                                <td style="height: 13px" width="16%">
                                    <asp:CheckBox ID="cbxSalesIssue" TabIndex="11" runat="server" CssClass="tLabel" Width="104px"
                                        Text="Sales Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SalesIssue") %>'>
                                    </asp:CheckBox></td>
                            </tr>
                            <tr>
                                <td width="17%" colspan="2">
                                    <asp:TextBox ID="tbxStreet" TabIndex="3" runat="server" CssClass="tTextField" Width="261px"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Street") %>'>
                                    </asp:TextBox></td>
                                <td width="17%">
                                    <asp:TextBox ID="tbxUSMH" TabIndex="4" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMH") %>'>
                                    </asp:TextBox></td>
                                <td style="width: 122px" width="122">
                                    <asp:TextBox ID="tbxDSMH" TabIndex="5" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMH") %>'>
                                    </asp:TextBox></td>
                                <td style="width: 147px" width="147">
                                </td>
                                <td width="16%">
                                    <asp:CheckBox ID="cbxInvestigationIssue" TabIndex="12" runat="server" CssClass="tLabel"
                                        Width="136px" Text="Investigation Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].InvestigationIssue") %>'>
                                    </asp:CheckBox></td>
                            </tr>
                            <tr height="16">
                                <td style="height: 5px" width="17%">
                                </td>
                                <td style="height: 5px" width="17%">
                                </td>
                                <td style="height: 5px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 2px">
                                        USMH MN#</div>
                                </td>
                                <td style="width: 122px; height: 5px" width="122">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 2px">
                                        DSMH MN#</div>
                                </td>
                                <td style="width: 147px; height: 5px" width="147">
                                </td>
                                <td style="height: 5px" width="16%">
                                    <asp:CheckBox ID="cbxIssueGivenToBayCity" TabIndex="13" runat="server" CssClass="tLabel"
                                        Width="152px" Text="Issue Given To Client?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueGivenToBayCity") %>'>
                                    </asp:CheckBox></td>
                            </tr>
                            <tr>
                                <td width="17%" colspan="2">
                                </td>
                                <td width="17%">
                                    <asp:TextBox ID="tbxUSMHMN" TabIndex="6" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHMN") %>'>
                                    </asp:TextBox></td>
                                <td style="width: 122px" width="122">
                                    <asp:TextBox ID="tbxDSMHMN" TabIndex="7" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHMN") %>'>
                                    </asp:TextBox></td>
                                <td style="width: 147px" width="147">
                                </td>
                                <td width="16%">
                                    <asp:CheckBox ID="cbxIssueResolved" TabIndex="14" runat="server" CssClass="tLabel"
                                        Width="120px" Text="Issue Resolved?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueResolved") %>'>
                                    </asp:CheckBox></td>
                            </tr>
                        </table>
                        <br>
                        <!-- Data element: Horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td>
                                    <hr width="100%" color="#c8dbed" size="2">
                                </td>
                            </tr>
                        </table>
                        <!-- Page element: 6Columns -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr height="16">
                                <td style="height: 15px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 9px">
                                        Map Size</div>
                                </td>
                                <td style="height: 15px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 146px; height: 8px">
                                        Confirmed Size</div>
                                </td>
                                <td style="height: 15px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        Scaled Length</div>
                                </td>
                                <td style="height: 15px" width="16%">
                                    <div class="tLabel" style="display: inline; width: 114px; height: 4px">
                                        Actual Length</div>
                                </td>
                                <td style="height: 15px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 9px">
                                        P1 Date</div>
                                </td>
                                <td style="height: 15px" width="16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 1px">
                                        M1 Date</div>
                                </td>
                            </tr>
                            <tr>
                                <td width="17%">
                                    <asp:TextBox ID="tbxSize_" TabIndex="15" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Size_") %>'>
                                    </asp:TextBox></td>
                                <td width="17%">
                                    <asp:TextBox ID="tbxConfirmedSize" TabIndex="16" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ConfirmedSize") %>'>
                                    </asp:TextBox></td>
                                <td width="17%">
                                    <asp:TextBox ID="tbxScaledLength" TabIndex="17" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ScaledLength") %>'>
                                    </asp:TextBox></td>
                                <td width="16%">
                                    <asp:TextBox ID="tbxActualLength" TabIndex="18" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ActualLength") %>'>
                                    </asp:TextBox></td>
                                <td width="17%">
                                    <asp:TextBox ID="tbxP1Date" TabIndex="19" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].P1Date", "{0:d}") %>'>
                                    </asp:TextBox></td>
                                <td width="16%">
                                    <asp:TextBox ID="tbxM1Date" TabIndex="20" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].M1Date", "{0:d}") %>'>
                                    </asp:TextBox></td>
                            </tr>
                            <tr valign="top">
                                <td width="17%">
                                </td>
                                <td width="17%">
                                    <asp:RegularExpressionValidator ID="revConfirmedSize" runat="server" EnableViewState="False"
                                        ValidationExpression="\d*" Font-Size="Smaller" ErrorMessage="Invalid data" ControlToValidate="tbxConfirmedSize"
                                        Display="Dynamic"></asp:RegularExpressionValidator></td>
                                <td width="17%">
                                    <asp:CustomValidator ID="cvScaledLength" runat="server" Width="80px" Display="Dynamic"
                                        ControlToValidate="tbxScaledLength" ErrorMessage="Invalid data" Font-Size="Smaller"></asp:CustomValidator></td>
                                <td width="16%">
                                    <asp:CustomValidator ID="cvActualLength" runat="server" Width="100px" Font-Size="Smaller"
                                        ControlToValidate="tbxActualLength" Display="Dynamic" ValidateEmptyText="True"></asp:CustomValidator></td>
                                <td width="17%">
                                    <asp:CustomValidator ID="cvP1Date" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" ControlToValidate="tbxP1Date" Display="Dynamic"></asp:CustomValidator></td>
                                <td width="16%">
                                    <asp:CustomValidator ID="cvM1Date" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" ControlToValidate="tbxM1Date" Display="Dynamic"></asp:CustomValidator></td>
                            </tr>
                            <tr height="16">
                                <td style="height: 20px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 139px; height: 1px">
                                        Measurement Taken By</div>
                                </td>
                                <td style="height: 20px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 114px; height: 3px">
                                        Traffic Control</div>
                                </td>
                                <td style="height: 20px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 114px; height: 5px">
                                        Pipe Material Type</div>
                                </td>
                                <td style="height: 20px" width="16%">
                                    <div class="tLabel" style="display: inline; width: 114px; height: 2px">
                                        Robotic Distances</div>
                                </td>
                                <td style="height: 20px" width="17%">
                                    <asp:CheckBox ID="cbxBypassRequired" TabIndex="25" runat="server" CssClass="tLabel"
                                        Height="8px" Text="Bypass Required?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].BypassRequired") %>'>
                                    </asp:CheckBox></td>
                                <td style="height: 20px" width="16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 5px">
                                        Final Video</div>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 17px" width="17%">
                                    <asp:TextBox ID="tbxMeasurementsTakenBy" TabIndex="21" runat="server" CssClass="tTextFieldCenter"
                                        Width="140px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].MeasurementsTakenBy") %>'>
                                    </asp:TextBox></td>
                                <td style="height: 17px" width="17%">
                                    <asp:DropDownList ID="ddlDegreeOfTrafficControl" TabIndex="22" runat="server" CssClass="tTextField"
                                        Width="140px">
                                    </asp:DropDownList></td>
                                <td style="height: 17px" width="17%">
                                    <asp:TextBox ID="tbxPipeMaterialType" TabIndex="23" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].PipeMaterialType") %>'>
                                    </asp:TextBox></td>
                                <td style="height: 17px" width="16%">
                                    <asp:TextBox ID="tbxRoboticDistances" TabIndex="24" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RoboticDistances") %>'>
                                    </asp:TextBox></td>
                                <td style="height: 17px" width="17%" colspan="2">
                                    <asp:CheckBox ID="cbxRoboticPrepRequired" TabIndex="26" runat="server" CssClass="tLabel"
                                        Height="8px" Width="160px" Text="Robotic Prep Required?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RoboticPrepRequired") %>'>
                                    </asp:CheckBox><asp:TextBox ID="tbxFinalVideo" TabIndex="27" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].FinalVideo", "{0:d}") %>'>
                                    </asp:TextBox></td>
                            </tr>
                            <tr valign="top">
                                <td width="17%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                    <asp:CustomValidator ID="cvFinalVideo" runat="server" EnableViewState="False" Font-Size="Smaller"
                                        ErrorMessage="Invalid date" ControlToValidate="tbxFinalVideo" Display="Dynamic"></asp:CustomValidator></td>
                            </tr>
                        </table>
                        <!-- Page element: Custom -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td height="16">
                                    <div class="tLabel" style="display: inline; width: 78px; height: 2px">
                                        Comments</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbxComments" TabIndex="28" runat="server" CssClass="tTextField"
                                        Height="85px" Width="856px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Comments") %>'
                                        TextMode="MultiLine">
                                    </asp:TextBox></td>
                            </tr>
                        </table>
                        <br>
                        <!-- Data element: Horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td>
                                    <hr width="100%" color="#c8dbed" size="2">
                                </td>
                            </tr>
                        </table>
                        <!-- Data element: Grid -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tbody>
                                <tr height="5">
                                    <td width="900"">
                                    </td>
                                </tr>
                                <tr>
                                    <td>   
                                        <asp:UpdatePanel id="upnlJlinerSheet" runat="server">
                                            <contenttemplate>                                                                
                                        <asp:GridView ID="grdPointRepairs" runat="server" SkinID="GridViewInTabs" Width="890px"
                                            PageSize="3" ShowFooter="True" AutoGenerateColumns="False" AllowPaging="True"
                                            DataKeyNames="ID, RefID, COMPANY_ID" OnDataBound="grdPointRepairs_DataBound" OnRowCommand="grdPointRepairs_RowCommand"
                                            OnRowDeleting="grdPointRepairs_RowDeleting" OnRowUpdating="grdPointRepairs_RowUpdating" OnRowDataBound="grdPointRepairs_RowDataBound"
                                            DataSourceID="odsPointRepairs">
                                            <Columns>
                                                <asp:TemplateField SortExpression="ID" Visible="False" HeaderText="ID">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                
                                                
                                                <asp:TemplateField SortExpression="COMPANY_ID" Visible="False" HeaderText="COMPANY_ID">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCOMPANY_ID" runat="server" Text='<%# Eval("COMPANY_ID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCOMPANY_ID" runat="server" Text='<%# Eval("COMPANY_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                                                                                                                                                                              
                                                
                                                <asp:TemplateField  HeaderText="Point Repair and Grout Details">
                                                    <EditItemTemplate>
                                                        <!-- Page element : 2 columns - Point Repair and Grout Details Information -->
                                                        <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 10px; height: 10px">
                                                                    </td>
                                                                    <td style="width: 33px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 116px">
                                                                    </td>
                                                                    <td style="width: 116px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td style="vertical-align: middle; text-align: center" rowspan="9">
                                                                        <asp:Label ID="lblDetailIDEdit" runat="server" SkinID="LabelPageTitle1" EnableViewState="False" Text='<%# Eval("DetailID") %>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLinerDistanceEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Liner Distance"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDirectionEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Direction"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReinstatesEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Reinstates"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLtMhEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="LT @ MH"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblVtMhEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="VT @ MH"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblInstallDateEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Install Date"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDistanceEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Distance"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLinerDistanceEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                            Style="width: 103px" Text='<%# Eval("LinerDistance") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDirectionEdit" runat="server" DataSourceID="odsLFSDirections"
                                                                            DataTextField="Direction" DataValueField="Direction"
                                                                            SkinID="DropDownListLookup" Style="width: 103px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxReinstatesEdit" runat="server" EnableViewState="False"
                                                                            SkinID="TextBox" Style="width: 103px" Text='<%# Eval("Reinstates") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLtMhEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                         Style="width: 103px" Text='<%# Eval("LTAtMH") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        &nbsp;<asp:TextBox ID="tbxVtMhEdit" runat="server" EnableViewState="False"
                                                                            SkinID="TextBox" Style="width: 103px" Text='<%# Eval("VTAtMH") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="tkrdpInstallDateEdit" runat="server" Width="103px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDistanceEdit" runat="server" EnableViewState="False"
                                                                            SkinID="TextBox" Style="width: 106px" Text='<%# Eval("Distance") %>'></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                        <asp:CompareValidator ID="cvReinstatesEdit" runat="server" ControlToValidate="tbxReinstatesEdit"
                                                                            Display="Dynamic" ErrorMessage="Invalid format. (use XXXX)" Operator="DataTypeCheck"
                                                                            SkinID="Validator" Type="Integer" ValidationGroup="editData"></asp:CompareValidator></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSizeEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Size"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblMhShootEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="MH Shot?"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblExtraRepairEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Extra Repair"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCancelledEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Cancelled"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblApprovedEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Approved"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNotApprovedEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Not Approved"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: middle; text-align: center">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxSizeEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                            Style="width: 103px" Text='<%# Eval("RepairSize") %>' ></asp:TextBox></td>
                                                                    <td>                                                                    
                                                                        <asp:DropDownList ID="ddlMhShotEdit" runat="server" DataSourceID="odsLFSMHShots"
                                                                            DataTextField="MHShot" DataValueField="MHShot"
                                                                            SkinID="DropDownListLookup" Style="width: 103px">
                                                                        </asp:DropDownList> 
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxExptraRepairEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("ExtraRepair") %>'/></td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxCancelledEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("Cancelled") %>'/></td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxApprovedEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("Approved") %>'/></td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxNotApprovedEdit" runat="server" SkinID="CheckBox" Checked='<%# Eval("NotApproved") %>'/></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCommentsEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Comments"></asp:Label></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="tbxCommentEdit" runat="server" Rows="4" SkinID="TextBox" Style="width: 787px"
                                                                            Text='<%# Eval("Comments") %>' TextMode="MultiLine"></asp:TextBox></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>                                                                
                                                        <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 10px; height: 10px">
                                                                    </td>
                                                                    <td style="width: 33px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 116px">
                                                                    </td>
                                                                    <td style="width: 116px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td rowspan="9">
                                                                        </td>
                                                                    <td>
                                                                        <asp:Label ID="lblLinerDistanceFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Liner Distance"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDirectionFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Direction"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblReinstatesFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Reinstates"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLtMhFooter" runat="server" EnableViewState="False"
                                                                            SkinID="Label" Text="LT @ MH"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblVtMhFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="VT @ MH"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblInstallDateFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Install Date"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDistanceFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Distance"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLinerDistanceFooter" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                            Style="width: 103px" ></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDirectionFooter" runat="server" DataSourceID="odsLFSDirections"
                                                                            DataTextField="Direction" DataValueField="Direction"
                                                                            SkinID="DropDownListLookup" Style="width: 103px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxReinstatesFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 103px" ></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLtMhFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 103px" ></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxVtMhFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 103px" ></asp:TextBox></td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="tkrdpInstallDateFooter" runat="server" Width="106px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                    <td colspan="1">
                                                                        <asp:TextBox ID="tbxDistanceFooter" runat="server" EnableViewState="False"
                                                                            SkinID="TextBox" Style="width: 106px" ></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                        <asp:CompareValidator ID="cvReinstatesFooter" runat="server" ControlToValidate="tbxReinstatesFooter"
                                                                            Display="Dynamic" ErrorMessage="Invalid format. (use XXXX)" Operator="DataTypeCheck"
                                                                            SkinID="Validator" Type="Integer" ValidationGroup="repairsFooter"></asp:CompareValidator></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSizeFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Size"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblMhShootFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="MH Shot?"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblExtraRepairFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Extra Repair"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCancelledFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Cancelled"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblApprovedFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Approved"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNotApprovedFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Not Approved"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxSizeFooter" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                            Style="width: 103px" ></asp:TextBox></td>
                                                                    <td>                                                                        
                                                                        <asp:DropDownList ID="ddlMhShotFooter" runat="server" DataSourceID="odsLFSMHShots"
                                                                            DataTextField="MHShot" DataValueField="MHShot"
                                                                            SkinID="DropDownListLookup" Style="width: 103px">
                                                                        </asp:DropDownList>                                                                            
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxExptraRepairFooter" runat="server" SkinID="CheckBox" /></td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxCancelledFooter" runat="server" SkinID="CheckBox" /></td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxApprovedFooter" runat="server" SkinID="CheckBox" /></td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxNotApprovedFooter" runat="server" SkinID="CheckBox" /></td>
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
                                                                    <td colspan="3">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCommentsFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Comments"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="3">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="tbxCommentFooter" runat="server" Rows="1" SkinID="TextBox" Style="width: 787px"></asp:TextBox></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="840px"></HeaderStyle>
                                                    <ItemTemplate>                                                    
                                                        <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 10px; height: 10px">
                                                                    </td>
                                                                    <td style="width: 33px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 113px">
                                                                    </td>
                                                                    <td style="width: 116px">
                                                                    </td>
                                                                    <td style="width: 116px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td style="vertical-align: middle; text-align: center" rowspan="8">
                                                                        <asp:Label ID="lblDetailID" runat="server" SkinID="LabelPageTitle1" EnableViewState="False" Text='<%# Eval("DetailID") %>'></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLinerDistance" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Liner Distance"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDirection" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Direction"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblReinstates" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Reinstates"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblLtMh" runat="server" EnableViewState="False" SkinID="Label" Text="LT @ MH"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblVtMh" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="VT @ MH"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblInstallDate" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Install Date"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDistance" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Distance"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td >
                                                                    </td>
                                                                    <td colspan="1" >
                                                                        <asp:TextBox ID="tbxLinerDistance" Style="width: 103px"  runat="server" SkinID="TextBoxReadOnly"
                                                                            Text='<%# Eval("LinerDistance") %>' EnableViewState="False" ReadOnly="True"></asp:TextBox></td>
                                                                    <td colspan="1" >
                                                                        <asp:TextBox ID="tbxDirection" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 103px" Text='<%# Eval("Direction") %>'></asp:TextBox></td>
                                                                    <td colspan="1" >
                                                                        <asp:TextBox ID="tbxReinstates" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 103px" Text='<%# Eval("Reinstates") %>'></asp:TextBox></td>
                                                                    <td colspan="1" >
                                                                        <asp:TextBox ID="tbxDistanceToCentre" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 103px" Text='<%# Eval("LTAtMH") %>'></asp:TextBox></td>
                                                                    <td colspan="1">
                                                                        <asp:TextBox ID="tbxVtMh" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 103px" Text='<%# Eval("VTAtMH") %>'></asp:TextBox></td>
                                                                    <td colspan="1" >
                                                                        <asp:TextBox ID="tbxInstallDate" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 106px" Text='<%# Eval("InstallDate", "{0:d}") %>'></asp:TextBox></td>
                                                                    <td colspan="1" >
                                                                        <asp:TextBox ID="tbxDistance" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 106px" Text='<%# Eval("Distance") %>'></asp:TextBox></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSize" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Size"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblMhShoot" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="MH Shot?"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblExtraRepair" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Extra Repair"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCancelled" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Cancelled"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblApproved" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Approved"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNotApproved" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Not Approved"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxSize" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 103px" Text='<%# Eval("RepairSize") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxMhShot" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 103px" Text='<%# Eval("MHShot") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxExtraRepair" runat="server" onclick="return cbxClick();"
                                                                            SkinID="CheckBox" Checked='<%# Eval("ExtraRepair") %>' /></td>
                                                                    <td><asp:CheckBox ID="ckbxCancelled" runat="server" onclick="return cbxClick();"
                                                                            SkinID="CheckBox" Checked='<%# Eval("Cancelled") %>' /></td>
                                                                    <td>
                                                                    <asp:CheckBox ID="ckbxApproved" runat="server" onclick="return cbxClick();"
                                                                            SkinID="CheckBox" Checked='<%# Eval("Approved") %>'/></td>
                                                                    <td>
                                                                    <asp:CheckBox ID="ckbxNotApproved" runat="server" onclick="return cbxClick();"
                                                                            SkinID="CheckBox" Checked='<%# Eval("NotApproved") %>'/></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments"
                                                                            EnableViewState="False"></asp:Label></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox Style="width: 787px" ID="tbxComment" runat="server" SkinID="TextBoxReadOnly"
                                                                            Text='<%# Eval("Comments") %>' Rows="4" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update"
                                                                            ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png"></asp:ImageButton>
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"
                                                                            ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png"></asp:ImageButton>
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
                                                                            ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"></asp:ImageButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </FooterTemplate>
                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                                            ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"></asp:ImageButton>
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                            OnClientClick='return confirm("Are you sure you want to delete this Point Repair and Grout Details?");'
                                                                            ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"></asp:ImageButton>
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
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMaxNumber" runat="server" SkinID="LabelError" Text="The maximum laterals amount was reached, no more laterals can be added."></asp:Label>
                                    </td>                                    
                                </tr>                                
                            </tbody>
                        </table>
                        
       
                       
                        
                       
                        <br>
                        <br>
                        <!-- Page element: Footer buttons -->
                        <table height="28" cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td valign="middle" width="700" background="./../common/images/im_footer1.gif" height="28">
                                    <table cellspacing="0" cellpadding="0" width="700" border="0">
                                        <tr>
                                            <td width="10">
                                            </td>
                                            <td align="center" width="50">
                                                <asp:Button ID="btnPrevious" TabIndex="100" runat="server" CssClass="tButtonPrevNext"
                                                    Height="22px" Width="50px" EnableViewState="False" Text="Prev" Font-Bold="True"
                                                    OnClick="btnPrevious_Click"></asp:Button></td>
                                            <td width="5">
                                            </td>
                                            <td align="center" width="50">
                                                <asp:Button ID="btnNext" TabIndex="100" runat="server" CssClass="tButtonPrevNext"
                                                    Height="22px" Width="50px" EnableViewState="False" Text="Next" OnClick="btnNext_Click">
                                                </asp:Button></td>
                                            <td width="25">
                                            </td>
                                            <td align="center" width="90">
                                                <asp:Button ID="btnDelete" TabIndex="100" runat="server" CssClass="tButtonDelete"
                                                    CausesValidation="False" Height="22px" Width="90px" Text="Delete" OnClick="btnDelete_Click">
                                                </asp:Button></td>
                                            <td width="25">
                                            </td>
                                            <td width="445">
                                                <asp:ValidationSummary ID="vsFooter" runat="server" Width="445px" EnableViewState="False"
                                                    Font-Size="Smaller" BackColor="#C8DBED" HeaderText="VALIDATION ISSUES.  Please review the form.">
                                                </asp:ValidationSummary>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_footer2.gif" height="28">
                                    <asp:Button ID="btnOK" TabIndex="45" runat="server" CssClass="tButtonOkCancel" Height="22px"
                                        Width="90px" EnableViewState="False" Text="OK" OnClick="btnOK_Click"></asp:Button></td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_footer3.gif" height="28">
                                    <asp:Button ID="btnCancel" TabIndex="46" runat="server" CssClass="tButtonOkCancel"
                                        CausesValidation="False" Height="22px" Width="90px" Text="Cancel" OnClick="btnCancel_Click">
                                    </asp:Button></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 187px" colspan="2">
                                </td>
                            </tr>
                        </table>
                        <br/>
                        <br/>
                    </div>
                    
                <!-- ENDPAGE --><td>&nbsp;</td>
                 </td>
            </tr> 
         </table>               
        
        <!-- Page element: Data objects --><table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsLFSDirections" runat="server" SelectMethod="GetLFSDirectionsForDropDownList"
                        TypeName="LiquiForce.LFSLive.CWP.DatabaseGateway.LFSDirectionsGateway">
                        <SelectParameters>
                            <asp:Parameter Name="directionItem" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsLFSMHShots" runat="server" SelectMethod="GetLFSMHShotsForDropDownList"
                        TypeName="LiquiForce.LFSLive.CWP.DatabaseGateway.LFSMHShotsGateway">
                        <SelectParameters>
                            <asp:Parameter Name="mhShotItem" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsPointRepairs" runat="server" 
                     SelectMethod="GetPointRepairsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.view_scopesheet" 
                     DeleteMethod="DummyPointRepairsNew" FilterExpression="(Deleted = 0)AND (Archived = 0)" 
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
