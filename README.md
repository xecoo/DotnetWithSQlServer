# DotnetWithSQlServer

Web API project for creating and querying basic data using SQL Server database

## How to initiate application

1- It's necessary create a database connection with specified parameters located on project as DefaultConnection;

2- In the oot project, write on cmd the command to create table products

```
dotnet ef --startup-project src/Api/ database update
```

3- Now, execute the next command

```
dotnet run --project src/Api/Api.csproj
```

## How to use routes

You can use swagger to view all routes of project or use the follow routes

GET - https://localhost:5001/api/products
This route show all products order by id registered on sistem.

POST - https://localhost:5001/api/product
This route register a product following the body json as

```
{
    "name":string,
    "description":string
}
```