<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advisors.aspx.cs" Inherits="WelareTshirt.advisors" %>

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
                <legend>Employee Consent Request Form for Welfare T-Shirt</legend>
                <div>
                    Company
                </div>
                <div>
                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="formfield" Width="200px">
                    </asp:DropDownList>
                </div>

                <div>
                    Branch Code
                </div>
                <div>
                    <asp:TextBox ID="txtBranchCode" runat="server" CssClass="formfield" Enabled="false"></asp:TextBox>
                </div>


                <div>
                    EPF
                </div>
                <div>
                    <asp:DropDownList ID="ddlAdvisorCode" runat="server" CssClass="formfield" Width="200px">
                    </asp:DropDownList>
                </div>
                <br />
                <div>
                    Do you like to buy T-shirt(s)
                </div>
                <div>
                    <asp:RadioButton ID="rbtnYes" runat="server" GroupName="grpConfirm" Text="Yes" Checked="true" Style="margin-left: 80px" />
                    <asp:RadioButton ID="rbtnNo" runat="server" GroupName="grpConfirm" Text="No" Style="margin-left: 80px" />
                </div>
                <br />
                <div>
                    No. of items
                </div>
                <div>
                    <%--   <asp:TextBox ID="txtNoOfItems" runat="server" CssClass="formfield" placeholder=" No. of items" Text="1"></asp:TextBox>--%>
                    <table border="1" style="margin-left: 80px">

                        <tr>

                            <td rowspan="2">Size
                            </td>

                            <td colspan="2">No. of Items 
                            </td>

                        </tr>
                        <tr>



                            <td>Gents
                            </td>

                            <td>Ladies
                            </td>
                        </tr>
                        <tr>

                            <td>Extra Small</td>

                            <td>
                                <asp:TextBox ID="txtGentsExSmall" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>

                            <td>
                                <asp:TextBox ID="txtLadiesExSmall" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>Small</td>

                            <td>
                                <asp:TextBox ID="txtGentsSmall" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>

                            <td>
                                <asp:TextBox ID="txtLadiesSmall" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>Medium</td>

                            <td>
                                <asp:TextBox ID="txtGentsMedium" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtLadiesMedium" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>Large</td>

                            <td>
                                <asp:TextBox ID="txtGentsLarge" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtLadiesLarge" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>Extra Large</td>

                            <td>
                                <asp:TextBox ID="txtGentsExLarge" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtLadiesExLarge" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>Double Extra Large</td>

                            <td>
                                <asp:TextBox ID="txtGentsDExLarge" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtLadiesDExLarge" runat="server" Text="0" Width="40px" MaxLength="2"></asp:TextBox></td>
                        </tr>

                    </table>



                </div>
                <br />







                <div>
                    Remarks    
                </div>
                <div>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="formfield" placeholder="Remarks" TextMode="MultiLine" Rows="3"></asp:TextBox>

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

