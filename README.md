EmployeeCRUD
============

1. EmployeeDB.sql - Execute this script 
2. Make sure you have proper DB connection in app.config of all the projects:
<connectionStrings>
    <add name="EmployeeDBEntities" connectionString="metadata=res://*/DBModel.csdl|res://*/DBModel.ssdl|res://*/DBModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DSD-LPT-0117\SQLEXPRESS2014;initial catalog=EmployeeDB;user id=sa;password=decos@123;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
  Note: Update based on the your DB connection string
3. Run web application

Note: 
Now, you can perform, Insert, Update and Delete operation. 
Make user, you select one employee record before performting delete/update operation.
