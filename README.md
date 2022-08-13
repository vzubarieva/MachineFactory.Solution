# Dr. Sillystringz's Factory

#### By: Viktoriia Zubarieva

## Description

This is web application which can help to keep track of machine repairs at Dr. Sillystringz's Factory. This MVC web application is managing engineers, and the machines they are licensed to fix. The factory manager can add a list of engineers, a list of machines, and specify which engineers are licensed to repair which machines. There is a many-to-many relationship between Engineers and Machines. It shows that engineer can be licensed to repair (belong to) many machines (such as the Dreamweaver, the Bubblewrappinator, and the Laughbox) and a machine can have many engineers licensed to repair it.

## Technologies Used

- C#
- .Net 5.0
- git
- ASP.NET Core MVC
- Microsoft.EntityFrameworkCore
- Dotnet EntityFramework Tool
- Microsoft.EntityFrameworkCore.Design

## Setup/Installation Requirements

- Clone this project to your desktop with the link provided on the its Github [repository](https://github.com/vzubarieva/MachineFactory.Solution.Solution)
- Navigate to the top level of the directory
- Open in text editor
- Create appsettings.json in MachineFactory/Factory/ directory
- Copy this code into appsettings.json, replacing YOUR_PASSWORD with your MySQL password
  {
  "ConnectionStrings":
  { "DefaultConnection": "Server=localhost;Port=3306;database=factory;uid=root;pwd=YOUR_PASSWORD;" }
  }

- open new terminal and run SQL

  $ mysql -uroot -p{your_password}

- open MySQL Workbench
- In terminal, navigate into MachineFactory/Factory/ and enter this command, to install necessary packages

  $ dotnet restore

- enter this command to build the program

  $ dotnet build

- enter this command to build your database

  $ dotnet ef database update

- check MySql Workbench to make sure the correct database has built
- enter this command to view this application in your browser

  $ dotnet run

## Known Bugs

- _No known bugs_

## License

_Message to viktoria.dubinina@gmail.com with any comments or contributions. This software is licensed under the MIT license_

Copyright (c) _August 2022_ _Viktoriia Zubarieva_
cd
