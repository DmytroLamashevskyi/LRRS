
# Lab Report Repository (LRR)

Web applications for online student learning. makes it possible to add courses and post grades with lessons. Also the ability to take tests and the ability for students to upload laboratory work.


## Screenshots

### Access Managment 
![Access Managment](https://github.com/DmytroLamashevskyi/LRRS/blob/master/Screens/AccessManagment.png?raw=true)
### Cource Students Managment
![CourceStudentsManagment Screenshot](https://github.com/DmytroLamashevskyi/LRRS/blob/master/Screens/CourceStudentsManagment.png?raw=true)
### Cources
![Cources Screenshot](https://github.com/DmytroLamashevskyi/LRRS/blob/master/Screens/Cources.png?raw=true)
### Grades
![Grades Screenshot](https://github.com/DmytroLamashevskyi/LRRS/blob/master/Screens/Grades.png?raw=true)
### Lectures
![Lectures Screenshot](https://github.com/DmytroLamashevskyi/LRRS/blob/master/Screens/Lectures.png?raw=true)
### User Managment
![UserManagment Screenshot](https://github.com/DmytroLamashevskyi/LRRS/blob/master/Screens/UserManagment.png?raw=true)

[Other Screenshots](https://github.com/DmytroLamashevskyi/LRRS/blob/master/Screens/)

  

## Used tools 
 - [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)
 - [EF Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0)
 - [Rich Text Editor](https://richtexteditor.com/)
 - [Bootstrap](https://getbootstrap.com/)
 - [Fontawesome icons](https://fontawesome.com/)
 - [MailKit](https://www.nuget.org/packages/MailKit/2.15.0?_src=template)
 - [MimeKit](https://www.nuget.org/packages/MimeKit/2.15.1?_src=template)
## Run Locally

Clone the project

```bash
  git clone https://github.com/DmytroLamashevskyi/LRRS.git
```

Open to the project

```bash
  ..\LRRS\LRRS\LRRS.sln
```

Install dependencies

```bash
    # Updates all packages in all projects in the solution
    Update-Package 
    Update-Package –reinstall
```
Change data in file **appsettings.json**

```code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-WebApp-171D3A48-B83E-41C5-87F4-9D57B5441C7E;Trusted_Connection=True;MultipleActiveResultSets=true"
  }  
```
Update SuperAdmin user
```code
  "SuperAdmin": { 
    "UserName": "superadmin",
    "FirstName": "Admin",
    "LastName": "Administrator",
    "Email": "superadmin@gmail.com",
    "PasswordHash": "123Pa$$word." //PaswordData
  },
```

Update mail stmp server
```code
  "EmailConfiguration": {
    "From": "mail@gmail.com",
    "SmtpServer": "smtp.gmail.com",
    "Port": 465,
    "Username": "login",
    "Password": "password"
  },
```

Update Password requirements
```code
  "PasswordRequirements": {
    "RequiredLength": 6,
    "RequiredUniqueChars": 0,
    "RequireNonAlphanumeric": false,
    "RequireLowercase": true,
    "RequireUppercase": false,
    "RequireDigit": false
  },
```  

Add migration for Data base
```code
PM> Add-Migration <Name>
```
Run migration for Data base
```code
PM> Update-Database
```
[About migration in EF Core](https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx)

Run Application and login using **SuperAdmin** Credentials

## Installation on Server
   
  [Publish an ASP.NET Core app to IIS](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-5.0&tabs=visual-studio)
  [Publish an ASP.NET Core App to Azure](https://medium.com/net-core/deploy-an-asp-net-core-app-with-ef-core-and-sql-server-to-azure-e11df41a4804)  

  Remember to install DB credentials and run Migration on VS

## Roadmap

* Release V0.1b 
    - Register and Login for Users
    - User Management
    - Adding Courses
    - Course Management
    - Add students to Course
    - Add Lessons
    - Added Lessons TextArea 
    - Adding Grades
    - Add Lessons 
    - Prepare Language support

* Release V0.2b
    - Block for Users 
    - File Managment
    - File Upload
    - File Upload Limits (for DB 3Mb Max)
    - Adding Files in Database and on Server
    - Added File unique name generation
    - Add password cources  
    - Update Language support Views
    - Added mail change Password
    - Added mail password confirmation

* Release V0.3b
    - Add statistics for Cource
    - Add upload Files to Lecture 
    - Add Lecture deadline 
    - Add mailing to Students (add checkbox for this)
    - Adding pdf file generating
    - Bugfix
    - Refactoring
    
* Release V0.4b
    - Add Tests environment
    - Add News Envierment 
    - Adding Administrator Tab for application settings managment   
    - Finish implementing Language pages
    - Add Paging for Cources and Users panels
    - Refactoring

* Release V0.5b
    - Add Version controll for DB
    - Add mail information sending

## Authors

- [@DmytroLamashevskyi](https://github.com/DmytroLamashevskyi)

  
## 🛠 Skills
Javascript, HTML, CSS, ASP.NET CORE MVC, C#, Bootstrap, EF Core

  
