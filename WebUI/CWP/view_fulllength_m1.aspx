<%@ Page language="c#" Codebehind="view_fulllength_m1.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.view_fulllength_m1" %>
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
					<TD vAlign="top" width="900">
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
												<TD align="right" width="85" height="23"><asp:linkbutton id="lkbtnSignOut" tabIndex="100" runat="server" CausesValidation="False" CssClass="tMainLink" onclick="lkbtnSignOut_Click">Sign out</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD align="right" width="85" height="23"><asp:linkbutton id="lkbtnMenu" tabIndex="100" runat="server" CausesValidation="False" CssClass="tMainLinkOrange" onclick="lkbtnMenu_Click">Menu</asp:linkbutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE> <!-- Page element: Header buttons -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD width="700" background="./../common/images/im_header4.gif" height="28">&nbsp;</TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header5.gif" height="28"><asp:button id="btnOK1" tabIndex="82" runat="server" CssClass="tButtonOkCancel" Text="OK" EnableViewState="False"
											Width="90px" Height="22px" onclick="btnOK_Click"></asp:button></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header6.gif" height="28"><asp:button id="btnCancel1" tabIndex="83" runat="server" CausesValidation="False" CssClass="tButtonOkCancel"
											Text="Cancel" Width="90px" Height="22px" onclick="btnCancel_Click"></asp:button></TD>
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
									<td height="5"></td>
								</tr>
								<TR>
									<TD>
										<TABLE height="35" cellSpacing="0" cellPadding="0" width="900" border="0">
											<TR height="35">
												<TD vAlign="middle" align="center" width="130" background="./../common/images/Im_OptionOFF.gif"
													height="35"><asp:linkbutton id="lkbtnSectionDetails" tabIndex="1" runat="server" CssClass="tOptionOFF" onclick="lkbtnSectionDetails_Click">Section Details</asp:linkbutton></TD>
												<TD class="tOptionON" vAlign="middle" align="center" width="130" background="./../common/images/Im_OptionOn.gif"
													height="35">M1 Information
												</TD>
												<TD vAlign="middle" align="center" width="130" background="./../common/images/Im_OptionOff.gif"
													height="35"><asp:linkbutton id="lkbtnM2" tabIndex="2" runat="server" CssClass="tOptionOFF" onclick="lkbtnM2_Click">M2 Measurements</asp:linkbutton></TD>
												<TD background="./../common/images/im_backbutton.gif">&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR height="5">
									<TD width="17%" height="5"></TD>
									<TD width="17%" height="5"></TD>
									<TD style="WIDTH: 155px" width="155" height="5"></TD>
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
									<TD style="WIDTH: 155px" width="155"></TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >M1 
											Date</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Line 
											With ID#</DIV>
									</TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxRecordID tabIndex=3 runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>' Width="100px" ReadOnly="True">
										</asp:textbox>
										<asp:TextBox id=tbxID tabIndex=200 runat="server" Width="0px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>' ReadOnly="True">
										</asp:TextBox></TD>
									<TD style="WIDTH: 308px" width="308" colSpan="2"><asp:textbox id="tbxCOMPANIES_ID" tabIndex="4" runat="server" CssClass="tTextField" Width="255px"
											ReadOnly="True"></asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxM1Date tabIndex=5 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].M1Date", "{0:d}") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%" colspan="2"><asp:textbox id="tbxLineWithID" tabIndex="6" runat="server" CssClass="tTextField" Width="250px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LineWithID") %>'></asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"></TD>
									<TD style="WIDTH: 308px" width="308" colSpan="2"></TD>
									<TD width="16%"><asp:customvalidator id="cvM1Date" runat="server" EnableViewState="False" Font-Size="Smaller" ErrorMessage="Invalid date"
											ControlToValidate="tbxM1Date" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="3">
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="17%" height="3">&nbsp;</TD>
									<TD style="WIDTH: 155px" width="155" height="3">&nbsp;</TD>
									<TD width="16%" height="3">&nbsp;</TD>
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="16%" height="3">&nbsp;</TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Sub 
											Area</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD style="WIDTH: 155px" width="155"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2"><asp:textbox id=tbxSubArea tabIndex=7 runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SubArea") %>' Width="261px">
										</asp:textbox></TD>
									<TD style="WIDTH: 155px" width="155"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Street</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD style="WIDTH: 155px" width="155">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >USMH</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >USMH 
											MN#</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >USMH 
											Depth</DIV>
									</TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2"><asp:textbox id=tbxStreet tabIndex=8 runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Street") %>' Width="261px">
										</asp:textbox></TD>
									<TD style="WIDTH: 155px" width="155"><asp:textbox id=tbxUSMH tabIndex=9 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMH") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxUSMHMN tabIndex=10 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHMN") %>' Width="140px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxUSMHDepth tabIndex=11 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHDepth") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%">
										<asp:checkbox id=cbxDropPipe tabIndex=15 runat="server" CssClass="tLabel" Width="96px" Text="Drop Pipe" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DropPipe") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR height="16">
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD style="WIDTH: 155px" width="155">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >DSMH</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >DSMH 
											MN#</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 10px" >DSMH 
											Depth</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 136px; HEIGHT: 10px" >Drop 
											Pipe Invert Depth</DIV>
									</TD>
								</TR>
								<TR>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD style="WIDTH: 155px" width="155"><asp:textbox id=tbxDSMH tabIndex=12 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMH") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxDSMHMN tabIndex=13 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHMN") %>' Width="140px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxDSMHDepth tabIndex=14 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHDepth") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%">
										<asp:textbox id=tbxDropPipeInvertDepth tabIndex=16 runat="server" CssClass="tTextField" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DropPipeInvertDepth") %>'>
										</asp:textbox></TD>
								</TR>
								<tr height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 3px" >Confirmed 
											Size</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 112px; HEIGHT: 10px" >Pipe 
											Material Type</DIV>
									</TD>
									<TD style="WIDTH: 155px" width="155">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 155px; HEIGHT: 10px" >Steel 
											Tape Through Sewer</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 144px; HEIGHT: 2px" >Measurements 
											Taken By</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</tr>
								<tr>
									<TD width="17%"><asp:textbox id=tbxConfirmedSize tabIndex=17 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ConfirmedSize") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxPipeMaterialType tabIndex=18 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].PipeMaterialType") %>' Width="100px">
										</asp:textbox></TD>
									<TD style="WIDTH: 155px" width="155"><asp:textbox id=tbxSteelTapeThruPipe tabIndex=19 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SteelTapeThruPipe") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxMeasurementsTakenBy tabIndex=20 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].MeasurementsTakenBy") %>' Width="140px">
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</tr>
								<tr>
									<TD width="17%"><asp:regularexpressionvalidator id="revConfirmedSize" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxConfirmedSize" Display="Dynamic" ValidationExpression="\d*"></asp:regularexpressionvalidator></TD>
									<TD width="17%"></TD>
									<TD style="WIDTH: 155px" width="17%">
										<asp:customvalidator id="cvSteelTapeThruPipe" runat="server" Width="100px" Display="Dynamic" ControlToValidate="tbxSteelTapeThruPipe"
											Font-Size="Smaller" ValidateEmptyText="True"></asp:customvalidator></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</tr>
							</TABLE>
							<BR>
							<BR> <!-- Page element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<HR width="100%" color="#c8dbed" SIZE="2">
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR vAlign="top">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 144px; HEIGHT: 8px" >USMH 
											PIPE DIAMETER</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="3">
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
								</TR>
								<TR height="16">
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 9px" >Mouth 
											12:00</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 9px" >Mouth 
											1:00</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 9px" >Mouth 
											2:00</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Mouth 
											3:00</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 9px" >Mouth 
											4:00</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 8px" >Mouth 
											5:00</DIV>
									</TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxUSMHAtMouth1200 tabIndex=21 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHAtMouth1200") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxUSMHAtMouth100 tabIndex=22 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHAtMouth100") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxUSMHAtMouth200 tabIndex=23 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHAtMouth200") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxUSMHAtMouth300 tabIndex=24 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHAtMouth300") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxUSMHAtMouth400 tabIndex=25 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHAtMouth400") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxUSMHAtMouth500 tabIndex=26 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHAtMouth500") %>' Width="100px">
										</asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"><asp:regularexpressionvalidator id="revUSMHAtMouth1200" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxUSMHAtMouth1200" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revUSMHAtMouth100" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxUSMHAtMouth100" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revUSMHAtMouth200" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxUSMHAtMouth200" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="16%"><asp:regularexpressionvalidator id="revUSMHAtMouth300" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxUSMHAtMouth300" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revUSMHAtMouth400" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxUSMHAtMouth400" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="16%"><asp:regularexpressionvalidator id="revUSMHAtMouth500" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxUSMHAtMouth500" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
								</TR>
							</TABLE>
							<BR>
							<BR> <!-- Page element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<HR width="100%" color="#c8dbed" SIZE="2">
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR vAlign="top">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 144px; HEIGHT: 8px" >DSMH 
											PIPE DIAMETER</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="3">
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Mouth 
											12:00</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Mouth 
											1:00</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 9px" >Mouth 
											2:00</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Mouth 
											3:00</DIV>
									</TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Mouth 
											4:00</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 1px" >Mouth 
											5:00</DIV>
									</TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxDSMHAtMouth1200 tabIndex=27 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHAtMouth1200") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxDSMHAtMouth100 tabIndex=28 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHAtMouth100") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxDSMHAtMouth200 tabIndex=29 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHAtMouth200") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxDSMHAtMouth300 tabIndex=30 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHAtMouth300") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxDSMHAtMouth400 tabIndex=31 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHAtMouth400") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxDSMHAtMouth500 tabIndex=32 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHAtMouth500") %>' Width="100px">
										</asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"><asp:regularexpressionvalidator id="revDSMHAtMouth1200" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxDSMHAtMouth1200" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revDSMHAtMouth100" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxDSMHAtMouth100" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revDSMHAtMouth200" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxDSMHAtMouth200" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="16%"><asp:regularexpressionvalidator id="revDSMHAtMouth300" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxDSMHAtMouth300" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revDSMHAtMouth400" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxDSMHAtMouth400" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
									<TD width="16%"><asp:regularexpressionvalidator id="revDSMHAtMouth500" runat="server" EnableViewState="False" Font-Size="Smaller"
											ErrorMessage="Invalid data" ControlToValidate="tbxDSMHAtMouth500" Display="Dynamic" ValidationExpression="\d*(\.\d+)?"></asp:regularexpressionvalidator></TD>
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
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 16px" >Hydrant 
											Address</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 150px; HEIGHT: 16px" >Distance 
											To Inversion MH</DIV>
									</TD>
									<TD width="16%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 16px" >Traffic 
											Control</DIV>
									</TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="4"><asp:textbox id=tbxHydrantAddress tabIndex=33 runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].HydrantAddress") %>' Width="560px">
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxDistanceToInversionMH tabIndex=34 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DistanceToInversionMH") %>' Width="100px">
										</asp:textbox></TD>
									<TD width="17%"><asp:dropdownlist id="ddlDegreeOfTrafficControl" tabIndex="35" runat="server" CssClass="tTextField"
											Width="130px"></asp:dropdownlist></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="16">
									<TD width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 108px; HEIGHT: 8px" >Hydro 
											Wire Details</DIV>
									</TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
								<TR>
									<TD width="17%" colSpan="4"><asp:textbox id=tbxHydroWireDetails tabIndex=36 runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].HydroWireDetails") %>' Width="560px">
										</asp:textbox></TD>
									<TD width="17%"><asp:checkbox id=cbxRampsRequired tabIndex=37 runat="server" CssClass="tLabel" Text="Ramps Required?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RampsRequired") %>'>
										</asp:checkbox></TD>
									<TD width="16%"><asp:checkbox id=cbxPipeSizeChange tabIndex=38 runat="server" CssClass="tLabel" Text="Pipe Size Change?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].PipeSizeChange") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR height="3">
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
								</TR>
								<TR height="16">
									<TD style="HEIGHT: 6px" width="17%" colSpan="3"><asp:checkbox id=cbxStandarBypass tabIndex=39 runat="server" CssClass="tLabel" Text="Standard Bypass? (If yes, explain in comments below)" Width="400px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].StandarBypass") %>'>
										</asp:checkbox></TD>
									<TD style="HEIGHT: 6px" width="16%" colSpan="2"><asp:checkbox id=cbxRoboticPrepRequired tabIndex=40 runat="server" CssClass="tLabel" Text="Robotic Prep Required?" Width="158px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RoboticPrepRequired") %>'>
										</asp:checkbox></TD>
									<TD style="HEIGHT: 6px" width="16%"></TD>
								</TR>
								<TR height="3">
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
									<TD width="17%" height="3"></TD>
									<TD width="16%" height="3"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%">
										<asp:checkbox id=cbxSchoolZone tabIndex=41 runat="server" CssClass="tLabel" Text="School Zone" Width="96px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SchoolZone") %>'>
										</asp:checkbox></TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%">
										<asp:checkbox id=cbxRestaurantArea tabIndex=42 runat="server" CssClass="tLabel" Text="Restaurant Area?" Width="120px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RestaurantArea") %>'>
										</asp:checkbox></TD>
									<TD width="17%"></TD>
									<TD width="16%">
										<asp:checkbox id=cbxCarwashLaundromat tabIndex=43 runat="server" CssClass="tLabel" Text="Carwash/Laundromat?" Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].CarwashLaundromat") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%">&nbsp;</TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
							</TABLE> <!-- Page element: Custom -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD height="16">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 88px; HEIGHT: 8px" >M1 
											Comments</DIV>
									</TD>
								</TR>
								<TR>
									<TD><asp:textbox id=tbxM1Comments tabIndex=44 runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].M1Comments") %>' Width="855px" Height="85px" TextMode="MultiLine">
										</asp:textbox></TD>
								</TR>
							</TABLE>
							<BR>
							<!-- Page element: Custom -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD height="16">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 160px; HEIGHT: 8px" >Traffic 
											Control Details</DIV>
									</TD>
								</TR>
								<TR>
									<TD><asp:textbox id=tbxTrafficControlDetails tabIndex=45 runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].TrafficControlDetails") %>' Width="855px" Height="85px" TextMode="MultiLine">
										</asp:textbox></TD>
								</TR>
							</TABLE>
							<BR>
							<BR> <!-- Page element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD>
										<HR width="100%" color="#c8dbed" SIZE="2">
									</TD>
								</TR>
							</TABLE> <!-- Page element: 6Columns -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR height="16">
									<TD width="17%" colSpan="2">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 232px; HEIGHT: 8px" >EXTRA 
											EQUIPMENT NEEDED</DIV>
									</TD>
									<TD width="17%" colSpan="2"></TD>
									<TD width="17%" colSpan="2"></TD>
								</TR>
								<TR height="16">
									<TD width="17%" colSpan="2"></TD>
									<TD width="17%" colSpan="2"></TD>
									<TD width="17%" colSpan="2"></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxHydroPulley tabIndex=46 runat="server" CssClass="tLabel" Text="Hydro Pulley?" Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].HydroPulley") %>'>
										</asp:checkbox></TD>
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxFridgeCart tabIndex=47 runat="server" CssClass="tLabel" Text="Fridge Cart?" Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].FridgeCart") %>'>
										</asp:checkbox></TD>
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxTwoInchPump tabIndex=48 runat="server" CssClass="tLabel" Text='2" Pump?' Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].TwoInchPump") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR height="16">
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxSixInchBypass tabIndex=49 runat="server" CssClass="tLabel" Text='6" Bypass?' Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SixInchBypass") %>'>
										</asp:checkbox></TD>
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxScaffolding tabIndex=50 runat="server" CssClass="tLabel" Text="Scaffolding?" Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Scaffolding") %>'>
										</asp:checkbox></TD>
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxWinchExtension tabIndex=51 runat="server" CssClass="tLabel" Text="Winch Extension?" Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].WinchExtension") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR height="16">
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxExtraGenerator tabIndex=52 runat="server" CssClass="tLabel" Text="Extra Generator?" Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ExtraGenerator") %>'>
										</asp:checkbox></TD>
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxGreyCableExtension tabIndex=53 runat="server" CssClass="tLabel" Text="Grey Cable Extension?" Width="184px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].GreyCableExtension") %>'>
										</asp:checkbox></TD>
									<TD width="17%" colSpan="2">
										<asp:checkbox id=cbxEasementMats tabIndex=54 runat="server" CssClass="tLabel" Text="Easement Mats?" Width="144px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].EasementMats") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%" colSpan="2">&nbsp;</TD>
									<TD width="17%" colSpan="2"></TD>
									<TD width="17%" colSpan="2"></TD>
								</TR>
							</TABLE>
							<BR>
							<BR> <!-- Page element: Footer buttons -->
							<table height="28" cellSpacing="0" cellPadding="0" width="900" border="0">
								<tr>
									<td vAlign="middle" width="700" background="./../common/images/im_footer1.gif" height="28"><asp:validationsummary id="vsFooter" runat="server" Width="670px" EnableViewState="False" Font-Size="Smaller"
											BackColor="#C8DBED" HeaderText="VALIDATION ISSUES.  Please review the form."></asp:validationsummary></td>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer2.gif" height="28"><asp:button id="btnOK" tabIndex="80" runat="server" CssClass="tButtonOkCancel" Height="22px"
											Width="90px" EnableViewState="False" Text="OK" onclick="btnOK_Click"></asp:button></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer3.gif" height="28"><asp:button id="btnCancel" tabIndex="81" runat="server" CssClass="tButtonOkCancel" CausesValidation="False"
											Height="22px" Width="90px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
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
