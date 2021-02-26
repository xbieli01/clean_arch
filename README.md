# CleanXamarin

Showcase of clean architecture with Xamarin Forms.

![arch](images/draw.jpg?raw=true "Architecture")

# Getting Started

- open CleanXamarin.sln
- update database connection string in \Service\MyNewProject.Service\appsettings.json
- start project MyNewProject.Service
- in \App\MyNewProject\config.json update current DBService url
- start any of UI apps .Android, .iOS, .UWP, .Web

# Various database providers

To change database provider, uncomment desired lines in ConfigureServices in \Service\MyNewProject.Service\Startup.cs
Currently there is support for MS Sql, MySQL and Oracle providers.
Entity Framework is used as ORM.
Connection string is defined in \Service\MyNewProject.Service\appsettings.json

# Data source options

Source for data could be change in \App\MyNewProject\App.xaml.cs
and \App\MyNewProject.Web\Startup.cs by changing implementation of IOrdersSource.

# Used technologies

- Xamarin.Forms - UWP, Android, iOS applications
- Ooui - Web presentation for Xamarin.Forms
- Entity Framework - ORM
- Prism.Unity - Xamarin.Forms IoC
- .NET Core Web Api

# Pros and Cons

- **Pros**: Simplified development of application for iOS, Android, Windows and Web with .NET from a single shared codebase. Separate database service for scalability, security and performance.
- **Cons**: Smaller subset of Xamarin toolkit using Xamarin.Forms. Web application must implement some features separately, because of Ooui framework hasn't implemented all Xamarin.Forms features yet.
