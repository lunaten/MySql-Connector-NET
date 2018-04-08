<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_20180407_DataSet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
    function Change()
    {
        
        //var chk1 = document.getElementById("MainContent_CheckBox1");
        //var chk2 = document.getElementById("MainContent_CheckBox2");
        var chk1 = document.getElementById("CheckBox1");
        var chk2 = document.getElementById("CheckBox2");
        if (document.forms[0].CheckBox1.checked == true)
        {
            // 2番目のチェックボックスがオンなら1番目もオンにする
            document.forms[0].CheckBox2.checked = true;
        }
        else
        {
            // 2番目のチェックボックスがオンなら1番目もオンにする
            document.forms[0].CheckBox2.checked = false;
        }
    }
    </script>
    
    <h3>DataSet</h3>
    <h5>・userテーブル</h5>
    　<asp:Label id="lbl1" runat="server" Width="368px" EnableViewState="False"></asp:Label>
    <hr>
    <h3>CheckBox</h3>
    <h5>・Server Side</h5>
    　<asp:CheckBox id="chk1" runat="server" EnableViewState="False" AutoPostBack="true" OnCheckedChanged="chk1_CheckedChanged1"></asp:CheckBox>１
    　<asp:CheckBox id="chk2" runat="server" EnableViewState="False" AutoPostBack="true" OnCheckedChanged="chk1_CheckedChanged1"></asp:CheckBox>２
    <h5>・Client Side</h5>
    　<input type="checkbox" name="CheckBox1" value="" onclick="Change()">１
    　<input type="checkbox" name="CheckBox2" value="" onclick="Change()">２

</asp:Content>
