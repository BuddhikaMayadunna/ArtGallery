# ArtGallery - A Web API and MVC client built on .NET 6
This sample code has two applications, Web API and a MVC client application written on .NET 6
It allows to perform some basic functionalities to perform in a system, register a user, login user and perform CRUD operations on a entity

# A Web API built on .NET Core 3.1

## Technology stack
* .NET 6 on Visual Studio 2022
* EF Core 6
* Swashbuckle.AspNetCore 6.3.1

## Resources used
* A relational database on SQL server to store data
* Http client factory to call ArtGallery APIs


## Available APIs
| Url            | Operation                              |    Usage       | Response                                                                                      
| ------------------- | --------------------------------- | ----------------------------------- | -----------------------------------     
| /users/create         | GET              | Retrieve 5 users from the random user API and save in the Inmemory datastore   | Users created : Returns 201 Created with message, 400 Bad Request returns when something goes wrong, 500 Internal server error if its my fault                                      
| /users/get        | GET                             | Retrieve all users from the datastore |  Returns 200 OK with user array, 500 Internal server error if its my fault   
