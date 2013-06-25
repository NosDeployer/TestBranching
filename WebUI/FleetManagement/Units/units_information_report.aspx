<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="units_information_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_information_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:RadioButton ID="rbtnByUnit" runat="server" SkinID="RadioButton" Text="By Unit" Checked="true" GroupName="Options" />                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlUnits" runat="server" DataMember="DefaultView" DataSourceID="odsUnits"
                        DataTextField="Description" DataValueField="UnitID" SkinID="DropDownList" Style="width: 160px">
                    </asp:DropDownList>                    
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbtnByUnitType" runat="server" SkinID="RadioButton" Text="By Unit Type" GroupName="Options" />                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlUnitType" runat="server" SkinID="DropDownList" Style="width: 160px">
                        <asp:ListItem Value="Vehicle" Text="Vehicle" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Equipment" Text="Equipment"></asp:ListItem>
                    </asp:DropDownList>                    
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="(All)" Name="description" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                   
                </td>
            </tr>
        </table>
                
    </div>
</asp:Content>
