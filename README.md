
# Lab Report Repository (LRR)

Web applications for online student learning. makes it possible to add courses and post grades with lessons. Also the ability to take tests and the ability for students to upload laboratory work.



## Used tools 
 - [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)
 - [EF Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0)
 - [Rich Text Editor](https://richtexteditor.com/)
 - [Bootstrap](https://getbootstrap.com/)

  
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
    - Adding Files
    - File Managment
    - File Upload
    - Add password cources 
    - Add public cources 
    - Update Language support Views

* Release V0.3b
    - Add statistics for Cource
    - Adding pdf Output
    - Adding pdf Subjects Data
    
## Authors

- [@DmytroLamashevskyi](https://github.com/DmytroLamashevskyi)

  
## 🛠 Skills
Javascript, HTML, CSS, ASP.NET CORE MVC, C#, Bootstrap, EF Core

  
