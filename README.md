# dotnet-core-microservices


- Dodanie referencji do projektu
~~~ bash
dotnet add app/app.csproj reference lib/lib.csproj
~~~

Przykład
~~~ bash
dotnet add Microservices/Document/Document.Domain/Document.Domain.csproj reference  Core/Infrastructure/Infrastructure.csproj
~~~

- Dodanie projektu do rozwiązania
~~~ bash
dotnet sln add src/Core/Infrastructure/Infrastructure.csproj 
~~~

## MediatR

- Instalacja
~~~ bash
dotnet add package mediatr
dotnet add package mediatr.extensions.microsoft.dependencyinjection
~~~