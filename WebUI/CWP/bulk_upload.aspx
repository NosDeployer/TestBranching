<%@ Page language="c#" Codebehind="bulk_upload.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.bulk_upload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LFS Combined Work Program</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="./../common/images/lfcss.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post" runat="server" enctype="multipart/form-data">
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
								<td><asp:label id="lblTitle" runat="server" CssClass="tDialogTitle" Font-Bold="True">Bulk Upload</asp:label></td>
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
									<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 232px" ><asp:label id="lblSelectAFile" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px"
											runat="server" CssClass="tLabel"> Select a Microsoft Excel File</asp:label><asp:button id="btnUpload" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 152px" tabIndex="2"
											runat="server" CssClass="tButtonOkCancel" Width="80px" Height="22px" Text="Upload" onclick="btnUpload_Click"></asp:button><INPUT class="tButtonOkCancel" id="hbtnCancel" style="Z-INDEX: 100; LEFT: 344px; WIDTH: 80px; POSITION: absolute; TOP: 152px; HEIGHT: 22px"
											onclick="window.close();" tabIndex="3" type="button" value="Close"> <INPUT id="htmlInputFile" style="Z-INDEX: 103; LEFT: 0px; WIDTH: 296px; POSITION: absolute; TOP: 24px; HEIGHT: 22px"
											type="file" size="30" class="tTextField" runat="server">
										<asp:Label id="lblResults" style="Z-INDEX: 104; LEFT: 0px; POSITION: absolute; TOP: 184px"
											runat="server" Font-Bold="True" ForeColor="Red" Font-Size="9pt" Font-Names="Microsoft Sans Serif"></asp:Label>
										<asp:checkbox id="cbxUploadLfsMasterArea" style="Z-INDEX: 105; LEFT: 0px; POSITION: absolute; TOP: 56px"
											tabIndex="8" runat="server" CssClass="tLabel" Text="Upload lfs_master_area data range" Height="16px"
											Checked="True" Enabled="False"></asp:checkbox>
										<asp:checkbox id="cbxUploadLfsPointRepairs" style="Z-INDEX: 106; LEFT: 0px; POSITION: absolute; TOP: 80px"
											tabIndex="8" runat="server" CssClass="tLabel" Text="Upload lfs_point_repairs data range" Height="16px"
											Checked="True"></asp:checkbox>
										<asp:checkbox id="cbxUploadLfsJunctionLiner" style="Z-INDEX: 107; LEFT: 0px; POSITION: absolute; TOP: 104px"
											tabIndex="8" runat="server" CssClass="tLabel" Text="Upload lfs_juntion_liner data range" Height="16px"
											Checked="True"></asp:checkbox></DIV>
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
		<script>window.document.all["htmlInputFile"].focus()</script>
	</body>
</HTML>
