<%@ Page language="c#" Codebehind="print2.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.print2" SmartNavigation="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LFS Combined Work Program</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="./../common/images/lfcss.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" height="100%" border="0">
				<TR height="30" bgColor="#c8dbed">
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
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 168px" >
										<asp:label id="lblSelectAClient" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px"
											runat="server" CssClass="tLabel"> Select Client</asp:label><asp:dropdownlist id="ddlSelectAClient" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 24px"
											tabIndex="1" runat="server" Width="250px" CssClass="tTextField"></asp:dropdownlist><asp:button id="btnPreview" style="Z-INDEX: 103; LEFT: 0px; POSITION: absolute; TOP: 88px" tabIndex="2"
											runat="server" Width="80px" Text="Preview" CssClass="tButtonOkCancel" Height="22px" onclick="btnPreview_Click"></asp:button>
										<INPUT id="hbtnCancel" style="Z-INDEX: 100; LEFT: 344px; WIDTH: 80px; POSITION: absolute; TOP: 88px; HEIGHT: 22px"
											onclick="window.close();" tabIndex="4" type="button" value="Close" class="tButtonOkCancel">
										<asp:button id="btnExport" style="Z-INDEX: 104; LEFT: 88px; POSITION: absolute; TOP: 88px" tabIndex="3"
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
		<!--- Inline scripts --->
		<script>window.document.all["ddlSelectAClient"].focus()</script>
	</body>
</HTML>
