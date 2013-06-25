<%@ Page language="c#" Codebehind="error_page.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.error_page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head runat="server">
		<title>LFS Combined Work Program</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link href="./common/images/lfcss.css" rel="stylesheet" type="text/css" />
	</head>
	<body >
		<form method="post" runat="server">
			<table cellspacing="0" cellpadding="0" style="height:100%; width: 100%" border="0">
				<tr style="height: 30px" bgcolor="#c2c2c4">
					<td style="width:40px">&nbsp;</td>
					<td style="width:40px">&nbsp;</td>
					<td style="width:614px">&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr style="height:30px">
					<td bgcolor="#c2c2c4"></td>
					<td></td>
					<td style="width: 614px"></td>
					<td></td>
				</tr>
				<tr>
					<td bgcolor="#c2c2c4"></td>
					<td></td>
					<!-- PAGE -->
					<td valign="top" style="WIDTH: 615px">
						<!-- HEADER -->
						<table cellspacing="0" cellpadding="0" style="width:100%" border="0">
							<tr>
								<td>
									<asp:label id="lblTitle" runat="server" Font-Bold="True" CssClass="tDialogTitleNew">LFS Live</asp:label>
								</td>
							</tr>
							<tr>
								<td>
									<hr style="width:100%" size="2" color="#c2c2c4" />
								</td>
							</tr>
						</table>
						<!-- DATA -->
						<table cellspacing="0" cellpadding="0" width="100%" border="0" id="Table1">
							<tr>
								<td>
									<div style="WIDTH: 100.11%; POSITION: relative; HEIGHT: 404px" >
										<asp:Label id="lblTitleError" runat="server" Font-Bold="True" ForeColor="Red">ERROR</asp:Label>
										<asp:Label id="lblError" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 32px" runat="server"
											CssClass="tLabelNew" Width="576px" Height="340px">Label</asp:Label>
									</div>
								</td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</html>
