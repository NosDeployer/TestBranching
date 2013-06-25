<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="revenue_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Revenue.revenue_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 760px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzRevenue" runat="server" Width="750px" Height="300px" 
                        ActiveStepIndex="1" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" 
                        OnNextButtonClick="Wizard_NextButtonClick" 
                        OnFinishButtonClick="Wizard_FinishButtonClick" 
                        OnCancelButtonClick="Wizard_CancelButtonClick" 
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            
                            
                            <asp:WizardStep ID="StepData" runat="server" Title="Data">
                                <!-- Page element: Data -->
                                <table cellpadding="0" cellspacing="0" style="width: 850px">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:Label ID="lblDailyRevenueTitle" runat="server" EnableViewState="False" SkinID="Label" Text="Daily Revenue"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <!-- Page element: UpdatePanel -->
                                            <asp:Panel ID="pnlRevenue" runat="server" Height="330px" Width="840px">
                                                <asp:UpdatePanel ID="upnlRevenue" runat="server">
                                                    <ContentTemplate>
                                                        <!-- Page element: 1 column - Grid Project Time -->
                                                        <asp:GridView ID="grdRevenue" runat="server" SkinID="GridView" Width="840px"
                                                            AutoGenerateColumns="False" AllowPaging="True" PageSize="10" ShowFooter="True"
                                                            OnDataBound="grdRevenue_DataBound" OnRowCommand="grdRevenue_RowCommand"
                                                            OnRowUpdating="grdRevenue_RowUpdating" OnRowEditing="grdRevenue_RowEditing"
                                                            OnRowDeleting="grdRevenue_RowDeleting" OnRowDataBound="grdRevenue_RowDataBound"
                                                            DataKeyNames="ProjectID,RefID" DataSourceID="odsRevenue">
                                                            
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
                                                                <asp:TemplateField HeaderText="Client">
                                                                    <EditItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblClientEdit" runat="server" Text='<%# Eval("Client") %>' SkinID="Label"></asp:Label>
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
                                                                                                Width="190px" DataSourceID="odsClientFooter" AutoPostBack="True" TabIndex="2"
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
                                                                    <HeaderStyle Width="200px"></HeaderStyle>
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
                                                                
                                                                <%--3--%>
                                                                <asp:TemplateField HeaderText="Project">
                                                                    <EditItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblProjectEdit" runat="server" Text='<%# Eval("Project") %>' SkinID="Label"></asp:Label>
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
                                                                                                                Width="190px" AutoPostBack="True"
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
                                                                    <HeaderStyle Width="200px"></HeaderStyle>
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
                                                                
                                                                <%--4--%>
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
                                                                                    <%--<asp:CustomValidator ID="cvDateEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="tkrdpDateEdit" Display="Dynamic"
                                                                                        ErrorMessage="There is a registered revenue on this date. Please change this data." OnServerValidate="cvDateEdit_ServerValidate" ValidationGroup="DataEdit"></asp:CustomValidator>--%>
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
                                                                                    <%--<asp:CustomValidator ID="cvDateFooter" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="tkrdpDateFooter" Display="Dynamic"
                                                                                        ErrorMessage="There is a registered revenue on this date. Please change this data." OnServerValidate="cvDateFooter_ServerValidate" ValidationGroup="DataNew"></asp:CustomValidator>--%>
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
                                                                
                                                                <%--5--%>
                                                                <asp:TemplateField HeaderText="Revenue">
                                                                    <EditItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="upnlRevenueEdit" runat="server" UpdateMode="Always">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxRevenueEdit" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Revenue")) %>' TabIndex="5"
                                                                                                Width="50px"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvRevenueEdit" runat="server" Operator="DataTypeCheck" Type="Currency"
                                                                                        ControlToValidate="tbxRevenueEdit" ValidationGroup="DataEdit" SkinID="Validator"
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
                                                                                    <asp:UpdatePanel ID="upnlRevenueFooter" runat="server" UpdateMode="Always">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxRevenueFooter" runat="server" SkinID="TextBoxRight" Text="0.00" TabIndex="5"
                                                                                                Width="50px"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvRevenueFooter" runat="server" Operator="DataTypeCheck" Type="Currency"
                                                                                        ControlToValidate="tbxRevenueFooter" ValidationGroup="DataNew" SkinID="Validator"
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
                                                                                    <asp:Label ID="lblRevenue" runat="server" Text='<%# String.Format("{0:N2}", Eval("Revenue")) %>'
                                                                                        SkinID="Label"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <%--6--%>
                                                                <asp:TemplateField HeaderText="Comments">
                                                                    <EditItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxCommentEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Comment") %>'
                                                                                            Width="220px"></asp:TextBox>
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
                                                                                        Width="220px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="230px"></HeaderStyle>
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
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this revenue?");'>
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
                                        <td style="height: 7px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                                                       
                        
                                                    
                           <asp:WizardStep ID="StepSummary" runat="server" Title="Summary">
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="550px" ReadOnly="True"
                                                SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                                                                                                              
                        </WizardSteps>
                    </asp:Wizard>                    
                </td>
            </tr>
        </table>


        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsRevenue" runat="server" SelectMethod="GetRevenueDetail"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Revenue.revenue_add"
                        DeleteMethod="DummyRevenueDetail" FilterExpression="(Deleted = 0)" UpdateMethod="DummyRevenueDetail"
                        InsertMethod="DummyRevenueDetail" OldValuesParameterFormatString="original_{0}">
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
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsClientFooter" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
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
    </div>
</asp:Content>
