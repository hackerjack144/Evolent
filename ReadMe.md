Evolent Assignment For Managing Contact Details.

1. This assignment contains three projects.
	a. DataLayer - A class library solution that contains EF and Data Access Logic
	b. Web API - It has APIs
	c. Consumer - MVC application that consume APIs for displaying the data in UI.

2. Database:
	I have used SQL Server as Database for this assignment. For review, DB script is placed under DB Script folder, path will be : ../EvolentAssignment.WebAPI/EvolentAssignment.DataAccess/DB Script
	
Steps:

1. Run the DB script in SQL server which will create a Database named as "EvolentAssignment" and create a table named as "Contacts".

2. After cloning to local or downloading the source code for review, kindly Restore the nuget packages (in case anything is missing while uploading)

3. To see the application output, run "EvolentAssignment.WebAPI" project first which runs on localhost at "https://localhost:44355/".
	APIs path are respectively...
		a. GetAllContacts: https://localhost:44355/api/Contact/GetAllContacts
		b. GetContact: https://localhost:44355/api/Contact/GetContact/{id}
		c. InsertContact:https://localhost:44355/api/Contact/UpdateContact
		d. UpdateContact: https://localhost:44355/api/Contact/UpdateContact
		e. DeleteContact (only change the status from Active to Inactive): https://localhost:44355/api/Contact/DeleteContact/{id}
Note: Swagger is not installed so on browser, only first two APIs shows result in JSON, other are POST APIs so need to create a complete payload to run them. No worries, output will be shown in consumer solution.

4. Consumer solution which is nothing but MVC application, running on the default path: "https://localhost:44335/".
To see the All contact landing page, kindly enter this URL -> "https://localhost:44335/Contact/GetAllContacts"

5. After that you can perform all the CURD operation.

PS: Both solutions must be running on browser.

<!---------------------------------------------------------------------------------------------------------------------->

Connections String:

1. In Datalayer (app.config) and API solution (web.config), following connection string is used for connecting the database.
	
	<connectionStrings>
    <add name="EvolentAssignmentEntities" connectionString="metadata=res://*/ContactManager.csdl|res://*/ContactManager.ssdl|res://*/ContactManager.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\SQLEXPRESS;initial catalog=EvolentAssignment;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
	</connectionStrings>
	
PS: Please change the datasource as per you DB server name.

2. While running "EvolentAssignment.WebAPI", if it runs on different port as compare to "https://localhost:44355/" this. Then go to "EvolentAssignment.APIConsumer" solution and search for this key --> "<add key="ServiceUrl" value="https://localhost:44355/"></add>" in Web.config file and change the value of port where this application is running on your browser.