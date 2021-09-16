# Automated Appointment Scheduler

The Automated Appointment Scheduler application allows businesses to connect with their clients through an online portal. Businesses are able 
to register with the website, set up a schedule, and receive appointments from clients. Clients are able to login to the website and choose which businesses
to set up appointments with and manage those appointments. 

# Technologies

- [React](https://reactjs.org/docs/getting-started.html) with [TypeScript](https://www.typescriptlang.org/docs)
- [Microsoft Fabric UI](https://developer.microsoft.com/en-us/fluentui#/get-started)
- [NSwag](https://github.com/RicoSuter/NSwag) generated DTOs and client for back-end API
- [ASP.NET Core 3.1](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro)
- [MediatR](https://github.com/jbogard/MediatR) as [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) implementation
- [AutoMapper](https://github.com/AutoMapper/AutoMapper) handling Entity-to-DTO mapping
- [Swagger UI](https://github.com/swagger-api/swagger-ui)

#Tools for Development

###IDE's 

[**Visual Studio Code**](https://code.visualstudio.com/) - Ideal for front-end development.<br/>
[**Visual Studio**](https://visualstudio.microsoft.com/) - Can be used for a back-end development. You can use the free community version with this application.<br/>
[**JetBrains Rider**](https://www.jetbrains.com/rider/) - Can also be used for back-end development. There is no free version, but you can get a student license.<br/>

###Database

[**SQL Server Express**](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) - The LocalDB configuration of SQL Server is used for this application. You must be sure to select this feature during the installation in the installation wizard.<br/>
[**SQL Server Management Studio**](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) - Management studio provides a UI to manage the DB tables. 

###SDK's
[**.NET Core SDK**](https://dotnet.microsoft.com/download) - The .NET SDK is required to run the application. This will provide the backend functionality. Download the .NET 5.0 SDK through the link.<br/> 
[**Node.js LTS**](https://nodejs.org/en) - Node is also required to run the application. Download the recommended package(Currently 14.17.6).

# How to run

1. Clone the repo into a local directory of your choosing. 
2. Open your terminal and navigate to the service directory of the application. 
3. Run the commands below. 
```sh
dotnet build
dotnet run --project AAS.API
```
4. Open your browser and navigate to: `https://localhost:44345/swagger`. This will show the API functionality in the Swagger UI. 
5. While keeping the prior terminal open, start another terminal and navigate to the client directory of the application. 
6. Run the commands below. 
```sh
npm install
npm start
```
6. Your browser should automatically open a page going to `https://localhost:3000`. This will show the front-end of the application.  

# Adding an Entity Framework Core migration

1. Open a command prompt in the **AAS.Data** folder.
2. `dotnet tool install --global dotnet-ef`
3. `dotnet ef migrations add <NAME OF MIGRATION>`
4. If you have changed the structure of the database, you may have to run the following command in the data folder to make the update live.\
   `dotnet ef database update`

# Removing the latest Entity Framework Core migration

1. Open a command prompt in the **AAS.Data** folder.
2. `dotnet ef migrations remove`




