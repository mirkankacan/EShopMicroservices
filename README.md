# EShopMicroservices

## Overview

EShopMicroservices is a sample e-commerce application built using microservices architecture. The project demonstrates the use of various technologies and patterns to create a scalable and maintainable system.

## Features

- **Microservices Architecture**: The application is divided into multiple microservices, each responsible for a specific domain.
- **Blazor**: The front-end is built using Blazor, providing a modern and interactive user experience.
- **ASP.NET Core**: The backend services are built using ASP.NET Core.
- **Docker**: The application is containerized using Docker for easy deployment and scalability.
- **Event-Driven Communication**: Microservices communicate with each other using events.
- **Database Integration**: Each microservice has its own database, ensuring data isolation and consistency.

## Technologies Used

- .NET 9
- C# 13.0
- Blazor
- ASP.NET Core
- Docker
- RabbitMQ (for event-driven communication)
- SQL Server (for database)

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://www.docker.com/get-started)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Installation

1. Clone the repository:
```
git clone https://github.com/mirkankacan/EShopMicroservices.git
```
```
cd EShopMicroservices
```
2. Build and run the Docker containers:
```
docker-compose up --build
```

3. Open the solution in Visual Studio 2022 and build the project.

### Running the Application

1. Ensure Docker is running.
2. Start the application by running the Docker containers:
```
docker-compose up
```

3. Open your browser and navigate to `http://localhost:6005` or `https://localhost:6065` to access the Blazor front-end.

## Project Structure

- **WebApps/Shopping.Web**: Contains the Blazor front-end application.
- **Services**: Contains the various microservices for different domains (e.g., Ordering, Catalog, Basket).
- **BuildingBlocks**: Contains shared libraries and utilities used across multiple services.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contact

For any questions or feedback, please contact [kacanmirkan@gmail.com].


    
