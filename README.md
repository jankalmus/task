**Task**

1. Correct all of the deficiencies in index.html

2. "Sectors" selectbox:
   1. Add all the entries from the "Sectors" selectbox to database
   2. Compose the "Sectors" selectbox using data from database

3. Perform the following activities after the "Save" button has been pressed:
   1. Validate all input data (all fields are mandatory)
   2. Store all input data to database (Name, Sectors, Agree to terms)
   3. Refill the form using stored data
   4. Allow the user to edit his/her own data during the session

**Solution**

To solve this task, I decided to approach with a basic ASP.NET Razor Pages application. This approach allowed me to use builtin functionalities for requests, validations and very simply integrate sessions and a database. This approach also ensures that the application will remain easily extendable and is not limited to the required functionality.

Because of this, the final Index.html is now found in Index.cshtml. 

To run the application, there are the following options: 

* Open a terminal in the Application ***project*** folder and run the following command:
  ``docker compose up``
  * The application will automatically bootstrap itself. Migrations and seeding is automatic. 
    Open the application in http://localhost:443
* Spin a PostgreSQL instance in its native port and run the application locally through your preferred IDE. The application will run in http://localhost:5074/. Adapt the connection string according to your settings and credentials. 