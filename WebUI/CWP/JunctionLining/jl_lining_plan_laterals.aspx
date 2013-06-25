<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true" CodeBehind="jl_lining_plan_laterals.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.jl_lining_plan_laterals" Title="LFS Live"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 735px;">
        <!-- Page element: Order by -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">            
            <tr>
                <td style="width: 10px">
                </td>
                <td style="width: 715px">
                    <asp:Label ID="lblOrder" runat="server" SkinID="Label" Text="Order Laterals By" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrder" runat="server" SkinID="DropDownList" Width="105px">
                        <asp:ListItem>Default</asp:ListItem>
                        <asp:ListItem>Per selection</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnOrder" runat="server" SkinID="Button" Text="Order" Width="80px" OnClick="btnOrder_Click" EnableViewState="False" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="3">
                </td>
            </tr>
        </table>
        
        <!-- Page element : No results bar -->
        <table id="tdNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 10px">
                </td>
                <td style="width: 715px">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
                        <tr>
                            <td>
                                <asp:Label ID="lblNoResults" runat="server" Text="No results for your query"></asp:Label>
                            </td>
                        </tr>
                   </table>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Grid results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 10px">
                </td>
                <td style="width: 715px">
                    <asp:GridView ID="grdLiningPlanLiners" runat="server" AutoGenerateColumns="False" PageSize="1"
                        Width="100%" GridLines="None" ShowHeader="False" AllowSorting="True" DataSourceID="odsJliners"
                        OnSorting="grdLiningPlanLiners_Sorting" OnDataBound="grdLiningPlanLiners_DataBound"  EnableViewState="False">
                        <Columns>
                            <asp:TemplateField SortExpression="ParentInstallOrder" Visible="False" HeaderText="ParentInstallOrder">                   
                                <ItemTemplate>
                                    <asp:Label ID="lblParentInstallOrder" runat="server" Text='<%# Eval("ParentInstallOrder") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                            <asp:TemplateField>
                                <ItemTemplate>
                                    
                                    <!-- Table element : 5 columns - Section row -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%"  class="Background_ViewGrid_Table">
                                        <tr>
                                            <td class="Background_ViewGrid_Header">
                                                
                                                <!-- Table element: 5 columns - Header data -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">
                                                    <tr>
                                                        <td style="width: 90px">
                                                            <asp:Label ID="lblHeader" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Install Order"></asp:Label>
                                                        </td>
                                                        <td style="width: 625px" >
                                                            <asp:Label ID="lblHeader2" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Laterals available for Lining Plan"></asp:Label>
                                                        </td>                                                        
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Background_ViewGrid_Td">
                                                <!-- Table element: 4 columns - LiningPlan fields -->
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 90px; vertical-align: middle; text-align: center;">
                                                            <asp:DropDownList ID="ddlSelected" runat="server" Width="70px" SkinID="DropDownList"
                                                                SelectedValue='<%# Eval("Selected") %>'>
                                                                <asp:ListItem Selected="True" Value="30">(None)</asp:ListItem>
                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                                <asp:ListItem Value="6">6</asp:ListItem>
                                                                <asp:ListItem Value="7">7</asp:ListItem>
                                                                <asp:ListItem Value="8">8</asp:ListItem>
                                                                <asp:ListItem Value="9">9</asp:ListItem>
                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                                <asp:ListItem Value="13">13</asp:ListItem>
                                                                <asp:ListItem Value="14">14</asp:ListItem>
                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>                                        
                                                        <td style="width: 1px" class="ViewGrid_Separator">
                                                        </td>
                                                        <td style="width: 12px" class="Background_ViewGrid_Td">
                                                        </td>
                                                        <td style="width: 600px; vertical-align: top">
                                                            <!-- Table element: 4 columns - Section data -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 150px; height: 15px">
                                                                        <asp:HiddenField ID="hdfAssetId" runat="server" Value='<%# Eval("AssetID") %>' />
                                                                    </td>
                                                                    <td style="width: 150px">
                                                                        <asp:HiddenField ID="hdfCompanyId" runat="server" Value='<%# Eval("COMPANY_ID") %>' />
                                                                    </td>
                                                                    <td style="width: 150px">
                                                                        <asp:HiddenField ID="hdfSectionId" runat="server" EnableViewState="false" Value='<%# Eval("Section_") %>' />
                                                                    </td>
                                                                    <td style="width: 150px">                                                                        
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblLateralId" runat="server" EnableViewState="False" SkinID="Label" Text="Lateral ID"></asp:Label>
                                                                    </td>                                                                    
                                                                    <td>
                                                                        <asp:Label ID="lblMn" runat="server" EnableViewState="False" SkinID="Label" Text="MN#"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPullInDistance" runat="server" EnableViewState="False" SkinID="Label" Text="Pull In Distance"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblLinerType" runat="server" EnableViewState="False" SkinID="Label" Text="Liner Type"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLateralId" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" 
                                                                            Text='<%# Eval("FlowOrderIDLateralID") %>' Width="140px"></asp:TextBox>
                                                                    </td>                                                                    
                                                                    <td>
                                                                        <asp:TextBox ID="tbxMn" runat="server" EnableViewState="False" ReadOnly="true" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("Address") %>' Width="140px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxPullInDistance" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("PullInDistance") %>' 
                                                                            Width="140px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLinerType" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("LinerType") %>' 
                                                                            Width="140px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px" colspan="4">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblFlange" runat="server" EnableViewState="False" SkinID="Label" 
                                                                            Text="Flange"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblMainSize" runat="server" EnableViewState="False" 
                                                                            SkinID="Label" Text="Main Size"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblLinerSize" runat="server" EnableViewState="False" 
                                                                            SkinID="Label" Text="Liner Size"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStantandardBypass" runat="server" EnableViewState="False" 
                                                                            SkinID="Label" Text="CO/Pit Location"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxFlange" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("Flange") %>' 
                                                                            Width="140px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxMainSize" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("MainSize") %>' 
                                                                            Width="140px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLinerSize" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("LinerSize") %>' 
                                                                            Width="140px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxCoPitLocation" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("CoPitLocation") %>' 
                                                                            Width="140px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px" colspan="4">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblComments" runat="server" EnableViewState="False" 
                                                                            SkinID="Label" Text="Comments"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top" colspan="4">
                                                                        <asp:TextBox ID="tbxComments" runat="server" EnableViewState="False" 
                                                                            ReadOnly="true" Rows="10" SkinID="TextBoxReadOnly" 
                                                                            Text='<%# Eval("Comments") %>' TextMode="MultiLine" Width="590px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 20px">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td> 
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Table element : Space inter rows -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one or more laterals"
                        Display="Dynamic" SkinID="Validator">
                    </asp:CustomValidator>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px;">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsJliners" runat="server"
                        SelectMethod="GetJlinersNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.JunctionLining.jl_lining_plan_laterals" >
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
            
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <div style="width: 735px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 645px; height: 24px;" align="right">
                    <asp:Button ID="btnPreview" runat="server" EnableViewState="False" SkinID="Button"
                        Text="Preview" Style="width: 80px" OnClick="btnPreview_Click" />
                </td>
                <td style="height: 24px" align="right">
                    <asp:Button ID="btnClose" runat="server" EnableViewState="False" OnClientClick="btnCloseClick();"
                        SkinID="Button" Text="Close" Style="width: 80px" />
                </td>
            </tr>
        </table>                
    </div>
</asp:Content>