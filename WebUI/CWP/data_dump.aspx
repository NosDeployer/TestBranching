<%@ Page language="c#" Codebehind="data_dump.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.data_dump" %>
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
			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR bgColor="#c8dbed" height="30">
					<TD width="40">&nbsp;</TD>
					<TD width="40">&nbsp;</TD>
					<TD width="430">&nbsp;</TD>
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
						<!-- HEADER -->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:label id="lblTitle" runat="server" CssClass="tDialogTitle" Font-Bold="True">Data Dump</asp:label></td>
							</tr>
							<tr>
								<td>
									<hr width="100%" color="#c8dbed" SIZE="2">
								</td>
							</tr>
						</table>
						<!-- DATA -->
						<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 182px" ><asp:label id="lblSelectATable" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px"
											runat="server" CssClass="tLabel"> Select Table</asp:label><asp:dropdownlist id="ddlTable" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 24px" tabIndex="1"
											runat="server" CssClass="tTextField" Width="250px">
											<asp:ListItem Value="Master area">Master area</asp:ListItem>
											<asp:ListItem Value="Point repairs">Point repairs</asp:ListItem>
											<asp:ListItem Value="M2 Tables">M2 Tables</asp:ListItem>
											<asp:ListItem Value="Junction Liners">Junction Liners</asp:ListItem>
										</asp:dropdownlist><asp:button id="btnDump" style="Z-INDEX: 103; LEFT: 0px; POSITION: absolute; TOP: 104px" tabIndex="2"
											runat="server" CssClass="tButtonOkCancel" Width="80px" Height="22px" Text="Dump" onclick="btnDump_Click"></asp:button><INPUT class="tButtonOkCancel" id="hbtnCancel" style="Z-INDEX: 100; LEFT: 344px; WIDTH: 80px; POSITION: absolute; TOP: 104px; HEIGHT: 22px"
											onclick="window.close();" tabIndex="3" type="button" value="Close">
										<asp:checkbox id="cbxIncludeArchivedRecords" style="Z-INDEX: 105; LEFT: 0px; POSITION: absolute; TOP: 56px"
											tabIndex="8" runat="server" CssClass="tLabel" Text="Include archived records" Height="16px"></asp:checkbox></DIV>
								</td>
							</tr>
						</table>
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
		<!--- Inline scripts --->
		<script>window.document.all["ddlTable"].focus()</script>
	</body>
</HTML>
