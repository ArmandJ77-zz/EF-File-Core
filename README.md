# EF-File-Core
A web API which integrates file handling with persisted storage via an ORM to a T-SQL db with data validation.


## Scenario

Build an api which has the ability to:
-> Create clients
-> Create file configuration per client
-> Import contacts via a json/csv file per client file configuration
-> export contacts via json/csv per client file configuration

## Tech Stack

  - ASP.NET Core MVC 
  - Entity Framework Core
  - MS SQL

## Installation

  - Install VS 2017
  - Install .Net Core
  - SSMS 2017
  - Postman

## Setting up EF Core

The connection string may be updated at:

```
Api -> appsettings -> LocalDb
```

To create the database open the **Package Manager Console** and run:

```
Update-Database
```

> **Note:** Ensure that you selected the Database project as the Default project

## DB Structure

-> Client
  - Contains client data
-> ClientFileConfiguration
  - Contains data about the client's file config
-> Contacts
  - Contains imported validated contact data
-> StagingContact
  - Only used for importing contacts via the external api call to get dummy contact information

## Endpoints

  - Clients
    - Contains CRUD operations for clients
  - Contacts
    - Contains enpoints to import/export from files as well as to import form 3rd party api
  - File
    - Contains CRUD operations for file configurations associated with a clientId

## Usage

See postman collection - steps for api usage:

```
https://www.getpostman.com/collections/0a077c9208f1374cc47c
```

## Architecture
This repo is by no means a guide nor complete implementation of the following:

- Domain Driven Design Pattern
- Repository Pattern
- Unit Of work patterns

The focus is on implementing a solution to the above scenario full architectural design patterns may be implemented should the solution grow in functionality

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## License

MIT
