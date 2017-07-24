# EF-File-Core
A web application which integrates file handling with persisted storage via an ORM to a T-SQL db with data validation.

## Scenario

Build a system which allows for the storing of client information, the data will be imported per client either via a Json or CSV file. 

The client should specify the file path, file type per upload

Data validation should also be added on the imported data. Given the following scenario's the app should act accrodningly:

1) In valid data
  - Set IsValid = false and persist to storage agains the client
2) Valid data
  - Set IsValid = true and persistto storage against the client 

## Tech Stack

  - ASP.NET Core MVC 
  - Entity Framework Core
  - MS SQL

## Installation

TODO: Describe the installation process

## Usage

TODO: Write usage instructions

## Architecture
This repo is by no means a guide nor complete implementation of the following:

- Domain Driven Design Pattern
- Repository Pattern
- Unit Of work patters

The focus is on implementing a solution to the above scenario 

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## License

MIT
