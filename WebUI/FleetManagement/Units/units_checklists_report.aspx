<%@ Page Language="C#" MasterPageFile="../../mReport1.Master" AutoEventWireup="true" CodeBehind="units_checklists_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_checklists_report" Title="LFS Live" %>

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
            <!-- Page element : Horizontal Rule -->
            <tr style="width: 160px">
                <td style="height: 30px">
                </td>
            </tr>
            <tr style="width: 160px">
                <td style="height: 2px" class="Background_Separator">
                </td>
            </tr>
            <tr style="width: 160px">
                <td style="height: 10px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Checkbox ID="ckbxAllUnits" runat="server" SkinID="CheckBox" Text="Show units with no rules" />                    
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
                        <asp:ListItem Value="All" Selected="True">(All)</asp:ListItem>
                        <asp:ListItem Value="Vehicle" Text="Vehicle"></asp:ListItem>
                        <asp:ListItem Value="Equipment" Text="Equipment"></asp:ListItem>
                    </asp:DropDownList>                    
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWorkingLocation" runat="server" Text="Working Location" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:dropdownlist id="ddlWorkingLocation" SkinID="DropDownList" tabIndex="1" runat="server" Width="160px">
                        <asp:ListItem Value="All">(All)</asp:ListItem>    
                        <asp:ListItem Value="3">USA</asp:ListItem>    
                        <asp:ListItem Value="2">Canada</asp:ListItem> 
	                </asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMtoDotRules" runat="server" SkinID="Label" Text="Fixed Date Rules"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlMtoDotRule" runat="server" SkinID="DropDownList" Style="width: 160px">
                        <asp:ListItem Value="All" Selected="True">(All)</asp:ListItem>
                        <asp:ListItem Value="MTODOTRules" Text="Fixed Date Rules" ></asp:ListItem>
                        <asp:ListItem Value="LFSRules" Text="LFS Rules"></asp:ListItem>
                    </asp:DropDownList>                    
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFrequency" runat="server" SkinID="Label" Text="Frequency"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlFrequency" runat="server" DataMember="DefaultView" DataSourceID="odsFrequency"
                        DataTextField="Frequency" DataValueField="Frequency" SkinID="DropDownList" Style="width: 160px">
                    </asp:DropDownList>                    
                </td>
            </tr>
            <tr>
                <td height="7px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblChecklistState" runat="server" SkinID="Label" Text="Checklist State"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlChecklistState" runat="server" SkinID="DropDownList" Style="width: 160px">
                        <asp:ListItem Value="All">(All)</asp:ListItem>
                        <asp:ListItem Value="In Progress">In Progress</asp:ListItem>
                        <asp:ListItem Value="Healthy">Healthy</asp:ListItem>
                        <asp:ListItem Value="Warning">Warning</asp:ListItem>
                        <asp:ListItem Value="Expired">Expired</asp:ListItem>
                        <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                        <asp:ListItem Value="Unknown">Unknown</asp:ListItem>
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
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>  
                    <asp:ObjectDataSource ID="odsFrequency" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.RuleFrecuencyList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="frequency" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                
                </td>
            </tr>
        </table>
                
    </div>
</asp:Content>