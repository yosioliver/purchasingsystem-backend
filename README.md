# purchasingsystem-backend

This is the Repository for the Backend Stack for The Phone Balance Purchasing System.

# Requierements

For Database :
  - PostgreSQL 11 (PostgreSQL 10 will be ok)
  - you can install here : [Download PostgreSQL](https://www.postgresql.org/download/)
  - Or, if you using MacOS Machine you can install brew here : [Download Brew](https://brew.sh)
  - After brew installed on your MacOS Machine, type the command below for installing PostgreSQL 11 :

```sh
$ brew install postgresql@11
```
Setup your Database :
  - You can use DBeaver for Administering your PostgreSQL Database
  - You can install DBeaver here : [Download DBeaver](https://dbeaver.io/download/)
  - After installing DBeaver, you can setup the Database (please see images below for the instruction)

![Postgre](https://i.ibb.co/vwz9Xns/Screen-Shot-2021-01-17-at-19-27-58.png)

On the image above, Select PostgreSQL for your Database Connection, after that you can fill the information like the image below : 

![Postgre](https://i.ibb.co/F8jhhDk/Screen-Shot-2021-01-17-at-19-35-37.png)

Usually the Default Database is postgres, Username is like your computer name (in this case my computer name is : yosioliver) Then click Test Connection, if your fill the information correctly, pop up will appear like the image below : 

![Postgre](https://i.ibb.co/6B15XRN/Screen-Shot-2021-01-15-at-15-28-20.png)

Next step is Creating New Role (in this case my role username is purchasingsysusr, my password is PurchasingSys1234!@#$), please see image below for detail : 

![Postgre](https://i.ibb.co/G9LNM5r/Screen-Shot-2021-01-17-at-19-47-29.png)

After Creating New Role, then you need to create new Database (in this case my database name. : purchasingsysdb), set Owner for purchasingsysdb To purchasingsysusr.
Please see image below for detail : 

![Postgre](https://i.ibb.co/Prz4CLf/Screen-Shot-2021-01-17-at-19-47-08.png)

For Backend API / REST Api : 
  - .Net Core Framework Version 3.1
  - You can install here : [Download .Net Core SDK](https://dotnet.microsoft.com/download) - Please choose version : 3.1 for the compability with this Project (Because this Project built with .Net Core Version 3.1)


After successfully installing .Net Core SDK, type the command below on your terminal/console :

```sh
$ dotnet --version
```

After that, if .Net Core SDK installed successfully, you will prompted as below on your terminal/console :

```sh
$ 3.1.0
```

Open your Project with Visual Studio Code or Visual Studio Community For Mac/Windows (FREE)

> I will recommend Visual Studio Community For Mac/Windows, because it is really powerfull for the Project that built with .Net Core Framework (you only need to click for clean, build and publish the .Net Core Projects)

You can download Visual Studio Code here : [Download Visual Studio Code](https://code.visualstudio.com)

### Open your Project on IDE (VS Code / VS Community for Mac/Windows)

On the Visual Studio Community for Mac/Windows you can choose/pick *.sln (solution file) file. 
In this case the Project Name is PurchasingSystemServices.sln

On Visual Studio Code you need to choose the root Directory of The Project
After open the project on your Favorite IDE

Type this command on your console/terminal (you must inside the Project Folder : PurchasingSystemServices).
Please follows the step below :

Step 1. 
  - For Clean the Project
```sh
$ dotnet clean
```
Step 2. 
  - Restores the dependencies and tools of a project.
```sh
$ dotnet restore
```
Step 3. 
  - For Build the Project
```sh
$ dotnet build
```

After that, you need to make sure your Application Setting file (appsettings.json) as follows :

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "PgsqlConnection": "User ID=purchasingsysusr;Password=PurchasingSys1234!@#$;Server=localhost;Port=5432;Database=purchasingsysdb"
  },
  "AllowedHosts": "*"
}

```

Please make sure your Connection String for the User ID (same with the Role that you create before), the Database (same with the Database that you create before) and the Password (same with the Role Password that you create before).

### Database Migration

In this case im using Entity Framework Code First concept. Because Entity Framework CLI is not shipped with .Net Framework 3.1, you need to Install the Entity Framework CLI with command below on your console/terminal : 

```sh
$ dotnet tool install --global dotnet-ef
```

Migrate the Database with using the Entity Framework CLI.
Please type this command on your terminal/console (you must inside the Project Folder : PurchasingSystemServices) :

```sh
$ dotnet ef migrations add InitialCreate
```

Update the Database Migration for commiting the Database file that created by Entity Framework
Please type this command on your terminal/console (you must inside the Project Folder : PurchasingSystemServices) :

```sh
dotnet ef database update
```

Finally, you need to run your application.
Please type this command on your terminal/console (you must inside the Project Folder : PurchasingSystemServices) :

```sh
dotnet run
```

Your Application will be running on url : https://localhost:5001/api/{your-controller-name}

> This Application is running on Default Port : 5001 and use HTTPS

You need to create the Self Signing Certificate.

About the Self Signing Certificate you can read the documentation here : [Self Signing Certificate](https://devcenter.heroku.com/articles/ssl-certificate-self)

You can create Self Signing Certificate with dotnet cli command as follows : 

```sh
dotnet dev-certs https --trust
```

License
----

MIT


**Made with Love by Free Software Technologies Stack**
