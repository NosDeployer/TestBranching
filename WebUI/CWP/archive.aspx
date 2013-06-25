<%@ Page language="c#" Codebehind="archive.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.Archive" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>Archive</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="./../common/images/lfcss.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form method="post" runat="server">
			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR bgColor="#c8dbed" height="30">
					<TD width="40">&nbsp;</TD>
					<TD width="40">&nbsp;</TD>
					<TD width="820">&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
				<tr height="30">
					<td bgColor="#c8dbed"></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td bgColor="#c8dbed"></td>
					<td></td>
					<!-- PAGE -->
					<td vAlign="top">
						<!-- Custom: Header -->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:label id="lblDialogTitle" runat="server" CssClass="tDialogTitle" Font-Bold="True">Archive Tool</asp:label></td>
							</tr>
							<tr>
								<td>
									<hr width="100%" color="#c8dbed" SIZE="2">
								</td>
							</tr>
						</table>
						<br>
						<!-- Custom: Search -->
						<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 86px; HEIGHT: 13px" vAlign="middle" width="86">
									<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 70px; HEIGHT: 15px" >Search 
										By</DIV>
								</TD>
								<TD style="WIDTH: 250px; HEIGHT: 13px" vAlign="middle" width="250">
									<asp:dropdownlist id="ddlSearch" tabIndex="1" runat="server" AutoPostBack="True" Width="240px" CssClass="tTextField" onselectedindexchanged="ddlSearch_SelectedIndexChanged">
										<asp:ListItem Value="ID#">ID#</asp:ListItem>
										<asp:ListItem Value="Client">Client</asp:ListItem>
										<asp:ListItem Value="USMH">USMH</asp:ListItem>
										<asp:ListItem Value="DSMH">DSMH</asp:ListItem>
										<asp:ListItem Value="Street">Street</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 13px" vAlign="middle" width="100"></TD>
								<TD style="HEIGHT: 13px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 86px"></TD>
								<TD style="WIDTH: 250px">
									<asp:textbox id="tbxSearch" tabIndex="2" runat="server" Width="240px" CssClass="tTextField"></asp:textbox></TD>
								<TD vAlign="middle" width="100">
									<asp:button id="btnSubmit" tabIndex="3" runat="server" Width="100px" CssClass="tButtonOkCancel"
										Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 86px"></TD>
								<TD style="WIDTH: 250px">
								<TD width="100"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 86px"></TD>
								<TD style="WIDTH: 250px">
									<asp:label id="lblHint" runat="server" CssClass="tLabel" >Type '%' to get all records</asp:label></TD>
								<TD width="100"></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<br>
						<!-- Custom: Results -->
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<asp:panel id="pNoResults" runat="server">
										<TABLE height="28" cellSpacing="0" cellPadding="0" width="100%" bgColor="#c8dbed" border="0">
											<TR>
												<TD width="700" height="28">&nbsp;
													<asp:Label id="lblResults" runat="server" Font-Bold="True" ForeColor="Red" BackColor="#C8DBED">No results found for your query</asp:Label></TD>
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td></td>
				</tr>
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
