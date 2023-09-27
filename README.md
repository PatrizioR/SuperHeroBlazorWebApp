# SuperHero Blazor Web App

This is a Blazor WebAssembly application that allows you to manage a list of super heroes and their associated movies.

## Getting Started

To run the application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build and run the solution.

## Project Structure

The project is divided into two main parts: the client and the server.

### Client

The client project contains the Blazor WebAssembly application. It includes the following components:

- `MovieListComponent`: Displays a list of movies and allows you to add, edit, and delete movies.
- `MovieEditComponent`: Allows you to create or edit a movie.
- `SuperHeroListComponent`: Displays a list of super heroes and allows you to add, edit, and delete super heroes.
- `SuperHeroEditComponent`: Allows you to create or edit a super hero.

### Server

The server project contains the API and database access logic. It includes the following components:

- `SuperHeroBlazorContext`: The database context class that provides access to the underlying SQLite database.
- `BaseEntityController`: A base controller class that provides CRUD operations for a given entity.
- `SuperHeroController`: A controller class that inherits from `BaseEntityController` and provides additional functionality for super heroes.
- `MovieController`: A controller class that inherits from `BaseEntityController` and provides additional functionality for movies.

## Dependencies

The project has the following dependencies:

- `Microsoft.AspNetCore.Components`: The main Blazor framework.
- `Microsoft.EntityFrameworkCore`: The library for working with databases.
- `Microsoft.Extensions.Configuration`: The library for working with configuration settings.
- `Microsoft.Extensions.DependencyInjection`: The library for dependency injection.
- `System.Net.Http`: The library for making HTTP requests.

## Notes

- The application uses an SQLite database. The database file is located in the root folder of the solution and is named `superhero.sqlite`.
- The application uses Entity Framework Core to interact with the database.
- The client project uses Bootstrap for styling.

## Contributing

Contributions are welcome! If you find any issues or have any suggestions, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
