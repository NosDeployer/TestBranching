<%@ Page Language="C#" MasterPageFile="../../mForm6.Master" AutoEventWireup="true"
    Codebehind="select_project.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.select_project"
    Title="LFS Live" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblTitle" runat="server" Text="This Is A Title" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: right">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px; height: 295px">
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblSelectAClient" runat="server" SkinID="LabelTitle1" Text="Please select a client and a project"
                        EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: select project -->
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSelect">

           <%-- <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                
                <tr>
                    <td style="width: 230px">
                        <asp:Label ID="lblInProjectManhole" runat="server" EnableViewState="False" SkinID="Label" Text="Manholes in Project"></asp:Label>                            
                    </td>
                    <td style="width: 230px">
                    </td>
                    <td style="width: 290px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="cbxInProject" runat="server" Checked="true" 
                        AutoPostBack="true" oncheckedchanged="cbxInProject_CheckedChanged"/>                         
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel id="upnlSelectNoProject" runat="server" >
                            <contenttemplate>
                                <asp:Button ID="btnSelectNoProject" runat="server" OnClick="btnSelectNoProject_Click" SkinID="Button" Text="Go" Style="width: 100px" EnableViewState="False" />
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="height: 7px">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>--%>
            <asp:UpdatePanel id="upnlForManholesInProject" runat="server" >
                <contenttemplate>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">              
                        <tr>
                            <td  style="width: 230px">
                                <asp:Label ID="lblClient" runat="server" EnableViewState="False" SkinID="Label" Text="Client"></asp:Label>
                            </td>
                            <td  style="width: 230px">
                                <asp:Label ID="lblProject" runat="server" EnableViewState="False" SkinID="Label" Text="Project"></asp:Label>
                            </td>
                            <td  style="width: 290px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel id="upnlClient" runat="server" >
                                    <contenttemplate>
                                        <asp:DropDownList id="ddlClient" runat="server" SkinID="DropDownListLookup" Width="220px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> 
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel id="upnlProject" runat="server">
                                    <contenttemplate>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 330px">
                                                        <asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="220px"></asp:DropDownList>
                                                    </td>
                                                    <td style="VERTICAL-ALIGN: middle">
                                                        <asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                            <ProgressTemplate>
                                                                <asp:Image id="imAjax" runat="server" skinId="Ajax_Grey"></asp:Image> 
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress> 
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </contenttemplate>
                                    <triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                    </triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" SkinID="Button" Text="Select" Style="width: 100px" EnableViewState="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlClient"
                                    EnableViewState="False" ErrorMessage="Please select a client" InitialValue="-1" SkinID="Validator">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvProject" runat="server" ControlToValidate="ddlProject"
                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a project" InitialValue="-1" SkinID="Validator">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        
                    </table>    
                
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblLastOpenedProjects" runat="server" EnableViewState="False" 
                                    SkinID="Label" Text="Last Opened Projects"></asp:Label>
                            </td>                    
                        </tr>                       
                        <tr>
                            <td>                                       
                                <asp:GridView id="grdProjects" runat="server" SkinID="GridView" Width="560px" 
                                    DataKeyNames="ProjectID, ClientID, UserID, LastLoggedInDate, COMPANY_ID, WorkType" OnRowCommand="grdProjects_RowCommand"
                                    DataSourceID="odsProjects" OnDataBound="grdProjects_DataBound"
                                    AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ClientID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientId" runat="server" Style="width: 100px" Text='<%# Bind("ClientID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="ProjectID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectId" runat="server" Style="width: 100px" Text='<%# Bind("ProjectID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="UserID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserId" runat="server" Style="width: 100px" Text='<%# Bind("UserID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="LastLoggedInDate" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLastLoggedInDate" runat="server" Style="width: 100px" Text='<%# Bind("LastLoggedInDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            
                                            <asp:TemplateField HeaderText="COMPANY_ID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyId" runat="server" Style="width: 100px" Text='<%# Bind("COMPANY_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Client">                                    
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientName" runat="server" Style="width: 230px" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="200px"></HeaderStyle>
                                            </asp:TemplateField>
                                            
                                            
                                            <asp:TemplateField HeaderText="Project">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Style="width: 230px" Text='<%# Bind("ProjectName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="310px"></HeaderStyle>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField>
                                                <ItemTemplate>                                            
                                                    <asp:HyperLink ID="hlkGo" runat="server" SkinID="HyperLink" Text="Go"
                                                     NavigateUrl='<%# GetUrl( Eval("ProjectID"), Eval("ClientID")) %>' Target="_parent" >
                                                    </asp:HyperLink>                                                                               
                                                </ItemTemplate>
                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                                                                         
                                                                                         
                                                                                                                                                                
                                        </Columns>
                                    </asp:GridView>
                            
                            </td>
                        </tr>
                        <tr>
                            <td >
                                </td>                    
                        </tr>
                        <tr>
                            <td style="height: 60px">
                            </td>                    
                        </tr>
                    </table>
            
                </contenttemplate>
            </asp:UpdatePanel>
                        
            <!-- Page element: Data objects -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:ObjectDataSource ID="odsProjects" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProjects" 
                            TypeName="LiquiForce.LFSLive.WebUI.CWP.Common.select_project">
                        </asp:ObjectDataSource>

                    </td>
                </tr>
            </table>
            
            <!-- Page element : Tag page -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:HiddenField ID="hdfCompanyId" runat="server" />
                        <asp:HiddenField ID="hdfLoginId" runat="server" />                        
                        <asp:HiddenField ID="hdfWorkType" runat="server" />                        
                    </td>
                </tr>
            </table>

    
        </asp:Panel>            
    </div>
</asp:Content>