using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLibrary;
using System.Data.Entity;

namespace MyWebApp
{
  public partial class EmployeeForm : System.Web.UI.Page
  {
    EmployeeDBEntities _myEntityDb = new EmployeeDBEntities();
    private const int _hiddenIndex = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
      var employees = from emp in GetEmployeeData().ToList()
                      select emp;
      MyEmployeeGrid.DataSource = employees;
      MyEmployeeGrid.DataBind();

      if (IsPostBack) upMain.Update();
    }

    private DbSet<Employee> GetEmployeeData()
    {
      return _myEntityDb.Employees;
    }

    protected void MyEmployeeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.Cells.Count > 1)
      {
        e.Row.Cells[_hiddenIndex].Visible = false;
        if (e.Row.RowType == DataControlRowType.Header)
        {
          //e.Row.Cells[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          //e.Row.Cells[0].Visible = false;
        }
      }
    }

    protected void MyEmployeeGrid_SelectedIndexChanged(Object sender, EventArgs e)
    {
      // Get the currently selected row using the SelectedRow property.
      GridViewRow row = MyEmployeeGrid.SelectedRow;
      hdnSelectedRowId.Value = row.Cells[_hiddenIndex].Text;
      btnDelete.Enabled = true;
      btnUpdate.Enabled = true;
      lblMessage.Text = "You have selected employee id: " + hdnSelectedRowId.Value + " Name:" + row.Cells[_hiddenIndex + 1].Text;
    }


    [System.Web.Services.WebMethod]
    public static bool InsertEmployee()
    {
      bool bReturn = false;
      try
      {
        EmployeeDBEntities myEntityDb = new EmployeeDBEntities();
        Employee emp = new Employee();
        emp.Id = Guid.NewGuid();
        emp.Name = "ABC + " + new Random().Next().ToString();
        emp.DOB = DateTime.Now;
        emp.EmailId = emp.Name + "@abc.com";
        myEntityDb.Employees.Add(emp);
        myEntityDb.SaveChanges();
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex);
      }
      return bReturn;
    }

    [System.Web.Services.WebMethod]
    public static bool DeleteEmployee(string sEmpId)
    {
      bool bReturn = false;
      try
      {
        EmployeeDBEntities myEntityDb = new EmployeeDBEntities();
        var empToDelete = (from emp in myEntityDb.Employees
                           where emp.Id == (new Guid(sEmpId))
                           select emp).SingleOrDefault();
        myEntityDb.Employees.Remove(empToDelete);
        myEntityDb.SaveChanges();
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex);
      }
      return bReturn;
    }


    [System.Web.Services.WebMethod]
    public static bool UpdateEmployee(string sEmpId)
    {
      bool bReturn = false;
      try
      {
        EmployeeDBEntities myEntityDb = new EmployeeDBEntities();
        var empToUpdate = (from emp in myEntityDb.Employees
                           where emp.Id == (new Guid(sEmpId))
                           select emp).SingleOrDefault();
        if (empToUpdate != null)
        {
          empToUpdate.Name = "Update demo " + new Random().Next().ToString() + empToUpdate.Name;
          myEntityDb.SaveChanges();
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex);
      }
      return bReturn;
    }

    protected void hdnSelectedRowId_ValueChanged(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(((HiddenField)sender).Value))
      {
        lblMessage.Text = "";
      }
    }
  }
}