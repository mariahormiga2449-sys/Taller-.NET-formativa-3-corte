# Registro de películas y series

## Descripción
Este proyecto es una aplicación de consola desarrollada en C# que utiliza ADO.NET y SQLite para almacenar y consultar información de películas y series.

La aplicación crea una base de datos llamada `contenido.db` y una tabla llamada `Contenido`, donde se guardan el título, tipo, género y año de cada registro.

## Tecnologías utilizadas
- C#
- .NET
- ADO.NET
- SQLite
- Microsoft.Data.Sqlite

## Funcionamiento
El programa realiza las siguientes operaciones:

1. Establece una conexión con la base de datos SQLite mediante `SqliteConnection`.
2. Crea la tabla `Contenido` si todavía no existe.
3. Elimina los registros anteriores y reinicia el contador de identificadores.
4. Inserta cinco registros de películas y series utilizando `SqliteCommand` y parámetros.
5. Consulta los registros mediante `SqliteDataReader` y los muestra en la consola.
6. Utiliza `using` para administrar los recursos.

## Requisitos
- Tener instalado el SDK de .NET.
- Contar con el paquete `Microsoft.Data.Sqlite`.

## Cómo ejecutar el proyecto

1. Descargar o clonar este repositorio.
2. Abrir una terminal en la carpeta del proyecto.
3. Ejecutar:

```bash
dotnet restore
dotnet run
```

## Evidencias
En la carpeta `Evidencias` se encuentran las capturas de pantalla que muestran la conexión, creación de la tabla, inserción de registros y consulta de la información.

## Autor
Maria Alejandra Hormiga Navarro