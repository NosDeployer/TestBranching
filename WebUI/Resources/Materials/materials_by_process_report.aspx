<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="materials_by_process_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_by_process_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblProcess" runat="server" SkinID="Label" Text="Process"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlProcess" runat="server" 
                    DataSourceID="odsProcess" DataTextField="Type" DataValueField="Type" 
                    SkinID="DropDownListLookup" Width="160px">
                </asp:DropDownList>
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsProcess" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Materials.MaterialsTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(All)" Name="type" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                  
                </td>
            </tr>
        </table>
                
    </div>
</asp:Content>
