<%@ Page language="c#" Codebehind="delete_record.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.delete_record" %>
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
									<asp:label id="lblTitle" runat="server" Font-Bold="True" CssClass="tDialogTitle"> Delete Record</asp:label>
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
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 133px" ><asp:button id="btnOK" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 88px" tabIndex="2"
											runat="server" Width="80px" Text="Yes" CssClass="tButtonOkCancel" Height="22px" onclick="btnOK_Click"></asp:button>
										<asp:Label id="lblID" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server"
											CssClass="tLabel"> Are you sure you want to delete the following record?</asp:Label>
										<asp:TextBox id="tbxRecordID" style="Z-INDEX: 103; LEFT: 0px; POSITION: absolute; TOP: 24px"
											runat="server" Width="100px" tabIndex="1" CssClass="tTextField" ReadOnly="True" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>'>
										</asp:TextBox>
										<asp:button id="btnCancel" style="Z-INDEX: 104; LEFT: 88px; POSITION: absolute; TOP: 88px" tabIndex="2"
											runat="server" Width="80px" Text="No" CssClass="tButtonOkCancel" Height="22px" onclick="btnCancel_Click"></asp:button>
										<asp:TextBox id=tbxID style="Z-INDEX: 105; LEFT: 120px; POSITION: absolute; TOP: 24px" tabIndex=200 runat="server" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>' Width="0px" ReadOnly="True">
										</asp:TextBox></DIV>
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
					</td>
					<td></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
