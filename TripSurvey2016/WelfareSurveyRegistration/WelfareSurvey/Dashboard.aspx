<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WelfareSurvey.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="tmrUpdateTimer" runat="server" Interval="5000" OnTick="tmrUpdateTimer_Tick" />
        <div>
            <div style="width: 200px; height: 200px;left:50px; top:50px;position:absolute;background-color: yellow; font-size: x-large; text-align: center; vertical-align: middle; font-weight: 600;">
                Member Count
            <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" style="padding-top: 30px;">
                <ContentTemplate>
                    <asp:Literal ID="ltrlMemberCount" runat="server"></asp:Literal>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tmrUpdateTimer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
            <div style="width: 200px; height: 200px;left:250px;  top:50px;position:absolute;background-color: aqua; font-size: x-large; text-align: center; vertical-align: middle; font-weight: 600;">
                Spouse Count
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" style="padding-top: 30px;">
                <ContentTemplate>
                    <asp:Literal ID="ltrlSpouseCount" runat="server"></asp:Literal>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tmrUpdateTimer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
            <div style="width: 200px; height: 200px;left:450px;  top:50px;position:absolute;background-color: pink; font-size: x-large; text-align: center; vertical-align: middle; font-weight: 600;">
                Total Kids Count
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" style="padding-top: 30px;">
                <ContentTemplate>
                    <asp:Literal ID="ltrlKidsCount" runat="server"></asp:Literal>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tmrUpdateTimer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
             <div style="width: 200px; height: 200px;left:650px;  top:50px;position:absolute;background-color: lightgoldenrodyellow; font-size: x-large; text-align: center; vertical-align: middle; font-weight: 600;">
                Kids Below 6 Count
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" style="padding-top: 30px;">
                <ContentTemplate>
                    <asp:Literal ID="ltrlKidsBelow6Count" runat="server"></asp:Literal>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tmrUpdateTimer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
