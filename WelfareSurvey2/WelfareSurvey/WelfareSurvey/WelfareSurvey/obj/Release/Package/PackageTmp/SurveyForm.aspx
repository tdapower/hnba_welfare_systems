<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyForm.aspx.cs" Inherits="WelfareSurvey.SurveyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <link href="Styles/datepicker.min.css" rel="stylesheet" />
    <%--<link href="Styles/neon.css" rel="stylesheet" />--%>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap-datepicker.js" type="text/javascript"></script>


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

    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtCH1DOB").datepicker();
            $("#txtCH2DOB").datepicker();
            $("#txtCH3DOB").datepicker();
            $("#txtCH4DOB").datepicker();
            $("#txtCH5DOB").datepicker();
        });
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
                    Company *<br />
                </div>
                <br />
                <div>
                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="formfield"></asp:DropDownList>

                </div>
                <div>
                    Name *
                </div>
                <div>
                    <asp:TextBox ID="txtName" runat="server" CssClass="formfield" placeholder="Name"></asp:TextBox>
                </div>
                <div>
                    EPF *
                </div>
                <div>
                    <asp:TextBox ID="txtEPF" runat="server" CssClass="formfield" placeholder="EPF" MaxLength="6"></asp:TextBox>
                </div>

                <div>
                    Branch *
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
                    Sex *
                </div>
                <div>
                    <asp:RadioButton ID="rbtnMale" runat="server" GroupName="grpSex" Text="Male" />
                    <asp:RadioButton ID="rbtnFemale" runat="server" GroupName="grpSex" Text="Female" />
                </div>
                <div>
                    Maritial Status *
                </div>
                <div>
                    <asp:RadioButton ID="rbtnMaritialStatusSingle" runat="server" GroupName="grpMaritial" Text="Single" />
                    <asp:RadioButton ID="rbtnMaritialStatusMarried" runat="server" GroupName="grpMaritial" Text="Married" />
                </div>

                <div>

                    <asp:Panel ID="pnlFamilyMemberDetails" runat="server">
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
                            <asp:TextBox ID="txtNoOfChildren" runat="server" CssClass="formfield" placeholder="No. of Children"></asp:TextBox>
                        </div>
                </div>
                <asp:Panel ID="pnlChildren" runat="server">
                    <div>
                        Children Details
                    </div>
                    <div>

                        <table border="1">
                            <tr>
                                <td style="width: 250px;">Name
                                </td>

                                <td>Sex                  </td>

                                <td style="width: 60px;">Date of Birth</td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCH1Name" runat="server" placeholder="Name" Style="width: 95%;"></asp:TextBox></td>

                                <td>
                                    <asp:RadioButton ID="rbtnCH1Male" runat="server" GroupName="grpCH1Sex" Text="Male" />
                                    <asp:RadioButton ID="rbtnCH1Female" runat="server" GroupName="grpCH1Sex" Text="Female" /></td>

                                <td>
                                    <asp:TextBox ID="txtCH1DOB" runat="server" data-format="dd/mm/yyyy"></asp:TextBox>

                                    <%--<input type="date" name="bday" />--%>
                                    <%--<input type="date" id="Input1" runat="server" />--%>

                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCH2Name" runat="server" Style="width: 95%;" placeholder="Name"></asp:TextBox></td>

                                <td>
                                    <asp:RadioButton ID="rbtnCH2Male" runat="server" GroupName="grpCH2Sex" Text="Male" />
                                    <asp:RadioButton ID="rbtnCH2Female" runat="server" GroupName="grpCH2Sex" Text="Female" /></td>

                                <td>
                                    <asp:TextBox ID="txtCH2DOB" runat="server" data-format="dd/mm/yyyy"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCH3Name" runat="server" Style="width: 95%;" placeholder="Name"></asp:TextBox></td>

                                <td>
                                    <asp:RadioButton ID="rbtnCH3Male" runat="server" GroupName="grpCH3Sex" Text="Male" />
                                    <asp:RadioButton ID="rbtnCH3Female" runat="server" GroupName="grpCH3Sex" Text="Female" /></td>

                                <td>
                                    <asp:TextBox ID="txtCH3DOB" runat="server" data-format="dd/mm/yyyy"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCH4Name" runat="server" Style="width: 95%;" placeholder="Name"></asp:TextBox></td>

                                <td>
                                    <asp:RadioButton ID="rbtnCH4Male" runat="server" GroupName="grpCH4Sex" Text="Male" />
                                    <asp:RadioButton ID="rbtnCH4Female" runat="server" GroupName="grpCH4Sex" Text="Female" /></td>

                                <td>
                                    <asp:TextBox ID="txtCH4DOB" runat="server" data-format="dd/mm/yyyy"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCH5Name" runat="server" Style="width: 95%;" placeholder="Name"></asp:TextBox></td>

                                <td>
                                    <asp:RadioButton ID="rbtnCH5Male" runat="server" GroupName="grpCH5Sex" Text="Male" />
                                    <asp:RadioButton ID="rbtnCH5Female" runat="server" GroupName="grpCH5Sex" Text="Female" /></td>

                                <td>
                                    <asp:TextBox ID="txtCH5DOB" runat="server" data-format="dd/mm/yyyy"></asp:TextBox></td>
                            </tr>

                        </table>


                    </div>
                </asp:Panel>
            </asp:Panel>


                   



        </div>



        <div style="text-align:center;width:100%;">

            <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Class="button" OnClick="btnSubmit_Click" Style="text-align: center;" />
        </div>


        </fieldset>

        </div>

    </form>
</body>
</html>

