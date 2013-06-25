<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" CodeBehind="fl_field_cure_records.aspx.cs" 
Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_field_cure_records" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 1000px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard id="wizard" runat="server" ActiveStepIndex="0" SkinID="Wizard" Width="100%" Height="360px" DisplaySideBar="False" DisplayCancelButton="True" OnActiveStepChanged="Wizard_ActiveStepChanged" OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnNextButtonClick="Wizard_NextButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            
                            <asp:WizardStep ID="Begin" runat="server" Title="Begin" StepType="Start">                                
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 1000px">                                    
                                    <tr>
                                        <td >
                                            <asp:Label ID="lblFieldCureRecordTitle" runat="server" EnableViewState="False" SkinID="Label" Text="Please provide field cure record information. "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlFieldCureRecord" runat="server" Height="330px" Width="1000px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlFieldCureRecord" runat="server">
                                                    <contenttemplate>
                                                        <!-- Page element: 1 column - Grid FieldCureRecord -->
                                                        <asp:GridView ID="grdFieldCureRecord" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False"
                                                            AllowPaging="True" PageSize="10" ShowFooter="True" OnDataBound="grdFieldCureRecord_DataBound"
                                                            OnRowCommand="grdFieldCureRecord_RowCommand" OnRowUpdating="grdFieldCureRecord_RowUpdating" OnRowEditing="grdFieldCureRecord_RowEditing"
                                                            OnRowDeleting="grdFieldCureRecord_RowDeleting" OnRowDataBound="grdFieldCureRecord_RowDataBound"
                                                            DataKeyNames="WorkID, RefID" DataSourceID="odsFieldCureRecord">
                                                            <Columns>
                                                                                      
                                                                <%--ids--%>                                                                
                                                                <asp:TemplateField Visible="False" HeaderText="No">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblWorkIdEdit" runat="server" SkinID="Label" Text='<%# Eval("WorkID") %>' Width="30px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblWorkIdFooter" runat="server" SkinID="Label" Text='<%# Eval("WorkID") %>' Width="30px"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWorkId" runat="server"  SkinID="Label" Text='<%# Eval("WorkID") %>' Width="30px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField Visible="False" HeaderText="No">                 
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRefIdEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>' Width="30px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblRefIdFooter" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>' Width="30px"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRefId" runat="server"  SkinID="Label" Text='<%# Eval("RefID") %>' Width="30px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <%--Data--%>                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Reading Time">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdfReadingTimeEdit" runat="server" Value='<%# Eval("ReadingTime") %>' />                                                            
                                                                                    <asp:UpdatePanel id="upReadingTimeEdit" runat="server" UpdateMode="Conditional">
                                                                                        <contenttemplate>
                                                                                            <asp:DropDownList ID="ddlReadingTimeHourEdit" runat="server" SkinID="DropDownList" Style="width: 40px" >
                                                                                                <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                                                <asp:ListItem Value="0">0</asp:ListItem>
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
                                                                                                <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                <asp:ListItem Value="23">23</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:Label ID="lblReadingTimeDotsEdit" runat="server" EnableViewState="False" 
                                                                                                SkinID="Label" Text=" : " Width="6px"></asp:Label>
                                                                                            <asp:DropDownList ID="ddlReadingTimeMinuteEdit" runat="server" SkinID="DropDownList" Style="width: 40px">
                                                                                                <asp:ListItem Value=" "></asp:ListItem>
                                                                                                <asp:ListItem Value="00">00</asp:ListItem>
                                                                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                                                                <asp:ListItem Value="09">09</asp:ListItem>
                                                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                                                                <asp:ListItem Value="13">13</asp:ListItem>
                                                                                                <asp:ListItem Value="14">14</asp:ListItem>
                                                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                <asp:ListItem Value="23">23</asp:ListItem>
                                                                                                <asp:ListItem Value="24">24</asp:ListItem>
                                                                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                                                                <asp:ListItem Value="26">26</asp:ListItem>
                                                                                                <asp:ListItem Value="27">27</asp:ListItem>
                                                                                                <asp:ListItem Value="28">28</asp:ListItem>
                                                                                                <asp:ListItem Value="29">29</asp:ListItem>
                                                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                <asp:ListItem Value="30">31</asp:ListItem>
                                                                                                <asp:ListItem Value="30">32</asp:ListItem>
                                                                                                <asp:ListItem Value="30">33</asp:ListItem>
                                                                                                <asp:ListItem Value="30">34</asp:ListItem>
                                                                                                <asp:ListItem Value="30">35</asp:ListItem>
                                                                                                <asp:ListItem Value="30">36</asp:ListItem>
                                                                                                <asp:ListItem Value="30">37</asp:ListItem>
                                                                                                <asp:ListItem Value="30">38</asp:ListItem>
                                                                                                <asp:ListItem Value="30">39</asp:ListItem>
                                                                                                <asp:ListItem Value="30">40</asp:ListItem>
                                                                                                <asp:ListItem Value="30">41</asp:ListItem>
                                                                                                <asp:ListItem Value="30">42</asp:ListItem>
                                                                                                <asp:ListItem Value="30">43</asp:ListItem>
                                                                                                <asp:ListItem Value="30">44</asp:ListItem>
                                                                                                <asp:ListItem Value="30">45</asp:ListItem>
                                                                                                <asp:ListItem Value="30">46</asp:ListItem>
                                                                                                <asp:ListItem Value="30">47</asp:ListItem>
                                                                                                <asp:ListItem Value="30">48</asp:ListItem>
                                                                                                <asp:ListItem Value="30">49</asp:ListItem>
                                                                                                <asp:ListItem Value="30">50</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">51</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">52</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">53</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">54</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">55</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">56</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">57</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">58</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">59</asp:ListItem>                                                               
                                                                                            </asp:DropDownList>               
                                                                                        </contenttemplate>           
                                                                                    </asp:UpdatePanel>       
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvReadingTimeHourEdit" runat="server" SkinID="Validator" EnableViewState="True"
                                                                                            ValidationGroup="dataEdit" ErrorMessage="Please select the hours."
                                                                                            Display="Dynamic" ControlToValidate="ddlReadingTimeHourEdit"  InitialValue=" "></asp:RequiredFieldValidator>
                                                                                    <asp:RequiredFieldValidator ID="rfvReadingTimeMinuteEdit" runat="server" SkinID="Validator" EnableViewState="True"
                                                                                            ValidationGroup="dataEdit" ErrorMessage="Please select the minutes."
                                                                                            Display="Dynamic" ControlToValidate="ddlReadingTimeMinuteEdit"  InitialValue=" "></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdfReadingTimeFooter" runat="server" Value='<%# Eval("ReadingTime") %>' />                                                            
                                                                                    <asp:UpdatePanel id="upReadingTimeFooter" runat="server" UpdateMode="Conditional">
                                                                                        <contenttemplate>
                                                                                            <asp:DropDownList ID="ddlReadingTimeHourFooter" runat="server" SkinID="DropDownList" Style="width: 40px" >
                                                                                                <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                                                <asp:ListItem Value="0">0</asp:ListItem>
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
                                                                                                <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                <asp:ListItem Value="23">23</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:Label ID="lblReadingTimeDotsFooter" runat="server" EnableViewState="False" 
                                                                                                SkinID="Label" Text=" : " Width="6px"></asp:Label>
                                                                                            <asp:DropDownList ID="ddlReadingTimeMinuteFooter" runat="server" SkinID="DropDownList" Style="width: 40px">
                                                                                                <asp:ListItem Value=" "></asp:ListItem>
                                                                                                <asp:ListItem Value="00">00</asp:ListItem>
                                                                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                                                                <asp:ListItem Value="09">09</asp:ListItem>
                                                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                                                                <asp:ListItem Value="13">13</asp:ListItem>
                                                                                                <asp:ListItem Value="14">14</asp:ListItem>
                                                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                <asp:ListItem Value="23">23</asp:ListItem>
                                                                                                <asp:ListItem Value="24">24</asp:ListItem>
                                                                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                                                                <asp:ListItem Value="26">26</asp:ListItem>
                                                                                                <asp:ListItem Value="27">27</asp:ListItem>
                                                                                                <asp:ListItem Value="28">28</asp:ListItem>
                                                                                                <asp:ListItem Value="29">29</asp:ListItem>
                                                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                <asp:ListItem Value="30">31</asp:ListItem>
                                                                                                <asp:ListItem Value="30">32</asp:ListItem>
                                                                                                <asp:ListItem Value="30">33</asp:ListItem>
                                                                                                <asp:ListItem Value="30">34</asp:ListItem>
                                                                                                <asp:ListItem Value="30">35</asp:ListItem>
                                                                                                <asp:ListItem Value="30">36</asp:ListItem>
                                                                                                <asp:ListItem Value="30">37</asp:ListItem>
                                                                                                <asp:ListItem Value="30">38</asp:ListItem>
                                                                                                <asp:ListItem Value="30">39</asp:ListItem>
                                                                                                <asp:ListItem Value="30">40</asp:ListItem>
                                                                                                <asp:ListItem Value="30">41</asp:ListItem>
                                                                                                <asp:ListItem Value="30">42</asp:ListItem>
                                                                                                <asp:ListItem Value="30">43</asp:ListItem>
                                                                                                <asp:ListItem Value="30">44</asp:ListItem>
                                                                                                <asp:ListItem Value="30">45</asp:ListItem>
                                                                                                <asp:ListItem Value="30">46</asp:ListItem>
                                                                                                <asp:ListItem Value="30">47</asp:ListItem>
                                                                                                <asp:ListItem Value="30">48</asp:ListItem>
                                                                                                <asp:ListItem Value="30">49</asp:ListItem>
                                                                                                <asp:ListItem Value="30">50</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">51</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">52</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">53</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">54</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">55</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">56</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">57</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">58</asp:ListItem>                                                                
                                                                                                <asp:ListItem Value="30">59</asp:ListItem>                                                               
                                                                                            </asp:DropDownList>               
                                                                                        </contenttemplate>           
                                                                                    </asp:UpdatePanel> 
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="rfvReadingTimeHourFooter" runat="server" SkinID="Validator" EnableViewState="True"
                                                                                            ValidationGroup="dataEdit" ErrorMessage="Please select the hours"
                                                                                            Display="Dynamic" ControlToValidate="ddlReadingTimeHourFooter"  InitialValue=" "></asp:RequiredFieldValidator>
                                                                                    <asp:RequiredFieldValidator ID="rfvReadingTimeMinuteFooter" runat="server" SkinID="Validator" EnableViewState="True"
                                                                                            ValidationGroup="dataEdit" ErrorMessage="Please select the minutes"
                                                                                            Display="Dynamic" ControlToValidate="ddlReadingTimeMinuteFooter"  InitialValue=" "></asp:RequiredFieldValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblReadingTime" runat="server" SkinID="Label" Text='<%# Eval("ReadingTime") %>' Width="90px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                                                                                               
                                                                                                                                 
                                                                <asp:TemplateField  Visible="True" HeaderText="Head Ft">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxHeadFtEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("HeadFt"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvLbUsgEdit" runat="server" ControlToValidate="tbxHeadFtEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxHeadFtFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvHeadFtFooter" runat="server" ControlToValidate="tbxHeadFtFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblHeadFt" runat="server" SkinID="Label" Text='<%# GetRound(Eval("HeadFt"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Boiler In F">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxBoilerInFEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("BoilerInF"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvBoilerInFEdit" runat="server" ControlToValidate="tbxBoilerInFEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxBoilerInFFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvBoilerInFFooter" runat="server" ControlToValidate="tbxBoilerInFFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblBoilerInF" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BoilerInF"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>              
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Boiler Out F">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxBoilerOutFEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("BoilerOutF"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvBoilerOutFEdit" runat="server" ControlToValidate="tbxBoilerOutFEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxBoilerOutFFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvBoilerOutFFooter" runat="server" ControlToValidate="tbxBoilerOutFFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblBoilerOutF" runat="server" SkinID="Label" Text='<%# GetRound(Eval("BoilerOutF"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                                                              
                                                                                                                                                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Pump Flow">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxPumpFlowEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("PumpFlow"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvPumpFlowEdit" runat="server" ControlToValidate="tbxPumpFlowEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxPumpFlowFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvPumpFlowFooter" runat="server" ControlToValidate="tbxPumpFlowFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblPumpFlow" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PumpFlow"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Pump psi">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxPumpPsiEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("PumpPsi"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvPumpPsiEdit" runat="server" ControlToValidate="tbxPumpPsiEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxPumpPsiFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvPumpPsiFooter" runat="server" ControlToValidate="tbxPumpPsiFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblPumpPsi" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PumpPsi"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Top">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH1TopEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH1Top"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH1TopEdit" runat="server" ControlToValidate="tbxMH1TopEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH1TopFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH1TopFooter" runat="server" ControlToValidate="tbxMH1TopFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                      
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH1Top" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH1Top"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Bot">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH1BotEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH1Bot"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH1BotEdit" runat="server" ControlToValidate="tbxMH1BotEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH1BotFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH1BotFooter" runat="server" ControlToValidate="tbxMH1BotFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH1Bot" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH1Bot"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Top">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH2TopEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH2Top"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH2TopEdit" runat="server" ControlToValidate="tbxMH2TopEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH2TopFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH2TopFooter" runat="server" ControlToValidate="tbxMH2TopFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH2Top" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH2Top"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>   
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Bot">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH2BotEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH2Bot"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH2BotEdit" runat="server" ControlToValidate="tbxMH2BotEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH2BotFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH2BotFooter" runat="server" ControlToValidate="tbxMH2BotFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH2Bot" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH2Bot"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>   
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Top">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH3TopEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH3Top"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH3TopEdit" runat="server" ControlToValidate="tbxMH3TopEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH3TopFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH3TopFooter" runat="server" ControlToValidate="tbxMH3TopFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH3Top" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH3Top"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Bot">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH3BotEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH3Bot"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH3BotEdit" runat="server" ControlToValidate="tbxMH3BotEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH3BotFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH3BotFooter" runat="server" ControlToValidate="tbxMH3BotFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH3Bot" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH3Bot"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Top">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH4TopEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH4Top"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH4TopEdit" runat="server" ControlToValidate="tbxMH4TopEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH4TopFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH4TopFooter" runat="server" ControlToValidate="tbxMH4TopFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH4Top" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH4Top"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="MH # Bot">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxMH4BotEdit" runat="server" SkinID="TextBox" Text='<%# GetRound(Eval("MH4Bot"),2) %>' Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvMH4BotEdit" runat="server" ControlToValidate="tbxMH4BotEdit"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataEdit"></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxMH4BotFooter" runat="server" SkinID="TextBox"  Width="40px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                                    
                                                                                    <asp:CompareValidator ID="cvMH4BotFooter" runat="server" ControlToValidate="tbxMH4BotFooter"
                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Double" ValidationGroup="dataFooter"></asp:CompareValidator>
                                                                               </td>
                                                                            </tr>                                                                      
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblMH4Bot" runat="server" SkinID="Label" Text='<%# GetRound(Eval("MH4Bot"),2) %>' Width="40px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                
                                                                <asp:TemplateField  Visible="True" HeaderText="Comments">
                                                                    <HeaderStyle Width="190px"></HeaderStyle>                                                                    
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                     <asp:TextBox ID="tbxCommentsEdit" runat="server" SkinID="TextBox" TextMode="MultiLine" Rows="2"  Text='<%# Eval("Comments") %>' Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>                                                                                                                                             
                                                                        </table>                                                                         
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxCommentsFooter" runat="server" SkinID="TextBox" TextMode="MultiLine" Rows="2"  Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>                                                                                                                                                 
                                                                        </table>                                                                        
                                                                    </FooterTemplate>                                                                                                                                                                                                                                                                             
                                                                    
                                                                    <ItemTemplate>                                                                        
                                                                        <asp:Label ID="lblComments" runat="server" SkinID="Label" ToolTip='<%# Eval("Comments") %>'   Text='<%# Eval("Comments") %>' Width="180px"></asp:Label>
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
                                                                    <HeaderStyle Width="40px"></HeaderStyle>
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
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this field cure record?");'>
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </contenttemplate>
                                                </asp:UpdatePanel>                                                        
                                            </asp:Panel>
                                        </td>                                        
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsFieldCureRecord" runat="server" FilterExpression="(Deleted = 0)"
                                                            SelectMethod="GetFieldCureRecordNew" 
                                                            TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_field_cure_records"
                                                            DeleteMethod="DummyFieldCureRecordNew" InsertMethod="DummyFieldCureRecordNew" UpdateMethod="DummyFieldCureRecordNew" >
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                    </tr>
                                </table>
                                
                            </asp:WizardStep>
                            
                            <asp:WizardStep ID="Summary" runat="server" Title="Finish" >
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 730px">
                                    <tr>
                                        <td >
                                            <asp:TextBox ID="tbxSummary" runat="server" Width="900px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="25"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>                                    
                                </table>
                            </asp:WizardStep>
                                                        
                        </WizardSteps>
                        
                        
                       <FinishNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 730px">
                                <tr>                                    
                                    <td style="width: 460px; text-align: right">
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
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfUpdate" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfRunDetails" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                </td>
            </tr>
        </table>
               
    </div>
</asp:Content>