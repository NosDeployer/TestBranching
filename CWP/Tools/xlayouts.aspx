<%@ Page language="c#" Codebehind="xlayouts.aspx.cs" AutoEventWireup="True" Inherits="LFS.layouts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>layouts</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="images/lfcss.css" type="text/css" rel="stylesheet">
		<!-- -------------------- Scripts -------------------- -->
		<script>
			//
			// flkbtnSignOut()
			//
			function flkbtnSignOut()
			{
				window.alert("sign out");
			}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>&nbsp;</TD>
					<TD vAlign="top" width="900">
						<!-- PAGE -->
						<div>
							<!-- Page element: Header -->
							<table cellSpacing="0" cellPadding="0" width="900" border="0">
								<tr>
									<td width="700" background="images/im_header1.gif" height="50">&nbsp;</td>
									<td width="100" background="images/im_header2.gif" height="50"></td>
									<td width="100" background="images/im_header3.gif" height="50">
										<table height="50" cellSpacing="0" cellPadding="0" width="100" border="0">
											<tr>
												<td width="85" height="4"></td>
												<td width="15" rowSpan="3"></td>
											</tr>
											<tr>
												<td align="right" width="85" height="23"><asp:linkbutton id="lkbtnSignOut" runat="server" CssClass="tMainLink">Sign out</asp:linkbutton></td>
											</tr>
											<tr>
												<td align="right" width="85" height="23"><A class="tmainlinkorange" href="default.aspx">Menu</A>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<!-- Page element: Header buttons -->
							<table cellSpacing="0" cellPadding="0" width="900" border="0">
								<tr>
									<td width="700" background="images/im_header4.gif" height="28">&nbsp;</td>
									<td vAlign="middle" align="left" width="100" background="images/im_header5.gif" bgColor="#3399cc"
										height="28"><asp:button id="Button1" runat="server" CssClass="tButtonOkCancel" Height="22px" Width="90px"
											Text="OK"></asp:button></td>
									<td vAlign="middle" align="left" width="100" background="images/im_header6.gif" bgColor="#00ff33"
										height="28"><asp:button id="Button2" runat="server" CssClass="tButtonOkCancel" Height="22px" Width="90px"
											Text="Cancel"></asp:button></td>
								</tr>
							</table>
							<br>
							<br>
							<br>
							<!-- Page element: Title with horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<DIV class="tTitle" style="WIDTH: 496px; POSITION: relative; HEIGHT: 19px" >Title
										</DIV>
									</TD>
								</TR>
								<tr>
									<td>
										<table height="5" cellSpacing="0" cellPadding="0" width="900" border="0">
											<tr>
												<td><IMG height="5" src="images/im_backrowblue.gif" width="900"></td>
											</tr>
										</table>
									</td>
								</tr>
							</TABLE>
							<br>
							<br>
							<br>
							<!-- Page element: Title with tabs and hr -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD colSpan="2">
										<DIV class="tTitle" style="WIDTH: 496px; POSITION: relative; HEIGHT: 19px" >All 
											records in all projects
										</DIV>
									</TD>
								</TR>
								<tr>
									<td width="450">
										<table height="40" cellSpacing="0" cellPadding="0" width="900" border="0">
											<tr>
												<td class="tOptionON" vAlign="middle" align="center" width="150" background="images/Im_OptionON.gif"
													height="40">Section details</td>
												<td vAlign="middle" align="center" width="150" background="images/Im_OptionOff.gif"
													height="40"><A class="tOptionOFF" href="M1_info.htm">m1 info </A>
												</td>
												<td vAlign="middle" align="center" width="150" background="images/Im_OptionOff.gif"
													height="40"><A class="tOptionOFF" href="M2_measurement.htm">m2 measurements </A>
												</td>
												<td width="450" background="images/im_backbutton.gif" height="40">&nbsp;</td>
											</tr>
										</table>
									</td>
									<td></td>
								</tr>
							</TABLE>
							<br>
							<br>
							<br>
							<!-- Page element: Horizontal rule -->
							<table width="900" height="5" border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td><img src="images/im_backrowblue.gif" width="900" height="5"></td>
								</tr>
							</table>
							<br>
							<br>
							<br>
							<!-- Page element: Footer buttons -->
							<table width="900" height="28" border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td width="700" height="28" background="images/im_footer1.gif">&nbsp;</td>
									<td width="100" height="28" vAlign="middle" align="left" background="images/im_footer2.gif">
										<asp:button id="Button3" runat="server" CssClass="tButtonOkCancel" Height="22px" Width="90px"
											Text="OK"></asp:button></td>
									<td width="100" height="28" vAlign="middle" align="left" background="images/im_footer3.gif">
										<asp:button id="Button4" runat="server" CssClass="tButtonOkCancel" Height="22px" Width="90px"
											Text="Cancel"></asp:button></td>
								</tr>
							</table>
							<br>
							<br>
							<br>
							<br>
							<br>
							<br>
							<!-- Page element: Data [no indent] -->
							<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<td>
										<!-- DATA -->
										<div>
											Page: Data</div>
										<!-- ENDDATA -->
									</td>
								</TR>
							</TABLE>
							<br>
							<!-- Page element: Data [indent] -->
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<td width="30">&nbsp;</td>
									<td>
										<!-- DATA -->
										<div>
											Page: Data</div>
										<!-- ENDDATA -->
									</td>
								</TR>
							</TABLE>
							<br>
							<br>
							<br>
							<!-- Data element: Section -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<DIV  class="tSection" style="WIDTH: 496px; POSITION: relative; HEIGHT: 19px">
											Section
										</DIV>
									</TD>
								</TR>
								<tr>
									<td>
										<HR width="100%" SIZE="2" color="#c8dbed">
									</td>
								</tr>
							</TABLE>
							<br>
							<br>
							<br>
							<!-- Data element: Horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<tr>
									<td>
										<HR width="100%" SIZE="2" color="#c8dbed">
									</td>
								</tr>
							</TABLE>
							<br>
							<br>
							<br>
							<!-- Data element: 3 Columns -->
							<table cellSpacing="0" cellPadding="0" width="100%" border="0" ID="Table13">
								<tr>
									<td width="33%" valign="middle">
										field</td>
									<td width="33%" valign="middle">field</td>
									<td width="34%" valign="middle">field</td>
								</tr>
							</table>
							<br>
							<br>
							<br>
							<!-- Data element: 4 Columns -->
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td width="25%" valign="top"></td>
									<td width="25%" valign="top"></td>
									<td width="25%" valign="top"></td>
									<td width="25%" valign="top"></td>
								</tr>
							</table>
							<br>
							<br>
							<br>
							<!-- Data element: 3 Columns[Inside every column 2 columns and n rows] -->
							<table cellSpacing="0" cellPadding="0" width="100%" border="0" ID="Table14">
								<tr>
									<td width="33%" valign="top">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0" ID="Table15">
											<tr>
												<td>
													label</td>
												<td>field</td>
											</tr>
											<tr>
												<td></td>
												<td></td>
											</tr>
										</table>
									</td>
									<td width="33%" valign="top">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0" ID="Table16">
											<tr>
												<td>label</td>
												<td>field</td>
											</tr>
											<tr>
												<td></td>
												<td></td>
											</tr>
										</table>
									</td>
									<td width="34%" valign="top">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0" ID="Table17">
											<tr>
												<td>label</td>
												<td>field</td>
											</tr>
											<tr>
												<td></td>
												<td></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<br>
							<br>
							<!-- Data element: Grid -->
							<table width="900" cellpadding="0" cellspacing="0" border="0">
								<tr>
									<td width="450">grid title</td>
									<td width="100"></td>
									<td>&nbsp;</td>
								</tr>
								<tr>
									<td width="450">validation</td>
									<td width="100"></td>
									<td></td>
								</tr>
								<tr>
									<td width="450">grid</td>
									<td width="100" valign="top">
										<table width="100" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td width="5"></td>
												<td width="95">add</td>
											</tr>
											<tr>
												<td width="5"></td>
												<td width="95"></td>
											</tr>
											<tr>
												<td width="5"></td>
												<td width="95">clear</td>
											</tr>
										</table>
									</td>
									<td>&nbsp;</td>
								</tr>
							</table>
							<br>
							<br>
							<!-- Page element: 6Columns -->
							<table cellpadding="0" cellspacing="0" width="900" border="0">
								<TR height="16">
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR valign="top">
									<TD width="17%"></TD>
									<TD width="17%"></TD>
									<TD width="17%"></TD>
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
							</table>
							<br>
							<br>
							<!-- Page element: Custom -->
							<table width="900" cellpadding="0" cellspacing="0" border="0">
								<tr>
									<td width="34%" valign="top">
										<table width="100%" cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td width="30%" colspan="2">issues</td>
											</tr>
											<tr>
												<td width="30%">&nbsp;</td>
												<td width="70%">&nbsp;</td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%">lfs issue</td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
										</table>
									</td>
									<td width="66%" valign="top">
										<table width="100%" cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td width="450">grid title2</td>
												<td width="100"></td>
												<td>&nbsp;</td>
											</tr>
											<tr>
												<td width="450">validation</td>
												<td width="100"></td>
												<td></td>
											</tr>
											<tr>
												<td width="450">grid</td>
												<td width="100" valign="top">
													<table width="100" cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td width="5"></td>
															<td width="95">add</td>
														</tr>
														<tr>
															<td width="5"></td>
															<td width="95"></td>
														</tr>
														<tr>
															<td width="5"></td>
															<td width="95">clear</td>
														</tr>
													</table>
												</td>
												<td>&nbsp;</td>
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
									<TD>
									</TD>
								</TR>
							</TABLE>
							<br>
							<br>
							<!-- Page element: Custom -->
							<table width="900" cellpadding="0" cellspacing="0" border="0">
								<tr>
									<td width="34%" valign="top">
										<table width="100%" cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td width="30%" colspan="2">issues</td>
											</tr>
											<tr>
												<td width="30%">&nbsp;</td>
												<td width="70%">&nbsp;</td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%">lfs issue</td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="70%"></td>
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
												</TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</table>
							<br>
							<br>
							<!-- Page element: Custom -->
							<table width="700" cellpadding="10" cellspacing="0" border="0">
								<tr>
									<td>
										<table cellpadding="0" cellspacing="0" width="100%" border="0">
											<TR height="16">
												<TD width="8%" rowspan="9" align="center" valign="middle"></TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >Distance</DIV>
												</TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >Size</DIV>
												</TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >Reinstates</DIV>
												</TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >Installed</DIV>
												</TD>
											</TR>
											<TR>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
											</TR>
											<TR valign="top">
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
											</TR>
											<TR height="16">
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >LT 
														@ MH</DIV>
												</TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >VT 
														@ MH</DIV>
												</TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 88px; HEIGHT: 10px" >Liner 
														distance</DIV>
												</TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >Direction</DIV>
												</TD>
											</TR>
											<TR>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
											</TR>
											<TR valign="top">
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
											</TR>
											<TR height="16">
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >MH 
														Shot?</DIV>
												</TD>
												<TD width="23%">
													<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 72px; HEIGHT: 19px" >Comments</DIV>
												</TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
											</TR>
											<TR>
												<TD width="23%"></TD>
												<TD width="23%" colspan="3"></TD>
											</TR>
											<TR valign="top">
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
												<TD width="23%"></TD>
											</TR>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<br>
							<!-- COMPONENTS -->
							<table>
								<tr>
									<td>
										<p class="tLabel">Label</p>
										<table width="166" height="80" border="0" cellpadding="0" cellspacing="0">
											<tr>
												<td width="166" height="20" bgcolor="#7c8c96" class="tGroup">Group</td>
											</tr>
											<tr>
												<td height="20" bgcolor="#c8dbed" class="tColumns">Colum</td>
											</tr>
											<tr>
												<td height="20" bgcolor="#e7e9eb" class="tItem">Item</td>
											</tr>
											<tr>
												<td height="20" bgcolor="#2f82c7" class="tStatus">Status</td>
											</tr>
										</table>
										<P>
											<br>
											<input type="text" name="textfield" class="tTextField">
											<br>
											<input type="submit" name="Submit" value="Submit" class="tButton">
											<br>
											<br>
											Celeste fuerte #2f82c7
										</P>
										<P>Celeste medio #93b7dd</P>
										<P>Celeste bajo #c8dbed</P>
										<P>Plomo #7c8c96</P>
										<P>Bajito #e7e9eb</P>
                                        <p>
                                            Naranja #f7941c</p>
									</td>
								</tr>
							</table>
						</div>
						<!-- ENDPAGE --></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
		<!---->
	</body>
</HTML>
