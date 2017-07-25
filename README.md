# EF-File-Core
A web application which integrates file handling with persisted storage via an ORM to a T-SQL db with data validation.

> **Note:** This project is still under development and not yet ready for pull requests

## Scenario

Build a system which allows for the storing of client information, the data will be imported per client either via a Json or CSV file. 

The client should specify the file path, file type per upload

Data validation should also be added on the imported data. Given the following scenario's the app should act accordingly:

1) In valid data
  - Set IsValid = false and persist to storage agains the client
2) Valid data
  - Set IsValid = true and persist to storage against the client 

## Tech Stack

  - ASP.NET Core MVC 
  - Entity Framework Core
  - MS SQL

## Installation

  - Install VS 2017
  - Install .Net Core
  - SSMS 2017

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

## Endpoints

  - Clients
    - Contains CRUD operations for clients
  - Contacts
    - At this point it only imports from 3rd party api and asscoiates it with a client
  - File
    - Contains CRUD operations for file configurations associated with a clientId

## Architecture
This repo is by no means a guide nor complete implementation of the following:

- Domain Driven Design Pattern
- Repository Pattern
- Unit Of work patterns

The focus is on implementing a solution to the above scenario full architectural design patterns may be implemented should the solution grow in functionality

## Testing

TODO: Will be using xunit for integration tests

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## License

MIT
