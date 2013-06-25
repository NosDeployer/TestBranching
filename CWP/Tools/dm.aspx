<%@ Page language="c#" Codebehind="dm.aspx.cs" AutoEventWireup="True" Inherits="LFS.Tools.dm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>dm</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 72px; POSITION: absolute; TOP: 48px" runat="server"
				Text="Migrate!" Width="128px" onclick="Button1_Click"></asp:Button>
			<asp:Button id="Button2" style="Z-INDEX: 102; LEFT: 72px; POSITION: absolute; TOP: 112px" runat="server"
				Width="152px" Text="Upgrade ReverseSetup" onclick="Button2_Click"></asp:Button>
			<asp:Button id="Button3" style="Z-INDEX: 103; LEFT: 72px; POSITION: absolute; TOP: 176px" runat="server"
				Width="152px" Text="Initialize RCT" onclick="Button3_Click"></asp:Button>
		</form>
	</body>
</HTML>
