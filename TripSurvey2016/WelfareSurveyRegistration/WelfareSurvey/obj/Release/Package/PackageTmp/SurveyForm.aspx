<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyForm.aspx.cs" Inherits="WelfareSurvey.SurveyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="Styles/StyleSheet.css" rel="stylesheet" />--%>
    <link href="Styles/datepicker.min.css" rel="stylesheet" />
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <%--<link href="Styles/neon.css" rel="stylesheet" />--%>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap-datepicker.js" type="text/javascript"></script>


    <title>Welfare Survey</title>
    <%--    <script type="text/javascript">
        $(document).ready(function () {
            $('input[id^="txt"]').prop("disabled", true);
        });
    </script>--%>
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
                <legend>Employee Attendance Form</legend>
                <table>
                    <tr>
                        <td>Company</td>
                        <td>
                            <asp:TextBox ID="txtCompany" runat="server" CssClass="formfield" Enabled="false"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>EPF</td>
                        <td>
                            <asp:TextBox ID="txtEPF" runat="server" CssClass="formfield" Enabled="false"></asp:TextBox></td>
                    </tr>
                </table>


                <table>
                    <thead>
                        <tr>
                            <th></th>
                            <th style="text-align: center">Name</th>
                            <th style="text-align: center">Child Gender</th>
                            <th style="text-align: center">Child Age Category</th>

                            <th style="text-align: center; width: 200px;">Attended / Not Attended</th>
                        </tr>
                    </thead>
                    <tbody>

                        <tr>
                            <td>Member</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" CssClass="formfield" placeholder="Name" Enabled="false"></asp:TextBox></td>
                            <td></td>
                            <td></td>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkMemberAttended" CssClass="formfield" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Spouse</td>
                            <td>
                                <asp:TextBox ID="txtNameOfSpouse" runat="server" CssClass="formfield" Enabled="false" placeholder="Name of Spouse"></asp:TextBox>
                            </td>
                            <td></td>
                            <td></td>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkSpouseAttended" CssClass="formfield" runat="server" /></td>
                        </tr>
                        <tr>

                            <td>Child 1</td>
                            <td>
                                <asp:TextBox ID="txtCH1Name" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtCH1Sex" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtCH1AgeCategory" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox>


                            </td>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkChild1Attended" CssClass="formfield" runat="server" /></td>
                        </tr>


                        <tr>
                            <td>Child 2</td>
                            <td>
                                <asp:TextBox ID="txtCH2Name" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtCH2Sex" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtCH2AgeCategory" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox>


                            </td>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkChild2Attended" CssClass="formfield" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Child 3</td>
                            <td>
                                <asp:TextBox ID="txtCH3Name" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtCH3Sex" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>

                            <td>
                                <asp:TextBox ID="txtCH3AgeCategory" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox>


                            </td>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkChild3Attended" CssClass="formfield" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Child 4</td>
                            <td>
                                <asp:TextBox ID="txtCH4Name" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtCH4Sex" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>

                            <td>
                                <asp:TextBox ID="txtCH4AgeCategory" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox>


                            </td>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkChild4Attended" CssClass="formfield" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Child 5</td>
                            <td>
                                <asp:TextBox ID="txtCH5Name" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtCH5Sex" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>


                            <td>
                                <asp:TextBox ID="txtCH5AgeCategory" CssClass="formfield" runat="server" Enabled="false"></asp:TextBox></td>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkChild5Attended" CssClass="formfield" runat="server" /></td>
                        </tr>
                    </tbody>
                </table>

            </fieldset>
        </div>



        <div style="text-align: center; width: 100%;">

            <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Class="button" OnClick="btnSubmit_Click" Style="text-align: center;" />
            <asp:Button ID="btnBack" runat="server" Text="Back" Class="button" OnClick="btnBack_Click" Style="text-align: center;" />


        </div>




    </form>
</body>
</html>

