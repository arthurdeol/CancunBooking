# Cancun Booking
<br/>

Api to book hotel in Cancun following the principles of Clean Arqchitecture

## Technologies

* .NET Core 5
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [FluentAssertions](https://fluentassertions.com/)
* [Docker](https://www.docker.com/)

## Getting Started

1. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
2. Clone the repository into a folder [Repository](https://github.com/arthurdeol/CancunBooking.git)
8. Navigate to `CancunBooking.API/` and run `dotnet run` to launch the back end (.NET Web API)

### Docker Configuration

In order to build and run the docker containers, execute `docker-compose -f 'docker-compose.yml' up --build` from the root of the solution where you find the docker-compose.yml file.  You can also use "Docker Compose" from Visual Studio for Debugging purposes.
Then open http://localhost:5000/swagger/index.html on your browser.

To disable Docker in Visual Studio, right-click on the **docker-compose** file in the **Solution Explorer** and select **Unload Project**.

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project Infra\CancunBooking.Infrastructure` (optional if in this folder)
* `--startup-project API\CancunBooking.API`
* `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project Infra\CancunBooking.Infrastructure --startup-project API\CancunBooking.API --output-dir Persistence\Migrations`


## Support

If you are having problems, please let us know by [raising a new issue](https://github.com/arthurdeol/CancunBooking/issues/new).