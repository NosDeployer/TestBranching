<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mForm6.master" AutoEventWireup="true" CodeBehind="subcontractor_hours_add_by_subcontractor.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.subcontractor_hours_add_by_subcontractor" %>

<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="LabelTitle" runat="server" SkinID="LabelPageTitle1" Text="Add Hours By Subcontractor" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px"
                        OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Subcontractor Hours" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddHoursBySubcontractor" Text="Add Hours by Subcontractor" Selected="true" PostBack="false">
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mAddHoursByClientProject" Text="Add Hours by Client and Project">
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search">
                                    </telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2"
                        Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSubcontractors" Text="Add Subcontractors">
                                    </telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2"
                        Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mSubcontractorHoursReport" Text="Print Subcontractor Hours">
                                    </telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: 4 columns -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 180px">
                    <asp:Label ID="lblSubcontractor" runat="server" SkinID="Label" Text="Subcontractor" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 180px">
                </td>
                <td style="width: 180px">
                </td>
                <td style="width: 180px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList Width="350px" ID="ddlSubcontractor" runat="server" SkinID="DropDownListLookup"
                        DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                        DataSourceID="odsSubcontractorsList">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlSubcontractor" ValidationGroup="generalData"
                        Display="Dynamic" ErrorMessage="Please select a subcontractor." InitialValue="-1"
                        SkinID="Validator"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        
        <!-- Page element: 1 column title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="lblSubcontractors" runat="server" SkinID="Label" Text="Subcontractor Hours"
                        EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
        </table>
        
        <%--Grid--%>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 740px">
            <tr>
                <td>
                    <asp:Panel ID="pnlSubcontractors" runat="server" Height="330px" Width="740px">
                        <asp:UpdatePanel ID="upnlSubcontractors" runat="server">
                            <ContentTemplate>
                                <!-- Page element: 1 column - Grid Project Time -->
                                <asp:GridView ID="grdSubcontractors" runat="server" SkinID="GridView" Width="740px"
                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="10" ShowFooter="True"
                                    OnDataBound="grdSubcontractors_DataBound" OnRowCommand="grdSubcontractors_RowCommand"
                                    OnRowUpdating="grdSubcontractors_RowUpdating" OnRowEditing="grdSubcontractors_RowEditing"
                                    OnRowDeleting="grdSubcontractors_RowDeleting" OnRowDataBound="grdSubcontractors_RowDataBound"
                                    DataKeyNames="ProjectID,RefID" DataSourceID="odsSubcontractors">
                                    <Columns>
                                        <%--0--%>
                                        <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblProjectIdEdit" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectId" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblProjectIdFooter" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label></FooterTemplate>
                                        </asp:TemplateField>
                                        <%--1--%>
                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblRefIdEdit" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <%--2--%>
                                        <asp:TemplateField SortExpression="SubcontractorID" Visible="False" HeaderText="SubcontractorID">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblSubcontractorIdEdit" runat="server" Text='<%# Eval("SubcontractorID") %>'></asp:Label></EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubcontractorId" runat="server" Text='<%# Eval("SubcontractorID") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <%--3--%>
                                        <asp:TemplateField SortExpression="Date" HeaderText="Date">
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <telerik:RadDatePicker ID="tkrdpDateEdit" runat="server" DbSelectedDate='<%# String.Format("{0:d}",Eval("Date")) %>' TabIndex="1"
                                                                Width="100px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvDateEdit" runat="server" ControlToValidate="tkrdpDateEdit"
                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                ValidationGroup="DataEdit" EnableViewState="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <telerik:RadDatePicker ID="tkrdpDateFooter" runat="server" Width="100px" SkinID="RadDatePicker" TabIndex="1"
                                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvDateFooter" runat="server" ControlToValidate="tkrdpDateFooter"
                                                                Display="Dynamic" ErrorMessage="Please select a Date." InitialValue="" SkinID="Validator"
                                                                ValidationGroup="DataNew" EnableViewState="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>' SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Client">
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlClientEdit" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlClientEdit" runat="server" SkinID="DropDownListLookup" Width="100px" TabIndex="2"
                                                                        DataSourceID="odsClientEdit" AutoPostBack="True" DataValueField="Companies_ID"
                                                                        DataTextField="NAME" OnSelectedIndexChanged="ddlClientEdit_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvClientEdit" runat="server" ControlToValidate="ddlClientEdit"
                                                                Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                                ValidationGroup="DataEdit" EnableViewState="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlClientFooter" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlClientFooter" runat="server" SkinID="DropDownListLookup"
                                                                        Width="100px" DataSourceID="odsClientFooter" AutoPostBack="True" TabIndex="2"
                                                                        DataValueField="Companies_ID" DataTextField="NAME" OnSelectedIndexChanged="ddlClientFooter_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvClientFooter" runat="server" ControlToValidate="ddlClientFooter"
                                                                Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                                ValidationGroup="DataNew" EnableViewState="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--4--%>
                                        <asp:TemplateField HeaderText="Project">
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlProjectEdit" runat="server">
                                                                <ContentTemplate>
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlProjectEdit" runat="server" SkinID="DropDownListLookup" TabIndex="3"
                                                                                        Width="100px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="vertical-align: middle">
                                                                                    <asp:UpdateProgress ID="upProjectEdit" runat="server" AssociatedUpdatePanelID="upnlClientEdit">
                                                                                        <ProgressTemplate>
                                                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                        </ProgressTemplate>
                                                                                    </asp:UpdateProgress>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlClientEdit" EventName="SelectedIndexChanged">
                                                                    </asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProjectEdit" runat="server" ControlToValidate="ddlProjectEdit"
                                                                Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                                                                ValidationGroup="DataEdit" EnableViewState="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlProjectFooter" runat="server">
                                                                <ContentTemplate>
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlProjectFooter" runat="server" SkinID="DropDownListLookup" TabIndex="3" 
                                                                                        Width="100px" AutoPostBack="True"
                                                                                        >
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="vertical-align: middle">
                                                                                    <asp:UpdateProgress ID="upProjectFooter" runat="server" AssociatedUpdatePanelID="upnlClientFooter">
                                                                                        <ProgressTemplate>
                                                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                        </ProgressTemplate>
                                                                                    </asp:UpdateProgress>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlClientFooter" EventName="SelectedIndexChanged">
                                                                    </asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProjectFooter" runat="server" ControlToValidate="ddlProjectFooter"
                                                                Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                                                                ValidationGroup="DataNew" EnableViewState="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="100px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblProject" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--5--%>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlQuantityEdit" runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxQuantityEdit" runat="server" SkinID="TextBoxRight" Text='<%# Eval("Quantity") %>' TabIndex="4"
                                                                        Width="60px" OnTextChanged="tbxQuantityEdit_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CompareValidator ID="cvQuantityEdit" runat="server" Operator="DataTypeCheck"
                                                                Type="Double" ControlToValidate="tbxQuantityEdit" ValidationGroup="DataEdit"
                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.# format)">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlQuantityFooter" runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxQuantityFooter" runat="server" SkinID="TextBoxRight" Text="0.0" TabIndex="4"
                                                                        Width="60px" OnTextChanged="tbxQuantityFooter_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CompareValidator ID="cvQuantityFooter" runat="server" Operator="DataTypeCheck"
                                                                Type="Double" ControlToValidate="tbxQuantityFooter" ValidationGroup="DataNew"
                                                                SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.# format)">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>' SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--6--%>
                                        <asp:TemplateField HeaderText="Rate">
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRateEdit" runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRateEdit" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>' TabIndex="5"
                                                                        Width="60px" OnTextChanged="tbxRateEdit_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CompareValidator ID="cvRateEdit" runat="server" Operator="DataTypeCheck" Type="Currency"
                                                                ControlToValidate="tbxRateEdit" ValidationGroup="DataEdit" SkinID="Validator"
                                                                Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlRateFooter" runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxRateFooter" runat="server" SkinID="TextBoxRight" Text="0.00" TabIndex="5"
                                                                        Width="60px" OnTextChanged="tbxRateFooter_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CompareValidator ID="cvRateFooter" runat="server" Operator="DataTypeCheck" Type="Currency"
                                                                ControlToValidate="tbxRateFooter" ValidationGroup="DataNew" SkinID="Validator"
                                                                Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="lblRate" runat="server" Text='<%# String.Format("{0:N2}", Eval("Rate")) %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="upnlTotalCalcEdit" runat="server" UpdateMode="Always">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="tbxTotalEdit" runat="server" SkinID="TextBoxRightReadOnly" Text='<%# String.Format("{0:N2}", Eval("Total")) %>' TabIndex="6"
                                                                            AutoPostBack="True" Width="60px" ReadOnly="true"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlTotalCalcFooter" runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="tbxTotalFooter" runat="server" ReadOnly="true" SkinID="TextBoxRightReadOnly" TabIndex="6"
                                                                        Text="0.00" AutoPostBack="True" Width="60px"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="lblTotal" runat="server" Text='<%# String.Format("{0:N2}", Eval("Total")) %>'
                                                                SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comments">
                                            <EditItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbxCommentEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                    Width="160px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxCommentFooter" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                Width="160px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="160px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Comment") %>' SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 12px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderStyle Width="50px"></HeaderStyle>
                                            <ItemTemplate>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit">
                                                                </asp:ImageButton>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                    OnClientClick='return confirm("Are you sure you want to delete this subcontractor hour?");'>
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompaniesID" runat="server" EnableViewState="true" />
                    <asp:HiddenField ID="hdfProjectID" runat="server" />
                    <asp:HiddenField ID="hdfSaveClick" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                </td>
            </tr>
        </table>
        <!-- Page element: DataObjects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsSubcontractorsList" runat="server" CacheDuration="60"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a subcontractor)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSubcontractors" runat="server" SelectMethod="GetSubcontractorsDetail"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.subcontractor_hours_add_by_subcontractor"
                        DeleteMethod="DummySubcontractorsDetail" FilterExpression="(Deleted = 0)" UpdateMethod="DummySubcontractorsDetail"
                        InsertMethod="DummySubcontractorsDetail" OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="ProjectID" Type="Int32" />
                            <asp:Parameter Name="RefID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ProjectID" Type="Int32" />
                            <asp:Parameter Name="RefID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ProjectID" Type="Int32" />
                            <asp:Parameter Name="RefID" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsClientEdit" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.RAF.CompaniesList" CacheDuration="120" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsClientFooter" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.RAF.CompaniesList" CacheDuration="120" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
