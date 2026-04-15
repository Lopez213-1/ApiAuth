# API de Gestion de Tareas con JWT

API REST desarrollada en ASP.NET Core que implementa autenticacion con JWT, proteccion de endpoints y arquitectura en Capas.

## Funcionalidades 

- Registro de usuarios
- Login con generacion de token JWT
- Proteccion de endpoints con [Authorize]
- CRUD de tareas

## Tecnologias 

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT

## Arquitectura

API basada en la arquitectura en capas

- Controller: Manejo de Request y Responde
- Service: Logica de negocio
- Repository: Acceso a datos

## Pasos para ejecutar la API

- clonar el repositorio 
- configurar appsettings.json basado en el ejemplo "appsettings.example.json"
- ejecutar la Api (dotnet run)