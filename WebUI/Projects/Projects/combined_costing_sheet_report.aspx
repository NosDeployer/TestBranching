<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mReport1.Master" AutoEventWireup="true" CodeBehind="combined_costing_sheet_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.combined_costing_sheet_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCostingSheets" runat="server" DataMember="DefaultView" DataSourceID="odsCostingSheets"
                        DataTextField="Name" DataValueField="CostingSheetID" SkinID="DropDownList" Style="width: 160px">
                    </asp:DropDownList>                    
                </td>
            </tr>            
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsCostingSheets" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="costingSheetId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                  
                </td>
            </tr>
        </table>
                
    </div>
</asp:Content>