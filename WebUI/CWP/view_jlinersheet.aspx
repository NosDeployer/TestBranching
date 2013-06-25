<%@ Page language="c#" Codebehind="view_jlinersheet.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.CWP.view_jlinersheet" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head runat="server">
		<title>LFS Combined Work Program</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="./../common/images/lfcss.css" type="text/css" rel="stylesheet"/>
	
</head>
	<body>
		<form method="post" runat="server">
			<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td>&nbsp;
					    <!-- .. Script Manager -->
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
					</td>
					
					<!-- PAGE -->
					<td valign="top" width="800">
						<div>
						
						    <!-- Page element: Header -->
							<table cellspacing="0" cellpadding="0" width="900px" border="0">
								<tr>
									<td width="700" background="./../common/images/im_header1.gif" height="50">&nbsp;</TD>
									<td width="100" background="./../common/images/im_header2.gif" height="50"></td>
									<td style="width:100px; height:50px" background="./../common/images/im_header3.gif" >
										<table height="50" cellspacing="0" cellpadding="0" width="100" border="0">
											<tr>
												<td width="85" height="4"></td>
												<td width="15" rowSpan="3"></td>
											</tr>
											<tr>
												<td align="right" width="85" height="23"><asp:linkbutton id="lkbtnSignOut" tabIndex="100" runat="server" CssClass="tMainLink" CausesValidation="False" onclick="lkbtnSignOut_Click">Sign out</asp:linkbutton></TD>
											</tr>
											<tr>
												<td align="right" width="85" height="23"><asp:linkbutton id="lkbtnMenu" tabIndex="100" runat="server" CssClass="tMainLinkOrange" CausesValidation="False" onclick="lkbtnMenu_Click">Menu</asp:linkbutton></TD>
											</tr>
										</table>
									</td>
								</tr>
							</table> 
							
							<!-- Page element: Header buttons -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD style="WIDTH: 718px" width="718" background="./../common/images/im_header4.gif" height="28">&nbsp;</TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header5.gif" height="28"><asp:button id="btnOK1" tabIndex="47" runat="server" CssClass="tButtonOkCancel" Height="22px"
											Width="90px" EnableViewState="False" Text="OK" onclick="btnOK_Click"></asp:button></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_header6.gif" height="28"><asp:button id="btnCancel1" tabIndex="48" runat="server" CssClass="tButtonOkCancel" CausesValidation="False"
											Height="22px" Width="90px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
								</TR>
							</TABLE>							
							<br/>
							
							 <!-- Page element: Title with horizontal rule -->
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<DIV class="tTitle" style="WIDTH: 496px; POSITION: relative; HEIGHT: 19px" >Junction 
											Liner&nbsp;Sheet</DIV>
									</TD>
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
							</TABLE> <!-- Page element: 6Columns -->
							
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR height="5">
									<TD width="17%" height="5"></TD>
									<TD width="17%" height="5"></TD>
									<TD width="17%" height="5"></TD>
									<TD style="WIDTH: 122px" width="122" height="5"></TD>
									<TD style="WIDTH: 147px" width="147" height="5"></TD>
									<TD width="16%" height="5"></TD>
								</TR>
								<TR height="16">
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >ID#</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 14px" >Client</DIV>
									</TD>
									<TD style="HEIGHT: 7px" width="17%"></TD>
									<TD style="WIDTH: 122px; HEIGHT: 7px" width="122"></TD>
									<TD style="WIDTH: 147px; HEIGHT: 7px" width="147"></TD>
									<TD style="HEIGHT: 7px" width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxRecordID tabIndex=1 runat="server" CssClass="tTextField" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].RecordID") %>' ReadOnly="True">
										</asp:textbox><asp:textbox id=tbxID tabIndex=200 runat="server" Width="0px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ID") %>' ReadOnly="True">
										</asp:textbox></TD>
									<TD width="17%" colSpan="2"><asp:textbox id="tbxCOMPANIES_ID" tabIndex="2" runat="server" CssClass="tTextField" Width="255px"
											ReadOnly="True"></asp:textbox></TD>
									<TD style="WIDTH: 122px" width="122"></TD>
									<TD style="WIDTH: 147px" width="147"><asp:checkbox id=cbxIssueIdentified tabIndex=8 runat="server" CssClass="tLabel" Width="120px" Text="Issue Identified?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueIdentified") %>'>
										</asp:checkbox></TD>
									<TD width="16%"><asp:checkbox id=cbxLFSIssue tabIndex=9 runat="server" CssClass="tLabel" Width="88px" Text="LFS Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].LFSIssue") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR height="3">
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="17%" height="3">&nbsp;</TD>
									<TD width="17%" height="3">&nbsp;</TD>
									<TD style="WIDTH: 122px" width="122" height="3">&nbsp;</TD>
									<TD style="WIDTH: 147px" width="147" height="3">&nbsp;</TD>
									<TD width="16%" height="3"><asp:checkbox id=cbxClientIssue tabIndex=10 runat="server" CssClass="tLabel" Width="112px" Text="Client Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ClientIssue") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR height="16">
									<TD style="HEIGHT: 13px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >Street</DIV>
									</TD>
									<TD style="HEIGHT: 13px" width="17%"></TD>
									<TD style="HEIGHT: 13px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 6px" >USMH</DIV>
									</TD>
									<TD style="WIDTH: 122px; HEIGHT: 13px" width="122"><DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >DSMH</DIV>
									</TD>
									<TD style="WIDTH: 147px; HEIGHT: 13px" width="147"></TD>
									<TD style="HEIGHT: 13px" width="16%"><asp:checkbox id=cbxSalesIssue tabIndex=11 runat="server" CssClass="tLabel" Width="104px" Text="Sales Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].SalesIssue") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2"><asp:textbox id=tbxStreet tabIndex=3 runat="server" CssClass="tTextField" Width="261px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Street") %>'>
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxUSMH tabIndex=4 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMH") %>'>
										</asp:textbox></TD>
									<TD style="WIDTH: 122px" width="122"><asp:textbox id=tbxDSMH tabIndex=5 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMH") %>'>
										</asp:textbox></TD>
									<TD style="WIDTH: 147px" width="147"></TD>
									<TD width="16%"><asp:checkbox id=cbxInvestigationIssue tabIndex=12 runat="server" CssClass="tLabel" Width="136px" Text="Investigation Issue?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].InvestigationIssue") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR height="16">
									<TD style="HEIGHT: 5px" width="17%"></TD>
									<TD style="HEIGHT: 5px" width="17%"></TD>
									<TD style="HEIGHT: 5px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >USMH 
											MN#</DIV>
									</TD>
									<TD style="WIDTH: 122px; HEIGHT: 5px" width="122"><DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 2px" >DSMH 
											MN#</DIV>
									</TD>
									<TD style="WIDTH: 147px; HEIGHT: 5px" width="147"></TD>
									<TD style="HEIGHT: 5px" width="16%"><asp:checkbox id=cbxIssueGivenToBayCity tabIndex=13 runat="server" CssClass="tLabel" Width="152px" Text="Issue Given To Client?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueGivenToBayCity") %>'>
										</asp:checkbox></TD>
								</TR>
								<TR>
									<TD width="17%" colSpan="2"></TD>
									<TD width="17%"><asp:textbox id=tbxUSMHMN tabIndex=6 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].USMHMN") %>'>
										</asp:textbox></TD>
									<TD style="WIDTH: 122px" width="122"><asp:textbox id=tbxDSMHMN tabIndex=7 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].DSMHMN") %>'>
										</asp:textbox></TD>
									<TD style="WIDTH: 147px" width="147"></TD>
									<TD width="16%"><asp:checkbox id=cbxIssueResolved tabIndex=14 runat="server" CssClass="tLabel" Width="120px" Text="Issue Resolved?" Checked='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].IssueResolved") %>'>
										</asp:checkbox></TD>
								</TR>
							</TABLE>
							<br/> 
							<!-- Data element: Horizontal rule -->
							<table cellSpacing="0" cellPadding="0" width="900" border="0">
								<tr>
									<td>
										<hr width="100%" color="#c8dbed" SIZE="2"/>
									</td>
								</tr>
							</table> 
							
							<!-- Page element: 6Columns -->
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr height="16">
									<td style="HEIGHT: 16px" width="17%">
										<div class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 16px" >Map 
											Size</div>
									</td>
									<td style="HEIGHT: 16px" width="17%">
										<div class="tLabel" style="DISPLAY: inline; WIDTH: 146px; HEIGHT: 16px" >Confirmed 
											Size</div>
									</td>
									<td style="HEIGHT: 16px" width="17%">
										<div class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 16px" >Scaled 
											Length</div>
									</td>
									<td style="HEIGHT: 16px" width="16%">
										<div class="tLabel" style="DISPLAY: inline; WIDTH: 114px; HEIGHT: 16px" >Actual 
											Length</div>
									</TD>
									<TD style="HEIGHT: 16px" width="17%"></TD>
									<TD style="HEIGHT: 16px" width="16%"></TD>
								</TR>
								<TR>
									<TD width="17%"><asp:textbox id=tbxSize_ tabIndex=15 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Size_") %>'>
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxConfirmedSize tabIndex=16 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ConfirmedSize") %>'>
										</asp:textbox></TD>
									<TD width="17%"><asp:textbox id=tbxScaledLength tabIndex=17 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ScaledLength") %>'>
										</asp:textbox></TD>
									<TD width="16%"><asp:textbox id=tbxActualLength tabIndex=18 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].ActualLength") %>'>
										</asp:textbox></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"></TD>
									<TD width="17%"><asp:regularexpressionvalidator id="revConfirmedSize" runat="server" EnableViewState="False" ValidationExpression="\d*"
											Font-Size="Smaller" ErrorMessage="Invalid data" ControlToValidate="tbxConfirmedSize" Display="Dynamic"></asp:regularexpressionvalidator></TD>
									<TD width="17%">
										<asp:customvalidator id="cvScaledLength" runat="server" Width="80px" Display="Dynamic" ControlToValidate="tbxScaledLength"
											ErrorMessage="Invalid data" Font-Size="Smaller"></asp:customvalidator></TD>
									<TD width="16%"><asp:customvalidator id="cvActualLength" runat="server" Width="100px" Font-Size="Smaller" 
											ControlToValidate="tbxActualLength" Display="Dynamic" ValidateEmptyText="True"></asp:customvalidator></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
								<TR height="16">
									<TD style="HEIGHT: 16px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 139px; HEIGHT: 16px" >Main 
											Lined</DIV>
									</TD>
									<TD style="HEIGHT: 16px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 100px; HEIGHT: 16px" >P1 
											Date</DIV>
									</TD>
									<TD style="HEIGHT: 16px" width="17%">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 114px; HEIGHT: 16px" >Benching 
											Issue</DIV>
									</TD>
									<TD style="HEIGHT: 16px" width="16%"></TD>
									<TD style="HEIGHT: 16px" width="17%"></TD>
									<TD style="HEIGHT: 16px" width="16%"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 17px" width="17%"><asp:dropdownlist id="ddlMainLined" tabIndex="19" runat="server" CssClass="tTextFieldCenter" Width="100px">
											<asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="No">No</asp:ListItem>
											<asp:ListItem></asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="HEIGHT: 17px" width="17%"><asp:textbox id=tbxP1Date tabIndex=20 runat="server" CssClass="tTextFieldCenter" Width="100px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].P1Date", "{0:d}") %>'>
										</asp:textbox></TD>
									<TD style="HEIGHT: 17px" width="17%"><asp:dropdownlist id="ddlBenchingIssue" tabIndex="21" runat="server" CssClass="tTextFieldCenter" Width="100px">
											<asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="No">No</asp:ListItem>
											<asp:ListItem></asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="HEIGHT: 17px" width="16%"></TD>
									<TD style="HEIGHT: 17px" width="17%"></TD>
									<TD style="HEIGHT: 17px" width="16%"></TD>
								</TR>
								<TR vAlign="top">
									<TD width="17%"></TD>
									<TD width="17%"><asp:customvalidator id="cvP1Date" runat="server" EnableViewState="False" Font-Size="Smaller" ErrorMessage="Invalid date"
											ControlToValidate="tbxP1Date" Display="Dynamic"></asp:customvalidator></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
									<TD width="17%"></TD>
									<TD width="16%"></TD>
								</TR>
							</TABLE> 
							
							<!-- Page element: Custom -->
							<table cellspacing="0" cellpadding="0" width="900px" border="0">
								<tr>
									<td height="16">
										<div class="tLabel" style="DISPLAY: inline; WIDTH: 248px; HEIGHT: 16px" >Bypass 
											/ Benching / Traffic Comments</div>
									</td>
								</tr>
								<tr>
									<td><asp:textbox id="tbxTrafficControlDetails" tabIndex="22" runat="server" CssClass="tTextField" Height="85px" Width="890px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].TrafficControlDetails") %>' TextMode="MultiLine">
										</asp:textbox></td>
								</tr>
							</table> 
							
							<!-- Page element: Custom -->
							<TABLE cellSpacing="0" cellPadding="0" width="900" border="0">
								<TR>
									<TD height="16">
										<DIV class="tLabel" style="DISPLAY: inline; WIDTH: 78px; HEIGHT: 16px" >Comments</DIV>
									</TD>
								</TR>
								<TR>
									<TD><asp:textbox id="tbxComments" tabIndex=23 runat="server" CssClass="tTextField" Height="85px" Width="890px" Text='<%# DataBinder.Eval(tdsLfsRecord, "Tables[LFS_MASTER_AREA].DefaultView.[0].Comments") %>' TextMode="MultiLine">
										</asp:textbox></TD>
								</TR>
							</TABLE>
							<br/> 
							
							<!-- Data element: Horizontal rule -->
							<table cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td>
										<hr width="100%" color="#c8dbed" size="2" id="HR1" language="javascript" onclick="return HR1_onclick()" />
									</td>
								</tr>
							</table> 
							
							<!-- Data element: Grid -->
							<table cellspacing="0" cellpadding="0" width="900px" border="0">
							    <tr>
							        <td>
							            <asp:UpdatePanel id="upnlJlinerSheet" runat="server">
                                            <contenttemplate>
                                                <asp:GridView ID="grdJlinerSheet" runat="server" SkinID="GridView" Width="890px"
                                                    PageSize="4" ShowFooter="True" AutoGenerateColumns="False" AllowPaging="True"
                                                    DataKeyNames="ID, RefID, COMPANY_ID" OnDataBound="grdJlinerSheet_DataBound" OnRowCommand="grdJlinerSheet_RowCommand"
                                                    OnRowDeleting="grdJlinerSheet_RowDeleting" OnRowUpdating="grdJlinerSheet_RowUpdating" OnRowDataBound="grdJlinerSheet_RowDataBound"
                                                    DataSourceID="odsJlinerSheet">
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="ID" Visible="False" HeaderText="ID">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField SortExpression="COMPANY_ID" Visible="False" HeaderText="COMPANY_ID">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblCOMPANY_ID" runat="server" Text='<%# Eval("COMPANY_ID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCOMPANY_ID" runat="server" Text='<%# Eval("COMPANY_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField  HeaderText="Juntion Liner Details">
                                                            <EditItemTemplate>
                                                                <!-- Page element : 2 columns - Notes Information -->
                                                                <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px">
                                                                            </td>
                                                                            <td style="width: 50px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 115px">
                                                                            </td>
                                                                            <td style="width: 115px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td rowspan="14" style="vertical-align: middle; text-align: center">
                                                                                <asp:Label ID="lblDetailIDEdit" runat="server" EnableViewState="False" SkinID="LabelPageTitle1" Text='<%# Eval("DetailID") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMnEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="MN#"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblDistanceFromUsmhEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Distance From USMH"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblConfirmedLatSizeEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Confirmed Lat Size"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLateralMaterialEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Lateral Material"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblSharedLateralEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Shared Lateral"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutRequiredEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Required"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblPitRequiredEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Pit Required"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMnEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                    Style="width: 100px" Text='<%# Eval("MN") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxDistanceFromUsmhEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                    Style="width: 100px" Text='<%# Eval("DistanceFromUSMH") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxConfirmedLatSizeEdit" runat="server" EnableViewState="False"
                                                                                    SkinID="TextBox" Style="width: 100px" Text='<%# Eval("ConfirmedLatSize") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxLateralMaterialEdit" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 100px" Text='<%# Eval("LateralMaterial") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlSharedLateralEdit" runat="server" SkinID="DropDownList" Style="width: 100px"
                                                                                    EnableViewState="False" >
                                                                                    <asp:ListItem Value=" "> </asp:ListItem>
                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="No">No</asp:ListItem>                                                                                    
                                                                                </asp:DropDownList>                                                                                
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutRequiredEdit" runat="server" Checked='<%# Eval("CleanoutRequired") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxPitRequiredEdit" runat="server" Checked='<%# Eval("PitRequired") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                        </tr>                                                                       
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CompareValidator ID="cvDistanceFromUsmhEdit" runat="server" ControlToValidate="tbxDistanceFromUsmhEdit"
                                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator></td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblMhShotEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="MH Shot"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMainConnectionEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Main Connection"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblTransitionEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Transition?"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutInstalledEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblPitInstalledEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Pit Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutGroutedEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Grouted"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutCoredEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Cleanout Cored"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxMhShotEdit" runat="server" Checked='<%# Eval("MHShot") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlMainConnectionEdit" runat="server" SkinID="DropDownList" Style="width: 100px"
                                                                                    EnableViewState="False" >
                                                                                    <asp:ListItem Value=" "> </asp:ListItem>
                                                                                    <asp:ListItem Value="Tee">Tee</asp:ListItem>
                                                                                    <asp:ListItem Value="Wye">Wye</asp:ListItem>                                                                                    
                                                                                </asp:DropDownList>  
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlTransitionEdit" runat="server" SkinID="DropDownList" Style="width: 100px"
                                                                                    EnableViewState="False" >
                                                                                    <asp:ListItem Value=" "> </asp:ListItem>
                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="No">No</asp:ListItem>                                                                                    
                                                                                </asp:DropDownList>                                                                                 
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutInstalledEdit" runat="server" Checked='<%# Eval("CleanoutInstalled") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxPitInstalledEdit" runat="server" Checked='<%# Eval("PitInstalled") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutGroutedEdit" runat="server" Checked='<%# Eval("CleanoutGrouted") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutCoredEdit" runat="server" Checked='<%# Eval("CleanoutCored") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPrepCompletedEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Prep Completed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMeasuredLatLengthEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Measured Lat Length"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMeasurementsTakenByEdit" runat="server" EnableViewState="False"
                                                                                    SkinID="LabelSmall" Text="Measurements Taken By"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerInstalledEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblFinalVideoEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Final Video"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblRestorationCompleteEdit" runat="server" EnableViewState="False"
                                                                                    SkinID="LabelSmall" Text="Restoration Complete"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerOrderedEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Cored"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadDatePicker  ID="tkrdpPrepCompletedEdit" runat="server" Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                </telerik:RadDatePicker>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMeasuredLatLengthEdit" runat="server" EnableViewState="False"
                                                                                    SkinID="TextBox" Style="width: 100px" Text='<%# Eval("MeasuredLatLength") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMeasurementsTakenByEdit" runat="server" EnableViewState="False"
                                                                                    SkinID="TextBox" Style="width: 100px" Text='<%# Eval("MeasurementsTakenBy") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <telerik:RadDatePicker ID="tkrdpLinerInstalledEdit" runat="server" Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                </telerik:RadDatePicker>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadDatePicker ID="tkrdpFinalVideoEdit" runat="server" Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                </telerik:RadDatePicker>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxRestorationCompleteEdit" runat="server" Checked='<%# Eval("RestorationComplete") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxLinerOrderedEdit" runat="server" Checked='<%# Eval("LinerOrdered") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerInStockEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner In Stock"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerPriceEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner Price"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCommentsEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Comments"></asp:Label></td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td style="vertical-align: top">
                                                                                <asp:CheckBox ID="ckbxLinerInStockEdit" runat="server" Checked='<%# Eval("LinerInStock") %>'
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td style="vertical-align: top;">
                                                                                <asp:TextBox ID="tbxLinerPriceEdit" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                    Style="width: 100px" Text='<%# Eval("LinerPrice","{0:n2}") %>'></asp:TextBox></td>
                                                                            <td colspan="5">
                                                                                <asp:TextBox ID="tbxCommentEdit" runat="server" Rows="4" SkinID="TextBox" Style="width: 550px"
                                                                                    Text='<%# Eval("Comments") %>' TextMode="MultiLine"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CompareValidator ID="cvPriceEdit" runat="server" ControlToValidate="tbxLinerPriceEdit"
                                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="dataEdit"></asp:CompareValidator></td>
                                                                            <td colspan="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 10px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <!-- Page element : 2 columns - Notes Information -->
                                                                <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px">
                                                                            </td>
                                                                            <td style="width: 50px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 115px">
                                                                            </td>
                                                                            <td style="width: 115px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td rowspan="14">
                                                                                </td>
                                                                            <td>
                                                                                <asp:Label ID="lblMnFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="MN#"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblDistanceFromUsmhFooter" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Distance From USMH"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblConfirmedLatSizeFooter" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Confirmed Lat Size"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLateralMaterialFooter" runat="server" EnableViewState="False"
                                                                                    SkinID="Label" Text="Lateral Material"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblSharedLateralFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Shared Lateral"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutRequiredFooter" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Required"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblPitRequiredFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Pit Required"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMnFooter" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                    Style="width: 100px"></asp:TextBox></td>
                                                                            <td colspan="1">
                                                                                <asp:TextBox ID="tbxDistanceFromUsmhFooter" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                    Style="width: 100px" ></asp:TextBox></td>
                                                                            <td colspan="1">
                                                                                <asp:TextBox ID="tbxConfirmedLatSizeFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 100px" ></asp:TextBox></td>
                                                                            <td colspan="1">
                                                                                <asp:TextBox ID="tbxLateralMaterialFooter" runat="server" EnableViewState="False" SkinID="TextBox" Style="width: 100px" ></asp:TextBox></td>
                                                                            <td colspan="1">
                                                                                <asp:DropDownList ID="ddlSharedLateralFooter" runat="server" SkinID="DropDownList" Style="width: 100px"
                                                                                    EnableViewState="False" >
                                                                                    <asp:ListItem Value=" " Selected="True"> </asp:ListItem>
                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="No">No</asp:ListItem>                                                                                    
                                                                                </asp:DropDownList>
                                                                            </td>                                                                               
                                                                            <td colspan="1">
                                                                                <asp:CheckBox ID="ckbxCleanoutRequiredFooter" runat="server" SkinID="CheckBox" /></td>
                                                                            <td colspan="1">
                                                                                <asp:CheckBox ID="ckbxPitRequiredFooter" runat="server" SkinID="CheckBox" /></td>
                                                                        </tr>                                                                        
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td colspan="1">
                                                                                <asp:CompareValidator ID="cvDistanceFromUsmhFooter" runat="server" ControlToValidate="tbxDistanceFromUsmhFooter"
                                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator></td>
                                                                            <td colspan="1">
                                                                            </td>
                                                                            <td colspan="1">
                                                                            </td>
                                                                            <td colspan="1">
                                                                            </td>
                                                                            <td colspan="1">
                                                                            </td>
                                                                            <td colspan="1">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblMhShotFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="MH Shot"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMainConnectionFooter" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Main Connection"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblTransitionFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Transition?"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutInstalledFooter" runat="server" EnableViewState="False"
                                                                                    SkinID="LabelSmall" Text="Cleanout Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblPitInstalledFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Pit Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutGroutedFooter" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Grouted"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblClenoutCoredFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Cleanout Cored"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxMhShotFooter" runat="server" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlMainConnectionFooter" runat="server" SkinID="DropDownList" Style="width: 100px"
                                                                                    EnableViewState="False" >
                                                                                    <asp:ListItem Value=" " Selected="True"> </asp:ListItem>
                                                                                    <asp:ListItem Value="Tee">Tee</asp:ListItem>
                                                                                    <asp:ListItem Value="Wye">Wye</asp:ListItem>                                                                                    
                                                                                </asp:DropDownList>                                                                                
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlTransitionFooter" runat="server" SkinID="DropDownList" Style="width: 100px"
                                                                                    EnableViewState="False" >
                                                                                    <asp:ListItem Value=" " Selected="True"> </asp:ListItem>
                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="No">No</asp:ListItem>                                                                                    
                                                                                </asp:DropDownList>                                                                                 
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutInstalledFooter" runat="server" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxPitInstalledFooter" runat="server" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutGroutedFooter" runat="server" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutCoredFooter" runat="server" SkinID="CheckBox" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPrepCompletedFooter" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Prep Completed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMeasuredLatLengthFooter" runat="server" EnableViewState="False"
                                                                                    SkinID="LabelSmall" Text="Measured Lat Length"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMeasurementsTakenByFooter" runat="server" EnableViewState="False"
                                                                                    SkinID="LabelSmall" Text="Measurements Taken By"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerInstalledFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblFinalVideoFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Final Video"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblRestorationCompleteFooter" runat="server" EnableViewState="False"
                                                                                    SkinID="LabelSmall" Text="Restoration Complete"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerOrdered" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner Ordered"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadDatePicker ID="tkrdpPrepCompletedFooter" runat="server" Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                </telerik:RadDatePicker>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMeasuredLatLengthFooter" runat="server" EnableViewState="False"
                                                                                    SkinID="TextBox" Style="width: 100px"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMeasurementsTakenByFooter" runat="server" EnableViewState="False"
                                                                                    SkinID="TextBox" Style="width: 100px"></asp:TextBox></td>
                                                                            <td>
                                                                                <telerik:RadDatePicker ID="tkrdpLinerInstalledFooter" runat="server" Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                </telerik:RadDatePicker>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadDatePicker ID="tkrdpFinalVideoFooter" runat="server" Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                </telerik:RadDatePicker>
                                                                            </td>
                                                                            <td><asp:CheckBox ID="ckbxRestorationCompleteFooter" runat="server" SkinID="CheckBox" /></td>
                                                                            <td><asp:CheckBox ID="ckbxLinerOrderedFooter" runat="server" SkinID="CheckBox" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerInStockFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner In Stock"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerPriceFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner Price"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCommentsFooter" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Comments"></asp:Label></td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td style="vertical-align: top">
                                                                                <asp:CheckBox ID="ckbxLinerInStockFooter" runat="server" SkinID="CheckBox" /></td>
                                                                            <td style="vertical-align: top;">
                                                                                <asp:TextBox ID="tbxLinerPriceFooter" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                    Style="width: 100px"></asp:TextBox></td>
                                                                            <td colspan="5">
                                                                                <asp:TextBox ID="tbxCommentFooter" runat="server" Rows="1" SkinID="TextBox" Style="width: 550px"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CompareValidator ID="cvPriceFooter" runat="server" ControlToValidate="tbxLinerPriceFooter"
                                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="dataFooter"></asp:CompareValidator></td>
                                                                            <td colspan="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 10px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="840px"></HeaderStyle>
                                                            <ItemTemplate>                                                    
                                                                <table style="width: 840px" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px">
                                                                            </td>
                                                                            <td style="width: 50px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 110px">
                                                                            </td>
                                                                            <td style="width: 115px">
                                                                            </td>
                                                                            <td style="width: 115px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td rowspan="12" style="vertical-align: middle; text-align: center">
                                                                                <asp:Label ID="lblDetailID" runat="server" EnableViewState="False" SkinID="LabelPageTitle1" Text='<%# Eval("DetailID") %>'></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMn" runat="server" SkinID="Label" Text="MN#" EnableViewState="False"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblDistanceFromUsmh" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Distance From USMH"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblConfirmedLatSize" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Confirmed Lat Size"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLateralMaterial" runat="server" EnableViewState="False" SkinID="Label" Text="Lateral Material"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblSharedLateral" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Shared Lateral"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutRequired" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Required"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblPitRequired" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Pit Required"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td >
                                                                            </td>
                                                                            <td colspan="1" >
                                                                                <asp:TextBox ID="tbxMn" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                                                    Style="width: 100px" Text='<%# Eval("MN") %>'></asp:TextBox></td>
                                                                            <td colspan="1" >
                                                                                <asp:TextBox ID="tbxDistanceFromUsmh" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("DistanceFromUSMH") %>'></asp:TextBox></td>
                                                                            <td colspan="1" >
                                                                                <asp:TextBox ID="tbxConfirmedLatSize" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("ConfirmedLatSize") %>'></asp:TextBox></td>
                                                                            <td colspan="1" >
                                                                                <asp:TextBox ID="tbxLateralMaterial" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("LateralMaterial") %>'></asp:TextBox></td>
                                                                            <td colspan="1">
                                                                                <asp:TextBox ID="tbxSharedLateral" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("SharedLateral") %>'></asp:TextBox></td>
                                                                            <td colspan="1" >
                                                                                <asp:CheckBox ID="ckbxCleanoutRequired" runat="server" Checked='<%# Eval("CleanoutRequired") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                            <td colspan="1" >
                                                                                <asp:CheckBox ID="ckbxPitRequired" runat="server" Checked='<%# Eval("PitRequired") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblMhShot" runat="server" EnableViewState="False" SkinID="Label" Text="MH Shot"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMainConnection" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Main Connection"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblTransition" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Transition?"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutInstalled" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblPitInstalled" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Pit Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutGrouted" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Cleanout Grouted"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblCleanoutCored" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Cleanout Cored"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxMhShot" runat="server" Checked='<%# Eval("MHShot") %>' onclick="return cbxClick();"
                                                                                    SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMainConnection" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("MainConnection") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxTransition" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("Transition") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutInstalled" runat="server" Checked='<%# Eval("CleanoutInstalled") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxPitInstalled" runat="server" Checked='<%# Eval("PitInstalled") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutGrouted" runat="server" Checked='<%# Eval("CleanoutGrouted") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxCleanoutCored" runat="server" Checked='<%# Eval("CleanoutCored") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPrepCompletedEdit" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Prep Completed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMeasuredLatLength" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Measured Lat Length"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblMeasurementsTakenBy" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                                                    Text="Measurements Taken By"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerInstalled" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner Installed"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblFinalVideo" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Final Video"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblRestorationComplete" runat="server" EnableViewState="False"
                                                                                    SkinID="LabelSmall" Text="Restoration Complete"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerOrdered" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Cleanout Cored"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPrepCompleted" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("PrepCompleted", "{0:d}") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMeasuredLatLength" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("MeasuredLatLength") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxMeasurementsTakenBy" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("MeasurementsTakenBy") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxLinerInstalled" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("LinerInstalled", "{0:d}") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxFinalVideo" runat="server" EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("FinalVideo", "{0:d}") %>'></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxRestorationComplete" runat="server" Checked='<%# Eval("RestorationComplete") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ckbxLinerOrdered" runat="server" Checked='<%# Eval("LinerOrdered") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 7px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerInStock" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner In Stock"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblLinerPrice" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Liner Price"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments"
                                                                                    EnableViewState="False"></asp:Label></td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td style="vertical-align: top">
                                                                                <asp:CheckBox ID="ckbxLinerInStock" runat="server" Checked='<%# Eval("LinerInStock") %>'
                                                                                    onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                                            <td style="vertical-align: top;">
                                                                                <asp:TextBox ID="tbxLinerPrice" runat="server"  EnableViewState="False" ReadOnly="True"
                                                                                    SkinID="TextBoxReadOnly" Style="width: 100px" Text='<%# Eval("LinerPrice","{0:n2}") %>'></asp:TextBox></td>
                                                                            <td colspan="5">
                                                                                <asp:TextBox Style="width: 550px" ID="tbxComment" runat="server" SkinID="TextBoxReadOnly"
                                                                                    Text='<%# Eval("Comments") %>' Rows="4" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 10px">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 50%">
                                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update"
                                                                                    ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.gif"></asp:ImageButton>
                                                                            </td>
                                                                            <td style="width: 50%">
                                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"
                                                                                    ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.gif"></asp:ImageButton>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="height: 12px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add"
                                                                                    ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.gif"></asp:ImageButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 50%">
                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                                                    ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.gif"></asp:ImageButton>
                                                                            </td>
                                                                            <td style="width: 50%">
                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                    OnClientClick='return confirm("Are you sure you want to delete this Juntion Liner?");'
                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.gif"></asp:ImageButton>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                           </contenttemplate>
                                        </asp:UpdatePanel>
							        </td>
							    </tr>
							    <tr>
                                    <td>
                                        <asp:Label ID="lblMaxNumber" runat="server" SkinID="LabelError" Text="The maximum amount was reached, no more junction liners can be added."></asp:Label>
                                    </td>                                    
                                </tr>								
							</table>
							<br/>
							<br/>
							<!-- Page element: Footer buttons -->
							<table height="28" cellspacing="0" cellpadding="0" width="900" border="0">
								<tr>
									<td vAlign="middle" width="700" background="./../common/images/im_footer1.gif" height="28">
										<table cellSpacing="0" cellPadding="0" width="700" border="0">
											<tr>
												<td width="10"></td>
												<td align="center" width="50"><asp:button id="btnPrevious" tabIndex="100" runat="server" CssClass="tButtonPrevNext" Height="22px"
														Width="50px" EnableViewState="False" Text="Prev" Font-Bold="True" onclick="btnPrevious_Click"></asp:button></td>
												<td width="5"></td>
												<td align="center" width="50"><asp:button id="btnNext" tabIndex="100" runat="server" CssClass="tButtonPrevNext" Height="22px"
														Width="50px" EnableViewState="False" Text="Next" onclick="btnNext_Click"></asp:button></td>
												<td width="25"></td>
												<td align="center" width="90"><asp:button id="btnDelete" tabIndex="100" runat="server" CssClass="tButtonDelete" CausesValidation="False"
														Height="22px" Width="90px" Text="Delete" onclick="btnDelete_Click"></asp:button></td>
												<td width="25"></td>
												<td width="445"><asp:validationsummary id="vsFooter" runat="server" Width="445px" EnableViewState="False" Font-Size="Smaller"
														BackColor="#C8DBED" HeaderText="VALIDATION ISSUES. Please review the form."></asp:validationsummary></td>
											</tr>
										</table>
									</td>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer2.gif" height="28"><asp:button id="btnOK" tabIndex="45" runat="server" CssClass="tButtonOkCancel" Height="22px"
											Width="90px" EnableViewState="False" Text="OK" onclick="btnOK_Click"></asp:button></TD>
									<TD vAlign="middle" align="left" width="100" background="./../common/images/im_footer3.gif" height="28"><asp:button id="btnCancel" tabIndex="46" runat="server" CssClass="tButtonOkCancel" CausesValidation="False"
											Height="22px" Width="90px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
								</tr>
								<tr>
									<TD></TD>
									<TD style="WIDTH: 187px" colspan="2"></TD>
								</TR>
							</table>
							<br/>
						</div>
					</td>
					<!-- ENDPAGE -->
					<td>&nbsp;</td>
				</tr>
			</table>		            
            
            <!-- Page element: Data objects -->
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:ObjectDataSource ID="odsLfsMainConnections" runat="server" SelectMethod="GetLFSMainConnectionForDropDownList"
                            TypeName="LiquiForce.LFSLive.CWP.DatabaseGateway.LFSMainConnectionGateway">
                            <SelectParameters>
                                <asp:Parameter Name="mainConnectionItem" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsJlinerSheet" runat="server" 
                         SelectMethod="GetJlinerNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.view_jlinersheet" 
                         DeleteMethod="DummyJlinerNew" FilterExpression="(Deleted = 0) AND (Archived = 0)" 
                         UpdateMethod="DummyJlinerNew">
                            <DeleteParameters>
                                <asp:Parameter Name="ID"/>  
                                <asp:Parameter Name="RefID" Type="Int32" />                            
                                <asp:Parameter Name="COMPANY_ID" Type="Int32" /> 
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ID"  />  
                                <asp:Parameter Name="RefID" Type="Int32" />  
                                <asp:Parameter Name="COMPANY_ID" Type="Int32" /> 
                            </UpdateParameters>
                        </asp:ObjectDataSource>
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
		</form>
	</body>
</html>
