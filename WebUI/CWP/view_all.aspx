<%@ Page language="c#" Codebehind="view_all.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.view_all" %>

<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 Transitional//EN" >
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
			<table id="table1" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td>&nbsp;
					    <!-- .. Script Manager -->
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
					</td>
					<!-- PAGE -->
					<td valign="top" style="width:800px">
						<div>
						    <!-- Page element: Header -->
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td style="width:700px; height:50px" background="./../common/images/im_header1.gif" >&nbsp;</td>
									<td style="width:100px; height:50px" background="./../common/images/im_header2.gif" ></td>
									<td style="width:100px; height:50px" background="./../common/images/im_header3.gif" >
										<table style="height:50px" cellspacing="0" cellpadding="0" width="100" border="0">
											<tr>
												<td style="width:85px; height:4px"></td>
												<td style="width:15px" rowspan="3"></td>
											</tr>
											<tr>
												<td align="right" style="width:85px; height:23px">
												    <asp:linkbutton id="lkbtnSignOut" tabIndex="100" runat="server" CausesValidation="False" CssClass="tMainLink" onclick="lkbtnSignOut_Click">Sign out</asp:linkbutton>
												</td>
											</tr>
											<tr>
												<td align="right" style="width:85px; height:23px">
												    <asp:linkbutton id="lkbtnMenu" tabIndex="100" runat="server" CausesValidation="False" CssClass="tMainLinkOrange" onclick="lkbtnMenu_Click">Menu</asp:linkbutton>
												</td>
											</tr>
										</table>
									</td>
								</tr>								
							</table>
							
							<!-- Page element: Header buttons -->
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td style="width:700px; height:28px" background="./../common/images/im_header4.gif">&nbsp;
									</td>
									<td valign="middle" align="left" style="width:100px; height:28px" background="./../common/images/im_header5.gif" ><asp:button id="btnOK1" tabIndex="52" runat="server" CssClass="tButtonOkCancel" Text="OK" EnableViewState="False"
											width="90px" height="22px" onclick="btnOK_Click"></asp:button>
								    </td>
									<td valign="middle" align="left" style="width:100px; height:28px" background="./../common/images/im_header6.gif" ><asp:button id="btnCancel1" tabIndex="53" runat="server" CausesValidation="False" CssClass="tButtonOkCancel"
											Text="Cancel" width="90px" height="22px" onclick="btnCancel_Click"></asp:button></td>
								</tr>
							</table>
							<br/> 
							
							<!-- Page element: Title with horizontal rule -->
							<table cellspacing="0" cellpadding="0" width="100%" border="0">
								<tr>
									<td>
										<div class="tTitle" style="width: 496px; POSITION: relative; height: 19px" >All 
											Records In All Projects</div>
									</td>
								</tr>
								<tr>
									<td>
										<table style="height:5px; width:900px" cellspacing="0" cellpadding="0" border="0">
											<tr>
												<td>
												    <img height="5" src="./../common/images/im_backrowblue.gif" width="900" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							
							<!-- Page element: 6Columns -->
							<table cellspacing="0" cellpadding="0" style="width:900px" border="0">
								<tr style="height:5px">
									<td style="width:17%; height:5px"></td>
									<td style="width:17%; height:5px"></td>
									<td style="width:17%; height:5px"></td>
									<td style="width:17%; height:5px"></td>
									<td style="width:17%; height:5px"></td>
									<td style="width:16%; height:5px"></td>
								</tr>
								<tr style="height:16px">
									<td style="width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 2px" >ID#</div>
									</td>
									<td style="width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 2px" >Client</div>
									</td>
									<td style="width:17%"></td>
									<td style="width:16%">
										<div class="tLabel" style="display: inline; width: 100px; height: 6px" >Client ID#</div>
									</td>
									<td style="width:17%">
									</td>
									<td style="width:16%">
									</td>
								</tr>
								<tr>
									<td style="width:17%">
									    <asp:textbox id="tbxRecordID" tabIndex="1" runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>' width="100px" ReadOnly="True"></asp:textbox>
										<asp:TextBox id="tbxID" tabIndex="200" runat="server" width="0px" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>' ReadOnly="True"></asp:TextBox>
								    </td>
									<td style="width:17%" colspan="2">
									    <asp:textbox id="tbxCOMPANIES_ID" tabIndex="2" runat="server" CssClass="tTextField" width="255px"
											ReadOnly="True"></asp:textbox>
									</td>
									<td style="width:17%"><asp:textbox id="tbxClientID" tabIndex="3" runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].ClientID") %>' width="100px"></asp:textbox></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
								</tr>
								<tr valign="top">
									<td style="width:17%"></td>
									<td style="width:17%" colspan="2"></td>
									<td style="width:16%"></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
								</tr>
								<tr style="height:3px">
									<td style="width:17%; height:3px">&nbsp;</td>
									<td style="width:17%; height:3px">&nbsp;</td>
									<td style="width:17%; height:3px">&nbsp;</td>
									<td style="width:16%; height:3px">&nbsp;</td>
									<td style="width:17%; height:3px">
									    <asp:checkbox id="cbxFullLengthLining" tabIndex="8" runat="server" CssClass="tLabel" Text="Full Length Lining?" height="12px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].FullLengthLining") %>'></asp:checkbox>
									</td>
									<td style="width:16%; height:3px">&nbsp;</td>
								</tr>
								<tr style="height:16px">
									<td style="width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 13px" >Sub Area</div>
									</td>
									<td style="width:17%"></td>
									<td style="width:17%">
									    <div class="tLabel" style="display: inline; width: 100px; height: 7px" >City</div></td>
									<td style="width:16%">
									    <div class="tLabel" style="display: inline; width: 100px; height: 7px" >Prov/State</div></td>
									<td style="width:17%">
									    <asp:checkbox id="cbxPointLining" tabIndex="9" runat="server" CssClass="tLabel" Text="Point Lining?" width="112px" height="16px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].PointLining") %>'></asp:checkbox></td>
									<td style="width:16%">
									    <asp:checkbox id="cbxSubcontractorLining" tabIndex="13" runat="server" CssClass="tLabel" Text="Subcontractor Lining?" width="152px" height="16px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].SubcontractorLining") %>'></asp:checkbox></td>
								</tr>
								<tr>
									<td style="width:17%" colspan="2">
									    <asp:textbox id="tbxSubArea" tabIndex="4" runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].SubArea") %>' width="261px"></asp:textbox></td>
									<td style="width:17%">
									    <asp:TextBox ID="tbxCity" runat="server" CssClass="tTextField" TabIndex="4" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].City") %>' width="100px"></asp:TextBox></td>
									<td style="width:16%">
									    <asp:TextBox ID="tbxProvState" runat="server" CssClass="tTextField" TabIndex="4" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].ProvState") %>' width="100px"></asp:TextBox></td>
									<td style="width:17%">
									    <asp:checkbox id="cbxLateralLining" tabIndex="10" runat="server" CssClass="tLabel" Text="Lateral Lining?" width="112px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].LateralLining") %>'></asp:checkbox></td>
									<td style="width:16%">
									    <asp:checkbox id="cbxOutOfScopeInArea" tabIndex="14" runat="server" CssClass="tLabel" Text="Out Of Scope / In Area" width="152px" height="16px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].OutOfScopeInArea") %>'></asp:checkbox></td>
								</tr>
								<tr style="height:16px">
									<td style="width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 5px" >Street</div>
									</td>
									<td style="width:17%"></td>
									<td style="width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 3px" >USMH</div>
									</td>
									<td style="width:16%">
										<div class="tLabel" style="display: inline; width: 100px; height: 3px" >DSMH</div>
									</td>
									<td style="width:17%"><asp:checkbox id="cbxJLiner" tabIndex="11" runat="server" CssClass="tLabel" Text="J-Liner?" height="16px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].JLiner") %>'></asp:checkbox></td>
									<td style="width:16%"><asp:checkbox id="cbxRehabAssessment" tabIndex="15" runat="server" CssClass="tLabel" Text="Rehab Assessment" height="16px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].RehabAssessment") %>'></asp:checkbox></td>
								</tr>
								<tr>
									<td style="width:17%" colspan="2">
									    <asp:textbox id="tbxStreet" tabIndex="5" runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].Street") %>' width="261px"></asp:textbox></td>
									<td style="width:17%">
									    <asp:textbox id="tbxUSMH" tabIndex="6" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].USMH") %>' width="100px"></asp:textbox></td>
									<td style="width:16%">
									    <asp:textbox id="tbxDSMH" tabIndex="7" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].DSMH") %>' width="100px"></asp:textbox></td>
									<td style="width:17%">
									    <asp:checkbox id="cbxGrouting" tabIndex="12" runat="server" CssClass="tLabel" Text="Grouting?" height="16px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].Grouting") %>'></asp:checkbox></td>
									<td style="width:16%">
									    <asp:checkbox id="cbxFullLengthPointLiner" tabIndex="16" runat="server" CssClass="tLabel" Text="Full Length Point Liner?" width="155px" height="16px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].FullLengthPointLiner") %>'></asp:checkbox></td>
								</tr>
							</table>
							<br/>
							<br/>
							
							<!-- Data element: Horizontal rule -->
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td>
										<tr style="width:100%" color="#c8dbed" size="2"/>
									</td>
								</tr>
							</table>
							
							<!-- Page element: 6Columns -->
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr style="height:16px">
									<td style="width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 5px" >Map size</div>
									</td>
									<td style="width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 7px" >Confirmed 
											size</div>
									</td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
								</tr>
								<tr>
									<td style="width:17%">
									    <asp:textbox id="tbxSize_" tabIndex="17" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].size_") %>' width="100px"></asp:textbox></td>
									<td style="width:17%">
									    <asp:textbox id="tbxConfirmedSize" tabIndex="18" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].Confirmedsize") %>' width="100px"></asp:textbox></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
								</tr>
								<tr valign="top">
									<td style="width:17%"></td>
									<td style="width:17%"><asp:regularexpressionvalidator id="revConfirmedSize" runat="server" EnableViewState="False" ValidationExpression="\d*"
											display="Dynamic" ControlToValidate="tbxConfirmedSize" ErrorMessage="Invalid data" Font-size="Smaller"></asp:regularexpressionvalidator></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
								</tr>
								<tr style="height:16px">
									<td style="height: 1px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 7px" >Scaled Length</div>
									</td>
									<td style="height: 1px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 7px" >Actual Length</div>
									</td>
									<td style="height: 1px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 6px" >Live Lats</div>
									</td>
									<td style="height: 1px; width:16%">
										<div class="tLabel" style="display: inline; width: 108px; height: 14px" >Estimated 	# Joints</div>
									</td>
									<td style="height: 1px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 6px" >CXI's Removed</div>
									</td>
									<td style="height: 1px; width:16%">
									    <asp:label id="lblInstallRate" runat="server" CssClass="tLabel">Install Rate</asp:label></td>
								</tr>
								<tr>
									<td style="height: 22px; width:17%">
									    <asp:textbox id="tbxScaledLength" tabIndex="19" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].ScaledLength") %>' width="100px"></asp:textbox></td>
									<td style="height: 22px; width:17%">
									    <asp:textbox id="tbxActualLength" tabIndex="20" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].ActualLength") %>' width="100px"></asp:textbox></td>
									<td style="height: 22px; width:17%">
									    <asp:textbox id="tbxLiveLats" tabIndex="21" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].LiveLats") %>' width="100px"></asp:textbox></td>
									<td style="height: 22px; width:16%">
									    <asp:textbox id="tbxEstimatedJoints" tabIndex="22" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].EstimatedJoints") %>' width="100px"></asp:textbox></td>
									<td style="height: 22px; width:17%">
									    <asp:textbox id="tbxCXIsRemoved" tabIndex="23" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].CXIsRemoved") %>' width="100px"></asp:textbox></td>
									<td style="height: 22px; width:16%">
									    <asp:textbox id="tbxInstallRate" tabIndex="24" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].InstallRate", "{0:N}") %>' width="100px"></asp:textbox></td>
								</tr>
								<tr valign="top">
									<td style="width:17%">
										<asp:customvalidator id="cvScaledLength" runat="server" width="80px" Font-size="Smaller" ErrorMessage="Invalid data"
											ControlToValidate="tbxScaledLength" display="Dynamic"></asp:customvalidator></td>
									<td style="width:17%">
										<asp:customvalidator id="cvActualLength" runat="server" width="100px" Font-size="Smaller" ControlToValidate="tbxActualLength" display="Dynamic" ValidateEmptyText="True"></asp:customvalidator></td>
									<td style="width:17%"><asp:regularexpressionvalidator id="revLiveLats" runat="server" EnableViewState="False" ValidationExpression="\d*(\.\d+)?"
											display="Dynamic" ControlToValidate="tbxLiveLats" ErrorMessage="Invalid data" Font-size="Smaller"></asp:regularexpressionvalidator></td>
									<td style="width:16%"><asp:regularexpressionvalidator id="revEstimatedJoints" runat="server" EnableViewState="False" ValidationExpression="\d*"
											display="Dynamic" ControlToValidate="tbxEstimatedJoints" ErrorMessage="Invalid data" Font-size="Smaller"></asp:regularexpressionvalidator></td>
									<td style="width:17%"></td>
									<td style="width:16%"><asp:regularexpressionvalidator id="revInstallRate" runat="server" EnableViewState="False" width="66px" ValidationExpression="\d*(\.\d+)?"
											display="Dynamic" ControlToValidate="tbxInstallRate" ErrorMessage="Invalid data" Font-size="Smaller"></asp:regularexpressionvalidator></td>
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
								<tr style="height:16px">
									<td style="height: 7px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 5px" >Pre-Flush Date</div>
									</td>
									<td style="height: 7px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 5px" >Pre-Video Date</div>
									</td>
									<td style="height: 7px; width:17%">
										<div class="tLabel" style="display: inline; width: 132px; height: 10px" >Proposed Lining Date</div>
									</td>
									<td style="height: 7px; width:16%">
										<div class="tLabel" style="display: inline; width: 100px; height: 3px" >Deadline Date</div>
									</td>
									<td style="height: 7px; width:17%"></td>
									<td style="height: 7px; width:16%"></td>
								</tr>
								<tr>
									<td style="width:17%">
									    <asp:textbox id="tbxPreFlushDate" tabIndex="25" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].PreFlushDate", "{0:d}") %>' width="100px">
										</asp:textbox></td>
									<td style="width:17%">
									    <asp:textbox id="tbxPreVideoDate" tabIndex="26" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].PreVideoDate", "{0:d}") %>' width="100px">
										</asp:textbox></td>
									<td style="width:17%">
									    <asp:textbox id="tbxProposedLiningDate" tabIndex="27" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].ProposedLiningDate", "{0:d}") %>' width="100px"></asp:textbox></td>
									<td style="width:16%">
									    <asp:textbox id="tbxDeadlineDate" tabIndex="28" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].DeadlineDate", "{0:d}") %>' width="100px"></asp:textbox></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
								</tr>
								<tr valign="top">
									<td style="width:17%"><asp:customvalidator id="cvPreFlushDate" runat="server" EnableViewState="False" width="72px" display="Dynamic"
											ControlToValidate="tbxPreFlushDate" ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:17%"><asp:customvalidator id="cvPreVideoDate" runat="server" EnableViewState="False" display="Dynamic" ControlToValidate="tbxPreVideoDate"
											ErrorMessage="Invalid data" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:17%"><asp:customvalidator id="cvProposedLiningDate" runat="server" EnableViewState="False" display="Dynamic"
											ControlToValidate="tbxProposedLiningDate" ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:16%"><asp:customvalidator id="cvDeadlineDate" runat="server" EnableViewState="False" display="Dynamic" ControlToValidate="tbxDeadlineDate"
											ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:17%"></td>
									<td style="width:16%"></td>
								</tr>
								<tr style="height:16px">
									<td style="height: 3px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 3px" >P1 Date</div>
									</td>
									<td style="height: 3px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 6px" >M1 Date</div>
									</td>
									<td style="height: 3px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 6px" >M2 Date</div>
									</td>
									<td style="height: 3px; width:16%">
										<div class="tLabel" style="display: inline; width: 100px; height: 5px" >Install Date</div>
									</td>
									<td style="height: 3px; width:17%">
										<div class="tLabel" style="display: inline; width: 100px; height: 5px" >Final Video</div>
									</td>
									<td style="height: 3px; width:16%"></td>
								</tr>
								<tr>
									<td style="height: 3px; width:17%">
									    <asp:textbox id="tbxP1Date" tabIndex="29" runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].P1Date", "{0:d}") %>' width="100px"></asp:textbox></td>
									<td style="height: 3px; width:17%">
									    <asp:textbox id="tbxM1Date" tabIndex=30 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].M1Date", "{0:d}") %>' width="100px"></asp:textbox></td>
									<td style="height: 3px; width:17%">
									    <asp:textbox id="tbxM2Date" tabIndex=31 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].M2Date", "{0:d}") %>' width="100px"></asp:textbox></td>
									<td style="height: 3px; width:16%">
									    <asp:textbox id="tbxInstallDate" tabIndex=32 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].InstallDate", "{0:d}") %>' width="100px"></asp:textbox></td>
									<td style="height: 3px; width:17%">
									    <asp:textbox id="tbxFinalVideo" tabIndex=33 runat="server" CssClass="tTextFieldCenter" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].FinalVideo", "{0:d}") %>' width="100px">
										</asp:textbox>
								    </td>
									<td style="height: 3px; width:16%"></td>
								</tr>
								<tr valign="top">
									<td style="width:17%"><asp:customvalidator id="cvP1Date" runat="server" EnableViewState="False" display="Dynamic" ControlToValidate="tbxP1Date"
											ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:17%"><asp:customvalidator id="cvM1Date" runat="server" EnableViewState="False" display="Dynamic" ControlToValidate="tbxM1Date"
											ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:17%"><asp:customvalidator id="cvM2Date" runat="server" EnableViewState="False" width="66px" display="Dynamic"
											ControlToValidate="tbxM2Date" ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:16%"><asp:customvalidator id="cvInstallDate" runat="server" EnableViewState="False" width="72px" display="Dynamic"
											ControlToValidate="tbxInstallDate" ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:17%"><asp:customvalidator id="cvFinalVideo" runat="server" EnableViewState="False" display="Dynamic" ControlToValidate="tbxFinalVideo"
											ErrorMessage="Invalid date" Font-size="Smaller"></asp:customvalidator></td>
									<td style="width:16%"></td>
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
												    <asp:checkbox id="cbxIssueIdentified" tabIndex="34" runat="server" CssClass="tLabel" Text="Issue Identified?" width="120px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].IssueIdentified") %>'></asp:checkbox></td>
											</tr>
											<tr>
												<td style="width:30%">&nbsp;</td>
												<td style="width:70%">&nbsp;</td>
											</tr>
											<tr>
												<td style="width:30%"></td>
												<td style="width:70%">
												    <asp:checkbox id="cbxLFSIssue" tabIndex="35" runat="server" CssClass="tLabel" Text="LFS Issue?" width="150px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].LFSIssue") %>'></asp:checkbox></td>
											</tr>
											<tr>
												<td style="width:30%"></td>
												<td style="width:70%">
												    <asp:checkbox id="cbxClientIssue" tabIndex="36" runat="server" CssClass="tLabel" Text="Client Issue?" width="150px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].ClientIssue") %>'></asp:checkbox></td>
											</tr>
											<tr>
												<td style="width:30%"></td>
												<td style="width:70%">
												    <asp:checkbox id="cbxSalesIssue" tabIndex="37" runat="server" CssClass="tLabel" Text="Sales Issue?" width="150px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].SalesIssue") %>'></asp:checkbox></td>
											</tr>
											<tr>
												<td style="width:30%"></td>
												<td style="width:70%">
												    <asp:checkbox id="cbxInvestigationIssue" tabIndex="38" runat="server" CssClass="tLabel" Text="Investigation Issue?" width="136px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].InvestigationIssue") %>'></asp:checkbox></td>
											</tr>
											<tr>
												<td style="width:30%"></td>
												<td style="width:70%">
												    <asp:checkbox id="cbxIssueGivenToBayCity" tabIndex="39" runat="server" CssClass="tLabel" Text="Issue Given To Client?" width="168px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].IssueGivenToBayCity") %>'></asp:checkbox></td>
											</tr>
											<tr>
												<td style="width:30%"></td>
												<td style="width:70%">
												    <asp:checkbox id="cbxIssueResolved" tabIndex="40" runat="server" CssClass="tLabel" Text="Issue Resolved?" width="136px" Checked='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].IssueResolved") %>'></asp:checkbox></td>
											</tr>
										</table>
									</td>
									<td valign="top"  style="width:66%">
										<table cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td style="width:580px">
													<div class="tLabel" style="display: inline; width: 216px; height: 19px" >Point 
														Repair / Grout / Lateral Details</div>
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
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td style="height:16px">
										<div class="tLabel" style="display: inline; width: 88px; height: 6px" >Comments</div>
									</td>
								</tr>
								<tr>
									<td>
									    <asp:textbox id="tbxComments" tabIndex="44" runat="server" CssClass="tTextField" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].Comments") %>' width="891px" height="85px" TextMode="MultiLine"></asp:textbox></td>
								</tr>
							</table>
							
							<br/>
							
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td style="height:16px">
										<div class="tLabel" style="display: inline; width: 88px; height: 6px" >History</div>
									</td>
								</tr>
								<tr>
									<td>
									    <asp:textbox id="tbxHistory" tabIndex="45" runat="server" CssClass="tTextField" width="891px" Text='<%# DataBinder.Eval(tdsLfsRecord, "tables[LFS_MASTER_AREA].DefaultView.[0].History") %>'
											height="85px" TextMode="MultiLine"></asp:textbox></td>
								</tr>
							</table>
                            <br/>
							<br/>
							<!-- Page element: Footer buttons -->
							<table style="height:28px" cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td valign="middle" style="width:700px; height:28px" background="./../common/images/im_footer1.gif" >
										<table cellspacing="0" cellpadding="0" style="width:700px" border="0">
											<tr>
												<td style="width:10px"></td>
												<td align="center" style="width:50px">
												    <asp:button id="btnPrevious" tabIndex="100" runat="server" CssClass="tButtonPrevNext" Text="Prev"
														EnableViewState="False" width="50px" height="22px" Font-Bold="True" onclick="btnPrevious_Click"></asp:button></td>
												<td style="width:5px"></td>
												<td align="center" style="width:50px">
												    <asp:button id="btnNext" tabIndex="100" runat="server" CssClass="tButtonPrevNext" Text="Next"
														EnableViewState="False" width="50px" height="22px" onclick="btnNext_Click"></asp:button></td>
												<td style="width:25px"></td>
												<td align="center" style="width:90px">
												    <asp:button id="btnDelete" tabIndex="100" runat="server" CausesValidation="False" CssClass="tButtonDelete"
														Text="Delete" width="90px" height="22px" onclick="btnDelete_Click"></asp:button></td>
												<td style="width:25px"></td>
												<td style="width:445px">
												    <asp:validationsummary id="vsFooter" runat="server" EnableViewState="False" width="445px" Font-size="Smaller"
														BackColor="#C8DBED" HeaderText="VALIDATION ISSUES.  Please review the form."></asp:validationsummary></td>
											</tr>
										</table>
									</td>
									<td valign="middle" align="left" style="width:100px; height:28px" background="./../common/images/im_footer2.gif" >
									    <asp:button id="btnOK" tabIndex="50" runat="server" CssClass="tButtonOkCancel" Text="OK" EnableViewState="False"
											width="90px" height="22px" onclick="btnOK_Click"></asp:button></td>
									<td valign="middle" align="left" style="width:100px; height:28px" background="./../common/images/im_footer3.gif" >
									    <asp:button id="btnCancel" tabIndex="51" runat="server" CausesValidation="False" CssClass="tButtonOkCancel"
											Text="Cancel" width="90px" height="22px" onclick="btnCancel_Click"></asp:button></td>
								</tr>
								<tr>
									<td></td>
									<td style="width: 187px" colspan="2"></td>
								</tr>
							</table>
							<br/>
						</div>
					</td>
					
					<!-- ENDPAGE -->
					<td>&nbsp;</td>
				</tr>
			</table>		            
            
            <!-- Page element: Data objects -->
            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:ObjectDataSource ID="odsPointRepairs" runat="server" 
                         SelectMethod="GetPointRepairsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.view_all" 
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
