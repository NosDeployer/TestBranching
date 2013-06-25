<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mWizard2.Master"
    AutoEventWireup="true" Codebehind="add_manhole.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.add_manhole" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 770px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wizard" runat="server" Width="770px" Height="525px" ActiveStepIndex="1" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>                           
                            
                            
                           <asp:WizardStep ID="Begin" runat="server" Title="Begin" StepType="Start"> 
                                <asp:UpdatePanel ID="upStepNewManhole" runat="server">
                                    <ContentTemplate>
                                    
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSelectAClient" runat="server" SkinID="LabelTitle2" Text="Please select a client and a project"
                                                        EnableViewState="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height:10px">
                                                </td>
                                            </tr>
                                        </table>
                                    
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 230px">
                                                    <asp:Label ID="lblClient" runat="server" EnableViewState="False" SkinID="Label" Text="Client"></asp:Label>
                                                </td>
                                                <td style="width: 230px">
                                                    <asp:Label ID="lblProject" runat="server" EnableViewState="False" SkinID="Label"
                                                        Text="Project"></asp:Label>
                                                </td>
                                                <td style="width: 290px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="upnlClient" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlClient" runat="server" SkinID="DropDownListLookup" Width="220px"
                                                                OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="upnlProject" runat="server">
                                                        <ContentTemplate>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 330px">
                                                                            <asp:DropDownList ID="ddlProject" runat="server" SkinID="DropDownListLookup" Width="220px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="vertical-align: middle">
                                                                            <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                                                <ProgressTemplate>
                                                                                    <asp:Image ID="imAjax" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged">
                                                            </asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlClient"
                                                        EnableViewState="False" ErrorMessage="Please select a client." InitialValue="-1"
                                                        SkinID="Validator">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvProject" runat="server" ControlToValidate="ddlProject"
                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a project."
                                                        InitialValue="-1" SkinID="Validator">
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
                                    
                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdAddManholeNew" runat="server" SkinID="GridView" Width="770px"
                                                            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="AssetID" DataSourceID="odsAddManholeNew"
                                                            OnDataBound="grdAddManholeNew_DataBound" OnRowCreated="grdAddManholeNew_RowCreated"
                                                            OnRowUpdating="grdAddManholeNew_RowUpdating" OnRowEditing="grdAddManholeNew_RowEditing"
                                                            OnRowCommand="grdAddManholeNew_RowCommand" PageSize="2" ShowFooter="True"
                                                            OnRowDeleting="grdAddManholeNew_RowDeleting" OnRowDataBound="grdAddManholeNew_RowDataBound">
                                                            <Columns>
                                                                    
                                                                <asp:TemplateField SortExpression="AssetID" Visible="False" HeaderText="AssetID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblAssetID" runat="server" Text='<%# Eval("AssetID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAssetID" runat="server" Text='<%# Eval("AssetID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Manhole Information" SortExpression="AssetID"> 
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                            
                                                                            <tr>
                                                                                <td style="width: 10px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 190px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>                                                                            
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMhIdEdit" runat="server" SkinID="Label" Text="MH No"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblStreetEdit" runat="server" SkinID="Label" Text="Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLatitudeEdit" runat="server" SkinID="Label" Text="Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLongitudeEdit" runat="server" SkinID="Label" Text="Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblShapeEdit" runat="server" SkinID="Label" Text="Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLocationEdit" runat="server" SkinID="Label" Text="Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>                                                                                    
                                                                                    <asp:TextBox ID="tbxMhIdEdit" runat="server" Text='<%# Eval("MHID") %>' ReadOnly="true" Width="90px"
                                                                                        SkinID="TextBoxReadOnly" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxStreetEdit" runat="server" Text='<%# Eval("Address") %>' Width="180px"
                                                                                        SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxLatitudeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Latitud") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxLongitudeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Longitude") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="uplShapeEdit" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlShapeEdit" runat="server" DataMember="DefaultView"
                                                                                                DataSourceID="odsShape" DataTextField="ManholeShape" DataValueField="ManholeShape"
                                                                                                SkinID="DropDownList" Style="width: 90px" AutoPostBack="true" OnTextChanged="ddlShapeEdit_SelectedIndexChanged" >
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>                                                                                      
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlLocationEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsLocation" DataTextField="Location" DataValueField="Location"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvMhIdEdit" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="AddManholeUpdate" ErrorMessage="Please provide the manhole No."
                                                                                        Display="Dynamic" ControlToValidate="tbxMhIdEdit"></asp:RequiredFieldValidator>
                                                                                    <cc1:AutoCompleteExtender ID="aceMhIdEdit" runat="server" SkinID="AutoCompleteExtender"
                                                                                            TargetControlID="tbxMhIdEdit" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                                                                                            ServiceMethod="GetMHList" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="true">
                                                                                        </cc1:AutoCompleteExtender>
                                                                                 </td>                                                                                
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td></td>
                                                                                <td style="height: 7px"></td>                                                                                
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>  
                                                                                <td></td>                                                                              
                                                                                <td>
                                                                                    <asp:Label ID="lblRatingEdit" runat="server" SkinID="Label" Text="Condition Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMaterialEdit" runat="server" SkinID="Label" Text="Material"></asp:Label>
                                                                                </td>
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td> </td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlConditioningRatingEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlMaterialEdit" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsMaterialType" DataTextField="MaterialType" DataValueField="MaterialID"
                                                                                        SkinID="DropDownList" Style="width: 180px" >
                                                                                    </asp:DropDownList>  
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                                                                                                            
                                                                                </td>                                                                                                                                                                                                                                         
                                                                            </tr>    
                                                                            <tr>
                                                                                <td></td>
                                                                                <td style="height: 10px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                
                                                                        </table>
                                                                        
                                                                        <asp:UpdatePanel ID="upnlShapesEdit" runat="server">   
                                                                            <ContentTemplate> 
                                                                                <asp:Panel ID="pnlInformationRoundMHEdit" runat="server">    
                                                                                    <!-- Table element: 8 columns structure information -->                                                                                                                                                          
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>                                                                                        
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td> </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataChimneyDiameterEdit" runat="server" SkinID="Label" Text="Chimney Diameter"></asp:Label>          
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataChimneyDepthEdit" runat="server" SkinID="Label" Text="Chimney Depth"></asp:Label>
                                                                                            </td>
                                                                                             <td>                          
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelDiameterEdit" runat="server" SkinID="Label" Text="Barrel Diameter"></asp:Label> 
                                                                                            </td>
                                                                                            <td>                   
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelDepthEdit" runat="server" SkinID="Label" Text="Barrel Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelManholeRugsEdit" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>                                                            
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataChimneyDiameterEdit" runat="server" 
                                                                                                SkinID="TextBox"  Style="width: 90px" Text='<%# Eval("TopDiameter") %>' ></asp:TextBox>                                                                                                                                    
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataChimneyDepthEdit" runat="server"  
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("TopDepth") %>'></asp:TextBox>                                  
                                                                                            </td>
                                                                                            <td>          
                                                                                                <asp:TextBox ID="tbxRehabilitationDataBarrelDiameterEdit" runat="server"
                                                                                                 SkinID="TextBox" Style="width: 90px" Text='<%# Eval("DownDiameter") %>'></asp:TextBox>                                                                                                                                                     
                                                                                            </td>
                                                                                            <td>                   
                                                                                                <asp:TextBox ID="tbxRehabilitationDataBarrelDepthEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("DownDepth") %>'></asp:TextBox> 
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlRehabilitationDataRoundManholeRugsEdit" runat="server" DataMember="DefaultView"
                                                                                                    DataSourceID="odsRugs" DataTextField="ManholeRugs" DataValueField="ManholeRugsId"
                                                                                                    SkinID="DropDownListLookupBlueText" Style="width: 90px">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                      
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>                                                                                                
                                                                                               <asp:CustomValidator ID="cvRehabilitationDataChimneyDiameterEdit" runat="server" ControlToValidate="tbxRehabilitationDataChimneyDiameterEdit"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                                    OnServerValidate="cvRehabilitationDataChimneyDiameterEdit_ServerValidate" SkinID="Validator" ValidationGroup="AddManholeUpdate">
                                                                                               </asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                 <asp:CustomValidator ID="cvRehabilitationDataChimneyDepthEdit" runat="server" ControlToValidate="tbxRehabilitationDataChimneyDepthEdit"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                                    OnServerValidate="cvRehabilitationDataChimneyDepthEdit_ServerValidate" SkinID="Validator" ValidationGroup="AddManholeUpdate">
                                                                                               </asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                 <asp:CustomValidator ID="cvRehabilitationDataBarrelDiameterEdit" runat="server" ControlToValidate="tbxRehabilitationDataBarrelDiameterEdit"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                                    OnServerValidate="cvRehabilitationDataBarrelDiameterEdit_ServerValidate" SkinID="Validator" ValidationGroup="AddManholeUpdate">
                                                                                                </asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataBarrelDepthEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataBarrelDepthEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataBarrelDepthEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px"></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                          
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationRectangularMHEdit" runat="server">                                                                               
                                                                                    <!-- Table element: 6 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>                                                                                        
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1LongSideEdit" runat="server" SkinID="Label" Text="Rectangle 1 Long Sider"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1ShortSideEdit" runat="server" SkinID="Label" Text="Rectangle 1 Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1DepthEdit" runat="server" SkinID="Label" Text="Rectangle 1 Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2LongSideEdit" runat="server" SkinID="Label" Text="Rectangle 2 Long Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2ShortSideEdit" runat="server" SkinID="Label" Text="Rectangle 2 Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2DepthEdit" runat="server" SkinID="Label" Text="Rectangle 2 Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangularManholeRugsEdit" runat="server" SkinID="LabelSmall" Text="Manhole Rugs"></asp:Label>                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1LongSideEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("Rectangle1LongSide") %>'></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1ShortSideEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("Rectangle1ShortSide") %>'></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1DepthEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("TopDepth") %>'></asp:TextBox>                                                                                                                                                                                    
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle2LongSideEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("Rectangle2LongSide") %>'></asp:TextBox>                                                                                                                            
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle2ShortSideEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("Rectangle2ShortSide") %>'></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>
                                                                                                 <asp:TextBox ID="tbxRehabilitationDataRectangle2DepthEdit" runat="server" 
                                                                                                 SkinID="TextBox" Style="width: 90px" Text='<%# Eval("DownDepth") %>'></asp:TextBox>                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlRehabilitationDataRectangularManholeRugsEdit" runat="server" DataMember="DefaultView"
                                                                                                    DataSourceID="odsRugs" DataTextField="ManholeRugs" DataValueField="ManholeRugsId"
                                                                                                    SkinID="DropDownListLookupBlueText" Style="width: 90px" >
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle1LongSideEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle1LongSideEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle1LongSideEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                                </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle1ShortSideEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle1ShortSideEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle1ShortSideEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                                </td>
                                                                                            <td>                                                                                                
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle1DepthEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle1DepthEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle1DepthEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle2LongSideEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle2LongSideEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle2LongSideEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle2ShortSideEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle2ShortSideEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle2ShortSideEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle2DepthEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle2DepthEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle2DepthEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                    
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px"></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationMixedMHEdit" runat="server">
                                                                                    <!-- Table element: 8 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRoundDiameterEdit" runat="server" SkinID="Label" Text="Round Diameter"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRoundDepthEdit" runat="server" SkinID="Label" Text="Round Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleLongSideEdit" runat="server" SkinID="Label" Text="Rectangle Long Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleShortSideEdit" runat="server" SkinID="Label" Text="Rectangle Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleDepthEdit" runat="server" SkinID="Label" Text="Rectangle Depth"></asp:Label>
                                                                                            </td>
                                                                                             <td>
                                                                                                <asp:Label ID="lblRehabilitationDataManholeRugsEdit" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRoundDiameterEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("TopDiameter") %>'></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRoundDepthEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("TopDepth") %>'></asp:TextBox>                                                                                                                                    
                                                                                            </td>
                                                                                            <td>                           
                                                                                               <asp:TextBox ID="tbxRehabilitationDataRectangleLongSideEdit" runat="server" 
                                                                                               SkinID="TextBox" Style="width: 90px" Text='<%# Eval("Rectangle2LongSide") %>'></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangleShortSideEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("Rectangle2ShortSide") %>'></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangleDepthEdit" runat="server" 
                                                                                                SkinID="TextBox" Style="width: 90px" Text='<%# Eval("DownDepth") %>'></asp:TextBox>                                                                                    
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:DropDownList ID="ddlRehabilitationDataMixManholeRugsEdit" runat="server" DataMember="DefaultView"
                                                                                                    DataSourceID="odsRugs" DataTextField="ManholeRugs" DataValueField="ManholeRugsId"
                                                                                                    SkinID="DropDownListLookupBlueText" Style="width: 90px" >
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>                                                                                                
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRoundDiameterEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRoundDiameterEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRoundDiameterEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRoundDepthEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRoundDepthEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRoundDepthEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangleLongSideEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangleLongSideEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangleLongSideEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangleShortSideEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangleShortSideEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangleShortSideEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangleDepthEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangleDepthEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangleDepthEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                                                                                                                                                                             
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px">
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationOtherMHEdit" runat="server">   
                                                                                    <!-- Table element: 8 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td> </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataOtherStructureEdit" runat="server" SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataOtherStructureEdit" runat="server" SkinID="TextBox" 
                                                                                                Style="width: 90px" Text='<%# Eval("TotalSurfaceArea") %>'></asp:TextBox>                                                                                                                                   
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>                                          
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataOtherStructureEdit" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataOtherStructureEdit" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataOtherStructureEdit_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="mrOtherStructure"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px">
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>                                    
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel> 
                                                                    </EditItemTemplate>
                                                                    
                                                                    
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                            
                                                                            <tr>                                                                        
                                                                                <td style="width: 10px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 190px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>                                                                            
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblmhIdTitleAdd" runat="server" SkinID="Label" Text="MH No"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblStreetAdd" runat="server" SkinID="Label" Text="Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLatitudeAdd" runat="server" SkinID="Label" Text="Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLongitudeAdd" runat="server" SkinID="Label" Text="Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblShapeAdd" runat="server" SkinID="Label" Text="Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLocationAdd" runat="server" SkinID="Label" Text="Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>                                                                                    
                                                                                    <asp:TextBox ID="tbxMhIdAdd" runat="server"  Width="90px" SkinID="TextBox" Autocomplete="Off" OnTextChanged="tbxMhIdAdd_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxStreetAdd" runat="server"  Width="180px" SkinID="TextBox" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxLatitudeAdd" runat="server" SkinID="TextBox" Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxLongitudeAdd" runat="server" SkinID="TextBox"  Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdatePanel ID="uplShapeAdd" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlShapeAdd" runat="server" DataMember="DefaultView"
                                                                                                DataSourceID="odsShape" DataTextField="ManholeShape" DataValueField="ManholeShape"
                                                                                                SkinID="DropDownList" Style="width: 90px" AutoPostBack="true" OnTextChanged="ddlShapeAdd_SelectedIndexChanged" >
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>                                                                                      
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlLocationAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsLocation" DataTextField="Location" DataValueField="Location"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>     
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:CustomValidator ID="cvMhIdFooter" runat="server" ControlToValidate="tbxMhIdAdd"
                                                                                        Display="Dynamic" ErrorMessage="This manhole already exists please review your data"
                                                                                        OnServerValidate="cvMhIdFooter_ServerValidate" SkinID="Validator" ValidationGroup="AddManholeAdd"></asp:CustomValidator>
                                                                                                        
                                                                                    <asp:RequiredFieldValidator ID="rfvMhIdFooter" runat="server" SkinID="Validator"
                                                                                        EnableViewState="False" ValidationGroup="AddManholeAdd" ErrorMessage="Please provide the manhole No."
                                                                                        Display="Dynamic" ControlToValidate="tbxMhIdAdd"></asp:RequiredFieldValidator>
                                                                                        
                                                                                    <cc1:AutoCompleteExtender ID="aceMhIdAdd" runat="server" SkinID="AutoCompleteExtender"
                                                                                            TargetControlID="tbxMhIdAdd" ServicePath="./../../CWP/Assets/wsAssetSewerMH.asmx"
                                                                                            ServiceMethod="GetMHListAdd" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="true">
                                                                                        </cc1:AutoCompleteExtender>                                                                                                                                                                               
                                                                                </td>                                                                              
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                             </tr>   
                                                                             <tr>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>
                                                                                <td></td>                                                                                
                                                                                <td>
                                                                                    <asp:Label ID="lblRatingAdd" runat="server" SkinID="Label" Text="Condition Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMaterialAdd" runat="server" SkinID="Label" Text="Material"></asp:Label>
                                                                                </td>
                                                                                <td>                                                                                    
                                                                                </td>
                                                                                <td> </td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlConditioningRatingAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsConditionRating" DataTextField="ConditionRating" DataValueField="ConditionRatingId"
                                                                                        SkinID="DropDownList" Style="width: 90px" >
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlMaterialAdd" runat="server" DataMember="DefaultView"
                                                                                        DataSourceID="odsMaterialType" DataTextField="MaterialType" DataValueField="MaterialID"
                                                                                        SkinID="DropDownList" Style="width: 180px" >
                                                                                    </asp:DropDownList>  
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                                                                                                          
                                                                                </td>                                                                                                                                                             
                                                                             </tr>                                                                                  
                                                                             <tr>
                                                                                <td style="height: 10px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>  
                                                                        </table>
                                                                        
                                                                        <asp:UpdatePanel ID="upnlShapesAdd" runat="server">   
                                                                            <ContentTemplate> 
                                                                                <asp:Panel ID="pnlInformationRoundMHAdd" runat="server">    
                                                                                    <!-- Table element: 8 columns structure information -->                                                                                                                                                          
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>                                                                                        
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td> </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataChimneyDiameterAdd" runat="server" SkinID="Label" Text="Chimney Diameter"></asp:Label>          
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataChimneyDepthAdd" runat="server" SkinID="Label" Text="Chimney Depth"></asp:Label>
                                                                                            </td>
                                                                                             <td>                          
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelDiameterAdd" runat="server" SkinID="Label" Text="Barrel Diameter"></asp:Label> 
                                                                                            </td>
                                                                                            <td>                   
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelDepthAdd" runat="server" SkinID="Label" Text="Barrel Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelManholeRugsAdd" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>                                                            
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataChimneyDiameterAdd" runat="server" SkinID="TextBox"  Style="width: 90px" ></asp:TextBox>                                                                                                                                    
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataChimneyDepthAdd" runat="server"  SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                  
                                                                                            </td>
                                                                                            <td>          
                                                                                                <asp:TextBox ID="tbxRehabilitationDataBarrelDiameterAdd" runat="server" SkinID="TextBox" Style="width: 90px" ></asp:TextBox>                                                                                                                                                     
                                                                                            </td>
                                                                                            <td>                   
                                                                                                <asp:TextBox ID="tbxRehabilitationDataBarrelDepthAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox> 
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlRehabilitationDataRoundManholeRugsAdd" runat="server" DataMember="DefaultView"
                                                                                                    DataSourceID="odsRugs" DataTextField="ManholeRugs" DataValueField="ManholeRugsId"
                                                                                                    SkinID="DropDownListLookupBlueText" Style="width: 90px">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                      
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>                                                                                                
                                                                                               <asp:CustomValidator ID="cvRehabilitationDataChimneyDiameterAdd" runat="server" ControlToValidate="tbxRehabilitationDataChimneyDiameterAdd"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                                    OnServerValidate="cvRehabilitationDataChimneyDiameterAdd_ServerValidate" SkinID="Validator" ValidationGroup="AddManholeUpdate">
                                                                                               </asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                 <asp:CustomValidator ID="cvRehabilitationDataChimneyDepthAdd" runat="server" ControlToValidate="tbxRehabilitationDataChimneyDepthAdd"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                                    OnServerValidate="cvRehabilitationDataChimneyDepthAdd_ServerValidate" SkinID="Validator" ValidationGroup="AddManholeUpdate">
                                                                                               </asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                 <asp:CustomValidator ID="cvRehabilitationDataBarrelDiameterAdd" runat="server" ControlToValidate="tbxRehabilitationDataBarrelDiameterAdd"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)"
                                                                                                    OnServerValidate="cvRehabilitationDataBarrelDiameterAdd_ServerValidate" SkinID="Validator" ValidationGroup="AddManholeUpdate">
                                                                                                </asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataBarrelDepthAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataBarrelDepthAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataBarrelDepthAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px"></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                          
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationRectangularMHAdd" runat="server">                                                                               
                                                                                    <!-- Table element: 6 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>                                                                                        
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1LongSideAdd" runat="server" SkinID="Label" Text="Rectangle 1 Long Sider"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1ShortSideAdd" runat="server" SkinID="Label" Text="Rectangle 1 Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1DepthAdd" runat="server" SkinID="Label" Text="Rectangle 1 Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2LongSideAdd" runat="server" SkinID="Label" Text="Rectangle 2 Long Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2ShortSideAdd" runat="server" SkinID="Label" Text="Rectangle 2 Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2DepthAdd" runat="server" SkinID="Label" Text="Rectangle 2 Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangularManholeRugsAdd" runat="server" SkinID="LabelSmall" Text="Manhole Rugs"></asp:Label>                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1LongSideAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1ShortSideAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1DepthAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                                                                                                                    
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle2LongSideAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                                                            
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle2ShortSideAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>
                                                                                                 <asp:TextBox ID="tbxRehabilitationDataRectangle2DepthAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlRehabilitationDataRectangularManholeRugsAdd" runat="server" DataMember="DefaultView"
                                                                                                    DataSourceID="odsRugs" DataTextField="ManholeRugs" DataValueField="ManholeRugsId"
                                                                                                    SkinID="DropDownListLookupBlueText" Style="width: 90px" >
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle1LongSideAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle1LongSideAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle1LongSideAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                                </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle1ShortSideAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle1ShortSideAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle1ShortSideAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                                </td>
                                                                                            <td>                                                                                                
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle1DepthAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle1DepthAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle1DepthAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle2LongSideAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle2LongSideAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle2LongSideAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle2ShortSideAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle2ShortSideAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle2ShortSideAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangle2DepthAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangle2DepthAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangle2DepthAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                    
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px"></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationMixedMHAdd" runat="server">
                                                                                    <!-- Table element: 8 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRoundDiameterAdd" runat="server" SkinID="Label" Text="Round Diameter"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRoundDepthAdd" runat="server" SkinID="Label" Text="Round Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleLongSideAdd" runat="server" SkinID="Label" Text="Rectangle Long Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleShortSideAdd" runat="server" SkinID="Label" Text="Rectangle Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleDepthAdd" runat="server" SkinID="Label" Text="Rectangle Depth"></asp:Label>
                                                                                            </td>
                                                                                             <td>
                                                                                                <asp:Label ID="lblRehabilitationDataManholeRugsAdd" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRoundDiameterAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRoundDepthAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                                                                    
                                                                                            </td>
                                                                                            <td>                           
                                                                                               <asp:TextBox ID="tbxRehabilitationDataRectangleLongSideAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangleShortSideAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangleDepthAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                    
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:DropDownList ID="ddlRehabilitationDataMixManholeRugsAdd" runat="server" DataMember="DefaultView"
                                                                                                    DataSourceID="odsRugs" DataTextField="ManholeRugs" DataValueField="ManholeRugsId"
                                                                                                    SkinID="DropDownListLookupBlueText" Style="width: 90px" >
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>                                                                                                
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRoundDiameterAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRoundDiameterAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRoundDiameterAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRoundDepthAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRoundDepthAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRoundDepthAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangleLongSideAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangleLongSideAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangleLongSideAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangleShortSideAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangleShortSideAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangleShortSideAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataRectangleDepthAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataRectangleDepthAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataRectangleDepthAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="AddManholeUpdate"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                                                                                                                                                                             
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px">
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationOtherMHAdd" runat="server">   
                                                                                    <!-- Table element: 8 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td> </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataOtherStructureAdd" runat="server" SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataOtherStructureAdd" runat="server" SkinID="TextBox" Style="width: 90px"></asp:TextBox>                                                                                                                                   
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>                                          
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:CustomValidator ID="cvRehabilitationDataOtherStructureAdd" runat="server" 
                                                                                                    ControlToValidate="tbxRehabilitationDataOtherStructureAdd" Display="Dynamic" 
                                                                                                    ErrorMessage="Invalid format. (please use X'Y&quot;, or X&quot;, or Xft Yin, or X.Y, or X.Ym, or X.Ymm)" 
                                                                                                    OnServerValidate="cvRehabilitationDataOtherStructureAdd_ServerValidate" SkinID="Validator" 
                                                                                                    ValidationGroup="mrOtherStructure"></asp:CustomValidator>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px">
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>                                    
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </FooterTemplate>
                                                                    
                                                                    
                                                                    
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                            
                                                                            <tr>
                                                                                <td style="width: 10px; height: 10px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>                                                                                
                                                                                <td style="width: 190px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>                                                                            
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMhNoTitle" runat="server" SkinID="Label" Text="MH No"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblStreet" runat="server" SkinID="Label" Text="Street"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLatitude" runat="server" SkinID="Label" Text="Latitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLongitude" runat="server" SkinID="Label" Text="Longitude"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblShape" runat="server" SkinID="Label" Text="Shape"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblLocation" runat="server" SkinID="Label" Text="Location"></asp:Label>                                                                                    
                                                                                </td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMhId" runat="server" Text='<%# Eval("MHID") %>' Width="90px"
                                                                                        SkinID="TextBoxReadOnly" ReadOnly="true" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxStreet" runat="server" Text='<%# Eval("Address") %>' Width="180px"
                                                                                        SkinID="TextBoxReadOnly" ReadOnly="true" Autocomplete="Off"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxLatitude" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("Latitud") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxLongitude" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("Longitude") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                        
                                                                                </td>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxShape" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("ManholeShape") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                              
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxLocation" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("Location") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                                                                                                                  
                                                                                </td>                                                                               
                                                                            </tr>                                                                                  
                                                                             <tr>
                                                                                <td style="height: 7px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr> 
                                                                            <tr>        
                                                                                <td></td>                                                                        
                                                                                <td>
                                                                                    <asp:Label ID="lblRating" runat="server" SkinID="Label" Text="Condition Rating"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblMaterial" runat="server" SkinID="Label" Text="Material"></asp:Label>
                                                                                </td>
                                                                                <td>                                                                                   
                                                                                </td>
                                                                                <td> </td>
                                                                                <td></td>
                                                                                <td></td>                                                                               
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxConditionRating" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("ConditionRating") %>'
                                                                                            Width="90px" Autocomplete="Off"></asp:TextBox>                              
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMaterial" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text='<%# Eval("MaterialDescription") %>'
                                                                                            Width="180px" Autocomplete="Off"></asp:TextBox>                                                                                   
                                                                                </td>                                                                                
                                                                                <td colspan="4">                                                                                                                                                                            
                                                                                </td>                                                                                                                                                             
                                                                            </tr>                                                                                
                                                                            <tr>
                                                                                <td style="height: 10px"></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>                                                                
                                                                        </table>
                                                                        
                                                                        <asp:UpdatePanel ID="upnlShapes" runat="server">   
                                                                            <ContentTemplate> 
                                                                                <asp:Panel ID="pnlInformationRoundMH" runat="server">    
                                                                                    <!-- Table element: 8 columns structure information -->                                                                                                                                                          
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>                                                                                        
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td> </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataChimneyDiameter" runat="server" SkinID="Label" Text="Chimney Diameter"></asp:Label>          
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataChimneyDepth" runat="server" SkinID="Label" Text="Chimney Depth"></asp:Label>
                                                                                            </td>
                                                                                             <td>                          
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelDiameter" runat="server" SkinID="Label" Text="Barrel Diameter"></asp:Label> 
                                                                                            </td>
                                                                                            <td>                   
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelDepth" runat="server" SkinID="Label" Text="Barrel Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataBarrelManholeRugs" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>                                                            
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataChimneyDiameter" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true"  Style="width: 90px" Text='<%# Eval("TopDiameter") %>' ></asp:TextBox>                                                                                                                                    
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataChimneyDepth" runat="server" 
                                                                                                 SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("TopDepth") %>'></asp:TextBox>                                  
                                                                                            </td>
                                                                                            <td>          
                                                                                                <asp:TextBox ID="tbxRehabilitationDataBarrelDiameter" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("DownDiameter") %>'></asp:TextBox>                                                                                                                                                     
                                                                                            </td>
                                                                                            <td>                   
                                                                                                <asp:TextBox ID="tbxRehabilitationDataBarrelDepth" runat="server"
                                                                                                 SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("DownDepth") %>'></asp:TextBox> 
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRoundManholeRugs" Text='<%# Eval("ManholeRugs") %>'
                                                                                                runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px"></asp:TextBox>                                                                                                 
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                                                                                                             
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px"></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                          
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationRectangularMH" runat="server">                                                                               
                                                                                    <!-- Table element: 6 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>                                                                                        
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1LongSide" runat="server" SkinID="Label" Text="Rectangle 1 Long Sider"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1ShortSide" runat="server" SkinID="Label" Text="Rectangle 1 Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle1Depth" runat="server" SkinID="Label" Text="Rectangle 1 Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2LongSide" runat="server" SkinID="Label" Text="Rectangle 2 Long Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2ShortSide" runat="server" SkinID="Label" Text="Rectangle 2 Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangle2Depth" runat="server" SkinID="Label" Text="Rectangle 2 Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangularManholeRugs" runat="server" SkinID="LabelSmall" Text="Manhole Rugs"></asp:Label>                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1LongSide" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("Rectangle1LongSide") %>'></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1ShortSide" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("Rectangle1ShortSide") %>'></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle1Depth" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("TopDepth") %>'></asp:TextBox>                                                                                                                                                                                    
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle2LongSide" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("Rectangle2LongSide") %>'></asp:TextBox>                                                                                                                            
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangle2ShortSide" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("Rectangle2ShortSide") %>'></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>
                                                                                                 <asp:TextBox ID="tbxRehabilitationDataRectangle2Depth" runat="server" 
                                                                                                 SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("DownDepth") %>'></asp:TextBox>                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangularManholeRugs" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("ManholeRugs") %>'></asp:TextBox>                                                                                                                                                                                
                                                                                            </td>
                                                                                        </tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px"></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationMixedMH" runat="server">
                                                                                    <!-- Table element: 8 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRoundDiameter" runat="server" SkinID="Label" Text="Round Diameter"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRoundDepth" runat="server" SkinID="Label" Text="Round Depth"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleLongSide" runat="server" SkinID="Label" Text="Rectangle Long Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleShortSide" runat="server" SkinID="Label" Text="Rectangle Short Side"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataRectangleDepth" runat="server" SkinID="Label" Text="Rectangle Depth"></asp:Label>
                                                                                            </td>
                                                                                             <td>
                                                                                                <asp:Label ID="lblRehabilitationDataManholeRugs" runat="server" SkinID="Label" Text="Manhole Rugs"></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRoundDiameter" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("TopDiameter") %>'></asp:TextBox>                                                                                                                                
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRoundDepth" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("TopDepth") %>'></asp:TextBox>                                                                                                                                    
                                                                                            </td>
                                                                                            <td>                           
                                                                                               <asp:TextBox ID="tbxRehabilitationDataRectangleLongSide" runat="server" 
                                                                                               SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("Rectangle2LongSide") %>'></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangleShortSide" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("Rectangle2ShortSide") %>'></asp:TextBox>                                
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:TextBox ID="tbxRehabilitationDataRectangleDepth" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("DownDepth") %>'></asp:TextBox>                                                                                    
                                                                                            </td>
                                                                                            <td>        
                                                                                                <asp:TextBox ID="tbxRehabilitationDataMixManholeRugs" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("ManholeRugs") %>'></asp:TextBox>                                                                                                                                                                                    
                                                                                            </td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                                                                                                                                                                                                                                                                 
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px">
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>
                                                                                
                                                                                <asp:Panel ID="pnlInformationOtherMH" runat="server">   
                                                                                    <!-- Table element: 8 columns structure information -->                                                                               
                                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 10px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 100px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="8">
                                                                                                <!-- Page element : Horizontal Rule -->
                                                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 10px">
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td> </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblRehabilitationDataOtherStructure" runat="server" SkinID="Label" Text="Total Surface Area"></asp:Label>
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxRehabilitationDataOtherStructure" runat="server" 
                                                                                                SkinID="TextBoxReadOnly" ReadOnly="true" Style="width: 90px" Text='<%# Eval("TotalSurfaceArea") %>'></asp:TextBox>                                                                                                                                   
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>                                                                                                                                  
                                                                                        <tr>
                                                                                            <td></td>
                                                                                            <td style="height: 10px">
                                                                                            </td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                            <td></td>
                                                                                        </tr>
                                                                                    </table>                                                                           
                                                                                     
                                                                                </asp:Panel>                                    
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="700px"></HeaderStyle>                                                                    
                                                                </asp:TemplateField> 
                                                                
                                                                
                                                                
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" 
                                                                                            CommandName="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" 
                                                                                            CommandName="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" 
                                                                                       CommandName="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                    </asp:ImageButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" 
                                                                                            CommandName="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" 
                                                                                            CommandName="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this manhole?");'>
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>

                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:ObjectDataSource ID="odsAddManholeNew" runat="server" FilterExpression="(Deleted = 0)"
                                                SelectMethod="GetAddManholeNew" 
                                                TypeName="LiquiForce.LFSLive.WebUI.CWP.Common.add_manhole"
                                                DeleteMethod="DummyManholeNew" InsertMethod="DummyManholeNew" UpdateMethod="DummyManholeNew" >
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="Summary" runat="server" Title="Finish" >                           
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="240px" Width="100%" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                
                            </asp:WizardStep>
                        </WizardSteps>
                        
                        
                        
                        <FinishNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 230px">
                                <tr>                                    
                                    <td style="width: 60px; text-align: right">
                                    </td>
                                    <td style="width: 90px; text-align: right;">
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="FinishButton" Style="width: 80px" runat="server" CommandName="MoveComplete"
                                            Text="Finish" SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" SkinID="Button" EnableViewState="False" />
                                    </td>
                                </tr>
                            </table>
                        </FinishNavigationTemplate>
                    </asp:Wizard>                    
                </td>
            </tr>
        </table>

         <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                    
                    <asp:ObjectDataSource ID="odsShape" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHShapeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="shape" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                  
                                        
                    <asp:ObjectDataSource ID="odsLocation" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHLocationList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="location" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsRugs" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHRugsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="manholeRugsId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="manholeRugs" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsConditionRating" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.CWP.Assets.LfsAssetSewerMHConditionRatingList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="conditionRatingId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="conditionRating" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterialType" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Assets.Assets.AssetSewerMHMaterialTypeList">
                        <SelectParameters>                            
                            <asp:Parameter DefaultValue="-1" Name="materialId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="materialType" Type="String" />
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
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" /><asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfSearchTitle" runat="server" />
                    <asp:HiddenField ID="hdfTag" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>