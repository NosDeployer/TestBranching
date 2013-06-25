<%@ Page language="c#" Codebehind="print.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LFS Combined Work Program</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="./../common/images/lfcss.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" height="100%" border="0">
				<TR height="30" bgColor="#c8dbed">
					<TD style="width: 40px; height: 30px">&nbsp;</TD>
					<TD width="40" style="height: 30px">&nbsp;</TD>
					<TD width="430" style="height: 30px">&nbsp;</TD>
					<TD style="height: 30px">&nbsp;</TD>
				</TR>
				<tr height="30">
					<td bgColor="#c8dbed" style="width: 40px"></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td bgColor="#c8dbed" style="width: 40px"></td>
					<td></td>
					<!-- PAGE -->
					<td valign="top">
						<!-- HEADER -->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<asp:label id="lblTitle" runat="server" Font-Bold="True" CssClass="tDialogTitle">Dialog title</asp:label>
								</td>
							</tr>
							<tr>
								<td>
									<hr width="100%" size="2" color="#c8dbed">
								</td>
							</tr>
						</table>
						<!-- DATA -->
						<table cellSpacing="0" cellPadding="0" width="100%" border="0" ID="Table1">
							<tr>
								<td>
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 171px" ><asp:button id="btnPreview" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 88px" tabIndex="2"
											runat="server" Width="80px" Text="Preview" CssClass="tButtonOkCancel" Height="22px" onclick="btnPreview_Click"></asp:button>
										<INPUT id="hbtnCancel" style="Z-INDEX: 101; LEFT: 344px; WIDTH: 80px; POSITION: absolute; TOP: 88px; HEIGHT: 22px"
											onclick="window.close();" tabIndex="4" type="button" value="Close" class="tButtonOkCancel">
										<asp:button id="btnExport" style="Z-INDEX: 103; LEFT: 88px; POSITION: absolute; TOP: 88px" tabIndex="3"
											runat="server" CssClass="tButtonOkCancel" Width="80px" Height="22px" Text="Export" onclick="btnExport_Click"></asp:button></DIV>
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
	</body>
</HTML>
