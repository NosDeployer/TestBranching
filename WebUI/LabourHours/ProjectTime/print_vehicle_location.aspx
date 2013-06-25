<%@ Page Language="C#" MasterPageFile="./../../mReport1.master" AutoEventWireup="true" CodeBehind="print_vehicle_location.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.print_vehicle_location" Title="LFS Live"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblCountry" runat="server" Text="Select Country" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="160px" SkinID="DropDownList">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="1">Canada</asp:ListItem>
                        <asp:ListItem Value="2">USA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>            
            <tr>
                <td>
                    <asp:Label ID="lblUnit" runat="server" SkinID="Label" Text="Select Unit" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="UnitCode"
                        DataValueField="UnitID" SkinID="DropDownList" Width="160px" EnableViewState="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProjectTimeState" runat="server" SkinID="Label" Text="Select Project Time State" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlProjectTimeState" runat="server" SkinID="DropDownList" Width="160px" EnableViewState="False">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="Unapproved">For Approval</asp:ListItem>
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="False"></asp:Label>
                </td>
            </tr>      
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
             <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
        </table>
        
        
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>                    
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                </td>
            </tr>
        </table>
        
        
        
        <!-- Page element: Data objects-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="(All)" Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="isWithUnitCode" Type="Boolean" />
                            <asp:Parameter DefaultValue="0" Name="isTowable" Type="Int32" />                            
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>