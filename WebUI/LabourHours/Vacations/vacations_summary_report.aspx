<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mReport1.Master" AutoEventWireup="true" CodeBehind="vacations_summary_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Vacations.vacations_summary_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblLocation" runat="server" SkinID="Label" Text="Working Location" EnableViewState="False"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLocation" runat="server" SkinID="DropDownList"
                        Width="160px">
                        <asp:ListItem Value="(All)" Text="(All)"></asp:ListItem>
                        <asp:ListItem Value="CA" Text="LFS Canada"></asp:ListItem>
                        <asp:ListItem Value="US" Text="LFS USA"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>           
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmployee" runat="server" SkinID="Label" Text="Team Member" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlEmployee" runat="server" SkinID="DropDownList" EnableViewState="false" Width="160px" DataSourceID="odsEmployee" 
                        DataTextField="FullName" DataValueField="EmployeeID">
                    </asp:DropDownList>
                </td>
            </tr>                         
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblYear" runat="server" SkinID="Label" Text="Year"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" SkinID="DropDownList" Width="160px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" SelectMethod="LoadBySalariedAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="salaried" Type="Int32" />
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
                
    </div>
</asp:Content>