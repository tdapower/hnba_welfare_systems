<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WelfareTripSurvey.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <title>EPF</title>
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
        <div id="wrapper" style="height: 500px;top:100px;margin-top:100px;">

            <fieldset>
                <legend>Enter your EPF Number</legend>
                <div>
                    EPF Number<br />
                </div>
                <br />
                <div>
                    <asp:TextBox ID="txtEPF" runat="server" CssClass="formfield" placeholder="EPF Number"></asp:TextBox>
                </div>

                <div>

                    <asp:Label ID="lblMsg" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed" Class="button" OnClick="btnProceed_Click" />
                </div>


            </fieldset>

        </div>

    </form>
</body>
</html>

