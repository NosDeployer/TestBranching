<%@ Page language="c#" Codebehind="view_pointliner.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.view_pointliner" %>

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
					<td>&nbsp;
					    <!-- .. Script Manager -->
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
					</td> 
					<!-- PAGE -->
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
							<BR> <!-- Page element: Title with horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<DIV class="tTitle" style="WIDTH: 496px; POSITION: relative; HEIGHT: 19px" >Point 
											Liner / Other Sections Only</DIV>
									</TD>
								</TR>
								<TR>
									<TD>
										<TABLE height="5" cellSpacing="0" cellPadding="0" width="900" border="0">
											<TR>
												<TD><IMG height="5" src="./../common/images/im_backrowblue.gif" width="900"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
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
									<TD width="17%"><asp:textbox id=tbxRecordID tabIndex=1 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>' ReadOnly="True" CssClass="tTextField">
										</asp:textbox></TD>
									<TD width="17%" colSpan="2"><asp:textbox id="tbxCOMPANIES_ID" tabIndex="2" runat="server" Width="255px" ReadOnly="True" CssClass="tTextField"></asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxClientID tabIndex=3 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ClientID") %>' CssClass="tTextField">
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%">
										<asp:TextBox id=tbxID tabIndex=200 runat="server" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>' Width="0px" ReadOnly="True">
										</asp:TextBox></TD>
									<TD width="17%" colSpan="2"></TD>
									<TD width="16%"></TD>
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
									<TD width="17%"><asp:checkbox id=cbxPointLining tabIndex=8 runat="server" Width="112px" Text="Point Lining?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].PointLining") %>' Height="16px" CssClass="tLabel"></asp:checkbox></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2"><asp:textbox id=tbxSubArea tabIndex=4 runat="server" Width="261px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SubArea") %>' CssClass="tTextField">
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"><asp:checkbox id=cbxLateralLining tabIndex=9 runat="server" Width="112px" Text="Lateral Lining?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LateralLining") %>' CssClass="tLabel"></asp:checkbox></TD>
									<TD width="16%"><asp:checkbox id=cbxOutOfScopeInArea tabIndex=12 runat="server" Text="Out Of Scope / In Area" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].OutOfScopeInArea") %>' Height="16px" CssClass="tLabel" Width="152px"></asp:checkbox></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Street</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >USMH</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >DSMH</DIV>
									</TD>
									<TD width="17%"><asp:checkbox id=cbxJLiner tabIndex=10 runat="server" Text="J-Liner?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].JLiner") %>' Height="16px" CssClass="tLabel"></asp:checkbox></TD>
									<TD width="16%"><asp:checkbox id=cbxRehabAssessment tabIndex=13 runat="server" Text="Rehab Assessment?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RehabAssessment") %>' Height="16px" CssClass="tLabel"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2"><asp:textbox id=tbxStreet tabIndex=5 runat="server" Width="261px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Street") %>' CssClass="tTextField">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxUSMH tabIndex=6 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMH") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxDSMH tabIndex=7 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMH") %>' CssClass="tTextFieldCenter">
										</asp:textbox></TD>
									<TD width="17%"><asp:checkbox id=cbxGrouting tabIndex=11 runat="server" Text="Grouting?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Grouting") %>' Height="16px" CssClass="tLabel"></asp:checkbox></TD>
									<TD width="16%"><asp:checkbox id=cbxFullLengthPointLiner tabIndex=14 runat="server" Width="155px" Text="Full Length Point Liner?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].FullLengthPointLiner") %>' Height="16px" CssClass="tLabel"></asp:checkbox></TD>
								</TR>
							</TABLE>
							<BR>
							<BR> <!-- Data element: Horizontal rule -->
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
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 9px" >Map 
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
									<TD width="17%"><asp:textbox id=tbxSize_ tabIndex=15 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Size_") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxConfirmedSize tabIndex=16 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ConfirmedSize") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revConfirmedSize" runat="server" Font-Size="Smaller" EnableViewState="False"
											Display="Dynamic" ControlToValidate="tbxConfirmedSize" ErrorMessage="Invalid data" ValidationExpression="\d*"></asp:regularexpressionvalidator></TD>
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
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 7px" >Actual 
											Length</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 6px" >Live 
											Lats</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 108px; HEIGHT: 14px" >Estimated 
											# Joints</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 8px" >CXI's 
											Removed</DIV>
									</TD>
									<TD style="HEIGHT: 1px" width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 134px; HEIGHT: 7px" ># 
											Joints Test / Sealed</DIV>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxScaledLength tabIndex=17 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ScaledLength") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxActualLength tabIndex=18 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ActualLength") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxLiveLats tabIndex=19 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LiveLats") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="16%"><asp:textbox id=tbxEstimatedJoints tabIndex=20 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].EstimatedJoints") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="17%"><asp:textbox id=tbxCXIsRemoved tabIndex=21 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].CXIsRemoved") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 22px" width="16%"><asp:textbox id=tbxJointsTestSealed tabIndex=22 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].JointsTestSealed") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%">
										<asp:customvalidator id="cvScaledLength" runat="server" Width="80px" ErrorMessage="Invalid data" ControlToValidate="tbxScaledLength"
											Display="Dynamic" Font-Size="Smaller"></asp:customvalidator></TD>
									<TD width="17%">
										<asp:customvalidator id="cvActualLength" runat="server" Width="100px" ControlToValidate="tbxActualLength"
											Display="Dynamic" Font-Size="Smaller" ValidateEmptyText="True"></asp:customvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revLiveLats" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
											ControlToValidate="tbxLiveLats" ErrorMessage="Invalid data" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="16%"><asp:regularexpressionvalidator id="revEstimatedJoints" runat="server" Font-Size="Smaller" EnableViewState="False"
											Display="Dynamic" ControlToValidate="tbxEstimatedJoints" ErrorMessage="Invalid data" ValidationExpression="\d*"></asp:regularexpressionvalidator></TD>
									<TD width="17%"></TD>
									<TD width="16%"><asp:regularexpressionvalidator id="revJointsTestSealed" runat="server" Font-Size="Smaller" EnableViewState="False"
											Display="Dynamic" ControlToValidate="tbxJointsTestSealed" ErrorMessage="Invalid data" ValidationExpression="\d*"></asp:regularexpressionvalidator></TD>
								</TR>
							</TABLE>
							<BR>
							<BR> <!-- Data element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<HR width="100%" color="#c8dbed" SIZE="2">
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR height="16">
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Pre-Flush 
											Date</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Pre-Video 
											Date</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 132px; HEIGHT: 8px" >Proposed 
											Lining Date</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Deadline 
											Date</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Final 
											Video</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxPreFlushDate tabIndex=23 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].PreFlushDate", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxPreVideoDate tabIndex=24 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].PreVideoDate", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxProposedLiningDate tabIndex=25 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ProposedLiningDate", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxDeadlineDate tabIndex=26 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DeadlineDate", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxFinalVideo tabIndex=27 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].FinalVideo", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"><asp:customvalidator id="cvPreFlushDate" runat="server" Font-Size="Smaller" Width="72px" EnableViewState="False"
											Display="Dynamic" ControlToValidate="tbxPreFlushDate" ErrorMessage="Invalid date"></asp:customvalidator></TD>
									<TD width="17%"><asp:customvalidator id="cvPreVideoDate" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
											ControlToValidate="tbxPreVideoDate" ErrorMessage="Invalid data"></asp:customvalidator></TD>
									<TD width="17%"><asp:customvalidator id="cvProposedLiningDate" runat="server" Font-Size="Smaller" EnableViewState="False"
											Display="Dynamic" ControlToValidate="tbxProposedLiningDate" ErrorMessage="Invalid date"></asp:customvalidator></TD>
									<TD width="16%"><asp:customvalidator id="cvDeadlineDate" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
											ControlToValidate="tbxDeadlineDate" ErrorMessage="Invalid date"></asp:customvalidator></TD>
									<TD width="17%"><asp:customvalidator id="cvFinalVideo" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
											ControlToValidate="tbxFinalVideo" ErrorMessage="Invalid date"></asp:customvalidator></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >Pusher 
											Date</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Grout 
											Date</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Liner 
											Ordered?</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Vac-Ex 
											Date?</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Restoration?</DIV>
									</TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 17px" width="17%"><asp:textbox id=tbxPusherDate tabIndex=28 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].PusherDate", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 17px" width="17%"><asp:textbox id=tbxGroutDate tabIndex=29 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].GroutDate", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 17px" width="17%"><asp:textbox id=tbxLinerOrdered tabIndex=30 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LinerOrdered", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 17px" width="16%"><asp:textbox id=tbxVacExDate tabIndex=31 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].VacExDate") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 17px" width="17%"><asp:textbox id=tbxRestoration tabIndex=32 runat="server" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Restoration", "{0:d}") %>' CssClass="tTextFieldCenter"></asp:textbox></TD>
									<TD style="HEIGHT: 17px" width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"><asp:customvalidator id="cvPusherDate" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
											ControlToValidate="tbxPusherDate" ErrorMessage="Invalid date"></asp:customvalidator></TD>
									<TD width="17%">
										<P><asp:customvalidator id="cvGroutDate" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
												ControlToValidate="tbxGroutDate" ErrorMessage="Invalid data"></asp:customvalidator></P>
									</TD>
									<TD width="17%"><asp:customvalidator id="cvLinerOrdered" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
											ControlToValidate="tbxLinerOrdered" ErrorMessage="Invalid data"></asp:customvalidator></TD>
									<TD width="16%">
										<P>
											<asp:CustomValidator id="cvVacExDate" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
												ControlToValidate="tbxVacExDate" ErrorMessage="Invalid data"></asp:CustomValidator></P>
									</TD>
									<TD width="17%">
										<P><asp:customvalidator id="cvRestoration" runat="server" Font-Size="Smaller" EnableViewState="False" Display="Dynamic"
												ControlToValidate="tbxRestoration" ErrorMessage="Invalid data"></asp:customvalidator></P>
									</TD>
									<TD width="16%"></TD>
								</TR>
							</TABLE>
							<BR>
							<BR> <!-- Data element: Horizontal rule -->
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
												<td width="30%" colspan="2"><asp:checkbox id=cbxIssueIdentified tabIndex=34 runat="server" Width="120px" Text="Issue Identified?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueIdentified") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%">&nbsp;</td>
												<td width="70%">&nbsp;</td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxLFSIssue tabIndex=35 runat="server" Width="150px" Text="LFS Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LFSIssue") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxClientIssue tabIndex=36 runat="server" Width="150px" Text="Client Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ClientIssue") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%">
													<asp:checkbox id=cbxSalesIssue tabIndex=37 runat="server" Width="150px" Text="Sales Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SalesIssue") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%">
													<asp:checkbox id=cbxInvestigationIssue tabIndex=38 runat="server" Width="136px" Text="Investigation Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].InvestigationIssue") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxIssueGivenToBayCity tabIndex=39 runat="server" Width="168px" Text="Issue Given To Client?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueGivenToBayCity") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"><asp:checkbox id=cbxIssueResolved tabIndex=40 runat="server" Width="136px" Text="Issue Resolved?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueResolved") %>' CssClass="tLabel">
													</asp:checkbox></td>
											</tr>
										</table>
									</td>
									<td width="66%" valign="top">
										<table width="100%" cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td width="580">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 216px; HEIGHT: 19px" >Point 
														Repair / Grout / Lateral Details</DIV>
												</td>
												<td>&nbsp;</td>
											</tr>
											<tr>
												<td></td>
												<td></td>
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
                                                                                        <td style="text-align: center">
                                                                                            <asp:Label ID="lblDetailIdEdit" runat="server" SkinID="Label" Text='<%# Eval("DetailID") %>'></asp:Label>    
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
                                                                                    <td style="text-align: center"> 
                                                                                        <asp:Label ID="lblDetailIdFooter" runat="server" SkinID="Label" Text='<%# Eval("DetailID") %>'></asp:Label>                                                                               
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </FooterTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="text-align: center">
                                                                                            <asp:Label ID="lblDetailIdItem" runat="server" SkinID="Label" Text='<%# Eval("DetailID") %>'></asp:Label>        
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
                                                <td>&nbsp;</td>
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
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD height="16">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 88px; HEIGHT: 6px" >Comments</DIV>
									</TD>
								</TR>
								<TR>
									<TD><asp:textbox id=tbxComments tabIndex=44 runat="server" Width="891px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Comments") %>' TextMode="MultiLine" Height="85px" CssClass="tTextField">
										</asp:textbox>
									</TD>
								</TR>
							</TABLE>
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
							<BR>
							<br>
						</DIV>
					</TD> <!-- ENDPAGE -->
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
            
            <!-- Page element: Data objects -->
            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:ObjectDataSource ID="odsPointRepairs" runat="server" 
                         SelectMethod="GetPointRepairsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.view_pointliner" 
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
</HTML>
