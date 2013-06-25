<%@ Page Language="C#" MasterPageFile="./../../mDialog2.master" AutoEventWireup="true" CodeBehind="units_checklist_rules.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_checklist_rules" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 590px;">
        <!-- Page element: 2 columns - comment info -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td style=" width:147px"></td>
                <td style=" width:147px"></td>
                <td style=" width:147px"></td>
                <td style=" width:147px"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="grdChecklistRulesInformation" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="6" SkinID="GridView" Width="580px" OnDataBound="grdChecklistRulesInformation_DataBound" DataSourceID="odsChecklistRulesInformation" DataKeyNames="RuleID" OnPageIndexChanging="grdChecklistRulesInformation_PageIndexChanging" DataMember="DefaultView" OnRowDataBound="grdChecklistRulesInformation_RowDataBound">
                        <Columns>
                            <asp:BoundField ReadOnly="True" DataField="RuleID" Visible="False" SortExpression="RuleID" HeaderText="RuleID"></asp:BoundField>
                            
                            <asp:TemplateField HeaderText="Name">
                                <HeaderStyle Width="150px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn" runat="server" Width="115" Style="width: 150px" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Frequency">
                                <HeaderStyle Width="90px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblFrequency" Width="90px" runat="server" Style="width: 90px" SkinID="Label" Text='<%# Bind("Frequency") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Last Service">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                <ItemTemplate>
                                    <telerik:RadDatePicker ID="tkrdpLastService" runat="server" Width="100px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "LastService") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                    </telerik:RadDatePicker>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Next Due">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                <ItemTemplate>
                                    <telerik:RadDatePicker ID="tkrdpNextDue" runat="server" Width="100px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "NextDue") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                    </telerik:RadDatePicker>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Done">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <HeaderStyle Width="30px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxDone" runat="server" Checked='<%# Eval("Done") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="State">
                                <HeaderStyle Width="80px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlState" runat="server" EnableViewState="False"
                                        SkinID="DropDownList" Style="width: 80px" SelectedValue='<%# Eval("State") %>'>
                                        <asp:ListItem Value="Healthy">Healthy</asp:ListItem>
                                        <asp:ListItem Value="Warning">Warning</asp:ListItem>
                                        <asp:ListItem Value="Expired">Expired</asp:ListItem>
                                        <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                                        <asp:ListItem Value="Unknown">Unknown</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>                        
                                                        
                        </Columns>
                    </asp:GridView>                   
                </td>                                        
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CustomValidator ID="cvGrdChecklistRulesInformation" runat="server" Display="Dynamic" 
                    ErrorMessage="" OnServerValidate="cvGrdChecklistRulesInformation_ServerValidate" SkinID="Validator">
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="odsChecklistRulesInformation" runat="server" 
                                    FilterExpression="(Deleted = 0)"
                                    SelectMethod="GetChecklistRulesInformation"
                                    TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_checklist_rules" 
                                    >
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>    
                </td>
            </tr>                                
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfUnitId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ButtonsPlaceHolder" runat="server">
    <div style="width: 560px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
            <tr>
                <td style="width: 470px; height: 24px;" align="right">
                    <asp:Button ID="btnSave1" runat="server" EnableViewState="False" SkinID="Button"
                        Text="Apply" Style="width: 80px" OnClientClick="javascript:return btnSaveClick();"
                        OnClick="btnSave_Click" />
                </td>
                <td style="height: 24px" align="right">
                    <asp:Button ID="btnClose" runat="server" EnableViewState="False" OnClientClick="btnCloseClick();"
                        SkinID="Button" Text="Cancel" Style="width: 80px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
