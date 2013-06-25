<%@ Page Language="c#" Codebehind="view_fulllength_m2.aspx.cs" AutoEventWireup="True"
    Inherits="LiquiForce.LFSLive.WebUI.CWP.view_fulllength_m2" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>LFS Combined Work Program</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="./../common/images/lfcss.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form method="post" runat="server">
    <!-- .. Scrip Manager -->
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
                                                <asp:LinkButton ID="lkbtnSignOut" TabIndex="100" runat="server" CausesValidation="False"
                                                    CssClass="tMainLink" OnClick="lkbtnSignOut_Click">Sign out</asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="85" height="23">
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
                                <td width="700" background="./../common/images/im_header4.gif" height="28">
                                    &nbsp;</td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_header5.gif"
                                    height="28">
                                    <asp:Button ID="btnOK1" TabIndex="47" runat="server" CssClass="tButtonOkCancel" Text="OK"
                                        EnableViewState="False" Width="90px" Height="22px" OnClick="btnOK_Click"></asp:Button></td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_header6.gif"
                                    height="28">
                                    <asp:Button ID="btnCancel1" TabIndex="48" runat="server" CausesValidation="False"
                                        CssClass="tButtonOkCancel" Text="Cancel" Width="90px" Height="22px" OnClick="btnCancel_Click">
                                    </asp:Button></td>
                            </tr>
                        </table>
                        <br>
                        <!-- Page element: Title with tabs and hr -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td>
                                    <div class="tTitle" style="width: 496px; position: relative; height: 19px">
                                        Full Length Sections Only</div>
                                </td>
                            </tr>
                            <tr height="5">
                                <td height="5">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table height="35" cellspacing="0" cellpadding="0" width="900" border="0">
                                        <tr height="35">
                                            <td valign="middle" align="center" width="130" background="./../common/images/Im_OptionOFF.gif"
                                                height="35">
                                                <asp:LinkButton ID="lkbtnSectionDetails" TabIndex="1" runat="server" CssClass="tOptionOFF"
                                                    OnClick="lkbtnSectionDetails_Click">Section Details</asp:LinkButton></td>
                                            <td valign="middle" align="center" width="130" background="./../common/images/Im_OptionOff.gif"
                                                height="35">
                                                <asp:LinkButton ID="lkbtnM1" TabIndex="2" runat="server" CssClass="tOptionOFF" OnClick="lkbtnM1_Click">M1 Information</asp:LinkButton></td>
                                            <td class="tOptionON" valign="middle" align="center" width="130" background="./../common/images/Im_OptionOn.gif"
                                                height="35">
                                                M2 Measurements
                                            </td>
                                            <td background="./../common/images/im_backbutton.gif">
                                                &nbsp;</td>
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
                                <td width="17%" height="5">
                                </td>
                                <td width="17%" height="5">
                                </td>
                                <td width="16%" height="5">
                                </td>
                            </tr>
                            <tr height="16">
                                <td width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 10px">
                                        ID#</div>
                                </td>
                                <td width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 10px">
                                        Client</div>
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 10px">
                                        M2 Date</div>
                                </td>
                                <td width="17%">
                                    <div class="tLabel" style="display: inline; width: 144px; height: 10px">
                                        Measurement Type</div>
                                </td>
                                <td width="16%">
                                    <div class="tLabel" style="display: inline; width: 140px; height: 10px">
                                        Measured From Manhole</div>
                                </td>
                            </tr>
                            <tr>
                                <td width="17%">
                                    <asp:TextBox ID="tbxRecordID" TabIndex="3" runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>'
                                        Width="100px" ReadOnly="True">
                                    </asp:TextBox>
                                    <asp:TextBox ID="tbxID" TabIndex="200" runat="server" Width="0px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>'
                                        ReadOnly="True">
                                    </asp:TextBox></td>
                                <td width="17%" colspan="2">
                                    <asp:TextBox ID="tbxCOMPANIES_ID" TabIndex="4" runat="server" CssClass="tTextField"
                                        Width="255px" ReadOnly="True"></asp:TextBox></td>
                                <td width="17%">
                                    <asp:TextBox ID="tbxM2Date" TabIndex="5" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].M2Date", "{0:d}") %>'
                                        Width="100px">
                                    </asp:TextBox></td>
                                <td width="17%">
                                    <asp:DropDownList ID="ddlMeasurementType" TabIndex="6" runat="server" CssClass="tTextField"
                                        Width="112px">
                                    </asp:DropDownList></td>
                                <td width="16%">
                                    <asp:TextBox ID="tbxMeasuredFromManhole" TabIndex="8" runat="server" CssClass="tTextFieldCenter"
                                        Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].MeasuredFromManhole") %>'>
                                    </asp:TextBox></td>
                            </tr>
                            <tr valign="top">
                                <td width="17%">
                                </td>
                                <td width="17%" colspan="2">
                                </td>
                                <td width="16%">
                                    <asp:CustomValidator ID="cvM2Date" runat="server" EnableViewState="False" Width="66px"
                                        Font-Size="Smaller" Display="Dynamic" ControlToValidate="tbxM2Date" ErrorMessage="Invalid date"></asp:CustomValidator></td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                            </tr>
                            <tr height="3">
                                <td width="17%" height="3">
                                    &nbsp;</td>
                                <td width="17%" height="3">
                                    &nbsp;</td>
                                <td width="17%" height="3">
                                    &nbsp;</td>
                                <td width="16%" height="3">
                                    &nbsp;</td>
                                <td width="17%" height="3">
                                    &nbsp;</td>
                                <td width="16%" height="3">
                                    &nbsp;</td>
                            </tr>
                            <tr height="16">
                                <td width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        Street</div>
                                </td>
                                <td width="17%">
                                </td>
                                <td width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        USMH</div>
                                </td>
                                <td width="16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 10px">
                                        DSMH</div>
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                            </tr>
                            <tr>
                                <td width="17%" colspan="2">
                                    <asp:TextBox ID="tbxStreet" TabIndex="7" runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Street") %>'
                                        Width="267px">
                                    </asp:TextBox></td>
                                <td width="17%">
                                    <asp:TextBox ID="tbxUSMH" TabIndex="8" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMH") %>'
                                        Width="100px">
                                    </asp:TextBox></td>
                                <td width="16%">
                                    <asp:TextBox ID="tbxDSMH" TabIndex="9" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMH") %>'
                                        Width="100px">
                                    </asp:TextBox></td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
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
                                </td>
                            </tr>
                            <tr height="16">
                                <td style="height: 17px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 11px">
                                        Size</div>
                                </td>
                                <td style="height: 17px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        Video Done From</div>
                                </td>
                                <td style="height: 17px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 8px">
                                        To Manhole</div>
                                </td>
                                <td style="height: 17px" width="16%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 6px">
                                        # Of Live Lats</div>
                                </td>
                                <td style="height: 17px" width="17%">
                                    <div class="tLabel" style="display: inline; width: 100px; height: 2px">
                                        Capped Laterals</div>
                                </td>
                                <td style="height: 17px" width="16%">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 21px" width="17%">
                                    <asp:TextBox ID="tbxConfirmedSize" TabIndex="10" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ConfirmedSize") %>'
                                        Width="100px">
                                    </asp:TextBox></td>
                                <td style="height: 21px" width="17%">
                                    <asp:TextBox ID="tbxVideoDoneFrom" TabIndex="11" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].VideoDoneFrom") %>'
                                        Width="100px" ReadOnly="True">
                                    </asp:TextBox></td>
                                <td style="height: 21px" width="17%">
                                    <asp:TextBox ID="tbxToManhole" TabIndex="12" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ToManhole") %>'
                                        Width="100px" ReadOnly="True">
                                    </asp:TextBox></td>
                                <td style="height: 21px" width="16%">
                                    <asp:TextBox ID="tbxLiveLats" TabIndex="13" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LiveLats") %>'
                                        Width="100px">
                                    </asp:TextBox></td>
                                <td style="height: 21px" width="17%">
                                    <asp:TextBox ID="tbxCappedLaterals" TabIndex="14" runat="server" CssClass="tTextFieldCenter"
                                        Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].CappedLaterals") %>'
                                        Width="100px">
                                    </asp:TextBox></td>
                                <td style="height: 21px" width="16%">
                                </td>
                            </tr>
                            <tr valign="top">
                                <td width="17%">
                                    <asp:RegularExpressionValidator ID="revConfirmedSize" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" Display="Dynamic" ControlToValidate="tbxConfirmedSize" ErrorMessage="Invalid data"
                                        ValidationExpression="\d*"></asp:RegularExpressionValidator></td>
                                <td width="17%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                    <asp:RegularExpressionValidator ID="revLiveLats" runat="server" EnableViewState="False"
                                        Font-Size="Smaller" Display="Dynamic" ControlToValidate="tbxLiveLats" ErrorMessage="Invalid data"
                                        ValidationExpression="\d*(\.\d+)?"></asp:RegularExpressionValidator></td>
                                <td width="17%">
                                    <asp:RegularExpressionValidator ID="revCappedLaterals" runat="server" EnableViewState="False"
                                        Width="71px" Font-Size="Smaller" Display="Dynamic" ControlToValidate="tbxCappedLaterals"
                                        ErrorMessage="Invalid data" ValidationExpression="\d*"></asp:RegularExpressionValidator></td>
                                <td width="16%">
                                </td>
                            </tr>
                            <tr height="16">
                                <td width="17%" colspan="2">
                                    <div class="tLabel" style="display: inline; width: 96px; height: 16px">
                                        Video Distance</div>
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                            </tr>
                            <tr>
                                <td width="17%" colspan="4">
                                    <asp:TextBox ID="tbxCutterDescriptionDuringMeasuring" TabIndex="15" runat="server"
                                        CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].CutterDescriptionDuringMeasuring") %>'
                                        Width="100px" MaxLength="255">
                                    </asp:TextBox></td>
                                <td width="17%">
                                </td>
                                <td width="16%">
                                </td>
                            </tr>
                        </table>
                        <br>
                        <br>
                        <!-- Page element: Horizontal rule -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td>
                                    <hr width="100%" color="#c8dbed" size="2">
                                </td>
                            </tr>
                        </table>
                        <!-- Page element: Custom -->
                        <table cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr height="16">
                                <td width="900">
                                    <div class="tLabel" style="display: inline; width: 216px; height: 19px">
                                        Lateral Measurement Info
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel id="upnlGrdLfsM2" runat="server">
                                        <contenttemplate>
                                            <asp:GridView ID="grdLfsM2" runat="server" SkinID="GridViewInTabs" Width="890px"
                                                PageSize="5" ShowFooter="True" AutoGenerateColumns="False" AllowPaging="True"
                                                DataKeyNames="ID, RefID, COMPANY_ID" OnDataBound="grdLfsM2_DataBound" OnRowCommand="grdLfsM2_RowCommand"
                                                OnRowDeleting="grdLfsM2_RowDeleting" OnRowUpdating="grdLfsM2_RowUpdating" OnRowDataBound="grdLfsM2_RowDataBound"
                                                DataSourceID="odsLfsM2">
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
                                                    
                                                    <asp:TemplateField  HeaderText="Lateral Measurement Info">
                                                        <EditItemTemplate>
                                                            <!-- Page element : 2 columns - Notes Information -->
                                                            <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 10px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 106px">
                                                                        </td>
                                                                        <td style="width: 106px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblVideoDistanceEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Video Distance"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblClockPositionEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Clock Position"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLiveOrAbandonedEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                Text="Live Or Abandoned"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDistanceToCentreEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                Text="Distance to Centre"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLateralDiameterEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Lateral Diameter"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLateralTypeEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Lateral Type"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblTimeOpenedEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Time Opened"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblReverseSetupEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Reverse Setup"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxVideoDistanceEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                Style="width: 93px" Text='<%# Eval("VideoDistance") %>'></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxClockPositionEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                Style="width: 93px" Text='<%# Eval("ClockPosition") %>'></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxLiveOrAbandonedEdit" runat="server" EnableViewState="False"
                                                                                SkinID="TextBox" Style="width: 93px" Text='<%# Eval("LiveOrAbandoned") %>'></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxDistanceToCentreEdit" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 93px" Text='<%# Eval("DistanceToCentreOfLateral") %>'></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxLateralDiameterEdit" runat="server" EnableViewState="False"
                                                                                SkinID="TextBox" Style="width: 93px" Text='<%# Eval("LateralDiameter") %>'></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxLateralTypeEdit" runat="server" EnableViewState="False"
                                                                                SkinID="TextBox" Style="width: 93px" Text='<%# Eval("LateralType") %>'></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxTimeOpenedEdit" runat="server" EnableViewState="False"
                                                                                SkinID="TextBox" Style="width: 96px" Text='<%# Eval("DateTimeOpened") %>'></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxReverseSetupEdit" runat="server" EnableViewState="False" SkinID="TextBoxReadOnly"
                                                                                Style="width: 96px" Text='<%# Eval("ReverseSetup") %>' ReadOnly="True"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                            <asp:CustomValidator ID="cvVideoDistanceEdit" runat="server" ControlToValidate="tbxVideoDistanceEdit"
                                                                                Display="Dynamic" ErrorMessage="Invalid data.  No thousand comma separator allowed."
                                                                                OnServerValidate="cvDistance_ServerValidate" SkinID="Validator" ValidationGroup="dataEdit"></asp:CustomValidator></td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CustomValidator ID="cvDistanceToCentreEdit" runat="server" ControlToValidate="tbxDistanceToCentreEdit"
                                                                                Display="Dynamic" ErrorMessage="Invalid data.  No thousand "
                                                                                OnServerValidate="cvDistanceToCentre_ServerValidate" SkinID="Validator" ValidationGroup="dataEdit"></asp:CustomValidator></td>
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
                                                                            &nbsp;</td>
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
                                                                        <td colspan="8">
                                                                            <asp:TextBox ID="tbxCommentEdit" runat="server" Rows="4" SkinID="TextBox" Style="width: 820px"
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
                                                            <!-- Page element : 2 columns - Notes Information -->
                                                            <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 10px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 106px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblVideoDistanceFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Video Distance"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblClockPositionFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Clock Position"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLiveOrAbandonedFooter" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                Text="Live Or Abandoned"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDistanceToCentreFooter" runat="server" EnableViewState="False"
                                                                                SkinID="LabelSmall" Text="Distance To Centre"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLateralDiameterFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Lateral Diameter"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLateralTypeFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Lateral Type"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblTimeOpenedFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Time Opened"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblReverseSetupFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Reverse Setup"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxVideoDistanceFooter" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                Style="width: 93px" ></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxClockPositionFooter" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                Style="width: 93px" ></asp:TextBox></td>
                                                                        <td colspan="1">
                                                                            <asp:TextBox ID="tbxLiveOrAbandonedFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 93px" ></asp:TextBox></td>
                                                                        <td colspan="1">
                                                                            <asp:TextBox ID="tbxDistanceToCentreFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 93px" ></asp:TextBox></td>
                                                                        <td colspan="1">
                                                                            <asp:TextBox ID="tbxLateralDiameterFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 93px" ></asp:TextBox></td>
                                                                        <td colspan="1">
                                                                            <asp:TextBox ID="tbxLateralTypeFooter" runat="server" EnableViewState="False"
                                                                                SkinID="TextBox" Style="width: 93px" ></asp:TextBox></td>
                                                                        <td colspan="1">
                                                                            <asp:TextBox ID="tbxTimeOpenedFooter" runat="server" EnableViewState="False"
                                                                                SkinID="TextBox" Style="width: 96px" ></asp:TextBox></td>
                                                                        <td colspan="1">
                                                                            <asp:TextBox ID="tbxReverseSetupFooter" runat="server" EnableViewState="False" SkinID="TextBoxReadOnly"
                                                                                Style="width: 96px" ReadOnly="True" ></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                            <asp:CustomValidator ID="cvVideoDistanceFooter" runat="server" ControlToValidate="tbxVideoDistanceFooter"
                                                                                Display="Dynamic" ErrorMessage="Invalid data.  No thousand comma separator allowed."
                                                                                OnServerValidate="cvDistance_ServerValidate" SkinID="Validator" ValidationGroup="dataFooter"></asp:CustomValidator></td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CustomValidator ID="cvDistanceToCentreFooter" runat="server" ControlToValidate="tbxDistanceToCentreFooter"
                                                                                Display="Dynamic" ErrorMessage="Invalid data.  No thousand "
                                                                                OnServerValidate="cvDistanceToCentre_ServerValidate" SkinID="Validator" ValidationGroup="dataFooter"></asp:CustomValidator></td>
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
                                                                        <td>
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
                                                                        <td colspan="8">
                                                                            <asp:TextBox ID="tbxCommentFooter" runat="server" Rows="1" SkinID="TextBox" Style="width: 820px"></asp:TextBox></td>
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
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 103px">
                                                                        </td>
                                                                        <td style="width: 106px">
                                                                        </td>
                                                                        <td style="width: 106px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblVideoDistance" runat="server" SkinID="Label" Text="Video Distance" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblClockPosition" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Clock Position"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLiveOrAbandoned" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                Text="Live Or Abandoned"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblDistanceToCentre" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Distance to Centre"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLateralDiameter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Lateral Diameter"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblLateralType" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Lateral Type"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblTimeOpened" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Time Opened"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblReverseSetup" runat="server" EnableViewState="False" SkinID="Label"
                                                                                Text="Reverse Setup"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                        </td>
                                                                        <td >
                                                                            <asp:TextBox ID="tbxVideoDistance" Style="width: 93px"  runat="server" SkinID="TextBoxReadOnly"
                                                                                Text='<%# Eval("VideoDistance") %>' EnableViewState="False" ReadOnly="True"></asp:TextBox></td>
                                                                        <td colspan="1" >
                                                                            <asp:TextBox ID="tbxClockPosition" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 93px" Text='<%# Eval("ClockPosition") %>'></asp:TextBox></td>
                                                                        <td colspan="1" >
                                                                            <asp:TextBox ID="tbxLiveOrAbandoned" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 93px" Text='<%# Eval("LiveOrAbandoned") %>'></asp:TextBox></td>
                                                                        <td colspan="1" >
                                                                            <asp:TextBox ID="tbxDistanceToCentre" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 93px" Text='<%# Eval("DistanceToCentreOfLateral") %>'></asp:TextBox></td>
                                                                        <td colspan="1" >
                                                                            <asp:TextBox ID="tbxLateralDiameter" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 93px" Text='<%# Eval("LateralDiameter") %>'></asp:TextBox></td>
                                                                        <td colspan="1">
                                                                            <asp:TextBox ID="tbxLateralType" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 93px" Text='<%# Eval("LateralType") %>'></asp:TextBox></td>
                                                                        <td colspan="1" >
                                                                            <asp:TextBox ID="tbxTimeOpened" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 96px" Text='<%# Eval("DateTimeOpened") %>'></asp:TextBox></td>
                                                                        <td colspan="1" >
                                                                            <asp:TextBox ID="tbxReverseSetup" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 96px" Text='<%# Eval("ReverseSetup") %>'></asp:TextBox></td>
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="8">
                                                                            <asp:TextBox Style="width: 820px" ID="tbxComment" runat="server" SkinID="TextBoxReadOnly"
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
                                                                                OnClientClick='return confirm("Are you sure you want to delete this Lateral Measurement Info?");'
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
                        </table>
                        <br />
                        <br />
                        
                        <!-- Page element: Footer buttons -->
                        <table height="28" cellspacing="0" cellpadding="0" width="900" border="0">
                            <tr>
                                <td valign="middle" width="700" background="./../common/images/im_footer1.gif" height="28">
                                    <asp:ValidationSummary ID="vsFooter" runat="server" EnableViewState="False" Width="670px"
                                        Font-Size="Smaller" BackColor="#C8DBED" HeaderText="VALIDATION ISSUES.  Please review the form.">
                                    </asp:ValidationSummary>
                                </td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_footer2.gif"
                                    height="28">
                                    <asp:Button ID="btnOK" TabIndex="45" runat="server" CssClass="tButtonOkCancel" Text="OK"
                                        EnableViewState="False" Width="90px" Height="22px" OnClick="btnOK_Click"></asp:Button></td>
                                <td valign="middle" align="left" width="100" background="./../common/images/im_footer3.gif"
                                    height="28">
                                    <asp:Button ID="btnCancel" TabIndex="46" runat="server" CausesValidation="False"
                                        CssClass="tButtonOkCancel" Text="Cancel" Width="90px" Height="22px" OnClick="btnCancel_Click">
                                    </asp:Button></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 187px" colspan="2">
                                </td>
                            </tr>
                        </table>
                        
                        <!-- Page element: Data objects -->
                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="odsLfsM2" runat="server" 
                                     SelectMethod="GetLfsM2New" TypeName="LiquiForce.LFSLive.WebUI.CWP.view_fulllength_m2" 
                                     DeleteMethod="DummyLfsM2New" FilterExpression="(Deleted = 0) AND (Archived = 0)" 
                                     UpdateMethod="DummyLfsM2New">
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
            
                        <!-- Page element:  IFrame-->
                        <table>
                            <tr>
                                <td style="height: 7px">
                                    <iframe id="iframe" frameborder="0" height="0" width="0" src="./../refresh_iframe.aspx">
                                        Your web browser don't accept iFrame tag. Contact with your Administrator. </iframe>
                                </td>
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
        
        <!-- Page element:  refresh iFrame-->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <iframe id="iframe1" frameborder="0" height="0" width="0" src="./../refresh_iframe.aspx">
                        Your web browser don't accept iFrame tag. Contact with your Administrator. </iframe>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfId" runat="server" />                        
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
