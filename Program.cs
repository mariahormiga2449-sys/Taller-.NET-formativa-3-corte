
using Microsoft.Data.Sqlite;
string cadenaConexion = "Data Source=contenido.db";
using (var conexion = new SqliteConnection(cadenaConexion))
{
    conexion.Open();
    Console.WriteLine("====================================");
    Console.WriteLine("   REGISTRO DE PELÍCULAS Y SERIES");
    Console.WriteLine("====================================");
    Console.WriteLine("Conexión a SQLite establecida correctamente.");
    // aqui se crea la tabla Contenido
    string crearTabla = @"
        CREATE TABLE IF NOT EXISTS Contenido (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Titulo TEXT NOT NULL,
            Tipo TEXT NOT NULL,
            Genero TEXT NOT NULL,
            Anio INTEGER NOT NULL
        );";

    using (var comando = new SqliteCommand(crearTabla, conexion))
    {
        comando.ExecuteNonQuery();
    }
    Console.WriteLine("Tabla creada correctamente.");
    // elimina registros anteriores y reiniciar el contador de ID
    string eliminar = @"
        DELETE FROM Contenido;
        DELETE FROM sqlite_sequence WHERE name = 'Contenido';
    ";

    using (var comando = new SqliteCommand(eliminar, conexion))
    {
        comando.ExecuteNonQuery();
    }

    // inserta los cinco registros de peliculas y series en la tabla Contenido
    string insertar = @"
        INSERT INTO Contenido (Titulo, Tipo, Genero, Anio)
        VALUES (@titulo, @tipo, @genero, @anio);";

    using (var comando = new SqliteCommand(insertar, conexion))
    {
        comando.Parameters.AddWithValue("@titulo", "The Midnight Gospel");
        comando.Parameters.AddWithValue("@tipo", "Serie");
        comando.Parameters.AddWithValue("@genero", "Animación / Ciencia ficción");
        comando.Parameters.AddWithValue("@anio", 2020);
        comando.ExecuteNonQuery();

        comando.Parameters.Clear();
        comando.Parameters.AddWithValue("@titulo", "Everything Everywhere All at Once");
        comando.Parameters.AddWithValue("@tipo", "Película");
        comando.Parameters.AddWithValue("@genero", "Ciencia ficción / Aventura");
        comando.Parameters.AddWithValue("@anio", 2022);
        comando.ExecuteNonQuery();

        comando.Parameters.Clear();
        comando.Parameters.AddWithValue("@titulo", "Love, Death & Robots");
        comando.Parameters.AddWithValue("@tipo", "Serie");
        comando.Parameters.AddWithValue("@genero", "Animación / Ciencia ficción");
        comando.Parameters.AddWithValue("@anio", 2019);
        comando.ExecuteNonQuery();

        comando.Parameters.Clear();
        comando.Parameters.AddWithValue("@titulo", "Black Mirror");
        comando.Parameters.AddWithValue("@tipo", "Serie");
        comando.Parameters.AddWithValue("@genero", "Ciencia ficción / Suspenso");
        comando.Parameters.AddWithValue("@anio", 2011);
        comando.ExecuteNonQuery();

        comando.Parameters.Clear();
        comando.Parameters.AddWithValue("@titulo", "Cuando acecha la maldad");
        comando.Parameters.AddWithValue("@tipo", "Película");
        comando.Parameters.AddWithValue("@genero", "Terror");
        comando.Parameters.AddWithValue("@anio", 2023);
        comando.ExecuteNonQuery();
    }
    Console.WriteLine("Los cinco registros fueron insertados correctamente.");
    string consultar = "SELECT * FROM Contenido;";
    using (var comando = new SqliteCommand(consultar, conexion))
    using (var lector = comando.ExecuteReader())
    {
        Console.WriteLine("====================================");
        Console.WriteLine("       CONTENIDO REGISTRADO");
        Console.WriteLine("====================================");
        while (lector.Read())
        {
            Console.WriteLine($"ID: {lector["Id"]}");
            Console.WriteLine($"Título: {lector["Titulo"]}");
            Console.WriteLine($"Tipo: {lector["Tipo"]}");
            Console.WriteLine($"Género: {lector["Genero"]}");
            Console.WriteLine($"Año: {lector["Anio"]}");
            Console.WriteLine("------------------------------------");
        }
    }
}
Console.WriteLine("Programa finalizado correctamente.");
