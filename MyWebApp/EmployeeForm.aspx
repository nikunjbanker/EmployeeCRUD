<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="MyWebApp.EmployeeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script type="text/javascript">
    function insertEmployee() {
      PageMethods.InsertEmployee(cbSucess, cbFailed);
    }

    function deleteEmployee() {
      var id = document.getElementById('hdnSelectedRowId');
      if (id && id.value) {
        PageMethods.DeleteEmployee(id.value, cbSucess, cbFailed);
      }
    }

    function updateEmployee() {
      var id = document.getElementById('hdnSelectedRowId');
      if (id && id.value) {
        PageMethods.UpdateEmployee(id.value, cbSucess, cbFailed);
      }
    }

    function cbSucess(result, userContext, sMethodName) {
      switch (sMethodName) {
        case "DeleteEmployee":
        case "UpdateEmployee":
          var id = document.getElementById('hdnSelectedRowId');
          if (id && id.value) {
            id.value = '';
          }
          break;
      }
      DoNewPostback();
    }

    function cbFailed() {

    }

    function DoNewPostback(parameter) {
      window.__doPostBack('upMain', parameter);
    }
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="MyScriptManager" runat="server" EnableScriptGlobalization="true" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
      <asp:UpdatePanel UpdateMode="Conditional" ChildrenAsTriggers="false" ID="upMain" runat="server">
        <ContentTemplate>
          <asp:Panel ID="pnlList" runat="server">
            <asp:Label ID="lblHeader" Text="Employee Details" runat="server" BorderStyle="Outset" Style="font-size: large; text-align: center; width: 100%;"></asp:Label>
            </br>
            <asp:GridView ID="MyEmployeeGrid" Width="100%" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="True"
              SelectedIndex="1"
              OnRowDataBound="MyEmployeeGrid_RowDataBound" OnSelectedIndexChanged="MyEmployeeGrid_SelectedIndexChanged">
                
               <EmptyDataRowStyle BackColor="LightBlue"
                ForeColor="Red" />

              <AlternatingRowStyle ForeColor="White" BackColor="LightBlue" />
              <HeaderStyle Font-Bold="true" BackColor="RoyalBlue" ForeColor="White" />
              <EmptyDataTemplate>
                No Data Found.  
              </EmptyDataTemplate>


            </asp:GridView>
            </br>
            <asp:Button Text="Insert" ID="btnInsert" CommandArgument="Insert" OnClientClick="insertEmployee();" runat="server" />
            <asp:Button Text="Delete" ID="btnDelete" CommandArgument="Insert" OnClientClick="deleteEmployee();" runat="server" Enabled="false" />
            <asp:Button Text="Update" ID="btnUpdate" CommandArgument="Insert" OnClientClick="updateEmployee();" runat="server" Enabled="false" />
            <asp:HiddenField ID="hdnSelectedRowId" runat="server" ClientIDMode="Static" OnValueChanged="hdnSelectedRowId_ValueChanged" />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
          </asp:Panel>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
  </form>
</body>
</html>
