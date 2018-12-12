<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyForm.aspx.cs" Inherits="WelfareTripSurvey.SurveyForm" %>


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
                <legend>Survey Form</legend>




                <div>
                    <table>
                        <tr>
                            <td>Trip to Local Five Star Hotel

                            </td>


                            <td>Foreign Tour

                            </td>
                        </tr>

                        <tr>
                            <td>Can bring family members</td>


                            <td>Only for staff welfare members</td>
                        </tr>

                        <tr>
                            <td>2 days 1 night</td>


                            <td>3 days 2 nights</td>
                        </tr>

                        <tr>
                            <td></td>


                            <td></td>
                        </tr>

                        <tr>
                            <td></td>


                            <td></td>
                        </tr>

                        <tr>
                            <td></td>


                            <td></td>
                        </tr>

                        <tr>
                            <td></td>


                            <td></td>
                        </tr>

                        <tr>
                            <td></td>


                            <td></td>
                        </tr>

                        <tr>
                            <td></td>


                            <td></td>
                        </tr>



                    </table>



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

