<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mForm7.Master" AutoEventWireup="true" CodeBehind="materials_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_navigator2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Search Materials" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Materials" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddMaterials" Text="Add Materials"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" Selected="true" PostBack="false" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mMaterialByProcessReport" Text="Materials by Process Report" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>                                     
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Search &  Sort Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
            <tr>
                <td>
                    <asp:Label ID="lblSearchAndSort" runat="server" SkinID="LabelTitle1" Text="Search & Sort" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        <!-- Page element: Search & Sort components , 8 columns-->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">
            
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="Background_SearchAndSort">
                <tr>
                    <td style="width: 135px">
                        <asp:Label ID="lblFor" runat="server" SkinID="Label" Text="For" EnableViewState="False"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td style="width: 135px">
                        &nbsp;</td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCondition1" runat="server" SkinID="DropDownList" Style="width: 125px" EnableViewState="False" DataMember="DefaultView" DataSourceID="odsViewForDisplayList" DataTextField="Name" DataValueField="ConditionID">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="tbxCondition1" runat="server" Style="width: 480px" SkinID="TextBox" EnableViewState="False">%</asp:TextBox>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" SkinID="Button" Text="Search" Style="width: 80px" OnClick="btnSearch_Click" EnableViewState="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>                      
                        <asp:CustomValidator ID="cvForDecimalNumberCondition" runat="server" ControlToValidate="tbxCondition1" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="Invalid data. (use an decimal number, % or leave the field empty)" 
                            OnServerValidate="cvForDecimalNumberCondition_ServerValidate" SkinID="Validator" ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 7px">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
            
        <!-- Page element : Horizontal Rule -->
        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td style="height: 2px" class="Background_Separator">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Section title - Results-->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        <!-- Page element: Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one material."
                        Display="Dynamic" SkinID="Validator"></asp:CustomValidator>
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td style="width: 625px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Total Rows"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:Panel ID="pnlGrid" runat="server" Height="330px" Width="625px" ScrollBars="Horizontal">
                        <asp:GridView ID="grdNavigator" runat="server"  DataSourceID="odsNavigator"
                         AutoGenerateColumns="False" OnDataBound="grdNavigator_DataBound" 
                         DataKeyNames="MaterialID" SkinID="GridView" Width="620px"
                         OnSorting="grdNavigator_Sorting" AllowSorting="true">
                            <Columns>
                                
                                <asp:TemplateField HeaderText="MaterialID" Visible ="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialId" runat="server"  Text='<%# Eval("MaterialID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                            
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />                            
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                            Checked='<%# Eval("Selected") %>' />                                            
                                    </ItemTemplate>
                                    <ItemStyle Width="25px" />
                                </asp:TemplateField>                                                              
                                
                                <asp:TemplateField HeaderText="Process" SortExpression="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProcess" runat="server" Style="width: 120px" Text='<%# Eval("Type") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="120px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Style="width: 180px" Text='<%# Eval("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="180px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Size" SortExpression="Size">                                    
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSize" runat="server" Style="width: 80px" Text='<%# Eval("Size") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                                                
                                
                                <asp:TemplateField HeaderText="Length" SortExpression="Length">  
                                    <ItemStyle HorizontalAlign="Center" />                                  
                                    <ItemTemplate>
                                        <asp:Label ID="lblLength" runat="server" Style="width: 80px" Text='<%# Eval("Length") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                                                
                                <asp:TemplateField HeaderText="Thickness" SortExpression="Thickness">   
                                    <ItemStyle HorizontalAlign="Center" />                                                           
                                    <ItemTemplate>
                                        <asp:Label ID="lblThickness" runat="server" Style="width: 80px" Text='<%# Eval("Thickness") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                                                
                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Style="width: 80px" Text='<%# Eval("State") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Cost (CAD)" SortExpression="CostCad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostCad" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("CostCad"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Cost (USD)" SortExpression="CostUsd">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostUsd" runat="server" Style="width: 80px" Text='<%# GetRound(Eval("CostUsd"),2) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                                                
                                
                            </Columns>
                        </asp:GridView>                    
                    </asp:Panel> 
                </td>
                <td style="vertical-align: top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                        <!-- Page element : Buttons -->
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                Style="width: 80px" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                    Style="width: 80px" OnClick="btnEdit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPreviewList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Preview List" Style="width: 80px" OnClick="btnPreviewList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnExportList" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Export List" Style="width: 80px" OnClick="btnExportList_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                    Text="Delete" Style="width: 80px" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
        </table>
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>

        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsNavigator" runat="server" SelectMethod="GetNavigator"
                        TypeName="LiquiForce.LFSLive.WebUI.Resources.Materials.materials_navigator2"></asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsViewForDisplayList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Common.ResourceTypeViewConditionList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Materials" Name="resourceType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSortByList" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemInFor"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Common.ResourceTypeViewSortList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Materials" Name="resourceType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="True" Name="inFor" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentMaterialId" runat="server" />                    
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfResourceType" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>