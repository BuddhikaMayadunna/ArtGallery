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
* Change default connetion in the appsetting.json according to your environment.


## Available APIs
| Url            | Operation                              |    Usage       | Response                                                                                      
| ------------------- | --------------------------------- | ----------------------------------- | -----------------------------------     
| /api/Auth/register         | POST              | Register user.   | Users created : Returns 201 Created with message, 400 Bad Request returns when something goes wrong, 500 Internal server error if its my fault                                      
| /api/Auth/login        | PSOT                             | Login user |  Returns 200 OK with user array, 500 Internal server error if its my fault   
| /api/Post/Get        | GET                             | Get all posts |  Returns 200 OK with user array, 500 Internal server error if its my fault   
| /api/Post/Create        | POST                             | Create new post |  Returns 200 OK with user array, 500 Internal server error if its my fault
| /api/Post/Update        | PUT                             | Update individual posts |  Returns 200 OK with user array, 500 Internal server error if its my fault
