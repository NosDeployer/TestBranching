<%@ Page Language="c#" Codebehind="login.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI.login"
    SmartNavigation="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>login</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body>
    <form method="post" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 380px">
                    <asp:Label ID="lblTitle" runat="server" Font-Size="22px" Font-Names="Microsoft Sans Serif">LFS Live - TEST SITE</asp:Label>
                </td>
                <td style="width: 429px">
                    &nbsp;</td>
                <td style="width: 429px; text-align: right;">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif">User name :</asp:Label></td>
                <td style="width: 429px">
                    <asp:TextBox ID="tbxUserName" runat="server" TabIndex="1" Font-Names="Microsoft Sans Serif"
                        Width="150px"></asp:TextBox></td>
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
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPassword" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif">Password :</asp:Label></td>
                <td>
                    <asp:TextBox ID="tbxPassword" runat="server" TabIndex="2" TextMode="Password" Font-Names="Microsoft Sans Serif"
                        Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td style="text-align: right">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" TabIndex="3" Width="64px" Text="Log in"
                        OnClick="btnLogin_Click" Font-Names="Microsoft Sans Serif"></asp:Button></td>
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
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWith" runat="server">with</asp:Label></td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblLoginResult" runat="server" Font-Size="Smaller" ForeColor="Red"></asp:Label></td>
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
            </tr>
        </table>
        
        <table border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 25%;">
                </td>
                <td style="width: 25%;">
                    <asp:Label ID="lblProject" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Projects</asp:Label>
                </td>
                <td style="width: 25%;">
                </td>
                <td style="width: 25%;">
                </td>
            </tr>
            <tr>
                <%--General Permissions--%>
                <td style="vertical-align: top">
                    <asp:Label ID="lblGeneralPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">General Permissions:</asp:Label><br />
                    <br />
                    <asp:CheckBox ID="cbxView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Admin" Font-Size="Smaller" />
                </td>
                <%--Project Permissions--%>
                <td style="vertical-align: top">
                    <asp:Label ID="lblProjectPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Project Permissions:</asp:Label>&nbsp;<br />
                    <br />
                    <asp:CheckBox ID="cbxProjectView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Projects View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Projects Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Projects Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Projects Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectAdmin" runat="server" Checked="true" Font-Names="Microsoft Sans Serif"
                        Text="Projects Admin" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectPromoteProposalToProject" runat="server" Checked="true" Font-Names="Microsoft Sans Serif" 
                        Text="Projects Promote Proposal To Project" Font-Size="Smaller" />
                </td>
                <%--Project Costing Sheet Permissions--%>
                <td style="vertical-align: top">
                    <asp:Label ID="lblProjectCostingSheetPermissions" runat="server" Font-Bold="True"
                        Font-Names="Microsoft Sans Serif" Font-Size="12px">Project Costing Sheet Permissions:</asp:Label>&nbsp;<br />
                    <br />
                    <asp:CheckBox ID="cbxCostingSheetView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Costing Sheet View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxCostingSheetAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Costing Sheet Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxCostingSheetEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Costing Sheet Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxCostingSheetDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Costing Sheet Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxCostingSheetAdmin" runat="server" Checked="true" Font-Names="Microsoft Sans Serif"
                        Text="Costing Sheet Admin" Font-Size="Smaller" />
                </td>         
                <td style="vertical-align: top">
                    <asp:Label ID="lblProjectRevenue" runat="server" Font-Bold="True"
                        Font-Names="Microsoft Sans Serif" Font-Size="12px">Project Revenue:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxProjectRevenueView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Revenue View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectRevenueAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Revenue Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectRevenueEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Revenue Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectRevenueDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Revenue Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxProjectRevenueAdmin" runat="server" Checked="true" Font-Names="Microsoft Sans Serif"
                        Text="Revenue Admin" Font-Size="Smaller" />
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
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblLabourHours" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Labour Hours</asp:Label>
                </td>
            </tr>
            <tr>
                <%--Labour Hours Permissions--%>
                <td style="vertical-align: top">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblLabourHoursMyPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                                    Font-Size="12px">Labour Hours My Permissions:</asp:Label>&nbsp;<br />
                                <br />
                                <asp:CheckBox ID="cbxLHFullEditing" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH Full Editing" Font-Size="Smaller" />
                                <br />
                                <asp:CheckBox ID="cbxLHReports" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH Reports" Font-Size="Smaller" /><br />
                                <asp:CheckBox ID="cbxLHAutoReport" runat="server" Checked="false" Font-Names="Microsoft Sans Serif"
                                    Text="LH AutoReport" Font-Size="Smaller" />
                                <br />
                                <asp:CheckBox ID="cbxVacationHolidayFullEditing" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="Vacation/Holiday Full Editing" Font-Size="Smaller" /><br />
                                <br />
                            </td>
                            <td>
                                <br /><br />
                                <asp:CheckBox ID="cbxLHMTV" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH MT View" Font-Size="Smaller" />
                                <br />
                                <asp:CheckBox ID="cbxLHMTA" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH MT Add" Font-Size="Smaller" />
                                <br />
                                <asp:CheckBox ID="cbxLHMTE" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH MT Edit" Font-Size="Smaller" />
                                <br />
                                <asp:CheckBox ID="cbxLHMTD" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH MT Delete" Font-Size="Smaller" />
                                <br />
                                <asp:CheckBox ID="cbxLHMTM" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH MT Management" Font-Size="Smaller" />
                                <br />
                                <asp:CheckBox ID="cbxLHMTWM" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                                    Text="LH MT Wed Management" Font-Size="Smaller" />
                                <br />                                
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblLabourHoursOtherPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Labour Hours Other Permissions:</asp:Label><br />
                    <br />
                    <asp:CheckBox ID="cbxLHOTV" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="LH OT View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxLHOTA" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="LH OT Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxLHOTE" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="LH OT Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxLHOTD" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="LH OT Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxLHOTM" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="LH OT Management" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxLHOTWM" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="LH OT WeD Management" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblVacationsPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Vacations Permissions:</asp:Label><br />
                    <br />
                    <asp:CheckBox ID="cbxLHVacationsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Vacations View" Font-Size="Smaller" />
                    <br />
                    <%--<asp:CheckBox ID="cbxLHVacationsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Vacations Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxLHVacationsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Vacations Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxLHVacationsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Vacations Delete" Font-Size="Smaller" />
                    <br />--%>
                    <asp:CheckBox ID="cbxLHVacationsFullEditing" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Vacations Full Editing" Font-Size="Smaller" />
                    <br />                        
                    <asp:CheckBox ID="cbxLGVacationsReports" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Vacations Report" Font-Size="Smaller" />
                    <%--<br />
                    <asp:CheckBox ID="cbxLHVacationsAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Vacations Admin" Font-Size="Smaller" />--%>
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblActualCostsPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Actual Costs Permissions:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxActualCostsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Actual Costs View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxActualCostsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Actual Costs Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxActualCostsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Actual Costs Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxActualCostsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Actual Costs Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxActualCostsAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Actual Costs Admin" Font-Size="Smaller" />
                    <br />
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
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblFleetManagement" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Fleet Management</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Label ID="lblChecklistPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Checklist Permissions:</asp:Label><br />
                    <br />
                    <asp:CheckBox ID="cbxChecklistRulesAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Checklist Admin" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxChecklistRulesDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Checklist Delete" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxChecklistRulesEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Checklist Edit" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxChecklistRulesAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Checklist Add" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxChecklistRulesView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Checklist View" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblServicesPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Services Permissions:</asp:Label><br />
                    <br />
                    <asp:CheckBox ID="cbxServicesView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Services View" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxServicesAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Services Add" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxServicesEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Services Edit" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxServicesDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Services Delete" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxServicesAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Services Admin" Font-Size="Smaller" /><br />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblUnitsPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Units Permissions:</asp:Label><br />
                    <br />
                    <asp:CheckBox ID="cbxUnitsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units View" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxUnitsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Add" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxUnitsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Edit" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxUnitsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Delete" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxUnitsAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Admin" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxUnitsComments" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Comments" Font-Size="Smaller" /><br />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblToDoListPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">To Do List Permissions:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxToDoListView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="To Do List View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxToDoListAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="To Do List Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxToDoListEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="To Do List Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxToDoListDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="To Do List Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxToDoListAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="To Do List Admin" Font-Size="Smaller" />
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
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblESewers" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">eSewers</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                    <asp:Label ID="lblGerencialPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Gerencial Permissions:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxGerencialProductionReport" runat="server" Checked="false" Font-Names="Microsoft Sans Serif"
                        Text="Production Report " Font-Size="Smaller" />
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
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Label ID="lblRehabAssessmentPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Rehab Assessment Permissions:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxRAView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="RA View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxRAAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="RA Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxRAEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="RA Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxRADelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="RA Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxRAAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="RA Admin" Font-Size="Smaller" />
                    <br />
                </td>
                <td style="vertical-align: top">
                    &nbsp;<asp:Label ID="lblJunctionLiningiPermissions" runat="server" Font-Bold="True"
                        Font-Names="Microsoft Sans Serif" Font-Size="12px">Juntion Lining Permissions:</asp:Label>&nbsp;<br />
                    <br />
                    <asp:CheckBox ID="cbxJLView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="JL View" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxJLAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="JL Add" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxJLEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="JL Edit" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxJLDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="JL Delete" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxJLAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="JL Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblFullLengthLiningPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Full Length Lining Permissions:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxFLView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="FL View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxFLAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="FL Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxFLEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="FL Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxFLDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="FL Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxFLAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="FL Admin" Font-Size="Smaller" />
                    <br />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblPointRepairsPermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Point Repairs Permissions:</asp:Label><br />
                    <br />
                    <asp:CheckBox ID="cbxPointRepairsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="PR View" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxPointRepairsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="PR Add" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxPointRepairsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="PR Edit" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxPointRepairsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="PR Delete" Font-Size="Smaller" /><br />
                    <asp:CheckBox ID="cbxPointRepairsAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="PR Admin" Font-Size="Smaller" /><br />
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Label ID="lblManholePermissions" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Manhole Permissions:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxMRView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="MR View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMRAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="MR Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMREdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="MR Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMRDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="MR Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMRAdmin" runat="server" Checked="false" Font-Names="Microsoft Sans Serif"
                        Text="MR Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top">
                    &nbsp;</td>
                <td style="vertical-align: top">
                    &nbsp;</td>
                <td style="vertical-align: top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 7px;" colspan="4">                    
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top" colspan="4">
                    <asp:Label ID="lblResources" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Resources</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;" colspan="4">                    
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Label ID="lblEmployees" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Employees:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxEmployeeView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Employees View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxEmployeeAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Employees Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxEmployeeEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Employees Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxEmployeeDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Employees Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxEmployeeAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Employees Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblMaterials" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Materials:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxMaterialsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Materials View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMaterialsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Materials Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMaterialsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Materials Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMaterialsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Materials Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxMaterialsAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Materials Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblUnitsOfMeasurement" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Units Of Measurement:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxUnitsOfMeasurementView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Of Measurement View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxUnitsOfMeasurementAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Of Measurement Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxUnitsOfMeasurementEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Of Measurement Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxUnitsOfMeasurementDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Of Measurement Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxUnitsOfMeasurementAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Units Of Measurement Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top">
                    <asp:Label ID="lblSubcontractorsTitle" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Subcontractors:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxSubcontractorsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Subcontractors View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxSubcontractorsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Subcontractors Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxSubcontractorsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Subcontractors Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxSubcontractorsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Subcontractors Delete" Font-Size="Smaller" />
                </td>
            </tr>
            <tr>
                <td style="height: 7px;" colspan="4">                    
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">                    
                    <asp:Label ID="lblHotels" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Hotels:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxHotelsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Hotels View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxHotelsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Hotels Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxHotelsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Hotels Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxHotelsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Hotels Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxHotelsAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Hotels Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top;">                    
                    <asp:Label ID="lblInsuranceCompanies" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Insurance Companies:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxInsuranceCompaniesView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Insurance Companies View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxInsuranceCompaniesAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Insurance Companies Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxInsuranceCompaniesEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Insurance Companies Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxInsuranceCompaniesDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Insurance Companies Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxInsuranceCompaniesAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Insurance Companies Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top;">                    
                    <asp:Label ID="lblBondingCompanies" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Bonding Companies:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxBondingCompaniesView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Bonding Companies View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxBondingCompaniesAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Bonding Companies Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxBondingCompaniesEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Bonding Companies Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxBondingCompaniesDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Bonding Companies Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxBondingCompaniesAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Bonding Companies Admin" Font-Size="Smaller" />
                </td>
                <td style="vertical-align: top;">                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 7px;" colspan="4">                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">                    
                    <asp:Label ID="lblViews" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Views</asp:Label>
                </td>
                <td colspan="2">                    
                    <asp:Label ID="lblITTechSupportTicket" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">IT Tech Support Tickets:</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">                    
                    <asp:Label ID="lblViewsTitle" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Views:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxGlobalViewsView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Global Views View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxGlobalViewsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Global Views Add" Font-Size="Smaller"  />
                    <br />
                    <asp:CheckBox ID="cbxGlobalViewsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Global Views Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxGlobalViewsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Global Views Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxViewsAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Views Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxViewsEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Views Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxViewsDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Views Delete" Font-Size="Smaller" />
                </td>
                <td colspan="2">                    
                    <asp:Label ID="lblSupportTickets" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif"
                        Font-Size="12px">Support Tickets:</asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxSupportTicketView" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Support Ticket View" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxSupportTicketAdd" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Support Ticket Add" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxSupportTicketEdit" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Support Ticket Edit" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxSupportTicketDelete" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Support Ticket Delete" Font-Size="Smaller" />
                    <br />
                    <asp:CheckBox ID="cbxSupportTicketAdmin" runat="server" Checked="True" Font-Names="Microsoft Sans Serif"
                        Text="Support Ticket Admin" Font-Size="Smaller" />
                </td>
            </tr>
            <tr>
                <td style="height: 7px;" colspan="4">                    
                    &nbsp;</td>
            </tr>
        </table>
  
    </form>
    <!--- Inline scripts --->

    <script>window.document.all["tbxUserName"].focus()</script>

</body>
</html>
