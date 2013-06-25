<%@ Page language="c#" Codebehind="view_fulllength.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.view_fulllength" SmartNavigation="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LFS Combined Work Program</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="./../common/images/lfcss.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>&nbsp;</TD> <!-- PAGE -->
					<TD vAlign="top" width="800">
						<DIV><!-- Page element: Header -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD width="700" background="./../common/images/im_header1.gif" height="50">&nbsp;</TD>
									<TD width="100" background="./../common/images/im_header2.gif" height="50"></TD>
									<TD width="100" background="./../common/images/im_header3.gif" height="50">
										<TABLE height="50" cellSpacing="0" cellPadding="0" width="100" border="0">
											<TR>
												<TD width="85" height="4"></TD>
												<TD width="15" rowSpan="3"></TD>
											</TR>
											<TR>
												<TD align="right" width="85" height="23"><asp:linkbutton id="lkbtnSignOut" tabIndex="100" runat="server" CssClass="tMainLink" CausesValidation="False" onclick="lkbtnSignOut_Click">Sign out</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD align="right" width="85" height="23"><asp:linkbutton id="lkbtnMenu" runat="server" CssClass="tMainLinkOrange" CausesValidation="False"
														tabIndex="100" onclick="lkbtnMenu_Click">Menu</asp:linkbutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE> <!-- Page element: Header buttons -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD width="700" background="./../common/images/im_header4.gif" height="28">&nbsp;</TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header5.gif" height="28"><asp:button id="btnOK1" tabIndex="47" runat="server" CssClass="tButtonOkCancel" Height="22px"
											Width="90px" EnableViewState="False" Text="OK" onclick="btnOK_Click"></asp:button></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header6.gif" height="28"><asp:button id="btnCancel1" runat="server" CssClass="tButtonOkCancel" Height="22px" Width="90px"
											Text="Cancel" CausesValidation="False" tabIndex="48" onclick="btnCancel_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<BR> <!-- Page element: Title with tabs and hr -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<DIV class="tTitle" style="WIDTH: 496px; POSITION: relative; HEIGHT: 19px" >Full 
											Length Sections Only</DIV>
									</TD>
								</TR>
								<tr height="5">
									<td height="5">
									</td>
								</tr>
								<tr>
									<td>
										<table width="900" height="35" border="0" cellpadding="0" cellspacing="0">
											<tr height="35">
												<td width="130" height="35" background="./../common/images/Im_OptionON.gif" class="tOptionON" align="center"
													valign="middle">Section Details
												</td>
												<td width="130" height="35" align="center" valign="middle" background="./../common/images/Im_OptionOff.gif">
													<asp:linkbutton id="lkbtnM1" runat="server" CssClass="tOptionOFF" tabIndex="1" onclick="lkbtnM1_Click">M1 Information</asp:linkbutton>
												</td>
												<td width="130" height="35" align="center" valign="middle" background="./../common/images/Im_OptionOff.gif">
													<asp:linkbutton id="lkbtnM2" runat="server" CssClass="tOptionOFF" tabIndex="2" onclick="lkbtnM2_Click">M2 Measurements</asp:linkbutton>
												</td>
												<td background="./../common/images/im_backbutton.gif">&nbsp;</td>
											</tr>
										</table>
									</td>
								</tr>
							</TABLE>
							<!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR height="5">
									<TD width="17%" height="5"></TD>
									<TD width="17%" height="5"></TD>
									<TD width="17%" height="5"></TD>
									<TD width="17%" height="5"></TD>
									<TD width="17%" height="5"></TD>
									<TD width="16%" height="5"></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >ID#</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Client</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Client 
											ID#</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxRecordID tabIndex=3 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>' ReadOnly="True" CssClass="tTextField">
										</asp:textbox>
										<asp:TextBox id=tbxID tabIndex=200 runat="server" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>' Width="0px" ReadOnly="True">
										</asp:TextBox></TD>
									<TD width="17%" colSpan="2"><asp:textbox id="tbxCOMPANIES_ID" tabIndex="4" runat="server" Width="255px" ReadOnly="True" CssClass="tTextField"></asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxClientID tabIndex=5 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ClientID") %>' CssClass="tTextField">
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="3">
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="16%" height="3">&nbsp;</TD>
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="16%" height="3">&nbsp;</TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Sub 
											Area</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="17%">
									</TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2">
										<asp:textbox id=tbxSubArea tabIndex=6 runat="server" Width="261px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SubArea") %>' CssClass="tTextField">
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"><asp:checkbox id=cbxFullLengthLining tabIndex=10 runat="server" Text="Full Length Lining?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].FullLengthLining") %>' Height="16px" CssClass="tLabel">
										</asp:checkbox></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 9px" >Street</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >USMH</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >DSMH</DIV>
									</TD>
									<TD width="17%"><asp:checkbox id=cbxSubcontractorLining tabIndex=11 runat="server" Width="148px" Text="Subcontractor Lining?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SubcontractorLining") %>' Height="16px" CssClass="tLabel">
										</asp:checkbox></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2"><asp:textbox id=tbxStreet tabIndex=7 runat="server" Width="261px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Street") %>' CssClass="tTextField">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxUSMH tabIndex=8 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMH") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxDSMH tabIndex=9 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMH") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"><asp:checkbox id=cbxOutOfScopeInArea tabIndex=12 runat="server" Text="Out Of Scope / In Area" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].OutOfScopeInArea") %>' Height="16px" CssClass="tLabel" Width="155px">
										</asp:checkbox></TD>
									<TD width="16%"></TD>
								</TR>
							</TABLE>
							<BR>
							<BR>
							<!-- Data element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<HR width="100%" color="#c8dbed" SIZE="2">
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Map 
											Size</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 3px" >Confirmed 
											Size</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxSize_ tabIndex=13 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Size_") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxConfirmedSize tabIndex=14 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ConfirmedSize") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revConfirmedSize" runat="server" Font-Size="Smaller" EnableViewState="False"
											ValidationExpression="\d*" ErrorMessage="Invalid data" ControlToValidate="tbxConfirmedSize" Display="Dynamic"></asp:regularexpressionvalidator></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="16">
									<TD style="HEIGHT: 1px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 7px" >Scaled 
											Length</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 8px" >Actual 
											Length</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 8px" >Live 
											Lats</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >CXI's 
											Removed</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="17%">
										<asp:Label id="lblInstallRate" runat="server" CssClass="tLabel">Install Rate</asp:Label>
									</TD>
									<TD style="HEIGHT: 1px" width="16%"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxScaledLength tabIndex=15 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ScaledLength") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxActualLength tabIndex=16 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ActualLength") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxLiveLats tabIndex=17 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LiveLats") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="16%"><asp:textbox id=tbxCXIsRemoved tabIndex=18 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].CXIsRemoved") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxInstallRate tabIndex=19 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].InstallRate", "{0:N}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%">
										<asp:customvalidator id="cvScaledLength" runat="server" Width="80px" Display="Dynamic" ControlToValidate="tbxScaledLength"
											ErrorMessage="Invalid data" Font-Size="Smaller"></asp:customvalidator></TD>
									<TD width="17%">
										<asp:customvalidator id="cvActualLength" runat="server" Width="100px" Display="Dynamic" ControlToValidate="tbxActualLength"
											Font-Size="Smaller" ValidateEmptyText="True"></asp:customvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revLiveLats" runat="server" Font-Size="Smaller" EnableViewState="False" ValidationExpression="\d*(\.\d+)?"
											ErrorMessage="Invalid data" ControlToValidate="tbxLiveLats" Display="Dynamic"></asp:regularexpressionvalidator></TD>
									<TD width="16%"></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revInstallRate" runat="server" Font-Size="Smaller" Width="66px" EnableViewState="False"
											ValidationExpression="\d*(\.\d+)?" ErrorMessage="Invalid data" ControlToValidate="tbxInstallRate" Display="Dynamic"></asp:regularexpressionvalidator></TD>
									<TD width="16%"></TD>
								</TR>
							</TABLE>
							<BR>
							<BR>
							<!-- Data element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<HR width="100%" color="#c8dbed" SIZE="2">
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR height="16">
									<TD style="HEIGHT: 1px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 132px; HEIGHT: 8px" >Proposed 
											Lining Date</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >Deadline 
											Date</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="17%">
									</TD>
									<TD style="HEIGHT: 1px" width="16%"></TD>
									<TD style="HEIGHT: 1px" width="17%"></TD>
									<TD style="HEIGHT: 1px" width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxProposedLiningDate tabIndex=20 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ProposedLiningDate", "{0:d}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxDeadlineDate tabIndex=21 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DeadlineDate", "{0:d}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"><asp:customvalidator id="cvProposedLiningDate" runat="server" Font-Size="Smaller" EnableViewState="False"
											ErrorMessage="Invalid date" ControlToValidate="tbxProposedLiningDate" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="17%"><asp:customvalidator id="cvDeadlineDate" runat="server" Font-Size="Smaller" EnableViewState="False" ErrorMessage="Invalid date"
											ControlToValidate="tbxDeadlineDate" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >P1 
											Date</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >M1 
											Date</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 8px" >M2 
											Date</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Install 
											Date</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >Final 
											Video</DIV>
									</TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxP1Date tabIndex=22 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].P1Date", "{0:d}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxM1Date tabIndex=23 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].M1Date", "{0:d}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxM2Date tabIndex=24 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].M2Date", "{0:d}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxInstallDate tabIndex=25 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].InstallDate", "{0:d}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxFinalVideo tabIndex=26 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].FinalVideo", "{0:d}") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"><asp:customvalidator id="cvP1Date" runat="server" Font-Size="Smaller" EnableViewState="False" ErrorMessage="Invalid date"
											ControlToValidate="tbxP1Date" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="17%"><asp:customvalidator id="cvM1Date" runat="server" Font-Size="Smaller" EnableViewState="False" ErrorMessage="Invalid date"
											ControlToValidate="tbxM1Date" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="17%"><asp:customvalidator id="cvM2Date" runat="server" Font-Size="Smaller" Width="66px" EnableViewState="False"
											ErrorMessage="Invalid date" ControlToValidate="tbxM2Date" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="16%"><asp:customvalidator id="cvInstallDate" runat="server" Font-Size="Smaller" Width="72px" EnableViewState="False"
											ErrorMessage="Invalid date" ControlToValidate="tbxInstallDate" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="17%"><asp:customvalidator id="cvFinalVideo" runat="server" Font-Size="Smaller" EnableViewState="False" ErrorMessage="Invalid date"
											ControlToValidate="tbxFinalVideo" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="16%"></TD>
								</TR>
							</TABLE>
							<BR>
							<BR>
							<!-- Data element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<HR width="100%" color="#c8dbed" SIZE="2">
									</TD>
								</TR>
							</TABLE>
							<!-- Page element: Custom -->
							<table width="900" cellpadding="0" cellspacing="0" border="0">
								<tr>
									<td width="34%" valign="top">
										<table width="100%" cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td width="30%" colspan="2"><asp:checkbox id=cbxIssueIdentified tabIndex=27 runat="server" Width="120px" Text="Issue Identified?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueIdentified") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%">&nbsp;</td>
												<td width="70%">&nbsp;</td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxLFSIssue tabIndex=28 runat="server" Width="120px" Text="LFS Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LFSIssue") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxClientIssue tabIndex=29 runat="server" Width="112px" Text="Client Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ClientIssue") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxSalesIssue tabIndex=30 runat="server" Width="112px" Text="Sales Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SalesIssue") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxIssueGivenToBayCity tabIndex=31 runat="server" Width="160px" Text="Issue Given To Client?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueGivenToBayCity") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxIssueResolved tabIndex=32 runat="server" Width="128px" Text="Issue Resolved?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueResolved") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
										</table>
									</td>
									<td width="66%" valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD height="16">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 88px; HEIGHT: 6px" >Comments</DIV>
												</TD>
											</TR>
											<TR>
												<TD>
													<asp:textbox id=tbxComments tabIndex=33 runat="server" Width="585px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Comments") %>' Height="125px" TextMode="MultiLine" CssClass="tTextField">
													</asp:textbox>
												</TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</table>
							<br>
							<br>
							<!-- Page element: Footer buttons -->
							<table height="28" cellSpacing="0" cellPadding="0" width="900" border="0">
								<tr>
									<td vAlign="middle" width="700" background="./../common/images/im_footer1.gif" height="28">
										<table width="700" cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td width="10"></td>
												<td width="50" align="center">
													<asp:button id="btnPrevious" tabIndex="100" runat="server" CssClass="tButtonPrevNext" Text="Prev"
														EnableViewState="False" Width="50px" Height="22px" Font-Bold="True" onclick="btnPrevious_Click"></asp:button></td>
												<td width="5"></td>
												<td width="50" align="center">
													<asp:button id="btnNext" tabIndex="100" runat="server" CssClass="tButtonPrevNext" Text="Next"
														EnableViewState="False" Width="50px" Height="22px" onclick="btnNext_Click"></asp:button></td>
												<td width="25"></td>
												<td width="90" align="center">
													<asp:Button id="btnDelete" tabIndex="100" runat="server" Height="22px" Width="90px" Text="Delete"
														CssClass="tButtonDelete" CausesValidation="False" onclick="btnDelete_Click"></asp:Button>
												</td>
												<td width="25"></td>
												<td width="445">
													<asp:validationsummary id="vsFooter" runat="server" Width="445px" EnableViewState="False" Font-Size="Smaller"
														HeaderText="VALIDATION ISSUES.  Please review the form." BackColor="#C8DBED"></asp:validationsummary>
												</td>
											</tr>
										</table>
									</td>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer2.gif" height="28"><asp:button id="btnOK" tabIndex="45" runat="server" CssClass="tButtonOkCancel" Height="22px"
											Width="90px" EnableViewState="False" Text="OK" onclick="btnOK_Click"></asp:button></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer3.gif" height="28"><asp:button id="btnCancel" runat="server" CssClass="tButtonOkCancel" Height="22px" Width="90px"
											Text="Cancel" CausesValidation="False" tabIndex="46" onclick="btnCancel_Click"></asp:button></TD>
								</tr>
								<TR>
									<TD></TD>
									<TD style="WIDTH: 187px" colSpan="2"></TD>
								</TR>
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
			                <BR>
							<BR>
						</DIV>
					</TD> <!-- ENDPAGE -->
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			
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
</HTML>
