<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyForm.aspx.cs" Inherits="WelfareSurvey.SurveyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <link href="Styles/datepicker.min.css" rel="stylesheet" />
    <title>Welfare Survey</title>
    <script type="text/javascript">
        function jsValidateNum(obj) {
            if (isNaN(obj.value)) {
                alert('Invalid Number');
                obj.value = ''
                obj.focus()
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <fieldset>
                <legend>Employee Details Form</legend>
                <div>
                    Name
                </div>
                <div>
                    <asp:TextBox ID="txtName" runat="server" CssClass="formfield" placeholder="Name" Enabled="false"></asp:TextBox>
                </div>
                <div>
                    EPF
                </div>
                <div>
                    <asp:TextBox ID="txtEPF" runat="server" CssClass="formfield" placeholder="EPF" Enabled="false"></asp:TextBox>
                </div>

                <div>
                    Branch
                </div>
                <div>
                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="formfield" Width="200px">
                    </asp:DropDownList>

                </div>
                <div>
                    Residential Address
                </div>
                <div>
                    <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="formfield" placeholder="Line 1"></asp:TextBox><br />
                    <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="formfield" placeholder="Line 2"></asp:TextBox><br />
                    <asp:TextBox ID="txtAddressLine3" runat="server" CssClass="formfield" placeholder="Line 3"></asp:TextBox>
                </div>

                <div>
                    Sex
                </div>
                <div>
                    <asp:RadioButton ID="rbtnMale" runat="server" GroupName="grpSex" Text="Male" />
                    <asp:RadioButton ID="rbtnFemale" runat="server" GroupName="grpSex" Text="Female" />
                </div>
                <div>
                    Maritial Status
                </div>
                <div>
                    <asp:RadioButton ID="rbtnMaritialStatusSingle" runat="server" GroupName="grpMaritial" Text="Single" AutoPostBack="true" OnCheckedChanged="rbtnMaritialStatusSingle_CheckedChanged" />
                    <asp:RadioButton ID="rbtnMaritialStatusMarried" runat="server" GroupName="grpMaritial" Text="Married" AutoPostBack="true" OnCheckedChanged="rbtnMaritialStatusMarried_CheckedChanged" />
                </div>

                <div>



                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pnlFamilyMemberDetails" runat="server" Visible="false">
                                <div>
                                    Name of Spouse
                                </div>
                                <div>
                                    <asp:TextBox ID="txtNameOfSpouse" runat="server" CssClass="formfield" placeholder="Name of Spouse"></asp:TextBox>
                                </div>

                                <div>
                                    No. of Children
                                </div>
                                <div>
                                    <asp:TextBox ID="txtNoOfChildren" runat="server" CssClass="formfield" placeholder="No. of Children" OnTextChanged="txtNoOfChildren_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </div>
                         
                                        <asp:Panel ID="pnlChildren" runat="server" Visible="false">
                                            <div>
                                                Children Details
                                            </div>
                                            <div>
                                                <asp:GridView ID="grdChildren" runat="server" AutoGenerateColumns="False"
                                                   OnSelectedIndexChanged="grdChildren_SelectedIndexChanged" OnRowDataBound="grdChildren_RowDataBound" OnRowDeleting="grdChildren_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Name">

                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtName" runat="server" Width="350px" Text='<%# Eval("NAME") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Birth">

                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtDateOfBirth" AutoCompleteType="None" Width="100px"  Text='<%# Eval("DOB") %>'
                                                                    class="calendar_Textbox" />
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDateOfBirth"
                                                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                                                    ErrorTooltipEnabled="True" />
                                                                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                                                    ControlToValidate="txtDateOfBirth" EmptyValueMessage="Date is required" InvalidValueMessage="Date is invalid"
                                                                    Display="Dynamic" TooltipMessage="" EmptyValueBlurredText="Date is invalid" InvalidValueBlurredMessage="Date is invalid"
                                                                    ValidationGroup="MKE" />
                                                                <ajaxToolkit:CalendarExtender ID="txtDateOfBirthExtender" runat="server" TargetControlID="txtDateOfBirth"
                                                                    CssClass="MyCalendar" PopupButtonID="ImageButton3" Format="dd/MM/yyyy" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Sex" ControlStyle-Width="100px">

                                                            <ItemTemplate>
                                                                  <asp:TextBox ID="txtSex" Visible="false" runat="server" Width="350px" Text='<%# Eval("SEX") %>'></asp:TextBox>
                                                                <asp:RadioButton ID="rbtnChildMale" runat="server" GroupName="grpChildSex" Text="Male" />
                                                                <asp:RadioButton ID="rbtnChildFemale" runat="server" GroupName="grpChildSex" Text="Female" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </asp:Panel>


                                
                            </asp:Panel>


                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="rbtnMaritialStatusSingle" />
                            <asp:AsyncPostBackTrigger ControlID="rbtnMaritialStatusMarried" />
                            
                            <asp:AsyncPostBackTrigger ControlID="txtNoOfChildren" />
                        </Triggers>
                    </asp:UpdatePanel>



                </div>



                <div>

                    <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Class="button" OnClick="btnSubmit_Click" />
                </div>


            </fieldset>

        </div>

    </form>
</body>
</html>

