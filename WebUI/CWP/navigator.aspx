<%@ Page language="c#" Codebehind="navigator.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.navigator" SmartNavigation="true" %>
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
		<form method="post" runat="server"> <!-- onsubmit="__doPostBack('btnSubmit','');" -->
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>&nbsp;</TD>
					<!-- PAGE -->
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
												<TD align="right" width="85" height="23"><asp:linkbutton id="lkbtnSignOut" tabIndex="100" runat="server" CssClass="tMainLink" onclick="lkbtnSignOut_Click">Sign out</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD align="right" width="85" height="23"><A class="tmainlinkorange" tabIndex="100" href="./../default.aspx">Menu</A>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE> <!-- Page element: Header buttons -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD width="700" background="./../common/images/im_header4.gif" height="28">&nbsp;</TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header5.gif" height="28"></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header6.gif" height="28"></TD>
								</TR>
							</TABLE>
							<BR> <!-- Page element: Title with horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><asp:label id="lblTitle" runat="server" CssClass="tTitle" Font-Size="Large" EnableViewState="False"> Navigator</asp:label></TD>
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
							</TABLE>
							<BR> <!-- Page element: Custom [search] -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<DIV>
											<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD style="WIDTH: 86px; HEIGHT: 13px" vAlign="middle" width="86">
														<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 70px; HEIGHT: 15px" >Search 
															By</DIV>
													</TD>
													<TD style="WIDTH: 250px; HEIGHT: 13px" vAlign="middle" width="250"><asp:dropdownlist id="ddlSearch" tabIndex="1" runat="server" CssClass="tTextField" AutoPostBack="True"
															Width="240px" onselectedindexchanged="ddlSearch_SelectedIndexChanged">
															<asp:ListItem Value="ID#">ID#</asp:ListItem>
															<asp:ListItem Value="Client">Client</asp:ListItem>
															<asp:ListItem Value="USMH">USMH</asp:ListItem>
															<asp:ListItem Value="DSMH">DSMH</asp:ListItem>
															<asp:ListItem Value="P1 Date">P1 Date</asp:ListItem>
															<asp:ListItem Value="M1 Date">M1 Date</asp:ListItem>
															<asp:ListItem Value="M2 Date">M2 Date</asp:ListItem>
															<asp:ListItem Value="Install Date">Install Date</asp:ListItem>
															<asp:ListItem Value="Street">Street</asp:ListItem>
														</asp:dropdownlist></TD>
													<TD style="HEIGHT: 13px" vAlign="middle" width="100"></TD>
													<TD style="HEIGHT: 13px"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 86px"></TD>
													<TD style="WIDTH: 250px"><asp:textbox id="tbxSearch" tabIndex="2" runat="server" CssClass="tTextField" Width="240px"></asp:textbox></TD>
													<TD vAlign="middle" width="100"><asp:button id="btnSubmit" tabIndex="3" runat="server" CssClass="tButtonOkCancel" Width="100px"
															Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 86px"></TD>
													<TD style="WIDTH: 250px"><asp:customvalidator id="cvSearch" runat="server" Font-Size="Smaller" EnableViewState="False" ControlToValidate="tbxSearch"
															Display="Dynamic"></asp:customvalidator>
													<TD width="100"></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 86px"></TD>
													<TD style="WIDTH: 250px"><asp:label id="lblHint" runat="server" CssClass="tLabel">Type '%' to get all records</asp:label></TD>
													<TD width="100"></TD>
													<TD></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</TABLE>
							<BR>
							<!-- Page element: Custom [no results] -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<DIV><asp:panel id="pNoResults" runat="server">
												<TABLE height="28" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="700" background="./../common/images/im_footer1.gif" height="28">&nbsp;
															<asp:Label id="lblResults" runat="server" BackColor="#C8DBED" Font-Bold="True" ForeColor="Red">No results found for your query</asp:Label></TD>
														<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer2.gif" height="28"></TD>
														<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer3.gif" height="28"></TD>
													</TR>
												</TABLE>
											</asp:panel></DIV>
									</TD>
								</TR>
							</TABLE>
				            <!-- Page element:  IFrame-->
                            <table>
                                <tr>
                                    <td style="height: 7px">
                                        <iframe id="iframe" frameborder="0" height="0" width="0" src="./../refresh_iframe.aspx" >
                                            Your web browser don't accept iFrame tag. Contact with your Administrator.
                                        </iframe>
                                    </td>
                                </tr>
                            </table>
						</DIV>
					</TD> <!-- ENDPAGE -->
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
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
